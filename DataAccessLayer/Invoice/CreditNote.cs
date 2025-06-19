using BusinessEntities.Invoice;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Invoice
{
    public class CreditNote
    {
        public static DataTable GetCreditNotes(CreditNoteSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetCreditNotes");

                string sDate = string.Empty;
                string eDate = string.Empty;

                sDate = (search.date_from.Year > 2000) ? search.date_from.ToString("yyyy-MM-dd HH:mm:ss") : "";
                eDate = (search.date_to.Year > 2000) ? search.date_to.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") : "";


                if (!string.IsNullOrEmpty(search.branch_ids))
                {
                    db.AddInParameter(dbCommand, "branch_ids", DbType.String, search.branch_ids);
                }

                if (!string.IsNullOrEmpty(search.dept_ids))
                {
                    db.AddInParameter(dbCommand, "dept_ids", DbType.String, search.dept_ids);
                }

                if (!string.IsNullOrEmpty(search.doc_ids))
                {
                    db.AddInParameter(dbCommand, "doc_ids", DbType.String, search.doc_ids);
                }

                if (search.patient > 0)
                {
                    db.AddInParameter(dbCommand, "patient", DbType.Int32, search.patient);
                }

                if (!string.IsNullOrEmpty(sDate))
                {
                    db.AddInParameter(dbCommand, "date_from", DbType.String, sDate);
                }

                if (!string.IsNullOrEmpty(eDate))
                {
                    db.AddInParameter(dbCommand, "date_to", DbType.String, eDate);
                }

                if (!string.IsNullOrEmpty(search.inv_no))
                {
                    db.AddInParameter(dbCommand, "inv_no", DbType.String, search.inv_no);
                }

                if (!string.IsNullOrEmpty(search.cn_no))
                {
                    db.AddInParameter(dbCommand, "cn_no", DbType.String, search.cn_no);
                }

                if (!string.IsNullOrEmpty(search.statuses))
                {
                    string statuses = string.Join(",", search.statuses.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "statuses", DbType.String, statuses);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable SearchInvoicedPatients(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SearchInvoicedPatientForCreditNote");

                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string AutoCreateCreditNoteCode()
        {
            try
            {
                string cn_code = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AutoCreateCreditNoteCode");
                db.AddOutParameter(dbCommand, "cn_refno", DbType.String, 25);

                db.ExecuteScalar(dbCommand);

                cn_code = db.GetParameterValue(dbCommand, "cn_refno").ToString();
                return cn_code;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetCreditNoteByInvoice(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetCreditNoteByInvoice");

                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int AddCreditNoteItems(string cn_no, int ptId, int ptcId, int ptc_qty, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CreateNewCreditNoteItems");

                db.AddInParameter(dbCommand, "cn_no", DbType.String, cn_no);
                db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                db.AddInParameter(dbCommand, "ptcId", DbType.Int32, ptcId);
                db.AddInParameter(dbCommand, "ptc_qty", DbType.Int32, ptc_qty);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "ptcId_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int rValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "ptcId_output"));
                return rValue;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int CreateNewCreditNote(int invId, decimal net, decimal vat, int madeby, out string invc_no)
        {
            try
            {
                invc_no = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CreateNewCreditNote");

                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "net", DbType.Decimal, net);
                db.AddInParameter(dbCommand, "vat", DbType.Decimal, vat);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "invcId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "invc_no", DbType.String, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                int rValue = Convert.ToInt32(db.GetParameterValue(dbCommand, "invcId"));
                invc_no = db.GetParameterValue(dbCommand, "invc_no").ToString();
                return rValue;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int DeleteCreditNote(int invcId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DeleteCreditNotes");

                db.AddInParameter(dbCommand, "invcId", DbType.Int32, invcId);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);
                return val;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetCreditNoteLog(int invcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_CREDITNOTE_AUDIT_LOG");

                db.AddInParameter(dbCommand, "invcId", DbType.Int32, invcId);


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet PrintCreditNote(int invcId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PrintCreditNotes");

                db.AddInParameter(dbCommand, "invcId", DbType.String, invcId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int PostCreditNoteToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Invoice_Return_Post_To_Account");
                    db.AddInParameter(dbCommand, "invcId", DbType.Int32, id);
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
