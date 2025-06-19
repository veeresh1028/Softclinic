using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Marketing
{
    public class Marketing
    {
        // Appointments Table
        public int appId { get; set; }
        public string app_pat_code { get; set; }
        public string app_status { get; set; }
        public string app_status2 { get; set; }
        public string app_doc_ftime { get; set; }
        public string app_doc_ttime { get; set; }
        public string app_madeby_name { get; set; }
        public string app_comments { get; set; }
        public int app_branch { get; set; }
        public int app_doctor { get; set; }
        public int app_ins { get; set; }
        public int app_source { get; set; }
        public int app_campaign { get; set; }
        public int app_patient { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_date_created { get; set; }
        // Patients Table
        public int patId { get; set; }
        public string pat_name { get; set; }
        public string pat_mob { get; set; }
        public string pat_class { get; set; }
        public string pat_email { get; set; }
        // Employees Table
        public int empId { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_license { get; set; }
        public string emp_color { get; set; }
        // Appointments Status Color Table
        public string aps_color { get; set; }
        // Nationalities Table
        public string nationality { get; set; }
        // Appointment Remarks Table
        public string remarks { get; set; }
        public DateTime ar_fllowupdate { get; set; }
        public string ar_fllowtime { get; set; }
        // Others
        public string source_details { get; set; }
        public string campaign_details { get; set; }
    }

    public class Enquiry
    {
        public int appId { get; set; }
        public int app_branch { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_tdate { get; set; }
        public int app_patient { get; set; }
        public int app_source { get; set; }
        public int app_campaign { get; set; }
        public int app_madeby { get; set; }
        public int app_ftime { get; set; }
        public int app_ttime { get; set; }
        public int app_doctor { get; set; }
        public int app_room { get; set; } = 1;
        public int app_ins { get; set; }
        public int app_rappId { get; set; } = 0;
        public int app_po { get; set; } = 0;
        public int app_service { get; set; } = 0;
        public int app_duplicate { get; set; }
        public string app_eligibility { get; set; } = string.Empty;
        public string app_emergency { get; set; }
        public string app_type { get; set; }
        public string app_inout { get; set; }
        public string app_status { get; set; }
        public string app_status2 { get; set; }
        public string app_comments { get; set; } = string.Empty;
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
        [NotMapped]
        public List<CommonDDL> StatusList { get; set; }
    }

    public class MarketingSearch
    {
        public int search_type { get; set; } = 0;
        public string branch_ids { get; set; } = string.Empty;
        public string dept_ids { get; set; } = string.Empty;
        public string doc_ids { get; set; } = string.Empty;
        public string nats_ids { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public int patient { get; set; } = 0;
        public string handledby { get; set; } = string.Empty;
        public string sources { get; set; } = string.Empty;
        public string campaigns { get; set; } = string.Empty;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("1900-01-01");
    }
}
