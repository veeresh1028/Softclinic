using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class InjectablesTreatmentRecords
    {
        public int itrId { get; set; }
        public int itr_appId { get; set; }
        public string itr_1 { get; set; }
        public string itr_doc { get; set; }
        public string itr_status { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string itr_date_created { get; set; }

        public DateTime itr_date_modified { get; set; }
    }
}
