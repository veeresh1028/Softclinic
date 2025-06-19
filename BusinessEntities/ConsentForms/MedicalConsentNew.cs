using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class MedicalConsentNew
    {
        public int mctId { get; set; }
        public int mct_appId { get; set; }
        public string mct_1 { get; set; }
        public string mct_2 { get; set; }
        public string mct_3 { get; set; }
        public string mct_status { get; set; }
    }
}
