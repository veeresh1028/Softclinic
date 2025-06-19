using BusinessEntities.Accounts.Accounting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer.Accounts.Accounting
{
    public class FundsTransfer
    {
        public static DataTable GetFundsTransfer(FundsTransferSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Funds_Transfer_Get_Details");

                if (search.ftId > 0)
                {
                    db.AddInParameter(dbCommand, "ftId", DbType.Int32, search.ftId);
                }

                if (!string.IsNullOrEmpty(search.select_branch))
                {
                    db.AddInParameter(dbCommand, "ft_branch", DbType.String, search.select_branch);
                }

                if (!string.IsNullOrEmpty(search.ft_from))
                {
                    db.AddInParameter(dbCommand, "ft_from", DbType.String, search.ft_from);
                }
                
                if (!string.IsNullOrEmpty(search.ft_to))
                {
                    db.AddInParameter(dbCommand, "ft_to", DbType.String, search.ft_to);
                }

                if (!string.IsNullOrEmpty(search.select_refno))
                {
                    db.AddInParameter(dbCommand, "ft_refno", DbType.String, search.select_refno);
                }
                

                if (!string.IsNullOrEmpty(search.ft_code))
                {
                    db.AddInParameter(dbCommand, "ft_code", DbType.String, search.ft_code);
                }

                if (!string.IsNullOrEmpty(search.select_period))
                {
                    db.AddInParameter(dbCommand, "ft_period", DbType.String, search.select_period);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.select_date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.select_date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertFundsTransfer(BusinessEntities.Accounts.Accounting.FundsTransfer data)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Funds_Transfer_Insert_Update");
                db.AddInParameter(dbCommand, "ftId", DbType.Int32, data.ftId);
                db.AddInParameter(dbCommand, "ft_code", DbType.String, data.ft_code);
                db.AddInParameter(dbCommand, "ft_date", DbType.DateTime, data.ft_date);
                db.AddInParameter(dbCommand, "ft_from", DbType.String, data.ft_from);
                db.AddInParameter(dbCommand, "ft_to", DbType.String, data.ft_to);
                db.AddInParameter(dbCommand, "ft_amount", DbType.Decimal, data.ft_amount);
                db.AddInParameter(dbCommand, "ft_refno", DbType.String, data.ft_refno);
                db.AddInParameter(dbCommand, "ft_branch", DbType.Int32, data.ft_branch);
                db.AddInParameter(dbCommand, "ft_acc_period", DbType.String, data.ft_acc_period);
                db.AddInParameter(dbCommand, "ft_comments", DbType.String, data.ft_comments);
                db.AddInParameter(dbCommand, "ft_madeby", DbType.String, data.ft_madeby);
                db.AddOutParameter(dbCommand, "ft_outId", DbType.Int32, 0);

                db.ExecuteNonQuery(dbCommand);

                int agId = int.Parse(db.GetParameterValue(dbCommand, "ft_outId").ToString());

                return agId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ChangeFundTransferStatus(string ft_code, int ft_branch, string status, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Funds_Transfer_Status_Change");
                db.AddInParameter(dbCommand, "ft_code", DbType.String, ft_code);
                db.AddInParameter(dbCommand, "status", DbType.String, status);
                db.AddInParameter(dbCommand, "ft_branch", DbType.String, ft_branch);
                db.AddInParameter(dbCommand, "empId", DbType.String, empId);
                db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int data = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static DataTable GetFundTransferAuditLogs(string ft_code, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Funds_Transfer_Audit_Get_Logs");
                db.AddInParameter(dbCommand, "fta_code", DbType.String, ft_code);
                db.AddInParameter(dbCommand, "empId", DbType.String, empId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
