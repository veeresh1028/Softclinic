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
    public class GastroIntestinal
    {
        #region GastoIntestial (Page Load)
        public static DataTable GetAllGastroIntestinal(int? appId, int? giId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GASTRO_INTESTINAL_select_all_info");
                if (giId > 0)
                {
                    db.AddInParameter(dbCommand, "giId", DbType.Int32, giId);
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

        public static DataTable GetAllPreGastroIntestinal(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GASTRO_INTESTINAL_PREVIOUS_History");
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
        #endregion GastoIntestial (Page Load)
        #region GastoIntestial CRUD Operations
        public static bool InsertUpdateGastroIntestinal(BusinessEntities.EMR.GastroIntestinal data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GASTRO_INTESTINAL_INSERT_UPDATE");
                if (data.giId > 0)
                {
                    db.AddInParameter(dbCommand, "giId", DbType.Int32, data.giId);
                }
                db.AddInParameter(dbCommand, "gi_appId", DbType.Int32, data.gi_appId);
                db.AddInParameter(dbCommand, "gi_1", DbType.String, data.gi_1);
                db.AddInParameter(dbCommand, "gi_2", DbType.String, data.gi_2);
                db.AddInParameter(dbCommand, "gi_3", DbType.String, data.gi_3);
                db.AddInParameter(dbCommand, "gi_4", DbType.String, data.gi_4);
                db.AddInParameter(dbCommand, "gi_5", DbType.String, data.gi_5);
                db.AddInParameter(dbCommand, "gi_6", DbType.String, data.gi_6);
                db.AddInParameter(dbCommand, "gi_7", DbType.String, data.gi_7);
                db.AddInParameter(dbCommand, "gi_8", DbType.String, data.gi_8);
                db.AddInParameter(dbCommand, "gi_9", DbType.String, data.gi_9);
                db.AddInParameter(dbCommand, "gi_10", DbType.String, data.gi_10);
                db.AddInParameter(dbCommand, "gi_11", DbType.String, data.gi_11);
                db.AddInParameter(dbCommand, "gi_12", DbType.String, data.gi_12);
                db.AddInParameter(dbCommand, "gi_13", DbType.String, data.gi_13);
                db.AddInParameter(dbCommand, "gi_14", DbType.String, data.gi_14);
                db.AddInParameter(dbCommand, "gi_1_type", DbType.String, data.gi_1_type);
                db.AddInParameter(dbCommand, "gi_2_type", DbType.String, data.gi_2_type);
                db.AddInParameter(dbCommand, "gi_3_type", DbType.String, data.gi_3_type);
                db.AddInParameter(dbCommand, "gi_4_type", DbType.String, data.gi_4_type);
                db.AddInParameter(dbCommand, "gi_5_type", DbType.String, data.gi_5_type);
                db.AddInParameter(dbCommand, "gi_6_type", DbType.String, data.gi_6_type);
                db.AddInParameter(dbCommand, "gi_7_type", DbType.String, data.gi_7_type);
                db.AddInParameter(dbCommand, "gi_8_type", DbType.String, data.gi_8_type);
                db.AddInParameter(dbCommand, "gi_9_type", DbType.String, data.gi_9_type);
                db.AddInParameter(dbCommand, "gi_10_type", DbType.String, data.gi_10_type);
                db.AddInParameter(dbCommand, "gi_11_type", DbType.String, data.gi_11_type);
                db.AddInParameter(dbCommand, "gi_12_type", DbType.String, data.gi_12_type);
                db.AddInParameter(dbCommand, "gi_13_type", DbType.String, data.gi_13_type);
                db.AddInParameter(dbCommand, "gi_14_type", DbType.String, data.gi_14_type);
                db.AddInParameter(dbCommand, "gi_madeby", DbType.Int32, data.gi_madeby);

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

        public static int DeleteGastroIntestinal(int giId, int gi_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GASTRO_INTESTINAL_delete");

                db.AddInParameter(dbCommand, "giId", DbType.Int32, giId);
                db.AddInParameter(dbCommand, "gi_madeby", DbType.String, gi_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion GastoIntestial CRUD Operations
    }
}
