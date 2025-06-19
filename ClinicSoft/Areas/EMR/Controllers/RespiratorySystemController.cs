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
    public class RespiratorySystemController : Controller
    {
        // GET: EMR/RespiratorySystem
        #region RespSystem
        int PageId = (int)Pages.RespiratorySystem;
        // GET: EMR/RespiratorySystem
        public PartialViewResult RespiratorySystem()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    List<RespiratorySystem> respiratory = BusinessLogicLayer.EMR.RespiratorySystem.GetAllRespiratorySystem(appId, 0);
                    return PartialView("RespiratorySystem", respiratory.FirstOrDefault());
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

        public JsonResult GetAllRespiratorySystem(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RespiratorySystem> respiratory = BusinessLogicLayer.EMR.RespiratorySystem.GetAllRespiratorySystem(appId, 0);

                return Json(respiratory, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/RespiratorySystem

        public JsonResult GetAllPreRespiratorySystem(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RespiratorySystem> respiratory = BusinessLogicLayer.EMR.RespiratorySystem.GetAllPreRespiratorySystem(appId, patId);

                return Json(respiratory, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Copy/Previous
        public JsonResult CopyRespiratorySystem(int resId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RespiratorySystem> respiratory = BusinessLogicLayer.EMR.RespiratorySystem.GetAllRespiratorySystem(0, resId);

                return Json(respiratory, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: RespiratorySystem
        [HttpGet]
        public PartialViewResult ViewRespiratorySystem(int resId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<RespiratorySystem> respiratory = BusinessLogicLayer.EMR.RespiratorySystem.GetAllRespiratorySystem(0, resId);

                    return PartialView("ViewRespiratorySystem", respiratory.FirstOrDefault());
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

        // INSERT: RespiratorySystem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertRespiratorySystem(RespiratorySystem data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.res_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.RespiratorySystem.isValidRespiratorySystem(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.RespiratorySystem.InsertUpdateRespiratorySystem(data);

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
        // Update: RespiratorySystem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateRespiratorySystem(RespiratorySystem data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.res_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.RespiratorySystem.isValidRespiratorySystem(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.RespiratorySystem.InsertUpdateRespiratorySystem(data);

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

        //Delete: EMR/RespiratorySystem
        [HttpPost]
        public ActionResult DeleteRespiratorySystem(int resId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int res_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.RespiratorySystem.DeleteRespiratorySystem(resId, res_madeby);

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

        #endregion RespSystem
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}