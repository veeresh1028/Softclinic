using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class DentalImplants
    {
        public static bool isValidDentalImplants(BusinessEntities.ConcentForms.DentalImplants data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.pcd_1))
                {
                    errors.Add("pcd_1", "Please Enter Area of Teeth");
                }

                if (string.IsNullOrEmpty(data.pcd_2))
                {
                    errors.Add("pcd_2", "Please Enter Patient's Initials");
                }

                if (string.IsNullOrEmpty(data.pcd_3))
                {
                    errors.Add("pcd_3", "Please Enter Witness Name");
                }

                if (string.IsNullOrEmpty(data.pcd_4))
                {
                    errors.Add("pcd_4", "Please Enter Witness ID");
                }
            }
            else
            {
                errors.Add("pcd_1", "Please Enter Area of Teeth");
                errors.Add("pcd_2", "Please Enter Patient's Initials");
                errors.Add("pcd_3", "Please Enter Witness Name");
                errors.Add("pcd_4", "Please Enter Witness ID");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
