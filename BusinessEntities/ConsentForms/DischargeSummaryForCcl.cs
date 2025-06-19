using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargeSummaryForCcl
    {
        public int dsfcfId { get; set; }
        public int dsfcf_appId { get; set; }
        public string dsfcf_1 { get; set; }
        public string dsfcf_2 { get; set; }
        public string dsfcf_3 { get; set; }
        public string dsfcf_4 { get; set; }
        public string dsfcf_5 { get; set; }
        public string dsfcf_6 { get; set; }
        public string dsfcf_7 { get; set; }
        public string dsfcf_status { get; set; }
        public DateTime dsfcf_date_modified { get; set; }
    }
}
