using BusinessEntities.Reports;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace ClinicSoft.Areas.Reports.Controllers
{
    [Authorize]
    public class InsuranceOutstandingSummaryController : Controller
    {
        int PageId = (int)Pages.InsuranceOutstandingSummary;

        [HttpGet]
        public ActionResult InsuranceOutstandingSummary()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = BusinessLogicLayer.Reports.InsuranceOutstandingSummary.SearchInsuranceOutstandingSummary();

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Insurance Outstanding Summary Report!"
                });

                return View(dt);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult PrintReport()
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Printed Insurance Outstanding Summary Report!"
                });

                return Json(new { isAuthorized = true, message = "Access Granted!" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}