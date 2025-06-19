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
    public class MaterialConsumption
    {
        public static DataTable GetMaterialsConsumption(MaterialConsumption_filter filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSUMPTION_REQUESTS_GetDetail");
                if (filter.scr_branch > 0)
                    db.AddInParameter(dbCommand, "scr_branch", DbType.Int32, filter.scr_branch);
                if (filter.scr_refno > 0)
                    db.AddInParameter(dbCommand, "scr_refno", DbType.Int32, filter.scr_refno);
                if (filter.scr_doctor > 0)
                    db.AddInParameter(dbCommand, "scr_doctor", DbType.Int32, filter.scr_doctor);
                if (filter.scr_room > 0)
                    db.AddInParameter(dbCommand, "scr_room", DbType.Int32, filter.scr_room);

                if (!string.IsNullOrEmpty(filter.from_date) && (!string.IsNullOrEmpty(filter.to_date)))
                {
                    db.AddInParameter(dbCommand, "from_date", DbType.String, filter.from_date);
                    db.AddInParameter(dbCommand, "to_date", DbType.String, filter.to_date);
                }
                if (!string.IsNullOrEmpty(filter.scr_status))
                {
                    string scr_status = string.Join(",", filter.scr_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "scr_status ", DbType.String, scr_status);
                }
                if (filter.scr_madeby > 0)
                    db.AddInParameter(dbCommand, "scr_madeby", DbType.Int32, filter.scr_madeby);

                if (!string.IsNullOrEmpty(filter.item_code))
                    db.AddInParameter(dbCommand, "item_code", DbType.String, filter.item_code);

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
        public static DataSet GetDoctorsRoomsMadeby_ByBranch(int branchId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetDoctorsRoomsMadeby_ByBranch");
                db.AddInParameter(dbCommand, "branchId", DbType.Int32, branchId);
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetMaterialsConsumption_Print(int scr_refno, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSUMPTION_REQUESTS_GetDetail");
                db.AddInParameter(dbCommand, "scr_refno", DbType.Int32, scr_refno);
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertMaterialsConsumptions(DataTable dt, int madeby, out int scrId)
        {
            int POR_result = 0;
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
                        using (SqlCommand cmd = new SqlCommand("SP_STOCK_CONSUMPTION_REQUESTS_BulkInsertUpdate"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.AddWithValue("@madeby", madeby);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            inserts = 1;
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

                scrId = POR_result;

                return return_value;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable SearchItems(string query, int branch, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_GetDetail");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "type", DbType.String, type);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static DataTable GetBatchesDetail(string Item_code, int branch, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ITEMS_BATCH_GetDetail");
                db.AddInParameter(dbCommand, "Item_code", DbType.String, Item_code);
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int MaterialConsumption_Status(string data, string status, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0;  int error = 0;
                string[] scrId = data.Split(',');
                foreach(string id in scrId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSUMPTION_REQUESTS_StatusChange");
                    db.AddInParameter(dbCommand, "scrId", DbType.Int32, id);
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
                if(sucsess > 0 && excced == 0 && error == 0)
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

        public static DataTable GetMaterialsConsumptionEditDetail(int scrId, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_STOCK_CONSUMPTION_REQUESTS_GetDetail");
                db.AddInParameter(dbCommand, "scrId", DbType.Int32, scrId);                
                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.ExecuteNonQuery(dbCommand);
                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int PostMaterialConsumptionToAccount(string data, int empId)
        {
            try
            {
                int sucsess = 0; int excced = 0; int error = 0;
                string[] stdId = data.Split(',');
                foreach (string id in stdId)
                {
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Stock_Consumption_Post_To_Account");
                    db.AddInParameter(dbCommand, "scrId", DbType.Int32, id);
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
