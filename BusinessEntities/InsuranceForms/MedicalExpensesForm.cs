using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class MedicalExpensesForm
    {
        public int mefId { get; set; }
        public int mef_appId { get; set; }
        public string mef_radio{ get; set; }
        public string mef_diag { get; set; }
        public string mef_status{ get; set; }
        public DateTime mef_date_created { get; set; }
        public DateTime mef_date_modified { get; set; }
    }
}
