using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FacialTreatmentDerma
    {
        public static bool isValidFacialTreatmentDerma(BusinessEntities.ConsentForms.FacialTreatmentDerma data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ftf_1))
                {
                    errors.Add("ftf_1", "Please Enter area(s)");
                }
            }
            else
            {
                errors.Add("ftf_1", "Please Enter area(s)");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
