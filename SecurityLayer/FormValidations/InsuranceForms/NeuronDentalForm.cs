using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class NeuronDentalForm
    {
        public static bool isValidNeuronDentalForm(BusinessEntities.InsuranceForms.NeuronDentalForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ncd_1))
                {
                    errors.Add("ncd_1", "Please Enter History");
                }

            }
            else
            {
                errors.Add("ncd_1", "Please Enter History");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
