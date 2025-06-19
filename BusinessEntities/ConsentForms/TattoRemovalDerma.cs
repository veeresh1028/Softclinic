using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class TattoRemovalDerma
    {
        public int trcId { get; set; }
        public int trc_appId { get; set; }
        public string trc_1 { get; set; }
        public string trc_status { get; set; }

        public DateTime trc_date_modified { get; set; }
    }
}
