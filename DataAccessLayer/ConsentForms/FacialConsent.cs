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
    public class FacialConsent
    {
        public static DataTable GetFacialConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Consent_Select");

                db.AddInParameter(dbCommand, "ftc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveFacialConsent(BusinessEntities.ConsentForms.FacialConsent facial, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Consent_Insert");

                db.AddInParameter(dbCommand, "ftc_appId", DbType.Int32, facial.ftc_appId);
                db.AddInParameter(dbCommand, "ftc_1", DbType.String, string.IsNullOrEmpty(facial.ftc_1) ? "" : facial.ftc_1);
                db.AddInParameter(dbCommand, "ftc_2", DbType.String, string.IsNullOrEmpty(facial.ftc_2) ? "" : facial.ftc_2);
                db.AddInParameter(dbCommand, "ftc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "ftcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _ftcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftcId"));
                return _ftcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteFacialConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Consent_Delete");

                db.AddInParameter(dbCommand, "ftc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "ftc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ftc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _ftc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftc_output"));

                return _ftc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetFacialConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Facial_Treatment_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "ftc_appId", DbType.Int32, appId);
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
