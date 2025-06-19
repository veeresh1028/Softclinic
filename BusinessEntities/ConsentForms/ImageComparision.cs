using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class ImageComparision
    {
        public int cicId { get; set; }
        public int cic_appId { get; set; }
        public string cic_title { get; set; }
        public string cic_discription { get; set; }
        public string cic_doc { get; set; }
        public string cic_status { get; set; }
        public DateTime cic_date_modified { get; set; }
    }

   
}
