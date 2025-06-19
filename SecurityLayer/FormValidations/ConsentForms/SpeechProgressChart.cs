using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class SpeechProgressChart
    {
        public static bool isValidSpeechProgressChart(BusinessEntities.ConsentForms.SpeechProgressChart data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.spc_2))
                {
                    errors.Add("spc_2", "Please Enter Value");
                }

            }
            else
            {
                errors.Add("spc_2", "Please Enter Value");
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
