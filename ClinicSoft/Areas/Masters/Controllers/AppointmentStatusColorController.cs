using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class AppointmentStatusColorController : Controller
    {
        int PageId = (int)Pages.AppointmentStatusColor;

        #region Appointment Status Color (Page Load)
        [HttpGet]
        public ActionResult AppointmentStatusColor()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Appointment Status Color!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetAllAppointmentStatusColor()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.AppointmentStatusColor> colors = BusinessLogicLayer.Masters.AppointmentStatusColor.GetAppointmentStatusColor(0);

                return Json(colors, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Appointment Status Color CRUD Operations
        [HttpGet]
        public PartialViewResult CreateAppointmentStatusColor()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.AppointmentStatusColor AppointmentStatusColor = new BusinessEntities.Masters.AppointmentStatusColor();

                    return PartialView("CreateAppointmentStatusColor", AppointmentStatusColor);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertAppointmentStatusColor(BusinessEntities.Masters.AppointmentStatusColor data)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.AppointmentStatusColor.isValidAppointmentStatusColor(data, out errors))
                {
                    data.aps_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.Masters.AppointmentStatusColor.InsertUpdateAppointmentStatusColor(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.aps_madeby,
                            log_desc = $"Employee Created New Appointment Status Color : {data.aps_status}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Appointment Status Color Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Appointment Status Color Already Exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public PartialViewResult EditAppointmentStatusColor(int apsId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.AppointmentStatusColor appointmentstatuscolor = BusinessLogicLayer.Masters.AppointmentStatusColor.GetAppointmentStatusColor(apsId).FirstOrDefault();

                    return PartialView("EditAppointmentStatusColor", appointmentstatuscolor);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAppointmentStatusColor(BusinessEntities.Masters.AppointmentStatusColor data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.AppointmentStatusColor.isValidAppointmentStatusColor(data, out errors))
                {
                    data.aps_madeby = PageControl.getLoggedinId();

                    isUpdated = BusinessLogicLayer.Masters.AppointmentStatusColor.InsertUpdateAppointmentStatusColor(data);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.aps_madeby,
                            log_desc = $"Employee Updated Appointment Status Color to with apsId = {data.apsId}"
                        });

                        return Json(new { isUpdated = true, isSuccess = true, message = "Appointment Status Color Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Appointment Status Color Already Exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateAppointmentStatusColorStatus(int apsId, string aps_activity_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.AppointmentStatusColor.UpdateAppointmentStatusColorStatus(apsId, aps_activity_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Appointment Status Color Status to : {aps_activity_status} with apsId = {apsId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Appointment Status Color Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Appointment Status Color with the same name already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Appointment Status Color Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DeleteAppointmentStatusColorStatus(int apsId, string aps_activity_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.AppointmentStatusColor.UpdateAppointmentStatusColorStatus(apsId, aps_activity_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Appointment Status Color with apsId = {apsId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Appointment Status Color Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Appointment Status Color!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}