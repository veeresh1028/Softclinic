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
    public class SublimeConsent
    {
        public static DataTable GetSublimeConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Sublime_Consent_Form_Select");

                db.AddInParameter(dbCommand, "scf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveSublimeConsent(BusinessEntities.ConsentForms.SublimeConsent crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Sublime_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "scf_appId", DbType.Int32, crown.scf_appId);
                db.AddInParameter(dbCommand, "scf_1", DbType.String, string.IsNullOrEmpty(crown.scf_1) ? "" : crown.scf_1);
                db.AddInParameter(dbCommand, "scf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "scfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _scfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "scfId"));
                return _scfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteSublimeConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Sublime_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "scf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "scf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "scf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _scf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "scf_output"));

                return _scf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSublimeConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Sublime_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "scf_appId", DbType.Int32, appId);
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
