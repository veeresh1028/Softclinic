using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class SculptraConsentForm
    {
        public int scfId { get; set; }
        public int scf_appId { get; set; }
        public string scf_witness { get; set; }
        public string scf_status { get; set; }
        public DateTime scf_date_modified { get; set; }
    }
}
