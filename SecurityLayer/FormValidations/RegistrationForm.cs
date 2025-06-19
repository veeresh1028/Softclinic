using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class RegistrationForm
    {
        public static bool isValidRegistrationForm(BusinessEntities.FrontDesk.RegistrationForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                DateTime _dob = DateTime.Now;
                if (string.IsNullOrEmpty(data.pat_dob.ToString()))
                {
                    errors.Add("pat_dob", "DOB is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.pat_dob.ToString(), out _dob))
                    {
                        errors.Add("pat_dob", "Invalid Date of Birth");
                    }
                }
                if (!(data.pat_nat > 0))
                {
                    errors.Add("pat_nat", "Nationality is Required");
                }
                if (string.IsNullOrEmpty(data.pat_mob))
                {
                    errors.Add("pat_mob", "Mobile Number is Required");
                }
                else
                {
                    if (!(data.pat_mob.Length > 10))
                    {
                        errors.Add("pat_mob", "Mobile number is Required");
                    }
                }
                if (!(data.pat_referal > 0))
                {
                    errors.Add("pat_referal", "Referal is Required");
                }

            }
            else
            {
                errors.Add("pat_dob", "DOB is Required");
                errors.Add("pat_nat", "Nationality is Required");
                errors.Add("pat_mob", "Mobile Number is Required");
                errors.Add("pat_referal", "Referal is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
