using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargePlan
    {
        public int dpnId { get; set; }
        public int dpn_appId { get; set; }
        public string dpn_1 { get; set; }
        public string dpn_2 { get; set; }
        public string dpn_3 { get; set; }
        public string dpn_4 { get; set; }
        public string dpn_5 { get; set; }
        public string dpn_6 { get; set; }
        public string dpn_status { get; set; }
        public DateTime dpn_date_modified { get; set; }
    }
}
