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
    public class MinorsPsychotherapyConsent
    {
        public static DataTable GetMinorsPsychotherapyConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Psychotherapy_Consent_Select");

                db.AddInParameter(dbCommand, "mpc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveMinorsPsychotherapyConsent(BusinessEntities.ConsentForms.MinorsPsychotherapyConsent maple, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Psychotherapy_Consent_Insert");

                db.AddInParameter(dbCommand, "mpc_appId", DbType.Int32, maple.mpc_appId);
                db.AddInParameter(dbCommand, "mpc_wit", DbType.String, string.IsNullOrEmpty(maple.mpc_wit) ? "" : maple.mpc_wit);
                db.AddInParameter(dbCommand, "mpc_RelationshipStatus", DbType.String, string.IsNullOrEmpty(maple.mpc_RelationshipStatus) ? "" : maple.mpc_RelationshipStatus);
                db.AddInParameter(dbCommand, "mpc_session", DbType.String, string.IsNullOrEmpty(maple.mpc_session) ? "" : maple.mpc_session);
                db.AddInParameter(dbCommand, "mpc_living", DbType.String, string.IsNullOrEmpty(maple.mpc_living) ? "" : maple.mpc_living);
                db.AddInParameter(dbCommand, "mpc_radio1", DbType.String, string.IsNullOrEmpty(maple.mpc_radio1) ? "" : maple.mpc_radio1);
                db.AddInParameter(dbCommand, "mpc_provider", DbType.String, string.IsNullOrEmpty(maple.mpc_provider) ? "" : maple.mpc_provider);
                db.AddInParameter(dbCommand, "mpc_chk1", DbType.String, string.IsNullOrEmpty(maple.mpc_chk1) ? "" : maple.mpc_chk1);
                db.AddInParameter(dbCommand, "mpc_chk2", DbType.String, string.IsNullOrEmpty(maple.mpc_chk2) ? "" : maple.mpc_chk2);
                db.AddInParameter(dbCommand, "mpc_radio2", DbType.String, string.IsNullOrEmpty(maple.mpc_radio2) ? "" : maple.mpc_radio2);
                db.AddInParameter(dbCommand, "mpc_name", DbType.String, string.IsNullOrEmpty(maple.mpc_name) ? "" : maple.mpc_name);
                db.AddInParameter(dbCommand, "mpc_mobile", DbType.String, string.IsNullOrEmpty(maple.mpc_mobile) ? "" : maple.mpc_mobile);
                db.AddInParameter(dbCommand, "mpc_Relationship", DbType.String, string.IsNullOrEmpty(maple.mpc_Relationship) ? "" : maple.mpc_Relationship);
                db.AddInParameter(dbCommand, "mpc_radio3", DbType.String, string.IsNullOrEmpty(maple.mpc_radio3) ? "" : maple.mpc_radio3);
                db.AddInParameter(dbCommand, "mpc_date1", DbType.DateTime, maple.mpc_date1);
                db.AddInParameter(dbCommand, "mpc_radio4", DbType.String, string.IsNullOrEmpty(maple.mpc_radio4) ? "" : maple.mpc_radio4);
                db.AddInParameter(dbCommand, "mpc_date2", DbType.DateTime, maple.mpc_date2);
                db.AddInParameter(dbCommand, "mpc_other", DbType.String, string.IsNullOrEmpty(maple.mpc_other) ? "" : maple.mpc_other);
                db.AddInParameter(dbCommand, "mpc_general", DbType.String, string.IsNullOrEmpty(maple.mpc_general) ? "" : maple.mpc_general);
                db.AddInParameter(dbCommand, "mpc_medication1", DbType.String, string.IsNullOrEmpty(maple.mpc_medication1) ? "" : maple.mpc_medication1);
                db.AddInParameter(dbCommand, "mpc_medication2", DbType.String, string.IsNullOrEmpty(maple.mpc_medication2) ? "" : maple.mpc_medication2);
                db.AddInParameter(dbCommand, "mpc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "mpcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _mpcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "mpcId"));
                return _mpcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteMinorsPsychotherapyConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Psychotherapy_Consent_Delete");

                db.AddInParameter(dbCommand, "mpc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "mpc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "mpc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _mpc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "mpc_output"));

                return _mpc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetMinorsPsychotherapyConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Minors_Psychotherapy_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "mpc_appId", DbType.Int32, appId);
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
