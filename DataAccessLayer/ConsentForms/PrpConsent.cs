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
    public class PrpConsent
    {
        public static DataTable GetPrpConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Consent_Select");

                db.AddInParameter(dbCommand, "prp_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SavePrpConsent(BusinessEntities.ConsentForms.PrpConsent tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Consent_Insert");

                db.AddInParameter(dbCommand, "prp_appId", DbType.Int32, tooth.prp_appId);
                db.AddInParameter(dbCommand, "prp_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "prpId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _prpId = Convert.ToInt32(db.GetParameterValue(dbCommand, "prpId"));
                return _prpId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeletePrpConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Consent_Delete");

                db.AddInParameter(dbCommand, "prp_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "prp_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "prp_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _prp_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "prp_output"));

                return _prp_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPrpConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prp_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "prp_appId", DbType.Int32, appId);
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
