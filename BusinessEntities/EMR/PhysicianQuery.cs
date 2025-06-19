using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class PhysicianQuery
    {
        public int pqId { get; set; }
        public int pq_appId { get; set; }
        public string pq_txt1 { get; set; }
        public string pq_txt2 { get; set; }
        public string pq_txt3 { get; set; }
        public string pq_txt4 { get; set; }
        public string pq_txt5 { get; set; }
        public string pq_status { get; set; }
        public int pq_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    

    public class PhysicianNursingQuery
    {
        public int pnqId { get; set; }
        public int pnq_appId { get; set; }
        [AllowHtml]
        public string pnq_query { get; set; }
        [AllowHtml]
        public string pnq_response { get; set; }
        public int pnq_fromemp { get; set; }
        public int pnq_toemp { get; set; }
        public string pnq_status { get; set; }
        public int pnq_madeby { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime pnq_date_created { get; set; }
        public DateTime pnq_date_modified { get; set; }
        public string doctor_name { get; set; }
        public string fromemp { get; set; }
        public string toemp { get; set; }
        
    }
}
