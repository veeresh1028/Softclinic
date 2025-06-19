using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.EMR;
using System.Data.SqlClient;

namespace DataAccessLayer.EMR
{
    public class Packages
    {
        public static DataTable GetAllTodaySession(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RUNNING_PACKAGES_TODAY_SESSIONS_all_info");
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

        public static DataTable GetAllPreTodaySession(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RUNNING_PACKAGES_TODAY_SESSIONS_History");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                    db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetAllOnFlyPackages(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Onfly_Packages_All_Info");
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
        public static DataTable GetPreOnFlyPackages(int appId, int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Onfly_Packages_History");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                    db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region OnFly Packages CRUD Operations
        public static bool AddSession(int rpsId, int appId, int madeby )
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RUNNING_PACKAGE_SESSIONS_insert");


                db.AddInParameter(dbCommand, "rps_ccdtId", DbType.Int32, rpsId);

                db.AddInParameter(dbCommand, "rps_appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "rps_noses", DbType.Int32, "1");
                db.AddInParameter(dbCommand, "rps_madeby", DbType.String, madeby);

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

        public static int UpdateStatusRunningPackage(int Id, string status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RUNNING_PACKAGE_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "ccdtId", DbType.Int32, Id);
                db.AddInParameter(dbCommand, "ccdt_status", DbType.String, status);
                db.AddOutParameter(dbCommand, "ccdt_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ccdt_output").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int RevertRunningPackage(int Id, string status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RUNNING_PACKAGE_SESSIONS2_DELETE");

                db.AddInParameter(dbCommand, "ccdtId", DbType.Int32, Id);
                db.ExecuteNonQuery(dbCommand);

                return db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion OnFly Packages CRUD Operations

        #region Patient packages  CRUD Operations
        //public static bool InsertUpdatePatientPackageOrder(PatientPackage data, DataTable dt)
        //{
        //    try
        //    {
        //        int inserts = 0;
        //        int poId_output = 0;
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();
        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_ORDER_insert");

        //        if (data.poId > 0)
        //        {
        //            db.AddInParameter(dbCommand, "poId", DbType.Int32, data.poId);
        //        }
        //        if (data.po_patient > 0)
        //        {
        //            db.AddInParameter(dbCommand, "po_patient", DbType.Int32, data.po_patient);
        //        }
        //        db.AddInParameter(dbCommand, "app_ins", DbType.Int32, data.app_ins);
        //        db.AddInParameter(dbCommand, "po_services", DbType.String, data.po_services);
        //        db.AddInParameter(dbCommand, "po_package", DbType.Int32, data.po_package);
        //        db.AddInParameter(dbCommand, "po_branch", DbType.Int32, data.po_branch);
        //        db.AddInParameter(dbCommand, "po_notes", DbType.String, data.po_notes);
        //        db.AddInParameter(dbCommand, "po_date", DbType.DateTime, data.po_date);
        //        db.AddInParameter(dbCommand, "po_exp_date", DbType.DateTime, data.po_exp_date);
        //        db.AddInParameter(dbCommand, "po_madeby", DbType.String, data.po_madeby);
        //        db.AddOutParameter(dbCommand, "poId", DbType.Int32, 100);

        //        int val = db.ExecuteNonQuery(dbCommand);

        //        poId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "poId").ToString());

        //        if (poId_output > 0)
        //        {
        //            SqlConnection con = new SqlConnection(db.ConnectionString);

        //            using (con)
        //            {
        //                using (SqlCommand cmd = new SqlCommand("SP_BulkInsert_PackageService"))
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Connection = con;
        //                    cmd.Parameters.AddWithValue("@tblBulk", dt);
        //                    cmd.Parameters.AddWithValue("@poId", poId_output);
        //                    cmd.Parameters.AddWithValue("@madeby", data.po_madeby);
        //                    con.Open();
        //                    cmd.ExecuteNonQuery();
        //                    con.Close();
        //                    inserts = 1;
        //                }
        //            }

        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static bool InsertUpdatePatientPackageOrder(PatientPackage data, DataTable dt)
        {
            try
            {
                int inserts = 0;
                int poId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_ORDER_insert");

                if (data.poId > 0)
                {
                    db.AddInParameter(dbCommand, "poId", DbType.Int32, data.poId);
                }
                if (data.po_patient > 0)
                {
                    db.AddInParameter(dbCommand, "po_patient", DbType.Int32, data.po_patient);
                }
                db.AddInParameter(dbCommand, "app_ins", DbType.Int32, data.app_ins);
                db.AddInParameter(dbCommand, "po_refno", DbType.String, data.po_refno);
                db.AddInParameter(dbCommand, "po_services", DbType.String, data.po_services);
                db.AddInParameter(dbCommand, "po_package", DbType.Int32, data.po_package);
                db.AddInParameter(dbCommand, "po_branch", DbType.Int32, data.po_branch);
                db.AddInParameter(dbCommand, "po_notes", DbType.String, data.po_notes);
                db.AddInParameter(dbCommand, "po_date", DbType.DateTime, data.po_date);
                db.AddInParameter(dbCommand, "po_exp_date", DbType.DateTime, data.po_exp_date);
                db.AddInParameter(dbCommand, "po_madeby", DbType.String, data.po_madeby);
                db.AddOutParameter(dbCommand, "poId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                poId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "poId").ToString());

                if (poId_output > 0)
                {
                    //SqlConnection con = new SqlConnection(db.ConnectionString);

                    //using (con)
                    //{
                    //    using (SqlCommand cmd = new SqlCommand("SP_BulkInsert_PackageService"))
                    //    {
                    //        cmd.CommandType = CommandType.StoredProcedure;
                    //        cmd.Connection = con;
                    //        cmd.Parameters.AddWithValue("@tblBulk", dt);
                    //        cmd.Parameters.AddWithValue("@poId", poId_output);
                    //        cmd.Parameters.AddWithValue("@madeby", data.po_madeby);
                    //        con.Open();
                    //        cmd.ExecuteNonQuery();
                    //        con.Close();
                    //        inserts = 1;
                    //    }
                    //}

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
        public static bool UpdatePatientPackageOrder(PatientPackage data, DataTable dt)
        {
            try
            {
                int inserts = 0;
                int poId_output = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_ORDER_Update");


                db.AddInParameter(dbCommand, "poId", DbType.Int32, data.poId);

                db.AddInParameter(dbCommand, "po_patient", DbType.Int32, data.po_patient);
                db.AddInParameter(dbCommand, "po_services", DbType.String, data.po_services);
                db.AddInParameter(dbCommand, "po_package", DbType.Int32, data.po_package);
                db.AddInParameter(dbCommand, "po_branch", DbType.Int32, data.po_branch);
                db.AddInParameter(dbCommand, "po_notes", DbType.String, data.po_notes);
                db.AddInParameter(dbCommand, "po_date", DbType.DateTime, data.po_date);
                db.AddInParameter(dbCommand, "po_exp_date", DbType.DateTime, data.po_exp_date);
                db.AddInParameter(dbCommand, "po_madeby", DbType.String, data.po_madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                poId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "poId").ToString());

                if (data.poId > 0)
                {
                    SqlConnection con = new SqlConnection(db.ConnectionString);

                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_BulkInsert_PackageService"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.AddWithValue("@poId", poId_output);
                            cmd.Parameters.AddWithValue("@madeby", data.po_madeby);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            inserts = 1;
                        }
                    }

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
        public static int UpdateStatusPackageOrder(int Id, string status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Package_Order_Update_Status");

                db.AddInParameter(dbCommand, "poId", DbType.Int32, Id);
                db.AddInParameter(dbCommand, "po_status", DbType.String, status);
                db.AddOutParameter(dbCommand, "po_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "po_output").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string AutoCreatepackageRefNo(int branch)
        {
            try
            {
                string po_refno = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AutoCreatepackageRefNo");
                db.AddInParameter(dbCommand, "branch", DbType.Int32, branch);
                db.AddOutParameter(dbCommand, "po_rno", DbType.String, 25);

                db.ExecuteScalar(dbCommand);

                po_refno = db.GetParameterValue(dbCommand, "po_rno").ToString();
                return po_refno;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}
