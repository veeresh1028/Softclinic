using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class FillerInformedArb
    {
        public int ficaId { get; set; }
        public int fica_appId { get; set; }
        public string fica_1 { get; set; }
        public string fica_status { get; set; }
        public DateTime fica_date_modified { get; set; }
    }
}
