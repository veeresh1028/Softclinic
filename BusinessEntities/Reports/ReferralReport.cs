using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class ReferralReport
    {
        public DataTable report { get; set; }
        public List<string> sources { get; set; }
    }

    public class ReferralReportSearch
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public string select_year { get; set; }
    }

    public class YearlyReportHistory
    {
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_gender { get; set; }
        public string pat_madeby_name { get; set; }
        public string nationality { get; set; }
        public DateTime pat_date_created { get; set; }
    }

    public class MonthlyReferralReportSearch
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public int select_month { get; set; }
        public int select_year { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class MonthlyReferralReportHistory
    {
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_gender { get; set; }
        public string pat_madeby_name { get; set; }
        public string nationality { get; set; }
        public DateTime pat_date_created { get; set; }
    }
}