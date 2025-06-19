using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargeChalazionIncisionNew
    {
        public int dciId { get; set; }
        public int dci_appId { get; set; }
        public string dci_1 { get; set; }
        public string dci_2 { get; set; }
        public string dci_3 { get; set; }
        public string dci_4 { get; set; }
        public string dci_5 { get; set; }
        public string dci_6 { get; set; }
        public string dci_7 { get; set; }
        public string dci_status { get; set; }
        public DateTime dci_date_modified { get; set; }
    }
}
