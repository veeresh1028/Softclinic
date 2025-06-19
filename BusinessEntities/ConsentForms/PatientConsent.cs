using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConcentForms
{
    public class PatientConsent
    {
        public int pcId { get; set; }
        public int pc_appId { get; set; }
        public string pc_1 { get; set; }
        public string pc_2 { get; set; }
        public string pc_3 { get; set; }
        public string pc_4 { get; set; }
        public string pc_5 { get; set; }
        public string pc_6 { get; set; }
        public string pc_7 { get; set; }
        public string pc_status { get; set; }
    }
}
