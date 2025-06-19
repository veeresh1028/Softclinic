using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.KPIReports
{
    public class AppointmentStatusReport
    {
        public DateTime app_fdate { get; set; }
        public int Booked { get; set; }
        public int Enquiry { get; set; }
        public int Confirmed { get; set; }
        public int Cancelled { get; set; }
        public int Arrived { get; set; }
        public int Invoiced { get; set; }
        public int CallBack { get; set; }
        public int NoAnswer { get; set; }
        public int NoShow { get; set; }
        public int WithDoctor { get; set; }
        public int Deleted { get; set; }
        public int NurseStation { get; set; }
        public int NurseCompleted { get; set; }
        public int ConsultationCompleted { get; set; }
        public int InProcess { get; set; }
        public int Getting { get; set; }
        public int PriorRequest { get; set; }
    }

    public class AppointmentListSearch
    {
        public DateTime app_fdate { get; set; }
        public string app_status { get; set; }
    }

    public class AppointmentStatusSearch
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }
}