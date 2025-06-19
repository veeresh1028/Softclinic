using BusinessEntities;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Dashboard;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        int PageId = (int)Pages.Dashboard;
        // GET: Accounting/Dashboard
        public ActionResult Dashboard()
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
        public JsonResult GetDashboardDetails(Dashboard_filter search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                search.empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.MaterialManagement.Dashboard dbReport = BusinessLogicLayer.Accounts.MaterialManagement.Dashboard.GetDashboardDetail(search);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Account & Material Management Dashboard Reports!"
                });

                var jsonResult = Json(dbReport, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult GetPurchaseInvoicesDetails(Dashboard_filter search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                PurchaseInvoice_Filter filter = new PurchaseInvoice_Filter();
                filter.empId = PageControl.getLoggedinId(); ;
                filter.pinv_fdate = search.from_date;
                filter.pinv_tdate = search.to_date;
                filter.pinv_branch = search.branch;

                List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);
                PurchaseInvoiceList list = new PurchaseInvoiceList();
                list.purchaseInvoiceList = pinvlist;
                list.from_date = search.from_date;
                list.to_date = search.to_date;
                list.branch_name = pinvlist[0].branch_name;

                return PartialView("PurchaseInvoicesView", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        [HttpGet]
        public PartialViewResult GetExpItemsDetails(int days)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {         

                List<BusinessEntities.Accounts.MaterialManagement.ExpItems> itemlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetExpItems(days);
                ItemsExpiry list = new ItemsExpiry();
                list.Exp_Items = itemlist;
                return PartialView("ExpItemsView", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
                
        [HttpGet]
        public PartialViewResult GetPurchaseVATDetails(Dashboard_filter search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                PurchaseInvoice_Filter filter = new PurchaseInvoice_Filter();
                filter.empId = PageControl.getLoggedinId(); ;
                filter.pinv_fdate = search.from_date;
                filter.pinv_tdate = search.to_date;
                filter.pinv_branch = search.branch;

                List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);
                PurchaseInvoiceList list = new PurchaseInvoiceList();
                list.purchaseInvoiceList = pinvlist;
                list.from_date = search.from_date;
                list.to_date = search.to_date;
                list.branch_name = pinvlist[0].branch_name;

                return PartialView("PurchaseVATView", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
                
        [HttpGet]
        public PartialViewResult GetPurchaseBalanceDetails(Dashboard_filter search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                PurchaseInvoice_Filter filter = new PurchaseInvoice_Filter();
                filter.empId = PageControl.getLoggedinId(); ;
                filter.pinv_fdate = search.from_date;
                filter.pinv_tdate = search.to_date;
                filter.pinv_branch = search.branch;

                List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);
                PurchaseInvoiceList list = new PurchaseInvoiceList();
                list.purchaseInvoiceList = pinvlist;
                list.from_date = search.from_date;
                list.to_date = search.to_date;
                list.branch_name = pinvlist[0].branch_name;

                return PartialView("PurchaseBalanceView", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
           
        [HttpGet]
        public PartialViewResult GetPurchasePaymentDetails(Dashboard_filter search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                PaymentFilter filter = new PaymentFilter();
                filter.empId = PageControl.getLoggedinId(); ;
                filter.from_date = search.from_date;
                filter.to_date = search.to_date;
                filter.pay_branch = search.branch;
                filter.pay_type = "Invoice";                
                List<Payment> paylist = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter);

                PaymentList list = new PaymentList();
                list.paymentList = paylist;
                list.from_date = search.from_date;
                list.to_date = search.to_date;
                list.branch_name = paylist[0].branch_name;

                return PartialView("PurchasePaymentView", list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
         
        [HttpGet]
        public PartialViewResult GetAdvancePaymentDetails(Dashboard_filter search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                PaymentFilter filter = new PaymentFilter();
                filter.empId = PageControl.getLoggedinId(); ;
                filter.from_date = search.from_date;
                filter.to_date = search.to_date;
                filter.pay_branch = search.branch;
                filter.pay_type = "Advance,Refund";   
                
                List<Payment> paylist = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter);

                PaymentList list = new PaymentList();
                list.paymentList = paylist;
                list.from_date = search.from_date;
                list.to_date = search.to_date;
                list.branch_name = paylist[0].branch_name;

                return PartialView("PurchasePaymentView", list);
            }
            else
            {
                return PartialView("_Unauthorized");
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