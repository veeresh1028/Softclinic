using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class ConsultationEMR_Main
    {        
        public ConsultationEMR template_info { get; set; }
        public ConsultationEMRTemplate template { get; set; } 
        public ConsultationEMR_Details template_details { get; set; }
        public List<PatientDiagnosis> diagnosis_items { get; set; }
        public List<LaserMarking> cupping { get; set; }
    }
    public class ConsultationEMRTemplate
    {
        public int cemtId { get; set; }
        public string cemt_type { get; set; }
        public string cemt_type2 { get; set; }
        public string cemt_name { get; set; }
        public string cemt_status { get; set; }
        public int cemt_madeby { get; set; }
        
    }
    public class ConsultationEMR
    {
        public int appId { get; set; }
        public string app_type { get; set; }
        public string consultation { get; set; }
        public string app_status { get; set; }
        public string app_comments { get; set; }
        public string consultationtype { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public string doc_name { get; set; }
        public string app_fdate { get; set; }
        public string app_resnforvisit { get; set; }

    }
    public class ConsultationEMR_Details
    {
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public int cemrId { get; set; }
        public int cemr_cemtId { get; set; }
        public int cemr_appId { get; set; }
        public string cemr_complaint { get; set; }
        public string cemr_pasthistory { get; set; }
        public string cemr_checkvalue { get; set; }
        public string cemr_mentalorianted { get; set; }
        public string cemr_mentaldisoriented { get; set; }
        public string cemr_mentalimpired { get; set; }
        public string cemr_mentalother { get; set; }
        public string cemr_durationin { get; set; }
        public int cemr_pain { get; set; }
        public string cemr_acute1 { get; set; }
        public string cemr_subacute { get; set; }
        public string cemr_chronic { get; set; }
        public string cemr_recurrent { get; set; }
        public string cemr_gettingworse { get; set; }
        public string cemr_better { get; set; }
        public string cemr_stillsame { get; set; }
        public string cemr_bodyparts { get; set; }
        public string cemr_observationins { get; set; }
        public string cemr_palpation { get; set; }
        public string cemr_rom { get; set; }
        public string cemr_mptest { get; set; }
        public string cemr_stest { get; set; }
        public string cemr_reflexes { get; set; }
        public string cemr_dermatone { get; set; }
        public string cemr_myotome { get; set; }
        public string cemr_independent { get; set; }
        public string cemr_dependent { get; set; }
        public string cemr_crutches { get; set; }
        public string cemr_walker { get; set; }
        public string cemr_wheelchair { get; set; }
        public string cemr_active { get; set; }
        public string cemr_athlete { get; set; }
        public string cemr_lifestyle { get; set; }
        public string cemr_bedridden { get; set; }
        public string cemr_radiology { get; set; }
        public string cemr_procedure { get; set; }
        public string cemr_stgoals { get; set; }
        public string cemr_ltgoals { get; set; }
        public string cemr_followup { get; set; }
        public string cemr_session { get; set; }
        public string cemr_treatpoints { get; set; }
        public string cemr_management { get; set; }
        public int cemr_madeby { get; set; }

        public string pad_diagnosis { get; set; }
        public string pad_notes { get; set; }
        public string pad_year { get; set; }

        public string type1 { get; set; }
        public string type2 { get; set; }
        public string cemt_type { get; set; }
        public string cemr_bodyimage { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string cemr_bimage { get; set; }

        //New Fields
        public string cemt_type2 { get; set; }
        public string cemr_bodyimage2 { get; set; }
        public string image2 { get; set; }
        [AllowHtml]
        public string cemr_bimage2 { get; set; }
        public string cemr_faceimage { get; set; }
        public string image3 { get; set; }
        [AllowHtml]
        public string cemr_bimage3 { get; set; }

        public string cemr_type { get; set; }
        public string cemr_type2 { get; set; }
        public string cemr_followup_remarks { get; set; }
        public string cemr_marking_notes { get; set; }
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string app_resnforvisit { get; set; }
        public string app_status { get; set; }
    }
}
