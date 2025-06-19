using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public  class MassageTherapy
    {
        public int mtcId { get; set; }
        public int mtc_appId { get; set; }
        public string mtc_1 { get; set; }
        public string mtc_status { get; set; }
        public DateTime mtc_date_modified { get; set; }
    }
}
