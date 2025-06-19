using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class EyeFormNew3
    {
        public int efn3Id { get; set; }
        public int efn3_appId { get; set; }
        public string efn3_1 { get; set; }
        public string efn3_doc { get; set; }
        public string efn3_status { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string efn3_date_created { get; set; }
        public DateTime efn3_date_modified { get; set; }
    }
}
