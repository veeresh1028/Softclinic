using BusinessEntities;
using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class MessageTypeController : Controller
    {
        int PageId = (int)Pages.MessageTypes;

        #region Message Types (Page Load)
        [HttpGet]
        public ActionResult MessageType()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Message Types!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetAllMessageTypes()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.MessageType> messages = BusinessLogicLayer.Masters.MessageType.GetMessageType(0);

                return Json(messages, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Load Dropdowns
        [HttpGet]
        public ActionResult GetDesignations(int? desiId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_designation = BusinessLogicLayer.Masters.Designations.GetAllDesignations(desiId);
                    SelectList DesignationList = Models.Helper.ToSelectList(dt_designation, "desiId", "designation");

                    var jsonResult = Json(DesignationList, JsonRequestBehavior.AllowGet);
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
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetEmployees(int? empId, int? emp_desig)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_Employee = BusinessLogicLayer.Masters.MessageType.GetAllEmployees(empId, emp_desig);
                    SelectList EmployeeList = Models.Helper.ToSelectList(dt_Employee, "empId", "emp_name");
                    var jsonResult = Json(EmployeeList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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

        #region Message Types CRUD Operations
        [HttpGet]
        public PartialViewResult CreateMessageType()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.MessageType messageType = new BusinessEntities.Masters.MessageType();

                    messageType.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("CreateMessageType", messageType);
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
        public ActionResult InsertMessageType(BusinessEntities.Masters.MessageType data)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.MessageType.isValidMessagetype(data, out errors))
                {
                    data.mt_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.Masters.MessageType.InsertUpdateMessageType(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.mt_madeby,
                            log_desc = $"Employee Created New Message Type : {data.mt_type}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Message Type Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Message Type Already Exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditMessageType(int mtId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {

                    BusinessEntities.Masters.MessageType messageType = BusinessLogicLayer.Masters.MessageType.GetMessageType(mtId).FirstOrDefault();

                    messageType.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("EditMessagetype", messageType);
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
        public ActionResult UpdateMessageType(BusinessEntities.Masters.MessageType data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.MessageType.isValidMessagetype(data, out errors))
                {
                    data.mt_madeby = PageControl.getLoggedinId();

                    isUpdated = BusinessLogicLayer.Masters.MessageType.InsertUpdateMessageType(data);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.mt_madeby,
                            log_desc = $"Employee Updated Message Type with mtId = {data.mtId}"
                        });

                        return Json(new { isUpdated = true, isSuccess = true, message = "Message Type Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Message Type Already Exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateMessageTypeStatus(int mtId, string mt_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.MessageType.UpdateMessageTypeStatus(mtId, mt_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Message Type Status to : {mt_status} with mtId = {mtId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Message Type Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Message Type with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Message Type Status!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteMessageType(int mtId, string mt_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.MessageType.UpdateMessageTypeStatus(mtId, mt_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Message Type with mtId = {mtId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Message Type Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Message Type!" }, JsonRequestBehavior.AllowGet);
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