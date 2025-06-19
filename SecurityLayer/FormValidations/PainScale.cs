using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class PainScale
    {

        public static bool isValidPainScale(BusinessEntities.EMR.PainScale data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.pa_pain > -1))
                {
                    errors.Add("pa_pain", "Pain is Required");
                }

            }
            else
            {
                errors.Add("pa_pain", "Pain is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
