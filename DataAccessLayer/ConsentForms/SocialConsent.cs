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
    public class SocialConsent
    {
        public static DataTable GetSocialConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Social_Consent_Select");

                db.AddInParameter(dbCommand, "csoc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveSocialConsent(BusinessEntities.ConsentForms.SocialConsent tooth, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Social_Consent_Insert");

                db.AddInParameter(dbCommand, "csoc_appId", DbType.Int32, tooth.csoc_appId);
                db.AddInParameter(dbCommand, "csoc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "csocId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _csocId = Convert.ToInt32(db.GetParameterValue(dbCommand, "csocId"));
                return _csocId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSocialConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Social_Consent_Delete");

                db.AddInParameter(dbCommand, "csoc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "csoc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "csoc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _csoc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "csoc_output"));

                return _csoc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSocialConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Social_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "csoc_appId", DbType.Int32, appId);
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
