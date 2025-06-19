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
    public class MusculoSkeletal
    {
        #region MusculoSkeletal
        public static DataTable GetAllMusculoSkeletal(int? appId, int? msId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MUSCULO_SYSTEM_select_all_info");
                if (msId > 0)
                {
                    db.AddInParameter(dbCommand, "msId", DbType.Int32, msId);
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

        public static DataTable GetAllPreMusculoSkeletal(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MUSCULO_SYSTEM_PREVIOUS_History");
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

        public static bool InsertUpdateMusculoSkeletal(BusinessEntities.EMR.MusculoSkeletal data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MUSCULO_SYSTEM_INSERT_UPDATE");
                if (data.msId > 0)
                {
                    db.AddInParameter(dbCommand, "msId", DbType.Int32, data.msId);
                }
                db.AddInParameter(dbCommand, "ms_appId", DbType.Int32, data.ms_appId);
                db.AddInParameter(dbCommand, "ms_1", DbType.String, data.ms_1);
                db.AddInParameter(dbCommand, "ms_2", DbType.String, data.ms_2);
                db.AddInParameter(dbCommand, "ms_3", DbType.String, data.ms_3);
                db.AddInParameter(dbCommand, "ms_4", DbType.String, data.ms_4);
                db.AddInParameter(dbCommand, "ms_5", DbType.String, data.ms_5);
                db.AddInParameter(dbCommand, "ms_6", DbType.String, data.ms_6);
                db.AddInParameter(dbCommand, "ms_1_type", DbType.String, data.ms_1_type);
                db.AddInParameter(dbCommand, "ms_2_type", DbType.String, data.ms_2_type);
                db.AddInParameter(dbCommand, "ms_3_type", DbType.String, data.ms_3_type);
                db.AddInParameter(dbCommand, "ms_4_type", DbType.String, data.ms_4_type);
                db.AddInParameter(dbCommand, "ms_5_type", DbType.String, data.ms_5_type);
                db.AddInParameter(dbCommand, "ms_6_type", DbType.String, data.ms_6_type);
                db.AddInParameter(dbCommand, "ms_madeby", DbType.Int32, data.ms_madeby);

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

        public static int DeleteMusculoSkeletal(int msId, int ms_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MUSCULO_SYSTEM_delete");

                db.AddInParameter(dbCommand, "msId", DbType.Int32, msId);
                db.AddInParameter(dbCommand, "ms_madeby", DbType.String, ms_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion MusculoSkeletal
    }
}
