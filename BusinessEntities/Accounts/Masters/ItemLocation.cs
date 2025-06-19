using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Masters
{
    public class ItemLocation
    {
        public int ilId { get; set; }
        public string il_location { get; set; }
        public string il_status { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
    }
}
