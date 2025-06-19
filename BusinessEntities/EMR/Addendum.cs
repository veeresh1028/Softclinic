using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class Addendum
    {
        public int addeId { get; set; }
        public int adde_appId { get; set; }
        [AllowHtml]
        public string adde_notes { get; set; }
        public string adde_status { get; set; }
        public int adde_madeby { get; set; }
        public DateTime adde_date_created { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string adde_for { get; set; }
        public string adde_for_name { get; set; }
    }

    public class DocData
    {
        public int id { get; set; }
        public string type { get; set; }
        public FileInfo file { get; set; }
        public string label { get; set; }
        public HttpPostedFileBase audio { get; set; }
    }
}
