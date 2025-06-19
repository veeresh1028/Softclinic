using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class CentralNervous
    {
        public static bool isValidCentralNervous(BusinessEntities.EMR.CentralNervous data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cn_9))
                {
                    errors.Add("cn_9", "Others is Required");
                }


            }
            else
            {
                errors.Add("cn_9", "Others is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
