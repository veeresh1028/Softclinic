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
    public class ProgressNotes
    {
        #region ProgressNotes (Page Load)
        public static DataTable GetAllProgressNotes(int? appId, int? mnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MED_NOTES_select_all_info");
                if (mnId > 0)
                {
                    db.AddInParameter(dbCommand, "mnId", DbType.Int32, mnId);
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

        public static DataTable GetAllPreProgressNotes(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MED_NOTES_PREVIOUS");
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
        public static DataTable GetNotes(string query,string nsm_flag)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetNotesMaster");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "nsm_flag", DbType.String, nsm_flag);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }


        #endregion ProgressNotes (Page Load)

        #region ProgressNotes  CRUD Operations
        public static bool InsertUpdateProgressNotes(BusinessEntities.EMR.ProgressNotes data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MED_NOTES_INSERT_UPDATE");
                if (data.mnId > 0)
                {
                    db.AddInParameter(dbCommand, "mnId", DbType.Int32, data.mnId);
                }
                db.AddInParameter(dbCommand, "mn_appId", DbType.Int32, data.mn_appId);
                db.AddInParameter(dbCommand, "mn_notes", DbType.String, data.mn_notes);
                db.AddInParameter(dbCommand, "mn_visitPlan", DbType.String, data.mn_visitPlan);
                db.AddInParameter(dbCommand, "mn_instructions", DbType.String, data.mn_instructions);
                db.AddInParameter(dbCommand, "mn_madeby", DbType.Int32, data.mn_madeby);

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

        public static int DeleteProgressNotes(int mnId, int mn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_MED_NOTES_delete");
                db.AddInParameter(dbCommand, "mnId", DbType.Int32, mnId);
                db.AddInParameter(dbCommand, "mn_madeby", DbType.Int32, mn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion ProgressNotes  CRUD Operations
    }
}
