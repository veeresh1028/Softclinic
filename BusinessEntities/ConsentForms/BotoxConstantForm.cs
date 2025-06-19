using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class BotoxConstantForm
    {
        public int bcfId { get; set; }
        public int bcf_appId { get; set; }
        public string bcf_1 { get; set; }
        public string bcf_2 { get; set; }
        public string bcf_3 { get; set; }
        public string bcf_chk { get; set; }
        public string bcf_status { get; set; }
        public string bcf_date_created { get; set; }
        public DateTime bcf_date_modified { get; set; }
    }
}
