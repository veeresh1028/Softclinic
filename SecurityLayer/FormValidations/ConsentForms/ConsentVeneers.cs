using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ConsentVeneers
    {
        public static bool isValidConsentVeneers(BusinessEntities.ConcentForms.ConsentVeneers data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            //if (data != null)
            //{
            //    if (string.IsNullOrEmpty(data.cicv_1))
            //    {
            //        errors.Add("cicv_1", "Please Select CheckBoxes");
            //    }

            //}
            //else
            //{
            //    errors.Add("cicv_1", "Please Select CheckBoxes");
              
            //}
            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
