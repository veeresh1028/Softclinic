using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ConcentForms
{
    public class CrownBridge
    {
        public static DataTable GetCrownBridgeData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Select");

                db.AddInParameter(dbCommand, "icc_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveCrownBridge(BusinessEntities.ConsentForms.CrownBridge crown, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Insert");

                db.AddInParameter(dbCommand, "icc_appId", DbType.Int32, crown.icc_appId);
                db.AddInParameter(dbCommand, "icc_1", DbType.String, string.IsNullOrEmpty(crown.icc_1) ? "" : crown.icc_1);
                db.AddInParameter(dbCommand, "icc_2", DbType.String, string.IsNullOrEmpty(crown.icc_2) ? "" : crown.icc_2);
                db.AddInParameter(dbCommand, "icc_3", DbType.String, string.IsNullOrEmpty(crown.icc_3) ? "" : crown.icc_3);
                db.AddInParameter(dbCommand, "icc_4", DbType.String, string.IsNullOrEmpty(crown.icc_4) ? "" : crown.icc_4);
                db.AddInParameter(dbCommand, "icc_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "iccId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                 int _iccId = Convert.ToInt32(db.GetParameterValue(dbCommand, "iccId"));
                return _iccId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteCrownBridge(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Delete");

                db.AddInParameter(dbCommand, "icc_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "icc_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "icc_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _icc_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "icc_output"));

                return _icc_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetCrownBridgePreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Informed_Consent_Crown_Previoushistory");

                db.AddInParameter(dbCommand, "icc_appId", DbType.Int32, appId);
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
