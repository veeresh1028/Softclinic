using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Reports.Controllers
{
    [Authorize]
    public class DailyCollectionController : Controller
    {
        int PageId = (int)Pages.DailyCollections;

        [HttpGet]
        public ActionResult DailyCollection()
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
        public JsonResult GetDailyCollectionsReport(DailyCollectionsReportSearch search)
        {
            int Action = (int)Actions.Read;

            List<BusinessEntities.Reports.DailyCollectionsReport> reports = new List<DailyCollectionsReport>();

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    reports = BusinessLogicLayer.Reports.DailyCollectionsReport.SearchDailyCollectionsReports(search);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Daily Collections Report!"
                    });

                    var jsonResult = Json(new { isAuthorized = true, message = "", data = reports }, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(new { isAuthorized = true, message = ex.Message, data = reports }, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!", data = reports }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetPatientsForDropdown(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> patientList = BusinessLogicLayer.Reports.DailyCollectionsReport.GetPatientsForDropdown(query);

                    var jsonResult = Json(patientList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
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