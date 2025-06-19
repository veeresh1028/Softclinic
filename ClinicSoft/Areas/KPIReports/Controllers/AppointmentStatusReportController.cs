using BusinessEntities;
using BusinessEntities.Marketing.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.KPIReports.Controllers
{
    [Authorize]
    public class AppointmentStatusReportController : Controller
    {
        int PageId = (int)Pages.AppointmentStatusReport;

        public ActionResult AppointmentStatusReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAppointmentStatusReport(BusinessEntities.KPIReports.AppointmentStatusSearch _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.KPIReports.AppointmentStatusReport> statusReports = BusinessLogicLayer.KPIReports.AppointmentStatusReport.SearchAppointmentStatusReport(_filters);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Appointment Status Report"
                });

                var jsonResult = Json(statusReports, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetAppointmentList(BusinessEntities.KPIReports.AppointmentListSearch app)
        {
            TempData["app_data"] = app;
            TempData.Keep("app_data");

            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
            {
                log_by = PageControl.getLoggedinId(),
                log_desc = "Employee Viewed Appointment Status Report List"
            });

            return Json(app, JsonRequestBehavior.AllowGet);
        }

        #region Miscellaneous Functions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            bool isPartial = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            TempData["error"] = filterContext;

            string actionName = isPartial ? "ErrorPartialView" : "Error";

            filterContext.Result = RedirectToAction(actionName, "Error", new { area = "Common" });
        }
        #endregion
    }
}