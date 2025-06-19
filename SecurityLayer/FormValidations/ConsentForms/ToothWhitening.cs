using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConcentForms
{
    public class ToothWhitening
    {
        public static bool isValidToothWhitening(BusinessEntities.ConcentForms.ToothWhitening data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                //if (string.IsNullOrEmpty(data.icc_1))
                //{
                //    errors.Add("icc_1", "Please Enter Tooth(s)");
                //}

            }
            else
            {
                //errors.Add("icc_1", "Please Enter Tooth(s)");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
