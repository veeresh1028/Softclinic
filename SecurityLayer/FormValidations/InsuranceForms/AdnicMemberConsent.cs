using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class AdnicMemberConsent
    {
        public static bool isValidAdnicMemberConsent(BusinessEntities.InsuranceForms.AdnicMemberConsent data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.mcaf_mem_name))
                {
                    errors.Add("mcaf_mem_name", "Please Enter Group Member Name");
                }

                if (string.IsNullOrEmpty(data.mcaf_pat_name))
                {
                    errors.Add("mcaf_pat_name", "Please Enter Patient Name");
                }

                if (string.IsNullOrEmpty(data.mcaf_pat_memno))
                {
                    errors.Add("mcaf_pat_memno", "Please Enter Patient’s Membership No");
                }

                if (string.IsNullOrEmpty(data.mcaf_relationship))
                {
                    errors.Add("mcaf_relationship", "Please Enter Relationship");
                }

                if (string.IsNullOrEmpty(data.mcaf_pat_fileno))
                {
                    errors.Add("mcaf_pat_fileno", "Please Enter Patient File No");
                }

                if (string.IsNullOrEmpty(data.mcaf_auth))
                {
                    errors.Add("mcaf_auth", "Please Enter authorize");
                }

                if (string.IsNullOrEmpty(data.mcaf_auth1))
                {
                    errors.Add("mcaf_auth1", "Please Enter authorize1");
                }
            }
            else
            {
                errors.Add("mcaf_mem_name", "Please Enter Group Member Name");
                errors.Add("mcaf_pat_name", "Please Enter Patient Name");
                errors.Add("mcaf_pat_memno", "Please Enter Patient’s Membership No");
                errors.Add("mcaf_relationship", "Please Enter Relationship");
                errors.Add("mcaf_pat_fileno", "Please Enter Patient File No");
                errors.Add("mcaf_pat_mob", "Please Enter Patient Mobile No");
                errors.Add("mcaf_auth", "Please Enter authorize");
                errors.Add("mcaf_auth1", "Please Enter authorize1");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
