using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment.AuditLogs
{
    public class AppointmentLogs
    {
        public int appaId { get; set; }
        public int appa_appId { get; set; }
        public string appa_type { get; set; }
        public string appa_inout { get; set; }
        public string appa_operation { get; set; }
        public string appa_status { get; set; }
        public string appa_doctor_name { get; set; }
        public string appa_room_name { get; set; }
        public string appa_ftime_name { get; set; }
        public string appa_ttime_name { get; set; }
        public string appa_ins_name { get; set; }
        public string appa_madeby_name { get; set; }
        public string appa_name { get; set; }
        public DateTime appa_fdate { get; set; }
        public DateTime appa_date_modified { get; set; }
    }
    public class Log
    {
        public int appaId { get; set; }
    }
}