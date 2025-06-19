using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DoctorTreatmentTypewiseReport
    {
        public string doc_name { get; set; }
        public int patients { get; set; }
        public decimal total_consulatation { get; set; }
        public decimal total_procedure { get; set; }
        public decimal total_laboratory { get; set; }
        public decimal total_radiology { get; set; }
        public decimal total_pharmacy { get; set; }
        public decimal total_vat { get; set; }
        public decimal total_income { get; set; }
    }

    public class DoctorTreatmentTypewiseSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Now.AddYears(-1);
        public DateTime date_to { get; set; } = DateTime.Now.AddDays(1);
    }
}