using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Invoice;
using System.Data.SqlClient;

namespace DataAccessLayer.Invoice
{
    public class Invoice
    {
        public static DataTable GetInvoices(InvoiceSearch inv)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoices");


                string sDate = string.Empty;
                string eDate = string.Empty;

                sDate = (inv.inv_date_from.Year > 2000) ? inv.inv_date_from.ToString("yyyy-MM-dd HH:mm:ss") : "";
                eDate = (inv.inv_date_to.Year > 2000) ? inv.inv_date_to.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") : "";

                if (!string.IsNullOrEmpty(inv.branch_ids))
                {
                    db.AddInParameter(dbCommand, "branch_ids", DbType.String, inv.branch_ids);
                }

                if (!string.IsNullOrEmpty(inv.dept_ids))
                {
                    db.AddInParameter(dbCommand, "dept_ids", DbType.String, inv.dept_ids);
                }

                if (!string.IsNullOrEmpty(inv.emp_ids))
                {
                    db.AddInParameter(dbCommand, "emp_ids", DbType.String, inv.emp_ids);
                }

                if (!string.IsNullOrEmpty(sDate))
                {
                    db.AddInParameter(dbCommand, "inv_date_from", DbType.String, sDate);
                }

                if (!string.IsNullOrEmpty(eDate))
                {
                    db.AddInParameter(dbCommand, "inv_date_to", DbType.String, eDate);
                }

                if (!string.IsNullOrEmpty(inv.inv_no))
                {
                    db.AddInParameter(dbCommand, "inv_no", DbType.String, inv.inv_no);
                }

                if (inv.patient > 0)
                {
                    db.AddInParameter(dbCommand, "patient", DbType.Int32, inv.patient);
                }

                if (!string.IsNullOrEmpty(inv.inv_types))
                {
                    string inv_types = string.Join(",", inv.inv_types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "inv_types", DbType.String, inv_types);
                }

                if (!string.IsNullOrEmpty(inv.inv_statuses))
                {
                    string inv_statuses = string.Join(",", inv.inv_statuses.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "inv_statuses", DbType.String, inv_statuses);
                }

                if (!string.IsNullOrEmpty(inv.ic_codes))
                {
                    db.AddInParameter(dbCommand, "ic_codes", DbType.String, inv.ic_codes);
                    //string ic_codes = string.Join(",", inv.ic_codes.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    //db.AddInParameter(dbCommand, "ic_codes", DbType.String, ic_codes);
                }

                if (!string.IsNullOrEmpty(inv.ip_codes))
                {
                    db.AddInParameter(dbCommand, "ip_codes", DbType.String, inv.ip_codes);
                    //string ip_codes = string.Join(",", inv.ip_codes.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    //db.AddInParameter(dbCommand, "ip_codes", DbType.String, ip_codes);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetServicesByInvoices(int appId,int invId, int inv_insurance)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceServicesByAppId");

                db.AddInParameter(dbCommand, "appId", DbType.String, appId);
                db.AddInParameter(dbCommand, "invId", DbType.String, invId);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.String, inv_insurance);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetServicesByInvoicesappId(int appId, int inv_insurance)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetMultiInvoiceServicesByAppId");

                db.AddInParameter(dbCommand, "appId", DbType.String, appId);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.String, inv_insurance);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable GetInsServicesByInvoices(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsInvoiceServicesByAppId");

                db.AddInParameter(dbCommand, "appId", DbType.String, appId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int GenerateInvoice(BusinessEntities.Invoice.InvoiceNew inv, out string inv_no, int? multi_bill = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand;
                if (multi_bill==0)
                {
                     dbCommand = db.GetStoredProcCommand("SP_INVOICES_insert");
                }
                else
                {
                    dbCommand = db.GetStoredProcCommand("SP_INVOICES_Multi_insert");
                    db.AddInParameter(dbCommand, "prev_invId", DbType.Int32, inv.invId);
                }
               
                db.AddInParameter(dbCommand, "inv_appId", DbType.Int32, inv.inv_appId);
                db.AddInParameter(dbCommand, "inv_no", DbType.String, inv.inv_no);
                db.AddInParameter(dbCommand, "inv_date", DbType.DateTime, inv.inv_date);
                db.AddInParameter(dbCommand, "inv_total", DbType.Decimal, inv.inv_total);
                db.AddInParameter(dbCommand, "inv_tdisc", DbType.Decimal, inv.inv_tdisc);
                db.AddInParameter(dbCommand, "inv_tdisc_type", DbType.String, inv.inv_tdisc_type);
                db.AddInParameter(dbCommand, "inv_disc", DbType.Decimal, inv.inv_disc);
                db.AddInParameter(dbCommand, "inv_tded", DbType.Decimal, inv.inv_tded);
                db.AddInParameter(dbCommand, "inv_copay", DbType.Decimal, inv.inv_copay);
                db.AddInParameter(dbCommand, "inv_net", DbType.Decimal, inv.inv_net);
                db.AddInParameter(dbCommand, "inv_notes", DbType.String, string.IsNullOrEmpty(inv.inv_notes) ? string.Empty : inv.inv_notes);
                db.AddInParameter(dbCommand, "inv_madeby", DbType.Int32, inv.inv_madeby);
                db.AddInParameter(dbCommand, "inv_ic_name", DbType.String, inv.inv_ic_name);
                db.AddInParameter(dbCommand, "inv_type", DbType.String, inv.inv_type);
                db.AddInParameter(dbCommand, "pat_name", DbType.String, inv.pat_name);
                db.AddInParameter(dbCommand, "pat_code", DbType.String, inv.pat_code);
                db.AddInParameter(dbCommand, "inv_dcopay", DbType.Decimal, inv.inv_dcopay);
                db.AddInParameter(dbCommand, "inv_share", DbType.Decimal, inv.inv_share);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv.inv_insurance);
                db.AddInParameter(dbCommand, "inv_dded", DbType.Decimal, inv.inv_dded);
                db.AddInParameter(dbCommand, "inv_lded", DbType.Decimal, inv.inv_lded);
                db.AddInParameter(dbCommand, "inv_rded", DbType.Decimal, inv.inv_rded);
                db.AddInParameter(dbCommand, "inv_mded", DbType.Decimal, inv.inv_mded);
                db.AddInParameter(dbCommand, "inv_sded", DbType.Decimal, inv.inv_sded);
                db.AddInParameter(dbCommand, "inv_pded", DbType.Decimal, inv.inv_pded);
                db.AddOutParameter(dbCommand, "invId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "inv_no_output", DbType.String, 100);

                db.ExecuteNonQuery(dbCommand);

                inv_no = db.GetParameterValue(dbCommand, "inv_no_output").ToString();

                int val =  Convert.ToInt32(db.GetParameterValue(dbCommand, "invId").ToString());

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet PrintCashInvoice(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INVOICES_Cash_Print");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataSet PrintInsuranceInvoice(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Invoices_Insurance_Print");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);

                return db.ExecuteDataSet(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateCashInvoice(BusinessEntities.Invoice.InvoiceNew inv)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_INVOICES_UPDATE");
                db.AddInParameter(dbCommand, "invId", DbType.Int32, inv.invId);
                db.AddInParameter(dbCommand, "inv_date", DbType.DateTime, inv.inv_date);
                db.AddInParameter(dbCommand, "inv_total", DbType.Decimal, inv.inv_total);
                db.AddInParameter(dbCommand, "inv_tdisc", DbType.Decimal, inv.inv_tdisc);
                db.AddInParameter(dbCommand, "inv_tdisc_type", DbType.String, inv.inv_tdisc_type);
                db.AddInParameter(dbCommand, "inv_disc", DbType.Decimal, inv.inv_disc);
                db.AddInParameter(dbCommand, "inv_tded", DbType.Decimal, inv.inv_tded);
                db.AddInParameter(dbCommand, "inv_copay", DbType.Decimal, inv.inv_copay);
                db.AddInParameter(dbCommand, "inv_net", DbType.Decimal, inv.inv_net);
                db.AddInParameter(dbCommand, "inv_notes", DbType.String, inv.inv_notes);
                db.AddInParameter(dbCommand, "inv_madeby", DbType.Int32, inv.inv_madeby);
                db.AddInParameter(dbCommand, "inv_type", DbType.String, inv.inv_type);
                db.AddInParameter(dbCommand, "inv_dcopay", DbType.Decimal, inv.inv_dcopay);
                db.AddInParameter(dbCommand, "inv_share", DbType.Decimal, inv.inv_share);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv.inv_insurance);
                db.AddInParameter(dbCommand, "inv_refund", DbType.Decimal, inv.inv_refund);
                db.AddInParameter(dbCommand, "inv_dded", DbType.Decimal, inv.inv_dded);
                db.AddInParameter(dbCommand, "inv_lded", DbType.Decimal, inv.inv_lded);
                db.AddInParameter(dbCommand, "inv_rded", DbType.Decimal, inv.inv_rded);
                db.AddInParameter(dbCommand, "inv_mded", DbType.Decimal, inv.inv_mded);

                return db.ExecuteNonQuery(dbCommand); ;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int DeleteInvoice(int invId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_INVOICES_delete");
                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "inv_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "errorStatus", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);
                return Convert.ToInt32(db.GetParameterValue(dbCommand, "errorStatus").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInvoiceLog(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_INVOICE_AUDIT_LOG");

                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateBulkInvoiceStatus(DataTable dt, string status, int madeby)
        {
            int inserts = 0;
            try
            {


                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BulkUpdate_InvoiceStatus"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@madeby", madeby);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        inserts = 1;
                    }
                }

                return inserts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int PostToAccountInvoice(List<int> invIds, int madeby)
        {
            try
            {
                int count = 0;
                foreach (int invId in invIds)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();

                    DbCommand dbCommand = db.GetStoredProcCommand("SP_INVOICES_POST_TO_ACCOUNTS");
                    db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);
                    db.AddInParameter(dbCommand, "inv_madeby", DbType.Int32, madeby);

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

        public static DataTable SearchInvoicedPatients(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SearchInvoicedPatients");

                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetInvoiceByPatId(int patId, int? empId=0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceInfoByPatient");

                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAppointmentPackages(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("sp_GetAppointmentPackages");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetIns_InvoiceInfoByInvId(int invId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsInvoiceInfoByInvId");

                db.AddInParameter(dbCommand, "invId", DbType.String, invId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int PostSalesInvoiceToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Invoice_Post_To_Account");
                    db.AddInParameter(dbCommand, "invId", DbType.Int32, id);
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


        public static int GenerateInvoiceforPackage(BusinessEntities.Invoice.InvoiceNew inv, string ptIds, out string inv_no)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PackageServiceInvoice_insert");
                db.AddInParameter(dbCommand, "inv_appId", DbType.Int32, inv.inv_appId);
                db.AddInParameter(dbCommand, "ptIds", DbType.String, ptIds);
                db.AddInParameter(dbCommand, "inv_no", DbType.String, inv.inv_no);
                db.AddInParameter(dbCommand, "inv_total", DbType.Decimal, inv.inv_total);
                db.AddInParameter(dbCommand, "inv_tdisc", DbType.Decimal, inv.inv_tdisc);
                db.AddInParameter(dbCommand, "inv_tdisc_type", DbType.String, inv.inv_tdisc_type);
                db.AddInParameter(dbCommand, "inv_disc", DbType.Decimal, inv.inv_disc);
                db.AddInParameter(dbCommand, "inv_tded", DbType.Decimal, inv.inv_tded);
                db.AddInParameter(dbCommand, "inv_copay", DbType.Decimal, inv.inv_copay);
                db.AddInParameter(dbCommand, "inv_net", DbType.Decimal, inv.inv_net);
                db.AddInParameter(dbCommand, "inv_notes", DbType.String, inv.inv_notes);
                db.AddInParameter(dbCommand, "inv_madeby", DbType.Int32, inv.inv_madeby);
                db.AddInParameter(dbCommand, "inv_ic_name", DbType.String, inv.inv_ic_name);
                db.AddInParameter(dbCommand, "inv_type", DbType.String, inv.inv_type);
                db.AddInParameter(dbCommand, "inv_dcopay", DbType.Decimal, inv.inv_dcopay);
                db.AddInParameter(dbCommand, "inv_share", DbType.Decimal, inv.inv_share);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv.inv_insurance);
                db.AddInParameter(dbCommand, "poId", DbType.Int32, inv.poId);
                db.AddInParameter(dbCommand, "inv_dded", DbType.Decimal, inv.inv_dded);
                db.AddInParameter(dbCommand, "inv_lded", DbType.Decimal, inv.inv_lded);
                db.AddInParameter(dbCommand, "inv_rded", DbType.Decimal, inv.inv_rded);
                db.AddInParameter(dbCommand, "inv_mded", DbType.Decimal, inv.inv_mded);
                db.AddOutParameter(dbCommand, "invId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "inv_no_output", DbType.String, 100);

                db.ExecuteNonQuery(dbCommand);

                inv_no = db.GetParameterValue(dbCommand, "inv_no_output").ToString();
                return Convert.ToInt32(db.GetParameterValue(dbCommand, "invId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}