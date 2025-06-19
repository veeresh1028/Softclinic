using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.EMR;
using BusinessEntities.Accounts.Masters;
using System.Xml.Linq;

namespace DataAccessLayer.EMR
{
    public class ConsultationEMR
    {
        #region Denial Codes (Page Load)
        public static DataTable GetConsultationEMR(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("sp_ConsultationEMR");

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

        public static DataTable GetConsultationTemplateEMR(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetConsultationTemplateByAppId");

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
        public static DataTable GetTemplates(string query)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetConsultationEMR_Template");
                db.AddInParameter(dbCommand, "query", DbType.String, query);
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public static DataTable GetConsultationEMRTemplate(int cemtId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetConsultationEMRInfo");
                db.AddInParameter(dbCommand, "cemtId", DbType.Int32, cemtId);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Generate_ConsultationEMR(BusinessEntities.EMR.ConsultationEMR_Main temp, int madeby, out string temp_no)
        {
            int count = 0;
            int cemtId = 0;
            temp_no = string.Empty;
            List<BusinessEntities.EMR.PatientDiagnosis> list = temp.diagnosis_items;

            BusinessEntities.EMR.ConsultationEMRTemplate template = new BusinessEntities.EMR.ConsultationEMRTemplate();

            int id = 0;
            int id1 = 0;
            int id2 = -2;
            

            if (temp.template_details.type1 == "Template")
            {
                template.cemtId = 0;
                template.cemt_type = string.IsNullOrEmpty(temp.template.cemt_type) ? "" : temp.template.cemt_type;
                template.cemt_type2 = string.IsNullOrEmpty(temp.template.cemt_type2) ? "" : temp.template.cemt_type2;
                template.cemt_name = string.IsNullOrEmpty(temp.template.cemt_name) ? "" : temp.template.cemt_name;
                template.cemt_madeby = madeby;

                cemtId = ConsultationEMR.CreateTemplate(template);

                if (cemtId > 0)
                {
                    count++;
                }
                if (count > 0)
                {                   
                    id = CreateConsultationSheetEMRData(temp, madeby, cemtId, 0);
                } 
            }

            if (temp.template_details.type2 == "Appointment")
            {
                id1 = CreateConsultationSheetEMRData(temp, madeby, cemtId, 1);
            }


            if (id > 0 && id1 > 0)
            {
                return id;

            }
            else if (id > 0)
            {
                return id;
            }
            else if (id1 > 0)
            {
                return id1;
            }
            else
            {
                return id2;
            }



        }


        public static int CreateConsultationSheetEMRData(BusinessEntities.EMR.ConsultationEMR_Main temp, int madeby, int cemtId, int type)
        {
            try
            {
                ConsultationEMR_Details _temp = new ConsultationEMR_Details();
                _temp.cemrId = 0;
                _temp.cemr_cemtId = cemtId;
                _temp.cemr_appId = temp.template_details.cemr_appId;
                _temp.cemr_complaint = string.IsNullOrEmpty(temp.template_details.cemr_complaint) ? "" : temp.template_details.cemr_complaint;
                _temp.cemr_pasthistory = string.IsNullOrEmpty(temp.template_details.cemr_pasthistory) ? "" : temp.template_details.cemr_pasthistory;
                _temp.cemr_checkvalue = string.IsNullOrEmpty(temp.template_details.cemr_checkvalue) ? "" : temp.template_details.cemr_checkvalue;
                _temp.cemr_mentalorianted = string.IsNullOrEmpty(temp.template_details.cemr_mentalorianted) ? "" : temp.template_details.cemr_mentalorianted;
                _temp.cemr_mentaldisoriented = string.IsNullOrEmpty(temp.template_details.cemr_mentaldisoriented) ? "" : temp.template_details.cemr_mentaldisoriented;
                _temp.cemr_mentalimpired = string.IsNullOrEmpty(temp.template_details.cemr_mentalimpired) ? "" : temp.template_details.cemr_mentalimpired;
                _temp.cemr_mentalother = string.IsNullOrEmpty(temp.template_details.cemr_mentalother) ? "" : temp.template_details.cemr_mentalother;
                _temp.cemr_acute1 = string.IsNullOrEmpty(temp.template_details.cemr_acute1) ? "" : temp.template_details.cemr_acute1;
                _temp.cemr_subacute = string.IsNullOrEmpty(temp.template_details.cemr_subacute) ? "" : temp.template_details.cemr_subacute;
                _temp.cemr_chronic = string.IsNullOrEmpty(temp.template_details.cemr_chronic) ? "" : temp.template_details.cemr_chronic;
                _temp.cemr_recurrent = string.IsNullOrEmpty(temp.template_details.cemr_recurrent) ? "" : temp.template_details.cemr_recurrent;
                _temp.cemr_durationin = string.IsNullOrEmpty(temp.template_details.cemr_durationin) ? "" : temp.template_details.cemr_durationin;
                _temp.cemr_gettingworse = string.IsNullOrEmpty(temp.template_details.cemr_gettingworse) ? "" : temp.template_details.cemr_gettingworse;
                _temp.cemr_better = string.IsNullOrEmpty(temp.template_details.cemr_better) ? "" : temp.template_details.cemr_better;
                _temp.cemr_stillsame = string.IsNullOrEmpty(temp.template_details.cemr_stillsame) ? "" : temp.template_details.cemr_stillsame;
                _temp.cemr_bodyparts = string.IsNullOrEmpty(temp.template_details.cemr_bodyparts) ? "" : temp.template_details.cemr_bodyparts;
                _temp.cemr_observationins = string.IsNullOrEmpty(temp.template_details.cemr_observationins) ? "" : temp.template_details.cemr_observationins;
                _temp.cemr_palpation = string.IsNullOrEmpty(temp.template_details.cemr_palpation) ? "" : temp.template_details.cemr_palpation;
                _temp.cemr_rom = string.IsNullOrEmpty(temp.template_details.cemr_rom) ? "" : temp.template_details.cemr_rom;
                _temp.cemr_mptest = string.IsNullOrEmpty(temp.template_details.cemr_mptest) ? "" : temp.template_details.cemr_mptest;
                _temp.cemr_stest = string.IsNullOrEmpty(temp.template_details.cemr_stest) ? "" : temp.template_details.cemr_stest;
                _temp.cemr_reflexes = string.IsNullOrEmpty(temp.template_details.cemr_reflexes) ? "" : temp.template_details.cemr_reflexes;
                _temp.cemr_dermatone = string.IsNullOrEmpty(temp.template_details.cemr_dermatone) ? "" : temp.template_details.cemr_dermatone;
                _temp.cemr_myotome = string.IsNullOrEmpty(temp.template_details.cemr_myotome) ? "" : temp.template_details.cemr_myotome;
                _temp.cemr_independent = string.IsNullOrEmpty(temp.template_details.cemr_independent) ? "" : temp.template_details.cemr_independent;
                _temp.cemr_dependent = string.IsNullOrEmpty(temp.template_details.cemr_dependent) ? "" : temp.template_details.cemr_dependent;
                _temp.cemr_crutches = string.IsNullOrEmpty(temp.template_details.cemr_crutches) ? "" : temp.template_details.cemr_crutches;
                _temp.cemr_walker = string.IsNullOrEmpty(temp.template_details.cemr_walker) ? "" : temp.template_details.cemr_walker;
                _temp.cemr_wheelchair = string.IsNullOrEmpty(temp.template_details.cemr_wheelchair) ? "" : temp.template_details.cemr_wheelchair;
                _temp.cemr_active = string.IsNullOrEmpty(temp.template_details.cemr_active) ? "" : temp.template_details.cemr_active;
                _temp.cemr_athlete = string.IsNullOrEmpty(temp.template_details.cemr_athlete) ? "" : temp.template_details.cemr_athlete;
                _temp.cemr_lifestyle = string.IsNullOrEmpty(temp.template_details.cemr_lifestyle) ? "" : temp.template_details.cemr_lifestyle;
                _temp.cemr_bedridden = string.IsNullOrEmpty(temp.template_details.cemr_bedridden) ? "" : temp.template_details.cemr_bedridden;
                _temp.cemr_radiology = string.IsNullOrEmpty(temp.template_details.cemr_radiology) ? "" : temp.template_details.cemr_radiology;
                _temp.cemr_procedure = string.IsNullOrEmpty(temp.template_details.cemr_procedure) ? "" : temp.template_details.cemr_procedure;
                _temp.cemr_stgoals = string.IsNullOrEmpty(temp.template_details.cemr_stgoals) ? "" : temp.template_details.cemr_stgoals;
                _temp.cemr_ltgoals = string.IsNullOrEmpty(temp.template_details.cemr_ltgoals) ? "" : temp.template_details.cemr_ltgoals;
                _temp.cemr_followup = string.IsNullOrEmpty(temp.template_details.cemr_followup) ? "" : temp.template_details.cemr_followup;
                _temp.cemr_session = string.IsNullOrEmpty(temp.template_details.cemr_session) ? "" : temp.template_details.cemr_session;
                _temp.cemr_treatpoints = string.IsNullOrEmpty(temp.template_details.cemr_treatpoints) ? "" : temp.template_details.cemr_treatpoints;
                _temp.cemr_management = string.IsNullOrEmpty(temp.template_details.cemr_management) ? "" : temp.template_details.cemr_management;
                _temp.type1 = string.IsNullOrEmpty(temp.template_details.type1) ? "" : temp.template_details.type1;
                _temp.type2 = string.IsNullOrEmpty(temp.template_details.type2) ? "" : temp.template_details.type2;
                _temp.cemr_bodyimage = string.IsNullOrEmpty(temp.template_details.cemr_bodyimage) ? "" : temp.template_details.cemr_bodyimage;
                _temp.cemr_bodyimage2 = string.IsNullOrEmpty(temp.template_details.cemr_bodyimage2) ? "" : temp.template_details.cemr_bodyimage2;
                _temp.cemr_faceimage = string.IsNullOrEmpty(temp.template_details.cemr_faceimage) ? "" : temp.template_details.cemr_faceimage;
                _temp.cemr_bimage = string.IsNullOrEmpty(temp.template_details.cemr_bimage) ? "" : temp.template_details.cemr_bimage;
                _temp.cemr_bimage2 = string.IsNullOrEmpty(temp.template_details.cemr_bimage2) ? "" : temp.template_details.cemr_bimage2;
                _temp.cemr_bimage3 = string.IsNullOrEmpty(temp.template_details.cemr_bimage3) ? "" : temp.template_details.cemr_bimage3;
                _temp.cemr_type = string.IsNullOrEmpty(temp.template_details.cemr_type) ? "" : temp.template_details.cemr_type;
                _temp.cemr_type2 = string.IsNullOrEmpty(temp.template_details.cemr_type2) ? "" : temp.template_details.cemr_type2;
                _temp.cemr_followup_remarks = string.IsNullOrEmpty(temp.template_details.cemr_followup_remarks) ? "" : temp.template_details.cemr_followup_remarks;
                _temp.cemr_marking_notes = string.IsNullOrEmpty(temp.template_details.cemr_marking_notes) ? "" : temp.template_details.cemr_marking_notes;
                _temp.cemr_pain = temp.template_details.cemr_pain;
                _temp.cemr_madeby = madeby;

                if (type == 0)
                {
                    return ConsultationEMR.Generate_ConsultationEMRTemplate(_temp);
                }
                else if(type == 1)
                {
                    return ConsultationEMR.Generate_ConsultationEMRAppointment(_temp);
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public static int CreateTemplate(BusinessEntities.EMR.ConsultationEMRTemplate temp)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ConsultationEMR_Maintemplate_Insert");

                db.AddInParameter(dbCommand, "cemt_type", DbType.String, temp.cemt_type);
                db.AddInParameter(dbCommand, "cemt_type2", DbType.String, temp.cemt_type2);
                db.AddInParameter(dbCommand, "cemt_name", DbType.String, temp.cemt_name);
                db.AddInParameter(dbCommand, "cemt_madeby", DbType.Int32, temp.cemt_madeby);
                db.AddOutParameter(dbCommand, "cemtId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "cemtId").ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int Generate_ConsultationEMRTemplate(BusinessEntities.EMR.ConsultationEMR_Details _temp)
        {
            try
            {
                int epid = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ConsultationEMR_Insert");
                
                 db.AddInParameter(dbCommand, "cemr_bodyimage", DbType.String, _temp.cemr_bodyimage);
                 db.AddInParameter(dbCommand, "cemr_bodyimage2", DbType.String, _temp.cemr_bodyimage2);
                 db.AddInParameter(dbCommand, "cemr_faceimage", DbType.String, _temp.cemr_faceimage);
                
                db.AddInParameter(dbCommand, "cemr_cemtId", DbType.Int32, _temp.cemr_cemtId);
                db.AddInParameter(dbCommand, "cemr_complaint", DbType.String, _temp.cemr_complaint);
                db.AddInParameter(dbCommand, "cemr_pasthistory", DbType.String, _temp.cemr_pasthistory);
                db.AddInParameter(dbCommand, "cemr_checkvalue", DbType.String, _temp.cemr_checkvalue);
                db.AddInParameter(dbCommand, "cemr_mentalorianted", DbType.String, _temp.cemr_mentalorianted);
                db.AddInParameter(dbCommand, "cemr_mentaldisoriented", DbType.String, _temp.cemr_mentaldisoriented);
                db.AddInParameter(dbCommand, "cemr_mentalimpired", DbType.String, _temp.cemr_mentalimpired);
                db.AddInParameter(dbCommand, "cemr_mentalother", DbType.String, _temp.cemr_mentalother);
                db.AddInParameter(dbCommand, "cemr_acute1", DbType.String, _temp.cemr_acute1);
                db.AddInParameter(dbCommand, "cemr_subacute", DbType.String, _temp.cemr_subacute);
                db.AddInParameter(dbCommand, "cemr_chronic", DbType.String, _temp.cemr_chronic);
                db.AddInParameter(dbCommand, "cemr_recurrent", DbType.String, _temp.cemr_recurrent);
                db.AddInParameter(dbCommand, "cemr_durationin", DbType.String, _temp.cemr_durationin);
                db.AddInParameter(dbCommand, "cemr_gettingworse", DbType.String, _temp.cemr_gettingworse);
                db.AddInParameter(dbCommand, "cemr_better", DbType.String, _temp.cemr_better);
                db.AddInParameter(dbCommand, "cemr_stillsame", DbType.String, _temp.cemr_stillsame);
                db.AddInParameter(dbCommand, "cemr_bodyparts", DbType.String, _temp.cemr_bodyparts);
                db.AddInParameter(dbCommand, "cemr_observationins", DbType.String, _temp.cemr_observationins);
                db.AddInParameter(dbCommand, "cemr_palpation", DbType.String, _temp.cemr_palpation);
                db.AddInParameter(dbCommand, "cemr_rom", DbType.String, _temp.cemr_rom);
                db.AddInParameter(dbCommand, "cemr_mptest", DbType.String, _temp.cemr_mptest);
                db.AddInParameter(dbCommand, "cemr_stest", DbType.String, _temp.cemr_stest);
                db.AddInParameter(dbCommand, "cemr_reflexes", DbType.String, _temp.cemr_reflexes);
                db.AddInParameter(dbCommand, "cemr_dermatone", DbType.String, _temp.cemr_dermatone);
                db.AddInParameter(dbCommand, "cemr_myotome", DbType.String, _temp.cemr_myotome);
                db.AddInParameter(dbCommand, "cemr_independent", DbType.String, _temp.cemr_independent);
                db.AddInParameter(dbCommand, "cemr_dependent", DbType.String, _temp.cemr_dependent);
                db.AddInParameter(dbCommand, "cemr_crutches", DbType.String, _temp.cemr_crutches);
                db.AddInParameter(dbCommand, "cemr_walker", DbType.String, _temp.cemr_walker);
                db.AddInParameter(dbCommand, "cemr_wheelchair", DbType.String, _temp.cemr_wheelchair);
                db.AddInParameter(dbCommand, "cemr_active", DbType.String, _temp.cemr_active);
                db.AddInParameter(dbCommand, "cemr_athlete", DbType.String, _temp.cemr_athlete);
                db.AddInParameter(dbCommand, "cemr_lifestyle", DbType.String, _temp.cemr_lifestyle);
                db.AddInParameter(dbCommand, "cemr_bedridden", DbType.String, _temp.cemr_bedridden);
                db.AddInParameter(dbCommand, "cemr_radiology", DbType.String, _temp.cemr_radiology);
                db.AddInParameter(dbCommand, "cemr_procedure", DbType.String, _temp.cemr_procedure);
                db.AddInParameter(dbCommand, "cemr_stgoals", DbType.String, _temp.cemr_stgoals);
                db.AddInParameter(dbCommand, "cemr_ltgoals", DbType.String, _temp.cemr_ltgoals);
                db.AddInParameter(dbCommand, "cemr_followup", DbType.String, _temp.cemr_followup);
                db.AddInParameter(dbCommand, "cemr_session", DbType.String, _temp.cemr_session);
                db.AddInParameter(dbCommand, "cemr_treatpoints", DbType.String, _temp.cemr_treatpoints);
                db.AddInParameter(dbCommand, "cemr_management", DbType.String, _temp.cemr_management);
                db.AddInParameter(dbCommand, "cemr_pain", DbType.Int32, _temp.cemr_pain);
                db.AddInParameter(dbCommand, "cemr_madeby", DbType.Int32, _temp.cemr_madeby);
                db.AddInParameter(dbCommand, "cemr_type", DbType.String, _temp.cemr_type);
                db.AddInParameter(dbCommand, "cemr_type2", DbType.String, _temp.cemr_type2);
                db.AddInParameter(dbCommand, "cemr_followup_remarks", DbType.String, _temp.cemr_followup_remarks);
                db.AddInParameter(dbCommand, "cemr_marking_notes", DbType.String, _temp.cemr_marking_notes);
                db.AddOutParameter(dbCommand, "cemrId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);
                epid = Convert.ToInt32(db.GetParameterValue(dbCommand, "cemrId").ToString());
                return epid;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int Generate_ConsultationEMRAppointment(BusinessEntities.EMR.ConsultationEMR_Details _temp)
        {
            try
            {
                int epid = 0;
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_ConsultationEMR_Appointment_Insert");

                db.AddInParameter(dbCommand, "cemr_bodyimage", DbType.String, _temp.cemr_bodyimage);
                db.AddInParameter(dbCommand, "cemr_bodyimage2", DbType.String, _temp.cemr_bodyimage2);
                db.AddInParameter(dbCommand, "cemr_faceimage", DbType.String, _temp.cemr_faceimage);

                db.AddInParameter(dbCommand, "cemr_appId", DbType.Int32, _temp.cemr_appId);
                db.AddInParameter(dbCommand, "cemr_cemtId", DbType.Int32, _temp.cemr_cemtId);
                db.AddInParameter(dbCommand, "cemr_complaint", DbType.String, _temp.cemr_complaint);
                db.AddInParameter(dbCommand, "cemr_pasthistory", DbType.String, _temp.cemr_pasthistory);
                db.AddInParameter(dbCommand, "cemr_checkvalue", DbType.String, _temp.cemr_checkvalue);
                db.AddInParameter(dbCommand, "cemr_mentalorianted", DbType.String, _temp.cemr_mentalorianted);
                db.AddInParameter(dbCommand, "cemr_mentaldisoriented", DbType.String, _temp.cemr_mentaldisoriented);
                db.AddInParameter(dbCommand, "cemr_mentalimpired", DbType.String, _temp.cemr_mentalimpired);
                db.AddInParameter(dbCommand, "cemr_mentalother", DbType.String, _temp.cemr_mentalother);
                db.AddInParameter(dbCommand, "cemr_acute1", DbType.String, _temp.cemr_acute1);
                db.AddInParameter(dbCommand, "cemr_subacute", DbType.String, _temp.cemr_subacute);
                db.AddInParameter(dbCommand, "cemr_chronic", DbType.String, _temp.cemr_chronic);
                db.AddInParameter(dbCommand, "cemr_recurrent", DbType.String, _temp.cemr_recurrent);
                db.AddInParameter(dbCommand, "cemr_durationin", DbType.String, _temp.cemr_durationin);
                db.AddInParameter(dbCommand, "cemr_gettingworse", DbType.String, _temp.cemr_gettingworse);
                db.AddInParameter(dbCommand, "cemr_better", DbType.String, _temp.cemr_better);
                db.AddInParameter(dbCommand, "cemr_stillsame", DbType.String, _temp.cemr_stillsame);
                db.AddInParameter(dbCommand, "cemr_bodyparts", DbType.String, _temp.cemr_bodyparts);
                db.AddInParameter(dbCommand, "cemr_observationins", DbType.String, _temp.cemr_observationins);
                db.AddInParameter(dbCommand, "cemr_palpation", DbType.String, _temp.cemr_palpation);
                db.AddInParameter(dbCommand, "cemr_rom", DbType.String, _temp.cemr_rom);
                db.AddInParameter(dbCommand, "cemr_mptest", DbType.String, _temp.cemr_mptest);
                db.AddInParameter(dbCommand, "cemr_stest", DbType.String, _temp.cemr_stest);
                db.AddInParameter(dbCommand, "cemr_reflexes", DbType.String, _temp.cemr_reflexes);
                db.AddInParameter(dbCommand, "cemr_dermatone", DbType.String, _temp.cemr_dermatone);
                db.AddInParameter(dbCommand, "cemr_myotome", DbType.String, _temp.cemr_myotome);
                db.AddInParameter(dbCommand, "cemr_independent", DbType.String, _temp.cemr_independent);
                db.AddInParameter(dbCommand, "cemr_dependent", DbType.String, _temp.cemr_dependent);
                db.AddInParameter(dbCommand, "cemr_crutches", DbType.String, _temp.cemr_crutches);
                db.AddInParameter(dbCommand, "cemr_walker", DbType.String, _temp.cemr_walker);
                db.AddInParameter(dbCommand, "cemr_wheelchair", DbType.String, _temp.cemr_wheelchair);
                db.AddInParameter(dbCommand, "cemr_active", DbType.String, _temp.cemr_active);
                db.AddInParameter(dbCommand, "cemr_athlete", DbType.String, _temp.cemr_athlete);
                db.AddInParameter(dbCommand, "cemr_lifestyle", DbType.String, _temp.cemr_lifestyle);
                db.AddInParameter(dbCommand, "cemr_bedridden", DbType.String, _temp.cemr_bedridden);
                db.AddInParameter(dbCommand, "cemr_radiology", DbType.String, _temp.cemr_radiology);
                db.AddInParameter(dbCommand, "cemr_procedure", DbType.String, _temp.cemr_procedure);
                db.AddInParameter(dbCommand, "cemr_stgoals", DbType.String, _temp.cemr_stgoals);
                db.AddInParameter(dbCommand, "cemr_ltgoals", DbType.String, _temp.cemr_ltgoals);
                db.AddInParameter(dbCommand, "cemr_followup", DbType.String, _temp.cemr_followup);
                db.AddInParameter(dbCommand, "cemr_session", DbType.String, _temp.cemr_session);
                db.AddInParameter(dbCommand, "cemr_treatpoints", DbType.String, _temp.cemr_treatpoints);
                db.AddInParameter(dbCommand, "cemr_management", DbType.String, _temp.cemr_management);
                db.AddInParameter(dbCommand, "cemr_pain", DbType.Int32, _temp.cemr_pain);
                db.AddInParameter(dbCommand, "cemr_madeby", DbType.Int32, _temp.cemr_madeby);
                db.AddInParameter(dbCommand, "cemr_type", DbType.String, _temp.cemr_type);
                db.AddInParameter(dbCommand, "cemr_type2", DbType.String, _temp.cemr_type2);
                db.AddInParameter(dbCommand, "cemr_followup_remarks", DbType.String, _temp.cemr_followup_remarks);
                db.AddInParameter(dbCommand, "cemr_marking_notes", DbType.String, _temp.cemr_marking_notes);
                db.AddOutParameter(dbCommand, "cemrId", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);
                epid = Convert.ToInt32(db.GetParameterValue(dbCommand, "cemrId").ToString());
                return epid;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public static DataTable GetAppointmentConsultation(int? appId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetConsultationAppInfo");
                
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
       
        public static DataTable GetPreAppointmentConsultation(int? appId,int patId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetPreConsultationAppInfo");
                
                if (appId > 0)
                {
                    db.AddInParameter(dbCommand, "appId", DbType.Int32, appId);
                }
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

        public static int DeleteConsultationEMR(int cemrId, int cemr_madeby)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ConsultationEMR_Appdelete");

                db.AddInParameter(dbCommand, "cemrId", DbType.Int32, cemrId);
                db.AddInParameter(dbCommand, "cemr_madeby", DbType.Int32, cemr_madeby);
                int result = db.ExecuteNonQuery(dbCommand);
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Update_ConsultationEMR(BusinessEntities.EMR.ConsultationEMR_Details _temp)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_ConsultationEMR_Appointment_Update");
                
                db.AddInParameter(dbCommand, "cemrId", DbType.Int32, _temp.cemrId);
                db.AddInParameter(dbCommand, "cemr_appId", DbType.Int32, _temp.cemr_appId);
                db.AddInParameter(dbCommand, "cemr_cemtId", DbType.Int32, _temp.cemr_cemtId);
                db.AddInParameter(dbCommand, "cemr_complaint", DbType.String, _temp.cemr_complaint);
                db.AddInParameter(dbCommand, "cemr_pasthistory", DbType.String, _temp.cemr_pasthistory);
                db.AddInParameter(dbCommand, "cemr_checkvalue", DbType.String, _temp.cemr_checkvalue);
                db.AddInParameter(dbCommand, "cemr_mentalorianted", DbType.String, _temp.cemr_mentalorianted);
                db.AddInParameter(dbCommand, "cemr_mentaldisoriented", DbType.String, _temp.cemr_mentaldisoriented);
                db.AddInParameter(dbCommand, "cemr_mentalimpired", DbType.String, _temp.cemr_mentalimpired);
                db.AddInParameter(dbCommand, "cemr_mentalother", DbType.String, _temp.cemr_mentalother);
                db.AddInParameter(dbCommand, "cemr_acute1", DbType.String, _temp.cemr_acute1);
                db.AddInParameter(dbCommand, "cemr_subacute", DbType.String, _temp.cemr_subacute);
                db.AddInParameter(dbCommand, "cemr_chronic", DbType.String, _temp.cemr_chronic);
                db.AddInParameter(dbCommand, "cemr_recurrent", DbType.String, _temp.cemr_recurrent);
                db.AddInParameter(dbCommand, "cemr_durationin", DbType.String, _temp.cemr_durationin);
                db.AddInParameter(dbCommand, "cemr_gettingworse", DbType.String, _temp.cemr_gettingworse);
                db.AddInParameter(dbCommand, "cemr_better", DbType.String, _temp.cemr_better);
                db.AddInParameter(dbCommand, "cemr_stillsame", DbType.String, _temp.cemr_stillsame);
                db.AddInParameter(dbCommand, "cemr_bodyparts", DbType.String, _temp.cemr_bodyparts);
                db.AddInParameter(dbCommand, "cemr_observationins", DbType.String, _temp.cemr_observationins);
                db.AddInParameter(dbCommand, "cemr_palpation", DbType.String, _temp.cemr_palpation);
                db.AddInParameter(dbCommand, "cemr_rom", DbType.String, _temp.cemr_rom);
                db.AddInParameter(dbCommand, "cemr_mptest", DbType.String, _temp.cemr_mptest);
                db.AddInParameter(dbCommand, "cemr_stest", DbType.String, _temp.cemr_stest);
                db.AddInParameter(dbCommand, "cemr_reflexes", DbType.String, _temp.cemr_reflexes);
                db.AddInParameter(dbCommand, "cemr_dermatone", DbType.String, _temp.cemr_dermatone);
                db.AddInParameter(dbCommand, "cemr_myotome", DbType.String, _temp.cemr_myotome);
                db.AddInParameter(dbCommand, "cemr_independent", DbType.String, _temp.cemr_independent);
                db.AddInParameter(dbCommand, "cemr_dependent", DbType.String, _temp.cemr_dependent);
                db.AddInParameter(dbCommand, "cemr_crutches", DbType.String, _temp.cemr_crutches);
                db.AddInParameter(dbCommand, "cemr_walker", DbType.String, _temp.cemr_walker);
                db.AddInParameter(dbCommand, "cemr_wheelchair", DbType.String, _temp.cemr_wheelchair);
                db.AddInParameter(dbCommand, "cemr_active", DbType.String, _temp.cemr_active);
                db.AddInParameter(dbCommand, "cemr_athlete", DbType.String, _temp.cemr_athlete);
                db.AddInParameter(dbCommand, "cemr_lifestyle", DbType.String, _temp.cemr_lifestyle);
                db.AddInParameter(dbCommand, "cemr_bedridden", DbType.String, _temp.cemr_bedridden);
                db.AddInParameter(dbCommand, "cemr_radiology", DbType.String, _temp.cemr_radiology);
                db.AddInParameter(dbCommand, "cemr_procedure", DbType.String, _temp.cemr_procedure);
                db.AddInParameter(dbCommand, "cemr_stgoals", DbType.String, _temp.cemr_stgoals);
                db.AddInParameter(dbCommand, "cemr_ltgoals", DbType.String, _temp.cemr_ltgoals);
                db.AddInParameter(dbCommand, "cemr_followup", DbType.String, _temp.cemr_followup);
                db.AddInParameter(dbCommand, "cemr_session", DbType.String, _temp.cemr_session);
                db.AddInParameter(dbCommand, "cemr_treatpoints", DbType.String, _temp.cemr_treatpoints);
                db.AddInParameter(dbCommand, "cemr_management", DbType.String, _temp.cemr_management);
                db.AddInParameter(dbCommand, "cemr_pain", DbType.Int32, _temp.cemr_pain);
                db.AddInParameter(dbCommand, "cemr_madeby", DbType.Int32, _temp.cemr_madeby);
                db.AddInParameter(dbCommand, "cemr_bodyimage", DbType.String, _temp.cemr_bodyimage);
                db.AddInParameter(dbCommand, "cemr_bodyimage2", DbType.String, _temp.cemr_bodyimage2);
                db.AddInParameter(dbCommand, "cemr_faceimage", DbType.String, _temp.cemr_faceimage);
                db.AddInParameter(dbCommand, "cemr_type", DbType.String, _temp.cemr_type);
                db.AddInParameter(dbCommand, "cemr_type2", DbType.String, _temp.cemr_type2);
                db.AddInParameter(dbCommand, "cemr_followup_remarks", DbType.String, _temp.cemr_followup_remarks);
                db.AddInParameter(dbCommand, "cemr_marking_notes", DbType.String, _temp.cemr_marking_notes);

                int val = db.ExecuteNonQuery(dbCommand);
                return val;

                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }

    
}
