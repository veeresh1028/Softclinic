using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class LinkCouponsToProcedure
    {
        public static bool isValidLinkCouponsToProcedure(BusinessEntities.Masters.LinkCouponsToProcedure data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
               
                if (!(data.dtl_discId > 0))
                {
                    errors.Add("dtl_discId", "Discount is Required");
                }
                if (string.IsNullOrEmpty(data.dtl_tr_code))
                {
                    errors.Add("dtl_tr_code", "Procedure is Required");
                }
               

            }
            else
            {
                errors.Add("dtl_discId", "Discount is Required");
                errors.Add("dtl_tr_code", "Procedure is Required");
               
            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
