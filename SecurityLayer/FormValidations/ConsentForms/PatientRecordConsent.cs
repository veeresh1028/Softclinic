using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PatientRecordConsent
    {
        public static bool isValidPatientRecordConsent(BusinessEntities.ConsentForms.PatientRecordConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
     
                if (string.IsNullOrEmpty(data.prc_11))
                {
                    errors.Add("prc_11", "Please Enter Nurses Notes");
                }

            }
            else
            {
                errors.Add("prc_11", "Please Enter Nurses Notes");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
