using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.FrontDesk.Controllers
{
    [Authorize]
    public class RegistrationMainController : Controller
    {
        public ActionResult RegistrationMain(int appId)
        {
            TempData["appId"] = appId;

            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}