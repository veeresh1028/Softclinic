using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace BusinessEntities.Accounts.Masters
{
    public class SupplierHistory
    {
        public SupplierDetail supplierDetail { get; set; }
        public List<SupplierPurchaseOrder> supplierPurchaseOrders { get; set; }
        public List<SupplierGRN> supplierGRN { get; set; }
        public List<SupplierInvoice> supplierInvoice { get; set; }
        public List<SupplierPayment> supplierPayment { get; set; }
    }

    public class PurchaseOrderHistory
    {
        public List<SupplierPurchaseOrder> purchaseOrder { get; set; }
        public List<SupplierGRN> GRNs { get; set; }
        public List<SupplierInvoice> prurchaseInvoice { get; set; }
        public List<SupplierPayment> prurchaseInvoicePayment { get; set; }
        public List<PurchaseReturn> prurchaseInvoiceReturn { get; set; }
    }

    public class SupplierDetail
    {
        public int supId { get; set; }
        public int sup_branch { get; set; }
        public string sup_code { get; set; }
        public string sup_name { get; set; }
        public string sup_branch_name { get; set; }
    }
    public class SupplierPurchaseOrder
    {
        public int purId { get; set; }
        public int pur_supplier { get; set; }
        public string pur_odate { get; set; }
        public string pur_ocode { get; set; }
        public string pur_account { get; set; }
        public decimal pur_total { get; set; }
        public decimal pur_disc { get; set; }
        public string pur_disc_type { get; set; }
        public decimal pur_net { get; set; }
        public decimal pur_vat { get; set; }
        public string pur_status { get; set; }
        public string madeby_name { get; set; }
        public string branch_name { get; set; }
    }
    public class SupplierGRN
    {
        public string pir_dcode { get; set; }
        public string pir_ddate { get; set; }
        public decimal pir_received { get; set; }
        public string pir_status { get; set; }
        public string pir_batchno { get; set; }
        public string pir_uom { get; set; }
        public decimal pir_free_qty { get; set; }
        public int pir_dmadeby { get; set; }
        public string madeby_name { get; set; }
    }
    public class SupplierInvoice
    {
        public string pinv_account { get; set; }
        public string pinv_icode { get; set; }
        public string pinv_invno { get; set; }
        public string pinv_idate { get; set; }
        public decimal pinv_total { get; set; }
        public decimal pinv_disc { get; set; }
        public string pinv_disc_type { get; set; }
        public decimal pinv_net { get; set; }
        public string pinv_status { get; set; }
        public decimal pinv_vat { get; set; }
        public int pinv_imadeby { get; set; }
        public string madeby_name { get; set; }
    }
    public class SupplierPayment
    {
        public string pay_code { get; set; }
        public string pay_date { get; set; }
        public string pay_type { get; set; }
        public decimal paid { get; set; }
        public string pay_status { get; set; }
        public int pay_madeby { get; set; }
        public string madeby_name { get; set; }
        public string po_code { get; set; }
        public string po_date { get; set; }
    }
    public class PurchaseReturn
    {
        public string por_ocode { get; set; }
        public string por_odate { get; set; }
        public int por_supplier { get; set; }
        public decimal por_total { get; set; }
        public decimal por_net { get; set; }
        public string por_notes { get; set; }
        public string por_status { get; set; }
        public int por_omadeby { get; set; }
        public DateTime por_date_created { get; set; }
        public string brnach_name { get; set; }
        public string supplier_name { get; set; }
        public string purchase_order { get; set; }
        public string madeby_name { get; set; }
    }

}
