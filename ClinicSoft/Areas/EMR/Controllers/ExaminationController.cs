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
    public class ExaminationController : Controller
    {
        // GET: EMR/Examination
        int PageId = (int)Pages.CardioVascular;
        public PartialViewResult Examination()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    int appId = int.Parse(emr.appId);
                    
                    List<Examination> exam = BusinessLogicLayer.EMR.Examination.GetAllExamination(appId);
                    
                    return PartialView("Examination", exam.FirstOrDefault());
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

        public JsonResult GetAllExamination(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Examination> genexam = BusinessLogicLayer.EMR.Examination.GetAllExamination(appId);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // INSERT: Examination
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertExamination(BusinessEntities.EMR.Examination data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.GeneralExamination.isValidExamination(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.Examination.InsertUpdateExamination(data, PageControl.getLoggedinId());

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Examination already exists!" }, JsonRequestBehavior.AllowGet);
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

        // UPDATE: Examination
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateExamination(BusinessEntities.EMR.Examination data)
        {
            bool isUpdated = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.GeneralExamination.isValidExamination(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.EMR.Examination.InsertUpdateExamination(data, PageControl.getLoggedinId());

                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Examination already exists!" }, JsonRequestBehavior.AllowGet);
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

        //Delete: EMR/Examination
        [HttpPost]
        public ActionResult DeleteExamination(int geId,int resId,int cvId,int cnId,int giId,int genId,int msId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.Examination.DeleteExamination(geId, resId, cvId, cnId, giId, genId, msId, PageControl.getLoggedinId());

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
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}