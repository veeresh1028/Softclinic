using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLogicLayer.EMR
{
    public class ConsultationEMR
    {
        public static BusinessEntities.EMR.ConsultationEMR GetConsultationEMR(int? appId)
        {
            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetConsultationEMR(appId);

            BusinessEntities.EMR.ConsultationEMR info = new BusinessEntities.EMR.ConsultationEMR();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                info.appId = Convert.ToInt32(dr["appId"]);
                info.consultation = dr["pat_code"].ToString() + " - " + dr["pat_name"].ToString() + " - " + dr["app_fdate_time"].ToString();
                info.app_status = dr["app_status"].ToString();
                info.app_comments = dr["app_comments"].ToString();
                info.app_type = dr["app_type"].ToString();
                info.consultationtype = "Consultation" + " - " + dr["emp_dept_name"].ToString();
                info.starttime = dr["app_doc_ftime"].ToString();
                info.endtime = dr["app_doc_ttime"].ToString();
                info.doc_name = dr["doc_name"].ToString();
                info.app_fdate = dr["app_fdate"].ToString();
                info.app_resnforvisit = dr["app_resnforvisit"].ToString();
                
            }

           

            return info;
        }

        public static BusinessEntities.EMR.ConsultationEMRTemplate GetConsultationTemplateEMR(int? appId)
        {
            ConsultationEMRTemplate _temp = new ConsultationEMRTemplate();

            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetConsultationTemplateEMR(appId);
            
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                _temp.cemtId = DataValidation.isIntValid(r["cemtId"].ToString());
                _temp.cemt_type = r["cemt_type"].ToString();
                _temp.cemt_type2 = r["cemt_type2"].ToString();
                _temp.cemt_name = r["cemt_name"].ToString();
                _temp.cemt_status = r["cemt_status"].ToString();
                _temp.cemt_madeby = DataValidation.isIntValid(r["cemt_madeby"].ToString());
            }

            return _temp;
        }
        public static BusinessEntities.EMR.ConsultationEMR_Details GetAppointmentConsultationEMR(int? appId)
        {
            ConsultationEMR_Details _data = new ConsultationEMR_Details();

            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetConsultationTemplateEMR(appId);
            
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                _data.cemr_cemtId = int.Parse(dr["cemr_cemtId"].ToString());
                _data.cemr_complaint = dr["cemr_complaint"].ToString();
                _data.cemr_pasthistory = dr["cemr_pasthistory"].ToString();
                _data.cemr_checkvalue = dr["cemr_checkvalue"].ToString();
                _data.cemr_mentalorianted = dr["cemr_mentalorianted"].ToString();
                _data.cemr_mentaldisoriented = dr["cemr_mentaldisoriented"].ToString();
                _data.cemr_mentalimpired = dr["cemr_mentalimpired"].ToString();
                _data.cemr_mentalother = dr["cemr_mentalother"].ToString();
                _data.cemr_acute1 = dr["cemr_acute1"].ToString();
                _data.cemr_subacute = dr["cemr_subacute"].ToString();
                _data.cemr_chronic = dr["cemr_chronic"].ToString();
                _data.cemr_recurrent = dr["cemr_recurrent"].ToString();
                _data.cemr_durationin = dr["cemr_durationin"].ToString();
                _data.cemr_gettingworse = dr["cemr_gettingworse"].ToString();
                _data.cemr_better = dr["cemr_better"].ToString();
                _data.cemr_stillsame = dr["cemr_stillsame"].ToString();
                _data.cemr_bodyparts = dr["cemr_bodyparts"].ToString();
                _data.cemr_observationins = dr["cemr_observationins"].ToString();
                _data.cemr_palpation = dr["cemr_palpation"].ToString();
                _data.cemr_rom = dr["cemr_rom"].ToString();
                _data.cemr_mptest = dr["cemr_mptest"].ToString();
                _data.cemr_stest = dr["cemr_stest"].ToString();
                _data.cemr_reflexes = dr["cemr_reflexes"].ToString();
                _data.cemr_dermatone = dr["cemr_dermatone"].ToString();
                _data.cemr_myotome = dr["cemr_myotome"].ToString();
                _data.cemr_independent = dr["cemr_independent"].ToString();
                _data.cemr_dependent = dr["cemr_dependent"].ToString();
                _data.cemr_crutches = dr["cemr_crutches"].ToString();
                _data.cemr_walker = dr["cemr_walker"].ToString();
                _data.cemr_wheelchair = dr["cemr_wheelchair"].ToString();
                _data.cemr_active = dr["cemr_active"].ToString();
                _data.cemr_athlete = dr["cemr_athlete"].ToString();
                _data.cemr_lifestyle = dr["cemr_lifestyle"].ToString();
                _data.cemr_bedridden = dr["cemr_bedridden"].ToString();
                _data.cemr_radiology = dr["cemr_radiology"].ToString();
                _data.cemr_procedure = dr["cemr_procedure"].ToString();
                _data.cemr_stgoals = dr["cemr_stgoals"].ToString();
                _data.cemr_ltgoals = dr["cemr_ltgoals"].ToString();
                _data.cemr_followup = dr["cemr_followup"].ToString();
                _data.cemr_session = dr["cemr_session"].ToString();
                _data.cemr_treatpoints = dr["cemr_treatpoints"].ToString();
                _data.cemr_management = dr["cemr_management"].ToString();
                _data.cemt_type = dr["cemt_type"].ToString();
                _data.cemr_bodyimage = dr["cemr_bodyimage"].ToString();
                _data.cemr_bodyimage2 = dr["cemr_bodyimage2"].ToString();
                _data.cemr_faceimage = dr["cemr_faceimage"].ToString();
                _data.cemr_pain = int.Parse(dr["cemr_pain"].ToString());
                _data.cemr_type = dr["cemr_type"].ToString();
                _data.cemr_type2 = dr["cemr_type2"].ToString();
                _data.cemr_followup_remarks = dr["cemr_followup_remarks"].ToString();
                _data.cemr_marking_notes = dr["cemr_marking_notes"].ToString();

                
            }

            return _data;
        }


        public static List<CommonDDL> GetTemplates(string query)
        {
            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetTemplates(query);
            List<CommonDDL> data = new List<CommonDDL>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;

        }

        public static ConsultationEMR_Details GetConsultationEMRTemplate(int cemtId )
        {
            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetConsultationEMRTemplate(cemtId);
            DataRow dr = dt.Rows[0];

            ConsultationEMR_Details _data = new ConsultationEMR_Details();
            _data.cemr_cemtId = int.Parse(dr["cemr_cemtId"].ToString());
            _data.cemr_complaint = dr["cemr_complaint"].ToString();
            _data.cemr_pasthistory = dr["cemr_pasthistory"].ToString();
            _data.cemr_checkvalue = dr["cemr_checkvalue"].ToString();
            _data.cemr_mentalorianted = dr["cemr_mentalorianted"].ToString();
            _data.cemr_mentaldisoriented = dr["cemr_mentaldisoriented"].ToString();
            _data.cemr_mentalimpired = dr["cemr_mentalimpired"].ToString();
            _data.cemr_mentalother = dr["cemr_mentalother"].ToString();
            _data.cemr_acute1 = dr["cemr_acute1"].ToString();
            _data.cemr_subacute = dr["cemr_subacute"].ToString();
            _data.cemr_chronic = dr["cemr_chronic"].ToString();
            _data.cemr_recurrent = dr["cemr_recurrent"].ToString();
            _data.cemr_durationin = dr["cemr_durationin"].ToString();
            _data.cemr_gettingworse = dr["cemr_gettingworse"].ToString();
            _data.cemr_better = dr["cemr_better"].ToString();
            _data.cemr_stillsame = dr["cemr_stillsame"].ToString();
            _data.cemr_bodyparts = dr["cemr_bodyparts"].ToString();
            _data.cemr_observationins = dr["cemr_observationins"].ToString();
            _data.cemr_palpation = dr["cemr_palpation"].ToString();
            _data.cemr_rom = dr["cemr_rom"].ToString();
            _data.cemr_mptest = dr["cemr_mptest"].ToString();
            _data.cemr_stest = dr["cemr_stest"].ToString();
            _data.cemr_reflexes = dr["cemr_reflexes"].ToString();
            _data.cemr_dermatone = dr["cemr_dermatone"].ToString();
            _data.cemr_myotome = dr["cemr_myotome"].ToString();
            _data.cemr_independent = dr["cemr_independent"].ToString();
            _data.cemr_dependent = dr["cemr_dependent"].ToString();
            _data.cemr_crutches = dr["cemr_crutches"].ToString();
            _data.cemr_walker = dr["cemr_walker"].ToString();
            _data.cemr_wheelchair = dr["cemr_wheelchair"].ToString();
            _data.cemr_active = dr["cemr_active"].ToString();
            _data.cemr_athlete = dr["cemr_athlete"].ToString();
            _data.cemr_lifestyle = dr["cemr_lifestyle"].ToString();
            _data.cemr_bedridden = dr["cemr_bedridden"].ToString();
            _data.cemr_radiology = dr["cemr_radiology"].ToString();
            _data.cemr_procedure = dr["cemr_procedure"].ToString();
            _data.cemr_stgoals = dr["cemr_stgoals"].ToString();
            _data.cemr_ltgoals = dr["cemr_ltgoals"].ToString();
            _data.cemr_followup = dr["cemr_followup"].ToString();
            _data.cemr_session = dr["cemr_session"].ToString();
            _data.cemr_treatpoints = dr["cemr_treatpoints"].ToString();
            _data.cemr_management = dr["cemr_management"].ToString();
            _data.cemt_type = dr["cemt_type"].ToString();
            _data.cemr_bodyimage = dr["cemr_bodyimage"].ToString();
            _data.cemr_bodyimage2 = dr["cemr_bodyimage2"].ToString();
            _data.cemr_faceimage = dr["cemr_faceimage"].ToString();
            _data.cemr_pain = int.Parse(dr["cemr_pain"].ToString());
            _data.cemr_type = dr["cemr_type"].ToString();
            _data.cemr_type2 = dr["cemr_type2"].ToString();
            _data.cemr_followup_remarks = dr["cemr_followup_remarks"].ToString();
            _data.cemr_marking_notes = dr["cemr_marking_notes"].ToString();

            return _data;
        }

        public static int Generate_ConsultationEMR(BusinessEntities.EMR.ConsultationEMR_Main temp, int madeby, out string inv_no)
        {
            return DataAccessLayer.EMR.ConsultationEMR.Generate_ConsultationEMR(temp, madeby, out inv_no);

        }

        public static List<BusinessEntities.EMR.ConsultationEMR_Details> GetAppointmentConsultation(int? appId)
        {
            List<BusinessEntities.EMR.ConsultationEMR_Details> sclist = new List<BusinessEntities.EMR.ConsultationEMR_Details>();
            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetAppointmentConsultation(appId);


            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ConsultationEMR_Details
                {
                    cemrId = int.Parse(dr["cemrId"].ToString()),
                    cemr_cemtId = int.Parse(dr["cemr_cemtId"].ToString()),
                    cemr_complaint = dr["cemr_complaint"].ToString(),
                    cemr_pasthistory = dr["cemr_pasthistory"].ToString(),
                    cemr_checkvalue = dr["cemr_checkvalue"].ToString(),
                    cemr_mentalorianted = dr["cemr_mentalorianted"].ToString(),
                    cemr_mentaldisoriented = dr["cemr_mentaldisoriented"].ToString(),
                    cemr_mentalimpired = dr["cemr_mentalimpired"].ToString(),
                    cemr_mentalother = dr["cemr_mentalother"].ToString(),
                    cemr_acute1 = dr["cemr_acute1"].ToString(),
                    cemr_subacute = dr["cemr_subacute"].ToString(),
                    cemr_chronic = dr["cemr_chronic"].ToString(),
                    cemr_recurrent = dr["cemr_recurrent"].ToString(),
                    cemr_durationin = dr["cemr_durationin"].ToString(),
                    cemr_gettingworse = dr["cemr_gettingworse"].ToString(),
                    cemr_better = dr["cemr_better"].ToString(),
                    cemr_stillsame = dr["cemr_stillsame"].ToString(),
                    cemr_bodyparts = dr["cemr_bodyparts"].ToString(),
                    cemr_observationins = dr["cemr_observationins"].ToString(),
                    cemr_palpation = dr["cemr_palpation"].ToString(),
                    cemr_rom = dr["cemr_rom"].ToString(),
                    cemr_mptest = dr["cemr_mptest"].ToString(),
                    cemr_stest = dr["cemr_stest"].ToString(),
                    cemr_reflexes = dr["cemr_reflexes"].ToString(),
                    cemr_dermatone = dr["cemr_dermatone"].ToString(),
                    cemr_myotome = dr["cemr_myotome"].ToString(),
                    cemr_independent = dr["cemr_independent"].ToString(),
                    cemr_dependent = dr["cemr_dependent"].ToString(),
                    cemr_crutches = dr["cemr_crutches"].ToString(),
                    cemr_walker = dr["cemr_walker"].ToString(),
                    cemr_wheelchair = dr["cemr_wheelchair"].ToString(),
                    cemr_active = dr["cemr_active"].ToString(),
                    cemr_athlete = dr["cemr_athlete"].ToString(),
                    cemr_lifestyle = dr["cemr_lifestyle"].ToString(),
                    cemr_bedridden = dr["cemr_bedridden"].ToString(),
                    cemr_radiology = dr["cemr_radiology"].ToString(),
                    cemr_procedure = dr["cemr_procedure"].ToString(),
                    cemr_stgoals = dr["cemr_stgoals"].ToString(),
                    cemr_ltgoals = dr["cemr_ltgoals"].ToString(),
                    cemr_followup = dr["cemr_followup"].ToString(),
                    cemr_session = dr["cemr_session"].ToString(),
                    cemr_treatpoints = dr["cemr_treatpoints"].ToString(),
                    cemr_management = dr["cemr_management"].ToString(),
                    cemt_type = dr["cemt_type"].ToString(),
                    cemr_bodyimage = dr["cemr_bodyimage"].ToString(),
                    cemr_bodyimage2 = dr["cemr_bodyimage2"].ToString(),
                    cemr_faceimage = dr["cemr_faceimage"].ToString(),
                    cemr_pain = int.Parse(dr["cemr_pain"].ToString()),
                    cemr_type = dr["cemr_type"].ToString(),
                    cemr_type2 = dr["cemr_type2"].ToString(),
                    cemr_followup_remarks = dr["cemr_followup_remarks"].ToString(),
                    cemr_marking_notes = dr["cemr_marking_notes"].ToString()
                });
            }
            return sclist;
        }

        
        public static List<BusinessEntities.EMR.ConsultationEMR_Details> GetPreAppointmentConsultation(int? appId,int patId)
        {
            List<BusinessEntities.EMR.ConsultationEMR_Details> sclist = new List<BusinessEntities.EMR.ConsultationEMR_Details>();
            DataTable dt = DataAccessLayer.EMR.ConsultationEMR.GetPreAppointmentConsultation(appId,patId);


            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.EMR.ConsultationEMR_Details
                {
                    cemrId = int.Parse(dr["cemrId"].ToString()),
                    cemr_appId = int.Parse(dr["cemr_appId"].ToString()),
                    cemr_cemtId = int.Parse(dr["cemr_cemtId"].ToString()),
                    cemr_complaint = dr["cemr_complaint"].ToString(),
                    cemr_pasthistory = dr["cemr_pasthistory"].ToString(),
                    cemr_checkvalue = dr["cemr_checkvalue"].ToString(),
                    cemr_mentalorianted = dr["cemr_mentalorianted"].ToString(),
                    cemr_mentaldisoriented = dr["cemr_mentaldisoriented"].ToString(),
                    cemr_mentalimpired = dr["cemr_mentalimpired"].ToString(),
                    cemr_mentalother = dr["cemr_mentalother"].ToString(),
                    cemr_acute1 = dr["cemr_acute1"].ToString(),
                    cemr_subacute = dr["cemr_subacute"].ToString(),
                    cemr_chronic = dr["cemr_chronic"].ToString(),
                    cemr_recurrent = dr["cemr_recurrent"].ToString(),
                    cemr_durationin = dr["cemr_durationin"].ToString(),
                    cemr_gettingworse = dr["cemr_gettingworse"].ToString(),
                    cemr_better = dr["cemr_better"].ToString(),
                    cemr_stillsame = dr["cemr_stillsame"].ToString(),
                    cemr_bodyparts = dr["cemr_bodyparts"].ToString(),
                    cemr_observationins = dr["cemr_observationins"].ToString(),
                    cemr_palpation = dr["cemr_palpation"].ToString(),
                    cemr_rom = dr["cemr_rom"].ToString(),
                    cemr_mptest = dr["cemr_mptest"].ToString(),
                    cemr_stest = dr["cemr_stest"].ToString(),
                    cemr_reflexes = dr["cemr_reflexes"].ToString(),
                    cemr_dermatone = dr["cemr_dermatone"].ToString(),
                    cemr_myotome = dr["cemr_myotome"].ToString(),
                    cemr_independent = dr["cemr_independent"].ToString(),
                    cemr_dependent = dr["cemr_dependent"].ToString(),
                    cemr_crutches = dr["cemr_crutches"].ToString(),
                    cemr_walker = dr["cemr_walker"].ToString(),
                    cemr_wheelchair = dr["cemr_wheelchair"].ToString(),
                    cemr_active = dr["cemr_active"].ToString(),
                    cemr_athlete = dr["cemr_athlete"].ToString(),
                    cemr_lifestyle = dr["cemr_lifestyle"].ToString(),
                    cemr_bedridden = dr["cemr_bedridden"].ToString(),
                    cemr_radiology = dr["cemr_radiology"].ToString(),
                    cemr_procedure = dr["cemr_procedure"].ToString(),
                    cemr_stgoals = dr["cemr_stgoals"].ToString(),
                    cemr_ltgoals = dr["cemr_ltgoals"].ToString(),
                    cemr_followup = dr["cemr_followup"].ToString(),
                    cemr_session = dr["cemr_session"].ToString(),
                    cemr_treatpoints = dr["cemr_treatpoints"].ToString(),
                    cemr_management = dr["cemr_management"].ToString(),
                    cemt_type = dr["cemt_type"].ToString(),
                    cemr_bodyimage = dr["cemr_bodyimage"].ToString(),
                    cemr_bodyimage2 = dr["cemr_bodyimage2"].ToString(),
                    cemr_faceimage = dr["cemr_faceimage"].ToString(),
                    cemr_pain = int.Parse(dr["cemr_pain"].ToString()),
                    cemr_type = dr["cemr_type"].ToString(),
                    cemr_type2 = dr["cemr_type2"].ToString(),
                    cemr_followup_remarks = dr["cemr_followup_remarks"].ToString(),
                    cemr_marking_notes = dr["cemr_marking_notes"].ToString(),
                    doctor_name = dr["doctor_name"].ToString(),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"].ToString()),
                });
            }
            return sclist;
        }

        

        public static int Update_ConsultationEMR(BusinessEntities.EMR.ConsultationEMR_Details temp)
        {
            return DataAccessLayer.EMR.ConsultationEMR.Update_ConsultationEMR(temp);

        }
        public static int DeleteConsultationEMR(int cemrId, int cemr_madeby)
        {
            return DataAccessLayer.EMR.ConsultationEMR.DeleteConsultationEMR(cemrId, cemr_madeby);
        }
    }
}
