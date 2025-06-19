using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Vaccinations
    {
        public static bool isValidVaccinations(BusinessEntities.Masters.Vaccinations data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {


                if (string.IsNullOrEmpty(data.v_code))
                {
                    errors.Add("v_code", "Vaccination Code is Required");
                }
                if (string.IsNullOrEmpty(data.v_name))
                {
                    errors.Add("v_name", "Vaccination Name Required");
                }
                
            }
            else
            {
                errors.Add("v_code", "Vaccination Code is Required");
                errors.Add("v_name", "Vaccination Name is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
