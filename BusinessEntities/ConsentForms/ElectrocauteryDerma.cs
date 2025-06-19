using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ElectrocauteryDerma
    {
        public int elecId { get; set; }
        public int elec_appId { get; set; }
        public string elec_1 { get; set; }
        public string elec_2 { get; set; }
        public string elec_3 { get; set; }
        public string elec_status { get; set; }
        public DateTime elec_date_modified { get; set; }
    }
}
