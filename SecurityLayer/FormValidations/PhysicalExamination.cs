using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class PhysicalExamination
    {
            public static bool isValidPhysicalExamination(BusinessEntities.NurseStation.PhysicalExamination data, out Dictionary<string, string> errors)
            {
                bool isValid = false;
                errors = new Dictionary<string, string>();

                if (data != null)
                {
                    if (string.IsNullOrEmpty(data.pe_1))
                    {
                        errors.Add("pe_1", "BP is Required");
                    }

                }
                else
                {
                    errors.Add("pe_1", "BP is Required");

                }


                if (errors.Count == 0)
                {
                    isValid = true;
                }

                return isValid;
            }
        
    }
}
