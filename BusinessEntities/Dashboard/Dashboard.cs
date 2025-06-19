using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Dashboard
{
    public class Dashboard
    {
        public DashboardCashInsSales dbSales { get; set; }
        public DashboardTotalCollections dbCollections { get; set; }
        public List<DashboardAppointmentTypes> dbAppTypes { get; set; }
        public List<DashboardPatientCollections> patientCollections { get; set; }
        public List<DashboardInvRecMonth> invRecMonth { get; set; }
        public List<BusinessEntities.Marketing.Reports.DashboardStatuswise> appStatusList { get; set; }
        public List<DashboardCollectionByDoctor> collectionByDoctors { get; set; }
        public List<DashboardRevenueByInsCompanies> RevenueByInsCompanies { get; set; }
        public List<DashboardCollectionByMonth> collectionByMonths { get; set; }
    }

    public class DashboardSearch
    {
        public int search_type { get; set; } = 0;
        public int empId { get; set; } = 0;
        public string select_branch { get; set; } = string.Empty;
        public DateTime date_from { get; set; } = DateTime.Parse("1900-01-01");
        public DateTime date_to { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

    public class DashboardCashInsSales
    {
        public decimal total_cash_net { get; set; }
        public decimal total_ins_net { get; set; }
        public decimal total_copay { get; set; }
        public decimal total_remittance_amt { get; set; }
        public decimal total_consultation { get; set; }
        public decimal total_proc { get; set; }
        public decimal total_lab { get; set; }
        public decimal total_radiology { get; set; }
        public decimal total_pharmacy { get; set; }
    }

    public class DashboardTotalCollections
    {
        public decimal total_cash { get; set; }
        public decimal total_cc { get; set; }
        public decimal total_cheques { get; set; }
        public decimal total_bt { get; set; }
        public decimal total_advances { get; set; }
        public decimal total_allocations { get; set; }
        public decimal total_bad_debits { get; set; }
    }

    public class DashboardAppointmentTypes
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class DashboardPatientCollections
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class DashboardInvRecMonth
    {
        public string labels { get; set; }
        public decimal total { get; set; }
    }

    public class DashboardCollectionByDoctor
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class DashboardRevenueByInsCompanies
    {
        public string labels { get; set; }
        public int total { get; set; }
    }

    public class DashboardCollectionByMonth
    {
        public string labels { get; set; }
        public int total { get; set; }
    }
}