using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FillerInjection
    {
        public static bool isValidFillerInjection(BusinessEntities.ConsentForms.FillerInjection data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.fif_1))
                {
                    errors.Add("fif_1", "Please Enter Treatment");
                }

            }
            else
            {
                errors.Add("fif_1", "Please Enter Treatment");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
