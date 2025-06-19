using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class EyeForm2
    {
        public int efn2Id { get; set; }
        public int efn2_appId { get; set; }
        public string efn2_1 { get; set; }
        public string efn2_doc { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string efn2_status { get; set; }
        public DateTime efn2_date_modified { get; set; }

    }
}
