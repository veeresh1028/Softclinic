using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class GRN_Log_list
    {
        public List<GRN_Log> _grn_log { get; set; }
    }
    public class GRN_Log
    {
        public int praId { get; set; }
        public int pra_prId { get; set; }
        public string pra_code { get; set; }
        public string pra_date { get; set; }
        public int pra_PurchaseOrder { get; set; }
        public int pra_supplier { get; set; }
        public string pra_supplier_inv { get; set; }
        public decimal pra_total { get; set; }
        public decimal pra_discount { get; set; }
        public decimal pra_net { get; set; }
        public decimal pra_vat { get; set; }
        public decimal pra_netvat { get; set; }
        public string pra_status { get; set; }
        public int pra_branch { get; set; }
        public string pra_notes { get; set; }
        public int pra_madeby { get; set; }
        public string purchase_order { get; set; }
        public string supplier_name { get; set; }
        public string branch_name { get; set; }
        public string madeby { get; set; }
        public string pra_operation { get; set; }
        public string pra_date_created { get; set; }
    }
}
