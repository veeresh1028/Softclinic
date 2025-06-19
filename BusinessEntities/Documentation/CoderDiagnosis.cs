using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Documentation
{
    public class CoderDiagnosis
    {
        public int codId { get; set; }
        public int cod_appId { get; set; }
        public string cod_type { get; set; }
        public string cod_status { get; set; }
        public int cod_madeby { get; set; }
        public string emp_license { get; set; }
        public string doctor_Name { get; set; }
        public DateTime app_fdate { get; set; }
        public string madeby_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public string diag_name { get; set; }
        public string diag_code { get; set; }
        public string cod_notes { get; set; }
        public int cod_year { get; set; }
        public int cod_diagnosis { get; set; }
        public string chkyes { get; set; }
        public bool check_fav { get; set; }
    }
}
