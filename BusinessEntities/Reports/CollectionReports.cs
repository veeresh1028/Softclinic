using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class CollectionReports
    {
        public List<CollectionWeekly> weeklyCollection { get; set; }
        public List<CollectionDepartment> deptCollections { get; set; }
        public List<CashInsReport> cashInsCollections { get; set; }
        public List<CollectionReport> collectionReports { get; set; }
    }

    public class CollectionReportSearch
    {
        public string select_branch { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    public class CollectionWeekly
    {
        public int s_no { get; set; }
        public DateTime sales_date { get; set; }
        public decimal sales { get; set; }
    }
    public class CollectionDepartment
    {
        public string department { get; set; }
        public decimal daily { get; set; }
        public decimal weekly { get; set; }
        public decimal monthly { get; set; }
        public decimal daily_sales_perc { get; set; }
    }

    public class CashInsReport
    {
        public string inv_type { get; set; }
        public decimal daily { get; set; }
        public decimal weekly { get; set; }
        public decimal monthly { get; set; }
    }

    public class CollectionReport
    {
        public string description { get; set; }
        public int dailyNos { get; set; }
        public decimal daily { get; set; }
        public int weeklyNos { get; set; }
        public decimal weekly { get; set; }
        public int monthlyNos { get; set; }
        public decimal monthly { get; set; }
    }
}