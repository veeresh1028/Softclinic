using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Accounts.Accounting
{
    public class AccountPeriod
    {
        public int apId { get; set; }
        public string ap_name { get; set; }
        public string ap_fdate { get; set; }
        public string ap_tdate { get; set; }
        public string ap_status { get; set; }
        public string ap_code { get; set; }
        public int empId { get; set; }
        public string emp_name { get; set; }
        public string actionvisible { get; set; }
    }

    public class AccountPeriodLogsList
    {
       public List<AccountPeriodLogs> accountPeriodLogsList { get; set; }
    }

    public class AccountPeriodLogs
    {
        public int apaId { get; set; }
        public int apa_apId { get; set; }
        public string apa_name { get; set; }
        public string apa_fdate { get; set; }
        public string apa_tdate { get; set; }
        public string apa_status { get; set; }
        public string apa_code { get; set; }
        public string madeby { get; set; }
        public string apa_dateCreated { get; set; }
        public string apa_operation { get; set; }
    }
}