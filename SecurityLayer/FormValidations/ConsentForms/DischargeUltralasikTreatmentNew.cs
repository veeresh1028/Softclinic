using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DischargeUltralasikTreatmentNew
    {
        public static bool isValidDischargeUltralasikTreatmentNew(BusinessEntities.ConsentForms.DischargeUltralasikTreatmentNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dsut_6))
                {
                    errors.Add("dsut_6", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("dsut_6", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
