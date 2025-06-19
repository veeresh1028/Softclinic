using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.Lists;
using BusinessEntities.Patient;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Patient
{
    public class Patient
    {
        public static List<BusinessEntities.Patient.Patient> GetPatientsData(PatientSearch filter)
        {
            List<BusinessEntities.Patient.Patient> patients = new List<BusinessEntities.Patient.Patient>();
            DataTable dt = DataAccessLayer.Patient.Patient.GetPatientsData(filter);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.Patient patient = new BusinessEntities.Patient.Patient();
                patient.patId = int.Parse(dr["patId"].ToString());
                patient.pat_code = dr["pat_code"].ToString();
                patient.pat_name = dr["pat_name"].ToString();
                patient.pat_name_arb = dr["pat_name_arb"].ToString();
                patient.pat_dob = dr["pat_dob"].ToString();
                patient.pat_gender = dr["pat_gender"].ToString();
                patient.nationality = dr["nationality"].ToString();
                patient.pat_mob = dr["pat_mob"].ToString();
                patient.pat_emirateid = dr["pat_emirateid"].ToString();
                patient.pat_email = dr["pat_email"].ToString();
                patient.pat_status = dr["pat_status"].ToString();
                patient.actionvisible = dr["actionvisible"].ToString();
                patient.pat_age = dr["pat_age"].ToString();
                patient.pat_class = dr["pat_class"].ToString();
                patient.pat_ms = (dr["pat_ms"].ToString().ToLower().StartsWith("m") ? "Married" : (dr["pat_ms"].ToString().ToLower().StartsWith("d") ? "Divorced" : "Single"));
                patient.pat_referal = dr["pat_referal"].ToString();
                patient.ref_name = dr["ref_name"].ToString();
                patient.actionvisible = dr["actionvisible"].ToString();
                patient.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                patient.id_card_front = dr["id_card_front"].ToString();
                patient.id_card_back = dr["id_card_back"].ToString();
                patient.pat_title = dr["pat_title"].ToString();

                if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                {
                    patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                }
                else
                {
                    if (patient.pat_gender.ToLower().StartsWith("f"))
                    {
                        patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                    }
                    else
                    {
                        patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                    }
                }
                patients.Add(patient);
            }

            return patients;

        }
        
        public static List<BusinessEntities.Patient.Patient> GetPatientsDataByMRN(PatientSearch filter)
        {
            List<BusinessEntities.Patient.Patient> patients = new List<BusinessEntities.Patient.Patient>();
            DataTable dt = DataAccessLayer.Patient.Patient.GetPatientsDataByMRN(filter);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.Patient patient = new BusinessEntities.Patient.Patient();
                patient.patId = int.Parse(dr["patId"].ToString());
                patient.pat_code = dr["pat_code"].ToString();
                patient.pat_name = dr["pat_name"].ToString();
                patient.pat_name_arb = dr["pat_name_arb"].ToString();
                patient.pat_dob = dr["pat_dob"].ToString();
                patient.pat_gender = dr["pat_gender"].ToString();
                patient.nationality = dr["nationality"].ToString();
                patient.pat_mob = dr["pat_mob"].ToString();
                patient.pat_emirateid = dr["pat_emirateid"].ToString();
                patient.pat_email = dr["pat_email"].ToString();
                patient.pat_status = dr["pat_status"].ToString();
                patient.actionvisible = dr["actionvisible"].ToString();
                patient.pat_age = dr["pat_age"].ToString();
                patient.pat_class = dr["pat_class"].ToString();
                patient.pat_ms = (dr["pat_ms"].ToString().ToLower().StartsWith("m") ? "Married" : (dr["pat_ms"].ToString().ToLower().StartsWith("d") ? "Divorced" : "Single"));
                patient.pat_referal = dr["pat_referal"].ToString();
                patient.ref_name = dr["ref_name"].ToString();
                patient.actionvisible = dr["actionvisible"].ToString();
                patient.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                patient.id_card_front = dr["id_card_front"].ToString();
                patient.id_card_back = dr["id_card_back"].ToString();
                patient.pat_title = dr["pat_title"].ToString();

                if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                {
                    patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                }
                else
                {
                    if (patient.pat_gender.ToLower().StartsWith("f"))
                    {
                        patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                    }
                    else
                    {
                        patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                    }
                }
                patients.Add(patient);
            }

            return patients;

        }

        public static int UpdateBulkPatientStatus(PatientBulkStatus data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PatientId", typeof(int));
            dt.Columns.Add("Status", typeof(string));

            foreach (int i in data.patIds)
            {
                DataRow dr = dt.NewRow();
                dr["PatientId"] = i;
                dr["Status"] = data.status;
                dt.Rows.Add(dr);
            }
            return DataAccessLayer.Patient.Patient.UpdateBulkPatientStatus(dt);
        }

        public static DataTable GetReligions(int? relId)
        {
            return DataAccessLayer.Patient.Patient.GetReligions(relId);
        }

        public static DataTable GetCountries(int? countryId)
        {
            return DataAccessLayer.Patient.Patient.GetCountries(countryId);
        }

        public static DataTable GetCitizenship(int? citizenId)
        {
            return DataAccessLayer.Patient.Patient.GetCitizenship(citizenId);
        }

        public static DataTable GetRelationship(int? relId)
        {
            return DataAccessLayer.Patient.Patient.GetRelationship(relId);
        }

        public static List<CountryWithNationalityAndCitizenship> ReadCountryAndNationalityFromEMID(string code = null, string name = null)
        {
            DataTable dt = DataAccessLayer.Patient.Patient.ReadCountryAndNationalityFromEMID(code, name);

            List<CountryWithNationalityAndCitizenship> cn_list = new List<CountryWithNationalityAndCitizenship>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CountryWithNationalityAndCitizenship cn = new CountryWithNationalityAndCitizenship();
                    Countries c = new Countries();
                    c.countryId = int.Parse(dr["countryId"].ToString());
                    c.country = dr["country"].ToString();
                    c.country_code = dr["country_code"].ToString();

                    Nationalities n = new Nationalities();
                    n.natId = int.Parse(dr["natId"].ToString());
                    n.nationality = dr["nationality"].ToString();
                    n.nat_code = dr["nat_code"].ToString();
                    n.nat_cpq = dr["nat_cpq"].ToString();
                    n.nat_region = dr["nat_region"].ToString();
                    n.nat_ISO2 = dr["nat_ISO2"].ToString();

                    Citizenship cz = new Citizenship();
                    cz.citizenId = int.Parse(dr["citzenId"].ToString());
                    cz.citizen = dr["citzen"].ToString();
                    cz.citizen_code = dr["citzen_code"].ToString();

                    cn.countries = c;
                    cn.nationalities = n;
                    cn.citizenship = cz;
                    cn_list.Add(cn);
                }
            }

            return cn_list;
        }

        public static string GenerateMRN()
        {
            return DataAccessLayer.Patient.Patient.GenerateMRN();
        }

        public static int InsertPatient(PatientWithInsurance data, int madeby, out int piId_output)
        {
            data.patient.pat_tel = (string.IsNullOrEmpty(data.patient.pat_tel)) ? string.Empty : data.patient.pat_tel;
            data.patient.pat_fax = (string.IsNullOrEmpty(data.patient.pat_fax)) ? string.Empty : data.patient.pat_fax;
            data.patient.pat_email = (string.IsNullOrEmpty(data.patient.pat_email)) ? string.Empty : data.patient.pat_email;
            data.patient.pat_pobox = (string.IsNullOrEmpty(data.patient.pat_pobox)) ? string.Empty : data.patient.pat_pobox;
            data.patient.pat_address = (string.IsNullOrEmpty(data.patient.pat_address)) ? string.Empty : data.patient.pat_address;
            data.patient.pat_city = (string.IsNullOrEmpty(data.patient.pat_city)) ? string.Empty : data.patient.pat_city;
            data.patient.pat_rel_address = (string.IsNullOrEmpty(data.patient.pat_rel_address)) ? string.Empty : data.patient.pat_rel_address;
            data.patient.pat_notes = (string.IsNullOrEmpty(data.patient.pat_notes)) ? string.Empty : data.patient.pat_notes;
            data.patient.pat_mname = (string.IsNullOrEmpty(data.patient.pat_mname)) ? string.Empty : data.patient.pat_mname;
            data.patient.pat_ec_name1 = (string.IsNullOrEmpty(data.patient.pat_ec_name1)) ? string.Empty : data.patient.pat_ec_name1;
            data.patient.pat_ec_name2 = (string.IsNullOrEmpty(data.patient.pat_ec_name2)) ? string.Empty : data.patient.pat_ec_name2;
            data.patient.pat_ec_name3 = (string.IsNullOrEmpty(data.patient.pat_ec_name3)) ? string.Empty : data.patient.pat_ec_name3;
            data.patient.pat_ec_rel1 = (string.IsNullOrEmpty(data.patient.pat_ec_rel1)) ? string.Empty : data.patient.pat_ec_rel1;
            data.patient.pat_ec_rel2 = (string.IsNullOrEmpty(data.patient.pat_ec_rel2)) ? string.Empty : data.patient.pat_ec_rel2;
            data.patient.pat_ec_rel3 = (string.IsNullOrEmpty(data.patient.pat_ec_rel3)) ? string.Empty : data.patient.pat_ec_rel3;
            data.patient.pat_title = (string.IsNullOrEmpty(data.patient.pat_title)) ? string.Empty : data.patient.pat_title;
            data.patient.pat_obal_type = (string.IsNullOrEmpty(data.patient.pat_obal_type)) ? string.Empty : data.patient.pat_obal_type;
            data.patient.pat_emirateid = (string.IsNullOrEmpty(data.patient.pat_emirateid)) ? string.Empty : data.patient.pat_emirateid.Replace("-", "");
            data.patient.pat_passport = (string.IsNullOrEmpty(data.patient.pat_passport)) ? string.Empty : data.patient.pat_passport;
            data.patient.pat_name_arabic = (string.IsNullOrEmpty(data.patient.pat_name_arabic)) ? string.Empty : data.patient.pat_name_arabic;
            data.patient.pat_lname_arabic = (string.IsNullOrEmpty(data.patient.pat_lname_arabic)) ? string.Empty : data.patient.pat_lname_arabic;
            data.patient.pat_ethnic = (string.IsNullOrEmpty(data.patient.pat_ethnic)) ? string.Empty : data.patient.pat_ethnic;
            data.patient.pat_doc_2 = (string.IsNullOrEmpty(data.patient.pat_doc_2)) ? string.Empty : data.patient.pat_doc_2;
            data.patient.pat_race = (string.IsNullOrEmpty(data.patient.pat_race)) ? "Unknown" : data.patient.pat_race;

            data.patient.id_card_front = (string.IsNullOrEmpty(data.patient.id_card_front)) ? string.Empty : data.patient.id_card_front;
            data.patient.id_card_back = (string.IsNullOrEmpty(data.patient.id_card_back)) ? string.Empty : data.patient.id_card_back;
            data.patient.id_card_idate = (string.IsNullOrEmpty(data.patient.id_card_idate.ToString())) ? DateTime.Parse("1900-01-01") : data.patient.id_card_idate;
            data.patient.id_card_edate = (string.IsNullOrEmpty(data.patient.id_card_edate.ToString())) ? DateTime.Parse("2100-01-01") : data.patient.id_card_edate;

            return DataAccessLayer.Patient.Patient.InsertPatient(data, madeby, out piId_output);
        }

        public static int UpdatePatient(PatientDetails pat, int madeby)
        {
            pat.pat_tel = (string.IsNullOrEmpty(pat.pat_tel)) ? string.Empty : pat.pat_tel;
            pat.pat_fax = (string.IsNullOrEmpty(pat.pat_fax)) ? string.Empty : pat.pat_fax;
            pat.pat_email = (string.IsNullOrEmpty(pat.pat_email)) ? string.Empty : pat.pat_email;
            pat.pat_pobox = (string.IsNullOrEmpty(pat.pat_pobox)) ? string.Empty : pat.pat_pobox;
            pat.pat_address = (string.IsNullOrEmpty(pat.pat_address)) ? string.Empty : pat.pat_address;
            pat.pat_city = (string.IsNullOrEmpty(pat.pat_city)) ? string.Empty : pat.pat_city;
            pat.pat_rel_address = (string.IsNullOrEmpty(pat.pat_rel_address)) ?"Dubai" : pat.pat_rel_address;
            pat.pat_notes = (string.IsNullOrEmpty(pat.pat_notes)) ? string.Empty : pat.pat_notes;
            pat.pat_mname = (string.IsNullOrEmpty(pat.pat_mname)) ? string.Empty : pat.pat_mname;
            pat.pat_ec_name1 = (string.IsNullOrEmpty(pat.pat_ec_name1)) ? string.Empty : pat.pat_ec_name1;
            pat.pat_ec_name2 = (string.IsNullOrEmpty(pat.pat_ec_name2)) ? string.Empty : pat.pat_ec_name2;
            pat.pat_ec_name3 = (string.IsNullOrEmpty(pat.pat_ec_name3)) ? string.Empty : pat.pat_ec_name3;
            pat.pat_ec_rel1 = (string.IsNullOrEmpty(pat.pat_ec_rel1)) ? string.Empty : pat.pat_ec_rel1;
            pat.pat_ec_rel2 = (string.IsNullOrEmpty(pat.pat_ec_rel2)) ? string.Empty : pat.pat_ec_rel2;
            pat.pat_ec_rel3 = (string.IsNullOrEmpty(pat.pat_ec_rel3)) ? string.Empty : pat.pat_ec_rel3;
            pat.pat_title = (string.IsNullOrEmpty(pat.pat_title)) ? string.Empty : pat.pat_title;
            pat.pat_obal_type = (string.IsNullOrEmpty(pat.pat_obal_type)) ? string.Empty : pat.pat_obal_type;
            pat.pat_emirateid = (string.IsNullOrEmpty(pat.pat_emirateid)) ? string.Empty : pat.pat_emirateid.Replace("-", "");
            pat.pat_passport = (string.IsNullOrEmpty(pat.pat_passport)) ? string.Empty : pat.pat_passport;
            pat.pat_name_arabic = (string.IsNullOrEmpty(pat.pat_name_arabic)) ? string.Empty : pat.pat_name_arabic;
            pat.pat_lname_arabic = (string.IsNullOrEmpty(pat.pat_lname_arabic)) ? string.Empty : pat.pat_lname_arabic;
            pat.pat_ethnic = (string.IsNullOrEmpty(pat.pat_ethnic)) ? "Unknown" : pat.pat_ethnic;
            pat.pat_race = (string.IsNullOrEmpty(pat.pat_race)) ? "Other Race" : pat.pat_race;

            pat.id_card_front = (string.IsNullOrEmpty(pat.id_card_front)) ? string.Empty : pat.id_card_front;
            pat.id_card_back = (string.IsNullOrEmpty(pat.id_card_back)) ? string.Empty : pat.id_card_back;
            pat.id_card_idate = (string.IsNullOrEmpty(pat.id_card_idate.ToString())) ? DateTime.Parse("1900-01-01") : pat.id_card_idate;
            pat.id_card_edate = (string.IsNullOrEmpty(pat.id_card_edate.ToString())) ? DateTime.Parse("2100-01-01") : pat.id_card_edate;
            pat.pat_doc_2 = (string.IsNullOrEmpty(pat.pat_doc_2)) ? string.Empty : pat.pat_doc_2;

            return DataAccessLayer.Patient.Patient.UpdatePatient(pat, madeby);
        }

        public static PatientDetails GetPatientById(int patId)
        {
            PatientDetails pat = new PatientDetails();
            DataTable dt = DataAccessLayer.Patient.Patient.GetPatientById(patId);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                pat.patId = patId;
                pat.pat_class = dr["pat_class"].ToString();
                pat.pat_obal = decimal.Parse(dr["pat_obal"].ToString());
                pat.pat_obal_type = dr["pat_obal_type"].ToString();
                pat.pat_branch = int.Parse(dr["pat_branch"].ToString());
                pat.pat_code = dr["pat_code"].ToString();
                pat.pat_name = dr["pat_name"].ToString();
                pat.pat_mname = dr["pat_mname"].ToString();
                pat.pat_lname = dr["pat_lname"].ToString();
                pat.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                pat.pat_gender = dr["pat_gender"].ToString();
                pat.pat_name_arabic = dr["pat_name_arabic"].ToString();
                pat.pat_lname_arabic = dr["pat_lname_arabic"].ToString();
                pat.pat_tel = dr["pat_tel"].ToString();
                pat.pat_mob = dr["pat_mob"].ToString();
                pat.pat_email = dr["pat_email"].ToString();
                pat.pat_religion = dr["pat_religion"].ToString();
                pat.pat_race = dr["pat_race"].ToString();
                pat.pat_nat = int.Parse(dr["pat_nat"].ToString());
                pat.pat_citizen = dr["pat_citizen"].ToString();
                pat.pat_country = int.Parse(dr["pat_country"].ToString());
                pat.pat_ms = dr["pat_ms"].ToString();
                pat.pat_fax = dr["pat_fax"].ToString();
                pat.pat_emirateid = dr["pat_emirateid"].ToString();
                pat.pat_passport = dr["pat_passport"].ToString();
                pat.pat_occupation = dr["pat_occupation"].ToString();
                pat.pat_referal = int.Parse(dr["pat_referal"].ToString());
                pat.pat_city = dr["pat_city"].ToString();
                pat.pat_rel_address = dr["pat_rel_address"].ToString();
                pat.pat_pobox = dr["pat_pobox"].ToString();
                pat.pat_notes = dr["pat_notes"].ToString();
                pat.pat_address = dr["pat_address"].ToString();
                pat.id_card_front = dr["id_card_front"].ToString();
                pat.id_card_back = dr["id_card_back"].ToString();
                pat.id_card_idate = DateTime.Parse(dr["id_card_idate"].ToString());
                pat.id_card_edate = DateTime.Parse(dr["id_card_edate"].ToString());
                pat.pat_photo = dr["pat_photo"].ToString();
                pat.pat_ec_name1 = dr["pat_ec_name1"].ToString();
                pat.pat_ec_rel1 = dr["pat_ec_rel1"].ToString();
                pat.pat_ec_tel1 = dr["pat_ec_tel1"].ToString();
                pat.pat_ec_tel11 = dr["pat_ec_tel11"].ToString();
                pat.pat_ec_name2 = dr["pat_ec_name2"].ToString();
                pat.pat_ec_rel2 = dr["pat_ec_rel2"].ToString();
                pat.pat_ec_tel2 = dr["pat_ec_tel2"].ToString();
                pat.pat_ec_tel22 = dr["pat_ec_tel22"].ToString();
                pat.pat_ec_name3 = dr["pat_ec_name3"].ToString();
                pat.pat_ec_rel3 = dr["pat_ec_rel3"].ToString();
                pat.pat_ec_tel3 = dr["pat_ec_tel3"].ToString();
                pat.pat_ec_tel33 = dr["pat_ec_tel33"].ToString();
                pat.nationality = dr["nationality"].ToString();
                pat.pat_ethnic = dr["pat_ethnic"].ToString();
                pat.pat_lang = dr["pat_lang"].ToString();
                pat.app_last_visit = Convert.ToDateTime(dr["app_last_visit"].ToString());
                pat.pat_title = dr["pat_title"].ToString();
                pat.pat_doc_2 = dr["pat_doc_2"].ToString();
            }

            return pat;
        }

        public static int ChangePatientStatus(int patId, string pat_status, int madeby)
        {
            return DataAccessLayer.Patient.Patient.ChangePatientStatus(patId, pat_status, madeby);
        }

        public static int UpdateMRNNo(int patId, int madeby)
        {
            return DataAccessLayer.Patient.Patient.UpdateMRNNo(patId, madeby);
        }

        public static List<BusinessEntities.Patient.PatientAudit> PatientAuditLog(int patId)
        {
            List<BusinessEntities.Patient.PatientAudit> patients = new List<BusinessEntities.Patient.PatientAudit>();
            DataTable dt = DataAccessLayer.Patient.Patient.PatientAuditLog(patId);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.PatientAudit patient = new BusinessEntities.Patient.PatientAudit();
                patient.patId = int.Parse(dr["pata_patId"].ToString());
                patient.pat_code = int.Parse(dr["pata_code"].ToString());
                patient.pat_title = dr["pata_title"].ToString();
                patient.pat_name = dr["pata_name"].ToString();
                patient.pat_mname = dr["pata_mname"].ToString();
                patient.pat_lname = dr["pata_lname"].ToString();
                patient.pat_referal = dr["pata_referal"].ToString();
                patient.pat_branch = dr["pata_branch"].ToString();
                patient.pat_class = dr["pata_class"].ToString();
                patient.pat_dob = DateTime.Parse(dr["pata_dob"].ToString());
                patient.pat_gender = dr["pata_gender"].ToString();
                patient.pat_ms = (dr["pata_ms"].ToString().ToLower().StartsWith("m") ? "Married" : (dr["pata_ms"].ToString().ToLower().StartsWith("d") ? "Divorced" : "Single"));
                patient.pat_nat = dr["pata_nat"].ToString();
                patient.pat_mob = dr["pata_mob"].ToString();
                patient.pat_tel = dr["pata_tel"].ToString();
                patient.pat_fax = dr["pata_fax"].ToString();
                patient.pat_emirateid = dr["pata_emirateid"].ToString();
                patient.pat_email = dr["pata_email"].ToString();
                patient.pat_status = dr["pata_status"].ToString();
                patient.pat_pobox = dr["pata_pobox"].ToString();
                patient.pat_address = dr["pata_address"].ToString();
                patient.pat_class = dr["pata_class"].ToString();
                patient.pat_city = dr["pata_city"].ToString();
                patient.pat_country = dr["pata_country"].ToString();
                patient.pat_notes = dr["pata_notes"].ToString();
                patient.pat_obal = decimal.Parse(dr["pata_obal"].ToString());
                patient.pat_passport = dr["pata_passport"].ToString();
                patient.pat_religion = dr["pata_religion"].ToString();
                patient.pat_citizen = dr["pata_citizen"].ToString();
                patient.pat_slno = int.Parse(dr["pata_slno"].ToString());
                patient.pat_race = dr["pata_race"].ToString();
                patient.pat_name_arabic = dr["pata_name_arabic"].ToString();
                patient.pat_lname_arabic = dr["pata_lname_arabic"].ToString();
                patient.pat_occupation = dr["pata_occupation"].ToString();
                patient.pat_id_card_front = dr["pata_id_card_front"].ToString();
                patient.pat_id_card_back = dr["pata_id_card_back"].ToString();
                patient.pat_id_card_idate = DateTime.Parse(dr["pata_id_card_idate"].ToString());
                patient.pat_id_card_edate = DateTime.Parse(dr["pata_id_card_edate"].ToString());

                patient.logged_by = dr["pata_madeby_name"].ToString();
                patient.logged_action = dr["pata_operation"].ToString();
                patient.loged_timestamp = DateTime.Parse(dr["pata_date_created"].ToString());



                if (!string.IsNullOrEmpty(dr["pata_photo"].ToString()))
                {
                    patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pata_photo"].ToString();
                }
                else
                {
                    if (patient.pat_gender.ToLower().StartsWith("f"))
                    {
                        patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                    }
                    else
                    {
                        patient.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                    }
                }
                patients.Add(patient);
            }

            return patients;

        }

        public static int RemarksInsert(Remarks remark)
        {
            return DataAccessLayer.Patient.Patient.RemarksInsert(remark);
        }

        public static int RemarksDelete(int arId, int madeby)
        {
            return DataAccessLayer.Patient.Patient.RemarksDelete(arId, madeby);
        }

        public static List<BusinessEntities.Patient.Remarks> GetRemarks(int id, int type)
        {
            List<BusinessEntities.Patient.Remarks> remarks = new List<BusinessEntities.Patient.Remarks>();
            DataTable dt = DataAccessLayer.Patient.Patient.GetRemarks(id, type);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.Remarks r = new BusinessEntities.Patient.Remarks();
                r.arId = int.Parse(dr["arId"].ToString());
                r.ar_appId = int.Parse(dr["ar_appId"].ToString());
                r.ar_employee = int.Parse(dr["ar_employee"].ToString());
                r.ar_employee_name = dr["ar_employee_name"].ToString();
                r.ar_remarks = dr["ar_remarks"].ToString();
                r.ar_date_created = DateTime.Parse(dr["ar_date_created"].ToString());
                r.ar_patId = int.Parse(dr["ar_patId"].ToString());
                r.ar_fllowupdate = DateTime.Parse(dr["ar_fllowupdate"].ToString());
                r.ar_ftime = int.Parse(dr["ar_ftime"].ToString());
                r.ftime = dr["ftime"].ToString();
                r.ar_flag = dr["ar_flag"].ToString();
                r.ar_status = dr["ar_status"].ToString();
                remarks.Add(r);
            }

            return remarks;
        }

        public static int InsertInquiryPatient(PatientWithInsurance data, int madeby, out int piId_output)
        {
            return DataAccessLayer.Patient.Patient.InsertInquiryPatient(data, madeby, out piId_output);
        }

        public static PatientInquiry GetInquiryPatient(int patId)
        {
            PatientInquiry pat = new PatientInquiry();

            DataTable dt = DataAccessLayer.Patient.Patient.GetPatientById(patId);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                pat.patId = patId;
                pat.pat_name = dr["pat_name"].ToString();
                pat.pat_mname = dr["pat_mname"].ToString();
                pat.pat_lname = dr["pat_lname"].ToString();
                pat.pat_mob = dr["pat_mob"].ToString();
                pat.pat_email = dr["pat_email"].ToString();
            }

            return pat;
        }
        
        #region Packages
        public static List<BusinessEntities.EMR.PatientPackage> GetPatientPackages(int po_patId, int poId)
        {
            List<PatientPackage> packages = new List<PatientPackage>();
            DataSet ds = DataAccessLayer.Patient.Patient.GetPatientPackages(po_patId, poId);
            if (ds.Tables.Count > 0)
            {
                PatientPackage r = new PatientPackage();
                string service = string.Empty;
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    r.poId = int.Parse(dt.Rows[0]["poId"].ToString());
                    r.po_branch = int.Parse(dt.Rows[0]["po_branch"].ToString());
                    r.po_refno = dt.Rows[0]["po_refno"].ToString();
                    r.po_notes = dt.Rows[0]["po_notes"].ToString();
                    r.po_date = DateTime.Parse(dt.Rows[0]["po_date"].ToString());
                    r.po_patient = int.Parse(dt.Rows[0]["po_patient"].ToString());
                    r.po_exp_date = DateTime.Parse(dt.Rows[0]["po_exp_date"].ToString());
                    r.po_package = int.Parse(dt.Rows[0]["po_package"].ToString());
                    r.po_services = dt.Rows[0]["po_services"].ToString();
                    r.po_madeby = int.Parse(dt.Rows[0]["po_madeby"].ToString());
                    r.po_status = dt.Rows[0]["po_status"].ToString();
                    r.po_details = dt.Rows[0]["po_details"].ToString();
                    r.actionvisible = dt.Rows[0]["actionvisible"].ToString();
                    packages.Add(r);
                }

                DataTable dt_services = ds.Tables[1];
                if (dt_services.Rows.Count > 0)
                {
                    StringBuilder servicesBuilder = new StringBuilder();

                    foreach (DataRow dr in dt_services.Rows)
                    {
                        string poServicesDetails = dr["po_Servicesdetails"].ToString();
                        if (!string.IsNullOrEmpty(poServicesDetails))
                        {
                            servicesBuilder.Append(poServicesDetails);
                            servicesBuilder.Append("<br>");
                        }
                    }

                    if (servicesBuilder.Length > 4)
                    {
                        servicesBuilder.Length -= 4;
                    }

                    service = servicesBuilder.ToString();

                }

                r.po_Servicesdetails = service;
            }

            return packages;
        }
        #endregion

        public static List<CommonDDL> SearchPatients(string query, int search_type)
        {
            DataTable dt = DataAccessLayer.Patient.Patient.SearchPatients(query, search_type);
            List<CommonDDL> items = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    items.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["patId"]),
                        text = "<span class='text-primary me-2'>" + dr["pat_code"].ToString() + " - </span> " +
                                "<span class='text-info me-2'>" + dr["pat_name"].ToString() + " - </span> " +
                                "<span class='text-danger me-2'>" + dr["pat_mob"].ToString() + "</span>"
                    });
                }
            }

            return items;
        }

        public static List<BusinessEntities.Patient.PatientMerge> GetPatientDataforMerge(PatientSearch filter)
        {
            List<BusinessEntities.Patient.PatientMerge> patients = new List<BusinessEntities.Patient.PatientMerge>();
            DataTable dt = DataAccessLayer.Patient.Patient.GetPatientDataforMerge(filter);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.PatientMerge patient = new BusinessEntities.Patient.PatientMerge();
                patient.patId = int.Parse(dr["patId"].ToString());
                patient.piId = int.Parse(dr["piId"].ToString());
                patient.pat_code = dr["pat_code"].ToString();
                patient.pat_name = dr["pat_name"].ToString();
                patient.is_ic_name = dr["is_ic_name"].ToString();
                patient.is_title = dr["is_title"].ToString();
                patient.pi_insno = dr["pi_insno"].ToString();
                patient.pi_edate = DateTime.Parse(dr["pi_edate"].ToString());
                patients.Add(patient);
            }

            return patients;

        }

        public static int MergePatient(MergeData requestData, int madeby)
        {
            return DataAccessLayer.Patient.Patient.MergePatient(requestData, madeby);
        }

        public static List<BusinessEntities.Patient.PatientMerge> GetPatientDatabypiId(PatientSearch filter)
        {
            List<BusinessEntities.Patient.PatientMerge> patients = new List<BusinessEntities.Patient.PatientMerge>();
            DataTable dt = DataAccessLayer.Patient.Patient.GetPatientDatabypiId(filter);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Patient.PatientMerge patient = new BusinessEntities.Patient.PatientMerge();
                patient.patId = int.Parse(dr["patId"].ToString());
                patient.piId = int.Parse(dr["piId"].ToString());
                patient.appId = int.Parse(dr["appId"].ToString());
                patient.app_doctor = int.Parse(dr["app_doctor"].ToString());
                patient.app_patient = int.Parse(dr["app_patient"].ToString());
                patient.app_ins = int.Parse(dr["app_ins"].ToString());
                patient.pat_code = dr["pat_code"].ToString();
                patient.pat_name = dr["pat_name"].ToString();
                patient.is_ic_name = dr["is_ic_name"].ToString();
                patient.is_title = dr["is_title"].ToString();
                patient.pi_insno = dr["pi_insno"].ToString();
                patient.emp_name = dr["emp_name"].ToString();
                patient.pi_edate = DateTime.Parse(dr["pi_edate"].ToString());
                patient.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                patients.Add(patient);
            }

            return patients;

        }

        public static PatientBillingInfo PatientInvoiceSummary(int patId)
        {
            PatientBillingInfo info = new PatientBillingInfo();


            List<PatientInvoiceSummary> invoices_summary = new List<PatientInvoiceSummary>();
            DataTable dt = DataAccessLayer.Patient.Patient.PatientInvoiceSummary(patId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    PatientInvoiceSummary s = new PatientInvoiceSummary();
                    s.invId = int.Parse(r["invId"].ToString());
                    s.inv_appId = int.Parse(r["inv_appId"].ToString());
                    s.app_fdate = DateTime.Parse(r["app_fdate"].ToString());
                    s.inv_date = DateTime.Parse(r["inv_date"].ToString());
                    s.inv_type = r["inv_type"].ToString();
                    s.inv_no = r["inv_no"].ToString();
                    s.inv_status = r["inv_status"].ToString();
                    s.inv_total = decimal.Parse(r["inv_total"].ToString());
                    s.inv_disc = decimal.Parse(r["inv_disc"].ToString());
                    s.inv_net = decimal.Parse(r["inv_net"].ToString());
                    s.inv_vat = decimal.Parse(r["inv_vat"].ToString());
                    s.inv_netvat = decimal.Parse(r["inv_netvat"].ToString());

                    invoices_summary.Add(s);
                }

                info.patId = int.Parse(dt.Rows[0]["patId"].ToString());
                info.pat_name = dt.Rows[0]["pat_name"].ToString();
                info.invoices_summary = invoices_summary;
            }

            return info;
            
        }
    }
}