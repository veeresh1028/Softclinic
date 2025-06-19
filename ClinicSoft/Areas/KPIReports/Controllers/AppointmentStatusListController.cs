using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.KPIReports.Controllers
{
    [Authorize]
    public class AppointmentStatusListController : Controller
    {
        int PageId = (int)Pages.AppointmentStatusReport;

        [HttpGet]
        public ActionResult AppointmentStatusList()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAppointmentList(BusinessEntities.Appointment.AppointmentSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.Appointment.AppointmentCount app_count = new BusinessEntities.Appointment.AppointmentCount();
                BusinessEntities.Appointment.AppointmentStatusColor aps_color = new BusinessEntities.Appointment.AppointmentStatusColor();
                BusinessEntities.Appointment.AppointmentListData listData = new BusinessEntities.Appointment.AppointmentListData();

                listData.AppointmentList = BusinessLogicLayer.KPIReports.AppointmentStatusReport.SearchAppointments(data, out app_count, out aps_color);
                listData.AppointmentCount = app_count;
                listData.AppointmentStatusColor = aps_color;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Appointments Page!"
                });

                var jsonResult = Json(listData, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
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