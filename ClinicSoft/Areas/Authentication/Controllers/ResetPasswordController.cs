using BusinessEntities;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static Google.Apis.Requests.BatchRequest;


namespace ClinicSoft.Areas.Authentication.Controllers
{
    [AllowAnonymous]
    public class ResetPasswordController : Controller
    {
        [HttpGet]
        public ActionResult ResetPassword(string token)
        {
            mResetPassword mReset = new mResetPassword();

            try
            {
                if (token != null)
                {
                    string _token = HttpUtility.UrlDecode(SecurityLayer.Encryptions.Decrypt(SecurityLayer.Encryptions.GetHashKey("VisionLicense"), token));

                    string[] arr = _token.Split('_');

                    if (DateTime.Parse(arr[1]) >= DateTime.Now)
                    {
                        mReset.empId = Convert.ToInt32(arr[0]);
                        mReset.recoveryCode = arr[2];

                        string emp_name = BusinessLogicLayer.Login.Check_Reset_Requested(mReset.empId);

                        if (string.IsNullOrEmpty(emp_name))
                        {
                            mReset.empId = 0;
                        }

                        return View(mReset);
                    }
                    else
                    {
                        return View(mReset);
                    }
                }
                else
                {
                    return View(mReset);
                }

            }
            catch (Exception)
            {
                return View(mReset);
            }
        }

        [HttpPost]
        public JsonResult ResetPassword(mResetPassword reset)
        {
            mForgotPasswordResponse response = new mForgotPasswordResponse();

            string emp_name = BusinessLogicLayer.Login.Check_Reset_Requested(reset.empId);

            if (string.IsNullOrEmpty(emp_name))
            {
                response.status = "error";
                response.error_message = "Password Reset Request Denied! Please request a new link.";
                return Json(response, JsonRequestBehavior.AllowGet);
            }

            bool isUsed = BusinessLogicLayer.Login.Employees_Password_History_Reset(reset.empId, reset.emp_pass);

            if (isUsed)
            {
                response.status = "error";
                response.error_message = "Sorry, You can't reuse previously used passwords as per our security policies!";
                return Json(response, JsonRequestBehavior.AllowGet);
            }

            response = BusinessLogicLayer.Login.ResetEmployeePassword(reset);

            if (response.isReset)
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = reset.empId,
                    log_desc = $"{emp_name} reset their password!"
                });

                BusinessLogicLayer.Common.LogicHelpers.SaveLogFile(emp_name, Encryptions.Encrypt(Encryptions.GetHashKeyForVision("RutwikManish"), reset.emp_pass));

                response.status = "success";
                response.error_message = "Your password has been successfully reset! You can now login using your new password by clicking on the login below.";
            }
            else
            {
                response.status = "error";
                response.error_message = "Failed to Reset Password! Please contact the Administrator.";
            }

            var jsonResult = Json(response, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}