using BusinessEntities.Appointment;
using BusinessEntities;
using BusinessEntities.Timeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Timeline.Controllers
{
    [Authorize]
    public class AppJourneyController : Controller
    {
        [HttpGet]
        public ActionResult AppJourneyIndex()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult JourneyView(int appId)
        {
            BusinessEntities.Appointment.SearchAppJourney search = new BusinessEntities.Appointment.SearchAppJourney();
            search.appId = appId;

            return PartialView(search);
        }

        [HttpGet]
        public ActionResult GetJourneyData(int appId)
        {
            AppJourneyData data = BusinessLogicLayer.Timeline.AppJourney.GetAppJourney(appId);
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SearchJourney(string query)
        {
            try
            {
                List<CommonDDL> dt = BusinessLogicLayer.Timeline.AppJourney.SearchJourney(query);

                var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
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