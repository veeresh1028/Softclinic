using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class InvoicesEmailReport
    {
        public int SEWId { get; set; }
        public DateTime SEW_Timestamp { get; set; }
        public int SEW_ReferenceNo { get; set; }
        public string SEW_ReferenceType { get; set; }
        public string SEW_ReceiverAccount { get; set; }
        public string emp_name { get; set; }
        public string inv_no { get; set; }
    }

    public class EmailReportSearch
    {
        public string select_branch { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.AddDays(1).ToString());
    }
}