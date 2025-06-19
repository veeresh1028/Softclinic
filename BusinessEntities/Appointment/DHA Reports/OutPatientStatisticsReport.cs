using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment.DHA_Reports
{
    public class OutPatientStatisticsReport
    {
        public DateTime app_fdate { get; set; }
        public string app_type { get; set; }
        public string pat_code { get; set; }
        public string pat_emid { get; set; }
        public string pat_resident_status { get; set; }
        public string pat_city { get; set; }
        public string department { get; set; }
        public string diagnosis_code_1 { get; set; }
        public string diagnosis_code_2 { get; set; }
        public string diagnosis_code_3 { get; set; }
        public string diagnosis_code_4 { get; set; }
        public string diagnosis_code_5 { get; set; }
        public string treatment_code_1 { get; set; }
        public string treatment_code_2 { get; set; }
        public string treatment_code_3 { get; set; }
        public string treatment_code_4 { get; set; }
        public string treatment_code_5 { get; set; }
        public string pat_gender { get; set; }
        public int pat_age_years { get; set; }
        public string nationality { get; set; }
    }

    public class OutPatientStatisticsReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; }
        public int select_month { get; set; }
        public int select_year { get; set; }
    }
}