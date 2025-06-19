using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class NasConsultationForm
    {
        public int ncfId { get; set; }
        public int ncf_appId { get; set; }
        public string ncf_1 { get; set; }
        public string ncf_2 { get; set; }
        public string ncf_3 { get; set; }
        public string ncf_chk { get; set; }
        public string ncf_radio { get; set; }
        public string ncf_status { get; set; }
        public DateTime ncf_date_created { get; set; }
        public DateTime ncf_date_modified { get; set; }
    }
}
