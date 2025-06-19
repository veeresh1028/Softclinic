using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Common.Controllers
{
    public class AuditLogsController : Controller
    {
        public ActionResult AuditLogs()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ExportLogs(string desc)
        {
            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
            {
                log_by = PageControl.getLoggedinId(),
                log_desc = desc
            });

            return Json(new { message = "Log Created!" }, JsonRequestBehavior.AllowGet);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}