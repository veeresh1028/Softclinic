using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class DemographicForm
    {
        public int cdfId { get; set; }
        public int cdf_appId { get; set; }
        public string cdf_RelationshipStatus { get; set; }
        public string cdf_session { get; set; }
        public string cdf_living { get; set; }
        public string cdf_radio1 { get; set; }
        public string cdf_provider { get; set; }
        public string cdf_chk1 { get; set; }
        public string cdf_chk2 { get; set; }
        public string cdf_radio2 { get; set; }
        public string cdf_name { get; set; }
        public string cdf_mobile { get; set; }
        public string cdf_Relationship { get; set; }
        public string cdf_radio3 { get; set; }
        public DateTime cdf_date1 { get; set; }
        public string cdf_radio4 { get; set; }
        public DateTime cdf_date2 { get; set; }
        public string cdf_other { get; set; }
        public string cdf_general { get; set; }
        public string cdf_medication1 { get; set; }
        public string cdf_medication2 { get; set; }
        public string cdf_status { get; set; }
        public DateTime cdf_date_modified { get; set; }
    }
}
