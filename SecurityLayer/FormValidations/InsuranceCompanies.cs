using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class InsuranceCompanies
    {
        public static bool isValidInsuranceCompanyCreate(BusinessEntities.Masters.InsuranceCompanies data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.ic_branch > 0))
                {
                    errors.Add("ic_branch", "Please Select Branch");
                }
                if (string.IsNullOrEmpty(data.ic_type))
                {
                    errors.Add("ic_type", "Insurance Type is Required");
                }
                if (!(data.ic_country > 0))
                {
                    errors.Add("ic_country", "Please Select Country");
                }
                if (string.IsNullOrEmpty(data.ic_name))
                {
                    errors.Add("ic_name", "Insurance Name is Required");
                }
                if (string.IsNullOrEmpty(data.ic_code))
                {
                    errors.Add("ic_code", "Receiver Code is Required");
                }
            }
            else
            {
                errors.Add("ic_branch", "Please Select Branch");
                errors.Add("ic_type", "Type is Required");
                errors.Add("ic_country", "Please Select Country");
                errors.Add("ic_name", "Insurance Name is Required");
                errors.Add("ic_code", "Receiver Code is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidInsuranceCompanyUpdate(BusinessEntities.Masters.InsuranceCompanies data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (!(data.ic_branch > 0))
                {
                    errors.Add("uic_branch", "Please Select Branch");
                }
                if (string.IsNullOrEmpty(data.ic_type))
                {
                    errors.Add("uic_type", "Insurance Type is Required");
                }
                if (!(data.ic_country > 0))
                {
                    errors.Add("uic_country", "Please Select Country");
                }
                if (string.IsNullOrEmpty(data.ic_name))
                {
                    errors.Add("uic_name", "Insurance Name is Required");
                }
                if (string.IsNullOrEmpty(data.ic_code))
                {
                    errors.Add("uic_code", "Receiver Code is Required");
                }
            }
            else
            {
                errors.Add("uic_branch", "Please Select Branch");
                errors.Add("uic_type", "Type is Required");
                errors.Add("uic_country", "Please Select Country");
                errors.Add("uic_name", "Insurance Name is Required");
                errors.Add("uic_code", "Receiver Code is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidInsuranceNetworks(BusinessEntities.Masters.InsuranceNetworks data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            
            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.is_title))
                {
                    errors.Add("is_title", "Network Title is Required");
                }
            }
            else
            {
                errors.Add("is_title", "Network Title is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidInsuranceNetworksUpdate(BusinessEntities.Masters.InsuranceNetworks data, out Dictionary<string, string> errors)
        {
            bool isValid = false;

            errors = new Dictionary<string, string>();

            if (data != null)
            {

                if (string.IsNullOrEmpty(data.is_title))
                {
                    errors.Add("uis_title", "Network Title is Required");
                }
            }
            else
            {
                errors.Add("uis_title", "Network Title is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}