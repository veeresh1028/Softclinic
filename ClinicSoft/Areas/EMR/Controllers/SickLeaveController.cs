using BusinessEntities;
using BusinessEntities.EMR;
using BusinessLogicLayer.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class SickLeaveController : Controller
    {
        int PageId = (int)Pages.SickLeave;
       
        #region  Sick Leave General (Page Load)
        // GET: EMR/SickLeave
        public ActionResult SickLeaveGeneral()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Sick Leave General Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllSickLeaveGeneral(int? appId, int? slId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SickLeaveGeneral> pasthis = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveGeneral(appId, slId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/SickLeave

        public JsonResult GetAllPreSickLeaveGeneral(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SickLeaveGeneral> pasthis = BusinessLogicLayer.EMR.SickLeave.GetAllPreSickLeaveGeneral(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion  Sick Leave General (Page Load)

        #region  Sick Leave General CRUD Operations


        // Create: SickLeave
        public PartialViewResult CreateSickLeaveGeneral()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateSickLeaveGeneral");
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
        //INSERT: SickLeave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertSickLeaveGeneral(SickLeaveGeneral data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.sl_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.SickLeave.isValidSickLeaveGeneral(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.SickLeave.InsertUpdateSickLeaveGeneral(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: SickLeave
        [HttpGet]
        public PartialViewResult EditSickLeaveGeneral(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<SickLeaveGeneral> extraoral = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveGeneral(appId, 0);

                    return PartialView("EditSickLeaveGeneral", extraoral.FirstOrDefault());
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
        public ActionResult UpdateSickLeaveGeneral(SickLeaveGeneral data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sl_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.SickLeave.isValidSickLeaveGeneral(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.SickLeave.InsertUpdateSickLeaveGeneral(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: SickLeave
        [HttpGet]
        public ActionResult PrintSickLeaveGeneral(int slId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    SickLeaveGeneral print = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveGeneral(0, slId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Sick Leave General with slId = {slId}"
                    });

                    return View("PrintSickLeaveGeneral", print);
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
        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteSickLeaveGeneral(int slId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int sl_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.SickLeave.DeleteSickLeaveGeneral(slId, sl_madeby);

                    if (val == 1)
                    {
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

        #endregion  Sick Leave General CRUD Operations

        #region  Sick Leave MOH (Page Load)
        // GET: EMR/SickLeave
        public ActionResult SickLeaveMOH()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Sick Leave MOH Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllSickLeaveMOH(int? appId, int? slId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SickLeaveMOH> pasthis = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveMOH(appId, slId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/SickLeave

        public JsonResult GetAllPreSickLeaveMOH(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SickLeaveMOH> pasthis = BusinessLogicLayer.EMR.SickLeave.GetAllPreSickLeaveMOH(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion  Sick Leave MOH (Page Load)
        #region  Sick Leave GeMOHneral CRUD Operations


        // Create: SickLeave MOH
        public PartialViewResult CreateSickLeaveMOH()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateSickLeaveMOH");
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

        //INSERT: SickLeave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertSickLeaveMOH(SickLeaveMOH data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.sl_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.SickLeave.isValidSickLeaveMOH(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.SickLeave.InsertUpdateSickLeaveMOH(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: SickLeave
        [HttpGet]
        public PartialViewResult EditSickLeaveMOH(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<SickLeaveMOH> extraoral = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveMOH(appId, 0);

                    return PartialView("EditSickLeaveMOH", extraoral.FirstOrDefault());
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
        public ActionResult UpdateSickLeaveMOH(SickLeaveMOH data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sl_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.SickLeave.isValidSickLeaveMOH(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.SickLeave.InsertUpdateSickLeaveMOH(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: SickLeave
        [HttpGet]
        public ActionResult PrintSickLeaveMOH(int slId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    SickLeaveMOH print = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveMOH(0, slId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Sick Leave MOH with slId = {slId}"
                    });

                    return View("PrintSickLeaveMOH", print);
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
        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteSickLeaveMOH(int slId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int sl_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.SickLeave.DeleteSickLeaveMOH(slId, sl_madeby);

                    if (val == 1)
                    {
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

        #endregion  Sick Leave MOH CRUD Operations

        #region  Sick Leave DHA (Page Load)
        // GET: EMR/SickLeave
        public ActionResult SickLeaveDHA()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Sick Leave DHA Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllSickLeaveDHA(int? appId, int? slmId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SickLeaveDHA> pasthis = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveDHA(appId, slmId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/SickLeave

        public JsonResult GetAllPreSickLeaveDHA(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SickLeaveDHA> pasthis = BusinessLogicLayer.EMR.SickLeave.GetAllPreSickLeaveDHA(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion  Sick Leave DHA (Page Load)

        #region  Sick Leave DHA CRUD Operations


        // Create: SickLeave
        public PartialViewResult CreateSickLeaveDHA()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateSickLeaveDHA");
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
        //INSERT: SickLeave
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertSickLeaveDHA(SickLeaveDHA data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.slm_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.SickLeave.isValidSickLeaveDHA(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.SickLeave.InsertUpdateSickLeaveDHA(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: SickLeave
        [HttpGet]
        public PartialViewResult EditSickLeaveDHA(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<SickLeaveDHA> extraoral = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveDHA(appId, 0);

                    return PartialView("EditSickLeaveDHA", extraoral.FirstOrDefault());
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
        public ActionResult UpdateSickLeaveDHA(SickLeaveDHA data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.slm_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.SickLeave.isValidSickLeaveDHA(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.SickLeave.InsertUpdateSickLeaveDHA(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: SickLeave
        [HttpGet]
        public ActionResult PrintSickLeaveDHA(int slmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    SickLeaveDHA print = BusinessLogicLayer.EMR.SickLeave.GetAllSickLeaveDHA(0, slmId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Sick Leave DHA with slmId = {slmId}"
                    });

                    return View("PrintSickLeaveDHA", print);
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
        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteSickLeaveDHA(int slmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int slm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.SickLeave.DeleteSickLeaveDHA(slmId, slm_madeby);

                    if (val == 1)
                    {
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

        #endregion  Sick Leave DHA CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}