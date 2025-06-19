using BusinessEntities.Appointment;
using BusinessEntities.Patient;
using DataAccessLayer.Patient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration.Fluent;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Appointment
{
    public class Appointment
    {
        #region Appointment Scheduler
        public static DataTable GetAppointments(string start, string end, string val = null, int setId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Events");

                db.AddInParameter(dbCommand, "start", DbType.String, start);
                db.AddInParameter(dbCommand, "end", DbType.String, end);

                if (!string.IsNullOrEmpty(val))
                {
                    db.AddInParameter(dbCommand, "empIds", DbType.String, val);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setId", DbType.Int32, setId);
                }
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAppointmentsRoomSchedule(string start, string end, string val = null, int setId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Events_Rooms");

                db.AddInParameter(dbCommand, "start", DbType.String, start);
                db.AddInParameter(dbCommand, "end", DbType.String, end);

                if (!string.IsNullOrEmpty(val))
                {
                    db.AddInParameter(dbCommand, "roomIds", DbType.String, val);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setId", DbType.Int32, setId);
                }
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetTimeSlots(int app_branch, string app_fdate, int app_doctor)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_TimeSlots");
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app_branch);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, DateTime.Parse(app_fdate));

                if (app_doctor > 0)
                {
                    db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app_doctor);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetTimeSlotId(int app_branch, string app_time)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_TimeSlotId");
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app_branch);
                db.AddInParameter(dbCommand, "app_time", DbType.String, app_time);
                db.AddOutParameter(dbCommand, "tId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                int val = Convert.ToInt32(db.GetParameterValue(dbCommand, "tId"));

                return val;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchPatients(int type, string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Search_Patients");
                db.AddInParameter(dbCommand, "search_type", DbType.Int32, type);
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAppointmentStatus()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetAppointmentStatus");
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPackageOrder(int poId = 0, int po_patient = 0, int po_piId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_ORDERS_info");
                db.AddInParameter(dbCommand, "poId", DbType.Int32, poId);
                db.AddInParameter(dbCommand, "po_patient", DbType.Int32, po_patient);
                db.AddInParameter(dbCommand, "po_piId", DbType.Int32, po_piId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPackageService(int poId = 0, int po_patient = 0, int po_piId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PACKAGE_ORDERS_Service_info");
                db.AddInParameter(dbCommand, "poId", DbType.Int32, poId);
                db.AddInParameter(dbCommand, "po_patient", DbType.Int32, po_patient);
                db.AddInParameter(dbCommand, "po_piId", DbType.Int32, po_piId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetFollowupStatus(int piId, int app_doctor, DateTime app_fdate)
        {
            try
            {
                string type = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Followups");
                db.AddInParameter(dbCommand, "piId", DbType.Int32, piId);
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app_doctor);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, app_fdate);
                db.AddOutParameter(dbCommand, "type_output", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                type = db.GetParameterValue(dbCommand, "type_output").ToString();

                return type;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CreateAppointment(BusinessEntities.Appointment.Appointment app, DataTable dt)
        {
            try
            {
                int inserts = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Appointment_Insert");

                db.AddOutParameter(dbCommand, "appId", DbType.Int32, 100);
                db.AddInParameter(dbCommand, "app_room", DbType.Int32, app.app_room);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, app.app_fdate);
                db.AddInParameter(dbCommand, "app_tdate", DbType.DateTime, app.app_tdate);
                db.AddInParameter(dbCommand, "app_ftime", DbType.Int32, app.app_ftime);
                db.AddInParameter(dbCommand, "app_ttime", DbType.Int32, app.app_ttime);
                db.AddInParameter(dbCommand, "app_ins", DbType.Int32, app.app_ins);
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app.app_doctor);
                db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app.app_madeby);
                db.AddInParameter(dbCommand, "app_type", DbType.String, app.app_type);
                db.AddInParameter(dbCommand, "app_status", DbType.String, app.app_status);
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app.app_branch);
                db.AddInParameter(dbCommand, "app_inout", DbType.String, app.app_inout);
                db.AddInParameter(dbCommand, "app_duplicate", DbType.Int32, (app.app_duplicate == 0) ? 1 : app.app_duplicate);
                db.AddInParameter(dbCommand, "app_rappId", DbType.Int32, app.app_rappId);
                db.AddInParameter(dbCommand, "app_emergency", DbType.String, app.app_emergency);
                db.AddInParameter(dbCommand, "app_source", DbType.Int32, app.app_source);
                db.AddInParameter(dbCommand, "app_campaign", DbType.Int32, app.app_compaign);
                db.AddInParameter(dbCommand, "app_status2", DbType.String, app.app_status2);
                db.AddInParameter(dbCommand, "app_eligibility", DbType.String, string.IsNullOrEmpty(app.app_eligibility) ? "" : app.app_eligibility);
                db.AddInParameter(dbCommand, "app_po", DbType.Int32, app.app_package_order);
                db.AddInParameter(dbCommand, "app_Comments", DbType.String, string.IsNullOrEmpty(app.app_comments) ? "" : app.app_comments);
                db.AddInParameter(dbCommand, "app_service", DbType.String, app.app_service);
                db.AddInParameter(dbCommand, "app_category", DbType.String, app.app_category);

                int data = db.ExecuteNonQuery(dbCommand);

                int _appId = Convert.ToInt32(db.GetParameterValue(dbCommand, "appId"));

                if (_appId > 0)
                {
                    if (app.app_package_order > 0)
                    {
                        SqlConnection con = new SqlConnection(db.ConnectionString);

                        using (con)
                        {
                            using (SqlCommand cmd = new SqlCommand("SP_BulkInsert_AppointmentPackage"))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblBulk", dt);
                                cmd.Parameters.AddWithValue("@appId", _appId);
                                cmd.Parameters.AddWithValue("@madeby", app.app_madeby);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                inserts = 1;
                            }

                            using (SqlCommand cmd1 = new SqlCommand("SP_BulkInsert_PatientTreatPackage"))
                            {
                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.Connection = con;
                                cmd1.Parameters.AddWithValue("@tblBulk", dt);
                                cmd1.Parameters.AddWithValue("@appId", _appId);
                                cmd1.Parameters.AddWithValue("@madeby", app.app_madeby);
                                con.Open();
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                inserts = 1;
                            }
                        }

                        return _appId;
                    }
                    else
                    {
                        return _appId;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateAppointments(BusinessEntities.Appointment.Appointment app)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Appointment_update");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, app.appId);
                db.AddInParameter(dbCommand, "app_room", DbType.Int32, app.app_room);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, app.app_fdate);
                db.AddInParameter(dbCommand, "app_tdate", DbType.DateTime, app.app_tdate);
                db.AddInParameter(dbCommand, "app_ftime", DbType.Int32, app.app_ftime);
                db.AddInParameter(dbCommand, "app_ttime", DbType.Int32, app.app_ttime);
                db.AddInParameter(dbCommand, "app_ins", DbType.Int32, app.app_ins);
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app.app_doctor);
                db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app.app_madeby);
                db.AddInParameter(dbCommand, "app_type", DbType.String, app.app_type);
                db.AddInParameter(dbCommand, "app_status", DbType.String, app.app_status);
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app.app_branch);
                db.AddInParameter(dbCommand, "app_inout", DbType.String, app.app_inout);
                db.AddInParameter(dbCommand, "app_duplicate", DbType.Int32, (app.app_duplicate == 0) ? 1 : app.app_duplicate);
                db.AddInParameter(dbCommand, "app_emergency", DbType.String, app.app_emergency);
                db.AddInParameter(dbCommand, "app_source", DbType.Int32, app.app_source);
                db.AddInParameter(dbCommand, "app_campaign", DbType.Int32, app.app_compaign);
                db.AddInParameter(dbCommand, "app_status2", DbType.String, app.app_status2);
                db.AddInParameter(dbCommand, "app_eligibility", DbType.String, app.app_eligibility);
                db.AddInParameter(dbCommand, "app_po", DbType.Int32, app.app_package_order);
                db.AddInParameter(dbCommand, "app_Comments", DbType.String, string.IsNullOrEmpty(app.app_comments) ? "" : app.app_comments);
                db.AddInParameter(dbCommand, "app_service", DbType.String, app.app_service);
                db.AddInParameter(dbCommand, "app_category", DbType.String, app.app_category);

                int data = db.ExecuteNonQuery(dbCommand);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool BlockAppointment(BusinessEntities.Appointment.Appointment app)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Appointment_Block");

                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app.app_doctor);
                db.AddInParameter(dbCommand, "app_ins", DbType.Int32, app.app_ins);
                db.AddInParameter(dbCommand, "app_doc_ftime", DbType.String, app.app_doc_ftime);
                db.AddInParameter(dbCommand, "app_doc_ttime", DbType.String, app.app_doc_ttime);
                db.AddInParameter(dbCommand, "app_fdate", DbType.String, app.app_fdate);
                db.AddInParameter(dbCommand, "app_tdate", DbType.String, app.app_tdate);
                db.AddInParameter(dbCommand, "app_comments", DbType.String, app.app_comments);
                db.AddInParameter(dbCommand, "app_branch", DbType.String, app.app_branch);
                db.AddInParameter(dbCommand, "app_madeby", DbType.String, app.app_madeby);
                int data = db.ExecuteNonQuery(dbCommand);

                if (data > 0)
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
        public static int RebookAppointments(BusinessEntities.Appointment.ReBookAppointment app)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Rebook");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, app.appId);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, app.app_fdate);
                db.AddInParameter(dbCommand, "app_tdate", DbType.DateTime, app.app_tdate);
                db.AddInParameter(dbCommand, "app_doc_ftime", DbType.String, app.app_doc_ftime);
                db.AddInParameter(dbCommand, "app_doc_ttime", DbType.String, app.app_doc_ttime);
                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app.app_branch);
                db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app.app_madeby);

                if ((app.app_doctor != null) && app.app_doctor > 0)
                {
                    db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app.app_doctor);
                }

                if ((app.app_room != null) && app.app_room > 0)
                {
                    db.AddInParameter(dbCommand, "app_room", DbType.Int32, app.app_room);
                }

                int data = db.ExecuteNonQuery(dbCommand);
                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetAllDepartments(int deptId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_Departments");

                if (deptId > 0)
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.Int32, deptId);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int CopyCloneAppointments(BusinessEntities.Appointment.ReBookAppointment app)
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database db = factory.CreateDefault();
            DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Clone");

            db.AddInParameter(dbCommand, "appId", DbType.Int32, app.appId);
            db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, app.app_fdate);
            db.AddInParameter(dbCommand, "app_tdate", DbType.DateTime, app.app_tdate);
            db.AddInParameter(dbCommand, "app_doc_ftime", DbType.String, app.app_doc_ftime);
            db.AddInParameter(dbCommand, "app_doc_ttime", DbType.String, app.app_doc_ttime);
            db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app.app_branch);
            db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app.app_madeby);

            if ((app.app_doctor != 0) && app.app_doctor > 0)
            {
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app.app_doctor);
            }

            if ((app.app_room != 0) && app.app_room > 0)
            {
                db.AddInParameter(dbCommand, "app_room", DbType.Int32, app.app_room);
            }

            db.AddOutParameter(dbCommand, "appId_out", DbType.Int32, 100);
            int data = db.ExecuteNonQuery(dbCommand);


            int val = Convert.ToInt32(db.GetParameterValue(dbCommand, "appId_out"));

            return val;
        }

        public static int DeleteAppointments(int appId, int app_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Delete");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "app_madeby", DbType.Int32, app_madeby);

                int data = db.ExecuteNonQuery(dbCommand);
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetEMIDExpiry(int piId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMID_EXPIRY");

                db.AddInParameter(dbCommand, "piId", DbType.String, piId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Appointments Filters & Search
        public static DataTable GetDoctorsByDepartments(string deptIds, string branchIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetDoctorsByDeptsBranches");

                if (!string.IsNullOrEmpty(deptIds))
                {
                    db.AddInParameter(dbCommand, "deptIds", DbType.String, deptIds);
                }
                if (!string.IsNullOrEmpty(branchIds))
                {
                    db.AddInParameter(dbCommand, "branchIds", DbType.String, branchIds);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetBranchRooms(string room_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetRoomsByBranches");

                if (!string.IsNullOrEmpty(room_branch))
                {
                    db.AddInParameter(dbCommand, "room_branch", DbType.String, room_branch);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetReferrals()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetAppointmentReferrals");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetStatus()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_AppointmentStatus");

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatients(GetPatients patient)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatients");
                db.AddInParameter(dbCommand, "query", DbType.String, patient.query);

                //db.AddInParameter(dbCommand, "from_date", DbType.DateTime, patient.from_date);
                //db.AddInParameter(dbCommand, "to_date", DbType.DateTime, patient.to_date);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPatientsId(GetPatients patient)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientsId");
                db.AddInParameter(dbCommand, "query", DbType.String, patient.query);

                //db.AddInParameter(dbCommand, "from_date", DbType.DateTime, patient.from_date);
                //db.AddInParameter(dbCommand, "to_date", DbType.DateTime, patient.to_date);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsuranceCompanies(SearchQuery ins_comp)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetInsuranceCompanies");

                if (string.IsNullOrEmpty(ins_comp.query))
                {
                    ins_comp.query = string.Empty;
                }

                db.AddInParameter(dbCommand, "query", DbType.String, ins_comp.query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetInsurancePayers(int? icId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSURANCE_PAYERS_SELECT_ALL_INFO");

                if (icId > 0)
                {
                    db.AddInParameter(dbCommand, "ip_ins", DbType.Int32, icId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable SearchAppointments(AppointmentSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Search_Appointments");

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

                if (!string.IsNullOrEmpty(filters.room_ids))
                {
                    db.AddInParameter(dbCommand, "select_room", DbType.String, filters.room_ids);
                }

                if (!string.IsNullOrEmpty(filters.referral_ids))
                {
                    db.AddInParameter(dbCommand, "select_referral", DbType.String, filters.referral_ids);
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetAppointmentByPatId(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("Sp_GetAppointmentByPatient");
                if (patId > 0)
                {
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

        public static DataTable GetInsurancePayersByIcids(string icIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Insurance_PayersByIcId");

                if (!string.IsNullOrEmpty(icIds))
                {
                    db.AddInParameter(dbCommand, "icIds", DbType.String, icIds);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Appointments JqueryDatatable Miscellaneous Actions
        public static DataTable GetEMRPendings(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMR_PENDINGS");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPatientLabel(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_LABEL");
                if (patId > 0)
                {
                    db.AddInParameter(dbCommand, "patId", DbType.String, patId);
                }
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DeleteAppointment(int appId, int app_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_APPOINTMENTS_DELETE");

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
            catch (Exception)
            {
                throw;
            }
        }
        
        public static string UpdateInsuranceType(int appId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Appointment_InsuranceType_Update");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                    db.AddInParameter(dbCommand, "app_category", DbType.String, type);
                }

                int result = db.ExecuteNonQuery(dbCommand);

                string isUpdated = string.Empty;

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
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Recurring Appointments Insert
        public static void SlotAvailiility(int app_branch, int app_doctor, DateTime app_fdate, int app_ftime, int app_ttime, out int isAvail, out int isBooked)
        {
            try
            {
                isAvail = 0;
                isBooked = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CheckSlotAvailability");

                db.AddInParameter(dbCommand, "app_branch", DbType.Int32, app_branch);
                db.AddInParameter(dbCommand, "app_doctor", DbType.Int32, app_doctor);
                db.AddInParameter(dbCommand, "app_ftime", DbType.Int32, app_ftime);
                db.AddInParameter(dbCommand, "app_ttime", DbType.Int32, app_ttime);
                db.AddInParameter(dbCommand, "app_fdate", DbType.DateTime, app_fdate);
                db.AddOutParameter(dbCommand, "isAvail", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "isBooked", DbType.Int32, 100);

                int data = db.ExecuteNonQuery(dbCommand);

                isAvail = Convert.ToInt32(db.GetParameterValue(dbCommand, "isAvail").ToString());
                isBooked = Convert.ToInt32(db.GetParameterValue(dbCommand, "isBooked").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int InsertRecurringAppointments(DataTable dt, DateTime? latestAppFDate)
        {
            try
            {
                int inserts = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BulkInsert_Appointments"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);
                        cmd.Parameters.AddWithValue("@app_ins", int.Parse(dt.Rows[0]["app_ins"].ToString()));
                        cmd.Parameters.AddWithValue("@app_doctor", int.Parse(dt.Rows[0]["app_doctor"].ToString()));
                        cmd.Parameters.AddWithValue("@app_ftime", int.Parse(dt.Rows[0]["app_ftime"].ToString()));
                        cmd.Parameters.AddWithValue("@app_ttime", int.Parse(dt.Rows[0]["app_ttime"].ToString()));

                        if (latestAppFDate.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@app_last_visit", latestAppFDate);
                        }

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

        //public static DataTable PACKAGE_TYPE( string query)
        //{
        //    try
        //    {
        //        DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //        Database db = factory.CreateDefault();

        //        DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTreatment_Groups");
        //        db.AddInParameter(dbCommand, "query", DbType.String, query);

        //        DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

        //        return data;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static DataTable PACKAGE_TYPE(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPackageMaster");
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPackageServices(int query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPackage_Services");
                db.AddInParameter(dbCommand, "query", DbType.Int32, query);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable SearchAppointmentPackage(int appId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_AppointmentPackage");
                db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                db.AddInParameter(dbCommand, "type", DbType.String, type);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPackage_Services_Qty(int app_package_order, int ps_package)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPackage_Services_Qty");
                db.AddInParameter(dbCommand, "ps_services", DbType.Int32, app_package_order);
                db.AddInParameter(dbCommand, "ps_package", DbType.Int32, ps_package);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region GenerateTocken
        public static void Generate_TockenNo(int appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GenerateTockenNo");
                db.AddInParameter(dbCommand, "appId ", DbType.Int32, appId);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataSet GetPatientEMRInfo(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTockenDetails");

                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetTockenDetails
        public static DataSet GetTockenDetails(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetTockenDetails");
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
                DataSet ds = db.ExecuteDataSet(dbCommand);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}