using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class AppointmentStatusColor
    {
        #region Appointment Status Color (Page Load)
        public static DataTable GetAppointmentStatusColor(int? apsId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_APPOINTMENTS_STATUS_select_all_info2");

                if (apsId > 0)
                {
                    db.AddInParameter(dbCommand, "apsId", DbType.Int32, apsId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Appointment Status Color CRUD Operations
        public static bool InsertUpdateAppointmentStatusColor(BusinessEntities.Masters.AppointmentStatusColor appointmentstatuscolor)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_APPOINTMENTS_STATUS_INSERT_UPDATE");

                if (appointmentstatuscolor.apsId > 0)
                {
                    db.AddInParameter(dbCommand, "apsId", DbType.Int32, appointmentstatuscolor.apsId);
                }

                db.AddInParameter(dbCommand, "aps_status", DbType.String, appointmentstatuscolor.aps_status);
                db.AddInParameter(dbCommand, "aps_color", DbType.String, appointmentstatuscolor.aps_color);
                db.AddInParameter(dbCommand, "aps_madeby", DbType.Int32, appointmentstatuscolor.aps_madeby);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateAppointmentStatusColorStatus(int apsId, string aps_activity_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_APPOINTMENTS_STATUS_update_status");

                db.AddInParameter(dbCommand, "apsId", DbType.Int32, apsId);
                db.AddInParameter(dbCommand, "aps_activity_status", DbType.String, aps_activity_status);
                db.AddOutParameter(dbCommand, "aps_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "aps_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}