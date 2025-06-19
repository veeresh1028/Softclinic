using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Documentation
{
    public class DocInfo
    {
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_lname { get; set; }
        public string pat_fname { get; set; }
        public string pat_mname { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_age { get; set; }
        public string pat_gender { get; set; }
        public string pat_nationality { get; set; }
        public string pat_ms { get; set; }
        public string pat_photo { get; set; }
        public string app_ic_name { get; set; }
        public string appId { get; set; }
        public string app_fdate_time { get; set; }
        public string app_doctor_department { get; set; }
        public string emp_photo { get; set; }
        public string vital_sign { get; set; }
        public string allergy { get; set; }
        public bool isAlert { get; set; }
        public int patId { get; set; }
        public int app_branch { get; set; }
        public string emp_designation { get; set; }
        public string set_emr_lock { get; set; }
        public DateTime app_ae_date { get; set; }
        public DateTime app_ae_date1 { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public int app_doctor { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string app_category { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_address { get; set; }
        public string pi_insno { get; set; }
        public string pi_polocyno { get; set; }
        public string pat_city { get; set; }
        public string pat_country { get; set; }
        public string pat_pobox { get; set; }
        public string pat_dob { get; set; }
        public string app_fdate { get; set; }
        public string ic_name { get; set; }
        public string doc_name { get; set; }
        public string set_company { get; set; }
        public string set_permit_no { get; set; }
        public string doc_sign { get; set; }
        public string emp_license { get; set; }
        public string emp_tel { get; set; }
        public string emp_fax { get; set; }
        public string emp_address { get; set; }
        public string emp_nat { get; set; }
        public string emp_email { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_fax { get; set; }
    }
}
