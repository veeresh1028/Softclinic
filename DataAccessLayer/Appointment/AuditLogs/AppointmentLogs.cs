using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Appointment.AuditLogs
{
    public class AppointmentLogs
    {
        public static DataTable GetAppointmentLogs(BusinessEntities.Appointment.AuditLogs.Log log)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_APPOINTMENT_AUDIT_LOG");

                if (log.appaId > 0)
                {
                    db.AddInParameter(dbCommand, "appaId", DbType.String, log.appaId);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
