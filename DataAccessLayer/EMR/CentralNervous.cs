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
    public class CentralNervous
    {

        public static DataTable GetAllCentralNervous(int? appId, int? cnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CENTRAL_NERVOUS_select_all_info");
                if (cnId > 0)
                {
                    db.AddInParameter(dbCommand, "cnId", DbType.Int32, cnId);
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

        public static DataTable GetAllPreCentralNervous(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CENTRAL_NERVOUS_PREVIOUS_History");
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

        public static bool InsertUpdateCentralNervous(BusinessEntities.EMR.CentralNervous data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CENTRAL_NERVOUS_INSERT_UPDATE");
                if (data.cnId > 0)
                {
                    db.AddInParameter(dbCommand, "cnId", DbType.Int32, data.cnId);
                }
                db.AddInParameter(dbCommand, "cn_appId", DbType.Int32, data.cn_appId);
                db.AddInParameter(dbCommand, "cn_1", DbType.String, data.cn_1);
                db.AddInParameter(dbCommand, "cn_2", DbType.String, data.cn_2);
                db.AddInParameter(dbCommand, "cn_3", DbType.String, data.cn_3);
                db.AddInParameter(dbCommand, "cn_4", DbType.String, data.cn_4);
                db.AddInParameter(dbCommand, "cn_5", DbType.String, data.cn_5);
                db.AddInParameter(dbCommand, "cn_6", DbType.String, data.cn_6);
                db.AddInParameter(dbCommand, "cn_7", DbType.String, data.cn_7);
                db.AddInParameter(dbCommand, "cn_8", DbType.String, data.cn_8);
                db.AddInParameter(dbCommand, "cn_9", DbType.String, data.cn_9);
                db.AddInParameter(dbCommand, "cn_1_type", DbType.String, data.cn_1_type);
                db.AddInParameter(dbCommand, "cn_2_type", DbType.String, data.cn_2_type);
                db.AddInParameter(dbCommand, "cn_3_type", DbType.String, data.cn_3_type);
                db.AddInParameter(dbCommand, "cn_4_type", DbType.String, data.cn_4_type);
                db.AddInParameter(dbCommand, "cn_5_type", DbType.String, data.cn_5_type);
                db.AddInParameter(dbCommand, "cn_6_type", DbType.String, data.cn_6_type);
                db.AddInParameter(dbCommand, "cn_7_type", DbType.String, data.cn_7_type);
                db.AddInParameter(dbCommand, "cn_8_type", DbType.String, data.cn_8_type);
                db.AddInParameter(dbCommand, "cn_9_type", DbType.String, data.cn_9_type);
                db.AddInParameter(dbCommand, "cn_madeby", DbType.Int32, data.cn_madeby);

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

        public static int DeleteCentralNervous(int cnId, int cn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CENTRAL_NERVOUS_delete");

                db.AddInParameter(dbCommand, "cnId", DbType.Int32, cnId);
                db.AddInParameter(dbCommand, "cn_madeby", DbType.String, cn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
