using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class PreSubmissionReport
    {
        public string ic_code { get; set; }
        public string ic_name { get; set; }
        public string ip_code { get; set; }
        public string ip_name { get; set; }
        public int claim_count { get; set; }
        public decimal pat_share { get; set; }
        public decimal inv_net { get; set; }
    }

    public class PreSubmissionReportSearch
    {
        public string select_branch { get; set; }
        public string select_ins_tpa { get; set; }
        public string select_ins_payer { get; set; }
        public string select_doctors { get; set; }
        public DateTime select_date_from { get; set; }
        public DateTime select_date_to { get; set; }
    }
}