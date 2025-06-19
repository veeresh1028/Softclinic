using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class EnhancementProcedure
    {
        public int cepId { get; set; }
        public int cep_appId { get; set; }
        public string cep_1 { get; set; }
        public string cep_2 { get; set; }
        public string cep_status { get; set; }
        public DateTime cep_date_modified { get; set; }
    }
}
