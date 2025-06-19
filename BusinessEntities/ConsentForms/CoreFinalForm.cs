using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class CoreFinalForm
    {
        public int ccfId { get; set; }
        public int ccf_appId { get; set; }
        public string ccf_chk1 { get; set; }
        public string ccf_chk2 { get; set; }
        public string ccf_chk3 { get; set; }
        public string ccf_chk4 { get; set; }
        public string ccf_chk5 { get; set; }
        public string ccf_chk6 { get; set; }
        public string ccf_chk7 { get; set; }
        public string ccf_chk8 { get; set; }
        public string ccf_chk9 { get; set; }
        public string ccf_chk10 { get; set; }
        public double ccf_total { get; set; }
        public string ccf_status { get; set; }
        public DateTime ccf_date_modified { get; set; }
    }
}
