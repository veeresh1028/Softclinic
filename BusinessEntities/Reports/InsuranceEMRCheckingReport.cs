using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class InsuranceEMRCheckingReport
    {
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }       
        public string ic_code { get; set; }        
        public string ic_name { get; set; }        
        public string ip_code { get; set; }        
        public string ip_name { get; set; }        
        public string is_title { get; set; }        
        public int patId { get; set; }
        public int pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public int empId { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_license { get; set; }
        public decimal pat_share { get; set; }
        public decimal inv_net { get; set; }
    }

    public class InsuranceEMRReportSearch
    {
        public string select_branch { get; set; }
        public string select_ins_tpa { get; set; }
        public string select_ins_payer { get; set; }
        public string select_doctors { get; set; }
        public DateTime select_date_from { get; set; }
        public DateTime select_date_to { get; set; }
    }
}