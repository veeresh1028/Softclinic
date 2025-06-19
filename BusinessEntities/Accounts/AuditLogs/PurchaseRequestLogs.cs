using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class PurchaseRequestLogs
    {
        public int purqaId { get; set; }
        public string purqa_ocode { get; set; }
        public string purqa_odate { get; set; }
        public string purqa_account { get; set; }
        public decimal purqa_total { get; set; }
        public decimal purqa_disc { get; set; }
        public string purqa_disc_type { get; set; }
        public decimal purqa_net { get; set; }
        public string purqa_notes { get; set; }
        public string purqa_status { get; set; }
        public string purqa_type { get; set; }
        public string purqa_enqno { get; set; }
        public string purqa_quono { get; set; }
        public int purqa_validity { get; set; }
        public int purqa_pay_terms { get; set; }
        public string purqa_qdate { get; set; }
        public string purqa_ship_1 { get; set; }
        public string purqa_ship_2 { get; set; }
        public string purqa_ship_3 { get; set; }
        public string purqa_ship_4 { get; set; }
        public string purqa_bill_1 { get; set; }
        public string purqa_bill_2 { get; set; }
        public string purqa_bill_3 { get; set; }
        public string purqa_bill_4 { get; set; }
        public string purqa_buy_1 { get; set; }
        public string purqa_buy_2 { get; set; }
        public string purqa_buy_3 { get; set; }
        public string purqa_buy_4 { get; set; }
        public string purqa_operation { get; set; }
        public string purqa_date_modified { get; set; }
        public decimal purqa_vat { get; set; }
        public decimal purqa_idisc { get; set; }
        public decimal purqa_disc_val { get; set; }
        public string purqa_sup_invoice { get; set; }
        public string supplier_name { get; set; }
        public string madeby { get; set; }
        public string branch_name { get; set; }
    }
}
