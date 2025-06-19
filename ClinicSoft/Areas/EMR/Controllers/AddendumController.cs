using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class AddendumController : Controller
    {
        #region Addendum (Page Load)
        // GET: EMR/Addendum

        int PageId = (int)Pages.Addendum;
        public PartialViewResult Addendum()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Addendum Page!"
                    });
                    return PartialView("Addendum");
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

        public JsonResult GetAllAddendum(int appId, int? addeId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Addendum> Addendum = BusinessLogicLayer.EMR.Addendum.GetAllAddendum(appId, addeId);

                return Json(Addendum, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/Addendum

        public JsonResult GetAllPreAddendum(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Addendum> notes = BusinessLogicLayer.EMR.Addendum.GetAllPreAddendum(appId, patId);

                return Json(notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //GET:Complaints Master

        public ActionResult GetEMRTabMaster(string query)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> emr_tabs = BusinessLogicLayer.EMR.Addendum.GetEMRTabMaster(query);
                    var jsonResult = Json(emr_tabs, JsonRequestBehavior.AllowGet);
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

        #endregion Addendum (Page Load)

        #region Addendum  CRUD Operations
        // Create: Addendum
        public PartialViewResult CreateAddendum()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    Addendum notes = new Addendum();
                    return PartialView("CreateAddendum", notes);
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
        public ActionResult InsertAddendum(Addendum data)
        {
            try
            {
                bool isInserted = false;
                data.adde_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidAddendum(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.Addendum.InsertUpdateAddendum(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.adde_madeby,
                                log_desc = $"Employee Created New Addendum (Id) : {data.addeId}"
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();

        }

        //EDIT :Cheif Addendum
        public PartialViewResult EditAddendum(int appId, int addeId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<Addendum> Addendum = BusinessLogicLayer.EMR.Addendum.GetAllAddendum(appId, addeId);
                    return PartialView("EditAddendum", Addendum.FirstOrDefault());
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
        public ActionResult UpdateAddendum(Addendum data)
        {
            try
            {
                bool isUpdated = false;
                data.adde_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidAddendum(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.EMR.Addendum.InsertUpdateAddendum(data);
                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.adde_madeby,
                                log_desc = $"Employee Created New Addendum (Id) : {data.addeId}"
                            });
                            return Json(new { isUpdated = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();

        }
        //DELETE :Addendum

        [HttpPost]
        public ActionResult DeleteAddendum(int addeId)
        {
            try
            {
                int adde_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.Addendum.DeleteAddendum(addeId, adde_madeby);
                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = adde_madeby,
                            log_desc = $"Employee Deleted Addendum for (Id) : {addeId}"
                        });
                        return Json(new { success = true, isAuthorized = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
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
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}