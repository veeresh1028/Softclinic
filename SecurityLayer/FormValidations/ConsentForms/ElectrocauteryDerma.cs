using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class ElectrocauteryDerma
    {
        public static bool isValidElectrocauteryDerma(BusinessEntities.ConsentForms.ElectrocauteryDerma data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.elec_1))
                {
                    errors.Add("elec_1", "Please Enter Area's Of Treatment");
                }

                if (string.IsNullOrEmpty(data.elec_2))
                {
                    errors.Add("elec_2", "Please Enter Patient Initials");
                }

                if (string.IsNullOrEmpty(data.elec_3))
                {
                    errors.Add("elec_3", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("elec_1", "Please Enter Area's Of Treatment");
                errors.Add("elec_2", "Please Enter Patient Initials");
                errors.Add("elec_3", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
