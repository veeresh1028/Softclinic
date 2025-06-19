using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class MonovisionResidual
    {
        public int mwrId { get; set; }
        public int mwr_appId { get; set; }
        public string mwr_1 { get; set; }
        public string mwr_2 { get; set; }
        public string mwr_status { get; set; }
        public DateTime mwr_date_modified { get; set; }
    }
}
