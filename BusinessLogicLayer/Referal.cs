using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class Referal
    {
        public static DataTable GetReferals()
        {
            return DataAccessLayer.Referal.GetReferals();
        }
    }
}
