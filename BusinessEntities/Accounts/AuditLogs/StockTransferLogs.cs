using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class DirectStockTransferLogsList
    {
        public List<DirectStockTransferLogs> directStockTransferLogsList { get; set; }
    }
    public class DirectStockTransferLogs
    {
        public int stda_stdId { get; set; }
        public string stda_refno { get; set; }
        public string stda_date { get; set; }
        public int stda_from_branch { get; set; }
        public int stda_to_branch { get; set; }
        public int stda_itemId { get; set; }
        public int stda_ibId { get; set; }
        public decimal stda_oqty { get; set; }
        public string stda_item_code { get; set; }
        public string stda_ouom { get; set; }
        public string stda_item_batch { get; set; }
        public string stda_item_expiry { get; set; }
        public decimal stda_item_qty { get; set; }
        public string stda_item_uom { get; set; }
        public decimal stda_item_qty2 { get; set; }
        public string stda_item_uom2 { get; set; }
        public decimal stda_item_qty3 { get; set; }
        public string stda_item_uom3 { get; set; }
        public decimal stda_item_mfactor { get; set; }
        public decimal stda_item_mfactor2 { get; set; }
        public decimal stda_item_sprice { get; set; }
        public decimal stda_item_sprice2 { get; set; }
        public decimal stda_item_sprice3 { get; set; }
        public decimal stda_item_cost { get; set; }
        public decimal stda_item_cost2 { get; set; }
        public decimal stda_item_cost3 { get; set; }
        public decimal stda_rqty { get; set; }
        public decimal stda_rqty2 { get; set; }
        public decimal stda_rqty3 { get; set; }
        public string stda_status { get; set; }
        public string stda_notes { get; set; }
        public int stda_createdby { get; set; }
        public string madeby { get; set; }
        public string from_branch_name { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public string to_branch_name { get; set; }
        public string item_name { get; set; }
        public string stda_operation { get; set; }
        public string stda_date_created { get; set; }

    }

    public class StockTransferRequestLogsList
    {
        public List<StockTransferRequestLogs> stockTransferRequestLogsList { get; set; }
    }
    public class StockTransferRequestLogs
    {
        public int stra_strId { get; set; }
        public string stra_refno { get; set; }
        public string stra_date { get; set; }
        public int stra_from_branch { get; set; }
        public int stra_request_branch { get; set; }
        public int stra_itemId { get; set; }
        public int stra_ibId { get; set; }
        public decimal stra_oqty { get; set; }
        public string stra_item_code { get; set; }
        public string stra_ouom { get; set; }
        public string stra_item_batch { get; set; }
        public string stra_item_expiry { get; set; }
        public decimal stra_item_qty { get; set; }
        public string stra_item_uom { get; set; }
        public decimal stra_item_qty2 { get; set; }
        public string stra_item_uom2 { get; set; }
        public decimal stra_item_qty3 { get; set; }
        public string stra_item_uom3 { get; set; }
        public decimal stra_item_mfactor { get; set; }
        public decimal stra_item_mfactor2 { get; set; }
        public decimal stra_item_sprice { get; set; }
        public decimal stra_item_sprice2 { get; set; }
        public decimal stra_item_sprice3 { get; set; }
        public decimal stra_item_cost { get; set; }
        public decimal stra_item_cost2 { get; set; }
        public decimal stra_item_cost3 { get; set; }
        public decimal stra_rqty { get; set; }
        public decimal stra_rqty2 { get; set; }
        public decimal stra_rqty3 { get; set; }
        public string stra_status { get; set; }
        public string stra_notes { get; set; }
        public int stra_createdby { get; set; }
        public string madeby { get; set; }
        public string from_branch_name { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public string requested_branch_name { get; set; }
        public string item_name { get; set; }
        public string stra_operation { get; set; }
        public string stra_date_created { get; set; }

    }
}
