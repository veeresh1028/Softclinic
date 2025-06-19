using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class RootCanalArabic
    {
        public static bool isValidRootCanalArabic(BusinessEntities.ConsentForms.RootCanalArabic data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.crcta_1))
                {
                    errors.Add("crcta_1", "Please Enter Age");
                }

                if (string.IsNullOrEmpty(data.crcta_2))
                {
                    errors.Add("crcta_2", "Please Enter Diagnosis");
                }
                if (string.IsNullOrEmpty(data.crcta_3))
                {
                    errors.Add("crcta_3", "Please Enter witness Id");
                }


            }
            else
            {
                errors.Add("crcta_1", "Please Enter Age");
                errors.Add("crcta_2", "Please Enter Diagnosis");
                errors.Add("crcta_3", "Please Enter witness Id");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
