using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.KPIReports
{
    public class VitalSignsReport
    {
        public DateTime visit_date { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public decimal sign_temp { get; set; }
        public decimal sign_pulse { get; set; }
        public decimal sign_bp { get; set; }
        public decimal sign_bpd { get; set; }
        public decimal sign_height { get; set; }
        public decimal sign_weight { get; set; }
        public decimal sign_bmi { get; set; }
        public decimal sign_resp { get; set; }
        public decimal sign_spo2 { get; set; }
        public decimal sign_hip { get; set; }
        public decimal sign_waist { get; set; }
        public decimal sign_head { get; set; }
        public decimal sign_uri { get; set; }
        public string sign_notes { get; set; }
    }

    public class VitalSignsReportSearch
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public string dept_ids { get; set; }
        public string doctor_ids { get; set; }
        public int patient { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }
}