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
    public class PainScaleController : Controller
    {

        #region PainScale
        int PapaId = (int)Pages.PainScale;
        // GET: EMR/PainScale

        public PartialViewResult PainScale()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PapaId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    List<PainScale> pain = BusinessLogicLayer.EMR.PainScale.GetAllPainScale(appId, 0);
                    return PartialView("PainScale", pain.FirstOrDefault());
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

        public JsonResult GetAllPainScale(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PapaId, Action))
            {
                List<PainScale> pain = BusinessLogicLayer.EMR.PainScale.GetAllPainScale(appId, 0);

                return Json(pain, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/PainScale

        public JsonResult GetAllPrePainScale(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PapaId, Action))
            {
                List<PainScale> pain = BusinessLogicLayer.EMR.PainScale.GetAllPrePainScale(appId, patId);

                return Json(pain, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Copy/Previous
        public JsonResult CopyPainScale(int paId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PapaId, Action))
            {
                List<PainScale> pain = BusinessLogicLayer.EMR.PainScale.GetAllPainScale(0, paId);

                return Json(pain, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: PainScale
        [HttpGet]
        public PartialViewResult ViewPainScale(int paId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PapaId, Action))
                {
                    List<PainScale> pain = BusinessLogicLayer.EMR.PainScale.GetAllPainScale(0, paId);

                    return PartialView("ViewPainScale", pain.FirstOrDefault());
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
        // INSERT: PainScale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertPainScale(PainScale data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PapaId, Action))
                {


                    data.pa_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.PainScale.isValidPainScale(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.PainScale.InsertUpdatePainScale(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Pain already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Update: PainScale
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePainScale(PainScale data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PapaId, Action))
                {


                    data.pa_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.PainScale.isValidPainScale(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.PainScale.InsertUpdatePainScale(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Pain already exists!" }, JsonRequestBehavior.AllowGet);
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

        //Delete: EMR/PainScale
        [HttpPost]
        public ActionResult DeletePainScale(int paId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int pa_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PapaId, Action))
                {

                    int val = BusinessLogicLayer.EMR.PainScale.DeletePainScale(paId, pa_madeby);

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