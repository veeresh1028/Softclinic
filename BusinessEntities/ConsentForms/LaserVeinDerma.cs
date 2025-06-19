using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class LaserVeinDerma
    {
        public int lvcId { get; set; }
        public int lvc_appId { get; set; }
        public string lvc_1 { get; set; }
        public string lvc_2 { get; set; }
        public string lvc_status { get; set; }
        public DateTime lvc_date_modified { get; set; }
    }
}
