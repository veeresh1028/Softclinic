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
    public class WeightReductionConsent
    {
        public static DataTable GetWeightReductionConsentData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Reduction_Consent_Select");

                db.AddInParameter(dbCommand, "wrc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int SaveWeightReductionConsent(BusinessEntities.ConsentForms.WeightReductionConsent weight, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Reduction_Consent_Insert");

                db.AddInParameter(dbCommand, "wrc_appId", DbType.Int32, weight.wrc_appId);
                db.AddInParameter(dbCommand, "wrc_1", DbType.String, string.IsNullOrEmpty(weight.wrc_1) ? "" : weight.wrc_1);
                db.AddInParameter(dbCommand, "wrc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "wrcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _wrcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "wrcId"));
                return _wrcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static int DeleteWeightReductionConsent(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Reduction_Consent_Delete");

                db.AddInParameter(dbCommand, "wrc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "wrc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "wrc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _wrc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "wrc_output"));

                return _wrc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataTable GetWeightReductionConsentPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Weight_Reduction_Consent_PreviousHistory");

                db.AddInParameter(dbCommand, "wrc_appId", DbType.Int32, appId);
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
