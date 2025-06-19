using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Allergies
    {
        public static bool isValidAllergies(BusinessEntities.NurseStation.Allergies data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.all_for))
                {
                    errors.Add("all_for", "Allergy For is Required");
                }

            }
            else
            {
                errors.Add("all_for", "Allergy For is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
