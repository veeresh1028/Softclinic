using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.KPIReports
{
    public class MedicationReport
    {
        public int pre_appId { get; set; }
        public DateTime visit_date { get; set; }
        public string pat_file_no { get; set; }
        public string pat_mobile { get; set; }
        public string pat_name { get; set; }
        public string ic_type { get; set; }
        public string payer_name { get; set; }
        public string doctor_name { get; set; }
        public string department_name { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string item_brand { get; set; }
        public string item_dosage { get; set; }
        public string item_strength { get; set; }
        public int pre_temp3 { get; set; }
        public int pre_temp4 { get; set; }
        public string pre_temp5 { get; set; }
        public int pre_duration { get; set; }
        public int pre_qty_type { get; set; }
        public string ra_code_desc { get; set; }
        public string pre_instr { get; set; }
        public string pre_eRxRefNo { get; set; }
    }

    public class MedicationReportSearch
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public string dept_ids { get; set; }
        public string doctor_ids { get; set; }
        public string medication { get; set; }
        public int patient { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }
}
