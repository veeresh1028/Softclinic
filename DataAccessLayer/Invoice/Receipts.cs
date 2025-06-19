using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Invoice;

namespace DataAccessLayer.Invoice
{
    public class Receipts
    {
        public static DataTable BankNamesForBankTransfers()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_BankNamesForBankTransfers");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable ReceiptAdvanceByPatId(int patId, int? rec_doctor = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ReceiptAdvanceByPatId");
                db.AddInParameter(dbCommand, "rec_patient", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "rec_doctor", DbType.Int32, rec_doctor);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable ReceiptVouchers()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ReceiptVouchers");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable ReceiptLoyalityEarnsByPatId(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ReceiptLoyalityPointsByPatId");
                db.AddInParameter(dbCommand, "rec_patient", DbType.Int32, patId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int CreateReceipts(BusinessEntities.Invoice.Receipts rec)
        {
            try
            {
                int recId = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RECEIPTS_insert");

                db.AddInParameter(dbCommand, "rec_code", DbType.String, rec.rec_code);
                db.AddInParameter(dbCommand, "rec_date", DbType.DateTime, rec.rec_date);
                db.AddInParameter(dbCommand, "rec_patient", DbType.Int32, rec.rec_patient);
                db.AddInParameter(dbCommand, "rec_doctor", DbType.Int32, rec.rec_doctor);
                db.AddInParameter(dbCommand, "rec_poId", DbType.Int32, rec.rec_poId);
                db.AddInParameter(dbCommand, "rec_invoice", DbType.Int32, rec.rec_invoice);
                db.AddInParameter(dbCommand, "rec_cash", DbType.Decimal, rec.rec_cash);
                db.AddInParameter(dbCommand, "rec_cc", DbType.Decimal, rec.rec_cc);
                db.AddInParameter(dbCommand, "rec_cc_per", DbType.Decimal, rec.rec_cc_per);
                db.AddInParameter(dbCommand, "rec_chq", DbType.Decimal, rec.rec_chq);
                db.AddInParameter(dbCommand, "rec_chq_no", DbType.String, rec.rec_chq_no);
                db.AddInParameter(dbCommand, "rec_chq_date", DbType.DateTime, rec.rec_chq_date);
                db.AddInParameter(dbCommand, "rec_chq_bank", DbType.String, rec.rec_chq_bank);
                db.AddInParameter(dbCommand, "rec_bt", DbType.Decimal, rec.rec_bt);
                db.AddInParameter(dbCommand, "rec_bt_bank", DbType.String, rec.rec_bt_bank);
                db.AddInParameter(dbCommand, "rec_advance", DbType.Int32, rec.rec_advance);
                db.AddInParameter(dbCommand, "rec_allocated", DbType.Decimal, rec.rec_allocated);
                db.AddInParameter(dbCommand, "rec_notes", DbType.String, rec.rec_notes);
                db.AddInParameter(dbCommand, "rec_madeby", DbType.Int32, rec.rec_madeby);
                db.AddInParameter(dbCommand, "rec_debit", DbType.Decimal, rec.rec_debit);
                db.AddInParameter(dbCommand, "rec_branch", DbType.Int32, rec.rec_branch);
                db.AddInParameter(dbCommand, "rec_voucher", DbType.Int32, rec.rec_voucher);
                db.AddInParameter(dbCommand, "rec_vamount", DbType.Decimal, rec.rec_vamount);
                db.AddInParameter(dbCommand, "rec_loyalty", DbType.Int32, rec.rec_loyalty);
                db.AddInParameter(dbCommand, "rec_lamount", DbType.Decimal, rec.rec_lamount);
                db.AddInParameter(dbCommand, "rec_loy_value", DbType.Decimal, rec.rec_loy_value);
                db.AddInParameter(dbCommand, "rec_tabby", DbType.Decimal, rec.rec_tabby);
                db.AddInParameter(dbCommand, "rec_self", DbType.Decimal, rec.rec_self);
                db.AddInParameter(dbCommand, "rec_spoti", DbType.Decimal, rec.rec_spoti);
                db.AddInParameter(dbCommand, "rec_group", DbType.Decimal, rec.rec_group);
                db.AddInParameter(dbCommand, "rec_cob", DbType.Decimal, rec.rec_cob);
                db.AddInParameter(dbCommand, "rec_stripe", DbType.Decimal, rec.rec_stripe);
                db.AddInParameter(dbCommand, "rec_type", DbType.String, rec.rec_type);
                db.AddInParameter(dbCommand, "rec_prefix", DbType.String, rec.rec_prefix);
                db.AddInParameter(dbCommand, "rec_tamara", DbType.Decimal, rec.rec_tamara);
                db.AddInParameter(dbCommand, "rec_extra_pay1", DbType.Decimal, rec.rec_extra_pay1);
                db.AddInParameter(dbCommand, "rec_extra_pay2", DbType.Decimal, rec.rec_extra_pay2);
                db.AddInParameter(dbCommand, "rec_extra_pay3", DbType.Decimal, rec.rec_extra_pay3);
                db.AddOutParameter(dbCommand, "recId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                recId = Convert.ToInt32(db.GetParameterValue(dbCommand, "recId").ToString());

                return recId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetInvoiceReceipts(ReceiptSearch rec)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetReceiptsForInvoice");


                string sDate = string.Empty;
                string eDate = string.Empty;

                sDate = (rec.rec_date_from.Year > 2000) ? rec.rec_date_from.ToString("yyyy-MM-dd HH:mm:ss") : "";
                eDate = (rec.rec_date_to.Year > 2000) ? rec.rec_date_to.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") : "";

                if (!string.IsNullOrEmpty(rec.branch_ids))
                {
                    db.AddInParameter(dbCommand, "branch_ids", DbType.String, rec.branch_ids);
                }

                if (!string.IsNullOrEmpty(rec.dept_ids))
                {
                    db.AddInParameter(dbCommand, "dept_ids", DbType.String, rec.dept_ids);
                }

                if (!string.IsNullOrEmpty(rec.emp_ids))
                {
                    db.AddInParameter(dbCommand, "emp_ids", DbType.String, rec.emp_ids);
                }

                if (!string.IsNullOrEmpty(sDate))
                {
                    db.AddInParameter(dbCommand, "rec_date_from", DbType.String, sDate);
                }

                if (!string.IsNullOrEmpty(eDate))
                {
                    db.AddInParameter(dbCommand, "rec_date_to", DbType.String, eDate);
                }

                if (!string.IsNullOrEmpty(rec.inv_no))
                {
                    db.AddInParameter(dbCommand, "inv_no", DbType.String, rec.inv_no);
                }

                if (!string.IsNullOrEmpty(rec.rec_code))
                {
                    db.AddInParameter(dbCommand, "rec_code", DbType.String, rec.rec_code);
                }

                if (rec.patient > 0)
                {
                    db.AddInParameter(dbCommand, "patient", DbType.Int32, rec.patient);
                }

                if (!string.IsNullOrEmpty(rec.rec_statuses))
                {
                    string inv_statuses = string.Join(",", rec.rec_statuses.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "rec_statuses", DbType.String, inv_statuses);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string AutoCreateReceiptCode(int branch)
        {
            try
            {
                string rec_code = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AutoCreateReceiptCode");
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddOutParameter(dbCommand, "rec_refno", DbType.String, 25);

                db.ExecuteScalar(dbCommand);

                rec_code = db.GetParameterValue(dbCommand, "rec_refno").ToString();
                return rec_code;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet AutoCreateReceiptCodes(int branch)
        {
            try
            {
                string rec_code = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AutoCreateReceiptCodes");
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetAllReceiptsForInvoice(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetAllReceiptsForInvoice");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetAllInsReceiptsForInvoice(int invId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetAllInsReceiptsForInvoice");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);
                db.AddInParameter(dbCommand, "patId", DbType.String, patId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int UpdateReceipts(BusinessEntities.Invoice.Receipts rec)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RECEIPTS_update");
                db.AddInParameter(dbCommand, "recId", DbType.Int32, rec.recId);
                db.AddInParameter(dbCommand, "rec_doctor", DbType.Int32, rec.rec_doctor);
                db.AddInParameter(dbCommand, "rec_date", DbType.DateTime, rec.rec_date);
                db.AddInParameter(dbCommand, "rec_invoice", DbType.Int32, rec.rec_invoice);
                db.AddInParameter(dbCommand, "rec_cash", DbType.Decimal, rec.rec_cash);
                db.AddInParameter(dbCommand, "rec_cc", DbType.Decimal, rec.rec_cc);
                db.AddInParameter(dbCommand, "rec_cc_per", DbType.Decimal, rec.rec_cc_per);
                db.AddInParameter(dbCommand, "rec_chq", DbType.Decimal, rec.rec_chq);
                db.AddInParameter(dbCommand, "rec_chq_no", DbType.String, rec.rec_chq_no);
                db.AddInParameter(dbCommand, "rec_chq_date", DbType.DateTime, rec.rec_chq_date);
                db.AddInParameter(dbCommand, "rec_chq_bank", DbType.String, rec.rec_chq_bank);
                db.AddInParameter(dbCommand, "rec_bt", DbType.Decimal, rec.rec_bt);
                db.AddInParameter(dbCommand, "rec_bt_bank", DbType.String, rec.rec_bt_bank);
                db.AddInParameter(dbCommand, "rec_advance", DbType.Int32, rec.rec_advance);
                db.AddInParameter(dbCommand, "rec_allocated", DbType.Decimal, rec.rec_allocated);
                db.AddInParameter(dbCommand, "rec_notes", DbType.String, rec.rec_notes);
                db.AddInParameter(dbCommand, "rec_debit", DbType.Decimal, rec.rec_debit);
                db.AddInParameter(dbCommand, "rec_branch", DbType.Int32, rec.rec_branch);
                db.AddInParameter(dbCommand, "rec_voucher", DbType.Int32, rec.rec_voucher);
                db.AddInParameter(dbCommand, "rec_vamount", DbType.Decimal, rec.rec_vamount);
                db.AddInParameter(dbCommand, "rec_loyalty", DbType.Int32, rec.rec_loyalty);
                db.AddInParameter(dbCommand, "rec_lamount", DbType.Decimal, rec.rec_lamount);
                db.AddInParameter(dbCommand, "rec_loy_value", DbType.Decimal, rec.rec_loy_value);
                db.AddInParameter(dbCommand, "rec_tabby", DbType.Decimal, rec.rec_tabby);
                db.AddInParameter(dbCommand, "rec_self", DbType.Decimal, rec.rec_self);
                db.AddInParameter(dbCommand, "rec_spoti", DbType.Decimal, rec.rec_spoti);
                db.AddInParameter(dbCommand, "rec_group", DbType.Decimal, rec.rec_group);
                db.AddInParameter(dbCommand, "rec_cob", DbType.Decimal, rec.rec_cob);
                db.AddInParameter(dbCommand, "rec_stripe", DbType.Decimal, rec.rec_stripe);
                db.AddInParameter(dbCommand, "rec_tamara", DbType.Decimal, rec.rec_tamara);
                db.AddInParameter(dbCommand, "rec_madeby", DbType.Int32, rec.rec_madeby);
                db.AddInParameter(dbCommand, "rec_type", DbType.String, rec.rec_type);
                db.AddOutParameter(dbCommand, "rec_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int rec_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "rec_output").ToString());
                return rec_output;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetReceiptById(int recId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetReceiptById");

                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetInsReceiptById(int recId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsReceiptById");

                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteReceiptById(int recId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RECEIPTS_delete");
                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static int DeleteServiceReceiptsById(int srId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ServiceReceipts_delete");
                db.AddInParameter(dbCommand, "srId", DbType.Int32, srId);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable PrintReceipt(int recId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Receipt_Print");
                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetServiceWiseReceipts(int ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetServiceWiseReceipts");
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetReceiptLog(int recId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_RECEIPT_AUDIT_LOG");

                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int PostToAccountReceipt(List<int> recIds, int madeby)
        {
            try
            {
                int count = 0;
                foreach (int recId in recIds)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_RECEIPTS_POST_TO_ACCOUNTS");
                    db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);
                    db.AddInParameter(dbCommand, "rec_madeby", DbType.Int32, madeby);

                    int id = db.ExecuteNonQuery(dbCommand);

                    if (id > 0) { count++; }
                }

                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PostReceiptToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Receipt_Post_To_Account");
                    db.AddInParameter(dbCommand, "recId", DbType.Int32, id);
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

        public static DataTable GetTreatmentList(int? recId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatmentList");
                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int CreateServiceWiseReceipts(BusinessEntities.Invoice.ServiceWiseReceiptsInfo treatment, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Service_Wise_Receipts_Insert_update");
                db.AddInParameter(dbCommand, "sr_recId", DbType.Int32, treatment.sr_recId);
                db.AddInParameter(dbCommand, "sr_ptId", DbType.Int32, treatment.sr_ptId);
                db.AddInParameter(dbCommand, "sr_total", DbType.Decimal, treatment.sr_total);
                db.AddInParameter(dbCommand, "sr_bal", DbType.Decimal, treatment.sr_bal);
                db.AddInParameter(dbCommand, "sr_paid", DbType.Decimal, treatment.sr_paid);
                db.AddInParameter(dbCommand, "sr_notes", DbType.String, treatment.sr_notes);
                db.AddInParameter(dbCommand, "sr_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "srId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "srId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int GenerateServiceWiseReceipts(BusinessEntities.Invoice.QC_InvoiceReceipts inv, int madeby)
        {
            int count = 0;
            int invId = 0;
            int recId = 0;

            List<ServiceWiseReceiptsInfo> list = inv.Service_items;
            List<int> valList = new List<int>();


            foreach (ServiceWiseReceiptsInfo i in list)
            {
                BusinessEntities.Invoice.ServiceWiseReceiptsInfo treatment = new BusinessEntities.Invoice.ServiceWiseReceiptsInfo();
                treatment.sr_recId = i.sr_recId;
                treatment.sr_ptId = i.sr_ptId;
                treatment.sr_tr_name =i.sr_tr_name;
                treatment.sr_tr_code = i.sr_tr_code;
                treatment.sr_total = i.sr_total;
                treatment.sr_bal = i.sr_bal;
                treatment.sr_paid = i.sr_paid;
                treatment.sr_notes = inv.sr_notes;
                int val = DataAccessLayer.Invoice.Receipts.CreateServiceWiseReceipts(treatment, madeby);

                if (val > 0)
                {
                    valList.Add(val);
                    count++;
                }


            }


            return invId;
        }

        public static DataTable GetServiceReceipts(int recId, int srId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetServiceReceipts");
                db.AddInParameter(dbCommand, "recId", DbType.Int32, recId);
                db.AddInParameter(dbCommand, "srId", DbType.Int32, srId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertUpdateServiceWiseReceipts(BusinessEntities.Invoice.ServiceWiseReceiptsInfo sr)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Service_Wise_Receipts_update");
                db.AddInParameter(dbCommand, "srId", DbType.Int32, sr.srId);
                db.AddInParameter(dbCommand, "sr_paid", DbType.Decimal, sr.sr_paid);
                db.AddOutParameter(dbCommand, "outsrId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable SearchTreatmentsforEdit(int ptId, string appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SearchTreatmentsforEdit");

                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "appId", DbType.String, int.Parse(appId));

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}