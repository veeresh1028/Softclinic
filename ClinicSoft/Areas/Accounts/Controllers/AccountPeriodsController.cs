using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class AccountPeriodsController : Controller
    {
        int PageId = (int)Pages.AccountPeriods;

        [HttpGet]
        public ActionResult AccountPeriods()
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
        public JsonResult GetAccountPeriods()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                List<AccountPeriod> ap_list = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetAccountPeriods(0, empId);

                return Json(new { isAuthorized = true, ap_list }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetActiveAccountPeriods()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDLFORMS> ap_list = new List<CommonDDLFORMS>();

                try
                {
                    ap_list = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetActiveAccountPeriods();

                    var jsonResult = Json(ap_list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception)
                {
                    var jsonResult = Json(ap_list, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetOpenAccountPeriod()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDLFORMS> ap = new List<CommonDDLFORMS>();

                try
                {
                    ap = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    var jsonResult = Json(ap, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception)
                {
                    var jsonResult = Json(ap, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult CreateAccountPeriod()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateAccountPeriod");
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
        public ActionResult InsertAccountPeriod(AccountPeriod data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidAccountPeriod(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.InsertUpdateAccountPeriod(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = 1, message = "Account Period Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Account Period already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Creating Account Period!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = 0, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult UpdateStatus(int agId, string ag_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.ChangeAccountPeriodStatus(agId, ag_status, empId);

                    if (ischanged > 0)
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Account Period Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Error While Changing Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult AccountPeriodAuditLogs(int apId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    AccountPeriodLogsList _logsList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetAccountPeriodAuditLogs(apId, empId);

                    return PartialView("AccountPeriodAuditLogs", _logsList);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}