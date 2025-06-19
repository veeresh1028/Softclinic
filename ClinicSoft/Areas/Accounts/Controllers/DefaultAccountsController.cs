using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class DefaultAccountsController : Controller
    {
        int PageId = (int)Pages.Journals;

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

        public ActionResult AccountGroups(ReportFilters search)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                search.empId = PageControl.getLoggedinId();
                DefaultAccountsList ag_list = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.GetDefaultGroups(search);

                return View(ag_list);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccountDefaultGroup(DefaultAccounts data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.CreateDefaultAccountGroup(data);

                    if (ischanged > 0)
                    {
                        ReportFilters search = new ReportFilters();
                        search.branch = data.branch;
                        search.acc_period = data.period;
                        search.empId = data.empId;
                        DefaultAccountsList ag_list = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.GetDefaultGroups(search);

                        return Json(new { isInserted = true, success = true, message = "Group Created Successfully!", list = ag_list.defaultAccountsList }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = true, success = false, message = "Error While Creating Group!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult AccountCategories(ReportFilters search)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                search.empId = PageControl.getLoggedinId();
                DefaultAccountsList ac_list = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.GetDefaultCategories(search);

                return View(ac_list);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAccountDefaultCategory(DefaultAccounts data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.CreateDefaultAccountCategory (data);

                    if (ischanged > 0)
                    {
                        ReportFilters search = new ReportFilters();
                        search.branch = data.branch;
                        search.acc_period = data.period;
                        search.empId = data.empId;
                        DefaultAccountsList ac_list = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.GetDefaultCategories(search);

                        return Json(new { isInserted = true, success = true, message = "Category Created Successfully!", list = ac_list.defaultAccountsList }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = true, success = false, message = "Error While Creating Category!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ActionResult Accounts(ReportFilters search)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                search.empId = PageControl.getLoggedinId();
                DefaultAccountsList a_list = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.GetDefaultAccounts(search);

                return View(a_list);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDefaultAccount(DefaultAccounts data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.CreateDefaultAccount(data);

                    if (ischanged > 0)
                    {
                        ReportFilters search = new ReportFilters();
                        search.branch = data.branch;
                        search.acc_period = data.period;
                        search.empId = data.empId;
                        DefaultAccountsList a_list = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.GetDefaultAccounts(search);

                        return Json(new { isInserted = true, success = true, message = "Account Created Successfully!", list = a_list.defaultAccountsList }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = true, success = false, message = "Error While Creating Account!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public ActionResult CreateChartofAccounts(string period, int branch)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    int inserted = BusinessLogicLayer.Accounts.Accounting.DefaultAccounts.CreateChartofAccounts(period, branch,  empId);

                    if (inserted > 0)
                    {
                        ReportFilters search = new ReportFilters();
                        
                        return Json(new { isInserted = inserted, success = true, message = "Chart of Account Created Successfully!"}, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = inserted, success = false, message = "Error While Creating Chart of Account!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = 0, success = false, message = "Sorry you are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
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