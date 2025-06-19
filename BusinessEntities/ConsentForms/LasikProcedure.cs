using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class LasikProcedure
    {
        public int lpfId { get; set; }
        public int lpf_appId { get; set; }
        public string lpf_1 { get; set; }
        public string lpf_2 { get; set; }
        public string lpf_status { get; set; }
        public DateTime lpf_date_modified { get; set; }
    }
}
