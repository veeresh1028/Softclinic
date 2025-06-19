using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DentalInternalFormConsent
    {
        public int cdf_Id { get; set; }
        public int cdf_appId { get; set; }

        public string cdf_check2 { get; set; }
        public string cdf_text1 { get; set; }
        public string cdf_text2 { get; set; }

        public string cdf_comments { get; set; }

        public string cdf_status { get; set; }
        public DateTime cdf_date_modified { get; set; }
    }
}
