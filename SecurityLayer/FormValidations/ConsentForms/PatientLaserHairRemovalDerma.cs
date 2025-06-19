using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PatientLaserHairRemovalDerma
    {
        public static bool isValidPatientLaserHairRemovalDerma(BusinessEntities.ConsentForms.PatientLaserHairRemovalDerma data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.plhr_1))
                {
                    errors.Add("plhr_1", "Please Enter Remarks");
                }

            }
            else
            {
                errors.Add("plhr_1", "Please Enter Remarks");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
