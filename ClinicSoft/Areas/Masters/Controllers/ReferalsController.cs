using BusinessEntities;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class ReferalsController : Controller
    {
        int PageId = (int)Pages.Referals;

        #region Referals Master (Page Load)
        [HttpGet]
        public ActionResult Referals()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Referrals!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllReferrals()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Referals> referrals = BusinessLogicLayer.Masters.Referals.GetAllReferrals(0);

                return Json(referrals, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Referals Master (CRUD Operations)
        [HttpGet]
        public PartialViewResult CreateReferal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Referals referral = new BusinessEntities.Masters.Referals();

                    referral.CountryList = BusinessLogicLayer.Lists.Countries.GetCountryList();

                    return PartialView("CreateReferal", referral);
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
        public ActionResult InsertReferral(BusinessEntities.Masters.Referals data)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.Referals.isValidReferal(data, out errors))
                {
                    isInserted = BusinessLogicLayer.Masters.Referals.InsertUpdateReferral(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created New Referral : {data.ref_name}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Referral Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Referral Already Exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditReferal(int refId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Referals referral = BusinessLogicLayer.Masters.Referals.GetAllReferrals(refId).FirstOrDefault();

                    referral.CountryList = BusinessLogicLayer.Lists.Countries.GetCountryList();

                    return PartialView("EditReferal", referral);
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
        public ActionResult UpdateReferral(BusinessEntities.Masters.Referals data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.Referals.isValidReferal(data, out errors))
                {
                    isUpdated = BusinessLogicLayer.Masters.Referals.InsertUpdateReferral(data);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Referral with refId = {data.refId}"
                        });

                        return Json(new { isUpdated = true, isSuccess = true, message = "Referral Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Referral Already Exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateReferralStatus(int refId, string ref_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Referals.UpdateReferralStatus(refId, ref_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Referral Status to : {ref_status} with refId = {refId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Referral Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Referral with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Referral Status!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteReferralStatus(int refId, string ref_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Referals.UpdateReferralStatus(refId, ref_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Referral with refId = {refId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Referral Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Referral!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Acces Denied!" }, JsonRequestBehavior.AllowGet);
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