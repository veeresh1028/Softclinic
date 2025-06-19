using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Marketing.Reports
{
    public class PatientAnalysis
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class PatientAnalysisDetails
    {
        public DataTable report { get; set; }
        public List<string> statuses { get; set; }
        public List<string> columnNames { get; set; }
    }
    public class PatientAnalysisHistory
    {
        public int appId { get; set; }
        public string app_status { get; set; }
        public string managed_by { get; set; }
        public string emp_name { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string app_madeby_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_date_created { get; set; }
    }

}
