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
    public class RespiratorySystem
    {
        #region RespSystem

        public static DataTable GetAllRespiratorySystem(int? appId, int? resId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RESPIRATORY_select_all_info");
                if (resId > 0)
                {
                    db.AddInParameter(dbCommand, "resId", DbType.Int32, resId);
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

        public static DataTable GetAllPreRespiratorySystem(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RESPIRATORY_PREVIOUS_History");
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

        public static bool InsertUpdateRespiratorySystem(BusinessEntities.EMR.RespiratorySystem data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RESPIRATORY_INSERT_UPDATE");
                if (data.resId > 0)
                {
                    db.AddInParameter(dbCommand, "resId", DbType.Int32, data.resId);
                }
                db.AddInParameter(dbCommand, "res_appId", DbType.Int32, data.res_appId);
                db.AddInParameter(dbCommand, "res_1", DbType.String, data.res_1);
                db.AddInParameter(dbCommand, "res_2", DbType.String, data.res_2);
                db.AddInParameter(dbCommand, "res_3", DbType.String, data.res_3);
                db.AddInParameter(dbCommand, "res_4", DbType.String, data.res_4);
                db.AddInParameter(dbCommand, "res_5", DbType.String, data.res_5);
                db.AddInParameter(dbCommand, "res_6", DbType.String, data.res_6);
                db.AddInParameter(dbCommand, "res_7", DbType.String, data.res_7);
                db.AddInParameter(dbCommand, "res_8", DbType.String, data.res_8);
                db.AddInParameter(dbCommand, "res_1_type", DbType.String, data.res_1_type);
                db.AddInParameter(dbCommand, "res_2_type", DbType.String, data.res_2_type);
                db.AddInParameter(dbCommand, "res_3_type", DbType.String, data.res_3_type);
                db.AddInParameter(dbCommand, "res_4_type", DbType.String, data.res_4_type);
                db.AddInParameter(dbCommand, "res_5_type", DbType.String, data.res_5_type);
                db.AddInParameter(dbCommand, "res_6_type", DbType.String, data.res_6_type);
                db.AddInParameter(dbCommand, "res_7_type", DbType.String, data.res_7_type);
                db.AddInParameter(dbCommand, "res_8_type", DbType.String, data.res_8_type);
                db.AddInParameter(dbCommand, "res_madeby", DbType.Int32, data.res_madeby);

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

        public static int DeleteRespiratorySystem(int resId, int res_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RESPIRATORY_delete");

                db.AddInParameter(dbCommand, "resId", DbType.Int32, resId);
                db.AddInParameter(dbCommand, "res_madeby", DbType.String, res_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion RespSystem
    }
}
