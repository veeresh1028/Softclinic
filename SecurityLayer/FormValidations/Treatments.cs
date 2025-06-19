using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Treatments
    {

        public static bool isValidTreatment(BusinessEntities.Masters.Treatments data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {


                if (string.IsNullOrEmpty(data.tr_name))
                {
                    errors.Add("tr_name", " Name is Required");
                }
                if (string.IsNullOrEmpty(data.tr_class))
                {
                    errors.Add("tr_class", " Classification is Required");
                }
                if (string.IsNullOrEmpty(data.tr_tooth))
                {
                    errors.Add("tr_tooth", " Teeth No is Required");
                }
                if (string.IsNullOrEmpty(data.tr_dent_option))
                {
                    errors.Add("tr_dent_option", "Prior Auth Require ?");
                }

                if (!(data.tr_ins > 0))
                {
                    errors.Add("tr_ins", "Please Select atleast Insurance");
                }
                if (!(data.tr_branch > 0))
                {
                    errors.Add("tr_branch", "Branch is Required");
                }
                DateTime _strtdate = DateTime.Now;
                if (string.IsNullOrEmpty(data.tr_start_date.ToString()))
                {
                    errors.Add("tr_start_date", "Start Date is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.tr_start_date.ToString(), out _strtdate))
                    {
                        errors.Add("tr_start_date", "Start Date of Birth");
                    }
                }

                DateTime _enddate = DateTime.Now;
                if (string.IsNullOrEmpty(data.tr_end_date.ToString()))
                {
                    errors.Add("tr_end_date", "Start Date is Required");
                }
                else
                {
                    if (!DateTime.TryParse(data.tr_end_date.ToString(), out _enddate))
                    {
                        errors.Add("tr_end_date", "Start Date of Birth");
                    }
                }


            }
            else
            {
                errors.Add("tr_name", " Name is Required");
                errors.Add("tr_class", " Classification is Required");
                errors.Add("tr_tooth", " Teeth No is Required");
                errors.Add("tr_dent_option", " Prior Auth Require ?");
                errors.Add("tr_ins", " Insurance Required");
                errors.Add("tr_branch", " Branch Required");
                

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
