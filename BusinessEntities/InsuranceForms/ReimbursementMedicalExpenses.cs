using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class ReimbursementMedicalExpenses
    {
        public int rmeId { get; set; }
        public int rme_appId { get; set; }
        public string rme_radio { get; set; }
        public string rme_diag { get; set; }
        public string rme_status { get; set; }
        public DateTime rme_date_created { get; set; }
        public DateTime rme_date_modified { get; set; }
    }
}
