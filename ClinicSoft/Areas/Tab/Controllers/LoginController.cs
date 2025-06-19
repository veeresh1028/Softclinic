using BusinessEntities;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Tab.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                SecurityResponse _response = SecurityBreak.CheckLicense();

                if (_response.StatusCode == 200)
                {
                    string returnUrl = string.Empty;

                    if (!string.IsNullOrEmpty(_response.DisplayMessage))
                    {
                        ModelState.AddModelError(string.Empty, _response.DisplayMessage);
                    }

                    if (this.Request.IsAuthenticated)
                    {
                        RedirectToLocal(returnUrl);
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
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CurrentUser user = BusinessLogicLayer.Login.Employees_Check_Login_Details(model.UserName, model.Password);

                    if (user.isValid)
                    {
                        bool pwExpired = false;

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
                                this.SignInTabUser(user.empId, user.emp_login, user.emp_name, user.emp_dept, user.emp_dept_name, user.designation, user.set_company, user.emp_branch, user.emp_desig, user.emp_photo, false);

                                if (!string.IsNullOrEmpty(returnUrl))
                                {
                                    return this.RedirectToLocal(returnUrl);
                                }
                                else
                                {
                                    return RedirectToAction("PatientConsents", "PatientConsents", new { area = "Tab" });
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

            return this.RedirectToAction("LogOut", "Login", new { area = "Tab" });
        }

        private void SignInTabUser(int empId, string username, string emp_name, int emp_dept, string emp_dept_name, string role, string company, int emp_branch, int desigId, string emp_photo, bool isPersistent)
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
            else
            {
                Response.Write("Please check License");
            }
        }

        [HttpGet]
        public ActionResult LogOut()
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

            return RedirectToAction("Login", "Login", new { area = "Tab" });
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;

            filterContext.Result = RedirectToAction("ErrorTab", "Common", new { area = "Tab" });
        }
    }
}