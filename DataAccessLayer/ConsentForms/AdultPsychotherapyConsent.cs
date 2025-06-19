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
    public class AdultPsychotherapyConsent
    {
        public static DataTable GetAdultPsychotherapyConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Psychotherapy_Consent_Select");

                db.AddInParameter(dbCommand, "apc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveAdultPsychotherapyConsent(BusinessEntities.ConsentForms.AdultPsychotherapyConsent maple, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Psychotherapy_Consent_Insert");

                db.AddInParameter(dbCommand, "apc_appId", DbType.Int32, maple.apc_appId);
                db.AddInParameter(dbCommand, "apc_wit", DbType.String, string.IsNullOrEmpty(maple.apc_wit) ? "" : maple.apc_wit);
                db.AddInParameter(dbCommand, "apc_RelationshipStatus", DbType.String, string.IsNullOrEmpty(maple.apc_RelationshipStatus) ? "" : maple.apc_RelationshipStatus);
                db.AddInParameter(dbCommand, "apc_session", DbType.String, string.IsNullOrEmpty(maple.apc_session) ? "" : maple.apc_session);
                db.AddInParameter(dbCommand, "apc_living", DbType.String, string.IsNullOrEmpty(maple.apc_living) ? "" : maple.apc_living);
                db.AddInParameter(dbCommand, "apc_radio1", DbType.String, string.IsNullOrEmpty(maple.apc_radio1) ? "" : maple.apc_radio1);
                db.AddInParameter(dbCommand, "apc_provider", DbType.String, string.IsNullOrEmpty(maple.apc_provider) ? "" : maple.apc_provider);
                db.AddInParameter(dbCommand, "apc_chk1", DbType.String, string.IsNullOrEmpty(maple.apc_chk1) ? "" : maple.apc_chk1);
                db.AddInParameter(dbCommand, "apc_chk2", DbType.String, string.IsNullOrEmpty(maple.apc_chk2) ? "" : maple.apc_chk2);
                db.AddInParameter(dbCommand, "apc_radio2", DbType.String, string.IsNullOrEmpty(maple.apc_radio2) ? "" : maple.apc_radio2);
                db.AddInParameter(dbCommand, "apc_name", DbType.String, string.IsNullOrEmpty(maple.apc_name) ? "" : maple.apc_name);
                db.AddInParameter(dbCommand, "apc_mobile", DbType.String, string.IsNullOrEmpty(maple.apc_mobile) ? "" : maple.apc_mobile);
                db.AddInParameter(dbCommand, "apc_Relationship", DbType.String, string.IsNullOrEmpty(maple.apc_Relationship) ? "" : maple.apc_Relationship);
                db.AddInParameter(dbCommand, "apc_radio3", DbType.String, string.IsNullOrEmpty(maple.apc_radio3) ? "" : maple.apc_radio3);
                db.AddInParameter(dbCommand, "apc_date1", DbType.DateTime, maple.apc_date1);
                db.AddInParameter(dbCommand, "apc_radio4", DbType.String, string.IsNullOrEmpty(maple.apc_radio4) ? "" : maple.apc_radio4);
                db.AddInParameter(dbCommand, "apc_date2", DbType.DateTime, maple.apc_date2);
                db.AddInParameter(dbCommand, "apc_other", DbType.String, string.IsNullOrEmpty(maple.apc_other) ? "" : maple.apc_other);
                db.AddInParameter(dbCommand, "apc_general", DbType.String, string.IsNullOrEmpty(maple.apc_general) ? "" : maple.apc_general);
                db.AddInParameter(dbCommand, "apc_medication1", DbType.String, string.IsNullOrEmpty(maple.apc_medication1) ? "" : maple.apc_medication1);
                db.AddInParameter(dbCommand, "apc_medication2", DbType.String, string.IsNullOrEmpty(maple.apc_medication2) ? "" : maple.apc_medication2);
                db.AddInParameter(dbCommand, "apc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "apcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _apcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "apcId"));
                return _apcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteAdultPsychotherapyConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Psychotherapy_Consent_Delete");

                db.AddInParameter(dbCommand, "apc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "apc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "apc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _apc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "apc_output"));

                return _apc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAdultPsychotherapyConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Adult_Psychotherapy_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "apc_appId", DbType.Int32, appId);
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
