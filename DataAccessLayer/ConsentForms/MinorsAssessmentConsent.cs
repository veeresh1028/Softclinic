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
    public class MinorsAssessmentConsent
    {
        public static DataTable GetMinorsAssessmentConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Assessment_Consent_Select");

                db.AddInParameter(dbCommand, "mac_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMinorsAssessmentConsent(BusinessEntities.ConsentForms.MinorsAssessmentConsent maple, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Assessment_Consent_Insert");

                db.AddInParameter(dbCommand, "mac_appId", DbType.Int32, maple.mac_appId);
                db.AddInParameter(dbCommand, "mac_1", DbType.String, string.IsNullOrEmpty(maple.mac_1) ? "" : maple.mac_1);
                db.AddInParameter(dbCommand, "mac_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "macId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _macId = Convert.ToInt32(db.GetParameterValue(dbCommand, "macId"));
                return _macId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMinorsAssessmentConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Assessment_Consent_Delete");

                db.AddInParameter(dbCommand, "mac_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mac_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mac_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mac_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mac_output"));

                return _mac_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMinorsAssessmentConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Assessment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "mac_appId", DbType.Int32, appId);
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
