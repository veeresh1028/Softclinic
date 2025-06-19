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
    public class BotoxConsent
    {
        public static DataTable GetBotoxConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Consent_Select");

                db.AddInParameter(dbCommand, "bcc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveBotoxConsent(BusinessEntities.ConsentForms.BotoxConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Consent_Insert");

                db.AddInParameter(dbCommand, "bcc_appId", DbType.Int32, crown.bcc_appId);
                db.AddInParameter(dbCommand, "bcc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "bccId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _bccId = Convert.ToInt32(db.GetParameterValue(dbCommand, "bccId"));
                return _bccId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteBotoxConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Consent_Delete");

                db.AddInParameter(dbCommand, "bcc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "bcc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "bcc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _bcc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "bcc_output"));

                return _bcc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetBotoxConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Botox_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "bcc_appId", DbType.Int32, appId);
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
