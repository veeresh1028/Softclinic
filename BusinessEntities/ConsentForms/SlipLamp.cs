using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class SlipLamp
    {
        public int slnId { get; set; }
        public int sln_appId { get; set; }
        public string sln_status { get; set; }
        public DateTime sln_date_modified { get; set; }
    }
}
