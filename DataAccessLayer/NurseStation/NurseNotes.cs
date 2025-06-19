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
    public class NurseNotes
    {

        #region NurseNotes (Page Load)
        public static DataTable GetAllNurseNotes(int appId, int? nurseId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NURSE_NOTES_select_all_info");
                if (nurseId > 0)
                {
                    db.AddInParameter(dbCommand, "nurseId", DbType.Int32, nurseId);
                }
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetAllPreNurseNotes(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NURSE_NOTES_PREVIOUS_History");
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
        #endregion NurseNotes (Page Load)
        #region NurseNotes Favourites CRUD Operations
        public static bool InsertUpdateNurseNotes(BusinessEntities.NurseStation.NurseNotes data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NURSE_NOTES_INSERT_UPDATE");
                if (data.nurseId > 0)
                {
                    db.AddInParameter(dbCommand, "nurseId", DbType.Int32, data.nurseId);
                }
                db.AddInParameter(dbCommand, "nurse_appId", DbType.Int32, data.nurse_appId);
                db.AddInParameter(dbCommand, "nurse_notes", DbType.String, data.nurse_notes);
                db.AddInParameter(dbCommand, "nurse_madeby", DbType.Int32, data.nurse_madeby);

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

        public static int DeleteNurseNotes(int nurseId,  int nurse_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_NURSE_NOTES_delete");


                db.AddInParameter(dbCommand, "nurseId", DbType.Int32, nurseId);
                db.AddInParameter(dbCommand, "nurse_madeby", DbType.Int32, nurse_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion NurseNotes Favourites CRUD Operations
    }
}
