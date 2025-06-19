using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class AccountGroupsController : Controller
    {
        int PageId = (int)Pages.AccountGroups;

        [HttpGet]
        public ActionResult AccountGroups()
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
        public JsonResult GetAccountGroups(AccountGroupsSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<AccountGroup> ag_list = BusinessLogicLayer.Accounts.Accounting.AccountGroup.GetAccountGroups(data);

                    return Json(new { isAuthorized = true, ag_list }, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAccountGroupCode(AccountGroupCode data)
        {
            try
            {
                string ag_code = BusinessLogicLayer.Accounts.Accounting.AccountGroup.GenerateGroupCode(data);

                return Json(new { ag_code }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult CreateAccountGroup()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    AccountGroup group = new AccountGroup();
                    group.ag_branch = Convert.ToInt32(emp_branch);
                    group.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    group.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("CreateAccountGroup", group);
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
        public ActionResult InsertAccountGroup(AccountGroup data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidAccountGroup(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.AccountGroup.InsertUpdateAccountGroup(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = isInserted, message = "Account Group Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Account Group already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Creating Account Group!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditAccountGroup(int agId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    AccountGroupsSearch data = new AccountGroupsSearch();
                    data.agId = agId;
                    data.empId = PageControl.getLoggedinId();

                    AccountGroup group = BusinessLogicLayer.Accounts.Accounting.AccountGroup.GetAccountGroups(data).FirstOrDefault();
                    group.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    group.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("EditAccountGroup", group);
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
        public ActionResult UpdateAccountGroup(AccountGroup data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidAccountGroupUpdate(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Accounts.Accounting.AccountGroup.InsertUpdateAccountGroup(data);

                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = 1, message = "Account Group Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -1)
                        {
                            return Json(new { isUpdated = -1, message = "Account Group already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -2)
                        {
                            return Json(new { isUpdated = -2, message = "Account Group has Transactions Associated!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = 0, message = "Error While Updating Account Group!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult AccountGroupAuditLogs(int agId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<AccountGroupLogs> _logsList = BusinessLogicLayer.Accounts.Accounting.AccountGroup.GetAccountGroupAuditLogs(agId, empId);

                    return PartialView("AccountGroupAuditLogs", _logsList);
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
        public PartialViewResult ViewAccountGroupDetails(int agId, string ag_code, string ag_name, string ag_type, string ag_period)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                AccountGroupDetails ag = new AccountGroupDetails();
                ag.agId = agId;
                ag.ag_code = ag_code;
                ag.ag_name = ag_name;
                ag.ag_type = ag_type;
                ag.ag_period = ag_period;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("ViewAccountGroupDetails", ag);
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
        public JsonResult GetAccountGroupDetails(string tr_account, string date_from, string date_to, string ag_code, string ag_period)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<COALedgers> grouplist = BusinessLogicLayer.Accounts.Accounting.AccountGroup.AccountGroupDetails(tr_account, date_from, date_to, empId, ag_code, ag_period);

                    return Json(new { isAuthorized = true, message = grouplist }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Dropdown Filters
        [HttpGet]
        public ActionResult GetBranches()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();

                try
                {
                    branchList = BusinessLogicLayer.Company.GetBranchList();

                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception)
                {
                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetAccountGroupsByBranchPeriod(string ag_branch, string ag_period)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDLFORMS> accountGroups = new List<CommonDDLFORMS>();

                try
                {
                    accountGroups = BusinessLogicLayer.Accounts.Accounting.AccountGroup.GetAccountGroupsByBranchPeriod(ag_branch, ag_period);

                    var jsonResult = Json(accountGroups, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception)
                {
                    var jsonResult = Json(accountGroups, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetAccountGroupsById(int agId)
        {
            List<CommonDDLFORMS> group = new List<CommonDDLFORMS>();

            try
            {
                group = BusinessLogicLayer.Accounts.Accounting.AccountGroup.GetAccountGroupById(agId);

                var jsonResult = Json(group, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            catch (Exception)
            {
                var jsonResult = Json(group, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
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