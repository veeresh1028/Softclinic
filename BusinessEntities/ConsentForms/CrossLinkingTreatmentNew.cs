using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class CrossLinkingTreatmentNew
    {
        public int ocltId { get; set; }
        public int oclt_appId { get; set; }
        public string oclt_1 { get; set; }
        public string oclt_2 { get; set; }
        public string oclt_3 { get; set; }
        public string oclt_4 { get; set; }
        public string oclt_status { get; set; }
        public DateTime oclt_date_modified { get; set; }
    }
}
