using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.InsuranceForms
{
    public class AdnicClaim
    {
        public static bool isValidAdnicClaim(BusinessEntities.InsuranceForms.AdnicClaim data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ac_voucher))
                {
                    errors.Add("ac_voucher", "Please Enter Voucher No");
                }

                //if (string.IsNullOrEmpty(data.ac_rel))
                //{
                //    errors.Add("ac_rel", "Please Enter relationship");
                //}

                //if (string.IsNullOrEmpty(data.ac_ins))
                //{
                //    errors.Add("ac_ins", "Please Enter other insurer");
                //}

                //if (string.IsNullOrEmpty(data.ac_acc))
                //{
                //    errors.Add("ac_acc", "Please Enter accident");
                //}

                if (string.IsNullOrEmpty(data.ac_acc_details))
                {
                    errors.Add("ac_acc_details", "Please Enter details");
                }

                if (string.IsNullOrEmpty(data.ac_cond))
                {
                    errors.Add("ac_cond", "Please Enter Conditions");
                }

                if (string.IsNullOrEmpty(data.ac_groupname))
                {
                    errors.Add("ac_groupname", "Please Enter Group Member's Name");
                }

                if (string.IsNullOrEmpty(data.ac_employer))
                {
                    errors.Add("ac_employer", "Please Enter Employer's Name");
                }

                if (string.IsNullOrEmpty(data.ac_set))
                {
                    errors.Add("ac_set", "Please Enter set of illness");
                }
            }
            else
            {
                errors.Add("ac_voucher", "Please Enter Voucher No");
                //errors.Add("ac_rel", "Please Enter relationship");
                //errors.Add("ac_ins", "Please Enter other insurer");
                //errors.Add("ac_acc", "Please Enter accident");
                errors.Add("ac_acc_details", "Please Enter details");
                errors.Add("ac_cond", "Please Enter Conditions");
                errors.Add("ac_groupname", "Please Enter Group Member's Name");
                errors.Add("ac_employer", "Please Enter Employer's Name");
                errors.Add("ac_set", "Please Enter set of illness");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
