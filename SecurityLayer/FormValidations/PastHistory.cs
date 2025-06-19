using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class PastHistory
    {
        public static bool isValidPastHistory(BusinessEntities.NurseStation.PastHistory data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pf_other))
                {
                    errors.Add("pf_other", "Other Past History is Required");
                }

            }
            else
            {
                errors.Add("pf_other", "Other Past History is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
