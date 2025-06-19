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
    public class DmaxCrownBridge
    {
        public static DataTable GetDmaxCrownBridgeData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Crown_Bridge_Select");

                db.AddInParameter(dbCommand, "cdcb_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxCrownBridge(BusinessEntities.ConsentForms.DmaxCrownBridge derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Crown_Bridge_Insert");

                db.AddInParameter(dbCommand, "cdcb_appId", DbType.Int32, derma.cdcb_appId);
                db.AddInParameter(dbCommand, "cdcb_1", DbType.String, string.IsNullOrEmpty(derma.cdcb_1) ? "" : derma.cdcb_1);
                db.AddInParameter(dbCommand, "cdcb_2", DbType.String, string.IsNullOrEmpty(derma.cdcb_2) ? "" : derma.cdcb_2);
                db.AddInParameter(dbCommand, "cdcb_3", DbType.String, string.IsNullOrEmpty(derma.cdcb_3) ? "" : derma.cdcb_3);
                db.AddInParameter(dbCommand, "cdcb_4", DbType.String, string.IsNullOrEmpty(derma.cdcb_4) ? "" : derma.cdcb_4);
                db.AddInParameter(dbCommand, "cdcb_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdcbId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdcbId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdcbId"));
                return _cdcbId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxCrownBridge(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Crown_Bridge_Delete");

                db.AddInParameter(dbCommand, "cdcb_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdcb_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdcb_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdcb_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdcb_output"));

                return _cdcb_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxCrownBridgePreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Crown_Bridge_PreviousHistory");

                db.AddInParameter(dbCommand, "cdcb_appId", DbType.Int32, appId);
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
