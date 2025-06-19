using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Marketing.Reports
{
    public class DailyReport
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class DailyReportManagedBy
    {
        public DataTable report { get; set; }
        public List<string> managed_by { get; set; }
    }

    public class DailyHistory
    {
        public int appId { get; set; }
        public string app_status { get; set; }
        public string emp_name { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string source_details { get; set; }
        public string campaign_details { get; set; }
        public string app_comments { get; set; }
        public string app_madeby_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_date_created { get; set; }
    }

    public class DailyReportSource
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class DailyReportBySource
    {
        public DataTable report { get; set; }
        public List<string> by_sources { get; set; }
    }

    public class DailySourceHistory
    {
        public int appId { get; set; }
        public string app_status { get; set; }
        public string emp_name { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string source_details { get; set; }
        public string campaign_details { get; set; }
        public string app_comments { get; set; }
        public string app_madeby_name { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_date_created { get; set; }
    }
}
