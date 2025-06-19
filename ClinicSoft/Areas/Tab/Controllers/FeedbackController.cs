using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Tab.Controllers
{
    [AllowAnonymous]
    public class FeedbackController : Controller
    {
        [HttpGet]
        public ActionResult Feedback(string token)
        {
            string appId = HttpUtility.UrlDecode(token);

            ViewBag.appId = appId;

            try
            {
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertFeedback(BusinessEntities.Tab.Feedback data)
        {
            try
            {
                int isInserted = 0;

                isInserted = BusinessLogicLayer.Tab.Feedback.SaveFeedback(data);

                if (isInserted > 0)
                {
                    return Json(new { isSuccess = true, message = "Review Submitted Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Review already submitted!" }, JsonRequestBehavior.AllowGet);
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