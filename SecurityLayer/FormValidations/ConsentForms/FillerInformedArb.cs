using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FillerInformedArb
    {
        public static bool isValidFillerInformedArb(BusinessEntities.ConsentForms.FillerInformedArb data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.fica_1))
                {
                    errors.Add("fica_1", "Please Area");
                }

            }
            else
            {
                errors.Add("fica_1", "Please Enter Area");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
