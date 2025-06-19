using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment
{
    public class CommonDDL
    {
        public int id { get; set; }
        public string text { get; set; }
    }

    public class CommonDDLFORMS
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class DoctorsByDeptBranch
    {
        public string[] Departments { get; set; }
        public string[] Branches { get; set; }
    }

    public class RoomsByDeptBranch
    {
        public string[] Rooms { get; set; }
    }

    public class GetPatients
    {
        public string query { get; set; }
        public Nullable<DateTime> from_date { get; set; }
        public Nullable<DateTime> to_date { get; set; }
    }

    public class GetInsuranceCompanies
    {
        public string query { get; set; }
    }

    public class GetByName
    {
        public string id { get; set; }
        public string text { get; set; }
    }
    public class CampaignsBySources
    {
        public string[] Sources { get; set; }
    }

    public class PatientDiagnosisDDL
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class SearchQuery
    {
        public string query { get; set; }
    }

    public class PrescriptionsDDL
    {
        public string id { get; set; }
        public string text { get; set; }
    }

    public class CategoriesLoad
    {
        public string[] Branches { get; set; }
        public string Period { get; set; }
        public string[] Groups { get; set; }
    }

    public class LoadAccounts
    {
        public string branches { get; set; }
        public string period { get; set; }
        public string query { get; set; }
        public string groups { get; set; }
        public string categories { get; set; }
    }
}