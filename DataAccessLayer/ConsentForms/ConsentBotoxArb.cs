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
    public class ConsentBotoxArb
    {
        public static DataTable GetConsentBotoxArbData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Botox_Arb_Derma_Select");

                db.AddInParameter(dbCommand, "cba_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveConsentBotoxArb(BusinessEntities.ConsentForms.ConsentBotoxArb derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Botox_Arb_Derma_Insert");

                db.AddInParameter(dbCommand, "cba_appId", DbType.Int32, derma.cba_appId);
                db.AddInParameter(dbCommand, "cba_1", DbType.String, string.IsNullOrEmpty(derma.cba_1) ? "" : derma.cba_1);
                db.AddInParameter(dbCommand, "cba_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cbaId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cbaId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cbaId"));
                return _cbaId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteConsentBotoxArb(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Botox_Arb_Derma_Delete");

                db.AddInParameter(dbCommand, "cba_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cba_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cba_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cba_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cba_output"));

                return _cba_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetConsentBotoxArbPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Consent_Botox_Arb_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "cba_appId", DbType.Int32, appId);
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
