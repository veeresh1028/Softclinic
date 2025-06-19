using BusinessEntities.NurseStation;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BusinessEntities.Appointment;
using System.Collections;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class TPRChartsController : Controller
    {
        #region TPRChart
        // GET: NurseStation/TPRCharts

        int PageId = (int)Pages.VitalSign;
        public PartialViewResult TPRCharts()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("TPRCharts");
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
        public ActionResult DrawTPRStatChart(int patId,string app_fdate)
        {
            TRPChartData data = BusinessLogicLayer.NurseStation.TPRCharts.GetTPRStatChart(patId, app_fdate);
            var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        #endregion TPRChart
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}