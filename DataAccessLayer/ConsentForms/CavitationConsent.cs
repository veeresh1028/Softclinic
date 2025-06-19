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
    public class CavitationConsent
    {
        public static DataTable GetCavitationConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cavitation_Consent_Form_Select");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveCavitationConsent(BusinessEntities.ConsentForms.CavitationConsent cavitation, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cavitation_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, cavitation.ccf_appId);
                db.AddInParameter(dbCommand, "ccf_1", DbType.String, string.IsNullOrEmpty(cavitation.ccf_1) ? "" : cavitation.ccf_1);
                db.AddInParameter(dbCommand, "ccf_2", DbType.String, string.IsNullOrEmpty(cavitation.ccf_2) ? "" : cavitation.ccf_2);
                db.AddInParameter(dbCommand, "ccf_3", DbType.String, string.IsNullOrEmpty(cavitation.ccf_3) ? "" : cavitation.ccf_3);
                db.AddInParameter(dbCommand, "ccf_4", DbType.String, string.IsNullOrEmpty(cavitation.ccf_4) ? "" : cavitation.ccf_4);
                db.AddInParameter(dbCommand, "ccf_5", DbType.String, string.IsNullOrEmpty(cavitation.ccf_5) ? "" : cavitation.ccf_5);
                db.AddInParameter(dbCommand, "ccf_6", DbType.String, string.IsNullOrEmpty(cavitation.ccf_6) ? "" : cavitation.ccf_6);
                db.AddInParameter(dbCommand, "ccf_7", DbType.String, string.IsNullOrEmpty(cavitation.ccf_7) ? "" : cavitation.ccf_7);
                db.AddInParameter(dbCommand, "ccf_8", DbType.String, string.IsNullOrEmpty(cavitation.ccf_8) ? "" : cavitation.ccf_8);
                db.AddInParameter(dbCommand, "ccf_9", DbType.String, string.IsNullOrEmpty(cavitation.ccf_9) ? "" : cavitation.ccf_9);
                db.AddInParameter(dbCommand, "ccf_10", DbType.String, string.IsNullOrEmpty(cavitation.ccf_10) ? "" : cavitation.ccf_10);
                db.AddInParameter(dbCommand, "ccf_11", DbType.String, string.IsNullOrEmpty(cavitation.ccf_11) ? "" : cavitation.ccf_11);
                db.AddInParameter(dbCommand, "ccf_12", DbType.String, string.IsNullOrEmpty(cavitation.ccf_12) ? "" : cavitation.ccf_12);
                db.AddInParameter(dbCommand, "ccf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ccfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ccfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccfId"));
                return _ccfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteCavitationConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cavitation_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ccf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ccf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ccf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ccf_output"));

                return _ccf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetCavitationConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Cavitation_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "ccf_appId", DbType.Int32, appId);
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
