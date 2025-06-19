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
    public class PhysicianOrdersController : Controller
    {
        #region PhysicianOrder
        // GET: NurseStation/PhysicianOrders

        int PageId = (int)Pages.PhysicianOrders;
        public PartialViewResult PhysicianOrders()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("PhysicianOrders");
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

        public JsonResult GetAllPhysicianOrders(int appId, int? ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PhysicianOrders> order = BusinessLogicLayer.NurseStation.PhysicianOrders.GetAllPhysicianOrders(appId, ptId);

                return Json(order, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //update Notes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePhysicianNotes(int ptId,string pt_notes)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.PhysicianOrders.isValidPhysicianOrders(pt_notes, out errors))
                    {
                        isInserted = BusinessLogicLayer.NurseStation.PhysicianOrders.UpdatePhysicianNotes(ptId,pt_notes);
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        if (isInserted)
                        {
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 3,
                                AJ_AJSCId = 13,
                                AJ_AppId = int.Parse(emr.appId)
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

        //update Time
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePhysicianOrderTime(int ptId, DateTime pt_date_collected,DateTime pt_date_received)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.PhysicianOrders.isValidPhysicianOrdersTime(pt_date_collected, pt_date_collected, out errors))
                    {
                        isInserted = BusinessLogicLayer.NurseStation.PhysicianOrders.UpdatePhysicianOrderTime(ptId, pt_date_collected ,pt_date_received);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Time Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Time already updated!" }, JsonRequestBehavior.AllowGet);
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

        #endregion 
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}