using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class FundsTransferController : Controller
    {
        int PageId = (int)Pages.Journals;

        [HttpGet]
        public ActionResult FundsTransfer()
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
        public JsonResult GetFundsTransfer(FundsTransferSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.FundsTransfer> FT_list = BusinessLogicLayer.Accounts.Accounting.FundsTransfer.GetFundsTransfer(data);

                    return Json(new { isAuthorized = true, message = "", FT_list }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult CreateFundsTransfer()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    BusinessEntities.Accounts.Accounting.FundsTransfer ftl = new BusinessEntities.Accounts.Accounting.FundsTransfer();
                    ftl.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    ftl.ft_branch = Convert.ToInt32(emp_branch);
                    ftl.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("CreateFundsTransfer", ftl);
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
        public ActionResult InsertFundsTransfer(FundsTransfer data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ft_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidFundsTransfer(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.FundsTransfer.InsertFundsTransfer(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = isInserted, message = "Funds Transfer Inserted Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Funds Transfer already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Inserting Funds Transfer!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ChangeFundTransferStatus(string ft_code, int ft_branch, string status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.FundsTransfer.ChangeFundTransferStatus(ft_code, ft_branch, status, empId);

                    if (ischanged > 0)
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Fund Transfer Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult FundTransferAuditLogs(string ft_code)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<FundTransferAudit> _logsList = BusinessLogicLayer.Accounts.Accounting.FundsTransfer.GetFundTransferAuditLogs(ft_code, empId);

                    return PartialView("FundTransferAuditLogs", _logsList);
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

        [HttpGet]
        public PartialViewResult EditFundsTransfer(string ft_code)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                FundsTransferSearch data = new FundsTransferSearch();
                data.empId = PageControl.getLoggedinId();
                data.ft_code = ft_code;

                FundsTransfer ft_detail = BusinessLogicLayer.Accounts.Accounting.FundsTransfer.GetFundsTransfer(data).FirstOrDefault();
                ft_detail.BranchList = BusinessLogicLayer.Company.GetBranchList();
                ft_detail.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                return PartialView("EditFundsTransfer", ft_detail);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFundsTransfer(FundsTransfer data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ft_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidFundsTransfer(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Accounts.Accounting.FundsTransfer.InsertFundsTransfer(data);

                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = isUpdated, message = "Funds Transfer Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -1)
                        {
                            return Json(new { isUpdated = -1, message = "Funds Transfer already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = 0, message = "Error While Updating Funds Transfer!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = 0, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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