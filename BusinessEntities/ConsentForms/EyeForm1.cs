using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class EyeForm1
    {
        public int efn1Id { get; set; }
        public int efn1_appId { get; set; }
        public string efn1_1 { get; set; }
        public string efn1_doc { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string efn1_status { get; set; }
        public DateTime efn1_date_modified { get; set; }

    }
}
