using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Employees
    {
        public static bool isValidCreateEmployee(BusinessEntities.Masters.Employees data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.emp_branch > 0))
                {
                    errors.Add("emp_branch", "Branch is Required");
                }
                if (string.IsNullOrEmpty(data.emp_name))
                {
                    errors.Add("emp_name", "First Name is Required");
                }
                if (string.IsNullOrEmpty(data.emp_lname))
                {
                    errors.Add("emp_lname", "Last Name is Required");
                }
                if (string.IsNullOrEmpty(data.emp_email))
                {
                    errors.Add("emp_email", "E-Mail is Required");
                }
                if (!(data.emp_dept > 0))
                {
                    errors.Add("emp_dept", "Department is Required");
                }
                if (!(data.emp_desig > 0))
                {
                    errors.Add("emp_desig", "Department is Required");
                }
                if (!(data.emp_nat > 0))
                {
                    errors.Add("emp_nat", "Nationality is Required");
                }
                if (string.IsNullOrEmpty(data.emp_mob))
                {
                    errors.Add("emp_mob", "Mobile Number is Required");
                }
                if (string.IsNullOrEmpty(data.emp_login))
                {
                    errors.Add("emp_login", "Username is Required");
                }
                if (string.IsNullOrEmpty(data.emp_pass))
                {
                    errors.Add("emp_pass", "Password is Required");
                }
                if (string.IsNullOrEmpty(data.emp_work_branch))
                {
                    errors.Add("emp_work_branch", "Working Branch(es) is Required");
                }
                if (string.IsNullOrEmpty(data.emp_outside_access))
                {
                    data.emp_outside_access = "Allowed";
                }

            }
            else
            {
                errors.Add("emp_branch", "Branch is Required");
                errors.Add("emp_name", "First Name is Required");
                errors.Add("emp_lname", "Last Name is Required");
                errors.Add("emp_dept", "Department is Required");
                errors.Add("emp_desig", "Designation is Required");
                errors.Add("emp_nat", "Nationality is Required");
                errors.Add("emp_email", "E-mail is Required");
                errors.Add("emp_mob", "Mobile Number is Required");
                errors.Add("emp_login", "Username is Required");
                errors.Add("emp_pass", "Password is Required");
                errors.Add("emp_work_branch", "Working Branch(es) is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidUpdateEmployee(BusinessEntities.Masters.Employees data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.emp_branch > 0))
                {
                    errors.Add("uemp_branch", "Branch is Required");
                }
                if (string.IsNullOrEmpty(data.emp_name))
                {
                    errors.Add("uemp_name", "First Name is Required");
                }
                if (string.IsNullOrEmpty(data.emp_lname))
                {
                    errors.Add("uemp_lname", "Last Name is Required");
                }
                if (string.IsNullOrEmpty(data.emp_email))
                {
                    errors.Add("uemp_email", "E-Mail is Required");
                }
                if (!(data.emp_dept > 0))
                {
                    errors.Add("uemp_dept", "Department is Required");
                }
                if (!(data.emp_desig > 0))
                {
                    errors.Add("uemp_desig", "Department is Required");
                }
                if (!(data.emp_nat > 0))
                {
                    errors.Add("uemp_nat", "Nationality is Required");
                }
                if (string.IsNullOrEmpty(data.emp_mob))
                {
                    errors.Add("uemp_mob", "Mobile Number is Required");
                }
                if (string.IsNullOrEmpty(data.emp_login))
                {
                    errors.Add("uemp_login", "Username is Required");
                }
                if (string.IsNullOrEmpty(data.emp_pass))
                {
                    errors.Add("uemp_pass", "Password is Required");
                }
                if (string.IsNullOrEmpty(data.emp_work_branch))
                {
                    errors.Add("uemp_work_branch", "Working Branch(es) is Required");
                }
            }
            else
            {
                errors.Add("uemp_branch", "Branch is Required");
                errors.Add("uemp_name", "First Name is Required");
                errors.Add("uemp_lname", "Last Name is Required");
                errors.Add("uemp_dept", "Department is Required");
                errors.Add("uemp_desig", "Designation is Required");
                errors.Add("uemp_nat", "Nationality is Required");
                errors.Add("uemp_email", "E-mail is Required");
                errors.Add("uemp_mob", "Mobile Number is Required");
                errors.Add("uemp_login", "Username is Required");
                errors.Add("uemp_pass", "Password is Required");
                errors.Add("uemp_work_branch", "Working Branch(es) is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
