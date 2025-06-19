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
    public class ColposcopyReferral
    {
        public static DataTable GetColposcopyReferralData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Referral_New_Select");

                db.AddInParameter(dbCommand, "crn_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveColposcopyReferral(BusinessEntities.ConsentForms.ColposcopyReferral gyna, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Referral_New_Insert");

                db.AddInParameter(dbCommand, "crn_appId", DbType.Int32, gyna.crn_appId);
                db.AddInParameter(dbCommand, "crn_1", DbType.String, string.IsNullOrEmpty(gyna.crn_1) ? "" : gyna.crn_1);
                db.AddInParameter(dbCommand, "crn_2", DbType.String, string.IsNullOrEmpty(gyna.crn_2) ? "" : gyna.crn_2);
                db.AddInParameter(dbCommand, "crn_3", DbType.String, string.IsNullOrEmpty(gyna.crn_3) ? "" : gyna.crn_3);
                db.AddInParameter(dbCommand, "crn_radio1", DbType.String, string.IsNullOrEmpty(gyna.crn_radio1) ? "" : gyna.crn_radio1);

                db.AddInParameter(dbCommand, "crn_date1", DbType.String, string.IsNullOrEmpty(gyna.crn_date1) ? "" : gyna.crn_date1);
                db.AddInParameter(dbCommand, "crn_date2", DbType.String, string.IsNullOrEmpty(gyna.crn_date2) ? "" : gyna.crn_date2);
                db.AddInParameter(dbCommand, "crn_date3", DbType.String, string.IsNullOrEmpty(gyna.crn_date3) ? "" : gyna.crn_date3);
                db.AddInParameter(dbCommand, "crn_date4", DbType.String, string.IsNullOrEmpty(gyna.crn_date4) ? "" : gyna.crn_date4);
                db.AddInParameter(dbCommand, "crn_date5", DbType.String, string.IsNullOrEmpty(gyna.crn_date5) ? "" : gyna.crn_date5);
                db.AddInParameter(dbCommand, "crn_date6", DbType.String, string.IsNullOrEmpty(gyna.crn_date6) ? "" : gyna.crn_date6);
                db.AddInParameter(dbCommand, "crn_date7", DbType.String, string.IsNullOrEmpty(gyna.crn_date7) ? "" : gyna.crn_date7);
                db.AddInParameter(dbCommand, "crn_date8", DbType.String, string.IsNullOrEmpty(gyna.crn_date8) ? "" : gyna.crn_date8);
                db.AddInParameter(dbCommand, "crn_date9", DbType.String, string.IsNullOrEmpty(gyna.crn_date9) ? "" : gyna.crn_date9);

                db.AddInParameter(dbCommand, "crn_time1", DbType.String, string.IsNullOrEmpty(gyna.crn_time1) ? "" : gyna.crn_time1);

                db.AddInParameter(dbCommand, "crn_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "crnId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _crnId = Convert.ToInt32(db.GetParameterValue(dbCommand, "crnId"));
                return _crnId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteColposcopyReferral(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Referral_New_Delete");

                db.AddInParameter(dbCommand, "crn_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "crn_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "crn_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _crn_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "crn_output"));

                return _crn_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetColposcopyReferralPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Colposcopy_Referral_New_PreviousHistory");

                db.AddInParameter(dbCommand, "crn_appId", DbType.Int32, appId);
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
