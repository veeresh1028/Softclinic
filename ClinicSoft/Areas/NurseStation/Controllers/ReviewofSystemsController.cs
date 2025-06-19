using BusinessEntities.NurseStation;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class ReviewofSystemsController : Controller
    {
        #region ROS
        // GET: NurseStation/ReviewofSystems

        int PageId = (int)Pages.ReviewofSystems;
        public PartialViewResult ReviewofSystems()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("ReviewofSystems");
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

        public JsonResult GetAllReviewofSystems(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ReviewofSystems> ros = BusinessLogicLayer.NurseStation.ReviewofSystems.GetAllReviewofSystems(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/ReviewofSystems

        public JsonResult GetAllPreReviewofSystems(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ReviewofSystems> ros = BusinessLogicLayer.NurseStation.ReviewofSystems.GetAllPreReviewofSystems(appId, patId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Create: ReviewofSystems
        public PartialViewResult CreateReviewofSystems()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    ReviewofSystems ros = new ReviewofSystems();
                    return PartialView("CreateReviewofSystems", ros);
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
        public ActionResult InsertReviewofSystems(ReviewofSystems data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    
                    isInserted = BusinessLogicLayer.NurseStation.ReviewofSystems.InsertUpdateReviewofSystems(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 3,
                            AJ_AJSCId = 9,
                            AJ_AppId = data.rs_appId
                        });
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "HPI already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: ReviewofSystems
        [HttpGet]
        public PartialViewResult EditReviewofSystems(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<ReviewofSystems> ROS = BusinessLogicLayer.NurseStation.ReviewofSystems.GetAllReviewofSystems(appId);

                    return PartialView("EditReviewofSystems", ROS.FirstOrDefault());
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
        public ActionResult UpdateReviewofSystems(ReviewofSystems data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.rs_madeby = PageControl.getLoggedinId();
                   
                        isInserted = BusinessLogicLayer.NurseStation.ReviewofSystems.InsertUpdateReviewofSystems(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "ROS already exists!" }, JsonRequestBehavior.AllowGet);
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

        //Delete: NurseStation/ReviewofSystems
       [HttpPost]
        public ActionResult DeleteReviewofSystems(int rsId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int rs_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.NurseStation.ReviewofSystems.DeleteReviewofSystems(rsId, rs_madeby);

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

        #endregion ROS
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}