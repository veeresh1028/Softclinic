using BusinessEntities;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    public class DermatologyController : Controller
    {
        int PageId = (int)Pages.Dermatology;

        #region  Dermatology Notes (Page Load)
        // GET: EMR/DermaNotes
        public ActionResult DermaNotes()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Dermatology Notes Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllDermaNotes(int? appId, int? dnId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DermatologyNotes> pasthis = BusinessLogicLayer.EMR.Dermatology.GetAllDermaNotes(appId, dnId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/DermaNotes

        public JsonResult GetAllPreDermaNotes(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DermatologyNotes> pasthis = BusinessLogicLayer.EMR.Dermatology.GetAllPreDermaNotes(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion  Dermatology Notes (Page Load)

        #region  Dermatology Notes CRUD Operations


        // Create: DermaNotes
        public PartialViewResult CreateDermaNotes()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateDermaNotes");
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
        //INSERT: DermaNotes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDermaNotes(DermatologyNotes data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.dn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidDermaNotes(data, out errors))
                    {



                        isInserted = BusinessLogicLayer.EMR.Dermatology.InsertUpdateDermaNotes(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Dermatology Notese already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: DermaNotes
        [HttpGet]
        public PartialViewResult EditDermaNotes(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<DermatologyNotes> extraoral = BusinessLogicLayer.EMR.Dermatology.GetAllDermaNotes(appId, 0);

                    return PartialView("EditDermaNotes", extraoral.FirstOrDefault());
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
        public ActionResult UpdateDermaNotes(DermatologyNotes data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.dn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidDermaNotes(data, out errors))
                    {



                        isInserted = BusinessLogicLayer.EMR.Dermatology.InsertUpdateDermaNotes(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Dermatology Notes already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: DermaNotes
        [HttpGet]
        public ActionResult PrintDermaNotes(int dnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    DermatologyNotes print = BusinessLogicLayer.EMR.Dermatology.GetAllDermaNotes(0, dnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Dermatology Notes with dnId = {dnId}"
                    });

                    return View("PrintDermaNotes", print);
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
        // Delete: DermaNotes
        [HttpPost]
        public ActionResult DeleteDermaNotes(int dnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int dn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.Dermatology.DeleteDermaNotes(dnId, dn_madeby);

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

        #endregion  Dermatology Notes CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}