using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class NasPrescriptionClaim
    {
        public int npcId { get; set; }
        public int npc_appId { get; set; }
        public string npc_1 { get; set; }
        public string npc_chk { get; set; }
        public string npc_status { get; set; }
        public DateTime npc_date_created { get; set; }
        public DateTime npc_date_modified { get; set; }
    }
}
