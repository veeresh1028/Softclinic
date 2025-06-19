using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class MicroInformed
    {
        public static bool isValidMicroInformed(BusinessEntities.ConsentForms.MicroInformed data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            //if (data != null)
            //{
            //    if (string.IsNullOrEmpty(data.cef_1))
            //    {
            //        errors.Add("cef_1", "Please Enter Treatment Site");
            //    }
            //}
            //else
            //{
            //    errors.Add("cef_1", "Please Enter Treatment Site");
            //}

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
