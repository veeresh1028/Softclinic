using BusinessEntities;
using BusinessEntities.Marketing.Reports;
using BusinessEntities.Reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Reports.Controllers
{
    [Authorize]
    public class ReferralReportController : Controller
    {
        int PageId_Yearly = (int)Pages.YearlyReferralReport;
        int PageId_Monthly = (int)Pages.MonthlyReferralReport;

        #region Yearly Referral Report
        [HttpGet]
        public ActionResult YearlyReferralReport()
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
        public JsonResult GetYearlyReferralReport(BusinessEntities.Reports.ReferralReportSearch _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Yearly, Action))
            {
                BusinessEntities.Reports.ReferralReport yearlyReport = BusinessLogicLayer.Reports.ReferralReport.GetYearlyReferralReport(_filters);

                var data = JsonConvert.SerializeObject(yearlyReport, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Yearly Referral Report Page"
                });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Yearly Referral History
        [HttpGet]
        public PartialViewResult GetYearlyReferralHistory(string pat_year, string pat_source_name, int pat_month)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Yearly, Action))
                {
                    List<YearlyReportHistory> yearlySourceHistory = BusinessLogicLayer.Reports.ReferralReport.GetYearlyReferralHistory(pat_year, pat_source_name, pat_month);

                    return PartialView("GetYearlyReferralHistory", yearlySourceHistory);
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

        #region Monthly Referral Report
        [HttpGet]
        public ActionResult MonthlyReferralReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Monthly, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetMonthlyReferralReport(BusinessEntities.Reports.MonthlyReferralReportSearch _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Monthly, Action))
            {
                BusinessEntities.Reports.ReferralReport monthlyReport = BusinessLogicLayer.Reports.ReferralReport.GetMonthlyReferralReport(_filters);

                var data = JsonConvert.SerializeObject(monthlyReport, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Monthly Referral Report Page"
                });

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Monthly Referral Report History
        [HttpGet]
        public PartialViewResult GetMonthlyReferralHistory(string pat_date, string pat_source_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Monthly, Action))
                {
                    List<MonthlyReferralReportHistory> dailySourceHistory = BusinessLogicLayer.Reports.ReferralReport.GetMonthlyReferralHistory(pat_date, pat_source_name);

                    return PartialView("GetMonthlyReferralHistory", dailySourceHistory);
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
    }
}