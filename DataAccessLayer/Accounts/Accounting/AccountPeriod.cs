using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.Accounting
{
    public class AccountPeriod
    {
        public static DataTable GetAccountPeriods(int apId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Period_Getdetail");

                if (apId > 0)
                {
                    db.AddInParameter(dbCommand, "apId", DbType.Int32, apId);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                
                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetActiveAccountPeriods()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Accounts_Periods");

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetOpenAccountPeriod()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Account_Open_Period");

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertUpdateAccountPeriod(BusinessEntities.Accounts.Accounting.AccountPeriod data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Period_Insert_Update");
                db.AddInParameter(dbCommand, "apId", DbType.Int32, data.apId);
                db.AddInParameter(dbCommand, "ap_name", DbType.String, data.ap_name);
                db.AddInParameter(dbCommand, "ap_fdate", DbType.String, data.ap_fdate);
                db.AddInParameter(dbCommand, "ap_tdate", DbType.String, data.ap_tdate);
                db.AddInParameter(dbCommand, "empId", DbType.String, data.empId);
                db.AddOutParameter(dbCommand, "apId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int apId = int.Parse(db.GetParameterValue(dbCommand, "apId_out").ToString());

                return apId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangeAccountPeriodStatus(int apId, string ap_status, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Period_Updatestatus");
                db.AddInParameter(dbCommand, "apId", DbType.Int32, apId);
                db.AddInParameter(dbCommand, "ap_status", DbType.String, ap_status);
                db.AddInParameter(dbCommand, "empId", DbType.String, empId);
                db.AddOutParameter(dbCommand, "apId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int data = int.Parse(db.GetParameterValue(dbCommand, "apId_out").ToString());

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetAccountPeriodAuditLogs(int apa_apId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Period_Audit_Getlogs");
                db.AddInParameter(dbCommand, "apa_apId", DbType.Int32, apa_apId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}