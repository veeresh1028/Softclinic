using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class ReviewofSystems
    {
        public static bool isValidReviewofSystems(BusinessEntities.NurseStation.ReviewofSystems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.rs_comments))
                {
                    errors.Add("rs_comments", "Comments is Required");
                }

            }
            else
            {
                errors.Add("rs_comments", "Comments is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
