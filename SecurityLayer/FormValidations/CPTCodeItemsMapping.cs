using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class CPTCodeItemsMapping
    {
        public static bool isValidCPTCodeItemsMapping(BusinessEntities.Masters.CPTCodeItemsMapping data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.cpt_qty))
                {
                    errors.Add("cpt_qty", "QTY is Required");
                }
                if (string.IsNullOrEmpty(data.cpt_code))
                {
                    errors.Add("cpt_code", "CPT Code is Required");
                }
                if (string.IsNullOrEmpty(data.cpt_uom))
                {
                    errors.Add("cpt_uom", "UOM is Required");
                }
                if (string.IsNullOrEmpty(data.cpt_item))
                {
                    errors.Add("cpt_item", "Item is Required");
                }
            }
            else
            {
                errors.Add("cpt_qty", "Quantity is Required");
                errors.Add("cpt_code", "CPT Code is Required");
                errors.Add("cpt_item", "Item is Required");
                errors.Add("cpt_uom", "UOM is Required");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
