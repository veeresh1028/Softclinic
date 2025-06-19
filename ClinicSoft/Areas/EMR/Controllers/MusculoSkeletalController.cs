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
    public class MusculoSkeletalController : Controller
    {
        #region MusculoSkeletal
        int PageId = (int)Pages.MusculoSkeletal;
        // GET: EMR/MusculoSkeletal
        public PartialViewResult MusculoSkeletal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    List<MusculoSkeletal> musculo = BusinessLogicLayer.EMR.MusculoSkeletal.GetAllMusculoSkeletal(appId, 0);
                    return PartialView("MusculoSkeletal", musculo.FirstOrDefault());
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

        public JsonResult GetAllMusculoSkeletal(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MusculoSkeletal> musculo = BusinessLogicLayer.EMR.MusculoSkeletal.GetAllMusculoSkeletal(appId, 0);

                return Json(musculo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/MusculoSkeletal

        public JsonResult GetAllPreMusculoSkeletal(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MusculoSkeletal> musculo = BusinessLogicLayer.EMR.MusculoSkeletal.GetAllPreMusculoSkeletal(appId, patId);

                return Json(musculo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Copy/Previous
        public JsonResult CopyMusculoSkeletal(int msId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MusculoSkeletal> musculo = BusinessLogicLayer.EMR.MusculoSkeletal.GetAllMusculoSkeletal(0, msId);

                return Json(musculo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: MusculoSkeletal
        [HttpGet]
        public PartialViewResult ViewMusculoSkeletal(int msId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<MusculoSkeletal> musculo = BusinessLogicLayer.EMR.MusculoSkeletal.GetAllMusculoSkeletal(0, msId);

                    return PartialView("ViewMusculoSkeletal", musculo.FirstOrDefault());
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

        // INSERT: MusculoSkeletal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertMusculoSkeletal(MusculoSkeletal data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ms_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MusculoSkeletal.isValidMusculoSkeletal(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.MusculoSkeletal.InsertUpdateMusculoSkeletal(data);

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
        // Update: MusculoSkeletal
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMusculoSkeletal(MusculoSkeletal data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ms_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MusculoSkeletal.isValidMusculoSkeletal(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.MusculoSkeletal.InsertUpdateMusculoSkeletal(data);

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

        //Delete: EMR/MusculoSkeletal
        [HttpPost]
        public ActionResult DeleteMusculoSkeletal(int msId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ms_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.MusculoSkeletal.DeleteMusculoSkeletal(msId, ms_madeby);

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