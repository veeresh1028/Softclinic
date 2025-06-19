using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class AdultPsychotherapyConsent
    {
        public int apcId { get; set; }
        public int apc_appId { get; set; }
        public string apc_wit { get; set; }
        public string apc_RelationshipStatus { get; set; }
        public string apc_session { get; set; }
        public string apc_living { get; set; }
        public string apc_radio1 { get; set; }
        public string apc_provider { get; set; }
        public string apc_chk1 { get; set; }
        public string apc_chk2 { get; set; }
        public string apc_radio2 { get; set; }
        public string apc_name { get; set; }
        public string apc_mobile { get; set; }
        public string apc_Relationship { get; set; }
        public string apc_radio3 { get; set; }
        public DateTime apc_date1 { get; set; }
        public string apc_radio4 { get; set; }
        public DateTime apc_date2 { get; set; }
        public string apc_other { get; set; }
        public string apc_general { get; set; }
        public string apc_medication1 { get; set; }
        public string apc_medication2 { get; set; }
        public string apc_status { get; set; }
        public DateTime apc_date_modified { get; set; }
    }
}
