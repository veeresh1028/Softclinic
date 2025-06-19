using BusinessEntities.Appointment.AuditLogs;
using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.AuditLogs
{
    public class AppointmentLogs
    {
        public static List<BusinessEntities.Appointment.AuditLogs.AppointmentLogs> GetAppointmentLogs(Log log)
        {
            DataTable dt = DataAccessLayer.Appointment.AuditLogs.AppointmentLogs.GetAppointmentLogs(log);

            List<BusinessEntities.Appointment.AuditLogs.AppointmentLogs> app_log = new List<BusinessEntities.Appointment.AuditLogs.AppointmentLogs>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    app_log.Add(new BusinessEntities.Appointment.AuditLogs.AppointmentLogs
                    {
                        appaId = Convert.ToInt32(dr["appaId"]),
                        appa_appId = Convert.ToInt32(dr["appa_appId"]),
                        appa_type = dr["appa_type"].ToString(),
                        appa_inout = dr["appa_inout"].ToString(),
                        appa_name = dr["appa_name"].ToString(),                                 
                        appa_ins_name = dr["appa_ins_name"].ToString(),
                        appa_ftime_name = dr["appa_ftime_name"].ToString(),
                        appa_ttime_name = dr["appa_ttime_name"].ToString(),
                        appa_room_name = dr["appa_room_name"].ToString(),
                        appa_doctor_name = dr["appa_doctor_name"].ToString(),
                        appa_madeby_name = dr["appa_madeby_name"].ToString(),
                        appa_status = dr["appa_status"].ToString(),
                        appa_operation = dr["appa_operation"].ToString(),
                        appa_fdate = Convert.ToDateTime(dr["appa_fdate"].ToString()),
                        appa_date_modified = Convert.ToDateTime(dr["appa_date_modified"].ToString())                       
                    });
                }
            }
            return app_log;
        }
    }
}