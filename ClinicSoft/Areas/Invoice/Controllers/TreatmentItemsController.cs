using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class TreatmentItemsController : Controller
    {
        int PageId = (int)Pages.TreatmentItems;

        public ActionResult Index()
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
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetTreatmentItems(int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.TreatmentItem> list = new List<BusinessEntities.Invoice.TreatmentItem>();
                try
                {
                    list = BusinessLogicLayer.Invoice.TreatmentItem.GetTreatmentItems(ptId);

                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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
        public ActionResult AddTreatmentItem(TreatmentItem item)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int val = BusinessLogicLayer.Invoice.TreatmentItem.CreateTreatmentItems(item, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created New Treatment Item : {item.tit_item}"
                        });

                        return Json(new { isSuccess = true, message = val }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = -1 }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteTreatmentItems(int titId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Invoice.TreatmentItem.UpdateTreatmentItemStatus(titId, "Deleted", PageControl.getLoggedinId());

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Treatment Item with titId = {titId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Treatment Item Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Treatment Item!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorised!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult UpdateTreatmentItemStatus(int titId, string tit_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Invoice.TreatmentItem.UpdateTreatmentItemStatus(titId, tit_status, PageControl.getLoggedinId());

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Treatment Item Status to {tit_status} with titId = {titId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Treatment Item Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Treatment Item Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Miscellaneous Functions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            bool isPartial = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            TempData["error"] = filterContext;

            string actionName = isPartial ? "ErrorPartialView" : "Error";

            filterContext.Result = RedirectToAction(actionName, "Error", new { area = "Common" });
        }
        #endregion
    }
}