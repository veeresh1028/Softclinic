using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment
{
    public class S_Doctor
    {
        public string id { get; set; }
        public string title { get; set; }
        public List<WorkingHours> businessHours { get; set; }
        public S_DoctorProperties extendedProps { get; set; }
    }

    public class WorkingHours
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
        public List<int> daysOfWeek { get; set; }
    }

    //public class S_DoctorWithDP
    //{
    //    public string id { get; set; }
    //    public string title { get; set; }
    //    public string dp { get; set; }
    //}

    public class S_DoctorProperties
    {
        public string emp_color { get; set; }
        public int emp_rank { get; set; }
        public string emp_photo { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_desig_name { get; set; }
        public string emp_speciality { get; set; }
        public string emp_license { get; set; }
    }
    public class S_Invoices
    {
        public string id { get; set; }
        public string title { get; set; }
    }
}
