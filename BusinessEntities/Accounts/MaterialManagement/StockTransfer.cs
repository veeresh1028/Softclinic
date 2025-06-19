using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class DirectStockTransferList
    {
        public List<DirectStockTransfer> directStockTransferList { get; set; }
    }
    public class DirectStockTransfer
    {
        public int stdId { get; set; }
        public string std_refno { get; set; }
        public string std_date { get; set; }
        public int std_from_branch { get; set; }
        public int std_to_branch { get; set; }
        public int std_itemId { get; set; }
        public int std_ibId { get; set; }
        public decimal std_oqty { get; set; }
        public string std_item_code { get; set; }
        public string std_ouom { get; set; }
        public string std_item_batch { get; set; }
        public string std_item_expiry { get; set; }
        public decimal std_item_qty { get; set; }
        public string std_item_uom { get; set; }
        public decimal std_item_qty2 { get; set; }
        public string std_item_uom2 { get; set; }
        public decimal std_item_qty3 { get; set; }
        public string std_item_uom3 { get; set; }
        public decimal std_item_mfactor { get; set; }
        public decimal std_item_mfactor2 { get; set; }
        public decimal std_item_sprice { get; set; }
        public decimal std_item_sprice2 { get; set; }
        public decimal std_item_sprice3 { get; set; }
        public decimal std_item_cost { get; set; }
        public decimal std_item_cost2 { get; set; }
        public decimal std_item_cost3 { get; set; }
        public decimal std_rqty { get; set; }
        public decimal std_rqty2 { get; set; }
        public decimal std_rqty3 { get; set; }
        public string std_status { get; set; }
        public string std_status2 { get; set; }
        public string std_notes { get; set; }
        public int std_createdby { get; set; }
        public string madeby { get; set; }
        public string from_branch_name { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public string to_branch_name { get; set; }
        public string item_name { get; set; }
        public decimal ib_qty { get; set; }
        public decimal ib_qty2 { get; set; }
        public decimal ib_qty3 { get; set; }

    }
    public class DirectStockTransferFilter
    {
        public int stdId { get; set; }
        public string std_refno { get; set; }
        public int std_from_branch { get; set; }
        public int std_to_branch { get; set; }
        public string std_status { get; set; }
        public string item_code { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }
    }


    public class StockTransferRequest
    {
        public int strId { get; set; }
        public string str_refno { get; set; }
        public string str_date { get; set; }
        public int str_request_branch { get; set; }
        public int str_from_branch { get; set; }
        public int str_itemId { get; set; }
        public int str_ibId { get; set; }
        public decimal str_oqty { get; set; }
        public string str_item_code { get; set; }
        public string str_ouom { get; set; }
        public string str_item_batch { get; set; }
        public string str_item_expiry { get; set; }
        public decimal str_item_qty { get; set; }
        public string str_item_uom { get; set; }
        public decimal str_item_qty2 { get; set; }
        public string str_item_uom2 { get; set; }
        public decimal str_item_qty3 { get; set; }
        public string str_item_uom3 { get; set; }
        public decimal str_item_mfactor { get; set; }
        public decimal str_item_mfactor2 { get; set; }
        public decimal str_item_sprice { get; set; }
        public decimal str_item_sprice2 { get; set; }
        public decimal str_item_sprice3 { get; set; }
        public decimal str_item_cost { get; set; }
        public decimal str_item_cost2 { get; set; }
        public decimal str_item_cost3 { get; set; }
        public decimal str_rqty { get; set; }
        public decimal str_rqty2 { get; set; }
        public decimal str_rqty3 { get; set; }
        public string str_status { get; set; }
        public string str_status2 { get; set; }
        public string str_notes { get; set; }
        public int str_createdby { get; set; }
        public string madeby { get; set; }
        public string requested_branch_name { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public string from_branch_name { get; set; }
        public string item_name { get; set; }
        public decimal ib_qty { get; set; }
        public decimal ib_qty2 { get; set; }
        public decimal ib_qty3 { get; set; }

    }
    public class BatchAllocation
    {
        public int strId { get; set; }
        public int str_itemId { get; set; }
        public string str_date { get; set; }
        public string str_refno { get; set; }
        public int str_request_branch { get; set; }
        public string str_item_code { get; set; }
        public int str_ibId { get; set; }
        public decimal str_qty { get; set; }
        public decimal str_qty2 { get; set; }
        public decimal str_qty3 { get; set; }
        public string str_item_batch { get; set; }
        public string str_item_expiry { get; set; }
        public int empId { get; set; }
    }


        public class StockTransferRequestList
    {
        public List<StockTransferRequest> stockTransferRequestList { get; set; }
    }
}
