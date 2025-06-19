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
    [Authorize]
    public class RadiologyRequestController : Controller
    {
        #region RadiologyRequest (Page Load)
        int PageId = (int)Pages.Forms;
        // GET: EMR/RadiologyRequest
        public PartialViewResult RadiologyRequest()
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
                        log_desc = "Employee Viewed RadiologyRequest Page!"
                    });
                    RadiologyRequest radiology = BusinessLogicLayer.EMR.RadiologyRequest.GetAllRadiologyRequest(appId, 0).FirstOrDefault();
                    //radiology.doc_sign = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg");
                    //radiology.doc_stamp = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/signature_bg.jpg");
                    return PartialView("RadiologyRequest", radiology);
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

        public JsonResult GetAllRadiologyRequest(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RadiologyRequest> genexam = BusinessLogicLayer.EMR.RadiologyRequest.GetAllRadiologyRequest(appId, 0);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/RadiologyRequest

        public JsonResult GetAllPreRadiologyRequest(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RadiologyRequest> genexam = BusinessLogicLayer.EMR.RadiologyRequest.GetAllPreRadiologyRequest(appId, patId);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult PrintRadiologyRequest(int rdrf_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    RadiologyRequest print = BusinessLogicLayer.EMR.RadiologyRequest.GetPrintRadiologyRequest( rdrf_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Medical Decision with rdrf_Id = {rdrf_Id}"
                    });

                    return View("PrintRadiologyRequest", print);
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

        #endregion RadiologyRequest (Page Load)

        #region RadiologyRequest CRUD Operations

        // INSERT: RadiologyRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertRadiologyRequest(RadiologyRequest data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.rdrf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMR.MainNotes.isValidRadiologyRequest(data, out errors))
                    //{
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.rdrf_madeby,
                            log_desc = $"Employee Created New RadiologyRequest (Id) : {data.rdrf_Id}"
                        });
                        isInserted = BusinessLogicLayer.EMR.RadiologyRequest.InsertUpdateRadiologyRequest(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "HPI already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    ////}
                    ////else
                    ////{
                    ////    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    ////}
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
        // Update: RadiologyRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRadiologyRequest(RadiologyRequest data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.rdrf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMR.MainForms.isValidRadiologyRequest(data, out errors))
                    //{
                        isInserted = BusinessLogicLayer.EMR.RadiologyRequest.InsertUpdateRadiologyRequest(data);
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.rdrf_madeby,
                            log_desc = $"Employee Updated RadiologyRequest with Id = {data.rdrf_Id}"
                        });
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "HPI already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        //Delete: EMR/RadiologyRequest
        [HttpPost]
        public ActionResult DeleteRadiologyRequest(int rdrf_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int rdrf_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.RadiologyRequest.DeleteRadiologyRequest(rdrf_Id, rdrf_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted RadiologyRequest with Id = {rdrf_Id}"
                        });
                        return Json(new { success = true, isAuthorized = true, message = "RadiologyRequest Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
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

        #endregion RadiologyRequest CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}