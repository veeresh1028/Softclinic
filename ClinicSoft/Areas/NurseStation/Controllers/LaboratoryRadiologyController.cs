using BusinessEntities.NurseStation;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestSharp;
using System.Configuration;
using System.Threading.Tasks;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class LaboratoryRadiologyController : Controller
    {
        // GET: NurseStation/LaboratoryRadiology

        int PageId = (int)Pages.PhysicianOrders;
        public PartialViewResult LaboratoryRadiology()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("LaboratoryRadiology");
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

        public JsonResult GetAllLaboratoryRadiology(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaboratoryRadiology> order = BusinessLogicLayer.NurseStation.LaboratoryRadiology.GetAllLaboratoryRadiology(appId);

                return Json(order, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //update Collection
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePatinetTreatmentCollection(BusinessEntities.NurseStation.LaboratoryRadiology data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;
                data.pt_coll_by = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    
                        isInserted = BusinessLogicLayer.NurseStation.LaboratoryRadiology.UpdatePatinetTreatmentCollection(data);

                        if (isInserted)
                        {
                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 3,
                            AJ_AJSCId = 14,
                            AJ_AppId = data.pt_appId
                        });
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Print Items Barcode
        [HttpPost]
        public async Task<ActionResult> PrintBarcodeService(BarcodeServices data)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string Age_Gender = "";
                    int empId = PageControl.getLoggedinId();
                    BarcodeServices barcodeService = BusinessLogicLayer.NurseStation.LaboratoryRadiology.GetBarcodePrintData(data);
                    Age_Gender = ("File No: "+ barcodeService.pat_code +"/" +barcodeService.pat_age_years + "Y/"+ barcodeService.pat_gender);
                    string end_point = "Device/PrintBarcodeData?BarCodeNo=" + barcodeService.pt_appId + "&PatientName= " + barcodeService.pat_name + "&AgeGender=" + Age_Gender + "&CollectedDate" + barcodeService.pt_date_collected.ToString();
                    var options = new RestClientOptions(ConfigurationManager.AppSettings["BarcodeServiceEndPoint"].ToString())
                    {
                        MaxTimeout = -1,
                    };
                    var client = new RestClient(options);
                    var request = new RestRequest(end_point, Method.Get);
                    RestResponse response = await client.ExecuteAsync(request);
                    if (response.IsSuccessful)
                    {
                        return Json(new { isSuccess = true, message = response.Content, data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = response.Content, data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message, data = new { } }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
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