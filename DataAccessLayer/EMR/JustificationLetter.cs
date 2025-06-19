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
    public class JustificationLetter
    {

        #region  Justification Letter (Page Load)
        public static DataTable GetAllJustificationLetter(int? appId, int? jlId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Justification_Letter_select_all_info");
                if (jlId > 0)
                {
                    db.AddInParameter(dbCommand, "jlId", DbType.Int32, jlId);
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

        public static DataTable GetAllPreJustificationLetter(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Justification_Letter_PREVIOUS");
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
        #endregion  Justification Letter (Page Load)

        #region  Justification Letter CRUD Operations
        public static bool InsertUpdateJustificationLetter(BusinessEntities.EMR.JustificationLetter data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Justification_Letter_INSERT_UPDATE");
                if (data.jlId > 0)
                {
                    db.AddInParameter(dbCommand, "jlId", DbType.Int32, data.jlId);
                }
                db.AddInParameter(dbCommand, "jl_appId", DbType.Int32, data.jl_appId);
                db.AddInParameter(dbCommand, "jl_note", DbType.String, data.jl_note);
                db.AddInParameter(dbCommand, "jl_date", DbType.DateTime, data.jl_date);
                db.AddInParameter(dbCommand, "jl_madeby", DbType.Int32, data.jl_madeby);

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

        public static int DeleteJustificationLetter(int jlId, int jl_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Justification_Letter_delete");

                db.AddInParameter(dbCommand, "jlId", DbType.Int32, jlId);
                db.AddInParameter(dbCommand, "jl_madeby", DbType.String, jl_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Justification Letter CRUD Operations

        #region  Health Declaration (Page Load)
        public static DataTable GetAllHealthDeclaration(int? appId, int? chd_Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_DECLARATION_select_all_info");
                if (chd_Id > 0)
                {
                    db.AddInParameter(dbCommand, "chd_Id", DbType.Int32, chd_Id);
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

        public static DataTable GetAllPreHealthDeclaration(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_DECLARATION_PREVIOUS");
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
        #endregion  Health Declaration (Page Load)

        #region  Health Declaration CRUD Operations
        public static bool InsertUpdateHealthDeclaration(BusinessEntities.EMR.HealthDeclaration data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_DECLARATION_INSERT_UPDATE");
                if (data.chd_Id > 0)
                {
                    db.AddInParameter(dbCommand, "chd_Id", DbType.Int32, data.chd_Id);
                }
                db.AddInParameter(dbCommand, "chd_appId", DbType.Int32, data.chd_appId);
                db.AddInParameter(dbCommand, "chd_checkbox", DbType.String, data.chd_checkbox);
                db.AddInParameter(dbCommand, "chd_Prob1", DbType.String, data.chd_Prob1);
                db.AddInParameter(dbCommand, "chd_Prob2", DbType.String, data.chd_Prob2);
                db.AddInParameter(dbCommand, "chd_Prob3", DbType.String, data.chd_Prob3);
                db.AddInParameter(dbCommand, "chd_Prob4", DbType.String, data.chd_Prob4);
                db.AddInParameter(dbCommand, "chd_Prob5", DbType.String, data.chd_Prob5);
                db.AddInParameter(dbCommand, "chd_madeby", DbType.Int32, data.chd_madeby);

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

        public static int DeleteHealthDeclaration(int chd_Id, int chd_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_HEALTH_DECLARATION_delete");

                db.AddInParameter(dbCommand, "chd_Id", DbType.Int32, chd_Id);
                db.AddInParameter(dbCommand, "chd_madeby", DbType.String, chd_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Health Declaration CRUD Operations
    }
}
