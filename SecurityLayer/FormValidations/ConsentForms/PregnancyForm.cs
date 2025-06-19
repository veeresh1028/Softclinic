using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class PregnancyForm
    {
        public static bool isValidPregnancyForm(BusinessEntities.ConsentForms.PregnancyForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ptf_52))
                {
                    errors.Add("ptf_52", "Please Enter Staff Comments");
                }

            }
            else
            {
                errors.Add("ptf_52", "Please Enter Staff Comments");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
