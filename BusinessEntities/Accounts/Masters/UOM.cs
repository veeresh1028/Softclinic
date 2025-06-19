using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Masters
{
    public class UOM
    {
        public int uomId { get; set; }
        public string uom { get; set; }
        public string uom_category { get; set; }
        public string uom_status { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
    }
}
