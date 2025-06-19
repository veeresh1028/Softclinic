using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DermalFillers
    {
        public int dffId { get; set; }
        public int dff_appId { get; set; }
        public string dff_1 { get; set; }
        public string dff_2 { get; set; }
        public string dff_chk { get; set; }
        public string dff_status { get; set; }
        public DateTime dff_date_modified { get; set; }
    }
}
