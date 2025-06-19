using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Appointment;
using Google.Type;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class ChartOfAccountsController : Controller
    {
        int PageId = (int)Pages.ChartOfAccounts;

        [HttpGet]
        public ActionResult ChartOfAccounts()
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
        public JsonResult GetChartOfAccounts(ChartOfAccountsSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.ChartOfAccounts> coa_list = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetChartOfAccounts(data);

                    return Json(new { isAuthorized = true, coa_list }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = false }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult GetCOACode(ChartOfAccountsCode data)
        {
            try
            {
                string acc_code = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GenerateCOACode(data);

                return Json(new { acc_code }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult CreateChartOfAccounts()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    BusinessEntities.Accounts.Accounting.ChartOfAccounts coa = new BusinessEntities.Accounts.Accounting.ChartOfAccounts();
                    coa.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    coa.acc_branch = Convert.ToInt32(emp_branch);
                    coa.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("CreateChartOfAccounts", coa);
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
        public ActionResult InsertChartOfAccount(BusinessEntities.Accounts.Accounting.ChartOfAccounts data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidChartOfAccount(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.InsertUpdateChartOfAccount(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = 1, message = "Chart of Account Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Chart of Account already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Creating Chart of Account!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public PartialViewResult EditChartOfAccount(int accId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                ChartOfAccountsSearch data = new ChartOfAccountsSearch();
                data.accId = accId;
                data.empId = PageControl.getLoggedinId();

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Accounts.Accounting.ChartOfAccounts coa = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetChartOfAccounts(data).FirstOrDefault();
                    coa.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    coa.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("EditChartOfAccounts", coa);
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
        public ActionResult UpdateChartOfAccount(BusinessEntities.Accounts.Accounting.ChartOfAccounts data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidChartOfAccountUpdate(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.InsertUpdateChartOfAccount(data);

                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = 1, message = "Chart of Account Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -1)
                        {
                            return Json(new { isUpdated = -1, message = "Account has Transactions Associated, Can't Update!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -2)
                        {
                            return Json(new { isUpdated = -1, message = "Chart of Account already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = 0, message = "Error While Updating Chart of Account!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public PartialViewResult ChartOfAccountsAuditLogs(int accId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<ChartOfAccountsLogs> _logsList = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetChartOfAccountsAuditLogs(accId, empId);

                    return PartialView("ChartOfAccountsAuditLogs", _logsList);
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
        public PartialViewResult ViewAccountDetails(int accId, string acc_code, string acc_name, string acc_gtype, string acc_period)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                ChartOfAccountsDetails coa = new ChartOfAccountsDetails();
                coa.accId = accId;
                coa.acc_code = acc_code;
                coa.acc_name = acc_name;
                coa.acc_gtype = acc_gtype;
                coa.acc_period = acc_period;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("ViewAccountDetails", coa);
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
        public JsonResult GetAccountDetails(string tr_account, string date_from, string date_to)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                List<COALedgers> accountslist = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.AccountDetails(tr_account, date_from, date_to, empId);

                return Json(accountslist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetInvoiceType(int invId)
        {
            string type = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetInvoiceType(invId);

            return Json(type, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAccountsDropdown(LoadAccounts data)
        {
            try
            {
                List<CommonDDLFORMS> dt = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetAccountsDropdown(data);

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

        [HttpGet]
        public ActionResult GetAccountDropdownByCode(string acc_code, string acc_period, int acc_branch)
        {
            try
            {
                List<CommonDDLFORMS> dt = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetAccountDropdownByCode(acc_code, acc_period, acc_branch);

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

        [HttpGet]
        public ActionResult GetActiveChartOfAccountsDropdown(string acc_type, string acc_period, int acc_branch, string acc_gtype)
        {
            try
            {
                List<CommonDDLFORMS> dt = BusinessLogicLayer.Accounts.Accounting.ChartOfAccounts.GetActiveChartOfAccountsDropdown(acc_type, acc_period, acc_branch, acc_gtype);

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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}