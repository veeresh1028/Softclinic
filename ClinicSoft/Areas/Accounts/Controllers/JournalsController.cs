using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.MaterialManagement;
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
    public class JournalsController : Controller
    {
        int PageId = (int)Pages.Journals;

        [HttpGet]
        public ActionResult Journals()
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
        public JsonResult GetJournalPostings(JournalSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.Journals> J_list = BusinessLogicLayer.Accounts.Accounting.Journals.GetJournals(data);

                    return Json(new { isAuthorized = true, message = "", J_list }, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetReferrenceNo(JournalReferrenceNo data)
        {
            try
            {
                string j_code = BusinessLogicLayer.Accounts.Accounting.Journals.GetReferrenceNo(data);

                return Json(new { j_code }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult CreateJournal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    BusinessEntities.Accounts.Accounting.Journals jl = new BusinessEntities.Accounts.Accounting.Journals();
                    jl.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    jl.j_branch = Convert.ToInt32(emp_branch);
                    jl.PeriodList = BusinessLogicLayer.Accounts.Accounting.AccountPeriod.GetOpenAccountPeriod();

                    return PartialView("CreateJournal", jl);
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
        public ActionResult InsertJournals(JournalWithList data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.journalHeader.j_madeby = PageControl.getLoggedinId();
                                        
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Accounts.isValidJournals(data, out errors))
                    {
                        string j_code;
                        isInserted = BusinessLogicLayer.Accounts.Accounting.Journals.InsertJournals(data, out j_code);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Journal Entries Posted Successfully!", jc_Id = 0 }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Posting Journal Entries!", pojc_IdrId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Not Authorized To Perform This Action!", jc_Id = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage_Insert"] = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditJournal(string j_refno)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                JournalSearch search = new JournalSearch();
                search.select_refno = j_refno;
                search.empId = empId;

                JournalWithList _list = BusinessLogicLayer.Accounts.Accounting.Journals.GetJournalsEdit(search);

                return View("EditJournal", _list);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult ChangeJournalsStatus(string j_refno, string status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.Journals.ChangeJournalsStatus(j_refno, status, empId);

                    if (ischanged > 0)
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Journal Entry Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateJournals(JournalWithList data, string deleteIds)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.journalHeader.j_madeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Accounts.isValidJournals(data, out errors))
                    {
                        string j_code;
                        isUpdated = BusinessLogicLayer.Accounts.Accounting.Journals.UpdateJournals(data, out j_code, deleteIds);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Journal Entries Posted Successfully!", jc_Id = 0 }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Posting Journal Entries!", pojc_IdrId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = "Not Authorized To Perform This Action!", jc_Id = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage_Insert"] = ex.Message;
            }

            return View();
        }

        [HttpGet]
        public PartialViewResult JournalAuditLogs(string j_refno)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<JournalAudit> _logsList = BusinessLogicLayer.Accounts.Accounting.Journals.GetJournalAuditLogs(j_refno, empId);

                    return PartialView("JournaAuditLogs", _logsList);
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