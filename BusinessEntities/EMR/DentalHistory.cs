using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class DentalHistory
    {
        public int pdId { get; set; }
        public int pd_appId { get; set; }
        public string pd_medicaltreat { get; set; }
        public string pd_hospitalized { get; set; }
        public string pd_medications { get; set; }
        public string pd_medicationsyes { get; set; }
        public string pd_tobacco { get; set; }
        public string pd_gums { get; set; }
        public string pd_hotcold { get; set; }
        public string pd_sweetsour { get; set; }
        public string pd_teethpain { get; set; }
        public string pd_soresjumps { get; set; }
        public string pd_headinjuries { get; set; }
        public string pd_clicking { get; set; }
        public string pd_pain { get; set; }
        public string pd_openingclosing { get; set; }
        public string pd_chewing { get; set; }
        public string pd_clench { get; set; }
        public string pd_bitelips { get; set; }
        public string pd_difficultextract { get; set; }
        public string pd_prolonged { get; set; }
        public string pd_gems { get; set; }
        public string pd_filling { get; set; }
        public string pd_w_medicaltreat { get; set; }
        public string pd_w_hospitalized { get; set; }
        public string pd_w_medications { get; set; }
        public string pd_w_amenorrhoea { get; set; }
        public string pd_status { get; set; }
        public int pd_madeby { get; set; }
        public string pd_last_dental_exam { get; set; }

        
        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }

        public int Action { get; set; }
    }

    public class MedicalHistory
    {
       public int  oeId { get; set; } 
        public int oe_appId { get; set; }
        public string oe_present_ill { get; set; }
        public string oe_pain { get; set; }
        public string oe_duration { get; set; }
        public string oe_infecious { get; set; }
        public string oe_infecious_other { get; set; }
        public string oe_systemic { get; set; }
        public string oe_systemic_other { get; set; }
        public string oe_past_med { get; set; }
        public string oe_past_med_other { get; set; }
        public string oe_fall_risk { get; set; }
        public string oe_fall_risk_other { get; set; }
        public string oe_fall_risk_type { get; set; }
        public string oe_notes { get; set; }
        public string oe_extra_oral { get; set; }
        public string oe_intra_oral { get; set; }
        public string oe_oral_notes { get; set; }

        public string oe_status { get; set; }
        public int oe_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class DMFIndex
    {
        public int dmfId { get; set; }
        public int dmf_appId { get; set; }
        public string dmf_index { get; set; }
        public string dmf_other { get; set; }
        public string dmf_status { get; set; }
        public int dmf_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class CrownOrder
    {
        public int c_Id { get; set; }
        public int c_appId { get; set; }
        public string c_chk { get; set; }
        public string c_requiredBy { get; set; }
        public string c_instrns { get; set; }
        public string c_toothNo { get; set; }
        public string c_shade { get; set; }
        public string c_system { get; set; }
        public string c_diameter { get; set; }
        public string c_diag1 { get; set; }
        public string c_diag2 { get; set; }
        public string c_wax1 { get; set; }
        public string c_wax2 { get; set; }
        public DateTime c_start_date { get; set; }
        public DateTime c_Completion_date { get; set; }
        public string C_status { get; set; }
        public int c_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
