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
    public class PhysicianQuery
    {
        #region  Physician Query (Page Load)
        public static DataTable GetAllPhysicianQuery(int? appId, int? pqId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_QUERY_select_all_info");
                if (pqId > 0)
                {
                    db.AddInParameter(dbCommand, "pqId", DbType.Int32, pqId);
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

        public static DataTable GetAllPrePhysicianQuery(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_QUERY_PREVIOUS");
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
        #endregion  Physician Query (Page Load)

        #region  Physician Query CRUD Operations
        public static bool InsertUpdatePhysicianQuery(BusinessEntities.EMR.PhysicianQuery data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_QUERY_INSERT_UPDATE");
                if (data.pqId > 0)
                {
                    db.AddInParameter(dbCommand, "pqId", DbType.Int32, data.pqId);
                }
                db.AddInParameter(dbCommand, "pq_appId", DbType.Int32, data.pq_appId);
                db.AddInParameter(dbCommand, "pq_txt1", DbType.String, data.pq_txt1);
                db.AddInParameter(dbCommand, "pq_txt2", DbType.String, data.pq_txt2);
                db.AddInParameter(dbCommand, "pq_txt3", DbType.String, data.pq_txt3);
                db.AddInParameter(dbCommand, "pq_txt4", DbType.String, data.pq_txt4);
                db.AddInParameter(dbCommand, "pq_txt5", DbType.String, data.pq_txt5);
                db.AddInParameter(dbCommand, "pq_madeby", DbType.Int32, data.pq_madeby);

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

        public static int DeletePhysicianQuery(int pqId, int pq_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_QUERY_delete");

                db.AddInParameter(dbCommand, "pqId", DbType.Int32, pqId);
                db.AddInParameter(dbCommand, "pq_madeby", DbType.String, pq_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Physician Query CRUD Operations

        #region  Physician Query (Page Load)
        public static DataTable GetAllPhysicianNursingQuery(int? appId, int? pnqId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_NURSE_QUERY_select_all_info");
                if (pnqId > 0)
                {
                    db.AddInParameter(dbCommand, "pnqId", DbType.Int32, pnqId);
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

        public static DataTable GetEmployeeDept(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetEmployeeDept");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                
                return dt;
            }
            catch (Exception)
            {
                throw;

            }
        }

        public static DataTable GetEmployeeDetailsByID(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetEmployeeDetailsByID");
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;

            }

        }

        #endregion  Physician Query (Page Load)

        #region  Physician Nursing Query Operations
        public static bool InsertUpdatePhysicianNursingQuery(BusinessEntities.EMR.PhysicianNursingQuery data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_NURSE_QUERY_INSERT_UPDATE");
                if (data.pnqId > 0)
                {
                    db.AddInParameter(dbCommand, "pnqId", DbType.Int32, data.pnqId);
                }
                db.AddInParameter(dbCommand, "pnq_appId", DbType.Int32, data.pnq_appId);
                db.AddInParameter(dbCommand, "pnq_query", DbType.String, data.pnq_query);
                db.AddInParameter(dbCommand, "pnq_response", DbType.String, data.pnq_response);
                db.AddInParameter(dbCommand, "pnq_toemp", DbType.Int32, data.pnq_toemp);
                db.AddInParameter(dbCommand, "pnq_fromemp", DbType.Int32, data.pnq_fromemp);
                db.AddInParameter(dbCommand, "pnq_madeby", DbType.Int32, data.pnq_madeby);

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

        public static int DeletePhysicianNursingQuery(int pnqId, int pnq_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PHYSICAIN_NURSE_QUERY_delete");

                db.AddInParameter(dbCommand, "pnqId", DbType.Int32, pnqId);
                db.AddInParameter(dbCommand, "pnq_madeby", DbType.String, pnq_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion  Physician Nursing Query Operations
    }
}
