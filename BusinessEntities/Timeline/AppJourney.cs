using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Timeline
{
    public class AppJourney
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public bool isCompleted { get; set; }
        public int PatId { get; set; }
        public string Status { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class AppJourneyData
    {
        public int CurrentIndex { get; set; }
        public string Photo { get; set; }
        public string PatientName { get; set; }
        public string MRN { get; set; }
        public string Mobile { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public List<AppJourney> BookStage { get; set; }
        public List<AppJourney> FrontDeskStage { get; set; }
        public List<AppJourney> NurseStationStage { get; set; }
        public List<AppJourney> DoctorStationStage { get; set; }
        public List<AppJourney> BillingStage { get; set; }
    }
}
