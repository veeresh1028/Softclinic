using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class RespiratorySystem
    {
        public static bool isValidRespiratorySystem(BusinessEntities.EMR.RespiratorySystem data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.res_1))
                {
                    errors.Add("res_1", "Chest is Required");
                }

            }
            else
            {
                errors.Add("res_1", "Chest is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
