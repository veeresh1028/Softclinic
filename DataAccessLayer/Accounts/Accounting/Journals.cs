using BusinessEntities.Accounts.Accounting;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Accounts.MaterialManagement;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DataAccessLayer.Accounts.Accounting
{
    public class Journals
    {
        public static string GetReferrenceNo(JournalReferrenceNo data)
        {
            try
            {
                string j_output = string.Empty;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Journal_Getreferrenceno");

                db.AddInParameter(dbCommand, "j_branch", DbType.Int32, data.j_branch);
                db.AddInParameter(dbCommand, "j_acc_period", DbType.String, data.j_acc_period);
                db.AddInParameter(dbCommand, "j_type", DbType.String, data.j_type);

                db.AddOutParameter(dbCommand, "j_code", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                j_output = db.GetParameterValue(dbCommand, "j_code").ToString();

                return j_output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool InsertJournals(JournalWithList data, DataTable dt, out string j_code, string mode)
        {
            int inserts = 0;
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            try
            {
                string POR_code = string.Empty;
                bool return_value = false;

                if (dt.Rows.Count > 0)
                {
                    dt.DefaultView.Sort = "j_mode ASC";

                    SqlConnection con = new SqlConnection(db.ConnectionString);
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("SP_Journal_Posting_Bulk_Insert"))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.AddWithValue("@j_branch", data.journalHeader.j_branch);
                            cmd.Parameters.AddWithValue("@j_type", data.journalHeader.j_type);
                            cmd.Parameters.AddWithValue("@j_acc_period", data.journalHeader.j_acc_period);
                            cmd.Parameters.AddWithValue("@j_date", data.journalHeader.j_date);
                            cmd.Parameters.AddWithValue("@j_madeby", data.journalHeader.j_madeby);
                            cmd.Parameters.AddWithValue("@mode", mode);

                            SqlParameter _output = new SqlParameter("@_outVal", SqlDbType.Int);
                            _output.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(_output);

                            con.Open();
                            cmd.ExecuteNonQuery();

                            inserts = Convert.ToInt32(cmd.Parameters["@_outVal"].Value);

                            con.Close();
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

                j_code = "";

                return return_value;
            }
            catch (Exception)
            {                
                throw;
            }
        }
        public static DataTable GetJournals(JournalSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Journal_Getdetails");

                if (search.jId > 0)
                {
                    db.AddInParameter(dbCommand, "jId", DbType.Int32, search.jId);
                }

                if (!string.IsNullOrEmpty(search.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);
                }
                
                if (!string.IsNullOrEmpty(search.select_account))
                {
                    db.AddInParameter(dbCommand, "select_account", DbType.String, search.select_account);
                }
                
                if (!string.IsNullOrEmpty(search.select_refno))
                {
                    db.AddInParameter(dbCommand, "select_refno", DbType.String, search.select_refno);
                }

                if (!string.IsNullOrEmpty(search.select_period))
                {
                    db.AddInParameter(dbCommand, "select_period", DbType.String, search.select_period);
                }

                if (!string.IsNullOrEmpty(search.select_group))
                {
                    string acc_group = string.Join(",", search.select_group.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_group", DbType.String, acc_group);
                }

                if (!string.IsNullOrEmpty(search.select_category))
                {
                    string acc_category = string.Join(",", search.select_category.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_category", DbType.String, acc_category);
                }
                
                if (!string.IsNullOrEmpty(search.select_types))
                {
                    string _types = string.Join(",", search.select_types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_types", DbType.String, _types);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.AddInParameter(dbCommand, "select_date_from", DbType.DateTime, search.select_date_from);

                db.AddInParameter(dbCommand, "select_date_to", DbType.DateTime, search.select_date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public static bool UpdateJournals(JournalWithList data, DataTable dt, out string j_code, string mode, string deleteIds)
        {
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
                        using (SqlCommand cmd = new SqlCommand("SP_Journal_Posting_Bulk_Update"))
                        {                            
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Connection = con;
                            cmd.Parameters.AddWithValue("@tblBulk", dt);
                            cmd.Parameters.AddWithValue("@j_branch", data.journalHeader.j_branch);
                            cmd.Parameters.AddWithValue("@j_type", data.journalHeader.j_type);
                            cmd.Parameters.AddWithValue("@j_acc_period", data.journalHeader.j_acc_period);
                            cmd.Parameters.AddWithValue("@j_date", data.journalHeader.j_date);
                            cmd.Parameters.AddWithValue("@j_madeby", data.journalHeader.j_madeby);
                            cmd.Parameters.AddWithValue("@j_refno", data.journalHeader.j_refno);

                            if (!string.IsNullOrEmpty(deleteIds))
                            {
                                string _ids = string.Join(",", deleteIds.Split(',').Select(x => string.Format("'{0}'", x)).ToList());                                
                                cmd.Parameters.AddWithValue("@deleteIds", _ids);
                            }

                            
                            cmd.Parameters.AddWithValue("@mode", mode);

                            SqlParameter _output = new SqlParameter("@_outVal", SqlDbType.Int);
                            _output.Direction = ParameterDirection.Output;
                            cmd.Parameters.Add(_output);

                            con.Open();
                            cmd.ExecuteNonQuery();

                            inserts = Convert.ToInt32(cmd.Parameters["@_outVal"].Value);

                            con.Close();
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

                j_code = "";

                return return_value;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int ChangeJournalsStatus(string j_refno, string status, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Journal_Status_Change");
                db.AddInParameter(dbCommand, "j_refno", DbType.String, j_refno);
                db.AddInParameter(dbCommand, "j_status", DbType.String, status);
                db.AddInParameter(dbCommand, "empId", DbType.String, empId);
                db.AddOutParameter(dbCommand, "jId_out", DbType.Int32, 0);
                db.ExecuteNonQuery(dbCommand);

                int data = int.Parse(db.GetParameterValue(dbCommand, "jId_out").ToString());

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public static DataTable GetJournalAuditLogs(string j_refno, int empId)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();

            try
            {
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Journal_Audit_Get_Logs");
                db.AddInParameter(dbCommand, "ja_refno", DbType.String, j_refno);
                db.AddInParameter(dbCommand, "empId", DbType.String, empId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}