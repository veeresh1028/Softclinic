using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessEntities.Masters;

namespace DataAccessLayer.Masters
{
    public class Medicines
    {
        #region Medicines Master (Page Load)
        public static DataTable GetMedicines(int? itemId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Medicine_ByID");

                if (itemId > 0)
                {
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, itemId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchMedicines(MedicinesFilter data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medicines_select_all_info");

                if (data.itemId > 0)
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.itemId);

                if (!string.IsNullOrEmpty(data.item_name_code))
                    db.AddInParameter(dbCommand, "item_name_code", DbType.String, data.item_name_code);

                if (!string.IsNullOrEmpty(data.item_type))
                {
                    string item_type = string.Join(",", data.item_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "item_type", DbType.String, item_type);
                }

                if (!string.IsNullOrEmpty(data.item_status))
                {
                    string item_status = string.Join(",", data.item_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "item_status", DbType.String, item_status);
                }

                if (!string.IsNullOrEmpty(data.item_category))
                    db.AddInParameter(dbCommand, "item_category", DbType.String, data.item_category);

                if (!string.IsNullOrEmpty(data.item_brand))
                    db.AddInParameter(dbCommand, "item_brand", DbType.String, data.item_brand);

                if (!string.IsNullOrEmpty(data.item_location))
                    db.AddInParameter(dbCommand, "item_location", DbType.String, data.item_location);

                if (!string.IsNullOrEmpty(data.item_branch))
                    db.AddInParameter(dbCommand, "item_branch", DbType.String, data.item_branch);

                if (data.item_madeby > 0)
                    db.AddInParameter(dbCommand, "item_madeby", DbType.Int32, data.item_madeby);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Medicines CRUD Operations
        public static bool InsertUpdateMedicine(BusinessEntities.Masters.Medicines data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medicines_Insert_Update");

                if (data.itemId > 0)
                {
                    db.AddInParameter(dbCommand, "itemId", DbType.Int32, data.itemId);
                }

                db.AddInParameter(dbCommand, "item_supplier", DbType.String, data.item_supplier);
                db.AddInParameter(dbCommand, "item_type", DbType.String, data.item_type);
                db.AddInParameter(dbCommand, "item_category", DbType.Int32, data.item_category);
                db.AddInParameter(dbCommand, "item_location", DbType.Int32, data.item_location);
                db.AddInParameter(dbCommand, "item_code", DbType.String, data.item_code);
                db.AddInParameter(dbCommand, "item_name", DbType.String, data.item_name);
                db.AddInParameter(dbCommand, "item_desc", DbType.String, data.item_desc);
                db.AddInParameter(dbCommand, "item_account", DbType.String, data.item_account);
                db.AddInParameter(dbCommand, "item_brand", DbType.String, data.item_brand);
                db.AddInParameter(dbCommand, "item_dosage", DbType.String, data.item_dosage);
                db.AddInParameter(dbCommand, "item_strength", DbType.String, data.item_strength);
                db.AddInParameter(dbCommand, "item_pur_account", DbType.String, data.item_pur_account);
                db.AddInParameter(dbCommand, "item_branch", DbType.Int32, data.item_branch);
                db.AddInParameter(dbCommand, "item_qty", DbType.Decimal, data.item_qty);
                db.AddInParameter(dbCommand, "item_uom", DbType.String, data.item_uom);
                db.AddInParameter(dbCommand, "item_cost", DbType.Decimal, data.item_cost);
                db.AddInParameter(dbCommand, "item_sprice", DbType.Decimal, data.item_sprice);
                db.AddInParameter(dbCommand, "item_m_factor", DbType.Decimal, data.item_m_factor);
                db.AddInParameter(dbCommand, "item_qty2", DbType.Decimal, data.item_qty2);
                db.AddInParameter(dbCommand, "item_uom2", DbType.String, data.item_uom2);
                db.AddInParameter(dbCommand, "item_cost2", DbType.Decimal, data.item_cost2);
                db.AddInParameter(dbCommand, "item_sprice2", DbType.Decimal, data.item_sprice2);
                db.AddInParameter(dbCommand, "item_m_factor2", DbType.Decimal, data.item_m_factor2);
                db.AddInParameter(dbCommand, "item_uom3", DbType.String, data.item_uom3);
                db.AddInParameter(dbCommand, "item_qty3", DbType.Decimal, data.item_qty3);
                db.AddInParameter(dbCommand, "item_cost3", DbType.Decimal, data.item_cost3);
                db.AddInParameter(dbCommand, "item_sprice3", DbType.Decimal, data.item_sprice3);
                db.AddInParameter(dbCommand, "item_vat", DbType.Decimal, data.item_vat);
                db.AddInParameter(dbCommand, "item_madeby", DbType.Int32, data.item_madeby);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateMedicinestatus(int itemId, string item_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Medicines_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "itemId", DbType.Int32, itemId);
                db.AddInParameter(dbCommand, "item_status", DbType.String, item_status);
                db.AddOutParameter(dbCommand, "item_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "item_output").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetBranchMedicines(int item_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Branch_Medicines");
                if (item_branch > 0)
                {
                    db.AddInParameter(dbCommand, "item_branch", DbType.Int32, item_branch);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Medicines Import (DHA / MOH)
        public static int BulkInsert_DHAMOH_Medicines(DataTable dt)
        {
            try
            {
                int inserts = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BulkInsert_DHAMOH_Medicines"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        inserts += 1;
                    }
                }

                return inserts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertDHA_Prescriptions(BusinessEntities.Masters.Medicines medicine)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_InsertDHA_Medicines");

                db.AddInParameter(dbCommand, "item_code", DbType.String, medicine.item_code);
                db.AddInParameter(dbCommand, "item_name", DbType.String, medicine.item_name);
                db.AddInParameter(dbCommand, "mo_brand", DbType.String, medicine.mo_brand);
                db.AddInParameter(dbCommand, "mo_dosage", DbType.String, medicine.mo_dosage);
                db.AddInParameter(dbCommand, "mo_strength", DbType.String, medicine.mo_strength);
                db.AddInParameter(dbCommand, "mo_status", DbType.String, medicine.mo_status);
                db.AddInParameter(dbCommand, "mo_status_grace_peried", DbType.String, medicine.mo_status_grace_peried);

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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}