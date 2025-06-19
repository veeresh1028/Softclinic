using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class BodyWrap
    {
        public static bool isValidBodyWrap(BusinessEntities.ConsentForms.BodyWrap data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.bwc_1))
                {
                    errors.Add("bwc_1", "Please Enter Name");
                }

            }
            else
            {
                errors.Add("bwc_1", "Please Enter Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
