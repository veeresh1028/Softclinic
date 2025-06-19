using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class AdnicClaim
    {
        public int acId { get; set; }
        public int ac_appId { get; set; }
        public string ac_voucher { get; set; }
        public string ac_rel { get; set; }
        public string ac_ins { get; set; }
        public string ac_acc { get; set; }
        public string ac_acc_details { get; set; }
        public string ac_cond { get; set; }
        public string ac_groupname { get; set; }
        public string ac_employer { get; set; }
        public string ac_set { get; set; }
        public string ac_status { get; set; }
    }
}
