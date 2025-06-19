using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AuditLogs
{
    public class AuditLogs
    {
        #region General Logs
        public static void GeneralLogs(BusinessEntities.AuditLogs.AuditLogs auditLogs)
        {
            DataAccessLayer.AuditLogs.AuditLogs.GeneralLogs(auditLogs);
        }
        #endregion

        #region EMR Audit Logs

        public static List<BusinessEntities.KPIReports.VitalSignsAuditLogsKPI> VitalSignsAudit(int appId)
        {
            List<BusinessEntities.KPIReports.VitalSignsAuditLogsKPI> sclist = new List<BusinessEntities.KPIReports.VitalSignsAuditLogsKPI>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.VitalSignsAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.VitalSignsAuditLogsKPI
                {
                    signaId = Convert.ToInt32(dr["signaId"]),
                    signa_appId = Convert.ToInt32(dr["signa_appId"]),
                    signa_doctor_name = dr["signa_doctor_name"].ToString(),
                    signa_temp = dr["signa_temp"].ToString(),
                    signa_pulse = dr["signa_pulse"].ToString(),
                    signa_bp = dr["signa_bp"].ToString(),
                    signa_notes = dr["signa_notes"].ToString(),
                    signa_height = dr["signa_height"].ToString(),
                    signa_weight = dr["signa_weight"].ToString(),
                    signa_resp = dr["signa_resp"].ToString(),
                    signa_spo2 = dr["signa_spo2"].ToString(),
                    signa_waist = dr["signa_waist"].ToString(),
                    signa_hip = dr["signa_hip"].ToString(),
                    signa_uri = dr["signa_uri"].ToString(),
                    signa_head = dr["signa_head"].ToString(),
                    signa_bmi = dr["sign_bmi"].ToString(),
                    signa_status = dr["signa_status"].ToString(),
                    signa_madeby_name = dr["signa_madeby_name"].ToString(),
                    signa_bpd = dr["signa_bpd"].ToString(),
                    signa_operation = dr["signa_operation"].ToString(),
                    signa_date_created = Convert.ToDateTime(dr["signa_date_created"]),

                });
            }
            return sclist;
        }

        public static List<BusinessEntities.KPIReports.AllergiesAuditLogsKPI> AllergiesAudit(int appId)
        {
            List<BusinessEntities.KPIReports.AllergiesAuditLogsKPI> sclist = new List<BusinessEntities.KPIReports.AllergiesAuditLogsKPI>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.AllergiesAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.AllergiesAuditLogsKPI
                {
                    allaId = Convert.ToInt32(dr["allaId"]),
                alla_appId = Convert.ToInt32(dr["alla_appId"]),
                allergiesa = dr["allergiesa"].ToString(),
                alla_for = dr["alla_for"].ToString(),
                alla_pexam = dr["alla_pexam"].ToString(),
                alla_type = dr["alla_type"].ToString(),
                alla_severity = dr["alla_severity"].ToString(),
                alla_status = dr["alla_status"].ToString(),
                alla_doctor_name = dr["alla_doctor_name"].ToString(),
                alla_madeby_name = dr["alla_madeby_name"].ToString(),
                alla_operation = dr["alla_operation"].ToString(),
                alla_date_created = Convert.ToDateTime(dr["alla_date_created"]),
            });
            }
            return sclist;
        }
        public static List<BusinessEntities.KPIReports.PastHistoryAuditLogs> PastHistoryAudit(int appId)
        {
            List<BusinessEntities.KPIReports.PastHistoryAuditLogs> sclist = new List<BusinessEntities.KPIReports.PastHistoryAuditLogs>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.PastHistoryAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.PastHistoryAuditLogs
                {
                    pfaId = Convert.ToInt32(dr["pfaId"]),
                    pfa_appId = Convert.ToInt32(dr["pfa_appId"]),
                    pfa_past = dr["pfa_past"].ToString(),
                    pfa_other = dr["pfa_other"].ToString(),
                    pfa_surgical = dr["pfa_surgical"].ToString(),
                    pfa_smok = dr["pfa_smok"].ToString(),
                    pfa_smok_habit = dr["pfa_smok_habit"].ToString(),
                    pfa_smok_details = dr["pfa_smok_details"].ToString(),
                    pfa_alco = dr["pfa_alco"].ToString(),
                    pfa_alco_habit = dr["pfa_alco_habit"].ToString(),
                    pfa_alco_details = dr["pfa_alco_details"].ToString(),
                    pfa_drug = dr["pfa_drug"].ToString(),
                    pfa_drug_habit = dr["pfa_drug_habit"].ToString(),
                    pfa_drug_details = dr["pfa_drug_details"].ToString(),
                    pfa_status = dr["pfa_status"].ToString(),
                    pfa_madeby_name = dr["pfa_madeby_name"].ToString(),
                    pfa_operation = dr["pfa_operation"].ToString(),
                    pfa_date_created = Convert.ToDateTime(dr["pfa_date_created"]),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.KPIReports.CheifComplaintsAuditLogs> CheifComplaintsAudit(int appId)
        {
            List<BusinessEntities.KPIReports.CheifComplaintsAuditLogs> sclist = new List<BusinessEntities.KPIReports.CheifComplaintsAuditLogs>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.CheifComplaintsAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.CheifComplaintsAuditLogs
                {
                    compaId = Convert.ToInt32(dr["compaId"]),
                    compa_appId = Convert.ToInt32(dr["compa_appId"]),
                    complainta = dr["complaint_a"].ToString(),
                    compa_status = dr["compa_status"].ToString(),
                    cma_title = dr["compa_location"].ToString(),
                    compa_madeby_name = dr["compa_madeby_name"].ToString(),
                    compa_operation = dr["compa_operation"].ToString(),
                    compa_date_created = Convert.ToDateTime(dr["compa_date_created"]),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.KPIReports.HPIAudit> HPIAudit(int appId)
        {
            List<BusinessEntities.KPIReports.HPIAudit> sclist = new List<BusinessEntities.KPIReports.HPIAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.HPIAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.HPIAudit
                {

                    hpiaId = Convert.ToInt32(dr["hpiaId"]),
                    hpia_appId = Convert.ToInt32(dr["hpia_appId"]),
                    hpia_loc = dr["hpia_loc"].ToString(),
                    hpia_qua = dr["hpia_qua"].ToString(),
                    hpia_sev = dr["hpia_sev"].ToString(),
                    hpia_dur = dr["hpia_dur"].ToString(),
                    hpia_tim = dr["hpia_tim"].ToString(),
                    hpia_con = dr["hpia_con"].ToString(),
                    hpia_mod = dr["hpia_mod"].ToString(),
                    hpia_sym = dr["hpia_sym"].ToString(),
                    hpia_other = dr["hpia_other"].ToString(),
                    hpia_status = dr["hpia_status"].ToString(),
                    hpia_madeby_name = dr["hpia_madeby_name"].ToString(),
                    hpia_operation = dr["hpia_operation"].ToString(),
                    hpia_date_created = Convert.ToDateTime(dr["hpia_date_created"]),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.KPIReports.ROSAudit> ROSAudit(int appId)
        {
            List<BusinessEntities.KPIReports.ROSAudit> sclist = new List<BusinessEntities.KPIReports.ROSAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.ROSAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.ROSAudit
                {

                    rsaId = Convert.ToInt32(dr["rsaId"]),
                    rsa_appId = Convert.ToInt32(dr["rsa_appId"]),
                    rsa_comments = dr["rsa_comments"].ToString(),
                    rsa_1_type = dr["rsa_1_type"].ToString(),
                    rsa_2_type = dr["rsa_2_type"].ToString(),
                    rsa_3_type = dr["rsa_3_type"].ToString(),
                    rsa_4_type = dr["rsa_4_type"].ToString(),
                    rsa_5_type = dr["rsa_5_type"].ToString(),
                    rsa_6_type = dr["rsa_6_type"].ToString(),
                    rsa_7_type = dr["rsa_7_type"].ToString(),
                    rsa_8_type = dr["rsa_8_type"].ToString(),
                    rsa_9_type = dr["rsa_9_type"].ToString(),
                    rsa_10_type = dr["rsa_10_type"].ToString(),
                    rsa_11_type = dr["rsa_11_type"].ToString(),
                    rsa_12_type = dr["rsa_12_type"].ToString(),
                    rsa_13_type = dr["rsa_13_type"].ToString(),
                    rsa_14_type = dr["rsa_14_type"].ToString(),
                    rsa_15_type = dr["rsa_15_type"].ToString(),
                    rsa_16_type = dr["rsa_16_type"].ToString(),
                    rsa_status = dr["rsa_status"].ToString(),
                    rsa_madeby_name = dr["rsa_madeby_name"].ToString(),
                    rsa_operation = dr["rsa_operation"].ToString(),
                    rsa_date_created = Convert.ToDateTime(dr["rsa_date_created"]),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.KPIReports.NurseNotesAudit> NurseNotesAudit(int appId)
        {
            List<BusinessEntities.KPIReports.NurseNotesAudit> sclist = new List<BusinessEntities.KPIReports.NurseNotesAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.NurseNotesAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.NurseNotesAudit
                {

                    nurseaId = Convert.ToInt32(dr["nurseaId"]),
                    nurse_appId = Convert.ToInt32(dr["nurse_appId"]),
                    nurse_notes = dr["nurse_notes"].ToString(),
                    nurse_status = dr["nurse_status"].ToString(),
                    nurse_madeby_name = dr["nurse_madeby_name"].ToString(),
                    nurse_operation = dr["nurse_operation"].ToString(),
                    nurse_date_created = Convert.ToDateTime(dr["nurse_date_created"]),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.KPIReports.NarrativeDiagnosisAudit> NarrativeDiagnosisAudit(int appId)
        {
            List<BusinessEntities.KPIReports.NarrativeDiagnosisAudit> sclist = new List<BusinessEntities.KPIReports.NarrativeDiagnosisAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.NarrativeDiagnosisAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.NarrativeDiagnosisAudit
                {

                    ntdaId = Convert.ToInt32(dr["ntdaId"]),
                    ntda_appId = Convert.ToInt32(dr["ntda_appId"]),
                    ntda_1 = dr["ntda_1"].ToString(),
                    ntda_2 = dr["ntda_2"].ToString(),
                    ntda_status = dr["ntda_status"].ToString(),
                    ntda_madeby_name = dr["ntda_madeby_name"].ToString(),
                    ntda_operation = dr["ntda_operation"].ToString(),
                    ntda_date_created = Convert.ToDateTime(dr["ntda_date_created"]),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.KPIReports.PatDiagnosisAudit> PatDiagnosisAudit(int appId)
        {
            List<BusinessEntities.KPIReports.PatDiagnosisAudit> sclist = new List<BusinessEntities.KPIReports.PatDiagnosisAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.PatDiagnosisAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.PatDiagnosisAudit
                {

                    padaId = Convert.ToInt32(dr["padaId"]),
                    pada_appId = Convert.ToInt32(dr["pada_appId"]),
                    pada_type = dr["pada_type"].ToString(),
                    diag_name = dr["diag_name"].ToString(),
                    pada_notes = dr["pada_notes"].ToString(),
                    pada_year = Convert.ToInt32(dr["pada_year"].ToString()),
                    pada_diagnosis = Convert.ToInt32(dr["pada_diagnosis"].ToString()),
                    diag_code = dr["diag_code"].ToString(),
                    pada_status = dr["pad_status"].ToString(),
                    pada_madeby_name = dr["pada_madeby_name"].ToString(),
                    pada_operation = dr["pada_operation"].ToString(),
                    pada_date_created = Convert.ToDateTime(dr["pada_date_created"]),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.KPIReports.AddendumAudit> AddendumAudit(int appId)
        {
            List<BusinessEntities.KPIReports.AddendumAudit> sclist = new List<BusinessEntities.KPIReports.AddendumAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.AddendumAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.AddendumAudit
                {

                    addeaId = Convert.ToInt32(dr["addeaId"]),
                    addea_appId = Convert.ToInt32(dr["addea_appId"]),
                    addea_notes = dr["addea_notes"].ToString(),
                    addea_for_name = dr["adde_for_name"].ToString(),
                    addea_status = dr["addea_status"].ToString(),
                    addea_madeby_name = dr["addea_madeby_name"].ToString(),
                    addea_operation = dr["addea_operation"].ToString(),
                    addea_date_created = Convert.ToDateTime(dr["addea_date_created"]),


                });
            }
            return sclist;
        }
        public static List<BusinessEntities.KPIReports.ProgressNotesAudit> ProgressNotesAudit(int appId)
        {
            List<BusinessEntities.KPIReports.ProgressNotesAudit> sclist = new List<BusinessEntities.KPIReports.ProgressNotesAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.ProgressNotesAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.ProgressNotesAudit
                {

                    mnaId = Convert.ToInt32(dr["mnaId"]),
                    mna_appId = Convert.ToInt32(dr["mna_appId"]),
                    mna_notes = dr["mna_notes"].ToString(),
                    mna_visitPlan = dr["mna_visitPlan"].ToString(),
                    mna_instructions = dr["mna_instructions"].ToString(),
                    mna_status = dr["mna_status"].ToString(),
                    mna_madeby_name = dr["mna_madeby_name"].ToString(),
                    mna_operation = dr["mna_operation"].ToString(),
                    mna_date_created = Convert.ToDateTime(dr["mna_date_created"]),


                });
            }
            return sclist;
        }

        public static List<BusinessEntities.KPIReports.PatientTreatmentAudit> PatientTreatemntsAudit(int appId)
        {
            List<BusinessEntities.KPIReports.PatientTreatmentAudit> sclist = new List<BusinessEntities.KPIReports.PatientTreatmentAudit>();
            DataTable dt = DataAccessLayer.AuditLogs.AuditLogs.PatientTreatemntsAudit(appId);

            foreach (DataRow dr in dt.Rows)
            {
                sclist.Add(new BusinessEntities.KPIReports.PatientTreatmentAudit
                {

                    ptaId = Convert.ToInt32(dr["ptaId"]),
                    pta_appId = Convert.ToInt32(dr["pta_appId"]),
                    tr_code = dr["tr_code"].ToString(),
                    tr_name_type = dr["tr_name_type"].ToString(),
                    pta_qty = Convert.ToInt32(dr["pta_qty"].ToString()),
                    pta_uprice = Convert.ToDecimal(dr["pta_uprice"].ToString()),
                    pta_total = Convert.ToDecimal(dr["pta_total"].ToString()),
                    pta_disc = Convert.ToDecimal(dr["pta_disc"].ToString()),
                    pta_net = Convert.ToDecimal(dr["pta_net"].ToString()),
                    pta_vat = Convert.ToDecimal(dr["pta_vat"].ToString()),
                    pta_net_vat = Convert.ToDecimal(dr["pta_net_vat"].ToString()),
                    pta_lab_status = dr["pta_lab_status"].ToString(),
                    pta_tdn_notes = dr["pta_tdn_notes"].ToString(),
                    pta_ses = Convert.ToInt32(dr["pta_ses"]),
                    pta_pack_exp_date = string.IsNullOrEmpty(dr["pta_pack_exp_date"].ToString()) ? Convert.ToDateTime("1900-01-01 00:00:00.000") : Convert.ToDateTime(dr["pta_pack_exp_date"].ToString()),
                    pta_status = dr["pta_status"].ToString(),
                    pta_madeby_name = dr["pta_madeby_name"].ToString(),
                    pta_operation = dr["pta_operation"].ToString(),
                    pta_date_created = Convert.ToDateTime(dr["pta_date_created"]),


                });
            }
            return sclist;
        }
        #endregion EMR Audit Logs
    }
}
