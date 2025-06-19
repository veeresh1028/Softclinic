using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DoctorsComissionReport
    {
        public int empId { get; set; }
        public string pt_app_doctor_name { get; set; }
        public decimal pt_consultation_commi { get; set; }
        public decimal pt_procedure_commi { get; set; }
        public decimal pt_lab_commi { get; set; }
        public decimal pt_rad_commi { get; set; }
        public decimal pt_pha_commi { get; set; }
        public decimal pt_met_commi { get; set; }
    }

    public class DoctorsComissionReportDetails
    {
        public int ptId { get; set; }
        public int pt_appId { get; set; }
        public string pt_type { get; set; }
        public string pat_name { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_qty { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_vat { get; set; }
        public decimal pt_netvat { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public DateTime pt_app_fdate { get; set; }
    }

    public class SearchDetails
    {
        public int empId { get; set; }
        public string emp_name { get; set; }
        public string type { get; set; }
    }

    public class DoctorsCommissionSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_dept { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public string select_type { get; set; } = string.Empty;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}