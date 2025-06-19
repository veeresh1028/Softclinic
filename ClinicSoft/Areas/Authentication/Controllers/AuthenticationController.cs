using BusinessEntities;
using Google.Type;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Authentication.Controllers
{
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            try
            {                

                SecurityResponse _response = SecurityBreak.CheckLicense();

                if (_response.StatusCode == 200)
                {
                    if (!string.IsNullOrEmpty(_response.DisplayMessage))
                    {
                        ModelState.AddModelError(string.Empty, _response.DisplayMessage);
                    }

                    if (this.Request.IsAuthenticated)
                    {
                        return this.RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, _response.DisplayMessage);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return this.View();
        }

        private string GetClientIpAddress(HttpRequestBase request)
        {
            string ipAddress = request.UserHostAddress;

            // Check if the request is coming from behind a proxy or load balancer
            string forwardedForHeader = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(forwardedForHeader))
            {
                // The X-Forwarded-For header can contain multiple IP addresses separated by commas.
                // The first one is the actual client IP address.
                ipAddress = forwardedForHeader.Split(',')[0].Trim();
            }

            return ipAddress;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CurrentUser user = BusinessLogicLayer.Login.Employees_Check_Login_Details(model.UserName, model.Password);

                    if (user.isValid)
                    {
                        bool isAllowed = true;
                        
                        //if (!string.IsNullOrEmpty(user.emp_outside_access))
                        //{
                        //    if (user.emp_outside_access == "Allowed")
                        //    {
                        //        isAllowed = true;
                        //    }
                        //    else
                        //    {
                        //        string userIP = GetClientIpAddress(Request);
                        //        string clinicIP = ConfigurationManager.AppSettings["FacilityPublicIP"];
                        //        if(!string.IsNullOrEmpty(userIP) && !string.IsNullOrEmpty(clinicIP))
                        //        {

                        //        }
                        //    }
                        //}

                        bool pwExpired = false;
                        if (isAllowed)
                        {
                            if (user.password_validity <= 0)
                            {
                                pwExpired = true;
                                ModelState.AddModelError(string.Empty, "Your password has expired! To continue, please change your password.");
                            }
                            else if (user.password_validity == 1)
                            {
                                TempData["passExpiry"] = "Your password will expire tomorrow!";
                                ModelState.AddModelError(string.Empty, "Your password will expire tomorrow! To ensure uninterrupted access, please change your password.");
                            }
                            else if (user.password_validity <= 7)
                            {
                                TempData["passExpiry"] = $"Your password will expire in {user.password_validity} days!";
                                ModelState.AddModelError(string.Empty, $"Your password will expire in {user.password_validity} days! To ensure uninterrupted access, please change your password.");
                            }

                            if (!pwExpired)
                            {
                                bool firstime = BusinessLogicLayer.Login.Employees_Check_First_Time_LogIn(user.empId);

                                if (!firstime)
                                {
                                    this.SignInUser(user.empId, user.emp_login, user.emp_name, user.emp_dept, user.emp_dept_name, user.designation, user.set_company, user.emp_branch, user.emp_desig, user.emp_photo, false);

                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = user.empId,
                                        log_desc = "User Login IP = " + GetClientIpAddress(Request)
                                    });

                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = user.empId,
                                        log_desc = $"{user.emp_name} logged into the system!"
                                    });

                                    Dictionary<int, bool> dict = PageControl.getMenuAccess(user.empId);
                                    TempData["MenuAccess"] = dict;

                                    BusinessLogicLayer.Masters.Employees.EmployeeLoggedInTime(user.empId, "I");

                                    bool isDashboard = (dict == null) ? false : ((dict.ContainsKey((int)Pages.Dashboard)) ? dict[(int)Pages.Dashboard] : false);

                                    if (!string.IsNullOrEmpty(returnUrl))
                                    {
                                        return this.RedirectToLocal(returnUrl);
                                    }
                                    else
                                    {
                                        return isDashboard ? RedirectToAction("DashboardIndex", "MyDashboard", new { area = "Dashboard" })
                                                    : RedirectToAction("Employees", "Employees", new { area = "Masters" });
                                    }
                                }
                                else
                                {
                                    ModelState.AddModelError(string.Empty, "Please change the password to login!");
                                }
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Not allowed to access outside the clinic");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Oops! Something went wrong. Please try again later or contact support. : " + ex.Message);
            }
            return this.View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            try
            {
                if (Url.IsLocalUrl(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this.RedirectToAction("LogOff", "Authentication", new { area = "Authentication" });
        }

        private void SignInUser(int empId, string username, string emp_name, int emp_dept, string emp_dept_name, string role, string company, int emp_branch, int desigId, string emp_photo, bool isPersistent)
        {
            SecurityResponse _response = SecurityBreak.CheckLicense();

            if (_response.StatusCode == 200)
            {
                var claims = new List<Claim>();

                try
                {
                    claims.Add(new Claim(ClaimTypes.Sid, empId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, username));
                    claims.Add(new Claim(ClaimTypes.GivenName, emp_name));
                    claims.Add(new Claim(ClaimTypes.Locality, emp_dept.ToString()));
                    claims.Add(new Claim(ClaimTypes.Surname, emp_dept_name));
                    claims.Add(new Claim(ClaimTypes.Role, role));
                    claims.Add(new Claim(ClaimTypes.PrimarySid, company));
                    claims.Add(new Claim(ClaimTypes.GroupSid, emp_branch.ToString()));
                    claims.Add(new Claim(ClaimTypes.Version, desigId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Thumbprint, emp_photo.ToString()));
                    claims.Add(new Claim(ClaimTypes.IsPersistent, emp_photo.ToString()));

                    var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                    var ctx = Request.GetOwinContext();
                    var authenticationManager = ctx.Authentication;
                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            var emp_name = claims.Where(c => c.Type == ClaimTypes.GivenName).Select(c => c.Value).SingleOrDefault();
            var empId = claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault();

            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
            {
                log_by = Convert.ToInt32(empId),
                log_desc = $"{emp_name} logged off from the system!"
            });

            BusinessLogicLayer.Masters.Employees.EmployeeLoggedInTime(Convert.ToInt32(empId), "O");

            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Authentication", new { area = "Authentication" });
            //return Json(new { isLoggedOut = true, message = "Logged out" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult UnAuthorizedAccess()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult ChangePassword(string returnUrl)
        {
            try
            {
                SecurityResponse _response = SecurityBreak.CheckLicense();

                if (_response.StatusCode == 200)
                {
                    if (!string.IsNullOrEmpty(_response.DisplayMessage))
                    {
                        ModelState.AddModelError(string.Empty, _response.DisplayMessage);
                    }

                    if (this.Request.IsAuthenticated)
                    {
                        return this.RedirectToLocal(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, _response.DisplayMessage);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ResetPassword model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CurrentUser user = BusinessLogicLayer.Login.Employees_Check_Login_Details(model.username, model.old_password);

                    if (user.isValid)
                    {
                        string saltpass;
                        string hashpass = SecurityLayer.Encryptions.CreateHash(model.password, out saltpass);

                        bool isUsed = BusinessLogicLayer.Login.Employees_Password_History(model.username, model.password);

                        if (!isUsed)
                        {
                            bool isUpdated = BusinessLogicLayer.Login.Employees_Change_Password(hashpass, saltpass, user.empId);

                            if (isUpdated)
                            {
                                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                {
                                    log_by = user.empId,
                                    log_desc = $"{user.emp_name} changed password!"
                                });

                                BusinessLogicLayer.Common.LogicHelpers.SaveLogFile(user.emp_name, Encryptions.Encrypt(Encryptions.GetHashKeyForVision("RutwikManish"), model.password));

                                return RedirectToAction("Login", "Authentication");
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, "Failed to Update Password! Please Try Again After some time.");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Sorry, You cannot reuse previously used passwords due to security reasons!");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid Username or Password");
                    }
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Oops! Something went wrong. Please try again later or contact support.");
            }
            return this.View(model);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}