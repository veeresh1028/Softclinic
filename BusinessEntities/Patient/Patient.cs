using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Patient
{
    public class Patient
    {
        public int patId { get; set; }
        public string pat_photo { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_gender { get; set; }
        public string pat_dob { get; set; }
        public string pat_age { get; set; }
        public string pat_title { get; set; }
        public string pat_class { get; set; }
        public string nationality { get; set; }
        public string pat_mob { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_email { get; set; }
        public string pat_status { get; set; }
        public string pat_ms { get; set; }
        public string pat_referal { get; set; }
        public DateTime id_card_edate { get; set; }
        public string ref_name { get; set; }
        public string actionvisible { get; set; }
        public string id_card_front { get; set; }
        public string id_card_back { get; set; }
        public string pat_name_arb { get; set; }
    }
    public class PatientSearch
    {
        public string branch_ids { get; set; }
        public string residential_types { get; set; }
        public string account_types { get; set; }
        public string mrn_from { get; set; }
        public string mrn_to { get; set; }
        public string nationalities { get; set; }
        public string reg_from { get; set; }
        public string reg_to { get; set; }
        public string dob_from { get; set; }
        public string dob_to { get; set; }
        public string pat_status { get; set; }
        public string pat_gender { get; set; }
        public string pat_ms { get; set; }
        public string pat_class { get; set; }
        public string pat_referals { get; set; }
        public string pat_info { get; set; }
        public string patIdT { get; set; }
        public string piIdF { get; set; }
        public int mode { get; set; }
    }
    public class PatientBulkStatus
    {
        public List<int> patIds { get; set; }
        public string status { get; set; }
        public int madeBy { get; set; }
    }
    public class PatientDetails
    {
        public int patId { get; set; }
        public int appId { get; set; }
        public string pat_title { get; set; }
        public string pat_class { get; set; }
        public decimal pat_obal { get; set; }
        public string pat_obal_type { get; set; }
        public int pat_branch { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_mname { get; set; }
        public string pat_lname { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_gender { get; set; }
        public string pat_name_arabic { get; set; }
        public string pat_lname_arabic { get; set; }
        public string pat_tel { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_religion { get; set; }
        public string pat_race { get; set; }
        public int pat_nat { get; set; }
        public string pat_citizen { get; set; }
        public int pat_country { get; set; }
        public string pat_ms { get; set; }
        public string pat_fax { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_rel_address { get; set; }
        public string pat_passport { get; set; }
        public string pat_occupation { get; set; }
        public int pat_referal { get; set; }
        public string pat_city { get; set; }
        public string pat_pobox { get; set; }
        public string pat_notes { get; set; }
        public string pat_address { get; set; }
        public string pat_doc_1 { get; set; }
        public string pat_doc_2 { get; set; }
        public string pat_doc_3 { get; set; }
        public string pat_doc_4 { get; set; }
        public string pat_doc_5 { get; set; }
        public string pat_photo { get; set; }
        public string pat_ec_name1 { get; set; }
        public string pat_ec_rel1 { get; set; }
        public string pat_ec_tel1 { get; set; }
        public string pat_ec_tel11 { get; set; }
        public string pat_ec_name2 { get; set; }
        public string pat_ec_rel2 { get; set; }
        public string pat_ec_tel2 { get; set; }
        public string pat_ec_tel22 { get; set; }
        public string pat_ec_name3 { get; set; }
        public string pat_ec_rel3 { get; set; }
        public string pat_ec_tel3 { get; set; }
        public string pat_ec_tel33 { get; set; }
        public string nationality { get; set; }
        public string pat_ethnic { get; set; }
        public string pat_lang { get; set; }
        public DateTime app_last_visit { get; set; }

        public string id_card_front { get; set; }
        public string id_card_back { get; set; }
        public Nullable<DateTime> id_card_idate { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> id_card_edate { get; set; } = DateTime.Parse("2100-01-01");
    }

    public class PatientInquiry
    {
        public int patId { get; set; }
        public string pat_name { get; set; }
        public string pat_mname { get; set; }
        public string pat_lname { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
    }
    public class PatientLabel
    {
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public string pat_gender { get; set; }
        public string pat_mob { get; set; }
        public string pat_ins { get; set; }
        public string nationality { get; set; }
        [DataType(DataType.Date), DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime pat_dob { get; set; }
    }
    public class PatientAudit
    {
        public int patId { get; set; }
        public int pat_code { get; set; }
        public string pat_title { get; set; }
        public string pat_name { get; set; }
        public string pat_mname { get; set; }
        public string pat_lname { get; set; }
        public string pat_referal { get; set; }
        public string pat_branch { get; set; }
        public string pat_class { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_gender { get; set; }
        public string pat_ms { get; set; }
        public string pat_nat { get; set; }
        public string pat_tel { get; set; }
        public string pat_mob { get; set; }
        public string pat_fax { get; set; }
        public string pat_email { get; set; }
        public string pat_pobox { get; set; }
        public string pat_address { get; set; }
        public string pat_city { get; set; }
        public string pat_country { get; set; }
        public string pat_photo { get; set; }
        public string pat_notes { get; set; }
        public string pat_status { get; set; }
        public string pat_emirateid { get; set; }
        public decimal pat_obal { get; set; }
        public string pat_passport { get; set; }
        public string pat_religion { get; set; }
        public string pat_citizen { get; set; }
        public string pat_race { get; set; }
        public int pat_slno { get; set; }
        public string pat_name_arabic { get; set; }
        public string pat_lname_arabic { get; set; }
        public string pat_occupation { get; set; }
        public string pat_id_card_front { get; set; }
        public string pat_id_card_back { get; set; }
        public DateTime pat_id_card_idate { get; set; }
        public DateTime pat_id_card_edate { get; set; }
        public string logged_by { get; set; }
        public string logged_action { get; set; }
        public DateTime loged_timestamp { get; set; }
    }
    public class PatientAuditView
    {
        public string pat_name { get; set; }
        public List<PatientAudit> log_data { get; set; }
    }
    public class Remarks
    {
        public int arId { get; set; }
        public int ar_appId { get; set; }
        public int ar_employee { get; set; }
        public string ar_employee_name { get; set; }
        public string ar_remarks { get; set; }
        public DateTime ar_date_created { get; set; }
        public int ar_patId { get; set; }
        public DateTime ar_fllowupdate { get; set; }
        public int ar_ftime { get; set; }
        public string ftime { get; set; }
        public string ar_flag { get; set; }
        public string ar_status { get; set; }
        [NotMapped]
        public List<CommonDDL> FromTimeList { get; set; }
    }

    public class RemarksView
    {
        public string remark_from { get; set; }
        public List<Remarks> remarks_data { get; set; }
    }

    public class PatientMerge
    {
        public int patId { get; set; }
        public int piId { get; set; }
        public int appId { get; set; }
        public int app_doctor { get; set; }
        public int app_patient { get; set; }
        public int app_ins { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string is_ic_name { get; set; }
        public string is_title { get; set; }
        public string pi_insno { get; set; }
        public string emp_name { get; set; }
        public DateTime pi_edate { get; set; }
        public DateTime app_fdate { get; set; }
    }
    
    public class MergeData
    {
        public List<MergeItem> dataFrom { get; set; }
        public List<MergeItem> dataTo { get; set; }
    }

    public class MergeItem
    {
        public int appIdF { get; set; }
        public int piIdF { get; set; }
        public int patIdF { get; set; }

        public int appIdT { get; set; }
        public int piIdT { get; set; }
        public int patIdT { get; set; }
    }
}
