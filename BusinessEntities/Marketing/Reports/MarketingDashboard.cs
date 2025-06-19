using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Marketing.Reports
{
    public class MarketingDashboard
    {
        public int search_type { get; set; }
        public int empId { get; set; }
        public string branch_ids { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class DashboardReport
    {
        public DashboardCount dbCount { get; set; }
        public List<DashboardManagedBy> mbList { get; set; }
        public List<DashboardSourcewise> sourceList { get; set; }
        public List<DashboardMonthwise> monthList { get; set; }
        public List<DashboardDaywise> dayList { get; set; }
        public List<DashboardStatuswise> statusList { get; set; }
    }

    public class DashboardCount
    {
        public int total_enquiries { get; set; }
        public int total_followups { get; set; }
    }

    public class DashboardManagedBy
    {
        public string app_madeby_name { get; set; }
        public int total { get; set; }
    }

    public class DashboardSourcewise
    {
        public string app_source_name { get; set; }
        public int total { get; set; }
    }

    public class DashboardMonthwise
    {
        public string month_name { get; set; }
        public int total { get; set; }
    }

    public class DashboardDaywise
    {
        public string day_name { get; set; }
        public int total { get; set; }
    }

    public class DashboardStatuswise
    {
        public string app_status { get; set; }
        public int total { get; set; }
    }
}
