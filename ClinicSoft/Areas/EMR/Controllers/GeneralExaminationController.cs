using BusinessEntities;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;


namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class GeneralExaminationController : Controller
    {
        #region GeneralExam
        int PageId = (int)Pages.GeneralExamination;
        // GET: EMR/GeneralExamination
        public ActionResult GeneralExamination()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    List<GeneralExamination> genexam = BusinessLogicLayer.EMR.GeneralExamination.GetAllGeneralExamination(appId,0);
                    return View("GeneralExamination", genexam.FirstOrDefault());
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            else
            {
                return View("_SessionExpired");
            }

        }

        public JsonResult GetAllGeneralExamination(int ? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<GeneralExamination> genexam = BusinessLogicLayer.EMR.GeneralExamination.GetAllGeneralExamination(appId,0);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/GeneralExamination

        public JsonResult GetAllPreGeneralExamination(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<GeneralExamination> genexam = BusinessLogicLayer.EMR.GeneralExamination.GetAllPreGeneralExamination(appId, patId);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Copy/Previous
        public JsonResult CopyGeneralExamination( int geId)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<GeneralExamination> genexam = BusinessLogicLayer.EMR.GeneralExamination.GetAllGeneralExamination(0, geId);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // View: GeneralExamination
        [HttpGet]
        public PartialViewResult ViewGeneralExamination(int geId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<GeneralExamination> genexam = BusinessLogicLayer.EMR.GeneralExamination.GetAllGeneralExamination(0, geId);

                    return PartialView("ViewGeneralExamination", genexam.FirstOrDefault());
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
        // INSERT: GeneralExamination
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertGeneralExamination(GeneralExamination data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ge_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.GeneralExamination.isValidGeneralExamination(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.GeneralExamination.InsertUpdateGeneralExamination(data);

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
        // Update: GeneralExamination
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateGeneralExamination(GeneralExamination data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ge_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.GeneralExamination.isValidGeneralExamination(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.GeneralExamination.InsertUpdateGeneralExamination(data);

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

        //Delete: EMR/GeneralExamination
        [HttpPost]
        public ActionResult DeleteGeneralExamination(int geId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ge_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.GeneralExamination.DeleteGeneralExamination(geId, ge_madeby);

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