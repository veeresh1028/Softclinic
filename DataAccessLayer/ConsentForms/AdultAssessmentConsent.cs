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
    public class AdultAssessmentConsent
    {
        public static DataTable GetAdultAssessmentConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Assessment_Consent_Select");

                db.AddInParameter(dbCommand, "aac_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAdultAssessmentConsent(BusinessEntities.ConsentForms.AdultAssessmentConsent maple, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Assessment_Consent_Insert");

                db.AddInParameter(dbCommand, "aac_appId", DbType.Int32, maple.aac_appId);
                db.AddInParameter(dbCommand, "aac_1", DbType.String, string.IsNullOrEmpty(maple.aac_1) ? "" : maple.aac_1);
                db.AddInParameter(dbCommand, "aac_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "aacId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _aacId = Convert.ToInt32(db.GetParameterValue(dbCommand, "aacId"));
                return _aacId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAdultAssessmentConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Assessment_Consent_Delete");

                db.AddInParameter(dbCommand, "aac_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "aac_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "aac_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _aac_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "aac_output"));

                return _aac_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAdultAssessmentConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Assessment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "aac_appId", DbType.Int32, appId);
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
