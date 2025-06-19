using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class PatientDiagnosis
    {
        public int padId { get; set; }
        public int pad_appId { get; set; }
        public string pad_type { get; set; }
        public string pad_status { get; set; }
        public int pad_madeby { get; set; }
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

        public string diag_name { get; set; }
        public string diag_code { get; set; }
        public string pad_notes { get; set; }
        public int pad_year { get; set; }
        public int pad_diagnosis { get; set; }
        public string chkyes { get; set; }
        public bool check_fav { get; set; }
    }
}
