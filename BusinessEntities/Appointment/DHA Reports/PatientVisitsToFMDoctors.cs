using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment.DHA_Reports
{
    public class PatientVisitsToFMDoctors
    {
        public string diag_code_name { get; set; }
        public int M_0_1 { get; set; }
        public int F_0_1 { get; set; }
        public int M_1_4 { get; set; }
        public int F_1_4 { get; set; }
        public int M_5_9 { get; set; }
        public int F_5_9 { get; set; }
        public int M_10_14 { get; set; }
        public int F_10_14 { get; set; }
        public int M_15_19 { get; set; }
        public int F_15_19 { get; set; }
        public int M_20_24 { get; set; }
        public int F_20_24 { get; set; }
        public int M_25_44 { get; set; }
        public int F_25_44 { get; set; }
        public int M_45_64 { get; set; }
        public int F_45_64 { get; set; }
        public int M_65_100 { get; set; }
        public int F_65_100 { get; set; }
    }

    public class PatientVisitsToFMDoctorsSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; }
        public int select_month { get; set; }
        public int select_year { get; set; }
        public string select_nat { get; set; }
    }
}