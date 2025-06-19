using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class PatientNonVisitReport
    {
        public int patId { get; set; }
        public int pat_branch { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_gender { get; set; }
        public string nationality { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_email { get; set; }
        public int no_of_days { get; set; }
        public DateTime pat_date_created { get; set; }
        public DateTime pat_last_visited { get; set; }
    }

    public class PatientLastDaysSearch
    {
        public int empId { get; set; }
        public int emp_branch { get; set;}
    }
}