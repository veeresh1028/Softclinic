using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FrontDesk
{
    public class GeneralConsent
    {
        public static DataTable GetAppointmentPatient(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Appointment_Patient_select_all_info");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int DeleteGeneralConsent(int gcfId, string gcf_status,int gcf_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_CONSENT_FORM_DELETE");

                db.AddInParameter(dbCommand, "gcfId", DbType.Int32, gcfId);
                db.AddInParameter(dbCommand, "gcf_status", DbType.String, gcf_status);
                db.AddInParameter(dbCommand, "gcf_madeby", DbType.String, gcf_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertUpdateGeneralConsent(BusinessEntities.FrontDesk.GeneralConsent data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_CONSENT_FORM_INSERT_UPDATE");
                if (data.gcfId > 0)
                {
                    db.AddInParameter(dbCommand, "gcfId", DbType.Int32, data.gcfId);
                }
                db.AddInParameter(dbCommand, "gcf_appId", DbType.Int32, data.gcf_appId);
                db.AddInParameter(dbCommand, "gcf_witness", DbType.String, data.gcf_witness);
                db.AddInParameter(dbCommand, "gcf_madeby", DbType.Int32, data.gcf_madeby);

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

        public static DataTable GetGeneralConsentAll(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GENERAL_CONSENT_FORM_select_all_info");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
