using BusinessEntities.Accounts.Accounting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Appointment;

namespace DataAccessLayer.Accounts.Accounting
{
    public class ChartOfAccounts
    {
        public static DataTable GetChartOfAccounts(ChartOfAccountsSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chart_Of_Accounts_Getdetails");

                if (search.accId > 0)
                {
                    db.AddInParameter(dbCommand, "accId", DbType.Int32, search.accId);
                }

                if (!string.IsNullOrEmpty(search.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);
                }

                if (!string.IsNullOrEmpty(search.select_period))
                {
                    db.AddInParameter(dbCommand, "select_period", DbType.String, search.select_period);
                }

                if (!string.IsNullOrEmpty(search.select_group))
                {
                    string acc_group = string.Join(",", search.select_group.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_group", DbType.String, acc_group);
                }

                if (!string.IsNullOrEmpty(search.select_category))
                {
                    string acc_category = string.Join(",", search.select_category.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_category", DbType.String, acc_category);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "select_date_from", DbType.DateTime, search.select_date_from);

                db.AddInParameter(dbCommand, "select_date_to", DbType.DateTime, search.select_date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertUpdateChartOfAccount(BusinessEntities.Accounts.Accounting.ChartOfAccounts data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chart_Of_Account_Insert_Update");
                db.AddInParameter(dbCommand, "accId", DbType.Int32, data.accId);
                db.AddInParameter(dbCommand, "acc_parent", DbType.String, 0);
                db.AddInParameter(dbCommand, "acc_cbal", DbType.Decimal, 0);
                db.AddInParameter(dbCommand, "acc_group", DbType.String, data.acc_group);
                db.AddInParameter(dbCommand, "acc_category", DbType.String, data.acc_category);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, data.acc_period);
                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, data.acc_branch);
                db.AddInParameter(dbCommand, "acc_type", DbType.String, data.acc_type);
                db.AddInParameter(dbCommand, "acc_name", DbType.String, data.acc_name);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddOutParameter(dbCommand, "accId_out", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int accId = int.Parse(db.GetParameterValue(dbCommand, "accId_out").ToString());

                return accId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetChartOfAccountsAuditLogs(int acca_accId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Chart_Of_Accounts_Audit_Getlogs");
                db.AddInParameter(dbCommand, "acca_accId", DbType.Int32, acca_accId);
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

        public static string GenerateCOACode(ChartOfAccountsCode data)
        {
            try
            {
                string acc_output = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_COA_Getcode");

                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, data.acc_branch);
                db.AddInParameter(dbCommand, "acc_category", DbType.String, data.acc_category);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, data.acc_period);

                db.AddOutParameter(dbCommand, "acc_code", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                acc_output = db.GetParameterValue(dbCommand, "acc_code").ToString();

                return acc_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable AccountDetails(string tr_account, string date_from, string date_to, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Transactions_Accountdetails");

                db.AddInParameter(dbCommand, "tr_account", DbType.String, tr_account);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, date_to);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetInvoiceType(int invId)
        {
            try
            {
                string type_output = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Invoice_Gettype");

                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);

                db.AddOutParameter(dbCommand, "inv_type", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                type_output = db.GetParameterValue(dbCommand, "inv_type").ToString();

                return type_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAccountsDropdown(LoadAccounts filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_SearchDropdown");

                db.AddInParameter(dbCommand, "query", DbType.String, filter.query);
                db.AddInParameter(dbCommand, "acc_branch", DbType.String, filter.branches);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, filter.period);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static DataTable GetAccountDropdownByCode(string acc_code, string acc_period, int acc_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Get_ByCode");

                db.AddInParameter(dbCommand, "acc_code", DbType.String, acc_code);
                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, acc_branch);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, acc_period);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static DataTable GetActiveChartOfAccountsDropdown(string acc_type, string acc_period, int acc_branch, string acc_gtype)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Active_Chart_Of_Accounts");

                db.AddInParameter(dbCommand, "acc_type", DbType.String, acc_type);
                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, acc_branch);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, acc_period);
                db.AddInParameter(dbCommand, "acc_gtype", DbType.String, acc_gtype);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}