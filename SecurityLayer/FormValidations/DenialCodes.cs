using BusinessEntities;
using BusinessEntities.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class DenialCodes
    {
        public static bool isValidDenialCode(BusinessEntities.Masters.DenialCodes data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.dc_code))
                {
                    errors.Add("dc_code", "Denial Code is Required");
                }
                if (string.IsNullOrEmpty(data.dc_desc))
                {
                    errors.Add("dc_desc", "Description is Required");
                }

            }
            else
            {
                errors.Add("dc_code", "Denial Code is Required");
                errors.Add("dc_desc", "Description is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
