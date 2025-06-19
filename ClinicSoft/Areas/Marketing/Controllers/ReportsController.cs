using BusinessEntities;
using BusinessEntities.Marketing;
using BusinessEntities.Marketing.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Marketing.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        int PageId_Daily = (int)Pages.DailyReportsHandledBy;
        int PageId_Yearly = (int)Pages.YearlyReportsHandledBy;
        int PageId_Daily_Source = (int)Pages.DailyReportsBySource;
        int PageId_Yearly_Source = (int)Pages.YearlyReportsBySource;
        int PageId_Status = (int)Pages.EnquiryReportsByStatus;
        int PageId_Patient = (int)Pages.PatientSummaryReport;
        int PageId_Graphical = (int)Pages.GraphicalReportSummary;

        #region Daily Enquiry Report (Managed By)
        [HttpGet]
        public ActionResult DailyReportsManagedBy()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Daily, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetDailyReports(BusinessEntities.Marketing.Reports.DailyReport _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Daily, Action))
            {
                DailyReportManagedBy dailyReports = BusinessLogicLayer.Marketing.Reports.DailyReport.DailyReportManagedby(_filters);

                var data = JsonConvert.SerializeObject(dailyReports, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Daily Enquiry Reports Page"
                });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Daily Enquiries History (Managed By)
        [HttpGet]
        public PartialViewResult GetDailyHistory(string app_fdate, string app_madeby_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Daily, Action))
                {
                    List<DailyHistory> dailyHistory = BusinessLogicLayer.Marketing.Reports.DailyReport.GetDailyHistory(app_fdate, app_madeby_name);

                    return PartialView("GetDailyHistory", dailyHistory);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        #endregion

        #region Yearly Enquiry Report (Managed By)
        [HttpGet]
        public ActionResult YearlyReportsManagedBy()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Yearly, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetYearlyReports(BusinessEntities.Marketing.Reports.YearlyReport _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Yearly, Action))
            {
                YearlyReportManagedBy yearlyReport = BusinessLogicLayer.Marketing.Reports.YearlyReport.YearlyReportManagedby(_filters);

                var data = JsonConvert.SerializeObject(yearlyReport, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Yearly Report (Managed By)"
                });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Yearly Enquiries History (Managed By)
        [HttpGet]
        public PartialViewResult GetYearlyHistory(string app_year, string app_madeby_name, int app_month)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Daily, Action))
                {
                    List<YearlyHistory> yearlyHistory = BusinessLogicLayer.Marketing.Reports.YearlyReport.GetYearlyHistory(app_year, app_madeby_name, app_month);

                    return PartialView("GetYearlyHistory", yearlyHistory);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        #endregion

        #region Daily Enquiry Report (By Source)
        [HttpGet]
        public ActionResult DailyReportsBySoure()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Daily_Source, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetDailyReportsBySource(BusinessEntities.Marketing.Reports.DailyReportSource _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Daily, Action))
            {
                DailyReportBySource dailyReports = BusinessLogicLayer.Marketing.Reports.DailyReport.DailyReportBySource(_filters);

                var data = JsonConvert.SerializeObject(dailyReports, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Daily Report (BySource)"
                });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Daily Enquiries History (By Source)
        [HttpGet]
        public PartialViewResult GetDailySourceHistory(string app_fdate, string app_source_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Daily_Source, Action))
                {
                    List<DailySourceHistory> dailySourceHistory = BusinessLogicLayer.Marketing.Reports.DailyReport.GetDailySourceHistory(app_fdate, app_source_name);

                    return PartialView("GetDailySourceHistory", dailySourceHistory);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        #endregion

        #region Yearly Enquiry Report (By Source)
        [HttpGet]
        public ActionResult YearlyReportsBySoure()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Yearly_Source, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetYearlyReportBySource(BusinessEntities.Marketing.Reports.YearlySourceReport _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Yearly_Source, Action))
            {
                YearlySourceReportData yearlyReport = BusinessLogicLayer.Marketing.Reports.YearlyReport.GetYearlyReportBySource(_filters);

                var data = JsonConvert.SerializeObject(yearlyReport, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Yearly Source Report Data"
                });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Yearly Enquiries History (By Source)
        [HttpGet]
        public PartialViewResult GetYearlySourceHistory(string app_year, string app_source_name, int app_month)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Daily, Action))
                {
                    List<YearlySourceHistory> yearlySourceHistory = BusinessLogicLayer.Marketing.Reports.YearlyReport.GetYearlySourceHistory(app_year, app_source_name, app_month);

                    return PartialView("GetYearlySourceHistory", yearlySourceHistory);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        #endregion

        #region Enquiry Details Report (By Status)
        [HttpGet]
        public ActionResult EnquiryReportStatus()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Status, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetEnquiryStatusReports(BusinessEntities.Marketing.Reports.StatusReport _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Status, Action))
            {
                StatusReportDetails statusReports = BusinessLogicLayer.Marketing.Reports.StatusReport.DailyReportByStatus(_filters);

                var data = JsonConvert.SerializeObject(statusReports, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Status Report Details"
                });

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Enquiry Details History (By Status)
        [HttpGet]
        public PartialViewResult GetStatusHistory(string app_fdate, string as_status)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Status, Action))
                {
                    List<StatusHistory> statusHistory = BusinessLogicLayer.Marketing.Reports.StatusReport.GetEnquiryStatusHistory(app_fdate, as_status);

                    return PartialView("GetStatusHistory", statusHistory);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        #endregion

        #region Patient Analysis Summary Report
        [HttpGet]
        public ActionResult PatientAnalysisSummary()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Patient, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetPatientAnalysisSummaryReport(BusinessEntities.Marketing.Reports.PatientAnalysis _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Patient, Action))
            {
                PatientAnalysisDetails patAnalysis = BusinessLogicLayer.Marketing.Reports.PatientAnalysis.GetPatientAnalysisSummaryReport(_filters);

                var data = JsonConvert.SerializeObject(patAnalysis, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Patient Analysis Details"
                });

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Patient Analysis Summary Report Detailed History
        [HttpGet]
        public PartialViewResult GetPatientHistory(string app_fdate, string app_status)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Patient, Action))
                {
                    List<PatientAnalysisHistory> patSummaryHistory = BusinessLogicLayer.Marketing.Reports.PatientAnalysis.GetPatientHistory(app_fdate, app_status);

                    return PartialView("GetPatientHistory", patSummaryHistory);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
        #endregion

        #region Graphical Report (Managed By / By Source / By Status)
        [HttpGet]
        public ActionResult GraphicalReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Graphical, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        [HttpGet]
        public JsonResult GetGraphicalReports(BusinessEntities.Marketing.Reports.GraphicalReport _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Graphical, Action))
            {
                GraphicalChartsData graphReports = BusinessLogicLayer.Marketing.Reports.GraphicalReport.GetGraphicalReport(_filters);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Graphical Charts Data"
                });

                return Json(graphReports, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

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