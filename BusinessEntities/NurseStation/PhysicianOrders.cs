using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    public class PhysicianOrders
    {
        public int ptId { get; set; }
        public int pt_appId { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string pt_qty { get; set; }
        public string pt_notes { get; set; }
        public string emp_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime pt_date_collected { get; set; }
        public DateTime pt_date_received { get; set; }
        public DateTime pt_exe_date { get; set; }
        public DateTime pt_date_modified { get; set; }
        public DateTime pt_date_created { get; set; }
        public string doctor_name { get; set; }

        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    
}
