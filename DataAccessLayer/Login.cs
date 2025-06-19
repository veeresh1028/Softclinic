using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer
{
    public class Login
    {
        #region Login Authentication
        public static DataTable DAL_Employees_Check_Login_Details(string username)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Employees_Check_Login_Details");

                db.AddInParameter(dbCommand, "emp_login", DbType.String, username);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Change Password
        public static int DAL_Employees_Change_Password(string hashpass, string saltpass, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Employees_Change_Password");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "el_key1", DbType.String, hashpass);
                db.AddInParameter(dbCommand, "el_key2", DbType.String, saltpass);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable DAL_Check_First_Time_LogIn(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Employees_Check_First_Time_Login");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable DAL_Employees_Password_History(string username)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Employees_Check_Password_History");

                db.AddInParameter(dbCommand, "emp_login", DbType.String, username);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Forgot Password
        public static DataTable DAL_GetForgotPasswordDetails(string username)
        {
            try
            {
                DataTable dt = new DataTable();
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Forgot_Password_Email");

                db.AddInParameter(dbCommand, "emp_email", DbType.String, username);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Reset Password
        public static DataTable DAL_Employees_Password_History_Reset(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Employees_Check_Password_History_Reset");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable DAL_Check_Reset_Requested(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Check_Reset_Requested");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DAL_Reset_Password(int empId, string saltpass, string hashpass)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Reset_Password");

                db.AddInParameter(dbCommand, "empId", DbType.String, empId);
                db.AddInParameter(dbCommand, "el_key1", DbType.String, hashpass);
                db.AddInParameter(dbCommand, "el_key2", DbType.String, saltpass);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        #endregion
    }
}