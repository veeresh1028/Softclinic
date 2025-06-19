using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Referals
    {
        public static bool isValidReferal(BusinessEntities.Masters.Referals data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ref_type))
                {
                    errors.Add("ref_type", "Type is Required");
                }
                if (string.IsNullOrEmpty(data.ref_name))
                {
                    errors.Add("ref_name", "Name is Required");
                }
                if (string.IsNullOrEmpty(data.ref_mob))
                {
                    errors.Add("ref_mob", "Mobile is Required");
                }
                if (!(data.ref_country > 0)) 
                {
                    errors.Add("ref_country", "Country Required");
                }

            }
            else
            {
                errors.Add("ref_type", "Type is Required");
                errors.Add("ref_name", "Name is Required");
                errors.Add("ref_mob", "Mobile is Required");
                errors.Add("ref_country", "Country is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
