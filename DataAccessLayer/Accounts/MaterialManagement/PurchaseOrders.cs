using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class PurchaseOrders
    {
        public static DataTable GetPurchaseOrders(PurchaseOrderFilters filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_SELECT_INFO");
                if (filter.purid > 0)
                    db.AddInParameter(dbCommand, "purid", DbType.Int32, filter.purid);
                if (!string.IsNullOrEmpty(filter.pur_branch))
                    db.AddInParameter(dbCommand, "pur_branch", DbType.String, filter.pur_branch);
                if (!string.IsNullOrEmpty(filter.pur_ocode))
                    db.AddInParameter(dbCommand, "pur_ocode", DbType.String, filter.pur_ocode);
                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }
                if (!string.IsNullOrEmpty(filter.pur_status))
                {
                    string pur_status = string.Join(",", filter.pur_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pur_status", DbType.String, pur_status);
                }
                if (filter.pur_omadeby > 0)
                    db.AddInParameter(dbCommand, "pur_omadeby", DbType.Int32, filter.pur_omadeby);
                if (!string.IsNullOrEmpty(filter.pur_type))
                {
                    string pur_type = string.Join(",", filter.pur_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pur_type", DbType.String, pur_type);
                }
                if (!string.IsNullOrEmpty(filter.pur_supplier))
                    db.AddInParameter(dbCommand, "pur_supplier", DbType.String, filter.pur_supplier);
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
        public static DataTable Get_Uom_ItemFactor(int itemId, int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_Get_Uom_ItemFactor");
                db.AddInParameter(dbCommand, "itemId", DbType.Int32, itemId);
                db.AddInParameter(dbCommand, "branchId", DbType.String, branchId);

                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetChildTableItems(int purId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_ChildTable");
                db.AddInParameter(dbCommand, "pi_purchase", DbType.Int32, purId);

                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetPurchaseOrdersItems(int purId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_forGRN");
                db.AddInParameter(dbCommand, "pi_purchase", DbType.Int32, purId);

                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertPurchaseOrder(PurchaseOrderAndItems data, DataTable dt, out string pur_code, out int pur_Id, string pi__mode, string purchase_type, int fixedAssetId)
        {
            int PO_result = 0;
            int inserts = 0;
            int pin_invoice = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string PO_code = string.Empty;
                bool return_value = false;

                if (data.purchaseOrders != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "purId", DbType.Int32, data.purchaseOrders.purId);
                    db.AddInParameter(dbCommand, "pur_supplier", DbType.Int32, data.purchaseOrders.pur_supplier);
                    db.AddInParameter(dbCommand, "pur_ocode", DbType.String, data.purchaseOrders.pur_ocode);
                    db.AddInParameter(dbCommand, "pur_odate", DbType.String, data.purchaseOrders.pur_odate);
                    db.AddInParameter(dbCommand, "pur_account", DbType.String, data.purchaseOrders.pur_account);
                    db.AddInParameter(dbCommand, "pur_total", DbType.Decimal, data.purchaseOrders.pur_total);
                    db.AddInParameter(dbCommand, "pur_disc", DbType.Decimal, data.purchaseOrders.pur_disc);
                    db.AddInParameter(dbCommand, "pur_disc_type", DbType.String, data.purchaseOrders.pur_disc_type);
                    db.AddInParameter(dbCommand, "pur_net", DbType.Decimal, data.purchaseOrders.pur_net);
                    db.AddInParameter(dbCommand, "pur_notes", DbType.String, data.purchaseOrders.pur_notes);
                    db.AddInParameter(dbCommand, "pur_status", DbType.String, data.purchaseOrders.pur_status);
                    db.AddInParameter(dbCommand, "pur_omadeby", DbType.Int32, data.purchaseOrders.pur_omadeby);
                    db.AddInParameter(dbCommand, "pur_type", DbType.String, data.purchaseOrders.pur_type);
                    db.AddInParameter(dbCommand, "pur_enqno", DbType.String, data.purchaseOrders.pur_enqno);
                    db.AddInParameter(dbCommand, "pur_quono", DbType.String, data.purchaseOrders.pur_quono);
                    db.AddInParameter(dbCommand, "pur_validity", DbType.Int32, data.purchaseOrders.pur_validity);
                    db.AddInParameter(dbCommand, "pur_pay_terms", DbType.Int32, data.purchaseOrders.pur_pay_terms);
                    db.AddInParameter(dbCommand, "pur_qdate", DbType.String, data.purchaseOrders.pur_qdate);
                    db.AddInParameter(dbCommand, "pur_ship_1", DbType.String, data.purchaseOrders.pur_ship_1);
                    db.AddInParameter(dbCommand, "pur_ship_2", DbType.String, data.purchaseOrders.pur_ship_2);
                    db.AddInParameter(dbCommand, "pur_ship_3", DbType.String, data.purchaseOrders.pur_ship_3);
                    db.AddInParameter(dbCommand, "pur_ship_4", DbType.String, data.purchaseOrders.pur_ship_4);
                    db.AddInParameter(dbCommand, "pur_bill_1", DbType.String, data.purchaseOrders.pur_bill_1);
                    db.AddInParameter(dbCommand, "pur_bill_2", DbType.String, data.purchaseOrders.pur_bill_2);
                    db.AddInParameter(dbCommand, "pur_bill_3", DbType.String, data.purchaseOrders.pur_bill_3);
                    db.AddInParameter(dbCommand, "pur_bill_4", DbType.String, data.purchaseOrders.pur_bill_4);
                    db.AddInParameter(dbCommand, "pur_buy_1", DbType.String, data.purchaseOrders.pur_buy_1);
                    db.AddInParameter(dbCommand, "pur_buy_2", DbType.String, data.purchaseOrders.pur_buy_2);
                    db.AddInParameter(dbCommand, "pur_buy_3", DbType.String, data.purchaseOrders.pur_buy_3);
                    db.AddInParameter(dbCommand, "pur_buy_4", DbType.String, data.purchaseOrders.pur_buy_4);
                    db.AddInParameter(dbCommand, "pur_branch", DbType.Int32, data.purchaseOrders.pur_branch);
                    db.AddInParameter(dbCommand, "pur_vat", DbType.Decimal, data.purchaseOrders.pur_vat);
                    db.AddInParameter(dbCommand, "pur_idisc", DbType.Decimal, data.purchaseOrders.pur_idisc);
                    db.AddInParameter(dbCommand, "pur_disc_val", DbType.Decimal, data.purchaseOrders.pur_disc_val);
                    db.AddInParameter(dbCommand, "pur_sup_invoice", DbType.String, data.purchaseOrders.pur_sup_invoice);
                    db.AddInParameter(dbCommand, "purchase_type", DbType.String, purchase_type);
                    db.AddInParameter(dbCommand, "fixedAssetId", DbType.Int32, fixedAssetId);
                    db.AddOutParameter(dbCommand, "purId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "purCode_out", DbType.String, 100);
                    db.AddOutParameter(dbCommand, "pin_invoice_out", DbType.Int32, 0);
                    db.ExecuteNonQuery(dbCommand);

                    PO_result = int.Parse(db.GetParameterValue(dbCommand, "purId_out").ToString());
                    pin_invoice = int.Parse(db.GetParameterValue(dbCommand, "pin_invoice_out").ToString());
                    PO_code = db.GetParameterValue(dbCommand, "purCode_out").ToString();
                }
                if (PO_result > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);
                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_PURCHASE_ITEMS_BulkInsert"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@pi_purchase", PO_result);
                                cmd.Parameters.AddWithValue("@pi_madeby", data.purchaseOrders.empId);
                                cmd.Parameters.AddWithValue("@pur_type", data.purchaseOrders.pur_type);
                                cmd.Parameters.AddWithValue("@pin_invoice", pin_invoice);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                inserts = 1;
                            }
                        }
                    }
                    else
                    {
                        if (pi__mode == "edit")
                            inserts = 1;
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
                pur_code = PO_code;
                pur_Id = PO_result;

                return return_value;
            }
            catch (Exception)
            {
                if (PO_result > 0)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_REMOVE");
                    db.AddInParameter(dbCommand, "purId", DbType.Int32, PO_result);
                    db.ExecuteNonQuery(dbCommand);
                }
                throw;
            }
        }
        public static DataSet GetPurchaseOrdersPrint(int purId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDER_Print");
                db.AddInParameter(dbCommand, "purId", DbType.Int32, purId);
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
        public static DataTable GetBarcodePrintData(int purId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_PrintBarcode");
                db.AddInParameter(dbCommand, "purId", DbType.Int32, purId);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool PurchaseOrderActionStatus(string data, string status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDER_StatusAction");
                db.AddInParameter(dbCommand, "purId", DbType.String, data);
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
        public static bool UploadDocument(BusinessEntities.Common.DocumentUpload doc)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DocumentUpload_PurchaseOrder");

                db.AddInParameter(dbCommand, "pod_purId", DbType.Int32, doc.doc_refId);
                db.AddInParameter(dbCommand, "pod_type", DbType.String, doc.doc_reftype);
                db.AddInParameter(dbCommand, "pod_title", DbType.String, doc.doc_label);
                db.AddInParameter(dbCommand, "pod_document", DbType.String, doc.doc_name);
                db.AddInParameter(dbCommand, "pod_document_ext", DbType.String, doc.doc_ext);
                db.AddInParameter(dbCommand, "pod_madeby", DbType.Int32, doc.doc_uploadedBy);
                db.AddInParameter(dbCommand, "pod_path", DbType.String, doc.doc_path);
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
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetDocumentsById(int id, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PurchaseOrder_DocumentsById");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool DeleteDocuments(int docId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PurchaseOrder_Documents_Delete");

                db.AddInParameter(dbCommand, "podId", DbType.Int32, docId);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
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
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetFilePathDownload(int id, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPurchaseDocsToDownload");
                db.AddInParameter(dbCommand, "Id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "Type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DeletePurchaseItems(int piId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_deleteItems");
                db.AddInParameter(dbCommand, "piId", DbType.Int32, piId);
                db.AddInParameter(dbCommand, "pi_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool UpdatePurchaseOrder(PurchaseOrderAndItems data, DataTable dt, out string pur_code, out int pur_Id)
        {
            int PO_result = 0;
            int PI_result = 0;
            int inserts = 0;
            int pin_invoice = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string PO_code = string.Empty;
                int return_value = 0;

                if (data.purchaseOrders.purId > 0 && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["pi_mode"].ToString() == "create")
                        {
                            DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ITEMS_UpdateItems");
                            db.AddInParameter(dbCommand, "piId", DbType.Int32, dr["piId"].ToString());
                            db.AddInParameter(dbCommand, "pi_mode", DbType.String, dr["pi_mode"].ToString());
                            db.AddInParameter(dbCommand, "pi_purchase", DbType.Int32, dr["pi_purchase"].ToString());
                            db.AddInParameter(dbCommand, "pi_item", DbType.Int32, dr["pi_item"].ToString());
                            db.AddInParameter(dbCommand, "pi_desc", DbType.String, dr["pi_desc"].ToString());
                            db.AddInParameter(dbCommand, "pi_edate", DbType.String, dr["pi_edate"].ToString());
                            db.AddInParameter(dbCommand, "pi_oqty", DbType.Decimal, dr["pi_oqty"].ToString());
                            db.AddInParameter(dbCommand, "pi_uom", DbType.String, dr["pi_uom"].ToString());
                            db.AddInParameter(dbCommand, "pi_uprice", DbType.Decimal, dr["pi_uprice"].ToString());
                            db.AddInParameter(dbCommand, "pi_disc", DbType.Decimal, dr["pi_disc"].ToString());
                            db.AddInParameter(dbCommand, "pi_disc_type", DbType.String, dr["pi_disc_type"].ToString());
                            db.AddInParameter(dbCommand, "pi_nprice", DbType.Decimal, dr["pi_nprice"].ToString());
                            db.AddInParameter(dbCommand, "pi_vat", DbType.Decimal, dr["pi_vat"].ToString());
                            db.AddInParameter(dbCommand, "pi_bqty", DbType.Decimal, dr["pi_bqty"].ToString());
                            db.AddInParameter(dbCommand, "pi_bqty2", DbType.Decimal, dr["pi_bqty2"].ToString());
                            db.AddInParameter(dbCommand, "pi_bqty3", DbType.Decimal, dr["pi_bqty3"].ToString());
                            db.AddInParameter(dbCommand, "pi_bqty_uom", DbType.String, dr["pi_bqty_uom"].ToString());
                            db.AddInParameter(dbCommand, "pi_bqty2_uom", DbType.String, dr["pi_bqty2_uom"].ToString());
                            db.AddInParameter(dbCommand, "pi_bqty3_uom", DbType.String, dr["pi_bqty3_uom"].ToString());
                            db.AddInParameter(dbCommand, "pi_rqty", DbType.Decimal, dr["pi_rqty"].ToString());
                            db.AddInParameter(dbCommand, "pi_rqty2", DbType.Decimal, dr["pi_rqty2"].ToString());
                            db.AddInParameter(dbCommand, "pi_rqty3", DbType.Decimal, dr["pi_rqty3"].ToString());
                            db.AddInParameter(dbCommand, "pi_disc_value", DbType.Decimal, dr["pi_disc_value"].ToString());
                            db.AddInParameter(dbCommand, "pi_freeQty", DbType.Decimal, dr["pi_freeQty"].ToString());
                            db.AddInParameter(dbCommand, "pi_freeUOM", DbType.String, dr["pi_freeUOM"].ToString());
                            db.AddInParameter(dbCommand, "pi_batch", DbType.String, dr["pi_batch"].ToString());
                            db.AddInParameter(dbCommand, "pi_branch", DbType.Int32, dr["pi_branch"].ToString());
                            db.AddInParameter(dbCommand, "pi_freeBatch", DbType.String, dr["pi_freeBatch"].ToString());
                            db.AddInParameter(dbCommand, "pi_freeExpiry", DbType.String, dr["pi_freeExpiry"].ToString());
                            db.AddInParameter(dbCommand, "pi_net", DbType.Decimal, dr["pi_net"].ToString());
                            db.AddInParameter(dbCommand, "pi_total", DbType.Decimal, dr["pi_total"].ToString());
                            db.AddInParameter(dbCommand, "pi_vat_per", DbType.Decimal, dr["pi_vat_per"].ToString());
                            db.AddInParameter(dbCommand, "pi_cost", DbType.Decimal, dr["pi_cost"].ToString());
                            db.AddInParameter(dbCommand, "pi_cost2", DbType.Decimal, dr["pi_cost2"].ToString());
                            db.AddInParameter(dbCommand, "pi_cost3", DbType.Decimal, dr["pi_cost3"].ToString());
                            db.AddInParameter(dbCommand, "pi_sprice", DbType.Decimal, dr["pi_sprice"].ToString());
                            db.AddInParameter(dbCommand, "pi_sprice2", DbType.Decimal, dr["pi_sprice2"].ToString());
                            db.AddInParameter(dbCommand, "pi_sprice3", DbType.Decimal, dr["pi_sprice3"].ToString());
                            db.AddInParameter(dbCommand, "m_factor", DbType.Decimal, dr["m_factor"].ToString());
                            db.AddInParameter(dbCommand, "m_factor2", DbType.Decimal, dr["m_factor2"].ToString());
                            db.AddInParameter(dbCommand, "madeby", DbType.Int32, data.purchaseOrders.pur_omadeby);
                            int pi_id = db.ExecuteNonQuery(dbCommand);
                            if (pi_id > 0)
                                return_value += 1;
                        }
                        else
                            return_value += 1;
                    }
                }


                if (return_value > 0 && data.purchaseOrders != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_PURCHASE_ORDERS_INSERT_UPDATE");
                    db.AddInParameter(dbCommand, "purId", DbType.Int32, data.purchaseOrders.purId);
                    db.AddInParameter(dbCommand, "pur_supplier", DbType.Int32, data.purchaseOrders.pur_supplier);
                    db.AddInParameter(dbCommand, "pur_ocode", DbType.String, data.purchaseOrders.pur_ocode);
                    db.AddInParameter(dbCommand, "pur_odate", DbType.String, data.purchaseOrders.pur_odate);
                    db.AddInParameter(dbCommand, "pur_account", DbType.String, data.purchaseOrders.pur_account);
                    db.AddInParameter(dbCommand, "pur_notes", DbType.String, data.purchaseOrders.pur_notes);
                    db.AddInParameter(dbCommand, "pur_status", DbType.String, data.purchaseOrders.pur_status);
                    db.AddInParameter(dbCommand, "pur_omadeby", DbType.Int32, data.purchaseOrders.pur_omadeby);
                    db.AddInParameter(dbCommand, "pur_type", DbType.String, data.purchaseOrders.pur_type);
                    db.AddInParameter(dbCommand, "pur_enqno", DbType.String, data.purchaseOrders.pur_enqno);
                    db.AddInParameter(dbCommand, "pur_quono", DbType.String, data.purchaseOrders.pur_quono);
                    db.AddInParameter(dbCommand, "pur_validity", DbType.Int32, data.purchaseOrders.pur_validity);
                    db.AddInParameter(dbCommand, "pur_pay_terms", DbType.Int32, data.purchaseOrders.pur_pay_terms);
                    db.AddInParameter(dbCommand, "pur_qdate", DbType.String, data.purchaseOrders.pur_qdate);
                    db.AddInParameter(dbCommand, "pur_ship_1", DbType.String, data.purchaseOrders.pur_ship_1);
                    db.AddInParameter(dbCommand, "pur_ship_2", DbType.String, data.purchaseOrders.pur_ship_2);
                    db.AddInParameter(dbCommand, "pur_ship_3", DbType.String, data.purchaseOrders.pur_ship_3);
                    db.AddInParameter(dbCommand, "pur_ship_4", DbType.String, data.purchaseOrders.pur_ship_4);
                    db.AddInParameter(dbCommand, "pur_bill_1", DbType.String, data.purchaseOrders.pur_bill_1);
                    db.AddInParameter(dbCommand, "pur_bill_2", DbType.String, data.purchaseOrders.pur_bill_2);
                    db.AddInParameter(dbCommand, "pur_bill_3", DbType.String, data.purchaseOrders.pur_bill_3);
                    db.AddInParameter(dbCommand, "pur_bill_4", DbType.String, data.purchaseOrders.pur_bill_4);
                    db.AddInParameter(dbCommand, "pur_buy_1", DbType.String, data.purchaseOrders.pur_buy_1);
                    db.AddInParameter(dbCommand, "pur_buy_2", DbType.String, data.purchaseOrders.pur_buy_2);
                    db.AddInParameter(dbCommand, "pur_buy_3", DbType.String, data.purchaseOrders.pur_buy_3);
                    db.AddInParameter(dbCommand, "pur_buy_4", DbType.String, data.purchaseOrders.pur_buy_4);
                    db.AddInParameter(dbCommand, "pur_branch", DbType.Int32, data.purchaseOrders.pur_branch);
                    db.AddInParameter(dbCommand, "pur_sup_invoice", DbType.String, data.purchaseOrders.pur_sup_invoice);
                    db.AddOutParameter(dbCommand, "purId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "purCode_out", DbType.String, 100);
                    db.AddOutParameter(dbCommand, "pin_invoice_out", DbType.Int32, 0);
                    db.ExecuteNonQuery(dbCommand);

                    PO_result = int.Parse(db.GetParameterValue(dbCommand, "purId_out").ToString());
                    pin_invoice = int.Parse(db.GetParameterValue(dbCommand, "pin_invoice_out").ToString());
                    PO_code = db.GetParameterValue(dbCommand, "purCode_out").ToString();
                }
                pur_code = PO_code;
                pur_Id = PO_result;
                if (return_value > 0)
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
        }
        public static DataSet GetPurchaseOrderHistory(string code, int branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Purchase_Order_History");
                db.AddInParameter(dbCommand, "pur_code", DbType.String, code);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Purchase Request
        public static DataTable GetPurchaseRequests(int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_List");

                db.AddInParameter(dbCommand, "branchId", DbType.Int32, branchId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetPurchaseRequestAndRequestItems(int purqId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Purchase_Request_And_Items_Detail");

                db.AddInParameter(dbCommand, "purqId", DbType.Int32, purqId);

                db.ExecuteNonQuery(dbCommand);

                DataSet result = db.ExecuteDataSet(dbCommand);

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetUOMItemWise(int itemId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Items_Uom");
                db.AddInParameter(dbCommand, "itemId", DbType.String, itemId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Stock Item Enquiry

        public static DataSet GetItemEnquiryDetail(int itemId, string item_code, int item_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Stock_Items_Enquiry_Detail");
                db.AddInParameter(dbCommand, "itemId", DbType.Int32, itemId);
                db.AddInParameter(dbCommand, "item_code", DbType.String, item_code);
                db.AddInParameter(dbCommand, "item_branch", DbType.Int32, item_branch);
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

        #endregion
    }
}
