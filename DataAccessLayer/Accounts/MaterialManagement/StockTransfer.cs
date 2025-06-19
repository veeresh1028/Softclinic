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
using System.Web.Mvc;

namespace DataAccessLayer.Accounts.MaterialManagement
{
    public class StockTransfer
    {
        #region Direct Stock Transfer
        public static DataTable GetDirectStockTransfer(DirectStockTransferFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_TRANSFER_DIRECT_GetDetail");
                if (filter.stdId > 0)
                    db.AddInParameter(dbCommand, "stdId", DbType.Int32, filter.stdId);

                if (filter.std_from_branch > 0)
                    db.AddInParameter(dbCommand, "std_from_branch", DbType.Int32, filter.std_from_branch);

                if (filter.std_to_branch > 0)
                    db.AddInParameter(dbCommand, "std_to_branch", DbType.Int32, filter.std_to_branch);
                
                if (!string.IsNullOrEmpty(filter.item_code))
                    db.AddInParameter(dbCommand, "std_item_code", DbType.String, filter.item_code);

                if (!string.IsNullOrEmpty(filter.std_refno))
                    db.AddInParameter(dbCommand, "std_refno", DbType.String, filter.std_refno);

                if (!string.IsNullOrEmpty(filter.std_status))
                {
                    string std_status = string.Join(",", filter.std_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "std_status ", DbType.String, std_status);
                }

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
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
        public static bool InsertDirectStockTransfer(DataTable dt, int madeby, out int std_Id)
        {
            int STD_result = 0;
            int inserts = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string POR_code = string.Empty;
                bool return_value = false;

                if (dt.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(db.ConnectionString);
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_STOCK_TRANSFER_DIRECT_BulkInsertUpdate"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.Add("@id_out", SqlDbType.VarChar, 1000);
                            cmd.Parameters["@id_out"].Direction = ParameterDirection.Output;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            inserts = int.Parse((cmd.Parameters["@id_out"].Value).ToString());
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

                std_Id = STD_result;

                return return_value;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int DirectStockTransfer_Status(string data, string status, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_TRANSFER_DIRECT_StatusChange");
                    db.AddInParameter(dbCommand, "stdId", DbType.Int32, id);
                    db.AddInParameter(dbCommand, "status", DbType.String, status);
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

        public static int PostDirectStockTransferToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Direct_Stock_Transfer_Post_To_Account");
                    db.AddInParameter(dbCommand, "stdId", DbType.Int32, id);
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
                return -2;
            }
        }
        #endregion

        #region Direct Stock Transfer
        public static DataTable GetStockTransferRquestDetail(DirectStockTransferFilter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Stock_Transfer_Request_GetDetail");
                if (filter.stdId > 0)
                    db.AddInParameter(dbCommand, "strId", DbType.Int32, filter.stdId);

                if (filter.std_from_branch > 0)
                    db.AddInParameter(dbCommand, "str_from_branch", DbType.Int32, filter.std_from_branch);

                if (filter.std_to_branch > 0)
                    db.AddInParameter(dbCommand, "str_to_branch", DbType.Int32, filter.std_to_branch);

                if (!string.IsNullOrEmpty(filter.item_code))
                    db.AddInParameter(dbCommand, "str_item_code", DbType.String, filter.item_code);

                if (!string.IsNullOrEmpty(filter.std_refno))
                    db.AddInParameter(dbCommand, "str_refno", DbType.String, filter.std_refno);

                if (!string.IsNullOrEmpty(filter.std_status))
                {
                    string std_status = string.Join(",", filter.std_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "str_status ", DbType.String, std_status);
                }

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
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
        public static bool InsertStockTransferRequest(DataTable dt, int madeby, out int std_Id)
        {
            int STD_result = 0;
            int inserts = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string POR_code = string.Empty;
                bool return_value = false;

                if (dt.Rows.Count > 0)
                {
                    SqlConnection con = new SqlConnection(db.ConnectionString);
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_Stock_Transfer_Request_BulkInsertUpdate"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.Add("@id_out", SqlDbType.VarChar, 1000);
                            cmd.Parameters["@id_out"].Direction = ParameterDirection.Output;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            inserts = int.Parse((cmd.Parameters["@id_out"].Value).ToString());
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

                std_Id = STD_result;

                return return_value;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int StockTransferRequest_Status(string data, string status, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Stock_Transfer_Request_StatusChange");
                    db.AddInParameter(dbCommand, "strId", DbType.Int32, id);
                    db.AddInParameter(dbCommand, "status", DbType.String, status);
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
        #endregion

        #region Transfer Stock Based on Request
        public static bool AllocateBatchesToRequest(BatchAllocation allocation)
        {
            int inserts = 0;            
            try
            {
                if (allocation != null)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Allocate_Batches_To_Requested_Item");
                    db.AddInParameter(dbCommand, "strId", DbType.Int32, allocation.strId);
                    db.AddInParameter(dbCommand, "str_itemId", DbType.Int32, allocation.str_itemId);
                    db.AddInParameter(dbCommand, "str_item_code", DbType.String, allocation.str_item_code);
                    db.AddInParameter(dbCommand, "str_ibId", DbType.Int32, allocation.str_ibId);
                    db.AddInParameter(dbCommand, "str_qty", DbType.Decimal, allocation.str_qty);
                    db.AddInParameter(dbCommand, "str_qty2", DbType.Decimal, allocation.str_qty2);
                    db.AddInParameter(dbCommand, "str_qty3", DbType.Decimal, allocation.str_qty3);
                    db.AddInParameter(dbCommand, "str_item_batch", DbType.String, allocation.str_item_batch);
                    db.AddInParameter(dbCommand, "str_item_expiry", DbType.DateTime, allocation.str_item_expiry);
                    db.AddInParameter(dbCommand, "str_request_branch", DbType.Int32, allocation.str_request_branch);
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, allocation.empId);

                    db.AddOutParameter(dbCommand, "Id_out", DbType.Int32, 0);

                    db.ExecuteNonQuery(dbCommand);
                    inserts = int.Parse(db.GetParameterValue(dbCommand, "Id_out").ToString());
                }

                if (inserts > 0)
                {
                    return true;
                }
                else
                {
                    return  false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
