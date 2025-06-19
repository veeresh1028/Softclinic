using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class ToothTreatmentsCategory
    {
        public int cctId { get; set; }
        public string cct_code { get; set; }
        public string cct_category { get; set; }
        public string cct_status { get; set; }
        public string cct_sub_category { get; set; }  
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int cct_madeby { get; set; }
        public string cct_flagdeleted { get; set; }
        public string trcode_name { get; set; }
        public string trcodecategory { get; set; }
        public DateTime cct_date_created { get; set; }
        public List<GetByName> toothTreatmentsList { get; set; }
    }
}
