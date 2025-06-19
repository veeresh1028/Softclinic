using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class MessageType
    {
        public static bool isValidMessagetype(BusinessEntities.Masters.MessageType data, out Dictionary<string, string> errors)
        {
            bool isValid = false;

            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mt_type))
                {
                    errors.Add("mt_type", "Type is Required");
                }
                if (!(data.mt_branch > 0))
                {
                    errors.Add("mt_branch", "Branch is Required");
                }
                if (!(data.mt_desig > 0))
                {
                    errors.Add("mt_desig", "Designation is Required");
                }
                if (!(data.mt_emp > 0))
                {
                    errors.Add("mt_emp", "Employee is Required");
                }
            }
            else
            {
                errors.Add("mt_type", "Type is Required");
                errors.Add("mt_branch", "Select Branch");
                errors.Add("mt_desig", "Select Designation");
                errors.Add("mt_emp", "Select Employee");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
