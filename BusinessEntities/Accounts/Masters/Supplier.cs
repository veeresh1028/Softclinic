using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Masters
{
    public class Supplier
    {
        public int supId { get; set; }
        public string sup_code { get; set; }
        public string sup_name { get; set; }
        public string sup_tel { get; set; }
        public string sup_fax { get; set; }
        public string sup_mob { get; set; }
        public string sup_email { get; set; }
        public string sup_url { get; set; }
        public string sup_address { get; set; }
        public string sup_notes { get; set; }
        public string sup_account { get; set; }
        public string sup_status { get; set; }
        public DateTime sup_date_created { get; set; }
        public DateTime sup_date_modified { get; set; }
        public int sup_credit { get; set; }
        public decimal sup_obal { get; set; }
        public string sup_obal_type { get; set; }
        public string sup_vat_regno { get; set; }
        public int sup_madeby { get; set; }
        public int sup_branch { get; set; }
        public string madeby_name { get; set; }
        public string branch_name { get; set; }
        public string actionvisible { get; set; }
        public decimal invoice_total { get; set; }
        public decimal total_paid { get; set; }
        public decimal balance { get; set; }
    }
    public class SupplierAccounts
    {
        public int trId { get; set; }
        public string tr_refno { get; set; }
        public string tr_date { get; set; }
        public string tr_account { get; set; }
        public string tr_ref_account { get; set; }
        public decimal tr_debit { get; set; }
        public decimal tr_credit { get; set; }
        public string tr_type { get; set; }
        public string tr_remark { get; set; }
        public string tr_date_created { get; set; }
        public string tr_date_modified { get; set; }
        public int tr_id { get; set; }
        public string tr_status { get; set; }
        public int tr_branch { get; set; }
        public string tr_acc_period { get; set; }
        public string tr_status2 { get; set; }
        public string tr_reconcil_date { get; set; }
        public string tr_date2 { get; set; }
        public string tr_drcr { get; set; }
        public string branch_name { get; set; }
        public string date_from { get; set; }
        public string date_to { get; set; }
    }
}
