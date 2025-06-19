using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class SurgicalAct
    {
        public int safId { get; set; }
        public int saf_appId { get; set; }
        public string saf_1 { get; set; }
        public string saf_2 { get; set; }
        public string saf_3 { get; set; }
        public string saf_4 { get; set; }
        public string saf_status { get; set; }
        public DateTime saf_date_modified { get; set; }
    }
}
