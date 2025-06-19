using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargeLucentisNew
    {
        public int dliId { get; set; }
        public int dli_appId { get; set; }
        public string dli_1 { get; set; }
        public string dli_2 { get; set; }
        public string dli_3 { get; set; }
        public string dli_4 { get; set; }
        public string dli_5 { get; set; }
        public string dli_6 { get; set; }
        public string dli_status { get; set; }
        public DateTime dli_date_modified { get; set; }
    }
}
