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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class PurchaseInvoice
    {
        public static DataTable GetPurchaseInvoices(PurchaseInvoice_Filter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_GetDetails");
                if (filter.pinvId > 0)
                    db.AddInParameter(dbCommand, "pinvId", DbType.Int32, filter.pinvId);
                if (filter.pinv_branch > 0)
                    db.AddInParameter(dbCommand, "pinv_branch", DbType.Int32, filter.pinv_branch);
                if (!string.IsNullOrEmpty(filter.pinv_supplier))
                    db.AddInParameter(dbCommand, "pinv_supplier", DbType.String, filter.pinv_supplier);

                if (!string.IsNullOrEmpty(filter.pinv_icode))
                    db.AddInParameter(dbCommand, "pinv_icode", DbType.String, filter.pinv_icode);
                if (!string.IsNullOrEmpty(filter.pinv_fdate) && (!string.IsNullOrEmpty(filter.pinv_tdate)))
                {
                    db.AddInParameter(dbCommand, "pinv_fdate", DbType.String, filter.pinv_fdate);
                    db.AddInParameter(dbCommand, "pinv_tdate", DbType.String, filter.pinv_tdate);
                }
                if (!string.IsNullOrEmpty(filter.pinv_status))
                {
                    string pr__status = string.Join(",", filter.pinv_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pinv_status", DbType.String, pr__status);
                }
                if (!string.IsNullOrEmpty(filter.pr_code))
                {                    
                    db.AddInParameter(dbCommand, "pr_code", DbType.String, filter.pr_code);
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
        public static DataTable GetExpItems(int days)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetItemsExpiringDetails");
                
                db.AddInParameter(dbCommand, "days", DbType.Int32, days);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPurchaseInvoiceItems(PurchaseInvoice_Filter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICE_ITEMS_GetDetails");
                if (filter.pinvId > 0)
                    db.AddInParameter(dbCommand, "pit_pinvoice", DbType.Int32, filter.pinvId);
                if (filter.pitId > 0)
                    db.AddInParameter(dbCommand, "pitId", DbType.Int32, filter.pitId);
                if (filter.pit_preceived > 0)
                    db.AddInParameter(dbCommand, "pit_preceived", DbType.Int32, filter.pit_preceived);
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
        public static bool PurchaseInvoice_StatusChange(string data, string status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_StatusChange");
                db.AddInParameter(dbCommand, "pinvId", DbType.String, data);
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
        public static DataSet GetPurchaseInvoice_Print(int pinvId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_GetPrintDetail");
                db.AddInParameter(dbCommand, "pinvId", DbType.Int32, pinvId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.ExecuteNonQuery(dbCommand);
                DataSet result = db.ExecuteDataSet(dbCommand);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetSupplierByBranches_grn(int? supId, int? sup_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetSupplier_PurchaseInvoice");
                if (supId > 0)
                    db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, sup_branch);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetGRN_Dropdown_Detail(int sup_branch, int supId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_Dropdown");
                if (supId > 0)
                    db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, sup_branch);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetGRN_Details(int branchId, int supId, string grnIds, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_ForPurchaseInvoice");
                db.AddInParameter(dbCommand, "prId", DbType.String, grnIds);
                db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, branchId);
                db.AddInParameter(dbCommand, "pr_supplier", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertPurchaseInvoice(purchaseInvoiceWithItems data, DataTable dt, out string pinvCode, out int pinvId)
        {
            pinvCode = "";
            pinvId = 0;
            int inserts = 0;
            int pr_slno_out = 0;
            bool return_value = false;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                if (data.purchaseInvoice != null && dt != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "pinvId", DbType.Int32, data.purchaseInvoice.pinvId);
                    db.AddInParameter(dbCommand, "pinv_supplier", DbType.Int32, data.purchaseInvoice.pinv_supplier);
                    db.AddInParameter(dbCommand, "pinv_icode", DbType.String, data.purchaseInvoice.pinv_icode);
                    db.AddInParameter(dbCommand, "pinv_invno", DbType.String, data.purchaseInvoice.pinv_invno);
                    db.AddInParameter(dbCommand, "pinv_idate", DbType.String, data.purchaseInvoice.pinv_idate);
                    db.AddInParameter(dbCommand, "pinv_total", DbType.Decimal, data.purchaseInvoice.pinv_total);
                    db.AddInParameter(dbCommand, "pinv_disc", DbType.Decimal, data.purchaseInvoice.pinv_disc);
                    db.AddInParameter(dbCommand, "pinv_disc_type", DbType.String, data.purchaseInvoice.pinv_disc_type);
                    db.AddInParameter(dbCommand, "pinv_net", DbType.Decimal, data.purchaseInvoice.pinv_net);
                    db.AddInParameter(dbCommand, "pinv_notes", DbType.String, data.purchaseInvoice.pinv_notes);
                    db.AddInParameter(dbCommand, "pinv_imadeby", DbType.Int32, data.purchaseInvoice.pinv_imadeby);
                    db.AddInParameter(dbCommand, "pinv_disc_value", DbType.Decimal, data.purchaseInvoice.pinv_disc_value);
                    db.AddInParameter(dbCommand, "pinv_vat", DbType.Decimal, data.purchaseInvoice.pinv_vat);
                    db.AddInParameter(dbCommand, "pinv_branch", DbType.Int32, data.purchaseInvoice.pinv_branch);
                    db.AddInParameter(dbCommand, "pinv_grnIds", DbType.String, data.purchaseInvoice.pinv_grnIds);                    
                    db.AddInParameter(dbCommand, "pinv_pocode", DbType.String, data.purchaseInvoice.pinv_pocode);                    
                    db.AddOutParameter(dbCommand, "pinvId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "pinvCode_out", DbType.String, 100);
                    db.ExecuteNonQuery(dbCommand);

                    pinvId = int.Parse(db.GetParameterValue(dbCommand, "pinvId_out").ToString());
                    pinvCode = db.GetParameterValue(dbCommand, "pinvCode_out").ToString();
                }
                if (pinvId > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_PURCHASE_INVOICE_ITEMS_BulkInsert"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@pinvId", pinvId);
                                cmd.Parameters.AddWithValue("@pinvCode", pinvCode);                                
                                cmd.Parameters.Add("@id_out", SqlDbType.VarChar, 1000);
                                cmd.Parameters["@id_out"].Direction = ParameterDirection.Output;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                inserts = int.Parse((cmd.Parameters["@id_out"].Value).ToString());
                            }
                        }
                    }
                }

                if (inserts > 0)
                {
                    return_value = true;
                }
                else
                {
                    return_value = false;
                }
                return return_value;
            }
            catch (Exception)
            {
                if (pinvId > 0)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICE_REMOVE");
                    db.AddInParameter(dbCommand, "pinvId", DbType.Int32, pinvId);
                    db.ExecuteNonQuery(dbCommand);
                }
                throw;
            }
            ;
        }
        public static DataTable GetGRN_Dropdown_Edit(int sup_branch, int supId, int pinvId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_Dropdown_edit");
                if (supId > 0)
                    db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, sup_branch);
                db.AddInParameter(dbCommand, "pinvId", DbType.Int32, pinvId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataSet GetPurchaseInvoice_Edit(int pinvId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_GetEditDetail");
                db.AddInParameter(dbCommand, "pinvId", DbType.Int32, pinvId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.ExecuteNonQuery(dbCommand);
                DataSet result = db.ExecuteDataSet(dbCommand);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool UpdatePurchaseInvoice(purchaseInvoiceWithItems data, DataTable dt, out string pinvCode, out int pinvId)
        {
            pinvCode = "";
            pinvId = 0;
            int inserts = 0;
            int pr_slno_out = 0;
            bool return_value = false;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                if (data.purchaseInvoice != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICES_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "pinvId", DbType.Int32, data.purchaseInvoice.pinvId);
                    db.AddInParameter(dbCommand, "pinv_supplier", DbType.Int32, data.purchaseInvoice.pinv_supplier);
                    db.AddInParameter(dbCommand, "pinv_icode", DbType.String, data.purchaseInvoice.pinv_icode);
                    db.AddInParameter(dbCommand, "pinv_invno", DbType.String, data.purchaseInvoice.pinv_invno);
                    db.AddInParameter(dbCommand, "pinv_idate", DbType.String, data.purchaseInvoice.pinv_idate);
                    db.AddInParameter(dbCommand, "pinv_total", DbType.Decimal, data.purchaseInvoice.pinv_total);
                    db.AddInParameter(dbCommand, "pinv_disc", DbType.Decimal, data.purchaseInvoice.pinv_disc);
                    db.AddInParameter(dbCommand, "pinv_disc_type", DbType.String, data.purchaseInvoice.pinv_disc_type);
                    db.AddInParameter(dbCommand, "pinv_net", DbType.Decimal, data.purchaseInvoice.pinv_net);
                    db.AddInParameter(dbCommand, "pinv_notes", DbType.String, data.purchaseInvoice.pinv_notes);
                    db.AddInParameter(dbCommand, "pinv_imadeby", DbType.Int32, data.purchaseInvoice.pinv_imadeby);
                    db.AddInParameter(dbCommand, "pinv_disc_value", DbType.Decimal, data.purchaseInvoice.pinv_disc_value);
                    db.AddInParameter(dbCommand, "pinv_vat", DbType.Decimal, data.purchaseInvoice.pinv_vat);
                    db.AddInParameter(dbCommand, "pinv_branch", DbType.Int32, data.purchaseInvoice.pinv_branch);
                    db.AddInParameter(dbCommand, "pinv_grnIds", DbType.String, data.purchaseInvoice.pinv_grnIds);
                    db.AddInParameter(dbCommand, "pinv_pocode", DbType.String, data.purchaseInvoice.pinv_pocode);
                    db.AddOutParameter(dbCommand, "pinvId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "pinvCode_out", DbType.String, 100);
                    db.ExecuteNonQuery(dbCommand);

                    pinvId = int.Parse(db.GetParameterValue(dbCommand, "pinvId_out").ToString());
                    pinvCode = db.GetParameterValue(dbCommand, "pinvCode_out").ToString();
                }
                if (pinvId > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_PURCHASE_INVOICE_ITEMS_BulkInsert"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@pinvId", pinvId);
                                cmd.Parameters.AddWithValue("@pinvCode", pinvCode);
                                cmd.Parameters.Add("@id_out", SqlDbType.VarChar, 1000);
                                cmd.Parameters["@id_out"].Direction = ParameterDirection.Output;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                inserts = int.Parse((cmd.Parameters["@id_out"].Value).ToString());
                            }
                        }
                    }
                }

                if (inserts > 0)
                {
                    return_value = true;
                }
                else
                {
                    return_value = false;
                }
                return return_value;
            }
            catch (Exception)
            {
                if (pinvId > 0)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_INVOICE_REMOVE");
                    db.AddInParameter(dbCommand, "pinvId", DbType.Int32, pinvId);
                    db.ExecuteNonQuery(dbCommand);
                }
                throw;
            }
           ;
        }

        public static int PostPurchaseInvoiceToAccount(string data, int empId)
        {   
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Invoice_Post_To_Account");
                    db.AddInParameter(dbCommand, "pinvId", DbType.Int32, id);
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
