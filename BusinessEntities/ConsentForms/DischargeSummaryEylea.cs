using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargeSummaryEylea
    {
        public int dsejId { get; set; }
        public int dsej_appId { get; set; }
        public string dsej_1 { get; set; }
        public string dsej_2 { get; set; }
        public string dsej_3 { get; set; }
        public string dsej_4 { get; set; }
        public string dsej_5 { get; set; }
        public string dsej_6 { get; set; }
        public string dsej_status { get; set; }
        public DateTime dsej_date_modified { get; set; }
    }
}
