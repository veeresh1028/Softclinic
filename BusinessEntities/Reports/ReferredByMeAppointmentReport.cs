using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class ReferredByMeAppointmentReport
    {
        public int patId { get; set; }
        public string pat_code_mob { get; set; }
        public int app_ins { get; set; }
        public int app_doctor { get; set; }
        public string iref_app_doc_ftime { get; set; }
        public string iref_app_doc_ttime { get; set; }
        public string app_status { get; set; }
        public string iref_app_date_time { get; set; }
        public string iref_doctor_from_name { get; set; }
        public string iref_doctor_to_name { get; set; }
        public string ins_exp { get; set; }
        public string app_madeby_name { get; set; }
    }

    public class ReferredByMeReportSearch
    {
        public string select_branch { get; set; } = string.Empty;
        public int empId { get; set; } = 0;
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.AddDays(1).ToString());
    }
}