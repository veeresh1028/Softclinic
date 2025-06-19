using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class ChemicalPeelingArb
    {
        public int cpfaId { get; set; }
        public int cpfa_appId { get; set; }
        public string cpfa_1 { get; set; }
        public string cpfa_status { get; set; }
        public DateTime cpfa_date_modified { get; set; }
    }
}
