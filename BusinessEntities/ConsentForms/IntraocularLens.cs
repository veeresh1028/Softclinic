using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class IntraocularLens
    {
        public int ilpId { get; set; }
        public int ilp_appId { get; set; }
        public string ilp_1 { get; set; }
        public string ilp_2 { get; set; }
        public string ilp_status { get; set; }
        public DateTime ilp_date_modified { get; set; }

    }
}
