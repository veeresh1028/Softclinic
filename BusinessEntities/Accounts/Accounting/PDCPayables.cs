using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class PDCPayables
    {
        public int payId { get; set; }
        public string pay_code { get; set; }
        public string pay_date { get; set; }
        public string pay_type { get; set; }
        public int pay_supplier { get; set; }
        public decimal pay_chq { get; set; }
        public string pay_chq_no { get; set; }
        public string pay_chq_date { get; set; }
        public string pay_chq_bank { get; set; }
        public string pay_status { get; set; }
        public int pay_branch { get; set; }
        public string pay_status2 { get; set; }
        public string set_company { get; set; }
        public string sup_name { get; set; }
        public string sup_code { get; set; }
        public string sup_mob { get; set; }



    }
    public class PDCPayablesFilter
    {
        public int payId { get; set; }
        public int pay_branch { get; set; }
        public string pay_code { get; set; }
        public string pat_code { get; set; }
        public string pay_status { get; set; }
        public int pay_supplier { get; set; }
        public string pat_mob { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string chq_from_date { get; set; }
        public string chq_to_date { get; set; }
        public int empId { get; set; }

    }
}
