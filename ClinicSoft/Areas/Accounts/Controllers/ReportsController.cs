using BusinessEntities.Accounts.Accounting;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Google.Type;
using BusinessEntities.Appointment;
using BusinessEntities.Accounts.MaterialManagement;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        int PageId = (int)Pages.ChartOfAccounts;

        #region Profit & Loss Report
        public ActionResult ProfitLossReport()
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
        public JsonResult GetProfitLossReport(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    decimal income_total = 0;
                    decimal expenses_total = 0;


                    List<BusinessEntities.Accounts.Accounting.AccountReports> pl_list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetProfitLossReport(data, out income_total, out expenses_total);

                    return Json(new { isAuthorized = true, credit_total = income_total, debit_total = expenses_total, pl_list }, JsonRequestBehavior.AllowGet);
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

        public ActionResult ProfitLossReportSummary()
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
        public JsonResult GetProfitLossSummaryReport(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    decimal income_total = 0;
                    decimal expenses_total = 0;


                    List<BusinessEntities.Accounts.Accounting.AccountReports> pl_list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetProfitLossSummaryReport(data, out income_total, out expenses_total);

                    return Json(new { isAuthorized = true, credit_total = income_total, debit_total = expenses_total, pl_list }, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Balance Sheet Report
        public ActionResult BalanceSheetReport()
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
        public JsonResult GetBalanceSheetReport(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    decimal as_total = 0;
                    decimal li_total = 0;
                    decimal eq_total = 0;


                    List<BusinessEntities.Accounts.Accounting.AccountReports> pl_list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetBalanceSheetReport(data, out as_total, out li_total, out eq_total);

                    return Json(new { isAuthorized = true, asset_total = as_total, liabilities_total = li_total, equity_total = eq_total, pl_list }, JsonRequestBehavior.AllowGet);
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

        public ActionResult BalanceSheetReportSummary()
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
        public JsonResult GetBalanceSheetSummaryReport(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    decimal as_total = 0;
                    decimal li_total = 0;
                    decimal eq_total = 0;


                    List<BusinessEntities.Accounts.Accounting.AccountReports> pl_list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetBalanceSheetSummaryReport(data, out as_total, out li_total, out eq_total);

                    return Json(new { isAuthorized = true, asset_total = as_total, liabilities_total = li_total, equity_total = eq_total, pl_list }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Cash Flow Statement
        public ActionResult CashFlowStatement()
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
        public JsonResult GetCashFlowStatement(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();
                    decimal _total = 0;
                    List<BusinessEntities.Accounts.Accounting.AccountReports> pl_list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetCashFlowStatement(data, out _total);

                    return Json(new { isAuthorized = true, total = _total, pl_list }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Trial Balance
        public ActionResult TrialBalance()
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
        public JsonResult GetTrialBalanceDetail(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();
                    decimal _total = 0;
                    List<BusinessEntities.Accounts.Accounting.AccountReports> pl_list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetTrialBalanceDetail(data, out _total);

                    return Json(new { isAuthorized = true, total = _total, pl_list }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Account Reconciliations
        public ActionResult AccountReconciliation()
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
        public JsonResult GetAccountReconciliationDetail(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.AccountReconciliation> pl_list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetAccountReconciliationDetail(data);

                    return Json(new { isAuthorized = true, pl_list }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult ReconcilAccountTranansaction(string data, string status, string date)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated = BusinessLogicLayer.Accounts.Accounting.AccountReports.ReconcilAccountTranansaction(data, status, date, empId);
                    if (isUpdated)
                    {
                        return Json(new { isUpdated = true, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = "Error While Status Updating!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Supplier Age Analysis
        public ActionResult SupplierAgeAnalysis()
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
        public JsonResult GetSupplierAgeAnalysis(int branch, string date)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.AgeAnalysis> _list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetSupplierAgeAnalysis(branch, empId, date);

                    return Json(new { isAuthorized = true, _list }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Patient Age Analysis
        public ActionResult PatientAgeAnalysis()
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
        public JsonResult GetPatientAgeAnalysis(int branch, string date)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.AgeAnalysis> _list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetPatientAgeAnalysis(branch, empId, date);

                    return Json(new { isAuthorized = true, _list }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Insurance Age Analysis
        public ActionResult InsuranceAgeAnalysis()
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
        public JsonResult GetInsuranceAgeAnalysis(int branch, string date)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.AgeAnalysis> _list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.GetInsuranceAgeAnalysis(branch, empId, date);

                    return Json(new { isAuthorized = true, _list }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Account VAT Report

        public ActionResult AccountVATReport()
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
        public JsonResult getAccountVATDetail(ReportFilters data)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.AccountVAT> pl_list =
                        BusinessLogicLayer.Accounts.Accounting.AccountReports.getAccountVATDetail(data);

                    return Json(new { isAuthorized = true, pl_list }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult GenerateAccountVATReport(ReportFilters data)
        {
            try
            {
                int isGenerated = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();
                    isGenerated = BusinessLogicLayer.Accounts.Accounting.AccountReports.GenerateAccountVATReport(data);
                    if (isGenerated > 0)
                    {
                        return Json(new { isGenerated = true, message = "Report is Generated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isGenerated == -1)
                    {
                        return Json(new { isGenerated = false, message = "No record found for Invoices and Purchases!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isGenerated = false, message = "Error While Generating Report!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isGenerated = false, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isGenerated = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ChangeAccountVATReportStatus(string data, string status, string date)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.Accounting.AccountReports.ChangeAccountVATReportStatus(data, status, date, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Report Already Subbmitted or Deleted Status" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Updating Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = -3, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult SalesInvoiceVATDetail(int branch, string date_from, string date_to)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<VAT_Report_detail> list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetSalesInvoiceVATDetail(branch, date_from, date_to);
                return PartialView("SalesInvoiceVATDetail", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        [HttpGet]
        public PartialViewResult SalesReturnVATDetail(int branch, string date_from, string date_to)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<VAT_Report_detail> list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetSalesReturnVATDetail(branch, date_from, date_to);
                return PartialView("SalesReturnVATDetail", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        [HttpGet]
        public PartialViewResult PurchaseInvoiceVATDetail(int branch, string date_from, string date_to)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<VAT_Report_detail> list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetPurchaseInvoiceVATDetail(branch, date_from, date_to);
                return PartialView("PurchaseInvoiceVATDetail", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }


        [HttpGet]
        public PartialViewResult PurchaseReturnVATDetail(int branch, string date_from, string date_to)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<VAT_Report_detail> list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetPurchaseReturnVATDetail(branch, date_from, date_to);
                return PartialView("PurchaseReturnVATDetail", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Print Account VAT Report
        [HttpGet]
        public ActionResult PrintAccountVAT_Report(int avrId)
        {
            int Action = (int)Actions.Read;
            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    ReportFilters filter = new ReportFilters();
                    filter.avrId = avrId;
                    filter.empId = PageControl.getLoggedinId();

                    BusinessEntities.Accounts.Accounting.AccountVAT pl_list = BusinessLogicLayer.Accounts.Accounting.AccountReports.getAccountVATDetail(filter).FirstOrDefault();
                   
                    return View("PrintAccountVAT_Report", pl_list);
                    // return Json(new { isAuthorized = true, pl_list }, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Statement of Account
        public ActionResult StatementOfAccount()
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
        public ActionResult GetAccountsDropdown(LoadAccounts data)
        {
            try
            {

                List<CommonDDLFORMS> dt = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetAccountsDropdown(data);

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
        public JsonResult GetStatementOfAccounts(ChartOfAccountsSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();
                    decimal balance = 0;
                    List<BusinessEntities.Accounts.Accounting.Transaction> list = BusinessLogicLayer.Accounts.Accounting.AccountReports.GetStatementOfAccounts(data, out balance);

                    return Json(new { isAuthorized = true, _balance = balance, list }, JsonRequestBehavior.AllowGet);
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


        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}