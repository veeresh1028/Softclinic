using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class Designations
    {
        #region Designations Page Load
        public static DataTable GetDesignations(int? desiId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DESIGNATIONS_SELECT_ALL_INFO");

                if (desiId > 0)
                {
                    db.AddInParameter(dbCommand, "desiId", DbType.Int32, desiId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Designations CRUD Operations
        public static bool InsertUpdateDesignation(BusinessEntities.Masters.Designations designation)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DESIGNATIONS_INSERT_UPDATE");

                if (designation.desiId > 0)
                {
                    db.AddInParameter(dbCommand, "desiId", DbType.Int32, designation.desiId);
                }

                db.AddInParameter(dbCommand, "designation", DbType.String, designation.designation);

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

        public static int UpdateDesignationStatus(int desiId, string desi_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DESIGNATIONS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "desiId", DbType.Int32, desiId);
                db.AddInParameter(dbCommand, "desi_status", DbType.String, desi_status);
                db.AddOutParameter(dbCommand, "desi_output", DbType.Int32, 10);
                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "desi_output").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmployeesByDesignation(int desiId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLYOEES_BY_DESIGNATION_DEPARTMENT");
                if (desiId > 0)
                {
                    db.AddInParameter(dbCommand, "desiId", DbType.Int32, desiId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetProfessions(int? id)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Profession_select_all_info");
                if (id > 0)
                {
                    db.AddInParameter(dbCommand, "Id", DbType.Int32, id);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetActiveDesignations(int? desiId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ACTIVE_DESIGNATIONS");

                if (desiId > 0)
                {
                    db.AddInParameter(dbCommand, "desiId", DbType.Int32, desiId);
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

        #region Employee Rights
        public static DataSet GetResourcesForDesignationRights(int desiId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_RESOURCES_FOR_DESIGNATION_RIGHTS");

                if (desiId > 0)
                {
                    db.AddInParameter(dbCommand, "desiId", DbType.Int32, desiId);
                }

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string UpdateDesignationRights(DataTable dt)
        {
            try
            {
                string inserts = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_DESIGNATION_RIGHTS_UPDATE"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        inserts = "Success";
                    }
                }
                return inserts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}