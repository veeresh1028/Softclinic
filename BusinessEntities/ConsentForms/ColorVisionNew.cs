using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ColorVisionNew
    {
        public int cvId { get; set; }
        public int cv_appId { get; set; }
        public string cv_1 { get; set; }
        public string cv_2 { get; set; }
        public string cv_status { get; set; }
        public DateTime cv_date_modified { get; set; }
    }
}
