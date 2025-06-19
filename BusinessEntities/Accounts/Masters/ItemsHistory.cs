using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Masters
{
    public class ItemsHistory
    {
        public ItemsHistoryDetail itemsHistoryDetail = new ItemsHistoryDetail();
        public List<PurcaseItemsReceived> purcaseItemsReceiveds = new List<PurcaseItemsReceived>();
        public List<TreatmentItemsUsed> treatmentItemsUsed = new List<TreatmentItemsUsed>();
        public List<ItemsQtyAdjusted> itemsQtyAdjusted = new List<ItemsQtyAdjusted>();
        public List<ItemsQtyAllocated> itemsQtyAllocated = new List<ItemsQtyAllocated>();
        public List<ItemConsuptionHistory> itemConsuptionHistory = new List<ItemConsuptionHistory>();
        public List<ItemDirectTransfer> itemDirectTransfer = new List<ItemDirectTransfer>();
        public List<ItemBatchDetail> itemBatchDetail = new List<ItemBatchDetail>();
    }
    public class ItemsHistoryDetail
    {
        public int itemId { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string branch_name { get; set; }
    }
    public class PurcaseItemsReceived
    {
        public int pirId { get; set; }
        public string sup_name { get; set; }
        public string pir_ddate { get; set; }
        public string pir_edate { get; set; }
        public string pir_grnno { get; set; }
        public string pur_ocode { get; set; }
        public string pir_dcode { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string pir_batchno { get; set; }
        public decimal pi_uprice { get; set; }
        public string pir_received { get; set; }
        public string pi_oqty { get; set; }
        public decimal pi_uprice2 { get; set; }
    }
    public class TreatmentItemsUsed
    {
        public int titId { get; set; }
        public decimal tit_qty { get; set; }
        public string item_exp_date { get; set; }
        public string item2_uom { get; set; }
        public string item2_name { get; set; }
        public string tit_notes { get; set; }
        public decimal tit_cost { get; set; }
        public string tit_item { get; set; }
        public string tr_name { get; set; }
        public string app_fdate { get; set; }
        public string emp_name { get; set; }
        public string tr_code { get; set; }
    }
    public class ItemsQtyAdjusted
    {
        public int iqaId { get; set; }
        public string iqa_date { get; set; }
        public string item_code { get; set; }
        public string item_type { get; set; }
        public string item_location { get; set; }
        public string ig_group { get; set; }
        public decimal iqa_qty { get; set; }
        public decimal iqa_adj { get; set; }
        public string iqa_notes { get; set; }
        public string iqa_by_name { get; set; }
    }
    public class ItemsQtyAllocated
    {
        public int ia1Id { get; set; }
        public string ia1_batchno { get; set; }
        public string ia1_edate { get; set; }
        public string ia1_date { get; set; }
        public string ia1_from_name2 { get; set; }
        public string ia1_refno { get; set; }
        public string item1_code { get; set; }
        public string item1_name { get; set; }
        public decimal ia1_aqty { get; set; }
        public decimal ia1_aqty_cost { get; set; }
        public string ia1_aqty_uom { get; set; }
        public string ia1_notes { get; set; }
        public string ia1_status { get; set; }
        public string ia1_madeby_name { get; set; }
    }

    public class ItemConsuptionHistory
    {
        public string scr_refno { get; set; }
        public string set_company { get; set; }
        public string ib_batch { get; set; }
        public string scr_date { get; set; }
        public string doctor_name { get; set; }
        public string room { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string madeby_name { get; set; }
        public decimal scr_qty { get; set; }
        public string scr_uom { get; set; }
        public string scr_desc { get; set; }
        public decimal qty_cost { get; set; }
    }

    public class ItemDirectTransfer
    {
        public string std_refno { get; set; }
        public string std_date { get; set; }
        public string from_branch { get; set; }
        public string to_branch { get; set; }
        public string std_item_batch { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string madeby_name { get; set; }
        public decimal std_oqty { get; set; }
        public string std_ouom { get; set; }
        public string std_notes { get; set; }
        public decimal qty_cost { get; set; }
    }

    public class ItemBatchDetail
    {
        public string ib_item { get; set; }
        public string ib_batch { get; set; }
        public string ib_edate { get; set; }
        public decimal ib_qty { get; set; }
        public string ib_grn { get; set; }
        public string ib_uom { get; set; }
        public decimal ib_cost { get; set; }
        public decimal ib_sprice { get; set; }
    }

}
