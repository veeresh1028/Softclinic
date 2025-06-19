using BusinessEntities.Appointment;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class TreatmentItemsController : Controller
    {
        int PageId = (int)Pages.TreatmentItems;

        [HttpGet]
        public ActionResult TreatmentItems(int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.Invoice.TreatmentItemView items = new BusinessEntities.Invoice.TreatmentItemView();
                items.ptId = ptId;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Treatment Items Page!"
                });

                return PartialView("TreatmentItems", items);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetTreatmentItems(int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.EMR.TreatmentItems> items = BusinessLogicLayer.EMR.TreatmentItems.GetTreatmentItems(ptId);

                var jsonResult = Json(items, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return Json(new { isAuthorized = true, message = jsonResult.Data }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult SearchTreatments(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> list = new List<CommonDDL>();

                try
                {
                    list = BusinessLogicLayer.Invoice.TreatmentItem.SearchTreatmentItems(query);

                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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
        [ValidateAntiForgeryToken]
        public ActionResult InsertTreatmentItem(BusinessEntities.EMR.TreatmentItems item)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int val = BusinessLogicLayer.EMR.TreatmentItems.InsertTreatmentItems(item, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Created New Treatment Item : {item.tit_item}"
                        });

                        return Json(new { isSuccess = true, message = val }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, message = "Treatment Item already exists for the same details!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Failed to Create Treatment Item!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateTreatmentItemStatus(int titId, string tit_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int isUpdated = 0;

                    int empId = PageControl.getLoggedinId();

                    isUpdated = BusinessLogicLayer.EMR.TreatmentItems.UpdateTreatmentItemStatus(titId, tit_status, empId);

                    if (isUpdated > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Allocated Qty Excceds Batch Qty!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated, message = "Error While Updating Status!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult DeleteTreatmentItem(int titId, string tit_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int isUpdated = 0;

                    int empId = PageControl.getLoggedinId();

                    isUpdated = BusinessLogicLayer.EMR.TreatmentItems.UpdateTreatmentItemStatus(titId, tit_status, empId);

                    if (isUpdated > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Treatment Item Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Allocated Qty Excceds Batch Qty!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated, message = "Error While Deleting Treatment Item!" }, JsonRequestBehavior.AllowGet);
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
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "ErrorEMR", new { area = "EMR" });
        }
    }
}