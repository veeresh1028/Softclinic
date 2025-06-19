using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class PurchaseRequests
    {
        public int purqId { get; set; }
        public int purq_supplier { get; set; }
        public string purq_ocode { get; set; }
        public string purq_odate { get; set; }
        public string purq_account { get; set; }
        public decimal purq_total { get; set; }
        public decimal purq_disc { get; set; }
        public string purq_disc_type { get; set; }
        public decimal purq_disc_val { get; set; }
        public decimal purq_net { get; set; }
        public decimal purq_netvat { get; set; }
        public string purq_notes { get; set; }
        public string purq_status { get; set; }
        public int purq_omadeby { get; set; }
        public string purq_type { get; set; }
        public string purq_enqno { get; set; }
        public string purq_quono { get; set; }
        public int purq_validity { get; set; }
        public int purq_pay_terms { get; set; }
        public string purq_qdate { get; set; }
        public string purq_ship_1 { get; set; }
        public string purq_ship_2 { get; set; }
        public string purq_ship_3 { get; set; }
        public string purq_ship_4 { get; set; }
        public string purq_bill_1 { get; set; }
        public string purq_bill_2 { get; set; }
        public string purq_bill_3 { get; set; }
        public string purq_bill_4 { get; set; }
        public string purq_buy_1 { get; set; }
        public string purq_buy_2 { get; set; }
        public string purq_buy_3 { get; set; }
        public string purq_buy_4 { get; set; }
        public int purq_branch { get; set; }
        public decimal purq_vat { get; set; }
        public decimal purq_idisc { get; set; }
        public string sup_name { get; set; }
        public string sup_tel { get; set; }
        public string sup_mob { get; set; }
        public string sup_email { get; set; }
        public string sup_account { get; set; }
        public string sup_code { get; set; }
        public string sup_vat_regno { get; set; }
        public string purq_sup_invoice { get; set; }
        public string branch_name { get; set; }
        public string madeby_name { get; set; }
        public string actionvisible { get; set; }
        public string set_footer_image { get; set; }
        public string set_header_image { get; set; }
        public string sup_address { get; set; }
        public string amount_in_words { get; set; }
        public int empId { get; set; }
    }

    public class PurchaseRequestItems
    {
        public int slno { get; set; }   
        public int prqiId { get; set; }
        public int prqi_purchase { get; set; }
        public int prqi_item { get; set; }
        public string prqi_mode { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string prqi_desc { get; set; }
        public string prqi_edate { get; set; }
        public decimal prqi_oqty { get; set; }
        public string prqi_uom { get; set; }
        public decimal prqi_uprice { get; set; }
        public decimal prqi_disc { get; set; }
        public string prqi_disc_type { get; set; }
        public decimal prqi_nprice { get; set; }
        public string prqi_status { get; set; }
        public int prqi_madeby { get; set; }
        public decimal prqi_net { get; set; }
        public decimal prqi_vat { get; set; }
        public decimal prqi_bqty { get; set; }
        public decimal prqi_bqty2 { get; set; }
        public decimal prqi_bqty3 { get; set; }
        public string prqi_bqty_uom { get; set; }
        public string prqi_bqty2_uom { get; set; }
        public string prqi_bqty3_uom { get; set; }
        public decimal prqi_rqty { get; set; }
        public decimal prqi_rqty2 { get; set; }
        public decimal prqi_rqty3 { get; set; }
        public decimal prqi_disc_value { get; set; }
        public decimal prqi_freeQty { get; set; }
        public string prqi_freeUOM { get; set; }
        public string prqi_freeBatch { get; set; }
        public string prqi_freeExpiry { get; set; }
        public string prqi_batch { get; set; }
        public int prqi_branch { get; set; }
        public int prqi_modifiedby { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public decimal prqi_total { get; set; }
        public decimal prqi_vat_per { get; set; }
        public decimal prqi_netvat { get; set; }
        public decimal prqi_cost { get; set; }
        public decimal prqi_cost2 { get; set; }
        public decimal prqi_cost3 { get; set; }
    }

    public class PurchaseRequestFilters
    {
        public int purqId { get; set; }
        public string purq_branch { get; set; }
        public string purq_ocode { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string purq_status { get; set; }
        public int purq_omadeby { get; set; }
        public string purq_type { get; set; }
        public string purq_supplier { get; set; }
        public int empId { get; set; }
    }

    public class PurchaseRequestDDL
    {
        public int id { get; set; }
        public string text { get; set; }
        public string name { get; set; }
    }

    public class PurchaseRequestsAndItems
    {
        public PurchaseRequests purchaseRequests { get; set; }
        public List<PurchaseRequestItems> purchaseRequestItems { get; set; }
    }
}