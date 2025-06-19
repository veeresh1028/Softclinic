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
    public class DemographicForm
    {
        public static DataTable GetDemographicFormData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Demographic_Form_Select");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDemographicForm(BusinessEntities.ConsentForms.DemographicForm maple, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Demographic_Form_Insert");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, maple.cdf_appId);
                db.AddInParameter(dbCommand, "cdf_RelationshipStatus", DbType.String, string.IsNullOrEmpty(maple.cdf_RelationshipStatus) ? "" : maple.cdf_RelationshipStatus);
                db.AddInParameter(dbCommand, "cdf_session", DbType.String, string.IsNullOrEmpty(maple.cdf_session) ? "" : maple.cdf_session);
                db.AddInParameter(dbCommand, "cdf_living", DbType.String, string.IsNullOrEmpty(maple.cdf_living) ? "" : maple.cdf_living);
                db.AddInParameter(dbCommand, "cdf_radio1", DbType.String, string.IsNullOrEmpty(maple.cdf_radio1) ? "" : maple.cdf_radio1);
                db.AddInParameter(dbCommand, "cdf_provider", DbType.String, string.IsNullOrEmpty(maple.cdf_provider) ? "" : maple.cdf_provider);
                db.AddInParameter(dbCommand, "cdf_chk1", DbType.String, string.IsNullOrEmpty(maple.cdf_chk1) ? "" : maple.cdf_chk1);
                db.AddInParameter(dbCommand, "cdf_chk2", DbType.String, string.IsNullOrEmpty(maple.cdf_chk2) ? "" : maple.cdf_chk2);
                db.AddInParameter(dbCommand, "cdf_radio2", DbType.String, string.IsNullOrEmpty(maple.cdf_radio2) ? "" : maple.cdf_radio2);
                db.AddInParameter(dbCommand, "cdf_name", DbType.String, string.IsNullOrEmpty(maple.cdf_name) ? "" : maple.cdf_name);
                db.AddInParameter(dbCommand, "cdf_mobile", DbType.String, string.IsNullOrEmpty(maple.cdf_mobile) ? "" : maple.cdf_mobile);
                db.AddInParameter(dbCommand, "cdf_Relationship", DbType.String, string.IsNullOrEmpty(maple.cdf_Relationship) ? "" : maple.cdf_Relationship);
                db.AddInParameter(dbCommand, "cdf_radio3", DbType.String, string.IsNullOrEmpty(maple.cdf_radio3) ? "" : maple.cdf_radio3);
                db.AddInParameter(dbCommand, "cdf_date1", DbType.DateTime, maple.cdf_date1);
                db.AddInParameter(dbCommand, "cdf_radio4", DbType.String, string.IsNullOrEmpty(maple.cdf_radio4) ? "" : maple.cdf_radio4);
                db.AddInParameter(dbCommand, "cdf_date2", DbType.DateTime, maple.cdf_date2);
                db.AddInParameter(dbCommand, "cdf_other", DbType.String, string.IsNullOrEmpty(maple.cdf_other) ? "" : maple.cdf_other);
                db.AddInParameter(dbCommand, "cdf_general", DbType.String, string.IsNullOrEmpty(maple.cdf_general) ? "" : maple.cdf_general);
                db.AddInParameter(dbCommand, "cdf_medication1", DbType.String, string.IsNullOrEmpty(maple.cdf_medication1) ? "" : maple.cdf_medication1);
                db.AddInParameter(dbCommand, "cdf_medication2", DbType.String, string.IsNullOrEmpty(maple.cdf_medication2) ? "" : maple.cdf_medication2);
                db.AddInParameter(dbCommand, "cdf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdfId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdfId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdfId"));
                return _cdfId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDemographicForm(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Demographic_Form_Delete");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdf_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdf_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdf_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdf_output"));

                return _cdf_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDemographicFormPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Demographic_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
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
