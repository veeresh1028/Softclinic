using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class AmityFormDental
    {
        public static bool isValidAmityFormDental(BusinessEntities.InsuranceForms.AmityFormDental data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mpd_pre))
                {
                    errors.Add("mpd_pre", "Please Enter Pre Authorisation Number");
                }

            }
            else
            {
                errors.Add("mpd_pre", "Please Enter Pre Authorisation Number");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
