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
    public class Mesotherapy
    {
        public static DataTable GetMesotherapyData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Mesotherapy_Consent_Form_Select");

                db.AddInParameter(dbCommand, "cmc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int SaveMesotherapy(BusinessEntities.ConsentForms.Mesotherapy meso, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Mesotherapy_Consent_Form_Insert");

                db.AddInParameter(dbCommand, "cmc_appId", DbType.Int32, meso.cmc_appId);
                db.AddInParameter(dbCommand, "cmc_1", DbType.String, string.IsNullOrEmpty(meso.cmc_1) ? "" : meso.cmc_1);
                db.AddInParameter(dbCommand, "cmc_2", DbType.String, string.IsNullOrEmpty(meso.cmc_2) ? "" : meso.cmc_2);
                db.AddInParameter(dbCommand, "cmc_3", DbType.String, string.IsNullOrEmpty(meso.cmc_3) ? "" : meso.cmc_3);
                db.AddInParameter(dbCommand, "cmc_4", DbType.String, string.IsNullOrEmpty(meso.cmc_4) ? "" : meso.cmc_4);
                db.AddInParameter(dbCommand, "cmc_5", DbType.String, string.IsNullOrEmpty(meso.cmc_5) ? "" : meso.cmc_5);
                db.AddInParameter(dbCommand, "cmc_6", DbType.String, string.IsNullOrEmpty(meso.cmc_6) ? "" : meso.cmc_6);
                db.AddInParameter(dbCommand, "cmc_7", DbType.String, string.IsNullOrEmpty(meso.cmc_7) ? "" : meso.cmc_7);
                db.AddInParameter(dbCommand, "cmc_8", DbType.String, string.IsNullOrEmpty(meso.cmc_8) ? "" : meso.cmc_8);
                db.AddInParameter(dbCommand, "cmc_9", DbType.String, string.IsNullOrEmpty(meso.cmc_9) ? "" : meso.cmc_9);
                db.AddInParameter(dbCommand, "cmc_10", DbType.String, string.IsNullOrEmpty(meso.cmc_10) ? "" : meso.cmc_10);
                db.AddInParameter(dbCommand, "cmc_11", DbType.String, string.IsNullOrEmpty(meso.cmc_11) ? "" : meso.cmc_11);
                db.AddInParameter(dbCommand, "cmc_12", DbType.String, string.IsNullOrEmpty(meso.cmc_12) ? "" : meso.cmc_12);
                db.AddInParameter(dbCommand, "cmc_13", DbType.String, string.IsNullOrEmpty(meso.cmc_13) ? "" : meso.cmc_13);
                db.AddInParameter(dbCommand, "cmc_14", DbType.String, string.IsNullOrEmpty(meso.cmc_14) ? "" : meso.cmc_14);
                db.AddInParameter(dbCommand, "cmc_15", DbType.String, string.IsNullOrEmpty(meso.cmc_15) ? "" : meso.cmc_15);
                db.AddInParameter(dbCommand, "cmc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cmcId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cmcId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cmcId"));
                return _cmcId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int DeleteMesotherapy(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Mesotherapy_Consent_Form_Delete");

                db.AddInParameter(dbCommand, "cmc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cmc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cmc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cmc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cmc_output"));

                return _cmc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetMesotherapyPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Mesotherapy_Consent_Form_PreviousHistory");

                db.AddInParameter(dbCommand, "cmc_appId", DbType.Int32, appId);
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
