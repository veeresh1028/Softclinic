using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class ImageComparisionDocuments
    {
        public int imgcId { get; set; }
        public int imgc_appId { get; set; }
        public int imgc_patId { get; set; }
        public string imgc_notes { get; set; }
        public string imgc_image { get; set; }
        public string imgc_type { get; set; }
        public HttpPostedFileBase image { get; set; }
        [AllowHtml]
        public DateTime imgc_date_created { get; set; }
        public string imgc_status { get; set; }
        
    }
}
