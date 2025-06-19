using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConsentForms
{
    public class RegeneraConsent
    {
        public static DataTable GetRegeneraConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Regenera_Treatment_Consent_Select");

                db.AddInParameter(dbCommand, "rtc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveRegeneraConsent(BusinessEntities.ConsentForms.RegeneraConsent regenera, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Regenera_Treatment_Consent_Insert");

                db.AddInParameter(dbCommand, "rtc_appId", DbType.Int32, regenera.rtc_appId);
                db.AddInParameter(dbCommand, "rtc_1", DbType.String, string.IsNullOrEmpty(regenera.rtc_1) ? "" : regenera.rtc_1);
                db.AddInParameter(dbCommand, "rtc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "rtcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _rtcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "rtcId"));
                return _rtcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int DeleteRegeneraConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Regenera_Treatment_Consent_Delete");

                db.AddInParameter(dbCommand, "rtc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "rtc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "rtc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _rtc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "rtc_output"));

                return _rtc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetRegeneraConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Regenera_Treatment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "rtc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
