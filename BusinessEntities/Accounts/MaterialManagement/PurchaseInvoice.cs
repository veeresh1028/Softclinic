using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.MaterialManagement
{
    public class purchaseInvoiceWithItems
    {
        public PurchaseInvoice purchaseInvoice { get; set; }
        public List<PurchaseInvoiceItems> purchaseInvoiceItems { get; set; }
    }
    public class PurchaseInvoiceList
    {
        public string branch_name { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public List<PurchaseInvoice> purchaseInvoiceList { get; set; }
    }
    public class PurchaseInvoice
    {
        public int pinvId { get; set; }
        public int pinv_supplier { get; set; }
        public int pinv_grnId { get; set; }
        public string pinv_grnIds { get; set; }
        public string pinv_account { get; set; }
        public string pinv_icode { get; set; }
        public string pinv_invno { get; set; }
        public string pinv_idate { get; set; }
        public decimal pinv_total { get; set; }
        public decimal pinv_disc { get; set; }
        public string pinv_disc_type { get; set; }
        public decimal pinv_net { get; set; }
        public decimal pinv_paid { get; set; }
        public decimal pinv_balance { get; set; }
        public string pinv_notes { get; set; }
        public int pinv_imadeby { get; set; }
        public string pinv_status { get; set; }
        public string pinv_date_created { get; set; }
        public string pinv_pocode { get; set; }
        public string pinv_status2 { get; set; }
        public decimal pinv_disc_value { get; set; }
        public decimal pinv_vat { get; set; }
        public decimal pinv_netvat { get; set; }
        public int pinv_branch { get; set; }
        public string supplier_name { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string actionvisible { get; set; }
        public string amount_in_words { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public int payId_count { get; set; }
        public int pinv_count { get; set; }

    }
    public class PurchaseInvoiceItems
    {
        public int pitId { get; set; }
        public int pit_preceived { get; set; }
        public int pit_pinvoice { get; set; }
        public string pit_notes { get; set; }
        public decimal pit_vat { get; set; }
        public decimal pit_total { get; set; }
        public decimal pit_net { get; set; }
        public decimal pit_disc { get; set; }
        public string pit_disc_type { get; set; }
        public decimal pit_disc_val { get; set; }
        public decimal pit_net_vat { get; set; }
        public string pit_status { get; set; }
        public string pr_code { get; set; }
        public string po_code { get; set; }
        public string mode { get; set; }

    }
    public class PurchaseInvoice_Filter
    {
        public string pinv_supplier { get; set; }
        public int pinvId { get; set; }
        public int pinv_branch { get; set; }
        public string pinv_fdate { get; set; }
        public string pinv_tdate { get; set; }
        public string pinv_icode { get; set; }
        public string pinv_status { get; set; }
        public int empId { get; set; }
        public int pitId { get; set; }
        public int pit_preceived { get; set; }
        public string pr_code { get; set; }
    }

    public class ItemsExpiry
    {
        public List<ExpItems> Exp_Items { get; set; }
    }
    public class ExpItems
    {
        public int ibId { get; set; }
        public string ib_item { get; set; }
        public string ib_batch { get; set; }
        public string ib_edate { get; set; }
        public string ib_grn { get; set; }
        public string ib_qty { get; set; }
        public string branch_name { get; set; }
    }
}
