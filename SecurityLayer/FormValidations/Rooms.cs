using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLayer.FormValidations
{
    public class Rooms
    {
        public static bool isValidRooms(BusinessEntities.Masters.Rooms data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.room))
                {
                    errors.Add("room", "Rooms is Required");
                }
                if (string.IsNullOrEmpty(data.room_branch))
                {
                    errors.Add("room_branch", "Branch is Required");
                }

            }
            else
            {
                errors.Add("room", "Rooms is Required");
                errors.Add("room_branch", "Branch is Required");

            }


            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
