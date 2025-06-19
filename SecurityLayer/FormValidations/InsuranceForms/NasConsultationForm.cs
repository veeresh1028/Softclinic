using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class NasConsultationForm
    {
        public static bool isValidNasConsultationForm(BusinessEntities.InsuranceForms.NasConsultationForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ncf_2))
                {
                    errors.Add("ncf_2", "Please Enter Remarks");
                }
            }
            else
            {
                errors.Add("ncf_2", "Please Enter Remarks");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
