using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessEntities.Patient
{
    public class PatientWithInsurance
    {
        public PatientDetails patient { get; set; }
        public PatientInsuranceDetails insurance { get; set; }
    }

    public class PatientAndInsurance
    {
        public int patId { get; set; }
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
        public string pat_rel_address { get; set; }
        public int pat_country { get; set; }
        public string pat_ms { get; set; }
        public string pat_fax { get; set; }
        public string pat_emirateid { get; set; }
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
        public string pat_ethnic { get; set; }

        public string id_card_front { get; set; }
        public string id_card_back { get; set; }
        public Nullable<DateTime> id_card_idate { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> id_card_edate { get; set; } = DateTime.Parse("2100-01-01");

        public int piId { get; set; } = 0;
        public int pit_insurance { get; set; } = 0;
        public int pi_insurance { get; set; } = 0;
        public int pi_scheme { get; set; } = 0;
        public int pi_payer { get; set; } = 0;
        public int is_insurance { get; set; } = 0;
        public DateTime pi_idate { get; set; } = DateTime.Now;
        public DateTime pi_edate { get; set; } = DateTime.Now;
        public string pi_insno { get; set; } = string.Empty;
        public string pi_polocyno { get; set; } = string.Empty;

        public string pi_cded_type { get; set; } = string.Empty;
        public decimal pi_cded { get; set; } = 0;
        public decimal pi_cded_limit { get; set; } = 0;

        public string pi_ip_dcopay_type { get; set; } = string.Empty;
        public decimal pi_ip_dcopay { get; set; } = 0;
        public decimal pi_ip_dcopay_limit { get; set; } = 0;


        public string pi_dded_type { get; set; } = string.Empty;
        public decimal pi_dded { get; set; } = 0;
        public decimal pi_dded_limit { get; set; } = 0;

        public string pi_copay_type { get; set; } = string.Empty;
        public decimal pi_copay { get; set; } = 0;
        public decimal pi_copay_limit { get; set; } = 0;

        public string pi_dcopay_type { get; set; } = string.Empty;
        public decimal pi_dcopay { get; set; } = 0;
        public decimal pi_dcopay_limit { get; set; } = 0;

        public string pi_hdcopay_type { get; set; } = string.Empty;
        public decimal pi_hdcopay { get; set; } = 0;
        public decimal pi_hdcopay_limit { get; set; } = 0;

        public string pi_pded_type { get; set; } = string.Empty;
        public decimal pi_pded { get; set; } = 0;
        public decimal pi_pded_limit { get; set; } = 0;

        public string pi_ided_type { get; set; } = string.Empty;
        public decimal pi_ided { get; set; } = 0;
        public decimal pi_ided_limit { get; set; } = 0;

        public string pi_rded_type { get; set; } = string.Empty;
        public decimal pi_rded { get; set; } = 0;
        public decimal pi_rded_limit { get; set; } = 0;

        public string pi_mded_type { get; set; } = string.Empty;
        public decimal pi_mded { get; set; } = 0;
        public decimal pi_mded_limit { get; set; } = 0;

        public double pi_limit { get; set; } = 0;
        public double pi_ceiling { get; set; } = 0;
        public string pi_image { get; set; } = string.Empty;
        public string pi_image2 { get; set; } = string.Empty;
        //public PatientDetails patient { get; set; }
        //public PatientInsuranceDetails insurance { get; set; }

        //public System.IO.FileInfo EIDFront { get; set; }
    }
    
}
