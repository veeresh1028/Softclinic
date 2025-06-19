using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class MinorsPsychotherapyConsent
    {
        public int mpcId { get; set; }
        public int mpc_appId { get; set; }
        public string mpc_wit { get; set; }
        public string mpc_RelationshipStatus { get; set; }
        public string mpc_session { get; set; }
        public string mpc_living { get; set; }
        public string mpc_radio1 { get; set; }
        public string mpc_provider { get; set; }
        public string mpc_chk1 { get; set; }
        public string mpc_chk2 { get; set; }
        public string mpc_radio2 { get; set; }
        public string mpc_name { get; set; }
        public string mpc_mobile { get; set; }
        public string mpc_Relationship { get; set; }
        public string mpc_radio3 { get; set; }
        public DateTime mpc_date1 { get; set; }
        public string mpc_radio4 { get; set; }
        public DateTime mpc_date2 { get; set; }
        public string mpc_other { get; set; }
        public string mpc_general { get; set; }
        public string mpc_medication1 { get; set; }
        public string mpc_medication2 { get; set; }
        public string mpc_status { get; set; }
        public DateTime mpc_date_modified { get; set; }
    }
}
