using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class FillerConsent
    {
        public int fccId { get; set; }
        public int fcc_appId { get; set; }
        public string fcc_1 { get; set; }
        public string fcc_2 { get; set; }
        public string fcc_status { get; set; }
    }
}
