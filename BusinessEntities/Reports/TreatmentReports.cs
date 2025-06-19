using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class TreatmentReports
    {
        public int ptId { get; set; }
        public string pt_inv_status { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_ded { get; set; }
        public string pt_invno { get; set; }
        public decimal pt_copay { get; set; }
        public decimal pt_share { get; set; }
        public decimal pt_net { get; set; }
        public int pt_treatment { get; set; }
        public DateTime pt_inv_date { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string ins_exp { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_license { get; set; }
        public string tr_name { get; set; }
        public decimal tr_cost { get; set; }
        public string tr_type { get; set; }
    }

    public class TreatmentReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_dept { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public int select_treat { get; set; } = 0;
        public string select_type { get; set; } = string.Empty;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}