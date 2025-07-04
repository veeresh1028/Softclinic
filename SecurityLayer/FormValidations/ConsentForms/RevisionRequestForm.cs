﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations.ConsentForms
{
    public class RevisionRequestForm
    {
        public static bool isValidRevisionRequestForm(BusinessEntities.ConsentForms.RevisionRequestForm data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.rrf_6))
                {
                    errors.Add("rrf_6", "Please Enter Other");
                }


            }
            else
            {
                errors.Add("rrf_6", "Please Enter Other");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

    }
}
