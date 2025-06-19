using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Accounts.MaterialManagementReports
{
    public class Reports
    {
        #region Stock Expiry Reports
        public static List<ItemsBactch> GetExpiryItemBatches(StockExpiryReportsFilter data)
        {
            DataTable dt = DataAccessLayer.Accounts.MaterialManagementReports.Reports.GetExpiryItemBatches(data);
            List<ItemsBactch> batches = new List<ItemsBactch>();
            foreach (DataRow dr in dt.Rows)
            {
                batches.Add(new ItemsBactch
                {
                    ibId = int.Parse(dr["ibId"].ToString()),
                    ib_item = dr["ib_item"].ToString(),
                    ib_batch = dr["ib_batch"].ToString(),
                    ib_edate = DataValidation.isDateValid(dr["ib_edate"].ToString()),
                    ib_qty = DataValidation.isDecimalValid(dr["ib_qty"].ToString()),
                    ib_grn = dr["ib_grn"].ToString(),
                    ib_date_created = dr["ib_date_created"].ToString(),
                    ib_date_modified = dr["ib_date_modified"].ToString(),
                    ib_uom = dr["ib_uom"].ToString(),
                    ib_qty2 = DataValidation.isDecimalValid(dr["ib_qty2"].ToString()),
                    ib_uom2 = dr["ib_uom2"].ToString(),
                    ib_uom3 = dr["ib_uom3"].ToString(),
                    ib_qty3 = DataValidation.isDecimalValid(dr["ib_qty3"].ToString()),
                    ib_cost = DataValidation.isDecimalValid(dr["ib_cost"].ToString()),
                    ib_sprice = DataValidation.isDecimalValid(dr["ib_sprice"].ToString()),
                    ib_m_factor = DataValidation.isDecimalValid(dr["ib_m_factor"].ToString()),
                    ib_cost2 = DataValidation.isDecimalValid(dr["ib_cost2"].ToString()),
                    ib_sprice2 = DataValidation.isDecimalValid(dr["ib_sprice2"].ToString()),
                    ib_m_factor2 = DataValidation.isDecimalValid(dr["ib_m_factor2"].ToString()),
                    ib_cost3 = DataValidation.isDecimalValid(dr["ib_cost3"].ToString()),
                    ib_sprice3 = DataValidation.isDecimalValid(dr["ib_sprice3"].ToString()),
                    ib_opening_qty = DataValidation.isDecimalValid(dr["ib_opening_qty"].ToString()),
                    ib_opening_qty2 = DataValidation.isDecimalValid(dr["ib_opening_qty2"].ToString()),
                    ib_opening_qty3 = DataValidation.isDecimalValid(dr["ib_opening_qty3"].ToString()),
                    item_amount = (DataValidation.isDecimalValid(dr["ib_qty"].ToString()) * DataValidation.isDecimalValid(dr["ib_cost"].ToString())),
                    madeby_name = dr["madeby_name"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    ib_status = dr["ib_status"].ToString(),
                    ib_opening_date = dr["ib_opening_date"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    sup_name = dr["sup_name"].ToString(),
                    ib_supplier = int.Parse(dr["ib_supplier"].ToString()),
                    ib_madeby = int.Parse(dr["ib_madeby"].ToString()),
                    itemId = int.Parse(dr["itemId"].ToString()),
                });
            }

            return batches;
        }
        #endregion

        #region Available Stock Report
        public static List<Items> GetAvailableQtyItems(StockExpiryReportsFilter data, string type)
        {
            List<BusinessEntities.Accounts.Masters.Items> Itemslist = new List<BusinessEntities.Accounts.Masters.Items>();
            DataTable dt = DataAccessLayer.Accounts.MaterialManagementReports.Reports.GetAvailableQtyItems(data, type);
            foreach (DataRow dr in dt.Rows)
            {
                Itemslist.Add(new BusinessEntities.Accounts.Masters.Items
                {
                    itemId = Convert.ToInt32(dr["itemId"].ToString()),
                    item_code = dr["item_code"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    item_qty = DataValidation.isDecimalValid(dr["item_qty"].ToString()),
                    item_uom = dr["item_uom"].ToString(),
                    item_desc = dr["item_desc"].ToString(),
                    item_status = dr["item_status"].ToString(),
                    item_cost = DataValidation.isDecimalValid(dr["item_cost"].ToString()),
                    item_sprice = DataValidation.isDecimalValid(dr["item_sprice"].ToString()),
                    item_brand = dr["item_brand"].ToString(),
                    item_dosage = dr["item_dosage"].ToString(),
                    item_strength = dr["item_strength"].ToString(),
                    item_branch = int.Parse(dr.IsNull("item_branch") ? "0" : dr["item_branch"].ToString()),
                    item_qty2 = DataValidation.isDecimalValid(dr["item_qty2"].ToString()),
                    item_uom2 = dr["item_uom2"].ToString(),
                    item_m_factor = DataValidation.isDecimalValid(dr["item_m_factor"].ToString()),
                    item_cost2 = DataValidation.isDecimalValid(dr["item_cost2"].ToString()),
                    item_sprice2 = DataValidation.isDecimalValid(dr["item_sprice2"].ToString()),
                    item_vat = DataValidation.isDecimalValid(dr["item_vat"].ToString()),
                    item_qty3 = DataValidation.isDecimalValid(dr["item_qty3"].ToString()),
                    item_uom3 = dr["item_uom3"].ToString(),
                    item_m_factor2 = DataValidation.isDecimalValid(dr["item_m_factor2"].ToString()),
                    item_cost3 = DataValidation.isDecimalValid(dr["item_cost3"].ToString()),
                    item_sprice3 = DataValidation.isDecimalValid(dr["item_sprice3"].ToString()),
                    item_opening_qty = DataValidation.isDecimalValid(dr["item_opening_qty"].ToString()),
                    item_opening_date = (dr.IsNull("item_opening_date") ? " " : (DateTime.Parse(dr["item_opening_date"].ToString()).ToString("dd/MM/yyyy"))),
                    category_name = dr["category_name"].ToString(),
                    branch_name = dr["branch_name"].ToString(),
                    location_name = dr["location_name"].ToString(),
                    item_opening_qty2 = DataValidation.isDecimalValid(dr["item_opening_qty2"].ToString()),
                    item_opening_qty3 = DataValidation.isDecimalValid(dr["item_opening_qty3"].ToString()),
                    item_min_qty = DataValidation.isDecimalValid(dr["item_min_qty"].ToString()),
                    item_max_qty = DataValidation.isDecimalValid(dr["item_max_qty"].ToString()),
                    item_last_purchase_date = DataValidation.isDateValid(dr["item_last_purchase_date"].ToString()),
                    item_last_sold_date = DataValidation.isDateValid(dr["item_last_sold_date"].ToString()),
                    stock_value = (DataValidation.isDecimalValid(dr["item_cost"].ToString())) * (DataValidation.isDecimalValid(dr["item_qty"].ToString()))                    
                });
            }
            return Itemslist;
        }
        #endregion

        #region Supplier Wise Purchase Order Summary Report
        public static List<POSummaryReport> GetSupplierWisePO_Summary(POSummaryReportFilter data)
        {
            List<POSummaryReport> Itemslist = new List<POSummaryReport>();
            DataTable dt = DataAccessLayer.Accounts.MaterialManagementReports.Reports.GetSupplierWisePO_Summary(data);
            foreach (DataRow dr in dt.Rows)
            {
                Itemslist.Add(new POSummaryReport
                {
                    pur_total = DataValidation.isDecimalValid(dr["pur_total"].ToString()),
                    pur_disc_val = DataValidation.isDecimalValid(dr["pur_disc_val"].ToString()),
                    pur_net = DataValidation.isDecimalValid(dr["pur_net"].ToString()),
                    pur_vat = DataValidation.isDecimalValid(dr["pur_vat"].ToString()),
                    pur_netvat = (DataValidation.isDecimalValid(dr["pur_net"].ToString()) + DataValidation.isDecimalValid(dr["pur_vat"].ToString())),
                    sup_name = dr["sup_name"].ToString(),
                    branch_name = dr["branch_name"].ToString()                   
                });
            }
            return Itemslist;
        }
        #endregion
        
        #region Supplier Wise Purchase Invoice Summary Report
        public static List<PurchaseInvocieSummaryReport> GetSupplierWiseInvoiceSummary(POSummaryReportFilter data)
        {
            List<PurchaseInvocieSummaryReport> Itemslist = new List<PurchaseInvocieSummaryReport>();
            DataTable dt = DataAccessLayer.Accounts.MaterialManagementReports.Reports.GetSupplierWiseInvoiceSummary(data);
            foreach (DataRow dr in dt.Rows)
            {
                Itemslist.Add(new PurchaseInvocieSummaryReport
                {
                    pinv_total = DataValidation.isDecimalValid(dr["pinv_total"].ToString()),
                    pinv_disc_value = DataValidation.isDecimalValid(dr["pinv_disc_value"].ToString()),
                    pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString()),
                    pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString()),
                    pinv_netvat = (DataValidation.isDecimalValid(dr["pinv_net"].ToString()) + DataValidation.isDecimalValid(dr["pinv_vat"].ToString())),
                    pinv_paid = DataValidation.isDecimalValid(dr["pinv_paid"].ToString()),
                    pinv_balance = DataValidation.isDecimalValid(dr["pinv_balance"].ToString()),
                    sup_name = dr["sup_name"].ToString(),
                    branch_name = dr["branch_name"].ToString()                   
                });
            }
            return Itemslist;
        }
        #endregion

        #region Item Wise & Batch Wise History Report
        public static List<ItemHistoryReport> GetItemWiseHistoryReport(ItemHistoryReportFilter data)
        {
            List<ItemHistoryReport> Itemslist = new List<ItemHistoryReport>();
            DataTable dt = DataAccessLayer.Accounts.MaterialManagementReports.Reports.GetItemWiseHistoryReport(data);
            foreach (DataRow dr in dt.Rows)
            {
                Itemslist.Add(new ItemHistoryReport
                {
                    itemId = DataValidation.isIntValid(dr["itemId"].ToString()),
                    item_code = dr["item_code"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    ig_group = dr["ig_group"].ToString(),
                    item_qty = DataValidation.isDecimalValid(dr["item_qty"].ToString()),
                    purchase_qty = DataValidation.isDecimalValid(dr["purchase_qty"].ToString()),
                    return_qty = DataValidation.isDecimalValid(dr["return_qty"].ToString()),
                    internal_qty = DataValidation.isDecimalValid(dr["internal_qty"].ToString()),
                    external_qty = DataValidation.isDecimalValid(dr["external_qty"].ToString()) ,
                    adjusted_qty = DataValidation.isDecimalValid(dr["adjusted_qty"].ToString()),
                    transfered_qty = DataValidation.isDecimalValid(dr["transfered_qty"].ToString()),
                    branch_name = dr["branch_name"].ToString()
                });
            }
            return Itemslist;
        }
        public static List<ItemHistoryReport> GetBatchWiseItemHistoryReport(ItemHistoryReportFilter data)
        {
            List<ItemHistoryReport> Itemslist = new List<ItemHistoryReport>();
            DataTable dt = DataAccessLayer.Accounts.MaterialManagementReports.Reports.GetBatchWiseItemHistoryReport(data);
            foreach (DataRow dr in dt.Rows)
            {
                Itemslist.Add(new ItemHistoryReport
                {
                    itemId = DataValidation.isIntValid(dr["itemId"].ToString()),
                    item_code = dr["item_code"].ToString(),
                    item_name = dr["item_name"].ToString(),
                    ig_group = dr["ig_group"].ToString(),
                    item_qty = DataValidation.isDecimalValid(dr["item_qty"].ToString()),
                    purchase_qty = DataValidation.isDecimalValid(dr["purchase_qty"].ToString()),
                    return_qty = DataValidation.isDecimalValid(dr["return_qty"].ToString()),
                    internal_qty = DataValidation.isDecimalValid(dr["internal_qty"].ToString()),
                    external_qty = DataValidation.isDecimalValid(dr["external_qty"].ToString()) ,
                    adjusted_qty = DataValidation.isDecimalValid(dr["adjusted_qty"].ToString()),
                    transfered_qty = DataValidation.isDecimalValid(dr["transfered_qty"].ToString()),
                    branch_name = dr["branch_name"].ToString(),
                    ib_batch = dr["ib_batch"].ToString()
                });
            }
            return Itemslist;
        }

        #endregion
    }
}
