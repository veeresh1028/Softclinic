using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ExcisionMultiple
    {
        public int emnId { get; set; }
        public int emn_appId { get; set; }
        public string emn_status { get; set; }
        public DateTime emn_date_modified { get; set; }

    }
}
