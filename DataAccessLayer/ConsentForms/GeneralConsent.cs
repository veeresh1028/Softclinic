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
    public class GeneralConsent
    {
        public static DataTable GetFillerConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Treatment_Consent_Select");

                db.AddInParameter(dbCommand, "gtc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveGeneralConsent(BusinessEntities.ConsentForms.GeneralConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Treatment_Consent_Insert");

                db.AddInParameter(dbCommand, "gtc_appId", DbType.Int32, crown.gtc_appId);
                db.AddInParameter(dbCommand, "gtc_1", DbType.String, string.IsNullOrEmpty(crown.gtc_1) ? "" : crown.gtc_1);
                db.AddInParameter(dbCommand, "gtc_2", DbType.String, string.IsNullOrEmpty(crown.gtc_2) ? "" : crown.gtc_2);
                db.AddInParameter(dbCommand, "gtc_3", DbType.String, string.IsNullOrEmpty(crown.gtc_3) ? "" : crown.gtc_3);

                db.AddInParameter(dbCommand, "gtc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "gtcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _gtcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "gtcId"));
                return _gtcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteGeneralConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Treatment_Consent_Delete");

                db.AddInParameter(dbCommand, "gtc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "gtc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "gtc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _gtc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "gtc_output"));

                return _gtc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetGeneralConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_General_Treatment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "gtc_appId", DbType.Int32, appId);
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
