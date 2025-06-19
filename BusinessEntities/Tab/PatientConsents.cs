using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Tab
{
    public class PatientConsents
    {

    }

    public class FormManager
    {
        public int appId { get; set; }
        public string app_type { get; set; }
    }

    public class ClaimForms
    {
        public string claimOption { get; set; }

        [NotMapped]
        public List<CommonDDLFORMS> claimOptionList { get; set; }
    }
}