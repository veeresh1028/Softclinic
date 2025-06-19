using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class ComplaintsMaster
    {
        public static bool isValidComplaintsMaster(BusinessEntities.Masters.ComplaintsMaster data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cm_title))
                {
                    errors.Add("cm_title", "Complaint Title is Required");
                }
                
            }
            else
            {
                errors.Add("cm_title", "Complaint Title is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
