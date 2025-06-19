using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class InjectablesTreatmentRecords
    {
        public static bool isValidInjectablesTreatmentRecords(BusinessEntities.ConsentForms.InjectablesTreatmentRecords data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.itr_1))
                {
                    errors.Add("itr_1", "Please Enter Product");
                }

            }
            else
            {
                errors.Add("itr_1", "Please Enter Product");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
