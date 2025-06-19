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
    public class IsotretinoinConsent
    {
        public static DataTable GetIsotretinoinConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Isotretinoin_Consent_Select");

                db.AddInParameter(dbCommand, "ict_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveIsotretinoinConsent(BusinessEntities.ConsentForms.IsotretinoinConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Isotretinoin_Consent_Insert");

                db.AddInParameter(dbCommand, "ict_appId", DbType.Int32, crown.ict_appId);
                db.AddInParameter(dbCommand, "ict_1", DbType.String, string.IsNullOrEmpty(crown.ict_1) ? "" : crown.ict_1);
                db.AddInParameter(dbCommand, "ict_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ictId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ictId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ictId"));
                return _ictId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteIsotretinoinConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Isotretinoin_Consent_Delete");

                db.AddInParameter(dbCommand, "ict_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ict_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ict_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ict_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ict_output"));

                return _ict_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetIsotretinoinConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Isotretinoin_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "ict_appId", DbType.Int32, appId);
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
