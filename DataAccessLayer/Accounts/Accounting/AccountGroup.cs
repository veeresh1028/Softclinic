using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BusinessEntities.Accounts.Accounting;

namespace DataAccessLayer.Accounts.Accounting
{
    public class AccountGroup
    {
        public static DataTable GetAccountGroups(AccountGroupsSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Groups_Getdetail");

                if (search.agId > 0)
                {
                    db.AddInParameter(dbCommand, "agId", DbType.Int32, search.agId);
                }

                if (!string.IsNullOrEmpty(search.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);
                }

                if (!string.IsNullOrEmpty(search.select_period))
                {
                    db.AddInParameter(dbCommand, "select_period", DbType.String, search.select_period);
                }

                if (!string.IsNullOrEmpty(search.select_types))
                {
                    string ag_type = string.Join(",", search.select_types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, ag_type);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertUpdateAccountGroup(BusinessEntities.Accounts.Accounting.AccountGroup data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Group_Insert_Update");
                db.AddInParameter(dbCommand, "agId", DbType.Int32, data.agId);
                db.AddInParameter(dbCommand, "ag_group", DbType.String, data.ag_group);
                db.AddInParameter(dbCommand, "ag_type", DbType.String, data.ag_type);
                db.AddInParameter(dbCommand, "ag_period", DbType.String, data.ag_period);
                db.AddInParameter(dbCommand, "ag_branch", DbType.String, data.ag_branch);
                db.AddInParameter(dbCommand, "empId", DbType.String, data.empId);
                db.AddOutParameter(dbCommand, "agId_out", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int agId = int.Parse(db.GetParameterValue(dbCommand, "agId_out").ToString());

                return agId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAccountGroupAuditLogs(int aga_agId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Groups_Audit_Getlogs");
                db.AddInParameter(dbCommand, "aga_agId", DbType.Int32, aga_agId);
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

        public static DataTable GetAccountGroupsByBranchPeriod(string ag_branch, string ag_period)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Groups_Get_Active_By_BranchPeriod");

                db.AddInParameter(dbCommand, "ag_branch", DbType.String, ag_branch);
                db.AddInParameter(dbCommand, "ag_period", DbType.String, ag_period);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAccountGroupById(int agId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Group_Get_By_Id");

                db.AddInParameter(dbCommand, "agId", DbType.Int32, agId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GenerateGroupCode(AccountGroupCode data)
        {
            try
            {
                string ag_output = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Group_Getcode");

                db.AddInParameter(dbCommand, "ag_branch", DbType.Int32, data.ag_branch);
                db.AddInParameter(dbCommand, "ag_type", DbType.String, data.ag_type);
                db.AddInParameter(dbCommand, "ag_period", DbType.String, data.ag_period);

                db.AddOutParameter(dbCommand, "ag_code", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                ag_output = db.GetParameterValue(dbCommand, "ag_code").ToString();

                return ag_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable AccountGroupDetails(string tr_account, string date_from, string date_to, int empId, string ag_code, string ag_period)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Transactions_Account_Groupdetails");

                db.AddInParameter(dbCommand, "tr_account", DbType.String, tr_account);
                db.AddInParameter(dbCommand, "ag_code", DbType.String, ag_code);
                db.AddInParameter(dbCommand, "ag_period", DbType.String, ag_period);
                db.AddInParameter(dbCommand, "date_from", DbType.String, date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.String, date_to);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

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