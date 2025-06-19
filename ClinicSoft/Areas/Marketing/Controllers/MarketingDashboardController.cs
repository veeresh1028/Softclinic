using BusinessEntities.Marketing.Reports;
using BusinessEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Marketing.Controllers
{
    [Authorize]
    public class MarketingDashboardController : Controller
    {
        int PageId_Daily = (int)Pages.MarketingDashboard;

        #region Marketing Dashboard Reports
        [HttpGet]
        public ActionResult MarketingDashboard()
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
        public JsonResult GetDashboardReports(BusinessEntities.Marketing.Reports.MarketingDashboard _filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_Daily, Action))
            {
                DashboardReport dashboardReports = BusinessLogicLayer.Marketing.Reports.MarketingDashboard.GetDashboardReports(_filters);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Marketing Dashboard Page!"
                });

                return Json(dashboardReports, JsonRequestBehavior.AllowGet);
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