using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class Prescription
    {
        public int preId { get; set; }
        public int pre_appId { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string item_brand { get; set; }
        public string item_dosage { get; set; }
        public string item_strength { get; set; }
        public string pre_temp3 { get; set; } = "1";
        public string pre_temp4 { get; set; } = "1";
        public string pre_temp5 { get; set; }
        public string pre_duration { get; set; } = "1";
        public string pre_qty_type { get; set; } = "1";
        public string ra_code_desc { get; set; }
        public string pre_instr { get; set; }
        public string pre_status { get; set; }
        public int pre_madeby { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public int app_doctor { get; set; }
        public string s_pre_medicine { get; set; }
        public int pre_medicine { get; set; }
        public string pre_type { get; set; }
        public float pre_qty { get; set; } = 1;
        public string pre_temp6 { get; set; }
        public string pre_temp1 { get; set; }
        public string pre_qtype { get; set; }
        public string pre_temp2 { get; set; }
        public string pre_oc_code { get; set; }
        public string pre_oc_type { get; set; }
        public string pre_med_type { get; set; }
        public string pre_ra_code { get; set; }
        public string pre_ra_type { get; set; }
        public string pre_eRxRefNo { get; set; }
        public string chkyes { get; set; }
        public bool check_fav { get; set; }
    }

    public class PrescriptionFavourites
    {
        public int prefId { get; set; }
        public int pref_empId { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string item_brand { get; set; }
        public string item_dosage { get; set; }
        public string item_strength { get; set; }
        public string pref_temp3 { get; set; } = "1";
        public string pref_temp4 { get; set; } = "1";
        public string pref_temp5 { get; set; }
        public string pref_duration { get; set; } = "1";
        public string pref_qty_type { get; set; } = "1";
        public string ra_code_desc { get; set; }
        public string pref_instr { get; set; }
        public string pref_status { get; set; }
        public int pref_madeby { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public int pref_medicine { get; set; }
        public string pref_type { get; set; }
        public float pref_qty { get; set; } = 1;
        public string pref_temp6 { get; set; }
        public string pref_temp1 { get; set; }
        public string pref_qtype { get; set; }
        public string pref_temp2 { get; set; }
        public string pref_oc_code { get; set; }
        public string pref_oc_type { get; set; }
        public string pref_ra_code { get; set; }
        public string pref_ra_type { get; set; }
    }

    public class erxSubmissions
    {
        public int erxId { get; set; }
        public int erx_appId { get; set; }
        public int erx_ReferenceNo { get; set; }
        public string erx_filename { get; set; }
        public string erx_ErrorMessage { get; set; }
        public string erx_ErrorReport { get; set; }
        public string erx_status { get; set; }
        public string erx_madeby { get; set; }
        public DateTime erx_date { get; set; }
    }

    public class ControlledDrug
    {
        public int precId { get; set; }
        public int prec_appId { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string item_brand { get; set; }
        public string item_dosage { get; set; }
        public string item_strength { get; set; }
        public string prec_temp3 { get; set; }
        public string prec_temp4 { get; set; }
        public string prec_temp5 { get; set; }
        public string prec_duration { get; set; }
        public string prec_qty_type { get; set; }
        public string ra_code_desc { get; set; }
        public string prec_instr { get; set; }
        public string prec_status { get; set; }
        public int prec_madeby { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public int app_doctor { get; set; }
        public string s_prec_medicine { get; set; }
        public int prec_medicine { get; set; }
        public string prec_type { get; set; }
        public float prec_qty { get; set; }
        public string prec_temp6 { get; set; }
        public string prec_temp1 { get; set; }
        public string prec_qtype { get; set; }
        public string prec_temp2 { get; set; }
        public string prec_oj_code { get; set; }
        public string prec_oj_type { get; set; }
    }

    public class PrescriptionPrint
    {
        public PrescriptionHeader pt_header { get; set; }
        public PrescriptionFooter pt_footer { get; set; }
        public List<PrescriptionBody> pt_body { get; set; }
    }

    public class PrescriptionHeader
    {
        public string set_vat_regno { get; set; }
        public string set_company { get; set; }
        public string set_address { get; set; }
        public string set_tel { get; set; }
        public string set_mob { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
        public string emp_name { get; set; }
        public string emp_license { get; set; }
        public string emp_dept_name { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string type { get; set; }
        public string pat_gender { get; set; }
        public string pt_date_created { get; set; }
        public string app_fdate { get; set; }
        public string pat_age { get; set; }
        public string madeby_name { get; set; }
        public string emp_sign { get; set; }
        public string PrimaryD { get; set; }
        public string SecD { get; set; }
        public string id_card_front { get; set; }
    }

    public class PrescriptionFooter
    {
        public string balance { get; set; }
        public string advance_balance { get; set; }
    }

    public class PrescriptionBody
    {
        public string item_name { get; set; }
        public string item_brand { get; set; }
        public string item_dosage { get; set; }
        public string item_strength { get; set; }
        public string item_erx_ref { get; set; }
        public string pre_instr { get; set; }
        public string pre_qty_type { get; set; }
        public string ra_code_desc { get; set; }
        public string pt_net { get; set; }
        public string pt_netvat { get; set; }
    }

    public class GeneralPrescription
    {
        public int gpreId { get; set; }
        public int gpre_appId { get; set; }
        [AllowHtml]
        public string gpre_desc { get; set; }
        public string gpre_status { get; set; }
        public int gpre_madeby { get; set; }
        public int gpre_modifiedby { get; set; }
        public DateTime app_fdate { get; set; }
        public string emp_license { get; set; }
        public string doctor_name { get; set; }
    }
}