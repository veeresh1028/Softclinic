using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class StockQtyAdjustment_List
    {
        public List<StockQtyAdjustment> stockQtyAdjustment_list { get; set; }
    }
    public class StockQtyAdjustment
    {
        public int iqaId { get; set; }
        public string iqa_date { get; set; }
        public int iqa_item { get; set; }
        public decimal iqa_qty { get; set; }
        public decimal iqa_adj { get; set; }
        public int iqa_by { get; set; }
        public string iqa_notes { get; set; }
        public decimal iqa_uprice { get; set; }
        public string iqa_account { get; set; }
        public string iqa_uom { get; set; }
        public decimal iqa_qty_1 { get; set; }
        public decimal iqa_qty_2 { get; set; }
        public decimal iqa_qty_3 { get; set; }
        public string iqa_uom_1 { get; set; }
        public string iqa_uom_2 { get; set; }
        public string iqa_uom_3 { get; set; }
        public decimal iqa_net { get; set; }
        public int iqa_modifiedby { get; set; }
        public int iqa_branch { get; set; }
        public decimal iqa_old_qty { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string madeby { get; set; }
        public string branch_name { get; set; }
        public int ibId { get; set; }
        public string ib_edate { get; set; }
        public string ib_batch { get; set; }
        public string account_name { get; set; }
    }

    public class StockQtyAdjustment_filter
    {
        public int iqa_branch { get; set; }
        public string item_code { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public int empId { get; set; }
    }
    public class AdjustmentDDL
    {
        public string id { get; set; }
        public string text { get; set; }
        public string name { get; set; }
        public string itemId { get; set; }
    }

   
}
