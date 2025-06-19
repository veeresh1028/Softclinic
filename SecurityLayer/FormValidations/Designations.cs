using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Designations
    {
        public static bool isValidCreateDesignation(BusinessEntities.Masters.Designations data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.designation))
                {
                    errors.Add("designation", "Designation is Required");
                }
                else
                {
                    if (data.designation.Length < 3)
                    {
                        errors.Add("designation", "Designation should be minimum 3 characters");
                    }
                }
            }
            else
            {
                errors.Add("designation", "Designation is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidUpdateDesignation(BusinessEntities.Masters.Designations data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.designation))
                {
                    errors.Add("udesignation", "Designation is Required");
                }
                else
                {
                    if (data.designation.Length < 3)
                    {
                        errors.Add("udesignation", "Designation should be minimum 3 characters");
                    }
                }
            }
            else
            {
                errors.Add("udesignation", "Designation is Required");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
