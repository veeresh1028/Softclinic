using BusinessEntities.Appointment;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.PriorRequests;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace DataAccessLayer.PriorRequests
{
    public class PriorRequest
    {
        public static DataTable SearchPriorAppointments(PriorAppointmentSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Search_PriorAppointments");

                if (!string.IsNullOrEmpty(filters.branch_ids))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.branch_ids);
                }

                if (!string.IsNullOrEmpty(filters.dept_ids))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.dept_ids);
                }

                if (!string.IsNullOrEmpty(filters.doc_ids))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.doc_ids);
                }

                if (!string.IsNullOrEmpty(filters.nats_ids))
                {
                    db.AddInParameter(dbCommand, "select_nat", DbType.String, filters.nats_ids);
                }

                if (!string.IsNullOrEmpty(filters.types))
                {
                    string app_type = string.Join(",", filters.types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, app_type);
                }

                if (!string.IsNullOrEmpty(filters.status))
                {
                    string app_status = string.Join(",", filters.status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_status", DbType.String, app_status);
                }

                if (filters.patient > 0)
                {
                    db.AddInParameter(dbCommand, "select_patient", DbType.Int32, filters.patient);
                }

                if (!string.IsNullOrEmpty(filters.ins_tpa))
                {
                    db.AddInParameter(dbCommand, "select_ins_tpa", DbType.String, filters.ins_tpa);
                }

                if (!string.IsNullOrEmpty(filters.ins_scheme))
                {
                    db.AddInParameter(dbCommand, "select_ins_scheme", DbType.String, filters.ins_scheme);
                }

                if (!string.IsNullOrEmpty(filters.ins_payer))
                {
                    db.AddInParameter(dbCommand, "select_ins_payers", DbType.String, filters.ins_payer);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Appointments JqueryDatatable Miscellaneous Actions
        public static DataSet GetProceduresAlert(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PRIOR_PROCEDURES");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string DeletePriorRequest(int appId, int app_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PriorRequest_Delete");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                    db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app_madeby);
                }

                int result = db.ExecuteNonQuery(dbCommand);

                string isDeleted = "";

                if (result > 0)
                {
                    isDeleted = "Success";
                }
                else
                {
                    isDeleted = "Error";
                }

                return isDeleted;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string ChangeStatusPriorRequest(int appId, string app_AuthStatus, int app_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PriorRequest_Status");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                    db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app_madeby);
                    db.AddInParameter(dbCommand, "app_AuthStatus", DbType.String, app_AuthStatus);
                }
                int result = db.ExecuteNonQuery(dbCommand);

                string isUpdated = "";
                if (result > 0)
                {
                    isUpdated = "Success";
                }
                else
                {
                    isUpdated = "Error";
                }

                return isUpdated;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet GetByID(int emp_branch, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetEmployeeSetupDetails");
                if (emp_branch > 0)
                {
                    db.AddInParameter(dbCommand, "emp_branch", DbType.Int32, emp_branch);
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int IS_ALREADY_INSERTED_IN_TABLE(string XMLFile)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_IsAlreadyInsertedInTable");
                db.AddInParameter(dbCommand, "XMLFile", DbType.String, XMLFile);
                db.AddOutParameter(dbCommand, "IsInserted", DbType.Int32, 1);
                int val = db.ExecuteNonQuery(dbCommand);

                int _output = Convert.ToInt32(db.GetParameterValue(dbCommand, "IsInserted"));
                return _output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int PRIOR_AUTH_XML_Insert(string filePath, string extractedPath, string s_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PriorAuthXMLInsert");
                if (filePath != "")
                {
                    db.AddInParameter(dbCommand, "filePath", DbType.String, filePath);
                    db.AddInParameter(dbCommand, "extractedPath", DbType.String, extractedPath);
                    db.AddInParameter(dbCommand, "s_status", DbType.String, s_status);
                }
                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UPDATE_INS_ELIGIBILITY_DATA_IN_APPOINTMENT(string file_name, int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("Sp_Update_Ins_Eligibility_Data_In_Appointment");
                if (file_name != "")
                {
                    db.AddInParameter(dbCommand, "pxd_xmlfile", DbType.String, file_name);
                }
                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int PRIOR_AUTH_XML_Details_Insert(PriorAuthXMLDetails px, int pxda_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_PriorAuthXMLDetailsInsert");
                db.AddInParameter(dbCommand, "pxd_SenderID", DbType.String, px.pxd_SenderID);
                db.AddInParameter(dbCommand, "pxd_ReceiverID", DbType.String, px.pxd_ReceiverID);
                db.AddInParameter(dbCommand, "pxd_TransactionDate", DbType.String, px.pxd_TransactionDate);
                db.AddInParameter(dbCommand, "pxd_Result", DbType.String, px.pxd_Result);
                db.AddInParameter(dbCommand, "pxd_ID", DbType.String, px.pxd_ID);
                db.AddInParameter(dbCommand, "pxd_IDPayer", DbType.String, px.pxd_IDPayer);
                db.AddInParameter(dbCommand, "pxd_DenialCode", DbType.String, px.pxd_DenialCode);
                db.AddInParameter(dbCommand, "pxd_Start", DbType.String, px.pxd_Start);
                db.AddInParameter(dbCommand, "pxd_End", DbType.String, px.pxd_End);
                db.AddInParameter(dbCommand, "pxd_Comments", DbType.String, px.pxd_Comments);
                db.AddInParameter(dbCommand, "pxd_ActID", DbType.String, px.pxd_ActID);
                db.AddInParameter(dbCommand, "pxd_Atype", DbType.String, px.pxd_Atype);
                db.AddInParameter(dbCommand, "pxd_ACode", DbType.String, px.pxd_ACode);
                db.AddInParameter(dbCommand, "pxd_AQty", DbType.String, px.pxd_AQty);
                db.AddInParameter(dbCommand, "pxd_Net", DbType.String, px.pxd_Net);
                db.AddInParameter(dbCommand, "pxd_Share", DbType.String, px.pxd_Share);
                db.AddInParameter(dbCommand, "pxd_Apay", DbType.String, px.pxd_Apay);
                db.AddInParameter(dbCommand, "pxd_xmlfile", DbType.String, px.pxd_xmlfile);
                db.AddInParameter(dbCommand, "pxda_madeby", DbType.Int32, pxda_madeby);
                int result = db.ExecuteNonQuery(dbCommand);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPriorReqDownloadList(PriorAppointmentSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Prior_Auth_XML_select_all_info");

                if (!string.IsNullOrEmpty(filters.branch_ids))
                {
                    db.AddInParameter(dbCommand, "s_app_branch", DbType.String, filters.branch_ids);
                }

                db.AddInParameter(dbCommand, "from_date", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "to_date", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetBranchesForPriorReq()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Branches_PermitNo");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public static int PRIOR_AUTH_XML_Insert_Single(BusinessEntities.PriorRequests.PriorAuthXML xml)
        //{
        //    try
        //    {
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();
        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_PriorAuthXMLFileInsert");

        //        db.AddInParameter(dbCommand, "XMLData", DbType.String, xml.XMLData);
        //        db.AddInParameter(dbCommand, "XMLFile", DbType.String, xml.XMLFile);
        //        db.AddInParameter(dbCommand, "XML_type", DbType.String, xml.XML_type);
        //        db.AddOutParameter(dbCommand, "out", DbType.Int32, 100);

        //        int query = db.ExecuteNonQuery(dbCommand);

        //        return query;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        public static int PRIOR_AUTH_XML_BulkInsert(DataTable dt)
        {
            try
            {
                int inserts = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_PriorAuthXMLInsert"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);

                        cmd.Parameters.Add("@out", SqlDbType.VarChar, 1000);
                        cmd.Parameters["@out"].Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        inserts = Convert.ToInt32(cmd.Parameters["@out"].Value);
                    }
                }
                return inserts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int PRIOR_AUTH_XML_Details_BulkInsert(DataTable dt, int pxda_madeby)
        {
            try
            {
                int inserts = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_PriorAuthXMLDetailsInsert"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);
                        cmd.Parameters.AddWithValue("@pxda_madeby", pxda_madeby);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        inserts = 1;
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
