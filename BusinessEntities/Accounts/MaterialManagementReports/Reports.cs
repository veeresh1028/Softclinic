using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Reports
{
    public class StockExpiryReportsFilter
    {        
        public string item_name_code { get; set; }
        public string item_type { get; set; }
        public string item_category { get; set; }
        public string item_brand { get; set; }
        public string item_location { get; set; }
        public string item_branch { get; set; }
        public string expiry_fdate { get; set; }
        public string expiry_tdate { get; set; }
        public int empId { get; set; }
    }

    public class POSummaryReportFilter
    {
        public string pur_branch { get; set; }
        public string pur_supplier { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }
    }
    public class POSummaryReport
    {
        public decimal pur_total { get; set; }
        public decimal pur_disc_val { get; set; }
        public decimal pur_net { get; set; }
        public decimal pur_vat { get; set; }
        public decimal pur_netvat { get; set; }
        public string sup_name { get; set; }
        public string branch_name { get; set; }
    }
    public class PurchaseInvocieSummaryReport
    {
        public decimal pinv_total { get; set; }
        public decimal pinv_disc_value { get; set; }
        public decimal pinv_net { get; set; }
        public decimal pinv_vat { get; set; }
        public decimal pinv_netvat { get; set; }
        public decimal pinv_paid { get; set; }
        public decimal pinv_balance { get; set; }
        public string sup_name { get; set; }
        public string branch_name { get; set; }
    }
    public class ItemHistoryReport
    {
        public int itemId { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public decimal item_qty { get; set; }
        public string ig_group { get; set; }
        public string branch_name { get; set; }
        public decimal purchase_qty { get; set; }
        public decimal return_qty { get; set; }
        public decimal internal_qty { get; set; }
        public decimal external_qty { get; set; }
        public decimal adjusted_qty { get; set; }
        public decimal transfered_qty { get; set; }
        public string ib_batch { get; set; }
       
    }

    public class ItemHistoryReportFilter
    {
        public string branch { get; set; }
        public string item_name { get; set; }
        public int empId { get; set; }
    }

}
