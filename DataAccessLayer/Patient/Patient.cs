using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Patient;
using System.Data.SqlClient;
using System.IO;
using static System.Net.WebRequestMethods;

namespace DataAccessLayer.Patient
{
    public class Patient
    {
        #region Patients (Page Load & Search)
        public static DataTable GetPatientsData(PatientSearch filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patients");

                if (!string.IsNullOrEmpty(filter.branch_ids))
                {
                    db.AddInParameter(dbCommand, "branch_ids", DbType.String, filter.branch_ids);
                }

                if (!string.IsNullOrEmpty(filter.residential_types))
                {
                    string residential_types = string.Join(",", filter.residential_types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "residential_types", DbType.String, residential_types);
                }

                if (!string.IsNullOrEmpty(filter.account_types))
                {
                    string account_types = string.Join(",", filter.account_types.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "account_types", DbType.String, account_types);
                }

                if (!string.IsNullOrEmpty(filter.mrn_from))
                {
                    db.AddInParameter(dbCommand, "mrn_from", DbType.String, filter.mrn_from);
                }

                if (!string.IsNullOrEmpty(filter.mrn_to))
                {
                    db.AddInParameter(dbCommand, "mrn_to", DbType.String, filter.mrn_to);
                }

                if (!string.IsNullOrEmpty(filter.nationalities))
                {
                    db.AddInParameter(dbCommand, "nationalities", DbType.String, filter.nationalities);
                }

                if (!string.IsNullOrEmpty(filter.reg_from))
                {
                    db.AddInParameter(dbCommand, "reg_from", DbType.String, filter.reg_from);
                }

                if (!string.IsNullOrEmpty(filter.reg_to))
                {
                    db.AddInParameter(dbCommand, "reg_to", DbType.String, filter.reg_to);
                }

                if (!string.IsNullOrEmpty(filter.dob_from))
                {
                    db.AddInParameter(dbCommand, "dob_from", DbType.String, filter.dob_from);
                }

                if (!string.IsNullOrEmpty(filter.dob_to))
                {
                    db.AddInParameter(dbCommand, "dob_to", DbType.String, filter.dob_to);
                }

                if (!string.IsNullOrEmpty(filter.pat_status))
                {
                    string pat_status = string.Join(",", filter.pat_status.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pat_status", DbType.String, pat_status);
                }

                if (!string.IsNullOrEmpty(filter.pat_gender))
                {
                    string pat_gender = string.Join(",", filter.pat_gender.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pat_gender", DbType.String, pat_gender);
                }

                if (!string.IsNullOrEmpty(filter.pat_ms))
                {
                    string pat_ms = string.Join(",", filter.pat_ms.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pat_ms", DbType.String, pat_ms);
                }

                if (!string.IsNullOrEmpty(filter.pat_class))
                {
                    string pat_class = string.Join(",", filter.pat_class.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "pat_class", DbType.String, pat_class);
                }

                if (!string.IsNullOrEmpty(filter.pat_referals))
                {
                    db.AddInParameter(dbCommand, "pat_referals", DbType.String, filter.pat_referals);
                }

                if (!string.IsNullOrEmpty(filter.pat_info))
                {
                    db.AddInParameter(dbCommand, "pat_info", DbType.String, filter.pat_info);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetPatientsDataByMRN(PatientSearch filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PatientsByMRN");

                if (!string.IsNullOrEmpty(filter.mrn_from))
                {
                    db.AddInParameter(dbCommand, "mrn_from", DbType.String, filter.mrn_from);
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

        #region Load Dropdowns
        public static DataTable GetReligions(int? relId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RELIGIONS_select_all_info");

                if (relId > 0)
                {
                    db.AddInParameter(dbCommand, "relId", DbType.Int32, relId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetCountries(int? countryId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_COUNTRIES_select_all_info");

                if (countryId > 0)
                {
                    db.AddInParameter(dbCommand, "countryId", DbType.Int32, countryId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetCitizenship(int? citizenId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_CITIZENSHIPS_select_all_info");

                if (citizenId > 0)
                {
                    db.AddInParameter(dbCommand, "citzenId", DbType.Int32, citizenId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetRelationship(int? relId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RELATIONSHIPS_select_all_info");

                if (relId > 0)
                {
                    db.AddInParameter(dbCommand, "relId", DbType.Int32, relId);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable ReadCountryAndNationalityFromEMID(string code = null, string name = null)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetNationality_ByCodeName");

                if (!string.IsNullOrEmpty(code))
                {
                    db.AddInParameter(dbCommand, "code", DbType.String, code);
                }

                if (!string.IsNullOrEmpty(name))
                {
                    db.AddInParameter(dbCommand, "name", DbType.String, name);
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

        #region Patient CRUD Operations
        public static string GenerateMRN()
        {
            try
            {
                string mrn_output = string.Empty;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GenerateMRN");
                db.AddOutParameter(dbCommand, "mrn_output", DbType.String, 100);

                db.ExecuteScalar(dbCommand);

                mrn_output = db.GetParameterValue(dbCommand, "mrn_output").ToString();

                return mrn_output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int InsertPatient(PatientWithInsurance pi, int madeby, out int piId_output)
        {
            try
            {
                piId_output = 0;
                int patId_output = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENTS_insert");

                //Main Info
                db.AddInParameter(dbCommand, "pat_code", DbType.Int32, pi.patient.pat_code);
                db.AddInParameter(dbCommand, "pat_title", DbType.String, pi.patient.pat_title);
                db.AddInParameter(dbCommand, "pat_class", DbType.String, pi.patient.pat_class);
                db.AddInParameter(dbCommand, "pat_referal", DbType.Int32, pi.patient.pat_referal);
                db.AddInParameter(dbCommand, "pat_branch", DbType.Int32, pi.patient.pat_branch);
                db.AddInParameter(dbCommand, "pat_name", DbType.String, pi.patient.pat_name);
                db.AddInParameter(dbCommand, "pat_mname", DbType.String, pi.patient.pat_mname);
                db.AddInParameter(dbCommand, "pat_lname", DbType.String, pi.patient.pat_lname);
                db.AddInParameter(dbCommand, "pat_emirateid", DbType.String, pi.patient.pat_emirateid);
                db.AddInParameter(dbCommand, "pat_mob", DbType.String, pi.patient.pat_mob);
                db.AddInParameter(dbCommand, "pat_dob", DbType.DateTime, pi.patient.pat_dob);
                db.AddInParameter(dbCommand, "pat_gender", DbType.String, pi.patient.pat_gender);
                db.AddInParameter(dbCommand, "pat_ms", DbType.String, pi.patient.pat_ms);
                db.AddInParameter(dbCommand, "pat_nat", DbType.Int32, pi.patient.pat_nat);

                //Additional Info
                db.AddInParameter(dbCommand, "pat_name_arabic", DbType.String, pi.patient.pat_name_arabic);
                db.AddInParameter(dbCommand, "pat_lname_arabic", DbType.String, pi.patient.pat_lname_arabic);
                db.AddInParameter(dbCommand, "pat_passport", DbType.String, pi.patient.pat_passport);
                db.AddInParameter(dbCommand, "pat_tel", DbType.String, pi.patient.pat_tel);
                db.AddInParameter(dbCommand, "pat_email", DbType.String, pi.patient.pat_email);
                db.AddInParameter(dbCommand, "pat_religion", DbType.String, pi.patient.pat_religion);
                db.AddInParameter(dbCommand, "pat_occupation", DbType.String, pi.patient.pat_occupation);
                db.AddInParameter(dbCommand, "pat_country", DbType.Int32, pi.patient.pat_country);
                db.AddInParameter(dbCommand, "pat_citizen", DbType.String, pi.patient.pat_citizen);
                db.AddInParameter(dbCommand, "pat_rel_address", DbType.String, pi.patient.pat_rel_address);
                db.AddInParameter(dbCommand, "pat_race", DbType.String, pi.patient.pat_race);
                db.AddInParameter(dbCommand, "pat_fax", DbType.String, pi.patient.pat_fax);
                db.AddInParameter(dbCommand, "pat_obal", DbType.Decimal, pi.patient.pat_obal);
                db.AddInParameter(dbCommand, "pat_obal_type", DbType.String, pi.patient.pat_obal_type);
                db.AddInParameter(dbCommand, "pat_pobox", DbType.String, pi.patient.pat_pobox);
                db.AddInParameter(dbCommand, "pat_city", DbType.String, pi.patient.pat_city);
                db.AddInParameter(dbCommand, "pat_address", DbType.String, pi.patient.pat_address);
                db.AddInParameter(dbCommand, "pat_notes", DbType.String, pi.patient.pat_notes);
                db.AddInParameter(dbCommand, "pat_photo", DbType.String, pi.patient.pat_photo);

                //Emergency Contact Info
                db.AddInParameter(dbCommand, "pat_ec_name1", DbType.String, pi.patient.pat_ec_name1);
                db.AddInParameter(dbCommand, "pat_ec_name2", DbType.String, pi.patient.pat_ec_name2);
                db.AddInParameter(dbCommand, "pat_ec_name3", DbType.String, pi.patient.pat_ec_name3);
                db.AddInParameter(dbCommand, "pat_ec_rel1", DbType.String, pi.patient.pat_ec_rel1);
                db.AddInParameter(dbCommand, "pat_ec_rel2", DbType.String, pi.patient.pat_ec_rel2);
                db.AddInParameter(dbCommand, "pat_ec_rel3", DbType.String, pi.patient.pat_ec_rel3);
                db.AddInParameter(dbCommand, "pat_ec_tel1", DbType.String, pi.patient.pat_ec_tel1);
                db.AddInParameter(dbCommand, "pat_ec_tel2", DbType.String, pi.patient.pat_ec_tel2);
                db.AddInParameter(dbCommand, "pat_ec_tel3", DbType.String, pi.patient.pat_ec_tel3);
                db.AddInParameter(dbCommand, "pat_ec_tel11", DbType.String, pi.patient.pat_ec_tel11);
                db.AddInParameter(dbCommand, "pat_ec_tel22", DbType.String, pi.patient.pat_ec_tel22);
                db.AddInParameter(dbCommand, "pat_ec_tel33", DbType.String, pi.patient.pat_ec_tel33);
                db.AddInParameter(dbCommand, "pat_ethnic", DbType.String, pi.patient.pat_ethnic);
                db.AddInParameter(dbCommand, "pat_lang", DbType.String, pi.patient.pat_lang);
                db.AddInParameter(dbCommand, "pat_doc_2", DbType.String, pi.patient.pat_doc_2);

                db.AddInParameter(dbCommand, "id_card_front", DbType.String, pi.patient.id_card_front);
                db.AddInParameter(dbCommand, "id_card_back", DbType.String, pi.patient.id_card_back);
                db.AddInParameter(dbCommand, "id_card_idate", DbType.DateTime, pi.patient.id_card_idate);
                db.AddInParameter(dbCommand, "id_card_edate", DbType.DateTime, pi.patient.id_card_edate);
                db.AddInParameter(dbCommand, "pat_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "patId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "piId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                patId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "patId").ToString());
                piId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "piId").ToString());

                if (patId_output > 0 && pi.insurance.pi_insurance > 1)
                {
                    piId_output = PatientInsurance.InsertPatientInsurance(pi.insurance, madeby, patId_output);
                }

                return patId_output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetPatientById(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientById");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdatePatient(PatientDetails pat, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_PATIENTS_update");
                //Main Info
                db.AddInParameter(dbCommand, "patId", DbType.Int32, pat.patId);
                db.AddInParameter(dbCommand, "pat_code", DbType.Int32, pat.pat_code);
                db.AddInParameter(dbCommand, "pat_title", DbType.String, pat.pat_title);
                db.AddInParameter(dbCommand, "pat_class", DbType.String, pat.pat_class);
                db.AddInParameter(dbCommand, "pat_referal", DbType.Int32, pat.pat_referal);
                db.AddInParameter(dbCommand, "pat_branch", DbType.Int32, pat.pat_branch);
                db.AddInParameter(dbCommand, "pat_name", DbType.String, pat.pat_name);
                db.AddInParameter(dbCommand, "pat_mname", DbType.String, pat.pat_mname);
                db.AddInParameter(dbCommand, "pat_lname", DbType.String, pat.pat_lname);
                db.AddInParameter(dbCommand, "pat_emirateid", DbType.String, pat.pat_emirateid);
                db.AddInParameter(dbCommand, "pat_mob", DbType.String, pat.pat_mob);
                db.AddInParameter(dbCommand, "pat_dob", DbType.DateTime, pat.pat_dob);
                db.AddInParameter(dbCommand, "pat_gender", DbType.String, pat.pat_gender);
                db.AddInParameter(dbCommand, "pat_ms", DbType.String, pat.pat_ms);
                db.AddInParameter(dbCommand, "pat_nat", DbType.Int32, pat.pat_nat);

                //Additional Info
                db.AddInParameter(dbCommand, "pat_name_arabic", DbType.String, pat.pat_name_arabic);
                db.AddInParameter(dbCommand, "pat_lname_arabic", DbType.String, pat.pat_lname_arabic);
                db.AddInParameter(dbCommand, "pat_passport", DbType.String, pat.pat_passport);
                db.AddInParameter(dbCommand, "pat_tel", DbType.String, pat.pat_tel);
                db.AddInParameter(dbCommand, "pat_email", DbType.String, pat.pat_email);
                db.AddInParameter(dbCommand, "pat_religion", DbType.String, pat.pat_religion);
                db.AddInParameter(dbCommand, "pat_occupation", DbType.String, pat.pat_occupation);
                db.AddInParameter(dbCommand, "pat_country", DbType.Int32, pat.pat_country);
                db.AddInParameter(dbCommand, "pat_citizen", DbType.String, pat.pat_citizen);
                db.AddInParameter(dbCommand, "pat_rel_address", DbType.String, pat.pat_rel_address);
                db.AddInParameter(dbCommand, "pat_race", DbType.String, pat.pat_race);
                db.AddInParameter(dbCommand, "pat_fax", DbType.String, pat.pat_fax);
                db.AddInParameter(dbCommand, "pat_obal", DbType.Decimal, pat.pat_obal);
                db.AddInParameter(dbCommand, "pat_obal_type", DbType.String, pat.pat_obal_type);
                db.AddInParameter(dbCommand, "pat_pobox", DbType.String, pat.pat_pobox);
                db.AddInParameter(dbCommand, "pat_city", DbType.String, pat.pat_city);
                db.AddInParameter(dbCommand, "pat_address", DbType.String, pat.pat_address);
                db.AddInParameter(dbCommand, "pat_notes", DbType.String, pat.pat_notes);
                db.AddInParameter(dbCommand, "pat_photo", DbType.String, pat.pat_photo);

                //Emergency Contact Info
                db.AddInParameter(dbCommand, "pat_ec_name1", DbType.String, pat.pat_ec_name1);
                db.AddInParameter(dbCommand, "pat_ec_name2", DbType.String, pat.pat_ec_name2);
                db.AddInParameter(dbCommand, "pat_ec_name3", DbType.String, pat.pat_ec_name3);
                db.AddInParameter(dbCommand, "pat_ec_rel1", DbType.String, pat.pat_ec_rel1);
                db.AddInParameter(dbCommand, "pat_ec_rel2", DbType.String, pat.pat_ec_rel2);
                db.AddInParameter(dbCommand, "pat_ec_rel3", DbType.String, pat.pat_ec_rel3);
                db.AddInParameter(dbCommand, "pat_ec_tel1", DbType.String, pat.pat_ec_tel1);
                db.AddInParameter(dbCommand, "pat_ec_tel2", DbType.String, pat.pat_ec_tel2);
                db.AddInParameter(dbCommand, "pat_ec_tel3", DbType.String, pat.pat_ec_tel3);
                db.AddInParameter(dbCommand, "pat_ec_tel11", DbType.String, pat.pat_ec_tel11);
                db.AddInParameter(dbCommand, "pat_ec_tel22", DbType.String, pat.pat_ec_tel22);
                db.AddInParameter(dbCommand, "pat_ec_tel33", DbType.String, pat.pat_ec_tel33);
                db.AddInParameter(dbCommand, "pat_ethnic", DbType.String, pat.pat_ethnic);
                db.AddInParameter(dbCommand, "pat_lang", DbType.String, pat.pat_lang);
                db.AddInParameter(dbCommand, "pat_doc_2", DbType.String, pat.pat_doc_2);

                db.AddInParameter(dbCommand, "id_card_front", DbType.String, pat.id_card_front);
                db.AddInParameter(dbCommand, "id_card_back", DbType.String, pat.id_card_back);
                db.AddInParameter(dbCommand, "id_card_idate", DbType.DateTime, pat.id_card_idate);
                db.AddInParameter(dbCommand, "id_card_edate", DbType.DateTime, pat.id_card_edate);
                db.AddInParameter(dbCommand, "pat_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "patId_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateBulkPatientStatus(DataTable dt)
        {
            int inserts = 0;
            try
            {


                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                SqlConnection con = new SqlConnection(db.ConnectionString);

                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("SP_BulkUpdate_PatientStatus"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@tblBulk", dt);
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

        public static int ChangePatientStatus(int patId, string pat_status, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_ChangeStatus");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "pat_status", DbType.String, pat_status);
                db.AddInParameter(dbCommand, "pat_madeby", DbType.String, madeby);
                db.AddOutParameter(dbCommand, "pat_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pat_output").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int UpdateMRNNo(int patId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Patient_ChangeMRN");
                db.AddInParameter(dbCommand, "patId", DbType.Int32, patId);
                db.AddInParameter(dbCommand, "pat_madeby", DbType.String, madeby);
                db.AddOutParameter(dbCommand, "pat_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "pat_output").ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Patient Miscellaneous Functions
        public static DataTable PatientAuditLog(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_PATIENT_AUDIT_LOG");

                db.AddInParameter(dbCommand, "pata_patId", DbType.Int32, patId);


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int RemarksInsert(Remarks remark)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Remarks_Insert");
                db.AddInParameter(dbCommand, "ar_appId", DbType.Int32, remark.ar_appId);
                db.AddInParameter(dbCommand, "ar_employee", DbType.Int32, remark.ar_employee);
                db.AddInParameter(dbCommand, "ar_remarks", DbType.String, remark.ar_remarks);
                db.AddInParameter(dbCommand, "ar_patId", DbType.Int32, remark.ar_patId);
                db.AddInParameter(dbCommand, "ar_fllowupdate", DbType.DateTime, remark.ar_fllowupdate);
                db.AddInParameter(dbCommand, "ar_ftime", DbType.Int32, remark.ar_ftime);
                db.AddInParameter(dbCommand, "ar_flag", DbType.String, remark.ar_flag);
                db.AddOutParameter(dbCommand, "ar_output", DbType.Int32, 100);

                db.ExecuteScalar(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "ar_output").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetRemarks(int id, int type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetRemarks");

                db.AddInParameter(dbCommand, "id", DbType.Int32, id);
                db.AddInParameter(dbCommand, "type", DbType.Int32, type);


                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int RemarksDelete(int arId, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Remarks_Delete");
                db.AddInParameter(dbCommand, "arId", DbType.Int32, arId);
                db.AddInParameter(dbCommand, "ar_employee", DbType.Int32, madeby);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Enquiry Patient CRUD Operations
        public static int InsertInquiryPatient(PatientWithInsurance pi, int madeby, out int piId_output)
        {
            try
            {
                piId_output = 0;
                int patId_output = 0;

                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_INSERT_ENQUIRY_PATIENT");

                db.AddInParameter(dbCommand, "pat_branch", DbType.Int32, pi.patient.pat_branch);
                db.AddInParameter(dbCommand, "pat_name", DbType.String, pi.patient.pat_name);
                db.AddInParameter(dbCommand, "pat_lname", DbType.String, pi.patient.pat_lname);
                db.AddInParameter(dbCommand, "pat_mob", DbType.String, pi.patient.pat_mob);

                db.AddInParameter(dbCommand, "pat_madeby", DbType.Int32, madeby);
                db.AddOutParameter(dbCommand, "patId", DbType.Int32, 100);
                db.AddOutParameter(dbCommand, "piId", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                patId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "patId").ToString());
                piId_output = Convert.ToInt32(db.GetParameterValue(dbCommand, "piId").ToString());

                if (patId_output > 0 && pi.insurance.pi_insurance > 1)
                {
                    piId_output = PatientInsurance.InsertPatientInsurance(pi.insurance, madeby, patId_output);
                }

                return patId_output;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        
        #region Packages
        public static DataSet GetPatientPackages(int po_patId, int poId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("sp_GetPatientPackages");

                if (poId > 0)
                {
                    db.AddInParameter(dbCommand, "poId", DbType.Int32, poId);
                }
                if (po_patId > 0)
                {
                    db.AddInParameter(dbCommand, "po_patId", DbType.Int32, po_patId);
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

        public static DataTable SearchPatients(string query, int search_type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Search_Patients");

                db.AddInParameter(dbCommand, "query", DbType.String, query);
                db.AddInParameter(dbCommand, "search_type", DbType.Int32, search_type);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Patients for merging
        public static DataTable GetPatientDataforMerge(PatientSearch filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_merge");

                if (!string.IsNullOrEmpty(filter.pat_info))
                {
                    db.AddInParameter(dbCommand, "patId", DbType.String, filter.pat_info);
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

        public static int MergePatient(MergeData requestData, int madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Merge_Patients");
                db.AddInParameter(dbCommand, "piIdF", DbType.Int32, requestData.dataFrom[0].piIdF);
                db.AddInParameter(dbCommand, "patIdF", DbType.Int32, requestData.dataFrom[0].patIdF);

                db.AddInParameter(dbCommand, "piIdT", DbType.Int32, requestData.dataTo[0].piIdT);
                db.AddInParameter(dbCommand, "patIdT", DbType.Int32, requestData.dataTo[0].patIdT);
                db.AddInParameter(dbCommand, "madeby", DbType.Int32, madeby);
                //db.AddOutParameter(dbCommand, "pat_output", DbType.Int32, 100);

                int val = db.ExecuteNonQuery(dbCommand);

                return val;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetPatientDatabypiId(PatientSearch filter)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Patient_BypiId");

                if (!string.IsNullOrEmpty(filter.piIdF))
                {
                    db.AddInParameter(dbCommand, "piIdF", DbType.Int32, int.Parse(filter.piIdF));
                }

                if (!string.IsNullOrEmpty(filter.patIdT))
                {
                    db.AddInParameter(dbCommand, "patIdT", DbType.Int32, int.Parse(filter.patIdT));
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable PatientInvoiceSummary(int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPatientInvoiceSummary");

                db.AddInParameter(dbCommand, "id", DbType.Int32, patId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}