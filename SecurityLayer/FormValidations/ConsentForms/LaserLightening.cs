using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class LaserLightening
    {
        public static bool isValidLaserLightening(BusinessEntities.ConsentForms.LaserLightening data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            //if (data != null)
            //{
            //    //if (string.IsNullOrEmpty(data.icca_1))
                //{
                //    errors.Add("icca_1", "Please Enter Tooth");
                //}

                //if (string.IsNullOrEmpty(data.icca_2))
                //{
                //    errors.Add("icca_2", "Please Enter Bridge");
                //}

                //if (string.IsNullOrEmpty(data.icca_3))
                //{
                //    errors.Add("icca_3", "Please Enter Witness ID");
                //}


            //}
            //else
            //{
            //    //errors.Add("icca_1", "Please Enter Tooth");
            //    //errors.Add("icca_2", "Please Enter Bridge");
            //    //errors.Add("icca_3", "Please Enter Witness ID");

            //}

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
