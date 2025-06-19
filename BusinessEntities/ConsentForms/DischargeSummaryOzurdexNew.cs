using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DischargeSummaryOzurdexNew
    {
        public int doiId { get; set; }
        public int doi_appId { get; set; }
        public string doi_1 { get; set; }
        public string doi_2 { get; set; }
        public string doi_3 { get; set; }
        public string doi_4 { get; set; }
        public string doi_5 { get; set; }
        public string doi_6 { get; set; }
        public string doi_status { get; set; }
        public DateTime doi_date_modified { get; set; }
    }
}
