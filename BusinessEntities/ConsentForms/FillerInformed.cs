using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class FillerInformed
    {
        public int ficId { get; set; }
        public int fic_appId { get; set; }
        public string fic_1 { get; set; }
        public string fic_status { get; set; }
        public DateTime fic_date_modified { get; set; }
    }
}
