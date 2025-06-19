using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EMR
{
    public class QuickEMR
    {
        #region Signed Documents (Page Load)
        public static DataTable GetAllSignedDocuments(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SignedDocuments_select_all_info");
                
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreSignedDocuments(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SignedDocuments_PREVIOUS");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Signed Documents (Page Load)

        #region Start End Time (Page Load)

        public static DataTable GetStartEndTime(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_START_END_select_all_info");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool InsertUpdateStartEndTime(BusinessEntities.EMR.StartEndTime data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_START_END_INSERT_UPDATE");
                if (data.tId > 0)
                {
                    db.AddInParameter(dbCommand, "tId", DbType.Int32, data.tId);
                }
                db.AddInParameter(dbCommand, "t_appid", DbType.Int32, data.t_appId);
                db.AddInParameter(dbCommand, "t_start", DbType.DateTime, data.t_start);
                db.AddInParameter(dbCommand, "t_end", DbType.DateTime, data.t_end);
                db.AddInParameter(dbCommand, "t_duration", DbType.String, data.t_duration);
                db.AddInParameter(dbCommand, "t_status", DbType.String, data.t_status);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion Start End Time (Page Load)
    }
}
