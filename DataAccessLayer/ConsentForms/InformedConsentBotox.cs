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
    public class InformedConsentBotox
    {
        public static DataTable GetInformedConsentBotoxData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Botox_Derma_Select");

                db.AddInParameter(dbCommand, "icb_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveInformedConsentBotox(BusinessEntities.ConsentForms.InformedConsentBotox derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Botox_Derma_Insert");

                db.AddInParameter(dbCommand, "icb_appId", DbType.Int32, derma.icb_appId);
                db.AddInParameter(dbCommand, "icb_1", DbType.String, string.IsNullOrEmpty(derma.icb_1) ? "" : derma.icb_1);
                db.AddInParameter(dbCommand, "icb_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "icbId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _icbId = Convert.ToInt32(db.GetParameterValue(dbCommand, "icbId"));
                return _icbId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteInformedConsentBotox(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Botox_Derma_Delete");

                db.AddInParameter(dbCommand, "icb_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "icb_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "icb_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _icb_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "icb_output"));

                return _icb_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetInformedConsentBotoxPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Botox_Derma_PreviousHistory");

                db.AddInParameter(dbCommand, "icb_appId", DbType.Int32, appId);
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
