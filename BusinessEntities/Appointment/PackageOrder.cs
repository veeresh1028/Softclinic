using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment
{
    public class PackageOrder
    {
        public int poId { get; set; }
        public string po_package { get; set; }
        public string po_refno { get; set; }
        public string po_details { get; set;}
        public string po_exp_date { get; set; }
        public decimal po_pkg_price { get; set; }
        public decimal pkg_balance { get; set; }
        public decimal pkg_adv_bal { get; set; }
        public decimal pkg_total_allocated { get; set; }
        public decimal pkg_advance { get; set; }
        public decimal total_recieved { get; set; }
        public decimal total_cash { get; set; }
        public string po_package_name { get; set; }
        public string po_date { get; set; }
        public string po_notes { get; set; }
        public string po_status { get; set; }
    }
}
