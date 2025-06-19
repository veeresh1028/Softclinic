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
    public class PurchaseRequests
    {
        #region Purchase Requests (Page Load)
        public static DataTable GetPurchaseRequests(PurchaseRequestFilters filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPurchase_Requests");

                if (filter.purqId > 0)
                    db.AddInParameter(dbCommand, "purqId", DbType.Int32, filter.purqId);

                if (!string.IsNullOrEmpty(filter.purq_branch))
                    db.AddInParameter(dbCommand, "purq_branch", DbType.String, filter.purq_branch);

                if (!string.IsNullOrEmpty(filter.purq_ocode))
                    db.AddInParameter(dbCommand, "purq_ocode", DbType.String, filter.purq_ocode);

                if (!string.IsNullOrEmpty(filter.purq_status))
                {
                    string purq_status = string.Join(",", filter.purq_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "purq_status", DbType.String, purq_status);
                }

                if (!string.IsNullOrEmpty(filter.purq_type))
                {
                    string pur_type = string.Join(",", filter.purq_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "purq_type", DbType.String, pur_type);
                }

                if (!string.IsNullOrEmpty(filter.purq_supplier))
                    db.AddInParameter(dbCommand, "purq_supplier", DbType.String, filter.purq_supplier);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }

                if (filter.purq_omadeby > 0)
                    db.AddInParameter(dbCommand, "purq_omadeby", DbType.Int32, filter.purq_omadeby);

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

        public static DataTable GetChildTableItems(int purqId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_Items_ChildTable");
                db.AddInParameter(dbCommand, "prqi_purchase", DbType.Int32, purqId);
                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPurchaseRequestsItems(int purqId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_Items_ForGRN");
                db.AddInParameter(dbCommand, "prqi_purchase", DbType.Int32, purqId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool InsertPurchaseRequest(PurchaseRequestsAndItems data, DataTable dt, out string purq_code, out int purq_Id, string prqi__mode)
        {
            int PR_result = 0;
            int inserts = 0;

            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                string PR_code = string.Empty;
                bool return_value = false;

                if (data.purchaseRequests != null)
                {
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_Insert_Update");
                    db.AddInParameter(dbCommand, "purqId", DbType.Int32, data.purchaseRequests.purqId);
                    db.AddInParameter(dbCommand, "purq_supplier", DbType.Int32, data.purchaseRequests.purq_supplier);
                    db.AddInParameter(dbCommand, "purq_ocode", DbType.String, data.purchaseRequests.purq_ocode);
                    db.AddInParameter(dbCommand, "purq_odate", DbType.String, data.purchaseRequests.purq_odate);
                    db.AddInParameter(dbCommand, "purq_account", DbType.String, data.purchaseRequests.purq_account);
                    db.AddInParameter(dbCommand, "purq_total", DbType.Decimal, data.purchaseRequests.purq_total);
                    db.AddInParameter(dbCommand, "purq_disc", DbType.Decimal, data.purchaseRequests.purq_disc);
                    db.AddInParameter(dbCommand, "purq_disc_type", DbType.String, data.purchaseRequests.purq_disc_type);
                    db.AddInParameter(dbCommand, "purq_net", DbType.Decimal, data.purchaseRequests.purq_net);
                    db.AddInParameter(dbCommand, "purq_notes", DbType.String, data.purchaseRequests.purq_notes);
                    db.AddInParameter(dbCommand, "purq_status", DbType.String, data.purchaseRequests.purq_status);
                    db.AddInParameter(dbCommand, "purq_omadeby", DbType.Int32, data.purchaseRequests.purq_omadeby);
                    db.AddInParameter(dbCommand, "purq_type", DbType.String, data.purchaseRequests.purq_type);
                    db.AddInParameter(dbCommand, "purq_enqno", DbType.String, data.purchaseRequests.purq_enqno);
                    db.AddInParameter(dbCommand, "purq_quono", DbType.String, data.purchaseRequests.purq_quono);
                    db.AddInParameter(dbCommand, "purq_validity", DbType.Int32, data.purchaseRequests.purq_validity);
                    db.AddInParameter(dbCommand, "purq_pay_terms", DbType.Int32, data.purchaseRequests.purq_pay_terms);
                    db.AddInParameter(dbCommand, "purq_qdate", DbType.String, data.purchaseRequests.purq_qdate);
                    db.AddInParameter(dbCommand, "purq_ship_1", DbType.String, data.purchaseRequests.purq_ship_1);
                    db.AddInParameter(dbCommand, "purq_ship_2", DbType.String, data.purchaseRequests.purq_ship_2);
                    db.AddInParameter(dbCommand, "purq_ship_3", DbType.String, data.purchaseRequests.purq_ship_3);
                    db.AddInParameter(dbCommand, "purq_ship_4", DbType.String, data.purchaseRequests.purq_ship_4);
                    db.AddInParameter(dbCommand, "purq_bill_1", DbType.String, data.purchaseRequests.purq_bill_1);
                    db.AddInParameter(dbCommand, "purq_bill_2", DbType.String, data.purchaseRequests.purq_bill_2);
                    db.AddInParameter(dbCommand, "purq_bill_3", DbType.String, data.purchaseRequests.purq_bill_3);
                    db.AddInParameter(dbCommand, "purq_bill_4", DbType.String, data.purchaseRequests.purq_bill_4);
                    db.AddInParameter(dbCommand, "purq_buy_1", DbType.String, data.purchaseRequests.purq_buy_1);
                    db.AddInParameter(dbCommand, "purq_buy_2", DbType.String, data.purchaseRequests.purq_buy_2);
                    db.AddInParameter(dbCommand, "purq_buy_3", DbType.String, data.purchaseRequests.purq_buy_3);
                    db.AddInParameter(dbCommand, "purq_buy_4", DbType.String, data.purchaseRequests.purq_buy_4);
                    db.AddInParameter(dbCommand, "purq_branch", DbType.Int32, data.purchaseRequests.purq_branch);
                    db.AddInParameter(dbCommand, "purq_vat", DbType.Decimal, data.purchaseRequests.purq_vat);
                    db.AddInParameter(dbCommand, "purq_idisc", DbType.Decimal, data.purchaseRequests.purq_idisc);
                    db.AddInParameter(dbCommand, "purq_disc_val", DbType.Decimal, data.purchaseRequests.purq_disc_val);
                    db.AddInParameter(dbCommand, "purq_sup_invoice", DbType.String, data.purchaseRequests.purq_sup_invoice);
                    db.AddOutParameter(dbCommand, "purqId_out", DbType.Int32, 0);
                    db.AddOutParameter(dbCommand, "purqCode_out", DbType.String, 100);
                    db.ExecuteNonQuery(dbCommand);

                    PR_result = int.Parse(db.GetParameterValue(dbCommand, "purqId_out").ToString());
                    PR_code = db.GetParameterValue(dbCommand, "purqCode_out").ToString();
                }

                if (PR_result > 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);

                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_Purchase_Request_Items_BulkInsert"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@prqi_purchase", PR_result);
                                cmd.Parameters.AddWithValue("@prqi_madeby", data.purchaseRequests.empId);
                                cmd.Parameters.AddWithValue("@purq_type", data.purchaseRequests.purq_type);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                inserts += 1;
                            }
                        }
                    }
                    else
                    {
                        if (prqi__mode == "edit")
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

                purq_code = PR_code;

                purq_Id = PR_result;

                return return_value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataSet GetPurchaseRequestPrint(int purqId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_Print");
                db.AddInParameter(dbCommand, "purqId", DbType.Int32, purqId);
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

        public static bool PurchaseRequestActionStatus(string data, string status, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_StatusAction");

                db.AddInParameter(dbCommand, "purqId", DbType.String, data);
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

        public static int DeletePurchaseRequestItems(int prqiId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Purchase_Request_Item_Delete");

                db.AddInParameter(dbCommand, "prqiId", DbType.Int32, prqiId);
                db.AddInParameter(dbCommand, "prqi_madeby", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Miscellaneous Functions
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
        #endregion
    }
}