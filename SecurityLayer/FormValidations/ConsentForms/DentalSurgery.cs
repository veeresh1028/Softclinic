using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConcentForms
{
    public class DentalSurgery
    {
        public static bool isValidDentalSurgery(BusinessEntities.ConcentForms.DentalSurgery data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pds_1))
                {
                    errors.Add("pds_1", "Please Enter Procedure");
                }

                if (string.IsNullOrEmpty(data.pds_2))
                {
                    errors.Add("pds_2", "Please Enter Patient’s Initials");
                }

                if (string.IsNullOrEmpty(data.pds_4))
                {
                    errors.Add("pds_4", "Please Enter Witness Name");
                }
                if (string.IsNullOrEmpty(data.pds_5))
                {
                    errors.Add("pds_5", "Please Enter Witness ID");
                }


            }
            else
            {
                errors.Add("pds_1", "Please Enter Procedure");
                errors.Add("pds_2", "Please Enter Patient’s Initials");
                errors.Add("pds_4", "Please Enter Witness Name");
                errors.Add("pds_5", "Please Enter Witness ID");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
