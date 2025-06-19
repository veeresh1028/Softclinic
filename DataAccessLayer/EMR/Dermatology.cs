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
    public class Dermatology
    {
        #region  Dermatology Notes (Page Load)
        public static DataTable GetAllDermaNotes(int? appId, int? dnId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DERMA_NOTES_select_all_info");
                if (dnId > 0)
                {
                    db.AddInParameter(dbCommand, "dnId", DbType.Int32, dnId);
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

        public static DataTable GetAllPreDermaNotes(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DERMA_NOTES_PREVIOUS");
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
        #endregion  Dermatology Notes (Page Load)

        #region  Dermatology Notes CRUD Operations
        public static bool InsertUpdateDermaNotes(BusinessEntities.EMR.DermatologyNotes data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DERMA_NOTES_INSERT_UPDATE");
                if (data.dnId > 0)
                {
                    db.AddInParameter(dbCommand, "dnId", DbType.Int32, data.dnId);
                }
                db.AddInParameter(dbCommand, "dn_appId", DbType.Int32, data.dn_appId);
                db.AddInParameter(dbCommand, "dn_notes", DbType.String, data.dn_notes);
                db.AddInParameter(dbCommand, "dn_madeby", DbType.Int32, data.dn_madeby);

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

        public static int DeleteDermaNotes(int dnId, int dn_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DERMA_NOTES_delete");

                db.AddInParameter(dbCommand, "dnId", DbType.Int32, dnId);
                db.AddInParameter(dbCommand, "dn_madeby", DbType.String, dn_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Dermatology Notes CRUD Operations
    }
}
