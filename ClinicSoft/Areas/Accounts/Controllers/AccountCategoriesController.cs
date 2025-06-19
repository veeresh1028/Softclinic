using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;
using BusinessEntities.Marketing;
using BusinessLogicLayer.Accounts.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class AccountCategoriesController : Controller
    {
        int PageId = (int)Pages.AccountCategories;

        [HttpGet]
        public ActionResult AccountCategories()
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
        public JsonResult GetAccountCategories(AccountCategoriesSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.AccountCategories> ac_list = BusinessLogicLayer.Accounts.Accounting.AccountCategories.GetAccountCategories(data);

                    return Json(new { isAuthorized = true, ac_list }, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAccountCategoryCode(AccountCategoryCode data)
        {
            try
            {
                string ac_code = BusinessLogicLayer.Accounts.Accounting.AccountCategories.GenerateCategoryCode(data);

                return Json(new { ac_code }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult CreateAccountCategory()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    BusinessEntities.Accounts.Accounting.AccountCategories category = new BusinessEntities.Accounts.Accounting.AccountCategories();
                    category.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    category.ac_branch = Convert.ToInt32(emp_branch);
                    category.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("CreateAccountCategory", category);
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
        public ActionResult InsertAccountCategory(BusinessEntities.Accounts.Accounting.AccountCategories data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidAccountCategory(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.AccountCategories.InsertUpdateAccountCategory(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = isInserted, message = "Account Category Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Account Category already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Creating Account Category!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditAccountCategory(int acId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    AccountCategoriesSearch data = new AccountCategoriesSearch();
                    data.acId = acId;
                    data.empId = PageControl.getLoggedinId();

                    BusinessEntities.Accounts.Accounting.AccountCategories category = BusinessLogicLayer.Accounts.Accounting.AccountCategories.GetAccountCategories(data).FirstOrDefault();
                    category.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    category.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("EditAccountCategory", category);
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
        public ActionResult UpdateAccountCategory(BusinessEntities.Accounts.Accounting.AccountCategories data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidAccountCategoryUpdate(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Accounts.Accounting.AccountCategories.InsertUpdateAccountCategory(data);

                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = 1, message = "Account Category Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -1)
                        {
                            return Json(new { isUpdated = -1, message = "Account Category already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdated == -2)
                        {
                            return Json(new { isUpdated = -2, message = "Account Category has Transactions Associated!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = 0, message = "Error While Updating Account Category!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult AccountCategoryAuditLogs(int acId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<AccountCategoryLogs> _logsList = BusinessLogicLayer.Accounts.Accounting.AccountCategories.GetAccountCategoryAuditLogs(acId, empId);

                    return PartialView("AccountCategoryAuditLogs", _logsList);
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
        public ActionResult GetCategories(CategoriesLoad cat)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDLFORMS> data = BusinessLogicLayer.Accounts.Accounting.AccountCategories.GetCategories(string.Join(",", cat.Branches), string.Join(",", cat.Period), string.Join(",", cat.Groups));

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetAccountCategoryById(int acId)
        {
            List<CommonDDLFORMS> group = new List<CommonDDLFORMS>();

            try
            {
                group = BusinessLogicLayer.Accounts.Accounting.AccountCategories.GetAccountCategoryById(acId);

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

        [HttpGet]
        public PartialViewResult ViewAccountCategoryDetails(int acId, string ac_code, string ac_category, string ac_type, string ac_period)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                AccountCategoryDetails ac = new AccountCategoryDetails();
                ac.acId = acId;
                ac.ac_code = ac_code;
                ac.ac_category = ac_category;
                ac.ac_type = ac_type;
                ac.ac_period = ac_period;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("ViewAccountCategoryDetails", ac);
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
        public JsonResult GetAccountCategoryDetails(string tr_account, string date_from, string date_to, string ac_code, string ac_period)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<COALedgers> categorylist = BusinessLogicLayer.Accounts.Accounting.AccountCategories.AccountCategoryDetails(tr_account, date_from, date_to, empId, ac_code, ac_period);

                    return Json(new { isAuthorized = true, message = categorylist }, JsonRequestBehavior.AllowGet);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}