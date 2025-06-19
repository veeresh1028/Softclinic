using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class Payment
    {
        #region Advacne Payment Data Logics
        public static DataTable GetAdvancePayments(PaymentFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_GetDetail");
                if (filter.pay_branch > 0)
                    db.AddInParameter(dbCommand, "pay_branch", DbType.Int32, filter.pay_branch);

                if (filter.payId > 0)
                    db.AddInParameter(dbCommand, "payId", DbType.Int32, filter.payId);
                
                if (filter.pay_supplier > 0)
                    db.AddInParameter(dbCommand, "pay_supplier", DbType.Int32, filter.pay_supplier);
                
                if (filter.pay_invoice > 0)
                    db.AddInParameter(dbCommand, "pay_invoice", DbType.Int32, filter.pay_invoice);

                if (!string.IsNullOrEmpty(filter.pay_code))
                    db.AddInParameter(dbCommand, "pay_code", DbType.String, filter.pay_code);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }
                
                if (!string.IsNullOrEmpty(filter.chq_from_date) && (!string.IsNullOrEmpty(filter.chq_to_date)))
                {
                    db.AddInParameter(dbCommand, "chq_from_date", DbType.String, filter.chq_from_date);
                    db.AddInParameter(dbCommand, "chq_to_date", DbType.String, filter.chq_to_date);
                }

                if (!string.IsNullOrEmpty(filter.pay_type))
                {
                    string pay_type = string.Join(",", filter.pay_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pay_type ", DbType.String, pay_type);
                }
                
                if (!string.IsNullOrEmpty(filter.pay_status))
                {
                    string pay_status = string.Join(",", filter.pay_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pay_status ", DbType.String, pay_status);
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
        public static DataTable GetSuppliersWithAdvance(int sup_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_SupplierList_WithAdavce");
                db.AddInParameter(dbCommand, "pay_branch", DbType.Int32, sup_branch);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetAdvanceWithSupplier(int pay_supplier)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_WithAdavce");
                db.AddInParameter(dbCommand, "pay_supplier", DbType.Int32, pay_supplier);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertAdvancePayment(BusinessEntities.Accounts.MaterialManagement.Payment data, out string pay_code, out int payId, string type)
        {
            pay_code = "";
            payId = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                DbCommand dbCommand;

                if(type == "Invoice")
                    dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_PURCHASE_INVOICE_INSERT_UPDATE");
                else
                    dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_ADVANCE_REFUND_INSERT_UPDATE");

                db.AddInParameter(dbCommand, "payId", DbType.Int32, data.payId);
                db.AddInParameter(dbCommand, "pay_code", DbType.String, data.pay_code);
                db.AddInParameter(dbCommand, "pay_date", DbType.String, data.pay_date);
                db.AddInParameter(dbCommand, "pay_type", DbType.String, data.pay_type);
                db.AddInParameter(dbCommand, "pay_supplier", DbType.Int32, data.pay_supplier);
                db.AddInParameter(dbCommand, "pay_invoice", DbType.Int32, data.pay_invoice);
                db.AddInParameter(dbCommand, "pay_cash", DbType.Decimal, data.pay_cash);
                db.AddInParameter(dbCommand, "pay_cc", DbType.Decimal, data.pay_cc);
                db.AddInParameter(dbCommand, "pay_cc_per", DbType.Decimal, data.pay_cc_per);
                db.AddInParameter(dbCommand, "pay_chq", DbType.Decimal, data.pay_chq);
                db.AddInParameter(dbCommand, "pay_chq_no", DbType.String, data.pay_chq_no);
                db.AddInParameter(dbCommand, "pay_chq_date", DbType.String, data.pay_chq_date);
                db.AddInParameter(dbCommand, "pay_chq_bank", DbType.String, data.pay_chq_bank);
                db.AddInParameter(dbCommand, "pay_bt", DbType.Decimal, data.pay_bt);
                db.AddInParameter(dbCommand, "pay_bt_bank", DbType.String, data.pay_bt_bank);
                db.AddInParameter(dbCommand, "pay_advance", DbType.Int32, data.pay_advance);
                db.AddInParameter(dbCommand, "pay_allocated", DbType.Decimal, data.pay_allocated);
                db.AddInParameter(dbCommand, "pay_notes", DbType.String, data.pay_notes);
                db.AddInParameter(dbCommand, "pay_madeby", DbType.Int32, data.pay_madeby);
                db.AddInParameter(dbCommand, "pay_dinvoice", DbType.Int32, data.pay_dinvoice);
                db.AddInParameter(dbCommand, "pay_cash_bank", DbType.String, data.pay_cash_bank);
                db.AddInParameter(dbCommand, "pay_branch", DbType.Int32, data.pay_branch);
                db.AddInParameter(dbCommand, "pay_cc_bank", DbType.String, data.pay_cc_bank);
                db.AddInParameter(dbCommand, "pay_refunded", DbType.Decimal, data.pay_refunded);

                db.AddOutParameter(dbCommand, "payId_out", DbType.Int32, 0);
                db.AddOutParameter(dbCommand, "payCode_out", DbType.String, 100);
                db.ExecuteNonQuery(dbCommand);

                payId = int.Parse(db.GetParameterValue(dbCommand, "payId_out").ToString());
                pay_code = db.GetParameterValue(dbCommand, "payCode_out").ToString();

                if (payId > 0)
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
        public static int UpdateAdvancePaymentStatus(int payId, string status, int empId, string pay_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_AdavceRefund_StatusChange");
                db.AddInParameter(dbCommand, "payId", DbType.Int32, payId);
                db.AddInParameter(dbCommand, "status", DbType.String, status);
                db.AddInParameter(dbCommand, "pay_type ", DbType.String, pay_type);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
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

        #endregion

        #region Payment Against Purchase Invoice Data Logics
        public static DataTable GetSupplierByBranchesAndPending(string query, int branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHAES_INVOICE_GetBySupplier");
                db.AddInParameter(dbCommand, "sup_name", DbType.String, query);
                db.AddInParameter(dbCommand, "branchId", DbType.Int32, branch);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetAllPaymentsForPurchaseInvoice(int pinvId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetAllPaymentsForPurchaseInvoice");

                db.AddInParameter(dbCommand, "pinvId", DbType.String, pinvId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable AdvancePaymentsBySupllier(int pay_supplier)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_AdvanceBySupplier");
                db.AddInParameter(dbCommand, "pay_supplier", DbType.Int32, pay_supplier);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeletePaymentById(int payId, int madeby, int pay_invoice, int pay_supplier)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PAYMENTS_InvoicePaymentDelete");
                db.AddInParameter(dbCommand, "payId", DbType.Int32, payId);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                db.AddInParameter(dbCommand, "pay_invoice", DbType.Int32, pay_invoice);
                db.AddInParameter(dbCommand, "pay_supplier", DbType.Int32, pay_supplier);
                db.AddOutParameter(dbCommand, "outId", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);
                int result = int.Parse(db.GetParameterValue(dbCommand, "outId").ToString());
                return result;  
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PostPaymentToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Payment_Post_To_Account");
                    db.AddInParameter(dbCommand, "payId", DbType.Int32, id);
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
        
        public static int PostAdvancePaymentToAccount(string data, string type, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                string[] _type = type.Split(',');
                int index = 0;
                foreach (string id in stdId)
                {
                    string proce = "";
                    if (_type[index] == "Advance")
                    {
                        proce = "SP_Adavnce_Payment_Post_To_Account";
                    }
                    else if (_type[index] == "Refund")
                    {
                        proce = "SP_Refund_Payment_Post_To_Account";
                    }

                    index++;
                    if (!string.IsNullOrEmpty(proce))
                    {
                        DatabaseProviderFactory factory = new DatabaseProviderFactory();
                        Database db = factory.CreateDefault();
                        DbCommand dbCommand = db.GetStoredProcCommand(proce);
                        db.AddInParameter(dbCommand, "payId", DbType.Int32, id);
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

        #endregion
    }
}
