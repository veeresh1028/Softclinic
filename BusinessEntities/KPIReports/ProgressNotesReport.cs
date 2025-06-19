using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.KPIReports
{
    public class ProgressNotesReport
    {
        public DateTime visit_date { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string mn_notes { get; set; }
        public string mn_visitPlan { get; set; }
        public string mn_instructions { get; set; }
        public DateTime mn_date_created { get; set; }
    }

    public class ProgressNotesReportSearch
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