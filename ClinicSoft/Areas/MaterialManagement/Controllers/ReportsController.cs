using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Accounts.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        int PageId_ExpiryStock = (int)Pages.StockExpiryReport;
        int PageId_AvaliableStock = (int)Pages.StockAvailableReport;
        int PageId_OutofStock = (int)Pages.OutofStockItemsReport;
        int PageId_PendingPO = (int)Pages.PendingPurchaseOrdersReport;
        int PageId_POSummary = (int)Pages.PurchaseOrdersSummaryReport;
        int PageId_PINVSummary = (int)Pages.PurchaseInvoicesSummaryReport;
        int PageId_StockConsumed = (int)Pages.StockItemsConsumptionsReport;

        #region Stock Expiry Report
        public ActionResult StockExpiryReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_ExpiryStock, Action))
            {                
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["ItemGroupList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["ItemLocationList"] = ItemLocationList;
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetExpiryItemBatches(StockExpiryReportsFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_ExpiryStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<ItemsBactch> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetExpiryItemBatches(data);
                
                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Available Stock Report
        public ActionResult AvaliableStockQtyReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AvaliableStock, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["ItemGroupList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["ItemLocationList"] = ItemLocationList;
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetAvailableQtyItems(StockExpiryReportsFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_AvaliableStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetAvailableQtyItems(data, "instock");

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        
        #region Out Of Stock Report
        public ActionResult OutofStockQtyReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_OutofStock, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["ItemGroupList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["ItemLocationList"] = ItemLocationList;
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetOutofStockItems(StockExpiryReportsFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_OutofStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetAvailableQtyItems(data, "outstock");

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Pending Purchase Orders Report
        public ActionResult PurchaseOrderPendingReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PendingPO, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["ItemGroupList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["ItemLocationList"] = ItemLocationList;
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetPendingPurchaseOrders(StockExpiryReportsFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_PendingPO, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetAvailableQtyItems(data, "outstock");

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetPurchaseOrders(PurchaseOrderFilters filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_ExpiryStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                filter.pur_status = "New,Partly Delivered";
                if (!string.IsNullOrEmpty(filter.from_date) && !string.IsNullOrEmpty(filter.to_date))
                {
                    filter.from_date = DateTime.Parse(filter.from_date).ToString("MM/dd/yyyy");
                    filter.to_date = DateTime.Parse(filter.to_date).ToString("MM/dd/yyyy");
                }
                List<PurchaseOrders> purchaseOrderslist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrders(filter);

                var jsonResult = Json(purchaseOrderslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Supplier Wise Purchase Order Summary Report
        public ActionResult SupplierWisePOSummaryReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_POSummary, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetSupplierWisePO_Summary(POSummaryReportFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_POSummary, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<POSummaryReport> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetSupplierWisePO_Summary(data);

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        
        #endregion
        
        #region Supplier Wise Purchase Invoice Summary Report
        public ActionResult SupplierWiseInvoiceSummaryReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_PINVSummary, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetSupplierWiseInvoiceSummary(POSummaryReportFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_PINVSummary, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<PurchaseInvocieSummaryReport> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetSupplierWiseInvoiceSummary(data);

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        
        #endregion
        
        #region Stock Consumption Report
        public ActionResult StockComsumptionReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetConsumedStockItems(POSummaryReportFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<PurchaseInvocieSummaryReport> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetSupplierWiseInvoiceSummary(data);

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Internal Stock Transfer Report
        public ActionResult InternalStockTransferReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion
        
        #region Item Wise History Report
        public ActionResult ItemWiseReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetItemWiseHistoryReport(ItemHistoryReportFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<ItemHistoryReport> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetItemWiseHistoryReport(data);

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Batch Wise Item History Report
        public ActionResult BatchWiseItemReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetBatchWiseItemHistoryReport(ItemHistoryReportFilter data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_StockConsumed, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<ItemHistoryReport> Itemslist = BusinessLogicLayer.Accounts.MaterialManagementReports.Reports.GetBatchWiseItemHistoryReport(data);

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
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