using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer
{
    public class EMIDValidation
    {
        public static bool isValidEMID(string emid)
        {
            var valid = false;

            emid = emid.Replace("-", "").Trim();

            if (emid.StartsWith("784"))
            {
                if (emid.Length == 15)
                {
                    valid = true;
                }
            }

            return valid;
        }
    }
}
