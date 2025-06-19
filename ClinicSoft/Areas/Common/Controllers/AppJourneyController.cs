using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Common.Controllers
{
    public class AppJourneyController : Controller
    {
        // GET: Common/AppJourney
        public ActionResult AppJourney()
        {
            return View();
        }
        [HttpPost]
        public JsonResult InsertAppJourney(int AJCId,int AJSCId,int AppId)
        {
            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
            {
                AJ_AJCId = AJCId,
                AJ_AJSCId = AJSCId,
                AJ_AppId = AppId
            });

            return Json(new { message = "AppJourney Created!" }, JsonRequestBehavior.AllowGet);
        }
    }
}