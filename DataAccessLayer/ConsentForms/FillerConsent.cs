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
    public class FillerConsent
    {
        public static DataTable GetFillerConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Consent_Select");

                db.AddInParameter(dbCommand, "fcc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveFillerConsent(BusinessEntities.ConsentForms.FillerConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Consent_Insert");

                db.AddInParameter(dbCommand, "fcc_appId", DbType.Int32, crown.fcc_appId);
                db.AddInParameter(dbCommand, "fcc_1", DbType.String, string.IsNullOrEmpty(crown.fcc_1) ? "" : crown.fcc_1);
                db.AddInParameter(dbCommand, "fcc_2", DbType.String, string.IsNullOrEmpty(crown.fcc_2) ? "" : crown.fcc_2);
                db.AddInParameter(dbCommand, "fcc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "fccId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _fccId = Convert.ToInt32(db.GetParameterValue(dbCommand, "fccId"));
                return _fccId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteFillerConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Consent_Delete");

                db.AddInParameter(dbCommand, "fcc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "fcc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "fcc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _fcc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "fcc_output"));

                return _fcc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetFillerConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Filler_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "fcc_appId", DbType.Int32, appId);
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
