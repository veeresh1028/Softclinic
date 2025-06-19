using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessEntities.Appointment;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class DirectPayment
    {
        public static DataTable GetDirectPayments(DirectPaymentFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIRECT_PAYMENTS_GetDetail");
                if (filter.dp_branch > 0)
                    db.AddInParameter(dbCommand, "dp_branch", DbType.Int32, filter.dp_branch);

                if (filter.dpId > 0)
                    db.AddInParameter(dbCommand, "dpId", DbType.Int32, filter.dpId);

                if (!string.IsNullOrEmpty(filter.dp_debit))
                    db.AddInParameter(dbCommand, "dp_debit", DbType.String, filter.dp_debit);

                if (!string.IsNullOrEmpty(filter.dp_credit))
                    db.AddInParameter(dbCommand, "dp_credit", DbType.String, filter.dp_credit);

                if (!string.IsNullOrEmpty(filter.dp_code))
                    db.AddInParameter(dbCommand, "dp_code", DbType.String, filter.dp_code);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }
                if (!string.IsNullOrEmpty(filter.dp_status))
                {
                    string dp_status = string.Join(",", filter.dp_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "dp_status ", DbType.String, dp_status);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, filter.empId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDebitCreditByBranch(int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ACCOUNTS_GetAccount");
                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, branchId);
                DataTable ds = db.ExecuteDataSet(dbCommand).Tables[0];
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool UpdateDirectPaymentStatus(string code, string status, int branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIRECT_PAYMENTS_StatusChange");
                db.AddInParameter(dbCommand, "dp_code", DbType.String, code);
                db.AddInParameter(dbCommand, "status", DbType.String, status);
                db.AddInParameter(dbCommand, "dp_branch", DbType.Int32, branch);
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

        public static bool InsertUpdateDirectPayment(BusinessEntities.Accounts.MaterialManagement.DirectPayment data, out string dp_code, out int dpId)
        {
            dp_code = "";
            dpId = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIRECT_PAYMENTS_INSERT_UPDATE");
                db.AddInParameter(dbCommand, "dpId", DbType.Int32, data.dpId);
                db.AddInParameter(dbCommand, "dp_code", DbType.String, data.dp_code);
                db.AddInParameter(dbCommand, "dp_date", DbType.String, data.dp_date);
                db.AddInParameter(dbCommand, "dp_to", DbType.String, data.dp_to);
                db.AddInParameter(dbCommand, "dp_debit", DbType.String, data.dp_debit);
                db.AddInParameter(dbCommand, "dp_credit", DbType.String, "");
                db.AddInParameter(dbCommand, "dp_cash", DbType.Decimal, data.dp_cash);
                db.AddInParameter(dbCommand, "dp_cc", DbType.Decimal, data.dp_cc);
                db.AddInParameter(dbCommand, "dp_chq", DbType.Decimal, data.dp_chq);
                db.AddInParameter(dbCommand, "dp_chq_date", DbType.String, data.dp_chq_date);
                db.AddInParameter(dbCommand, "dp_bt", DbType.Decimal, data.dp_bt);
                db.AddInParameter(dbCommand, "dp_bt_bank", DbType.String, data.dp_bt_bank);
                db.AddInParameter(dbCommand, "dp_notes", DbType.String, data.dp_notes);
                db.AddInParameter(dbCommand, "dp_chq_no", DbType.String, data.dp_chq_no);
                db.AddInParameter(dbCommand, "dp_chq_bank", DbType.String, data.dp_chq_bank);
                db.AddInParameter(dbCommand, "dp_branch", DbType.Int32, data.dp_branch);
                db.AddInParameter(dbCommand, "dp_madeby", DbType.Int32, data.dp_madeby);
                db.AddOutParameter(dbCommand, "dpId_out", DbType.Int32, 0);
                db.AddOutParameter(dbCommand, "dpCode_out", DbType.String, 100);
                db.ExecuteNonQuery(dbCommand);

                dpId = int.Parse(db.GetParameterValue(dbCommand, "dpId_out").ToString());
                dp_code = db.GetParameterValue(dbCommand, "dpCode_out").ToString();

                if (dpId > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
            ;
        }

        public static DataTable GetDirectPaymentPrint(int dpId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DIRECT_PAYMENTS_Print");
                db.AddInParameter(dbCommand, "dpId", DbType.Int32, dpId);
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

        public static DataTable GetChartOfAccountByType(LoadAccounts data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Chart_Of_Account_By_Type");
                db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, data.branches);
                db.AddInParameter(dbCommand, "acc_period", DbType.String, data.period);
                if (string.IsNullOrEmpty(data.groups))
                    db.AddInParameter(dbCommand, "acc_type", DbType.String, "G");
                else
                    db.AddInParameter(dbCommand, "acc_type", DbType.String, data.groups);
                DataTable ds = db.ExecuteDataSet(dbCommand).Tables[0];
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PostDirectPaymentToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Direct_Payment_Post_To_Account");
                    db.AddInParameter(dbCommand, "dpId", DbType.Int32, id);
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
    }
}
