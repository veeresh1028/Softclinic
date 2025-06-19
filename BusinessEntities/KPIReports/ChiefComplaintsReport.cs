using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.KPIReports
{
    public class ChiefComplaintsReport
    {
        public DateTime visit_date { get; set; }
        public string pat_file_no { get; set; }
        public string pat_mobile { get; set; }
        public string pat_name { get; set; }
        public string doctor_name { get; set; }
        public string department_name { get; set; }
        public string complaint { get; set; }
    }

    public class ChiefComplaintsReportSearch
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
