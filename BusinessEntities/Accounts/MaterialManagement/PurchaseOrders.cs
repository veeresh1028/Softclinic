using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class PurchaseOrderAndItems
    {
        public PurchaseOrders purchaseOrders { get; set; }
        public List<PurchaseOrderItems> purchaseItems { get; set; }
    }

    public class PurchaseOrders
    {
        public int purId { get; set; }
        public int pur_supplier { get; set; }
        public string pur_ocode { get; set; }
        public string pur_odate { get; set; }
        public string pur_account { get; set; }
        public decimal pur_total { get; set; }
        public decimal pur_disc { get; set; }
        public string pur_disc_type { get; set; }
        public decimal pur_disc_val { get; set; }
        public decimal pur_net { get; set; }
        public decimal pur_netvat { get; set; }
        public string pur_notes { get; set; }
        public string pur_status { get; set; }
        public int pur_omadeby { get; set; }
        public string pur_type { get; set; }
        public string pur_enqno { get; set; }
        public string pur_quono { get; set; }
        public int pur_validity { get; set; }
        public int pur_pay_terms { get; set; }
        public string pur_qdate { get; set; }
        public string pur_ship_1 { get; set; }
        public string pur_ship_2 { get; set; }
        public string pur_ship_3 { get; set; }
        public string pur_ship_4 { get; set; }
        public string pur_bill_1 { get; set; }
        public string pur_bill_2 { get; set; }
        public string pur_bill_3 { get; set; }
        public string pur_bill_4 { get; set; }
        public string pur_buy_1 { get; set; }
        public string pur_buy_2 { get; set; }
        public string pur_buy_3 { get; set; }
        public string pur_buy_4 { get; set; }
        public int pur_branch { get; set; }
        public decimal pur_vat { get; set; }
        public decimal pur_idisc { get; set; }
        public string sup_name { get; set; }
        public string sup_tel { get; set; }
        public string sup_mob { get; set; }
        public string sup_email { get; set; }
        public string sup_account { get; set; }
        public string sup_code { get; set; }
        public string sup_vat_regno { get; set; }
        public string pur_sup_invoice { get; set; }
        public string branch_name { get; set; }
        public string madeby_name { get; set; }
        public string actionvisible { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public string sup_address { get; set; }
        public string amount_in_words { get; set; }
        public int empId { get; set; }
    }

    public class PurchaseOrderItems
    {
        public int piId { get; set; }
        public int pi_purchase { get; set; }
        public int pi_item { get; set; }
        public string pi_mode { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string pi_desc { get; set; }
        public string pi_edate { get; set; }
        public decimal pi_oqty { get; set; }
        public string pi_uom { get; set; }
        public decimal pi_uprice { get; set; }
        public decimal pi_disc { get; set; }
        public string pi_disc_type { get; set; }
        public decimal pi_nprice { get; set; }
        public string pi_status { get; set; }
        public int pi_madeby { get; set; }
        public decimal pi_net { get; set; }
        public decimal pi_vat { get; set; }
        public decimal pi_bqty { get; set; }
        public decimal pi_bqty2 { get; set; }
        public decimal pi_bqty3 { get; set; }
        public string pi_bqty_uom { get; set; }
        public string pi_bqty2_uom { get; set; }
        public string pi_bqty3_uom { get; set; }
        public decimal pi_rqty { get; set; }
        public decimal pi_rqty2 { get; set; }
        public decimal pi_rqty3 { get; set; }
        public decimal pi_disc_value { get; set; }
        public decimal pi_freeQty { get; set; }
        public string pi_freeUOM { get; set; }
        public string pi_freeBatch { get; set; }
        public string pi_freeExpiry { get; set; }
        public string pi_batch { get; set; }
        public int pi_branch { get; set; }
        public int pi_modifiedby { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public decimal pi_total { get; set; }
        public decimal pi_vat_per { get; set; }
        public decimal pi_netvat { get; set; }
        public decimal pi_cost { get; set; }
        public decimal pi_cost2 { get; set; }
        public decimal pi_cost3 { get; set; }
        public string pur_odate { get; set; }
    }

    public class PurchaseOrderFilters
    {
        public int purid { get; set; }
        public string pur_branch { get; set; }
        public string pur_ocode { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string pur_status { get; set; }
        public int pur_omadeby { get; set; }
        public string pur_type { get; set; }
        public string pur_supplier { get; set; }
        public int empId { get; set; }
    }

    public class PurchaseOrderDDL
    {
        public int id { get; set; }
        public string text { get; set; }
        public string name { get; set; }
        
    }
}
