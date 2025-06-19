using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class AftercareLeafletForm
    {
        public int alfId { get; set; }
        public int alf_appId { get; set; }
        public string alf_status { get; set; }
        public DateTime alf_date_modified { get; set; }
    }
}
