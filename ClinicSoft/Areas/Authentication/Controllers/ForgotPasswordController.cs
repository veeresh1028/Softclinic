using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Authentication.Controllers
{
    [AllowAnonymous]
    public class ForgotPasswordController : Controller
    {
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ForgotPassword(ForgotPassword forgot)
        {
            string errorMsg = string.Empty;

            mForgotPasswordResponse response = BusinessLogicLayer.Login.GetForgotPasswordDetails(forgot.userName);

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