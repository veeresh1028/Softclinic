using BusinessEntities;
using BusinessEntities.NurseStation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    public class InjectionAdministrationController : Controller
    {
        int PageId = (int)Pages.VitalSign;
        #region  Justification Letter (Page Load)
        // GET: EMR/InjectionAdministration
        public ActionResult Injection()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Justification Letter Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllInjectionAdministration(int? appId, int? mrfId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<InjectionAdministration> pasthis = BusinessLogicLayer.NurseStation.InjectionAdministration.GetAllInjectionAdministration(appId, mrfId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/InjectionAdministration

        public JsonResult GetAllPreInjectionAdministration(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<InjectionAdministration> pasthis = BusinessLogicLayer.NurseStation.InjectionAdministration.GetAllPreInjectionAdministration(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion  Justification Letter (Page Load)

        #region  Justification Letter CRUD Operations


        // Create: InjectionAdministration
        public PartialViewResult CreateInjectionAdministration()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateInjectionAdministration");
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
        //INSERT: InjectionAdministration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertInjectionAdministration(InjectionAdministration data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.mrf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidInjectionAdministration(data, out errors))
                    {



                        isInserted = BusinessLogicLayer.NurseStation.InjectionAdministration.InsertUpdateInjectionAdministration(data);

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

        // Edit: InjectionAdministration
        [HttpGet]
        public PartialViewResult EditInjectionAdministration(int mrfId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<InjectionAdministration> extraoral = BusinessLogicLayer.NurseStation.InjectionAdministration.GetAllInjectionAdministration(0, mrfId);

                    return PartialView("EditInjectionAdministration", extraoral.FirstOrDefault());
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
        public ActionResult UpdateInjectionAdministration(InjectionAdministration data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.mrf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidInjectionAdministration(data, out errors))
                    {



                        isInserted = BusinessLogicLayer.NurseStation.InjectionAdministration.InsertUpdateInjectionAdministration(data);

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
        // Print: InjectionAdministration
        [HttpGet]
        public ActionResult PrintInjectionAdministration(int mrfId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    InjectionAdministration print = BusinessLogicLayer.NurseStation.InjectionAdministration.GetAllInjectionAdministration(0, mrfId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Justification Letter with mrfId = {mrfId}"
                    });

                    return View("PrintInjectionAdministration", print);
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
        // Delete: InjectionAdministration
        [HttpPost]
        public ActionResult DeleteInjectionAdministration(int mrfId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int mrf_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.NurseStation.InjectionAdministration.DeleteInjectionAdministration(mrfId, mrf_madeby);

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

        #endregion  
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}