using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Marketing.Reports
{
    public class YearlyReport
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public string select_year { get; set; }
        public static IDictionary<int, string> MonthList()
        {
            IDictionary<int, string> months = new Dictionary<int, string>();
            months.Add(1, "January");
            months.Add(2, "February");
            months.Add(3, "March");
            months.Add(4, "April");
            months.Add(5, "May");
            months.Add(6, "June");
            months.Add(7, "July");
            months.Add(8, "August");
            months.Add(9, "September");
            months.Add(10, "October");
            months.Add(11, "November");
            months.Add(12, "December");

            return months;
        }
    }

    public class YearlyReportManagedBy
    {
        public DataTable report { get; set; }
        public List<string> managed_by { get; set; }
    }

    public class YearlyHistory
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

    public class YearlySourceReport
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public string select_year { get; set; }
    }

    public class YearlySourceReportData
    {
        public DataTable report { get; set; }
        public List<string> sources { get; set; }
    }

    public class YearlySourceHistory
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