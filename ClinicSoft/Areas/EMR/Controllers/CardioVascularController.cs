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
    public class CardioVascularController : Controller
    {
        #region CardioSystem
        int PageId = (int)Pages.CardioVascular;
        // GET: EMR/CardioVascular
        public PartialViewResult CardioVascular()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    List<CardioVascular> cardio = BusinessLogicLayer.EMR.CardioVascular.GetAllCardioVascular(appId, 0);
                    return PartialView("CardioVascular", cardio.FirstOrDefault());
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

        public JsonResult GetAllCardioVascular(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CardioVascular> cardio = BusinessLogicLayer.EMR.CardioVascular.GetAllCardioVascular(appId, 0);

                return Json(cardio, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/CardioVascular

        public JsonResult GetAllPreCardioVascular(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CardioVascular> cardio = BusinessLogicLayer.EMR.CardioVascular.GetAllPreCardioVascular(appId, patId);

                return Json(cardio, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Copy/Previous
        public JsonResult CopyCardioVascular(int cvId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CardioVascular> cardio = BusinessLogicLayer.EMR.CardioVascular.GetAllCardioVascular(0, cvId);

                return Json(cardio, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: CardioVascular
        [HttpGet]
        public PartialViewResult ViewCardioVascular(int cvId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<CardioVascular> cardio = BusinessLogicLayer.EMR.CardioVascular.GetAllCardioVascular(0, cvId);

                    return PartialView("ViewCardioVascular", cardio.FirstOrDefault());
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

        // INSERT: CardioVascular
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertCardioVascular(CardioVascular data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cv_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.CardioVascular.isValidCardioVascular(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.CardioVascular.InsertUpdateCardioVascular(data);

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
        // Update: CardioVascular
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCardioVascular(CardioVascular data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cv_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.CardioVascular.isValidCardioVascular(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.CardioVascular.InsertUpdateCardioVascular(data);

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

        //Delete: EMR/CardioVascular
        [HttpPost]
        public ActionResult DeleteCardioVascular(int cvId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cv_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.CardioVascular.DeleteCardioVascular(cvId, cv_madeby);

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