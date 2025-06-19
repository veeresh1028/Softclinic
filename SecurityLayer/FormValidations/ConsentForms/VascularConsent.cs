using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class VascularConsent
    {
        public static bool isValidVascularConsent(BusinessEntities.ConsentForms.VascularConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pic_1))
                {
                    errors.Add("pic_1", "Please Enter Doctor Name");
                }
                if (string.IsNullOrEmpty(data.pic_2))
                {
                    errors.Add("pic_2", "Please Enter Phone Number");
                }
                

            }
            else
            {
                errors.Add("pic_1", "Please Enter Doctor Name");
                errors.Add("pic_2", "Please Enter Phone Number");
                
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
