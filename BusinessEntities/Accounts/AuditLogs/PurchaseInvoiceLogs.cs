using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class PurchaseInvoiceLogs_list
    {
        public List<PurchaseInvoiceLogs> purchaseInvoiceLogs_list { get; set; }

    }
    public class PurchaseInvoiceLogs
    {
        public int pinvaId { get; set; }
        public int pinva_supplier { get; set; }
        public string pinva_account { get; set; }
        public string pinva_icode { get; set; }
        public string pinva_invno { get; set; }
        public string pinva_idate { get; set; }
        public decimal pinva_total { get; set; }
        public decimal pinva_disc { get; set; }
        public string pinva_disc_type { get; set; }
        public decimal pinva_net { get; set; }
        public string pinva_notes { get; set; }
        public int pinva_imadeby { get; set; }
        public string pinva_status { get; set; }
        public string pinva_date_created { get; set; }
        public string pinva_pocode { get; set; }
        public string pinva_status2 { get; set; }
        public decimal pinva_disc_value { get; set; }
        public decimal pinva_vat { get; set; }
        public int pinva_branch { get; set; }
        public string pinva_operation { get; set; }
        public string supplier_name { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public decimal pinva_paid { get; set; }
        public decimal pinva_balance { get; set; }
    }
    public class PurchaseReturnLog_list
    {
        public List<PurchaseReturnLog> purchaseReturnLog_list { get; set; }

    }
    public class PurchaseReturnLog
    {
        public int poraId { get; set; }
        public int pora_porId { get; set; }
        public int pora_supplier { get; set; }
        public string pora_ocode { get; set; }
        public string pora_odate { get; set; }
        public string pora_account { get; set; }
        public decimal pora_total { get; set; }
        public decimal pora_disc { get; set; }
        public string pora_disc_type { get; set; }
        public decimal pora_net { get; set; }
        public string pora_notes { get; set; }
        public string pora_status { get; set; }
        public int pora_omadeby { get; set; }
        public string pora_date_created { get; set; }
        public string pora_type { get; set; }
        public string pora_status2 { get; set; }
        public int pora_branch { get; set; }
        public string pora_operation { get; set; }
        public string pora_pocode { get; set; }
        public int pora_purId { get; set; }
        public int pora_prId { get; set; }
        public string supplier_name { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
    }
    public class MaterialConsumptionLogList
    {
        public List<MaterialConsumptionLogs> materialConsumptionLogList { get; set; }

    }
    public class MaterialConsumptionLogs
    {
        public int scraId { get; set; }
        public int scra_refno { get; set; }
        public string scra_date { get; set; }
        public int scra_item { get; set; }
        public string scra_desc { get; set; }
        public decimal scra_qty { get; set; }
        public string scra_uom { get; set; }
        public int scra_madeby { get; set; }
        public string scra_status { get; set; }
        public string scra_batch { get; set; }
        public int scra_reqby { get; set; }
        public int scra_branch { get; set; }
        public int scra_doctor { get; set; }
        public int scra_room { get; set; }
        public int scra_ibId { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string item_name { get; set; }
        public string item_code { get; set; }
        public string room { get; set; }
        public string doctor_name { get; set; }
        public string scra_operation { get; set; }
        public string scra_date_created { get; set; }
    }
}
