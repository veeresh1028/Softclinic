using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class RevisionRequestForm
    {
        public int rrfId { get; set; }
        public int rrf_appId { get; set; }
        public string rrf_date1 { get; set; }
        public string rrf_date2 { get; set; }
        public string rrf_date3 { get; set; }
        public string rrf_1 { get; set; }
        public string rrf_2 { get; set; }
        public string rrf_3 { get; set; }
        public string rrf_4 { get; set; }
        public string rrf_5 { get; set; }
        public string rrf_6 { get; set; }
        public string rrf_7 { get; set; }
        public string rrf_status { get; set; }
        public DateTime rrf_date_modified { get; set; }
    }
}
