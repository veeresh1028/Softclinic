using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class NasAdviceForm
    {
        public int nafId { get; set; }
        public int naf_appId { get; set; }
        public string naf_1 { get; set; }
        public string naf_chk { get; set; }
        public string naf_status { get; set; }
        public DateTime naf_date_created { get; set; }
        public DateTime naf_date_modified { get; set; }
    }
}
