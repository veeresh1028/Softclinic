using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DermatologyGeneral
    {
        public int dgcId { get; set; }
        public int dgc_appId { get; set; }
        public string dgc_1 { get; set; }
        public string dgc_2 { get; set; }
        public string dgc_3 { get; set; }
        public string dgc_status { get; set; }

        public DateTime dgc_date_modified { get; set; }
    }
}
