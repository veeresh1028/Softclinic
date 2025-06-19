using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class PDCReceivable
    {
        public int recId { get; set; }
        public string rec_code { get; set; }
        public string rec_date { get; set; }
        public string rec_type { get; set; }
        public int rec_patient { get; set; }
        public decimal rec_chq { get; set; }
        public string rec_chq_no { get; set; }
        public string rec_chq_date { get; set; }
        public string rec_chq_bank { get; set; }
        public string rec_status { get; set; }
        public int rec_branch { get; set; }
        public string rec_status2 { get; set; }
        public string set_company { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string pat_mob { get; set; }



    }
    public class PDCReceivablesFilter
    {
        public int recId { get; set; }
        public int rec_branch { get; set; }
        public string rec_code { get; set; }
        public string pat_code { get; set; }
        public string rec_status { get; set; }
        public int rec_patient { get; set; }
        public string pat_mob { get; set; }
        public string from_date { get; set; }
        public string to_date { get; set; }
        public string chq_from_date { get; set; }
        public string chq_to_date { get; set; }
        public int empId { get; set; }

    }
}
