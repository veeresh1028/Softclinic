using BusinessEntities;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class GastroIntestinalController : Controller
    {
        #region GastoIntestial (Page Load)
        int PageId = (int)Pages.GastroIntestinal;
        // GET: EMR/GastroIntestinal
        public PartialViewResult GastroIntestinal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed GastroIntestinal Page!"
                    });
                    List<GastroIntestinal> genexam = BusinessLogicLayer.EMR.GastroIntestinal.GetAllGastroIntestinal(appId, 0);
                    return PartialView("GastroIntestinal", genexam.FirstOrDefault());
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

        public JsonResult GetAllGastroIntestinal(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<GastroIntestinal> genexam = BusinessLogicLayer.EMR.GastroIntestinal.GetAllGastroIntestinal(appId, 0);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/GastroIntestinal

        public JsonResult GetAllPreGastroIntestinal(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<GastroIntestinal> genexam = BusinessLogicLayer.EMR.GastroIntestinal.GetAllPreGastroIntestinal(appId, patId);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion GastoIntestial (Page Load)

        #region GastoIntestial CRUD Operations
        // GET: Copy/Previous
        public JsonResult CopyGastroIntestinal(int giId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Copied GastoIntestial (Id) : {giId}"
                });
                List<GastroIntestinal> genexam = BusinessLogicLayer.EMR.GastroIntestinal.GetAllGastroIntestinal(0, giId);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: GastroIntestinal
        [HttpGet]
        public PartialViewResult ViewGastroIntestinal(int giId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed GastroIntestinal (Id) : {giId}"
                    });
                    List<GastroIntestinal> genexam = BusinessLogicLayer.EMR.GastroIntestinal.GetAllGastroIntestinal(0, giId);

                    return PartialView("ViewGastroIntestinal", genexam.FirstOrDefault());
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
        // INSERT: GastroIntestinal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertGastroIntestinal(GastroIntestinal data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.gi_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.GastroIntestinal.isValidGastroIntestinal(data, out errors))
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.gi_madeby,
                            log_desc = $"Employee Created New GastroIntestinal (Id) : {data.giId}"
                        });
                        isInserted = BusinessLogicLayer.EMR.GastroIntestinal.InsertUpdateGastroIntestinal(data);

                        if (isInserted)
                        {
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
        // Update: GastroIntestinal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateGastroIntestinal(GastroIntestinal data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.gi_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.GastroIntestinal.isValidGastroIntestinal(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.GastroIntestinal.InsertUpdateGastroIntestinal(data);
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.gi_madeby,
                            log_desc = $"Employee Updated GastroIntestinal with Id = {data.giId}"
                        });
                        if (isInserted)
                        {
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

        //Delete: EMR/GastroIntestinal
        [HttpPost]
        public ActionResult DeleteGastroIntestinal(int giId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int gi_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.GastroIntestinal.DeleteGastroIntestinal(giId, gi_madeby);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted GastroIntestinal with Id = {giId}"
                        });
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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