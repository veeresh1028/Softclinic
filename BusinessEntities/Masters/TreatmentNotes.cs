using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class TreatmentNotes
    {
        public int tdnId { get; set; }
        public string tdn_code { get; set; }
        public int tdn_doctor { get; set; }
        public string tdn_notes { get; set; }
        public string tdn_status { get; set; }
    }
}