using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class GastroIntestinal
    {
        public static bool isValidGastroIntestinal(BusinessEntities.EMR.GastroIntestinal data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.gi_14))
                {
                    errors.Add("gi_14", "Others is Required");
                }


            }
            else
            {
                errors.Add("gi_14", "Others is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
