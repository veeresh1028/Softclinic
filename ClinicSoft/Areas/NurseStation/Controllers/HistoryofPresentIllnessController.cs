using BusinessEntities;
using BusinessEntities.NurseStation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class HistoryofPresentIllnessController : Controller
    {
        #region HPI (Page Load)
        int PageId = (int)Pages.HPI;

        // GET: NurseStation/HistoryofPresentIllness
        public PartialViewResult HistoryofPresentIllness()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed History of Present Illness Page!"
                    });

                    return PartialView("HistoryofPresentIllness");
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
        public JsonResult GetAllHPI(int ? appId, int? hpiId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<HistoryofPresentIllness> sclist = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.GetAllHPI(appId, hpiId);

                return Json(sclist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/HistoryofPresentIllness
        public JsonResult GetAllPreviousHPI(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<HistoryofPresentIllness> sclist = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.GetAllPreviousHPI(appId, patId);

                return Json(sclist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion HPI (Page Load)
        #region HPI  CRUD Operations
        // Create: HistoryofPresentIllness
        public PartialViewResult CreateHistoryofPresentIllness( int ? hpiId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    HistoryofPresentIllness hpi = new HistoryofPresentIllness();
                    if (hpiId == 0)
                    {
                         hpi = new HistoryofPresentIllness();
                    }
                    else
                    {
                        hpi = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.GetAllHPI(0, hpiId).FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous Patient HPI with Id = {hpiId}"
                        });
                    }
                    
                    return PartialView("CreateHistoryofPresentIllness", hpi);
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
        public ActionResult InsertHistoryofPresentIllness(BusinessEntities.NurseStation.HistoryofPresentIllness data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    
                    data.hpi_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.HistoryofPresentIllness.isValidHPI(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.InsertUpdateHPI(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.hpi_madeby,
                                log_desc = $"Employee Created New HistoryofPresentIllness with (Id) : {data.hpiId}"
                            });
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 3,
                                AJ_AJSCId = 6,
                                AJ_AppId = data.appId
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "HPI already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: HistoryofPresentIllness
        [HttpGet]
        public PartialViewResult EditHistoryofPresentIllness(int appId, int hpiId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<HistoryofPresentIllness> hpi = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.GetAllHPI(appId, hpiId);

                    return PartialView("EditHistoryofPresentIllness", hpi.FirstOrDefault());
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
        public ActionResult UpdateHPI(BusinessEntities.NurseStation.HistoryofPresentIllness data)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;
                
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.hpi_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.HistoryofPresentIllness.isValidHPI(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.InsertUpdateHPI(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.hpi_madeby,
                                log_desc = $"Employee Created New History of Present Illness with (Id) : {data.hpiId}"
                            });
                            return Json(new { isUpdated = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: HistoryofPresentIllness
        [HttpPost]
        public ActionResult DeleteHPI(int hpiId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.NurseStation.HistoryofPresentIllness.DeleteHPI(hpiId, PageControl.getLoggedinId());

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted History of Present Illness with Id = {hpiId}"
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
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}