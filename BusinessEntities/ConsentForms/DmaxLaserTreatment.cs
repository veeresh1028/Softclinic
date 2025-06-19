using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DmaxLaserTreatment
    {
        public int dltId { get; set; }
        public int dlt_appId { get; set; }
        public string dlt_1 { get; set; }
        public string dlt_status { get; set; }
        public DateTime dlt_date_modified { get; set; }
    }
}
