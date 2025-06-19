using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class CheifComplaints
    {
        public int compId { get; set; }
        public int comp_appId { get; set; }
        [AllowHtml]
        public string complaint { get; set; }
        public string comp_status { get; set; }
        public int comp_madeby { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

        public string cm_title { get; set; }
        public string comp_location { get; set; }
        public string comp_severity { get; set; }
    }
}
