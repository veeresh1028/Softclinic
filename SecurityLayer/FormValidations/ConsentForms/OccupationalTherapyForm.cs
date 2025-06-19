using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class OccupationalTherapyForm
    {
        public static bool isValidOccupationalTherapyForm(BusinessEntities.ConsentForms.OccupationalTherapyForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pot_18))
                {
                    errors.Add("pot_18", "Please Enter Long Term");
                }

            }
            else
            {
                errors.Add("pot_18", "Please Enter Long Term");
            }
            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
