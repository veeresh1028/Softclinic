using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.KPIReports
{

    public class AuditLogsInfo
    {
        public AppointmentAuditLogsKPI auditLogs { get; set; }
        public AllergiesAuditLogsKPI allergiesLogs { get; set; }
        public VitalSignsAuditLogsKPI vitalLogs { get; set; }
        public PastHistoryAuditLogs pfaLogs { get; set; }
        public CheifComplaintsAuditLogs complaintLogs { get; set; }
        public HPIAudit hpiLogs { get; set; }
        public ROSAudit rosLogs { get; set; }
        public NurseNotesAudit nusenoteLogs { get; set; }
        public NarrativeDiagnosisAudit narrativeLogs { get; set; }
        public PatDiagnosisAudit patdiagLogs { get; set; }
        public AddendumAudit addendumLogs { get; set; }
        public ProgressNotesAudit progressnoteLogs { get; set; }
        public PatientTreatmentAudit treatmentLogs { get; set; }
        public AuditLogsReport summary { get; set; }
    }

    public class AuditLogsReport
    {
        public int appId { get; set; }
        public List<AppointmentAuditLogsKPI> auditLogsKPI { get; set; }
        public List<AllergiesAuditLogsKPI> allergiesLogsKPI { get; set; }
        public List<VitalSignsAuditLogsKPI> vitalLogsKPI { get; set; }
        public List<PastHistoryAuditLogs> pfaLogsKPI { get; set; }
        public List<CheifComplaintsAuditLogs> complaintLogsKPI { get; set; }
        public List<HPIAudit> hpiLogsKPI { get; set; }
        public List<ROSAudit> rosLogsKPI { get; set; }
        public List<NurseNotesAudit> nusenoteLogsKPI { get; set; }
        public List<NarrativeDiagnosisAudit> narrativeLogsKPI { get; set; }
        public List<PatDiagnosisAudit> patdiagLogsKPI { get; set; }
        public List<AddendumAudit> addendumLogsKPI { get; set; }
        public List<ProgressNotesAudit> progressnoteLogsKPI { get; set; }
        public List<PatientTreatmentAudit> treatmentLogsKPI { get; set; }
    }

    public class AppointmentAuditLogsKPI
    {
        public int appa_appId { get; set; }
        public DateTime appa_fdate { get; set; }
        public DateTime appa_tdate { get; set; }
        public string appa_branch { get; set; }
        public string appa_ftime { get; set; }
        public string appa_ttime { get; set; }
        public string appa_patient { get; set; }
        public string appa_doctor { get; set; }
        public string appa_type { get; set; }
        public string appa_inout { get; set; }
        public string appa_operation { get; set; }
        public string appa_status { get; set; }
        public string appa_madeby { get; set; }
        public DateTime appa_date_created { get; set; }
        public DateTime appa_date_modified { get; set; }
    }
    
    public class AllergiesAuditLogsKPI
    {
        public int allaId { get; set; }
        public DateTime app_fdate { get; set; }
        public int alla_appId { get; set; }
        public string allergiesa { get; set; }
        public string alla_for { get; set; }
        public string alla_pexam { get; set; }
        public string alla_type { get; set; }
        public string alla_severity { get; set; }
        public string alla_status { get; set; }
        public string alla_madeby_name { get; set; }
        public string alla_doctor_name { get; set; }
        public string alla_operation { get; set; }
        public DateTime alla_date_created { get; set; }
    }
    
    public class VitalSignsAuditLogsKPI
    {
        public int signaId { get; set; }
        public int signa_appId { get; set; }
        public string signa_doctor_name { get; set; }
        public string signa_temp { get; set; }
        public string signa_pulse { get; set; }
        public string signa_bp { get; set; }
        public string signa_notes { get; set; }
        public string signa_height { get; set; }
        public string signa_weight { get; set; }
        public string signa_resp { get; set; }
        public string signa_spo2 { get; set; }
        public string signa_waist { get; set; }
        public string signa_hip { get; set; }
        public string signa_uri { get; set; }
        public string signa_head { get; set; }
        public string signa_bmi { get; set; }
        public string signa_bpd { get; set; }
        public string signa_status { get; set; }
        public int signa_madeby { get; set; }
        public int signa_modifyby { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public string signa_operation { get; set; }
        public string signa_madeby_name { get; set; }
        public DateTime signa_date_created { get; set; }
    }

    public class AuditLogsReportSearch
    {
        public int search_type { get; set; }
        public string select_branch { get; set; }
        public int select_patient { get; set; }
        public int select_madeby { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
    }

    public class PastHistoryAuditLogs
    {
        public int pfaId { get; set; }
        public int pfa_appId { get; set; }
        public string pfa_past { get; set; }
        public string pfa_other { get; set; }
        public string pfa_family { get; set; }
        public string pfa_surgical { get; set; }
        public string pfa_smok { get; set; }
        public string pfa_smok_habit { get; set; }
        public string pfa_smok_details { get; set; }
        public string pfa_alco { get; set; }
        public string pfa_alco_habit { get; set; }
        public string pfa_alco_details { get; set; }
        public string pfa_drug { get; set; }
        public string pfa_drug_habit { get; set; }
        public string pfa_drug_details { get; set; }
        public int pfa_madeby { get; set; }
        public string pfa_status { get; set; }
        public string pfa_madeby_name { get; set; }
        public string pfa_doctor_name { get; set; }
        public string pfa_operation { get; set; }
        public DateTime pfa_date_created { get; set; }
    }
    public class CheifComplaintsAuditLogs
    {
        public int compaId { get; set; }
        public int compa_appId { get; set; }
        [AllowHtml]
        public string complainta { get; set; }
        public string cma_title { get; set; }
        public string compa_location { get; set; }
        public int compa_madeby { get; set; }
        public string compa_status { get; set; }
        public string compa_madeby_name { get; set; }
        public string compa_doctor_name { get; set; }
        public string compa_operation { get; set; }
        public DateTime compa_date_created { get; set; }
    }
    public class HPIAudit
    {
       
        public int hpiaId { get; set; }
        public int hpia_appId { get; set; }
        public string hpia_loc { get; set; }
        public string hpia_qua { get; set; }
        public string hpia_sev { get; set; }
        public string hpia_dur { get; set; }
        public string hpia_tim { get; set; }
        public string hpia_con { get; set; }
        public string hpia_mod { get; set; }
        public string hpia_sym { get; set; }
        
        public string hpia_other { get; set; }
        public int hpia_madeby { get; set; }
        public string hpia_status { get; set; }
        public string hpia_madeby_name { get; set; }
        public string hpia_doctor_name { get; set; }
        public string hpia_operation { get; set; }
        public DateTime hpia_date_created { get; set; }
    }
    public class ROSAudit
    {

        public int rsaId { get; set; }
        public int rsa_appId { get; set; }
        public string rsa_comments { get; set; }
        
        public string rsa_1_type { get; set; }
        public string rsa_2_type { get; set; }
        public string rsa_3_type { get; set; }
        public string rsa_4_type { get; set; }
        public string rsa_5_type { get; set; }
        public string rsa_6_type { get; set; }
        public string rsa_7_type { get; set; }
        public string rsa_8_type { get; set; }
        public string rsa_9_type { get; set; }
        public string rsa_10_type { get; set; }
        public string rsa_11_type { get; set; }
        public string rsa_12_type { get; set; }
        public string rsa_13_type { get; set; }
        public string rsa_14_type { get; set; }
        public string rsa_15_type { get; set; }
        public string rsa_16_type { get; set; }
        public int rsa_madeby { get; set; }
        public string rsa_status { get; set; }
        public string rsa_madeby_name { get; set; }
        public string rsa_doctor_name { get; set; }
        public string rsa_operation { get; set; }
        public DateTime rsa_date_created { get; set; }
    }
    public class NurseNotesAudit
    {

        public int nurseaId { get; set; }
        public int nurse_appId { get; set; }
        [AllowHtml]
        public string nurse_notes { get; set; }
        public int nurse_madeby { get; set; }
        public string nurse_status { get; set; }
        public string nurse_madeby_name { get; set; }
        public string nurse_doctor_name { get; set; }
        public string nurse_operation { get; set; }
        public DateTime nurse_date_created { get; set; }
    }
    public class NarrativeDiagnosisAudit
    {

        public int ntdaId { get; set; }
        public int ntda_appId { get; set; }
        public string ntda_1 { get; set; }
        public string ntda_2 { get; set; }
        public string ntda_status { get; set; }
        public string ntda_madeby_name { get; set; }
        public string ntda_doctor_name { get; set; }
        public string ntda_operation { get; set; }
        public DateTime ntda_date_created { get; set; }
    }
    public class PatDiagnosisAudit
    {

        public int padaId { get; set; }
        public int pada_appId { get; set; }
        public string pada_type { get; set; }
        public string diag_name { get; set; }
        public string diag_code { get; set; }
        public string pada_notes { get; set; }
        public int pada_year { get; set; }
        public int pada_diagnosis { get; set; }
        public string pada_status { get; set; }
        public string pada_madeby_name { get; set; }
        public string pada_doctor_name { get; set; }
        public string pada_operation { get; set; }
        public DateTime pada_date_created { get; set; }
    }

    public class AddendumAudit
    {

        public int addeaId { get; set; }
        public int addea_appId { get; set; }
        public string addea_for_name { get; set; }
        public string addea_notes { get; set; }
        public string addea_status { get; set; }
        public string addea_madeby_name { get; set; }
        public string addea_doctor_name { get; set; }
        public string addea_operation { get; set; }
        public DateTime addea_date_created { get; set; }
    }
    public class ProgressNotesAudit
    {

        public int mnaId { get; set; }
        public int mna_appId { get; set; }
        public string mna_notes { get; set; }
        public string mna_visitPlan { get; set; }
        public string mna_instructions { get; set; }
        public string mna_status { get; set; }
        public string mna_madeby_name { get; set; }
        public string mna_doctor_name { get; set; }
        public string mna_operation { get; set; }
        public DateTime mna_date_created { get; set; }
    }

    public class PatientTreatmentAudit
    {

        public int ptaId { get; set; }
        public int pta_appId { get; set; }
        public string tr_code { get; set; }
        public string tr_name_type { get; set; }
        public decimal pta_qty { get; set; }
        public decimal pta_uprice { get; set; }
        public decimal pta_total { get; set; }
        public decimal pta_disc { get; set; }
        public decimal pta_net { get; set; }
        public decimal pta_vat { get; set; }
        public decimal pta_net_vat { get; set; }
        public string pta_lab_status { get; set; }
        public string pta_tdn_notes { get; set; }
        public int pta_ses { get; set; }
        public DateTime pta_pack_exp_date { get; set; }
        public string pta_status { get; set; }
        public string pta_madeby_name { get; set; }
        public string pta_doctor_name { get; set; }
        public string pta_operation { get; set; }
        public DateTime pta_date_created { get; set; }
    }
}