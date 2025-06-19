using BusinessEntities;
using BusinessEntities.Accounts.MaterialManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Reports.Controllers
{
    [Authorize]
    public class InternalStockComsumptionReportController : Controller
    {
        int PageId = (int)Pages.InternalStockComsumptionReport;

        [HttpGet]
        public ActionResult InternalStockComsumptionReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetInternalStockComsumption(BusinessEntities.EMR.InternalStockConsumptionSearch filter)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.EMR.TreatmentItems> stock = BusinessLogicLayer.EMR.TreatmentItems.SearchInternalStockConsumptionReport(filter);

                var jsonResult = Json(stock, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return Json(new { isAuthorized = true, message = jsonResult.Data }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult SearchItems(string query, int branch, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<AdjustmentDDL> dt = null;
                    
                    if (!string.IsNullOrEmpty(query) && branch > 0)
                        dt = BusinessLogicLayer.EMR.TreatmentItems.SearchItems(query, branch, type);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                   
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                   
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult PostInternalStockConsumptionToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.EMR.TreatmentItems.PostInternalStockConsumptionToAccount(data, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Posted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Purchase Invoice Posting Error" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Posting Purchase Invoice!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = -3, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
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