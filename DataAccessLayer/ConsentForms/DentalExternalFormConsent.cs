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
    public class DentalExternalFormConsent
    {
        public static DataTable GetDentalExternalFormConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_External_Form_Consent_Select");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDentalExternalFormConsent(BusinessEntities.ConsentForms.DentalExternalFormConsent dental, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_External_Form_Consent_Insert");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, dental.cde_appId);

                db.AddInParameter(dbCommand, "cde_check1", DbType.String, string.IsNullOrEmpty(dental.cde_check1) ? "" : dental.cde_check1);

                 db.AddInParameter(dbCommand, "cde_text1", DbType.String, string.IsNullOrEmpty(dental.cde_text1) ? "" : dental.cde_text1);

                db.AddInParameter(dbCommand, "cde_text2", DbType.String, string.IsNullOrEmpty(dental.cde_text2) ? "" : dental.cde_text2);

                db.AddInParameter(dbCommand, "cde_image", DbType.String, dental.image);

                db.AddInParameter(dbCommand, "cde_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cde_Id", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cde_Id = Convert.ToInt32(db.GetParameterValue(dbCommand, "cde_Id"));
                return _cde_Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDentalExternalFormConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_External_Form_Consent_Delete");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cde_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cde_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cde_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cde_output"));

                return _cde_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDentalExternalFormConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dental_External_Form_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "cde_appId", DbType.Int32, appId);
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
