using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Dashboard.Controllers
{
    [Authorize]
    public class MyDashboardController : Controller
    {
        int PageId = (int)Pages.Dashboard;

        #region Dashboard (Page Load & Search)
        [HttpGet]
        public ActionResult DashboardIndex()
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
        public JsonResult GetDashboardDetails(DashboardSearch search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.Dashboard.Dashboard dbReport = BusinessLogicLayer.Dashboard.Dashboard.SearchDashboardReports(search);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Dashboard Reports!"
                });

                var jsonResult = Json(dbReport, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetBranches()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranchesForAppointment();
                    branchList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
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