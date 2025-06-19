using BusinessEntities.Invoice;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.EClaims;

namespace DataAccessLayer.EClaims
{
    public class EClaims
    {
        public static DataTable GetInvoicesSubmissions(SubmissionsSearch inv)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsInvoicesReceipts");


                string sDate = string.Empty;
                string eDate = string.Empty;

                sDate = (inv.inv_date_from.Year > 2000) ? inv.inv_date_from.ToString("yyyy-MM-dd HH:mm:ss") : "";
                eDate = (inv.inv_date_to.Year > 2000) ? inv.inv_date_to.AddDays(1).AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss") : "";

                if (!string.IsNullOrEmpty(inv.branch_ids))
                {
                    db.AddInParameter(dbCommand, "branch_ids", DbType.String, inv.branch_ids);
                }

                if (!string.IsNullOrEmpty(inv.ic_codes))
                {
                    db.AddInParameter(dbCommand, "ic_codes", DbType.String, inv.ic_codes);
                }

                if (!string.IsNullOrEmpty(inv.ip_codes))
                {
                    string ip_codes = string.Join(",", inv.ip_codes.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "ip_codes", DbType.String, ip_codes);
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

                if (!string.IsNullOrEmpty(inv.inv_estatus))
                {
                    db.AddInParameter(dbCommand, "inv_estatus", DbType.String, inv.inv_estatus);
                }
                if (!string.IsNullOrEmpty(inv.dept_ids))
                {
                    db.AddInParameter(dbCommand, "dept_ids", DbType.String, inv.dept_ids);
                }
                if (!string.IsNullOrEmpty(inv.emp_ids))
                {
                    db.AddInParameter(dbCommand, "emp_ids", DbType.String, inv.emp_ids);
                }
                if (!string.IsNullOrEmpty(inv.inv_coder_status))
                {
                    db.AddInParameter(dbCommand, "inv_coder_status", DbType.String, inv.inv_coder_status);
                }
                if (!string.IsNullOrEmpty(inv.inv_sub_status))
                {
                    db.AddInParameter(dbCommand, "inv_sub_status", DbType.String, inv.inv_sub_status);
                }
                if (!string.IsNullOrEmpty(inv.app_category))
                {
                    db.AddInParameter(dbCommand, "app_category", DbType.String, inv.app_category);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetInvoiceDetailsForSubmission(string inv_ids, string s_flag)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceDetailsForSubmission");
                if (inv_ids != "")
                {
                    db.AddInParameter(dbCommand, "inv_ids", DbType.String, inv_ids);
                    //db.AddInParameter(dbCommand, "s_flag", DbType.String, s_flag);
                }
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPatient_InsuranceTPAeClaim(int? icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_InsuranceTPAeClaim");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "icId", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static float GetInvoiceNet(int appId,int invId, int inv_insurance)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInvoiceNet");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv_insurance);

                // Use ExecuteScalar to retrieve a single value
                object result = db.ExecuteScalar(dbCommand);

                // Check if the result is not null and convert it to decimal
                if (result != null && float.TryParse(result.ToString(), out float ptNet))
                {
                    return ptNet;
                }

                // Return a default value or handle the case when the result is not a valid decimal
                return 0;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, logging or rethrowing as needed
                throw ex;
            }
        }

        public static float GetTopupInvoiceNet(int appId, int inv_insurance)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTopupInvoiceNet");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv_insurance);

                // Use ExecuteScalar to retrieve a single value
                object result = db.ExecuteScalar(dbCommand);

                // Check if the result is not null and convert it to decimal
                if (result != null && float.TryParse(result.ToString(), out float ptNet))
                {
                    return ptNet;
                }

                // Return a default value or handle the case when the result is not a valid decimal
                return 0;
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, logging or rethrowing as needed
                throw ex;
            }
        }

        public static string SP_GetIcCode(string s_ic_id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetIcCode");

                db.AddInParameter(dbCommand, "s_ic_id", DbType.String, s_ic_id);

                // Use ExecuteScalar to retrieve a single value
                object result = db.ExecuteScalar(dbCommand);

                // Check if the result is not null before converting to string
                if (result != null)
                {
                    return result.ToString();
                }
                else
                {
                    // Handle the case where the result is null, if needed
                    return "";
                }
            }
            catch (Exception ex)
            {
                // Handle the exception appropriately, logging or rethrowing as needed
                throw ex;
            }
        }

        public static DataTable Get_TreatmentsByAppointmentID(int appId,int invId, int inv_insurance)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PatientTreatmentsClaimSubmissions");

                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "invId", DbType.Int32, invId);
                db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv_insurance);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetPrescriptions(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPrescriptionsForClaims");
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
        public static DataTable GetLabResultsAppointmentID(int ptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetLabResultsAppointmentID");
                if (ptId > 0)
                {
                    db.AddInParameter(dbCommand, "ptId", DbType.Int32, ptId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int SP_UpdateInvoiceStatus(string inv_ids)
        {
            try
            {
                // int epr_Id = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_UpdateInvoiceStatus");

                db.AddInParameter(dbCommand, "inv_ids", DbType.String, inv_ids);

                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool Check_Already_Submitted(string s_ic_id, DateTime s_date_from, DateTime s_date_to)
        {
            try
            {
                // int epr_Id = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Check_eClaimsAlreadySubmitted");

                db.AddInParameter(dbCommand, "s_ic_id", DbType.String, s_ic_id);
                db.AddInParameter(dbCommand, "s_date_from", DbType.DateTime, s_date_from);
                db.AddInParameter(dbCommand, "s_date_to", DbType.DateTime, s_date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                if (dt.Rows.Count > 0)
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
                throw ex;
            }
        }

        public static int eClaim_Insert(string s_ic_id, DateTime s_date_from, DateTime s_date_to, string file_name, string xmlString, string eClaim_ErrorMessage)
        {
            try
            {
                // int epr_Id = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_eClaim_insert");
                db.AddInParameter(dbCommand, "ecl_ins", DbType.String, s_ic_id);
                db.AddInParameter(dbCommand, "ecl_date_from", DbType.DateTime, s_date_from);
                db.AddInParameter(dbCommand, "ecl_date_to", DbType.DateTime, s_date_to);
                db.AddInParameter(dbCommand, "ecl_filename", DbType.String, file_name);
                db.AddInParameter(dbCommand, "ecl_file", DbType.String, xmlString);
                db.AddInParameter(dbCommand, "ecl_ErrorMessage", DbType.String, eClaim_ErrorMessage);

                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateInvoiceeestatus(string inv_ids, string inv_estatus)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Invoices_e_status_update");
                db.AddInParameter(dbCommand, "inv_ids", DbType.String, inv_ids);
                db.AddInParameter(dbCommand, "inv_estatus", DbType.String, inv_estatus);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
