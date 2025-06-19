using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class BlepharotomyDrainage
    {
        public int bdnId { get; set; }
        public int bdn_appId { get; set; }
        public string bdn_status { get; set; }
        public DateTime bdn_date_modified { get; set; }
    }
}
