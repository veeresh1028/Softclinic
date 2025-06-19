using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class EyeFormNew4
    {
        public int efn4Id { get; set; }
        public int efn4_appId { get; set; }
        public string efn4_1 { get; set; }
        public string efn4_doc { get; set; }
        public string efn4_status { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string efn4_date_created { get; set; }
        public DateTime efn4_date_modified { get; set; }
    }
}
