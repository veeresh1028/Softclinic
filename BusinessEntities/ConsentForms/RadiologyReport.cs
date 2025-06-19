using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class RadiologyReport
    {
        public int rrfId { get; set; }
        public int rrf_appId { get; set; }
        public string rrf_status { get; set; }
        public DateTime rrf_date_modified { get; set; }

    }
}
