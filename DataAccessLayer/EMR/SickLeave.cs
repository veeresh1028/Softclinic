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
    public class SickLeave
    {
        #region  Sick Leave General (Page Load)
        public static DataTable GetAllSickLeaveGeneral(int? appId, int? slId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_select_all_info");
                if (slId > 0)
                {
                    db.AddInParameter(dbCommand, "slId", DbType.Int32, slId);
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

        public static DataTable GetAllPreSickLeaveGeneral(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_PREVIOUS");
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
        #endregion  Sick Leave General (Page Load)

        #region  Sick Leave General CRUD Operations
        public static bool InsertUpdateSickLeaveGeneral(BusinessEntities.EMR.SickLeaveGeneral data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_INSERT_UPDATE");
                if (data.slId > 0)
                {
                    db.AddInParameter(dbCommand, "slId", DbType.Int32, data.slId);
                }
                db.AddInParameter(dbCommand, "sl_appId", DbType.Int32, data.sl_appId);
                db.AddInParameter(dbCommand, "sl_disease", DbType.String, data.sl_disease);
                db.AddInParameter(dbCommand, "sl_rest", DbType.String, data.sl_rest);
                db.AddInParameter(dbCommand, "sl_date1", DbType.DateTime, data.sl_date1);
                db.AddInParameter(dbCommand, "sl_date2", DbType.DateTime, data.sl_date2);
                db.AddInParameter(dbCommand, "sl_madeby", DbType.Int32, data.sl_madeby);

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

        public static int DeleteSickLeaveGeneral(int slId, int sl_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_delete");

                db.AddInParameter(dbCommand, "slId", DbType.Int32, slId);
                db.AddInParameter(dbCommand, "sl_madeby", DbType.String, sl_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Sick Leave General CRUD Operations

        #region  Sick Leave MOH (Page Load)
        public static DataTable GetAllSickLeaveMOH(int? appId, int? slId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MOH_select_all_info");
                if (slId > 0)
                {
                    db.AddInParameter(dbCommand, "slId", DbType.Int32, slId);
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

        public static DataTable GetAllPreSickLeaveMOH(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MOH_PREVIOUS");
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
        #endregion  Sick Leave MOH (Page Load)

        #region  Sick Leave MOH CRUD Operations
        public static bool InsertUpdateSickLeaveMOH(BusinessEntities.EMR.SickLeaveMOH data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MOH_INSERT_UPDATE");
                if (data.slId > 0)
                {
                    db.AddInParameter(dbCommand, "slId", DbType.Int32, data.slId);
                }
                db.AddInParameter(dbCommand, "sl_appId", DbType.Int32, data.sl_appId);
                db.AddInParameter(dbCommand, "sl_words", DbType.String, data.sl_words);
                db.AddInParameter(dbCommand, "city", DbType.String, data.pat_city);
                db.AddInParameter(dbCommand, "sl_date1", DbType.DateTime, data.sl_date1);
                db.AddInParameter(dbCommand, "sl_date2", DbType.DateTime, data.sl_date2);
                db.AddInParameter(dbCommand, "sl_madeby", DbType.Int32, data.sl_madeby);

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

        public static int DeleteSickLeaveMOH(int slId, int sl_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MOH_delete");

                db.AddInParameter(dbCommand, "slId", DbType.Int32, slId);
                db.AddInParameter(dbCommand, "sl_madeby", DbType.String, sl_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Sick Leave MOH CRUD Operations


        #region  Sick Leave DHA (Page Load)
        public static DataTable GetAllSickLeaveDHA(int? appId, int? slmId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MANUAL_select_all_info");
                if (slmId > 0)
                {
                    db.AddInParameter(dbCommand, "slmId", DbType.Int32, slmId);
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

        public static DataTable GetAllPreSickLeaveDHA(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MANUAL_PREVIOUS");
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
        #endregion  Sick Leave DHA (Page Load)

        #region  Sick Leave DHA CRUD Operations
        public static bool InsertUpdateSickLeaveDHA(BusinessEntities.EMR.SickLeaveDHA data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MANUAL_INSERT_UPDATE");
                if (data.slmId > 0)
                {
                    db.AddInParameter(dbCommand, "slmId", DbType.Int32, data.slmId);
                }
                db.AddInParameter(dbCommand, "slm_appId", DbType.Int32, data.slm_appId);
                db.AddInParameter(dbCommand, "slm_1", DbType.String, data.slm_1);
                db.AddInParameter(dbCommand, "slm_4", DbType.String, data.slm_4);
                db.AddInParameter(dbCommand, "slm_2", DbType.DateTime, data.slm_2);
                db.AddInParameter(dbCommand, "slm_3", DbType.DateTime, data.slm_3);
                db.AddInParameter(dbCommand, "slm_madeby", DbType.Int32, data.slm_madeby);

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

        public static int DeleteSickLeaveDHA(int slmId, int slm_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SICK_LEAVE_MANUAL_delete");

                db.AddInParameter(dbCommand, "slmId", DbType.Int32, slmId);
                db.AddInParameter(dbCommand, "slm_madeby", DbType.String, slm_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Sick Leave DHA CRUD Operations
    }
}
