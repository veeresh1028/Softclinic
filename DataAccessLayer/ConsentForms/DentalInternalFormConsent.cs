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
    public class DentalInternalFormConsent
    {
        public static DataTable GetDentalInternalFormConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_Internal_Form_Consent_Select");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDentalInternalFormConsent(BusinessEntities.ConsentForms.DentalInternalFormConsent dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_Internal_Form_Consent_Insert");

                db.AddInParameter(dbCommand, "cdf_appId", DbType.Int32, dental.cdf_appId);

               
                db.AddInParameter(dbCommand, "cdf_check2", DbType.String, string.IsNullOrEmpty(dental.cdf_check2) ? "" : dental.cdf_check2);

                db.AddInParameter(dbCommand, "cdf_text1", DbType.String, string.IsNullOrEmpty(dental.cdf_text1) ? "" : dental.cdf_text1);

                db.AddInParameter(dbCommand, "cdf_text2", DbType.String, string.IsNullOrEmpty(dental.cdf_text2) ? "" : dental.cdf_text2);

                db.AddInParameter(dbCommand, "cdf_comments", DbType.String, string.IsNullOrEmpty(dental.cdf_comments) ? "" : dental.cdf_comments);


                db.AddInParameter(dbCommand, "cdf_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdf_Id", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdf_Id = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdf_Id"));
                return _cdf_Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDentalInternalFormConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_Internal_Form_Consent_Delete");

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
        public static DataTable GetDentalInternalFormConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_Internal_Form_Consent_PreviousHistory");

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
