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
    public class HijjamaConsent
    {
        public static DataTable GetHijjamaConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Consent_Form_Select");

                db.AddInParameter(dbCommand, "hcf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveHijjamaConsent(BusinessEntities.ConsentForms.HijjamaConsent hijjama, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "hcf_appId", DbType.Int32, hijjama.hcf_appId);
                db.AddInParameter(dbCommand, "hcf_1", DbType.String, string.IsNullOrEmpty(hijjama.hcf_1) ? "" : hijjama.hcf_1);
                db.AddInParameter(dbCommand, "hcf_2", DbType.String, string.IsNullOrEmpty(hijjama.hcf_2) ? "" : hijjama.hcf_2);
                db.AddInParameter(dbCommand, "hcf_3", DbType.String, string.IsNullOrEmpty(hijjama.hcf_3) ? "" : hijjama.hcf_3);
                db.AddInParameter(dbCommand, "hcf_4", DbType.String, string.IsNullOrEmpty(hijjama.hcf_4) ? "" : hijjama.hcf_4);
                db.AddInParameter(dbCommand, "hcf_5", DbType.String, string.IsNullOrEmpty(hijjama.hcf_5) ? "" : hijjama.hcf_5);
                db.AddInParameter(dbCommand, "hcf_6", DbType.String, string.IsNullOrEmpty(hijjama.hcf_6) ? "" : hijjama.hcf_6);
                db.AddInParameter(dbCommand, "hcf_7", DbType.String, string.IsNullOrEmpty(hijjama.hcf_7) ? "" : hijjama.hcf_7);
                db.AddInParameter(dbCommand, "hcf_8", DbType.String, string.IsNullOrEmpty(hijjama.hcf_8) ? "" : hijjama.hcf_8);
                db.AddInParameter(dbCommand, "hcf_9", DbType.String, string.IsNullOrEmpty(hijjama.hcf_9) ? "" : hijjama.hcf_9);
                db.AddInParameter(dbCommand, "hcf_doc", DbType.String, hijjama.image);
                db.AddInParameter(dbCommand, "hcf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "hcfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _hcfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "hcfId"));
                return _hcfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteHijjamaConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "hcf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "hcf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "hcf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _hcf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "hcf_output"));

                return _hcf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetHijjamaConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Hijjama_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "hcf_appId", DbType.Int32, appId);
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
