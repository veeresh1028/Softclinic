using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public  class DripTherapy
    {
        public int dtcId { get; set; }
        public int dtc_appId { get; set; }
        public string dtc_1 { get; set; }
        public string dtc_status { get; set; }

        public DateTime dtc_date_modified { get; set; }
    }
}
