using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class TreatmentValidityReport
    {
        public int ptId { get; set; }
        public int psId { get; set; }
        public int patId { get; set; }
        public int pat_branch { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string tr_name { get; set; }
        public int ps_tr_rdays { get; set; }
        public string pat_email { get; set; }
        public int pt_treatment { get; set; }
        public string emp_name { get; set; }
        public string emp_desig { get; set; }
        public string emp_dept { get; set; }
        public DateTime due_date { get; set; }
        public DateTime pt_app_fdate { get; set; }
    }
}