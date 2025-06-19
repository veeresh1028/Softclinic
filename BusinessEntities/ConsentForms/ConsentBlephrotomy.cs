using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ConsentBlephrotomy
    {
        public int cbnId { get; set; }
        public int cbn_appId { get; set; }
        public string cbn_status { get; set; }
        public DateTime cbn_date_modified { get; set; }

    }
}
