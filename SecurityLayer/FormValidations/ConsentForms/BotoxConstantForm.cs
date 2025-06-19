using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class BotoxConstantForm
    {
        public static bool isValidBotoxConstantForm(BusinessEntities.ConsentForms.BotoxConstantForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.bcf_3))
                {
                    errors.Add("bcf_3", "Please Enter Treatment");
                }
            }
            else
            {
                errors.Add("bcf_3", "Please Enter Treatment");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
