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
    public class CentralNervousController : Controller
    {

        #region CentralNervous
        int PacnId = (int)Pages.CentralNervous;
        // GET: EMR/CentralNervous

        public PartialViewResult CentralNervous()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PacnId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    List<CentralNervous> nervous = BusinessLogicLayer.EMR.CentralNervous.GetAllCentralNervous(appId, 0);
                    return PartialView("CentralNervous", nervous.FirstOrDefault());
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

        public JsonResult GetAllCentralNervous(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PacnId, Action))
            {
                List<CentralNervous> nervous = BusinessLogicLayer.EMR.CentralNervous.GetAllCentralNervous(appId, 0);

                return Json(nervous, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/CentralNervous

        public JsonResult GetAllPreCentralNervous(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PacnId, Action))
            {
                List<CentralNervous> nervous = BusinessLogicLayer.EMR.CentralNervous.GetAllPreCentralNervous(appId, patId);

                return Json(nervous, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Copy/Previous
        public JsonResult CopyCentralNervous(int cnId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PacnId, Action))
            {
                List<CentralNervous> nervous = BusinessLogicLayer.EMR.CentralNervous.GetAllCentralNervous(0, cnId);

                return Json(nervous, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: CentralNervous
        [HttpGet]
        public PartialViewResult ViewCentralNervous(int cnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PacnId, Action))
                {
                    List<CentralNervous> nervous = BusinessLogicLayer.EMR.CentralNervous.GetAllCentralNervous(0, cnId);

                    return PartialView("ViewCentralNervous", nervous.FirstOrDefault());
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
        // INSERT: CentralNervous
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertCentralNervous(CentralNervous data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PacnId, Action))
                {


                    data.cn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.CentralNervous.isValidCentralNervous(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.CentralNervous.InsertUpdateCentralNervous(data);

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
        // Update: CentralNervous
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCentralNervous(CentralNervous data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PacnId, Action))
                {


                    data.cn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.CentralNervous.isValidCentralNervous(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.CentralNervous.InsertUpdateCentralNervous(data);

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

        //Delete: EMR/CentralNervous
        [HttpPost]
        public ActionResult DeleteCentralNervous(int cnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PacnId, Action))
                {

                    int val = BusinessLogicLayer.EMR.CentralNervous.DeleteCentralNervous(cnId, cn_madeby);

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
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}