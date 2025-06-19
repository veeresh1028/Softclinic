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
    public class WeightManagementConsent
    {
        public static DataTable GetWeightManagementConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Management_Consent_Select");

                db.AddInParameter(dbCommand, "wmc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveWeightManagementConsent(BusinessEntities.ConsentForms.WeightManagementConsent weightmanagement, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Management_Consent_Insert");

                db.AddInParameter(dbCommand, "wmc_appId", DbType.Int32, weightmanagement.wmc_appId);
                db.AddInParameter(dbCommand, "wmc_1", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_1) ? "" : weightmanagement.wmc_1);
                db.AddInParameter(dbCommand, "wmc_2", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_2) ? "" : weightmanagement.wmc_2);
                db.AddInParameter(dbCommand, "wmc_3", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_3) ? "" : weightmanagement.wmc_3);
                db.AddInParameter(dbCommand, "wmc_4", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_4) ? "" : weightmanagement.wmc_4);
                db.AddInParameter(dbCommand, "wmc_5", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_5) ? "" : weightmanagement.wmc_5);
                db.AddInParameter(dbCommand, "wmc_6", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_6) ? "" : weightmanagement.wmc_6);
                db.AddInParameter(dbCommand, "wmc_7", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_7) ? "" : weightmanagement.wmc_7);
                db.AddInParameter(dbCommand, "wmc_8", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_8) ? "" : weightmanagement.wmc_8);
                db.AddInParameter(dbCommand, "wmc_9", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_9) ? "" : weightmanagement.wmc_9);
                db.AddInParameter(dbCommand, "wmc_10", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_10) ? "" : weightmanagement.wmc_10);
                db.AddInParameter(dbCommand, "wmc_11", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_11) ? "" : weightmanagement.wmc_11);
                db.AddInParameter(dbCommand, "wmc_12", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_12) ? "" : weightmanagement.wmc_12);
                db.AddInParameter(dbCommand, "wmc_13", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_13) ? "" : weightmanagement.wmc_13);
                db.AddInParameter(dbCommand, "wmc_14", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_14) ? "" : weightmanagement.wmc_14);
                db.AddInParameter(dbCommand, "wmc_15", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_15) ? "" : weightmanagement.wmc_15);
                db.AddInParameter(dbCommand, "wmc_16", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_16) ? "" : weightmanagement.wmc_16);
                db.AddInParameter(dbCommand, "wmc_17", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_17) ? "" : weightmanagement.wmc_17);
                db.AddInParameter(dbCommand, "wmc_18", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_18) ? "" : weightmanagement.wmc_18);
                db.AddInParameter(dbCommand, "wmc_19", DbType.String, string.IsNullOrEmpty(weightmanagement.wmc_19) ? "" : weightmanagement.wmc_19);
                db.AddInParameter(dbCommand, "wmc_doc", DbType.String, weightmanagement.image);
                db.AddInParameter(dbCommand, "wmc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "wmcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _wmcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "wmcId"));
                return _wmcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteWeightManagementConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Management_Consent_Delete");

                db.AddInParameter(dbCommand, "wmc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "wmc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "wmc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _wmc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "wmc_output"));

                return _wmc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static DataTable GetWeightManagementConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Management_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "wmc_appId", DbType.Int32, appId);
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
