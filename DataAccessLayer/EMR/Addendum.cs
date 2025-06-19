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
    public class Addendum
    {
        #region Addendum (Page Load)
        public static DataTable GetAllAddendum(int appId, int? addeId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADDENDUM_select_all_info");
                if (addeId > 0)
                {
                    db.AddInParameter(dbCommand, "addeId", DbType.Int32, addeId);
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

        public static DataTable GetAllPreAddendum(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADDENDUM_PREVIOUS_History");
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
        public static DataTable GetEMRTabMaster(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetEMRTabMaster");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }

        public static DataTable GetEMRTabMaster_for_Reimb_Forms(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetEMRTabMaster_for_Reimb_Forms");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }


        #endregion Addendum (Page Load)

        #region Addendum  CRUD Operations
        public static bool InsertUpdateAddendum(BusinessEntities.EMR.Addendum data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADDENDUM_INSERT_UPDATE");
                if (data.addeId > 0)
                {
                    db.AddInParameter(dbCommand, "addeId", DbType.Int32, data.addeId);
                }
                db.AddInParameter(dbCommand, "adde_appId", DbType.Int32, data.adde_appId);
                db.AddInParameter(dbCommand, "adde_for", DbType.String, data.adde_for);
                db.AddInParameter(dbCommand, "adde_notes", DbType.String, data.adde_notes);
                db.AddInParameter(dbCommand, "adde_madeby", DbType.Int32, data.adde_madeby);

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

        public static int DeleteAddendum(int addeId, int adde_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ADDENDUM_delete");
                db.AddInParameter(dbCommand, "addeId", DbType.Int32, addeId);
                db.AddInParameter(dbCommand, "adde_madeby", DbType.Int32, adde_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion Addendum  CRUD Operations

    }
}
