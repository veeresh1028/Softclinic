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
    public class DmaxBotox
    {
        public static DataTable GetDmaxBotoxData(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Botox_Select");

                db.AddInParameter(dbCommand, "cdb_appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SaveDmaxBotox(BusinessEntities.ConsentForms.DmaxBotox derma, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Botox_Insert");

                db.AddInParameter(dbCommand, "cdb_appId", DbType.Int32, derma.cdb_appId);
                db.AddInParameter(dbCommand, "cdb_1", DbType.String, string.IsNullOrEmpty(derma.cdb_1) ? "" : derma.cdb_1);
                db.AddInParameter(dbCommand, "cdb_made_by", DbType.Int32, madeby);

                db.AddOutParameter(dbCommand, "cdbId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int _cdbId = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdbId"));
                return _cdbId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int DeleteDmaxBotox(int appId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Botox_Delete");

                db.AddInParameter(dbCommand, "cdb_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "cdb_made_by", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "cdb_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);
                int _cdb_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "cdb_output"));

                return _cdb_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDmaxBotoxPreviousHistory(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Dmax_Botox_PreviousHistory");

                db.AddInParameter(dbCommand, "cdb_appId", DbType.Int32, appId);
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
