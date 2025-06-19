using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class FillerInformed
    {
        public static bool isValidFillerInformed(BusinessEntities.ConsentForms.FillerInformed data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.fic_1))
                {
                    errors.Add("fic_1", "Please Enter Area");
                }

            }
            else
            {
                errors.Add("fic_1", "Please Enter Area");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
