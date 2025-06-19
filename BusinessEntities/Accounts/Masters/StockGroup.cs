using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Masters
{
    public class StockGroup
    {
        public int igId { get; set; }
        public string ig_group { get; set; }
        public string ig_status { get; set; }
        public int ig_branch { get; set; }
        public string ig_account { get; set; }
        public string actionvisible { get; set; }
        public string branch_name { get; set; }
        public int empId { get; set; }

    }
}
