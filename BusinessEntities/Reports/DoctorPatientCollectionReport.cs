using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class DoctorPatientCollectionReport
    {
        public List<DatesForReport> dates { get; set; }
        public List<DoctorsList> doctors { get; set; }
        public List<DoctorPatientCollection> collectionReport { get; set; }
    }

    public class DoctorsList
    {
        public int app_doctor { get; set; }
        public string emp_name { get; set; }
    }

    public class DatesForReport
    {
        public DateTime date { get; set; }
    }

    public class DoctorPatientCollection
    {
        public DateTime inv_date { get; set; }
        public int inv_doctor { get; set; }
        public string inv_doctor_name { get; set; }
        public int inv_pat { get; set; }
        public decimal inv_net { get; set; } = 0;
        public decimal inv_avg { get; set; } = 0;
    }

    public class DoctorwiseCollectionReport
    {
        public int app_doctor { get; set; }
        public string doctor_name { get; set; }
        public decimal total_ipatients { get; set; }
        public decimal total_inet { get; set; }
        public decimal total_iavg { get; set; }
    }

    public class DoctorPatientCollectionReportSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public string select_ins_tpa { get; set; } = string.Empty;
        public string select_scheme { get; set; } = string.Empty;
        public string select_ins_payer { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Parse("1900-01-01");
        public DateTime date_to { get; set; } = DateTime.Parse("2099-01-01");
    }
}