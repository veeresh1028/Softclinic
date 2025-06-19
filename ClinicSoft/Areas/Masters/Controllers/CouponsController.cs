using BusinessEntities;
using ClinicSoft.Models;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class CouponsController : Controller
    {
        int PageId = (int)Pages.Discounts;

        #region Discounts Master (Page Load)
        [HttpGet]
        public ActionResult Coupons()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Discounts!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllCoupons()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Coupons> coupons = BusinessLogicLayer.Masters.Coupons.GetCoupons(0);

                return Json(coupons, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Discounts CRUD Operations
        [HttpGet]
        public PartialViewResult CreateCoupons()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Coupons coupon = new BusinessEntities.Masters.Coupons();

                    coupon.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("CreateCoupons", coupon);
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
        public ActionResult InsertCoupon(BusinessEntities.Masters.Coupons data)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.Coupons.isValidCoupons(data, out errors))
                {
                    data.disc_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.Masters.Coupons.InsertUpdateCoupon(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.disc_madeby,
                            log_desc = $"Employee Created New Discount : {data.disc_name}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Discount Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Discount Already Exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public PartialViewResult EditCoupons(int discId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Coupons coupon = BusinessLogicLayer.Masters.Coupons.GetCoupons(discId).FirstOrDefault();

                    coupon.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("EditCoupons", coupon);
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
        public ActionResult UpdateCoupon(BusinessEntities.Masters.Coupons data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.Coupons.isValidCoupons(data, out errors))
                {
                    data.disc_madeby = PageControl.getLoggedinId();

                    isUpdated = BusinessLogicLayer.Masters.Coupons.InsertUpdateCoupon(data);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.disc_madeby,
                            log_desc = $"Employee Updated Discount with discId = {data.discId}"
                        });

                        return Json(new { isUpdated = true, isSuccess = true, message = "Discount Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Discount Already Exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult UpdateCouponStatus(int discId, string disc_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Coupons.UpdateCouponStatus(discId, disc_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Discount Status to : {disc_status} with discId = {discId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Discount Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Discount with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Discount Status!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult DeleteCoupon(int discId, string disc_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Coupons.UpdateCouponStatus(discId, disc_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Discount with discId = {discId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Discount Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Discount!" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}