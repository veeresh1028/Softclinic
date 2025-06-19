using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class TreatmentRecordSheet
    {
        public int trsId { get; set; }
        public int trs_appId { get; set; }
        public string trs_treat { get; set; }
        public string trs_treat_name { get; set; }
        public string trs_1 { get; set; }
        public string trs_date1 { get; set; }
        public string trs_notes { get; set; }
        public string trs_status { get; set; }
        public DateTime trs_date_modified { get; set; }
    }
}
