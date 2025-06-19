using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Accounts.Accounting;

namespace DataAccessLayer.Accounts.Accounting
{
    public class PDC
    {
     
        #region PDC Receivable
        public static DataTable GetPDCReceivables(PDCReceivablesFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Receipts_PDC");
                if (filter.recId > 0)
                    db.AddInParameter(dbCommand, "recId", DbType.Int32, filter.recId);

                if (filter.rec_branch > 0)
                    db.AddInParameter(dbCommand, "rec_branch", DbType.Int32, filter.rec_branch);

                if (filter.rec_patient > 0)
                    db.AddInParameter(dbCommand, "rec_patient", DbType.Int32, filter.rec_patient);

                if (!string.IsNullOrEmpty(filter.rec_code))
                    db.AddInParameter(dbCommand, "rec_code", DbType.String, filter.rec_code);

                if (!string.IsNullOrEmpty(filter.pat_code))
                    db.AddInParameter(dbCommand, "pat_code", DbType.String, filter.pat_code);

                if (!string.IsNullOrEmpty(filter.rec_status))
                    db.AddInParameter(dbCommand, "rec_status", DbType.String, filter.rec_status);

                if (!string.IsNullOrEmpty(filter.pat_mob))
                    db.AddInParameter(dbCommand, "pat_mob", DbType.String, filter.pat_mob);

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
        public static bool ChangePDCReceivablesStatus(string data, string status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Change_PDC_Receviable_Status");
                db.AddInParameter(dbCommand, "recIds", DbType.String, data);
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
        public static bool PostToAccountPDCReceivables(string data, string status, string acc_code, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PDC_Receviable_Post_To_Account");
                db.AddInParameter(dbCommand, "recIds", DbType.String, data);
                db.AddInParameter(dbCommand, "acc_code", DbType.String, acc_code);
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

        #endregion


        #region PDC Payables
        public static DataTable GetPDCPayables(PDCPayablesFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Payables_PDC");
                if (filter.payId > 0)
                    db.AddInParameter(dbCommand, "payId", DbType.Int32, filter.payId);

                if (filter.pay_branch > 0)
                    db.AddInParameter(dbCommand, "pay_branch", DbType.Int32, filter.pay_branch);

                if (filter.pay_supplier > 0)
                    db.AddInParameter(dbCommand, "pay_supplier", DbType.Int32, filter.pay_supplier);

                if (!string.IsNullOrEmpty(filter.pay_code))
                    db.AddInParameter(dbCommand, "pay_code", DbType.String, filter.pay_code);

                if (!string.IsNullOrEmpty(filter.pat_code))
                    db.AddInParameter(dbCommand, "pat_code", DbType.String, filter.pat_code);

                if (!string.IsNullOrEmpty(filter.pay_status))
                    db.AddInParameter(dbCommand, "pay_status", DbType.String, filter.pay_status);

                if (!string.IsNullOrEmpty(filter.pat_mob))
                    db.AddInParameter(dbCommand, "pat_mob", DbType.String, filter.pat_mob);

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
        public static bool ChangePDCPayablesStatus(string data, string status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Change_PDC_Payable_Status");
                db.AddInParameter(dbCommand, "payIds", DbType.String, data);
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
        public static bool PostToAccountPDCPayables(string data, string status, string acc_code, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PDC_Payables_Post_To_Account");
                db.AddInParameter(dbCommand, "payIds", DbType.String, data);
                db.AddInParameter(dbCommand, "acc_code", DbType.String, acc_code);
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
        #endregion


    }
}
