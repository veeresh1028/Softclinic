using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class DefaultAccounts
    {
        public string code { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string period { get; set; }
        public int branch { get; set; }
        public string current_code { get; set; }
        public string current_period { get; set; }
        public string group_name { get; set; }
        public string category_name { get; set; }
        public int empId { get; set; }
    }
    public class DefaultAccountsList
    {
        public List<DefaultAccounts> defaultAccountsList { get; set; }
    }
}
