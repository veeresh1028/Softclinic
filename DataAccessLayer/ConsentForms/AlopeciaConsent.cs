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
    public class AlopeciaConsent
    {
        public static DataTable GetAlopeciaConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Alopecia_Treatment_Consent_Select");

                db.AddInParameter(dbCommand, "atc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAlopeciaConsent(BusinessEntities.ConsentForms.AlopeciaConsent hijama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Alopecia_Treatment_Consent_Insert");

                db.AddInParameter(dbCommand, "atc_appId", DbType.Int32, hijama.atc_appId);
                db.AddInParameter(dbCommand, "atc_1", DbType.String, string.IsNullOrEmpty(hijama.atc_1) ? "" : hijama.atc_1);
                db.AddInParameter(dbCommand, "atc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "atcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _atcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "atcId"));
                return _atcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAlopeciaConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Alopecia_Treatment_Consent_Delete");

                db.AddInParameter(dbCommand, "atc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "atc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "atc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _atc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "atc_output"));

                return _atc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAlopeciaConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Alopecia_Treatment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "atc_appId", DbType.Int32, appId);
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
