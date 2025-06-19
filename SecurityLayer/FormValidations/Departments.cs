using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Departments
    {
        public static bool isValidDepartments(BusinessEntities.Masters.Departments data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.department))
                {
                    errors.Add("department", "Department is Required");
                }
                if (string.IsNullOrEmpty(data.dept_flag))
                {
                    errors.Add("dept_flag", "Category is Required");
                }
            }
            else
            {
                errors.Add("department", "Department is Required");
                errors.Add("dept_flag", "Category is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
