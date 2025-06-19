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
    public class AccountReports
    {
        public static DataTable GetProfitLossReport(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Profit_Loss_Account_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetProfitLossSummaryReport(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Profit_Loss_Account_Summary");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBalanceSheetReport(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Balance_Sheet_Account_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBalanceSheetSummaryReport(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Balance_Sheet_Account_Summary");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetCashFlowStatement(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Cash_Flow_Statement_Account_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetTrialBalanceDetail(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Trial_Balance_Account_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAccountReconciliationDetail(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Account_Reconciliation_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                if (!string.IsNullOrEmpty(search.status))
                    db.AddInParameter(dbCommand, "status", DbType.DateTime, search.status);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool ReconcilAccountTranansaction(string data, string status, string date, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Update_Transaction_Status_Update");
                db.AddInParameter(dbCommand, "trIds", DbType.String, data);
                db.AddInParameter(dbCommand, "reconcil_date", DbType.String, date);
                db.AddInParameter(dbCommand, "status", DbType.String, status);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());
                if (result > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSupplierAgeAnalysis(int branch, int empId, string date)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Supplier_Age_Analysis");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "due_date", DbType.String, date);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPatientAgeAnalysis(int branch, int empId, string date)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_Age_Analysis");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "due_date", DbType.String, date);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceAgeAnalysis(int branch, int empId, string date)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Insurance_Comapnies_Age_Analysis");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "due_date", DbType.String, date);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Account VAT Report
        public static DataTable getAccountVATDetail(ReportFilters search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Accounts_VAT_Report");

                db.AddInParameter(dbCommand, "avr_branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                if (!string.IsNullOrEmpty(search.date_from) && !string.IsNullOrEmpty(search.date_to))
                {
                    db.AddInParameter(dbCommand, "avr_date_from", DbType.DateTime, search.date_from);

                    db.AddInParameter(dbCommand, "avr_date_to", DbType.DateTime, search.date_to);
                }

                if (!string.IsNullOrEmpty(search.status))
                {
                    string status = string.Join(",", search.status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "status", DbType.String, status);
                }


                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int GenerateAccountVATReport(ReportFilters data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_VAT_Report_InsertUpdate");

                db.AddInParameter(dbCommand, "avr_branch", DbType.Int32, data.branch);

                db.AddInParameter(dbCommand, "avr_date_from", DbType.DateTime, data.date_from);

                db.AddInParameter(dbCommand, "avr_date_to", DbType.DateTime, data.date_to);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);

                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int result = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangeAccountVATReportStatus(string data, string status, string date, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Accounts_VAT_Update_Status");
                    db.AddInParameter(dbCommand, "avrId", DbType.Int32, id);
                    db.AddInParameter(dbCommand, "status", DbType.String, status);
                    db.AddInParameter(dbCommand, "date", DbType.DateTime, date);
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                    db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                    db.ExecuteNonQuery(dbCommand);

                    int result = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                    if (result > 0)
                        sucsess++;
                    if (result == -1)
                        excced++;
                    if (result == 0)
                        error++;
                }
                if (sucsess > 0 && excced == 0 && error == 0)
                {
                    return 1;
                }
                else if (sucsess > 0 && excced > 0 && error == 0)
                {
                    return -2;
                }
                else if (sucsess > 0 && excced > 0 && error > 0)
                {
                    return -2;
                }
                else if (sucsess == 0 && excced > 0 && error == 0)
                {
                    return -1;
                }
                else
                {
                    return -3;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSalesInvoiceVATDetail(int branch, string date_from, string date_to)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Sales_Invoice_VAT_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static DataTable GetSalesReturnVATDetail(int branch, string date_from, string date_to)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Sales_Return_VAT_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static DataTable GetPurchaseInvoiceVATDetail(int branch, string date_from, string date_to)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Purchase_Invoice_VAT_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPurchaseReturnVATDetail(int branch, string date_from, string date_to)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Purchase_Return_VAT_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Statement of Account
        public static DataTable GetAccountsDropdown(LoadAccounts filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Accounts_ForDropdown");

                db.AddInParameter(dbCommand, "query", DbType.String, filter.query);
                db.AddInParameter(dbCommand, "acc_branch", DbType.String, filter.branches);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, filter.period);

                if (!string.IsNullOrEmpty(filter.groups))
                {
                    string acc_group = string.Join(",", filter.groups.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "acc_group", DbType.String, acc_group);
                }

                if (!string.IsNullOrEmpty(filter.categories))
                {
                    string acc_category = string.Join(",", filter.categories.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "acc_categories", DbType.String, acc_category);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetStatementOfAccounts(ChartOfAccountsSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Statement_Of_Accounts");

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
                
                if (!string.IsNullOrEmpty(search.select_account))
                {
                    db.AddInParameter(dbCommand, "select_account", DbType.String, search.select_account);
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

        #endregion
    }
}
