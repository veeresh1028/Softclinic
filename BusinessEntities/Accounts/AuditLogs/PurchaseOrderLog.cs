using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class PurchaseOrderLog
    {
       public int puraId { get; set; }
        public string pura_ocode { get; set; }
        public string pura_odate { get; set; }
        public string pura_account { get; set; }
        public decimal pura_total { get; set; }
        public decimal pura_disc { get; set; }
        public string pura_disc_type { get; set; }
        public decimal pura_net { get; set; }
        public string pura_notes { get; set; }
        public string pura_status { get; set; }
        public string pura_type { get; set; }
        public string pura_enqno { get; set; }
        public string pura_quono { get; set; }
        public int pura_validity { get; set; }
        public int pura_pay_terms { get; set; }
        public string pura_qdate { get; set; }
        public string pura_ship_1 { get; set; }
        public string pura_ship_2 { get; set; }
        public string pura_ship_3 { get; set; }
        public string pura_ship_4 { get; set; }
        public string pura_bill_1 { get; set; }
        public string pura_bill_2 { get; set; }
        public string pura_bill_3 { get; set; }
        public string pura_bill_4 { get; set; }
        public string pura_buy_1 { get; set; }
        public string pura_buy_2 { get; set; }
        public string pura_buy_3 { get; set; }
        public string pura_buy_4 { get; set; }
        public string pura_operation { get; set; }
        public string pura_date_modified { get; set; }
        public decimal pura_vat { get; set; }
        public decimal pura_idisc { get; set; }
        public decimal pura_disc_val { get; set; }
        public string pura_sup_invoice { get; set; }
        public string supplier_name { get; set; }
        public string madeby { get; set; }
        public string branch_name { get; set; }
    }
}
