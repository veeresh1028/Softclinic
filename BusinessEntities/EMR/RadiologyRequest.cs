using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class RadiologyRequest
    {
        public int rdrf_Id { get; set; }
        public int rdrf_appId { get; set; }
        public string rdrf_finding { get; set; }
        public string rdrf_radio { get; set; }
        public string rdrf_status { get; set; }
        public int rdrf_madeby { get; set; }
        public string rdrf_witness { get; set; }
        public DateTime rdrf_date_created { get; set; }


        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string doc_sign { get; set; }
        public string doc_stamp { get; set; }
    }
}
