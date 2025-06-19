using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ParsPlana
    {
        public int ppvId { get; set; }
        public int ppv_appId { get; set; }
        public string ppv_1 { get; set; }
        public string ppv_2 { get; set; }
        public string ppv_status { get; set; }
        public DateTime ppv_date_modified { get; set; }
    }
}
