using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.Common
{
    public class Queries
    {
        public string emp_license { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public int resId { get; set; }
        public int res_query { get; set; }
        [AllowHtml]
        public string res_desc { get; set; }
        public string res_query_desc { get; set; }
        public int res_from { get; set; }
        public int res_to { get; set; }
        public DateTime res_date_created { get; set; }
        public DateTime res_date_modified { get; set; }
        public string res_read_status { get; set; }
        public string res_status { get; set; }
        public string res_from_name { get; set; }
        public string res_to_name { get; set; }
        public string DocumentName { get; set; }
        public string Documentpath { get; set; }
        public FileInfo file { get; set; }
    }

    public class QueriesSearch
    {
        public string select_branch { get; set; } = string.Empty;
        public string select_dept { get; set; } = string.Empty;
        public string select_doctor { get; set; } = string.Empty;
        public Nullable<DateTime> select_date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> select_date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}