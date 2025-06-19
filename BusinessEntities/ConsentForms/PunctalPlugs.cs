using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class PunctalPlugs
    {
        public int ppnId { get; set; }
        public int ppn_appId { get; set; }
        public string ppn_status { get; set; }
        public DateTime ppn_date_modified { get; set; }
    }
}
