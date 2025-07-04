﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class OperativeEyleaInjectionNew
    {
        public static bool isValidOperativeEyleaInjectionNew(BusinessEntities.ConsentForms.OperativeEyleaInjectionNew data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.orei_6))
                {
                    errors.Add("orei_6", "Please Enter Witness Name");
                }

            }
            else
            {
                errors.Add("orei_6", "Please Enter Witness Name");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
