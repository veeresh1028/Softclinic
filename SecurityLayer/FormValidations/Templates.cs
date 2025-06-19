using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Templates
    {
        public static bool isValidTemplate(BusinessEntities.Masters.Templates data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.TempName))
                {
                    errors.Add("TempName", "Template Name is Required");
                }
                if (string.IsNullOrEmpty(data.TempContent))
                {
                    errors.Add("TempContent", "Content is Required");
                }
                if (string.IsNullOrEmpty(data.TempFor))
                {
                    errors.Add("TempFor", "For is Required");
                }

            }
            else
            {
                errors.Add("TempName", "Template Name Required");
                errors.Add("TempContent", "Content Required");
                errors.Add("TempFor", "For is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
