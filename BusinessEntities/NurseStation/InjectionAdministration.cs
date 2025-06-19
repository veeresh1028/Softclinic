using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.NurseStation
{
    public class InjectionAdministration
    {
        public int mrfId { get; set; }
        public int mrf_appId { get; set; }
        public string mrf_1 { get; set; }
        public string mrf_2 { get; set; }
        public string mrf_3 { get; set; }
        public string mrf_4 { get; set; }
        public DateTime mrf_5 { get; set; }
        public string mrf_status { get; set; }
        public int mrf_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
