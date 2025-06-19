using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Masters;
using System.Data.SqlClient;
using BusinessEntities.Accounts.Accounting;

namespace DataAccessLayer.Masters
{
    public class Employees
    {
        #region Employees Master (Page Load & Search)
        public static DataTable SearchEmployees(EmployeesSearch filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLOYEES");

                if (filter.empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.String, filter.empId);
                }

                if (!string.IsNullOrEmpty(filter.branch_ids))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filter.branch_ids);
                }

                if (!string.IsNullOrEmpty(filter.dept_ids))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filter.dept_ids);
                }

                if (!string.IsNullOrEmpty(filter.desig_ids))
                {
                    db.AddInParameter(dbCommand, "select_desig", DbType.String, filter.desig_ids);
                }

                if (!string.IsNullOrEmpty(filter.nats_ids))
                {
                    db.AddInParameter(dbCommand, "select_nat", DbType.String, filter.nats_ids);
                }

                if (!string.IsNullOrEmpty(filter.select_status))
                {
                    string select_status = string.Join(",", filter.select_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_status", DbType.String, select_status);
                }

                if (!string.IsNullOrEmpty(filter.select_gender))
                {
                    string select_gender = string.Join(",", filter.select_gender.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_gender", DbType.String, select_gender);
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

        #region Employees Advanced Filters
        public static DataTable GetDepartmentEmployees(int? deptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DEPARTMENTS_EMPLOYEES");

                if (deptId > 0)
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.Int32, deptId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetDesignationsEmployees(int? desiId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DESIGNATIONS_EMPLOYEES");

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

        public static DataTable GetSpeciality(string type,string query,string category)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Malaffi_Nabidh_Riyathi_Codesets");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "category", DbType.String, category);
                db.AddInParameter(dbCommand, "type", DbType.String, type);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetSetupinfo(int setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Setupinfo");

                db.AddInParameter(dbCommand, "setId", DbType.Int32, setId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DataTable GetDHASpeciality(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DHA_SPECIALTY_select_all_info");


                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Employee CRUD Operations
        public static DataTable GetEmployee(int? empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPLOYEES_SELECT_INFO");

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetUserCount()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLOYEE_COUNT");

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool InsertEmployee(BusinessEntities.Masters.Employees data, string saltpass)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPLOYEE_INSERT");

                db.AddInParameter(dbCommand, "emp_login", DbType.String, data.emp_login);
                db.AddInParameter(dbCommand, "emp_pass", DbType.String, data.hashpass);
                db.AddInParameter(dbCommand, "emp_name", DbType.String, data.emp_name);
                db.AddInParameter(dbCommand, "emp_gender", DbType.String, data.emp_gender);
                db.AddInParameter(dbCommand, "emp_tel", DbType.String, data.emp_tel);
                db.AddInParameter(dbCommand, "emp_mob", DbType.String, data.emp_mob);
                db.AddInParameter(dbCommand, "emp_fax", DbType.String, data.emp_fax);
                db.AddInParameter(dbCommand, "emp_email", DbType.String, data.emp_email);
                db.AddInParameter(dbCommand, "emp_address", DbType.String, data.emp_address);
                db.AddInParameter(dbCommand, "emp_license", DbType.String, data.emp_license);
                db.AddInParameter(dbCommand, "emp_photo", DbType.String, data.emp_photo);
                db.AddInParameter(dbCommand, "emp_teeth", DbType.String, data.emp_teeth);
                db.AddInParameter(dbCommand, "emp_work_branch", DbType.String, data.emp_work_branch);
                db.AddInParameter(dbCommand, "emp_color", DbType.String, data.emp_color);
                db.AddInParameter(dbCommand, "emp_account", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_account1", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_account2", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_account3", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_sign", DbType.String, data.emp_sign);
                db.AddInParameter(dbCommand, "emp_emid", DbType.String, data.emp_emid);
                db.AddInParameter(dbCommand, "emp_stamp", DbType.String, data.emp_stamp);
                db.AddInParameter(dbCommand, "emp_dept", DbType.Int32, data.emp_dept);
                db.AddInParameter(dbCommand, "emp_desig", DbType.Int32, data.emp_desig);
                db.AddInParameter(dbCommand, "emp_nat", DbType.Int32, data.emp_nat);
                db.AddInParameter(dbCommand, "emp_branch", DbType.Int32, data.emp_branch);
                db.AddInParameter(dbCommand, "emp_rank", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "emp_comm", DbType.Decimal, 0);
                db.AddInParameter(dbCommand, "emp_col", DbType.Decimal, 0);
                db.AddInParameter(dbCommand, "emp_consultation_commi", DbType.Decimal, data.emp_consultation_commi);
                db.AddInParameter(dbCommand, "emp_procedure_commi", DbType.Decimal, data.emp_procedure_commi);
                db.AddInParameter(dbCommand, "emp_lab_commi", DbType.Decimal, data.emp_lab_commi);
                db.AddInParameter(dbCommand, "emp_rad_commi", DbType.Decimal, data.emp_rad_commi);
                db.AddInParameter(dbCommand, "emp_pha_commi", DbType.Decimal, data.emp_pha_commi);
                db.AddInParameter(dbCommand, "emp_met_commi", DbType.Decimal, data.emp_met_commi);
                db.AddInParameter(dbCommand, "emp_disc_allowed", DbType.Decimal, data.emp_disc_allowed);
                db.AddInParameter(dbCommand, "emp_speciality", DbType.String, data.emp_speciality);
                db.AddInParameter(dbCommand, "emp_dha_login", DbType.String, data.emp_dha_login);
                db.AddInParameter(dbCommand, "emp_dha_pass", DbType.String, data.emp_dha_pass);
                db.AddInParameter(dbCommand, "emp_lname", DbType.String, data.emp_lname);
                db.AddInParameter(dbCommand, "emp_whatsappId", DbType.String, data.emp_whatsappId);
                db.AddInParameter(dbCommand, "emp_whatsappToken", DbType.String, data.emp_whatsappToken);
                db.AddInParameter(dbCommand, "emp_dha_speciality", DbType.String, data.emp_dha_speciality);
                db.AddInParameter(dbCommand, "emp_madeby", DbType.Int32, data.emp_madeby);
                db.AddInParameter(dbCommand, "emp_scheduler", DbType.Int32, data.emp_scheduler);
                db.AddInParameter(dbCommand, "el_key1", DbType.String, data.hashpass);
                db.AddInParameter(dbCommand, "el_key2", DbType.String, saltpass);
                db.AddInParameter(dbCommand, "emp_moh_login", DbType.String, data.emp_moh_login);
                db.AddInParameter(dbCommand, "emp_moh_pass", DbType.String, data.emp_moh_pass);
                db.AddInParameter(dbCommand, "emp_pwd_validity", DbType.String, data.emp_pwd_validity);
                db.AddInParameter(dbCommand, "emp_flag", DbType.String, data.emp_flag);
                db.AddInParameter(dbCommand, "emp_outside_access", DbType.String, data.emp_outside_access);
                db.AddOutParameter(dbCommand, "empId", DbType.Int32, 100);

                int result = db.ExecuteNonQuery(dbCommand);

                int empId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "empId").ToString());

                if (empId_output > 0)
                {
                    result = InsertEmployeeRosters(empId_output, data.emp_work_branch);
                }

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
                throw;
            }
        }

        public static bool UpdateEmployee(BusinessEntities.Masters.Employees data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPLOYEES_UPDATE");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, data.empId);
                db.AddInParameter(dbCommand, "emp_login", DbType.String, data.emp_login);
                db.AddInParameter(dbCommand, "emp_name", DbType.String, data.emp_name);
                db.AddInParameter(dbCommand, "emp_lname", DbType.String, data.emp_lname);
                db.AddInParameter(dbCommand, "emp_gender", DbType.String, data.emp_gender);
                db.AddInParameter(dbCommand, "emp_tel", DbType.String, data.emp_tel);
                db.AddInParameter(dbCommand, "emp_mob", DbType.String, data.emp_mob);
                db.AddInParameter(dbCommand, "emp_fax", DbType.String, data.emp_fax);
                db.AddInParameter(dbCommand, "emp_email", DbType.String, data.emp_email);
                db.AddInParameter(dbCommand, "emp_address", DbType.String, data.emp_address);
                db.AddInParameter(dbCommand, "emp_license", DbType.String, data.emp_license);
                db.AddInParameter(dbCommand, "emp_photo", DbType.String, data.emp_photo);
                db.AddInParameter(dbCommand, "emp_teeth", DbType.String, data.emp_teeth);
                db.AddInParameter(dbCommand, "emp_work_branch", DbType.String, data.emp_work_branch);
                db.AddInParameter(dbCommand, "emp_color", DbType.String, data.emp_color);
                db.AddInParameter(dbCommand, "emp_account", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_account1", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_account2", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_account3", DbType.String, "");
                db.AddInParameter(dbCommand, "emp_sign", DbType.String, data.emp_sign);
                db.AddInParameter(dbCommand, "emp_emid", DbType.String, data.emp_emid);
                db.AddInParameter(dbCommand, "emp_stamp", DbType.String, data.emp_stamp);
                db.AddInParameter(dbCommand, "emp_dept", DbType.Int32, data.emp_dept);
                db.AddInParameter(dbCommand, "emp_desig", DbType.Int32, data.emp_desig);
                db.AddInParameter(dbCommand, "emp_nat", DbType.Int32, data.emp_nat);
                db.AddInParameter(dbCommand, "emp_branch", DbType.Int32, data.emp_branch);
                db.AddInParameter(dbCommand, "emp_rank", DbType.Int32, 0);
                db.AddInParameter(dbCommand, "emp_comm", DbType.Decimal, 0);
                db.AddInParameter(dbCommand, "emp_col", DbType.Decimal, 0);
                db.AddInParameter(dbCommand, "emp_consultation_commi", DbType.Decimal, data.emp_consultation_commi);
                db.AddInParameter(dbCommand, "emp_procedure_commi", DbType.Decimal, data.emp_procedure_commi);
                db.AddInParameter(dbCommand, "emp_lab_commi", DbType.Decimal, data.emp_lab_commi);
                db.AddInParameter(dbCommand, "emp_rad_commi", DbType.Decimal, data.emp_rad_commi);
                db.AddInParameter(dbCommand, "emp_pha_commi", DbType.Decimal, data.emp_pha_commi);
                db.AddInParameter(dbCommand, "emp_met_commi", DbType.Decimal, data.emp_met_commi);
                db.AddInParameter(dbCommand, "emp_disc_allowed", DbType.Decimal, data.emp_disc_allowed);
                db.AddInParameter(dbCommand, "emp_speciality", DbType.String, data.emp_speciality);
                db.AddInParameter(dbCommand, "emp_dha_login", DbType.String, data.emp_dha_login);
                db.AddInParameter(dbCommand, "emp_dha_pass", DbType.String, data.emp_dha_pass);
                db.AddInParameter(dbCommand, "emp_whatsappId", DbType.String, data.emp_whatsappId);
                db.AddInParameter(dbCommand, "emp_whatsappToken", DbType.String, data.emp_whatsappToken);
                db.AddInParameter(dbCommand, "emp_dha_speciality", DbType.String, data.emp_dha_speciality);
                db.AddInParameter(dbCommand, "emp_scheduler", DbType.String, data.emp_scheduler);
                db.AddInParameter(dbCommand, "emp_moh_login", DbType.String, data.emp_moh_login);
                db.AddInParameter(dbCommand, "emp_moh_pass", DbType.String, data.emp_moh_pass);
                db.AddInParameter(dbCommand, "emp_modifyby", DbType.Int32, data.emp_modifyby);
                db.AddInParameter(dbCommand, "emp_pwd_validity", DbType.String, data.emp_pwd_validity);
                db.AddInParameter(dbCommand, "emp_outside_access", DbType.String, data.emp_outside_access);
                db.AddInParameter(dbCommand, "emp_flag", DbType.String, data.emp_flag);

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
                throw;
            }
        }

        public static int UpdateEmployeesStatus(int empId, string emp_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPLOYEES_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "emp_status", DbType.String, emp_status);
                db.AddOutParameter(dbCommand, "emp_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "emp_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int InsertEmployeeRosters(int empId, string emp_branchs)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DataTable dt = new DataTable();
                dt.Columns.Add("er_employee", typeof(int));
                dt.Columns.Add("er_branch", typeof(int));
                dt.Columns.Add("er_day", typeof(string));
                dt.Columns.Add("er_ftime", typeof(int));
                dt.Columns.Add("er_ttime", typeof(int));
                dt.Columns.Add("er_type", typeof(string));
                dt.Columns.Add("er_fdate", typeof(DateTime));
                dt.Columns.Add("er_tdate", typeof(DateTime));
                dt.Columns.Add("er_range", typeof(string));
                dt.Columns.Add("er_round", typeof(string));

                string[] arrb = emp_branchs.Split(',');
                DayOfWeek[] days = { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };

                foreach (string branch in arrb)
                {
                    // Get Time Slots for Work Branch(es)
                    int result = 0;
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Time_Slots_Roster");
                    db.AddInParameter(dbCommand, "emp_branch", DbType.String, branch);

                    db.AddOutParameter(dbCommand, "ftime", DbType.Int32, 100);
                    db.AddOutParameter(dbCommand, "ttime", DbType.Int32, 100);

                    result = db.ExecuteNonQuery(dbCommand);

                    int ftime_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ftime").ToString());
                    int ttime_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "ttime").ToString());

                    // Datarows for days of the week
                    foreach (var day in days)
                    {
                        DataRow dr = dt.NewRow();
                        dr["er_employee"] = empId;
                        dr["er_branch"] = branch;
                        dr["er_day"] = day;
                        dr["er_ftime"] = ftime_output;
                        dr["er_ttime"] = ttime_output;
                        dr["er_type"] = "Normal";
                        dr["er_fdate"] = DateTime.Now.ToString("yyyy-MM-dd");
                        dr["er_tdate"] = "2099/01/01";
                        dr["er_range"] = "Unlimited";
                        dr["er_round"] = "No";

                        dt.Rows.Add(dr);
                    }
                }

                int inserts = 0;

                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EMPLOYEES_ROASTER_INSERT"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);
                        cmd.Parameters.Add("@out", SqlDbType.VarChar, 1000);
                        cmd.Parameters["@out"].Direction = ParameterDirection.Output;

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
                throw;
            }
        }

        public static DataTable GetEmployeeLogs(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLYOEE_AUDIT_LOG");

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empaId", DbType.Int32, empId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetEmployeeLoginById(int? empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_LoginName");

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
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

        #region Doctor Information
        public static DataTable DoctorAccountSummary(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_DOCTOR_ACCOUNT_SUMMARY");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable DoctorAppStatusSummary(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DOCTOR_APP_STATUS_SUMMARY");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataSet DoctorInfoSummary(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DOCTOR_INFO_SUMMARY");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Employee Rosters
        public static DataTable GetRosters(RosterSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_SEARCH_EMPLOYEE_ROSTERS");

                if (!string.IsNullOrEmpty(search.er_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, search.er_branch);
                }

                if (!string.IsNullOrEmpty(search.er_day))
                {
                    string select_days = string.Join(",", search.er_day.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_day", DbType.String, select_days);
                }

                if (!string.IsNullOrEmpty(search.er_type))
                {
                    string select_types = string.Join(",", search.er_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, select_types);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable EmployeeRosters(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLOYEE_ROASTERS");

                if (empId > 0)
                {
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetTimeSlots(int app_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_TIME_SLOTS_BY_BRANCH");

                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app_branch);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string InsertRoster(DataTable dt)
        {
            try
            {
                string inserts = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EMPLOYEES_ROASTER_INSERT"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);

                        cmd.Parameters.Add("@out", SqlDbType.VarChar, 1000);
                        cmd.Parameters["@out"].Direction = ParameterDirection.Output;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        inserts = (cmd.Parameters["@out"].Value).ToString();
                    }
                }
                return inserts;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetEmployeeRosterById(int erId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLOYEE_ROSTER_BY_ID");

                db.AddInParameter(dbCommand, "erId", DbType.Int32, erId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static string UpdateRoster(EmployeeRoasters roster)
        {
            try
            {
                string inserts = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPLOYEES_ROASTER_UPDATE");

                db.AddInParameter(dbCommand, "erId", DbType.Int32, roster.erId);
                db.AddInParameter(dbCommand, "er_branch", DbType.Int32, roster.er_branch);
                db.AddInParameter(dbCommand, "er_ftime", DbType.Int32, roster.er_ftime);
                db.AddInParameter(dbCommand, "er_ttime", DbType.Int32, roster.er_ttime);
                db.AddInParameter(dbCommand, "er_employee", DbType.Int32, roster.er_employee);
                db.AddInParameter(dbCommand, "er_day", DbType.String, roster.er_day);
                db.AddInParameter(dbCommand, "er_type", DbType.String, roster.er_type);
                db.AddInParameter(dbCommand, "er_range", DbType.String, roster.er_range);
                db.AddInParameter(dbCommand, "er_round", DbType.String, roster.er_round);
                db.AddInParameter(dbCommand, "er_fdate", DbType.DateTime, roster.er_fdate);
                db.AddInParameter(dbCommand, "er_tdate", DbType.DateTime, roster.er_tdate);

                db.AddOutParameter(dbCommand, "er_output", DbType.String, 200);

                db.ExecuteScalar(dbCommand);

                return db.GetParameterValue(dbCommand, "er_output").ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateEmployeeRosterStatus(int erId, string er_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMPLOYEE_ROSTER_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "erId", DbType.Int32, erId);
                db.AddInParameter(dbCommand, "er_status", DbType.String, er_status);
                db.AddOutParameter(dbCommand, "er_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "er_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Employee Rights
        public static DataSet GetResourcesForRights(int empId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_RESOURCES_FOR_RIGHTS");

                if (empId > 0)
                {
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

        public static string UpdateRights(DataTable dt)
        {
            try
            {
                string inserts = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EMPLOYEES_RIGHTS_UPDATE"))
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
                throw;
            }
        }
        #endregion

        #region Employee Logged in Time
        public static void EmployeeLoggedInTime(int empId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_EMP_LOGGEDIN_TIME_INSERT");

                db.AddInParameter(dbCommand, "elt_empId", DbType.Int32, empId);
                db.AddInParameter(dbCommand, "elt_type", DbType.String, type);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Chart of Account
        public static DataTable GetEmployeeCOA(EmployeeChartofAccount search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Employee_ChartofAccounts");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.branch);

                db.AddInParameter(dbCommand, "acc_period", DbType.String, search.acc_period);

                db.AddInParameter(dbCommand, "empId", DbType.Int32, search.empId);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateEmployeeCOA(EmployeeAccounts data)
        {
            try
            {
                bool isInserted = false;
                int result = 0;
                string[] acc_category = data.acc_type.Split(',');

                foreach(string _cate in acc_category)
                {
                    if(_cate == "IN1-1")
                    {
                        data.acc_category = "IN1-1";
                        data.acc_type = "Income";
                        data.group_name = "IN1";
                    }
                    else if(_cate == "EX2-6")
                    {
                        data.acc_category = "EX2-6";
                        data.acc_type = "Expenses";
                        data.group_name = "EX2";
                    }
                    else if(_cate == "EX2-5")
                    {
                        data.acc_category = "EX2-5";
                        data.acc_type = "Expenses";
                        data.group_name = "EX2";
                    }
                    
                    DatabaseProviderFactory factory = new DatabaseProviderFactory();
                    Database db = factory.CreateDefault();
                    DbCommand dbCommand = db.GetStoredProcCommand("SP_Employee_COA_Insert");

                    db.AddInParameter(dbCommand, "acc_branch", DbType.Int32, data.branch);
                    db.AddInParameter(dbCommand, "acc_period", DbType.String, data.acc_period);
                    db.AddInParameter(dbCommand, "acc_group", DbType.String, data.group_name);
                    db.AddInParameter(dbCommand, "acc_category", DbType.String, data.acc_category);
                    db.AddInParameter(dbCommand, "acc_parent", DbType.Int32, data.empId);
                    db.AddInParameter(dbCommand, "acc_type", DbType.String, "G");
                    db.AddInParameter(dbCommand, "acc_name", DbType.String, data.account_name);
                    db.AddInParameter(dbCommand, "acc_gtype", DbType.String, data.acc_type);
                    db.AddInParameter(dbCommand, "acc_cbal", DbType.Decimal, 0);
                    db.AddInParameter(dbCommand, "empId", DbType.Int32, data.logId);
                    db.AddOutParameter(dbCommand, "accId_out", DbType.Int32, 0);

                    db.ExecuteNonQuery(dbCommand);

                    result = Convert.ToInt32(db.GetParameterValue(dbCommand, "accId_out").ToString());
                    if (result > 0)
                        isInserted = true;
                    else
                        isInserted = false;
                }

                if (isInserted)
                {
                    return 1;
                }
                else
                {
                    return 0;
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