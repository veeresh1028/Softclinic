using BusinessEntities.Accounts.Accounting;
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
    public class AccountCategories
    {
        public static DataTable GetAccountCategories(AccountCategoriesSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Categories_Getdetail");

                if (search.acId > 0)
                {
                    db.AddInParameter(dbCommand, "acId", DbType.Int32, search.acId);
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
                    string ag_group = string.Join(",", search.select_group.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_group", DbType.String, ag_group);
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
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertUpdateAccountCategory(BusinessEntities.Accounts.Accounting.AccountCategories data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Category_Insert_Update");
                db.AddInParameter(dbCommand, "acId", DbType.Int32, data.acId);
                db.AddInParameter(dbCommand, "ac_group", DbType.String, data.ac_group);
                db.AddInParameter(dbCommand, "ac_category", DbType.String, data.ac_category);
                db.AddInParameter(dbCommand, "ac_period", DbType.String, data.ac_period);
                db.AddInParameter(dbCommand, "ac_branch", DbType.String, data.ac_branch);
                db.AddInParameter(dbCommand, "empId", DbType.String, data.empId);
                db.AddOutParameter(dbCommand, "acId_out", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int acId = int.Parse(db.GetParameterValue(dbCommand, "acId_out").ToString());

                return acId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAccountCategoryAuditLogs(int aca_acId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Categories_Audit_Getlogs");
                db.AddInParameter(dbCommand, "aca_acId", DbType.Int32, aca_acId);
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

        public static DataTable GetCategories(string branchIds, string period, string groupIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Categories_Get_Active_By_BranchesPeriodGroups");

                if (!string.IsNullOrEmpty(branchIds))
                {
                    db.AddInParameter(dbCommand, "select_branches", DbType.String, branchIds);
                }

                if (!string.IsNullOrEmpty(period))
                {
                    db.AddInParameter(dbCommand, "select_period", DbType.String, period);
                }

                if (!string.IsNullOrEmpty(groupIds))
                {
                    db.AddInParameter(dbCommand, "select_groups", DbType.String, groupIds);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GenerateCategoryCode(AccountCategoryCode data)
        {
            try
            {
                string ac_output = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_Category_Getcode");

                db.AddInParameter(dbCommand, "ac_branch", DbType.Int32, data.ac_branch);
                db.AddInParameter(dbCommand, "ac_group", DbType.String, data.ac_group);
                db.AddInParameter(dbCommand, "ac_period", DbType.String, data.ac_period);

                db.AddOutParameter(dbCommand, "ac_code", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                ac_output = db.GetParameterValue(dbCommand, "ac_code").ToString();

                return ac_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAccountCategoryById(int acId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Account_Category_Get_By_Id");

                db.AddInParameter(dbCommand, "acId", DbType.Int32, acId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable AccountCategoryDetails(string tr_account, string date_from, string date_to, int empId, string ac_code, string ac_period)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Transactions_Account_Categorydetails");

                db.AddInParameter(dbCommand, "tr_account", DbType.String, tr_account);
                db.AddInParameter(dbCommand, "ac_code", DbType.String, ac_code);
                db.AddInParameter(dbCommand, "ac_period", DbType.String, ac_period);
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