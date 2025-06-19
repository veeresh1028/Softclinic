using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Coupons
    {
        public static bool isValidCoupons(BusinessEntities.Masters.Coupons data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.disc_name))
                {
                    errors.Add("disc_name", "Coupon Name is Required");
                }
                if (string.IsNullOrEmpty(data.disc_branches))
                {
                    errors.Add("disc_branches", "Branch is Required");
                }
                if (!(data.disc_float > 0))
                {
                    errors.Add("disc_float", "Coupon Amount is Required");
                }
            }
            else
            {
                errors.Add("disc_name", "Coupon Name is Required");
                errors.Add("disc_branches", "Branch is Required");
                errors.Add("disc_float", "Coupon Discount is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
