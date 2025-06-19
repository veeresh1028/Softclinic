using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.NurseStation
{
    public class Allergies
    {
        #region Allergies
        public static DataTable GetAllAllergies(int? appId, int? allId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLERGIES_select_all_info");
                if (allId > 0)
                {
                    db.AddInParameter(dbCommand, "allId", DbType.Int32, allId);
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

        public static DataTable GetAllPreAllergies(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLERGIES_PREVIOUS_History");
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

        public static bool InsertUpdateAllergies(BusinessEntities.NurseStation.Allergies data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLERGIES_INSERT_UPDATE");
                if (data.allId > 0)
                {
                    db.AddInParameter(dbCommand, "allId", DbType.Int32, data.allId);
                }
                db.AddInParameter(dbCommand, "all_appId", DbType.Int32, data.all_appId);
                db.AddInParameter(dbCommand, "allergies", DbType.String, data.allergies);
                db.AddInParameter(dbCommand, "all_for", DbType.String, data.all_for);
                db.AddInParameter(dbCommand, "all_pexam", DbType.String, data.all_pexam);
                db.AddInParameter(dbCommand, "all_type", DbType.String, data.all_type);
                db.AddInParameter(dbCommand, "all_severity", DbType.String, data.all_severity);
                db.AddInParameter(dbCommand, "all_madeby", DbType.Int32, data.all_madeby);
                db.AddInParameter(dbCommand, "all_modifyby", DbType.Int32, data.all_madeby);

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

        public static DataTable get_MalaffiNabihRiyatiData(string query,string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MALAFFI_NABIDH_RIYATI_ByCodeSets");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteAllergies(int allId, int all_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ALLERGIES_delete");


                db.AddInParameter(dbCommand, "allId", DbType.Int32, allId);
                db.AddInParameter(dbCommand, "all_modifyby", DbType.Int32, all_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion Allergies
    }
}
