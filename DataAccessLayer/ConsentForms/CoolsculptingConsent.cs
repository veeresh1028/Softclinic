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
    public class CoolsculptingConsent
    {
        public static DataTable GetCoolsculptingConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coolsculpting_Informed_Consent_Select");

                db.AddInParameter(dbCommand, "coc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveCoolsculptingConsent(BusinessEntities.ConsentForms.CoolsculptingConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coolsculpting_Informed_Consent_Insert");

                db.AddInParameter(dbCommand, "coc_appId", DbType.Int32, crown.coc_appId);
                db.AddInParameter(dbCommand, "coc_1", DbType.String, string.IsNullOrEmpty(crown.coc_1) ? "" : crown.coc_1);
                db.AddInParameter(dbCommand, "coc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cocId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cocId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cocId"));
                return _cocId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteCoolsculptingConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coolsculpting_Informed_Consent_Delete");

                db.AddInParameter(dbCommand, "coc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "coc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "coc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _coc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "coc_output"));

                return _coc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCoolsculptingConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Coolsculpting_Informed_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "coc_appId", DbType.Int32, appId);
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
