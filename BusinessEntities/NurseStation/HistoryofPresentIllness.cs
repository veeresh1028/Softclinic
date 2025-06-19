using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    public class HistoryofPresentIllness
    {   

        public int appId { get; set; }
        public int patId { get; set; }
        public string emp_designation { get; set; }
        public int hpiId { get; set; }
        public int hpi_appId { get; set; }
        public string hpi_loc { get; set; }
        public string hpi_qua { get; set; }
        public string hpi_sev { get; set; }
        public string hpi_dur { get; set; }
        public string hpi_tim { get; set; }
        public string hpi_con { get; set; }
        public string hpi_mod { get; set; }
        public string hpi_sym { get; set; }
        public string hpi_status { get; set; }
        public int hpi_madeby { get; set; }
        public int hpi_modifyby { get; set; }
        public string hpi_other { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());

    }
    
}
