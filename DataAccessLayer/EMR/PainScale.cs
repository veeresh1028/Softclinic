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
    public class PainScale
    {
        #region PainScale
        public static DataTable GetAllPainScale(int? appId, int? paId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAIN_select_all_info");
                if (paId > 0)
                {
                    db.AddInParameter(dbCommand, "paId", DbType.Int32, paId);
                }
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPrePainScale(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAIN_PREVIOUS_History");
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

        public static bool InsertUpdatePainScale(BusinessEntities.EMR.PainScale data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAIN_INSERT_UPDATE");
                if (data.paId > 0)
                {
                    db.AddInParameter(dbCommand, "paId", DbType.Int32, data.paId);
                }
                db.AddInParameter(dbCommand, "pa_appId", DbType.Int32, data.pa_appId);
                db.AddInParameter(dbCommand, "pa_pain", DbType.Int32, data.pa_pain);
                db.AddInParameter(dbCommand, "pa_madeby", DbType.Int32, data.pa_madeby);

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

        public static int DeletePainScale(int paId, int pa_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAIN_delete");

                db.AddInParameter(dbCommand, "paId", DbType.Int32, paId);
                db.AddInParameter(dbCommand, "pa_madeby", DbType.String, pa_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion PainScale
    }
}
