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
using System.Security.Cryptography;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class PurchaseReturn
    {
        public static DataTable GetPurchaseReturn(PurchaseReturnFilters filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_RETURN_GetDetail");
                if (filter.porId > 0)
                    db.AddInParameter(dbCommand, "porId", DbType.Int32, filter.porId);

                if (!string.IsNullOrEmpty(filter.por_branch))
                    db.AddInParameter(dbCommand, "por_branch", DbType.String, filter.por_branch);

                if (!string.IsNullOrEmpty(filter.por_ocode))
                    db.AddInParameter(dbCommand, "por_ocode", DbType.String, filter.por_ocode);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }

                if (!string.IsNullOrEmpty(filter.por_status))
                {
                    string por_status = string.Join(",", filter.por_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "por_status ", DbType.String, por_status);
                }

                if (filter.por_omadeby > 0)
                    db.AddInParameter(dbCommand, "por_omadeby", DbType.Int32, filter.por_omadeby);
                
                if (!string.IsNullOrEmpty(filter.por_supplier))
                    db.AddInParameter(dbCommand, "por_supplier", DbType.String, filter.por_supplier);

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
        public static DataTable GetPurchaseReturnItems(int porId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_RETURN_GetDetail");
                db.AddInParameter(dbCommand, "pire_porId", DbType.Int32, porId);

                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetSupplierByBranches_PurchaseOrder(int? branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetSupplier_PurchaseOrder");
                db.AddInParameter(dbCommand, "branchId", DbType.Int32, branchId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPurchaseOrder_BySupplier(int supId, int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPurchaseOrder_BySupplier");
                db.AddInParameter(dbCommand, "pur_supplier", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "branchId", DbType.Int32, branchId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetGRN_ByPurchaseOrder(int sup_branch, int supId, int purId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_Dropdown_ByPurchaseOrder");
                db.AddInParameter(dbCommand, "supId", DbType.Int32, supId);
                db.AddInParameter(dbCommand, "sup_branch", DbType.Int32, sup_branch);
                db.AddInParameter(dbCommand, "purId", DbType.Int32, purId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchItems(string query, int branch, string pr_code)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_ByGRN");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "pir_dcode", DbType.String, pr_code);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetReturnItemDetail_ById(int Id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_GRN_ById");
                db.AddInParameter(dbCommand, "Id", DbType.Int32, Id);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertPurchaseReturn(PurchaseReturnWithItems data, DataTable dt, out string por_code, out int por_Id)
        {
            int POR_result = 0;
            int inserts = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string POR_code = string.Empty;
                bool return_value = false;

                if (data.purchaseReturn != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_RETURN_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "porId", DbType.Int32, data.purchaseReturn.porId);
                    db.AddInParameter(dbCommand, "por_supplier", DbType.Int32, data.purchaseReturn.por_supplier);
                    db.AddInParameter(dbCommand, "por_ocode", DbType.String, data.purchaseReturn.por_ocode);
                    db.AddInParameter(dbCommand, "por_odate", DbType.String, data.purchaseReturn.por_odate);
                    db.AddInParameter(dbCommand, "por_total", DbType.Decimal, data.purchaseReturn.por_total);
                    db.AddInParameter(dbCommand, "por_disc", DbType.Decimal, data.purchaseReturn.por_disc);
                    db.AddInParameter(dbCommand, "por_disc_type", DbType.String, data.purchaseReturn.por_disc_type);
                    db.AddInParameter(dbCommand, "por_net", DbType.Decimal, data.purchaseReturn.por_net);
                    db.AddInParameter(dbCommand, "por_notes", DbType.String, data.purchaseReturn.por_notes);
                    db.AddInParameter(dbCommand, "por_omadeby", DbType.String, data.purchaseReturn.por_omadeby);
                    db.AddInParameter(dbCommand, "por_type", DbType.String, data.purchaseReturn.por_type);
                    db.AddInParameter(dbCommand, "por_branch", DbType.Int32, data.purchaseReturn.por_branch);
                    db.AddInParameter(dbCommand, "por_purId", DbType.Int32, data.purchaseReturn.por_purId);                   
                    db.AddOutParameter(dbCommand, "porId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "porCode_out", DbType.String, 100);
                    db.ExecuteNonQuery(dbCommand);

                    POR_result = int.Parse(db.GetParameterValue(dbCommand, "porId_out").ToString());
                    POR_code = db.GetParameterValue(dbCommand, "porCode_out").ToString();
                }
                if (POR_result > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_PURCHASE_ITEMS_RETURN_BulkInsert"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@porId", POR_result);
                                cmd.Parameters.AddWithValue("@por_branch", data.purchaseReturn.por_branch);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                inserts = 1;
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
                por_code = POR_code;
                por_Id = POR_result;

                return return_value;
            }
            catch (Exception)
            {
                if (POR_result > 0)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_RETURN_REMOVE");
                    db.AddInParameter(dbCommand, "porId", DbType.Int32, POR_result);
                    db.ExecuteNonQuery(dbCommand);
                }
                throw;
            }
        }
        public static DataSet GetPurchaseReturn_Print(int porId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_RETURN_GetPrintDetail");
                db.AddInParameter(dbCommand, "porId", DbType.Int32, porId);
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

        public static int PostPurchaseReturnToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Return_Post_To_Account");
                    db.AddInParameter(dbCommand, "porId", DbType.Int32, id);
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
