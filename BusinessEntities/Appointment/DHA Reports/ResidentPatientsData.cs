using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment.DHA_Reports
{
    public class ResidentPatientsData
    {
        public string pat_code { get; set; }
        public string app_inout { get; set; }
        public string pat_prof_id { get; set; }
        public string country_code { get; set; }
        public string nat_cpq { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_gender { get; set; }
        public string country { get; set; }
        public string nationality { get; set; }
        public string pat_city { get; set; }
        public DateTime app_fdate { get; set; }
        public string emp_address { get; set; }
        public decimal inv_total { get; set; }
        public string diag_code1 { get; set; }
        public string diag_code2 { get; set; }
        public string diag_code3 { get; set; }
        public string diag_code4 { get; set; }
        public string diag_code5 { get; set; }
        public string diag_code6 { get; set; }
        public string diag_code7 { get; set; }
        public string diag_code8 { get; set; }
        public string pt_tr_code1 { get; set; }
        public string pt_tr_code2 { get; set; }
        public string pt_tr_code3 { get; set; }
        public string pt_tr_code4 { get; set; }
        public string pt_tr_code5 { get; set; }
        public string pt_tr_code6 { get; set; }
        public string pt_tr_code7 { get; set; }
        public string pt_tr_code8 { get; set; }
    }

    public class ResidentPatientsDataReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; }
        public int select_month { get; set; }
        public int select_year { get; set; }
    }
}