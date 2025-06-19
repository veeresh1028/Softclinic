using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class SpeechProgressChart
    {
        public int spcId { get; set; }
        public int spc_appId { get; set; }
        public string spc_date1 { get; set; }
        public string spc_1 { get; set; }
        public string spc_color { get; set; }
        public string spc_2 { get; set; }
        public string spc_status { get; set; }
        public DateTime spc_date_modified { get; set; }
    }
}
