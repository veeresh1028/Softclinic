using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.AuditLogs
{
    public class ItemsLog
    {
       public int itemaId { get; set; }
        public string itema_code { get; set; }
        public string itema_type { get; set; }
        public string itema_name { get; set; }
        public decimal itema_qty { get; set; }
        public string itema_uom { get; set; }
        public string itema_desc { get; set; }
        public string itema_status { get; set; }
        public decimal itema_cost { get; set; }
        public decimal itema_sprice { get; set; }
        public string itema_brand { get; set; }
        public string itema_dosage { get; set; }
        public string itema_strength { get; set; }
        public decimal itema_qty_adj { get; set; }
        public decimal itema_qty2 { get; set; }
        public string itema_uom2 { get; set; }
        public decimal itema_m_factor { get; set; }
        public decimal itema_cost2 { get; set; }
        public decimal itema_sprice2 { get; set; }
        public decimal itema_vat { get; set; }
        public decimal itema_qty3 { get; set; }
        public string itema_uom3 { get; set; }
        public decimal itema_m_factor2 { get; set; }
        public decimal itema_cost3 { get; set; }
        public decimal itema_sprice3 { get; set; }
        public string itema_operation { get; set; }
        public string itema_date_created { get; set; }
        public string branch_name { get; set; }
        public string location_name { get; set; }
        public string category_name { get; set; }
        public string madeby { get; set; }
    }
}
