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

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class GRN
    {
        public static DataTable GetPurchaseReceived(GRN_Filters filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_RECEIVED_GetDetails");
                if (filter.prId > 0)
                    db.AddInParameter(dbCommand, "prId", DbType.Int32, filter.prId);
                if (filter.pr_branch > 0)
                    db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, filter.pr_branch);
                if (!string.IsNullOrEmpty(filter.pr_code))
                    db.AddInParameter(dbCommand, "pr_code", DbType.String, filter.pr_code);
                if (!string.IsNullOrEmpty(filter.order_code))
                    db.AddInParameter(dbCommand, "order_code", DbType.String, filter.order_code);
                if (!string.IsNullOrEmpty(filter.pr_fdate) && (!string.IsNullOrEmpty(filter.pr_tdate)))
                {
                    db.AddInParameter(dbCommand, "pr_fdate", DbType.String, filter.pr_fdate);
                    db.AddInParameter(dbCommand, "pr_tdate", DbType.String, filter.pr_tdate);
                }
                if (!string.IsNullOrEmpty(filter.pr_status))
                {
                    string pr__status = string.Join(",", filter.pr_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pr_status", DbType.String, pr__status);
                }
                if (!string.IsNullOrEmpty(filter.pr_supplier))
                    db.AddInParameter(dbCommand, "pr_supplier", DbType.String, filter.pr_supplier);
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
        public static DataTable GetPurchaseReceivedItems(GRN_Filters filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_RECEIVED_GetDetails");
                if (filter.prId > 0)
                    db.AddInParameter(dbCommand, "prId", DbType.Int32, filter.prId);
                if (filter.pirId > 0)
                    db.AddInParameter(dbCommand, "pirId", DbType.Int32, filter.pirId);
                if (filter.pr_branch > 0)
                    db.AddInParameter(dbCommand, "pir_branch", DbType.Int32, filter.pr_branch);
                if (!string.IsNullOrEmpty(filter.pr_code))
                    db.AddInParameter(dbCommand, "pir_dcode", DbType.String, filter.pr_code);
                if (!string.IsNullOrEmpty(filter.pr_fdate) && (!string.IsNullOrEmpty(filter.pr_tdate)))
                {
                    db.AddInParameter(dbCommand, "pir_fdate", DbType.String, filter.pr_fdate);
                    db.AddInParameter(dbCommand, "pir_tdate", DbType.String, filter.pr_tdate);
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
        public static DataSet GetGRN_Print(int prId, int pr_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_Details_print");
                db.AddInParameter(dbCommand, "prId", DbType.Int32, prId);
                db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, pr_branch);
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
        public static DataTable GetBarcodePrintData(string pr_code, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_RECEIVED_PrintBarcode");
                db.AddInParameter(dbCommand, "pr_code", DbType.String, pr_code);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static bool GRN_Status(string data, string status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_RECEIVED_StatusChange");
                db.AddInParameter(dbCommand, "prId", DbType.String, data);
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
            catch (Exception ex)
            {
                throw;
            }
        }
        public static DataTable SearchPurchaseOrder(string query, int branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_search");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetUOMDetail(int piId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_ItemsUom");
                db.AddInParameter(dbCommand, "piId", DbType.String, piId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertGRN(GRN_and_Items data, DataTable dt, out string pr_Code, out int pr_Id)
        {
            pr_Code = "";
            pr_Id = 0;
            int inserts = 0;
            int pr_slno_out = 0;
            bool return_value = false;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                if (data.grn != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_RECEIVED_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "prId", DbType.Int32, data.grn.prId);
                    db.AddInParameter(dbCommand, "pr_PurchaseOrder", DbType.Int32, data.grn.pr_PurchaseOrder);
                    db.AddInParameter(dbCommand, "pr_supplier", DbType.Int32, data.grn.pr_supplier);
                    db.AddInParameter(dbCommand, "pr_date", DbType.String, data.grn.pr_date);
                    db.AddInParameter(dbCommand, "pr_supplier_inv", DbType.String, data.grn.pr_supplier_inv);
                    db.AddInParameter(dbCommand, "pr_total", DbType.Decimal, data.grn.pr_total);
                    db.AddInParameter(dbCommand, "pr_discount", DbType.Decimal, data.grn.pr_discount);
                    db.AddInParameter(dbCommand, "pr_net", DbType.Decimal, data.grn.pr_net);
                    db.AddInParameter(dbCommand, "pr_vat", DbType.Decimal, data.grn.pr_vat);
                    db.AddInParameter(dbCommand, "pr_netvat", DbType.Decimal, data.grn.pr_netvat);
                    db.AddInParameter(dbCommand, "pr_status", DbType.String, data.grn.pr_status);
                    db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, data.grn.pr_branch);
                    db.AddInParameter(dbCommand, "pr_notes", DbType.String, data.grn.pr_notes);
                    db.AddInParameter(dbCommand, "pr_madeby", DbType.Int32, data.grn.pr_madeby);
                    db.AddInParameter(dbCommand, "purchase_order", DbType.String, data.grn.purchase_order);
                    db.AddInParameter(dbCommand, "pr_supplier_inv_date", DbType.String, data.grn.pr_supplier_inv_date);
                    db.AddOutParameter(dbCommand, "prId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "pr_slno_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "prCode_out", DbType.String, 100);
                    db.ExecuteNonQuery(dbCommand);

                    pr_Id = int.Parse(db.GetParameterValue(dbCommand, "prId_out").ToString());
                    pr_slno_out = int.Parse(db.GetParameterValue(dbCommand, "pr_slno_out").ToString());
                    pr_Code = db.GetParameterValue(dbCommand, "prCode_out").ToString();
                }
                if (pr_Id > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_PURCHASE_ITEMS_RECEIVED_BulkInsert"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@pir_dcode", pr_Code);
                                cmd.Parameters.AddWithValue("@pir_dmadeby", data.grn.pr_madeby);
                                cmd.Parameters.AddWithValue("@pir_branch", data.grn.pr_branch);
                                cmd.Parameters.AddWithValue("@pir_piId", pr_Id);
                                cmd.Parameters.AddWithValue("@pir_slno", pr_slno_out);
                                cmd.Parameters.AddWithValue("@pir_supplier_inv", data.grn.pr_supplier_inv);
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
            catch (Exception ex)
            {
                if (pr_Id > 0)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_RECEIVED_REMOVE");
                    db.AddInParameter(dbCommand, "prId", DbType.Int32, pr_Id);
                    db.ExecuteNonQuery(dbCommand);
                }
                throw;
            }
            ;
        }

        public static DataSet GetGRN_Edit(int prId, int pr_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_Details_edit");
                db.AddInParameter(dbCommand, "prId", DbType.Int32, prId);
                db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, pr_branch);
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
        public static DataTable GetEditGRN_UOMDetail(int pirId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetGRN_ItemsUom");
                db.AddInParameter(dbCommand, "pirId", DbType.String, pirId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool UpdateGRN(GRN_and_Items data, DataTable dt, out string pr_Code, out int pr_Id)
        {
            pr_Code = "";
            pr_Id = 0;
            int updated = 0;
            int pr_slno_out = 0;
            bool return_value = false;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                if (data.grn != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_RECEIVED_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "prId", DbType.Int32, data.grn.prId);
                    db.AddInParameter(dbCommand, "pr_PurchaseOrder", DbType.Int32, data.grn.pr_PurchaseOrder);
                    db.AddInParameter(dbCommand, "pr_supplier", DbType.Int32, data.grn.pr_supplier);
                    db.AddInParameter(dbCommand, "pr_date", DbType.String, data.grn.pr_date);
                    db.AddInParameter(dbCommand, "pr_supplier_inv", DbType.String, data.grn.pr_supplier_inv);
                    db.AddInParameter(dbCommand, "pr_total", DbType.Decimal, data.grn.pr_total);
                    db.AddInParameter(dbCommand, "pr_discount", DbType.Decimal, data.grn.pr_discount);
                    db.AddInParameter(dbCommand, "pr_net", DbType.Decimal, data.grn.pr_net);
                    db.AddInParameter(dbCommand, "pr_vat", DbType.Decimal, data.grn.pr_vat);
                    db.AddInParameter(dbCommand, "pr_netvat", DbType.Decimal, data.grn.pr_netvat);
                    db.AddInParameter(dbCommand, "pr_status", DbType.String, data.grn.pr_status);
                    db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, data.grn.pr_branch);
                    db.AddInParameter(dbCommand, "pr_notes", DbType.String, data.grn.pr_notes);
                    db.AddInParameter(dbCommand, "pr_madeby", DbType.Int32, data.grn.pr_madeby);
                    db.AddInParameter(dbCommand, "purchase_order", DbType.String, data.grn.purchase_order);
                    db.AddInParameter(dbCommand, "pr_supplier_inv_date", DbType.String, data.grn.pr_supplier_inv_date);
                    db.AddOutParameter(dbCommand, "prId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "pr_slno_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "prCode_out", DbType.String, 100);
                    db.ExecuteNonQuery(dbCommand);

                    pr_Id = int.Parse(db.GetParameterValue(dbCommand, "prId_out").ToString());
                    pr_slno_out = int.Parse(db.GetParameterValue(dbCommand, "pr_slno_out").ToString());
                    pr_Code = db.GetParameterValue(dbCommand, "prCode_out").ToString();
                }
                if (pr_Id > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_RECEIVED_update");
                            db.AddInParameter(dbCommand, "pirId", DbType.Int32, dr["pirId"].ToString());
                            db.AddInParameter(dbCommand, "pir_pur_item", DbType.Int32, dr["pir_pur_item"].ToString());
                            db.AddInParameter(dbCommand, "pir_grnno", DbType.String, dr["pir_grnno"].ToString());
                            db.AddInParameter(dbCommand, "pir_ddate", DbType.DateTime, dr["pir_ddate"].ToString());
                            db.AddInParameter(dbCommand, "pir_received", DbType.Decimal, dr["pir_received"].ToString());
                            db.AddInParameter(dbCommand, "pir_edate", DbType.DateTime, dr["pir_edate"].ToString());
                            db.AddInParameter(dbCommand, "pir_batchno", DbType.String, dr["pir_batchno"].ToString());
                            db.AddInParameter(dbCommand, "pir_uom", DbType.String, dr["pir_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty", DbType.Decimal, dr["pir_free_qty"].ToString());
                            db.AddInParameter(dbCommand, "pir_vat", DbType.Decimal, dr["pir_vat"].ToString());
                            db.AddInParameter(dbCommand, "pir_fuom", DbType.String, dr["pir_fuom"].ToString());
                            db.AddInParameter(dbCommand, "pir_received_1", DbType.Decimal, dr["pir_received_1"].ToString());
                            db.AddInParameter(dbCommand, "pir_received_2", DbType.Decimal, dr["pir_received_2"].ToString());
                            db.AddInParameter(dbCommand, "pir_received_3", DbType.Decimal, dr["pir_received_3"].ToString());
                            db.AddInParameter(dbCommand, "pir_received_1_uom", DbType.String, dr["pir_received_1_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_received_2_uom", DbType.String, dr["pir_received_2_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_received_3_uom", DbType.String, dr["pir_received_3_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty_1", DbType.Decimal, dr["pir_free_qty_1"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty_2", DbType.Decimal, dr["pir_free_qty_2"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty_3", DbType.Decimal, dr["pir_free_qty_3"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty_1_uom", DbType.String, dr["pir_free_qty_1_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty_2_uom", DbType.String, dr["pir_free_qty_2_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_free_qty_3_uom", DbType.String, dr["pir_free_qty_3_uom"].ToString());
                            db.AddInParameter(dbCommand, "pir_uprice", DbType.Decimal, dr["pir_uprice"].ToString());
                            db.AddInParameter(dbCommand, "pir_disc", DbType.Decimal, dr["pir_disc"].ToString());
                            db.AddInParameter(dbCommand, "pir_disc_type", DbType.String, dr["pir_disc_type"].ToString());
                            db.AddInParameter(dbCommand, "pir_disc_val", DbType.Decimal, dr["pir_disc_val"].ToString());
                            db.AddInParameter(dbCommand, "pir_nprice", DbType.Decimal, dr["pir_nprice"].ToString());
                            db.AddInParameter(dbCommand, "pir_net", DbType.Decimal, dr["pir_net"].ToString());
                            db.AddInParameter(dbCommand, "pir_vat_per", DbType.Decimal, dr["pir_vat_per"].ToString());
                            db.AddInParameter(dbCommand, "pir_piId", DbType.Int32, dr["pir_piId"].ToString());
                            db.AddInParameter(dbCommand, "pir_freeBatch", DbType.String, dr["pir_freeBatch"].ToString());
                            db.AddInParameter(dbCommand, "pir_freeExpiry", DbType.DateTime, dr["pir_freeExpiry"].ToString());
                            db.AddInParameter(dbCommand, "pir_total", DbType.Decimal, dr["pir_total"].ToString());
                            db.AddInParameter(dbCommand, "pir_cost", DbType.Decimal, dr["pir_cost"].ToString());
                            db.AddInParameter(dbCommand, "pir_cost2", DbType.Decimal, dr["pir_cost2"].ToString());
                            db.AddInParameter(dbCommand, "pir_cost3", DbType.Decimal, dr["pir_cost3"].ToString());
                            db.AddInParameter(dbCommand, "pir_sprice", DbType.Decimal, dr["pir_sprice"].ToString());
                            db.AddInParameter(dbCommand, "pir_sprice2", DbType.Decimal, dr["pir_sprice2"].ToString());
                            db.AddInParameter(dbCommand, "pir_sprice3", DbType.Decimal, dr["pir_sprice3"].ToString());
                            db.AddInParameter(dbCommand, "m_factor", DbType.Decimal, dr["m_factor"].ToString());
                            db.AddInParameter(dbCommand, "m_factor2", DbType.Decimal, dr["m_factor2"].ToString());
                            db.AddInParameter(dbCommand, "pir_purchase", DbType.Int32, dr["pir_purchase"].ToString());
                            db.AddInParameter(dbCommand, "rQty_status", DbType.String, dr["rQty_status"].ToString());
                            db.AddInParameter(dbCommand, "fQty_status", DbType.String, dr["fQty_status"].ToString());
                            db.AddInParameter(dbCommand, "previous_rqty", DbType.String, dr["previous_rqty"].ToString());
                            db.AddInParameter(dbCommand, "previous_fqty", DbType.String, dr["previous_fqty"].ToString());
                            db.AddInParameter(dbCommand, "pir_dcode", DbType.String, dr["pir_dcode"].ToString());
                            db.AddInParameter(dbCommand, "pr_madeby", DbType.Int32, data.grn.pr_madeby);
                            db.AddInParameter(dbCommand, "pr_branch", DbType.Int32, data.grn.pr_branch);
                            db.AddInParameter(dbCommand, "prId", DbType.Int32, data.grn.prId);
                            db.AddOutParameter(dbCommand, "id_out", DbType.Int32, 0);
                            db.ExecuteNonQuery(dbCommand);
                            updated = int.Parse(db.GetParameterValue(dbCommand, "id_out").ToString());
                        }
                    }
                }

                if (updated > 0)
                {
                    return_value = true;
                }
                else
                {
                    return_value = false;
                }
                return return_value;
            }
            catch (Exception ex)
            {
                throw;
            }
           ;
        }
    }
}
