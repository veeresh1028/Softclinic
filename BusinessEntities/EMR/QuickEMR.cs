using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class SignedDocuments
    {
        public DateTime visit_date { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public int psbId { get; set; }
        public int psb_appId { get; set; }
        public int psb_patId { get; set; }
        public string psb_file { get; set; }
        public string psb_person { get; set; }
        public DateTime psb_date_created { get; set; }
        public string psb_formlink { get; set; }
        public string psb_status { get; set; }
        public string FileN { get; set; }
    }

    public class StartEndTime
    {
        public int tId { get; set; }
        public int t_appId { get; set; }
        public DateTime t_start { get; set; }
        public string t_start1 { get; set; }
        public DateTime t_end { get; set; }
        public string t_end1 { get; set; }
        public string t_duration { get; set; }
        public string t_status { get; set; }
    }
}
