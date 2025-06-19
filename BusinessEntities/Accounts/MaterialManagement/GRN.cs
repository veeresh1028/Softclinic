using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class GRN_and_Items
    {
        public GRN grn { get; set; }
        public List<GRN_ITEMS> grn_items { get; set; }
    }
    public class GRN
    {
        public int prId { get; set; }
        public string pr_code { get; set; }
        public string pr_date { get; set; }
        public int pr_PurchaseOrder { get; set; }
        public int pr_supplier { get; set; }
        public string pr_supplier_inv { get; set; }
        public decimal pr_total { get; set; }
        public decimal pr_discount { get; set; }
        public decimal pr_net { get; set; }
        public decimal pr_vat { get; set; }
        public decimal pr_netvat { get; set; }
        public string pr_status { get; set; }
        public int pr_branch { get; set; }
        public string pr_notes { get; set; }
        public int pr_madeby { get; set; }
        public string purchase_order { get; set; }
        public string supplier_name { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string actionvisible { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string amount_in_words { get; set; }
        public string pr_supplier_inv_date { get; set; }
        public string mode { get; set; }
        public string purchase_orderDate { get; set; }
    }
    public class GRN_ITEMS
    {
        public int pirId { get; set; }
        public int pir_pur_item { get; set; }
        public string pir_dcode { get; set; }
        public string pir_grnno { get; set; }
        public string pir_ddate { get; set; }
        public decimal pir_received { get; set; }
        public string pir_notes { get; set; }
        public int pir_dmadeby { get; set; }
        public string pir_status { get; set; }
        public string pir_edate { get; set; }
        public int pir_purchase { get; set; }
        public string pir_batchno { get; set; }
        public string pir_uom { get; set; }
        public decimal pir_free_qty { get; set; }
        public string pir_idate { get; set; }
        public int pir_branch { get; set; }
        public decimal pir_vat { get; set; }
        public string pir_fuom { get; set; }
        public decimal pir_received_1 { get; set; }
        public string pir_received_1_uom { get; set; }
        public decimal pir_received_2 { get; set; }
        public string pir_received_2_uom { get; set; }
        public decimal pir_received_3 { get; set; }
        public string pir_received_3_uom { get; set; }
        public decimal pir_free_qty_1 { get; set; }
        public string pir_free_qty_1_uom { get; set; }
        public decimal pir_free_qty_2 { get; set; }
        public string pir_free_qty_2_uom { get; set; }
        public decimal pir_free_qty_3 { get; set; }
        public string pir_free_qty_3_uom { get; set; }
        public decimal pir_uprice { get; set; }
        public decimal pir_disc { get; set; }
        public string pir_disc_type { get; set; }
        public decimal pir_disc_val { get; set; }
        public decimal pir_nprice { get; set; }
        public decimal pir_net { get; set; }
        public decimal pir_total { get; set; }
        public decimal pir_netvat { get; set; }
        public string pir_vat_per { get; set; }
        public int pir_piId { get; set; }
        public string pir_freeBatch { get; set; }
        public string pir_freeExpiry { get; set; }
        public string purchase_order { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string actionvisible { get; set; }
        public decimal pir_bqty { get; set; }
        public decimal pir_bqty2 { get; set; }
        public decimal pir_bqty3 { get; set; }
        public string pir_bqty_uom { get; set; }
        public string pir_bqty2_uom { get; set; }
        public string pir_bqty3_uom { get; set; }
        public decimal pir_cost { get; set; }
        public decimal pir_cost2 { get; set; }
        public decimal pir_cost3 { get; set; }
        public decimal pir_sprice { get; set; }
        public decimal pir_sprice2 { get; set; }
        public decimal pir_sprice3 { get; set; }
        public decimal m_factor { get; set; }
        public decimal m_factor2 { get; set; }
        public int piId { get; set; }
        public decimal pi_oqty { get; set; }
        public decimal pi_bqty { get; set; }
        public decimal pi_bqty2 { get; set; }
        public decimal pi_bqty3 { get; set; }
        public string pi_bqty_uom { get; set; }
        public string pi_bqty2_uom { get; set; }
        public string pi_bqty3_uom { get; set; }
        public decimal pi_rqty { get; set; }
        public decimal pi_rqty2 { get; set; }
        public decimal pi_rqty3 { get; set; }
        public decimal pi_freeQty { get; set; }
        public string pi_freeUOM { get; set; }
        public string pi_uom { get; set; }
        public decimal previous_rqty { get; set; }
        public decimal previous_fqty { get; set; }
        public string rQty_status { get; set; }
        public string fQty_status { get; set; }        
    }
    public class GRN_Filters
    {
        public int prId { get; set; }
        public int pr_branch { get; set; }
        public string pr_fdate { get; set; }
        public string pr_tdate { get; set; }
        public string pr_code { get; set; }
        public string order_code { get; set; }
        public string pr_status { get; set; }
        public string pr_supplier { get; set; }        
        public int empId { get; set; }
        public int pirId { get; set; }
    }
}
