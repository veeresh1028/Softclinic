using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargeCrossLinkingNew
    {
        public int dclId { get; set; }
        public int dcl_appId { get; set; }
        public string dcl_1 { get; set; }
        public string dcl_2 { get; set; }
        public string dcl_3 { get; set; }
        public string dcl_4 { get; set; }
        public string dcl_5 { get; set; }
        public string dcl_6 { get; set; }
        public string dcl_status { get; set; }
        public DateTime dcl_date_modified { get; set; }
    }
}
