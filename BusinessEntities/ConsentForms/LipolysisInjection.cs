using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public  class LipolysisInjection
    {
        public int licId { get; set; }
        public int lic_appId { get; set; }
        public string lic_1 { get; set; }
        public string lic_status { get; set; }

        public DateTime lic_date_modified { get; set; }
    }
}
