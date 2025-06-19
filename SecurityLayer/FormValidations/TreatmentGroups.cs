using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class TreatmentGroups
    {
        public static bool isValidTreatmentGroups(BusinessEntities.Masters.TreatmentGroups data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {


                if (string.IsNullOrEmpty(data.tg_group))
                {
                    errors.Add("tg_group", "Coupon Name is Required");
                }
                //if (!(data.tg_cost > 0))
                //{
                //    errors.Add("tg_cost", "Branch is Required");
                //}
                //if (!(data.tg_disc > 0))
                //{
                //    errors.Add("tg_disc", "Coupon Amount is Required");
                //}
                //if (!(data.tg_vat > 0))
                //{
                //    errors.Add("tg_vat", "Coupon Amount is Required");
                //}

            }
            else
            {
                errors.Add("tg_group", "Coupon Name is Required");
                //errors.Add("tg_cost", "Branch is Required");
                //errors.Add("tg_disc", "Coupon Amount is Required");
                //errors.Add("tg_vat", "Coupon Amount is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }


        public static bool isValidPackages(BusinessEntities.Masters.Packages data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {


                if (string.IsNullOrEmpty(data.ps_services))
                {
                    errors.Add("ps_services", "Service is Required");
                }
              

            }
            else
            {
                errors.Add("ps_services", "Service is Required");
               

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
