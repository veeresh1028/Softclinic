using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class MedicalDecision
    {
        public int mdId { get; set; }
        public int md_appId { get; set; }
        public string md_txt1 { get; set; }
        public string md_txt2 { get; set; }
        public string md_txt3 { get; set; }
        public string md_txt4 { get; set; }
        public string md_txt5 { get; set; }
        public string md_txt6 { get; set; }
        public string md_txt7 { get; set; }
        public string md_chk { get; set; }
        
        public string md_status { get; set; }
        public int md_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
