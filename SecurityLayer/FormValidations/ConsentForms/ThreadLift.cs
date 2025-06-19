using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ThreadLift
    {
        public static bool isValidThreadLift(BusinessEntities.ConsentForms.ThreadLift data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.tlc_1))
                {
                    errors.Add("tlc_1", "Please Enter procedure");
                }





            }
            else
            {
                errors.Add("tlc_1", "Please Enter procedure");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
