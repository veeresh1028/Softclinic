using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Patient
{
    public class PatientInsurance
    {
        public int piId { get; set; }
        public int pi_patient { get; set; }
        public string pi_image { get; set; }
        public string pi_image2 { get; set; }
        public string is_ic_code { get; set; }
        public string is_ic_name { get; set; }
        public string is_ip_code { get; set; }
        public string is_ip_name { get; set; }
        public string is_title { get; set; }
        public string pi_insno { get; set; }
        public string pi_polocyno { get; set; }
        public DateTime pi_idate { get; set; }
        public DateTime pi_edate { get; set; }

        public string pi_cded_type { get; set; }
        public decimal pi_cded { get; set; }
        public decimal pi_cded_limit { get; set; }

        public string pi_ip_dcopay_type { get; set; }
        public decimal pi_ip_dcopay { get; set; }
        public decimal pi_ip_dcopay_limit { get; set; }

        public string pi_dded_type { get; set; }
        public decimal pi_dded { get; set; }
        public decimal pi_dded_limit { get; set; }

        public string pi_ided_type { get; set; }
        public decimal pi_ided { get; set; }
        public decimal pi_ided_limit { get; set; }

        public string pi_rded_type { get; set; }
        public decimal pi_rded { get; set; }
        public decimal pi_rded_limit { get; set; }

        public string pi_mded_type { get; set; }
        public decimal pi_mded { get; set; }
        public decimal pi_mded_limit { get; set; }

        public string pi_pded_type { get; set; }
        public decimal pi_pded { get; set; }
        public decimal pi_pded_limit { get; set; }

        public string pi_copay_type { get; set; }
        public decimal pi_copay { get; set; }
        public decimal pi_copay_limit { get; set; }

        public string pi_dcopay_type { get; set; }
        public decimal pi_dcopay { get; set; }
        public decimal pi_dcopay_limit { get; set; }

        public string pi_hdcopay_type { get; set; }
        public decimal pi_hdcopay { get; set; }
        public decimal pi_hdcopay_limit { get; set; }


        public double pi_limit { get; set; }
        public double pi_ceiling { get; set; }
        public string pi_status { get; set; }

        public string pat_name { get; set; }
        public string pat_code { get; set; }

        public int isAllocated { get; set; }

    }

    public class PatientInsuranceDetails
    {
        public int piId { get; set; } = 0;
        public int pi_patient { get; set; } = 0;
        public int pit_insurance { get; set; } = 0;
        public int pi_insurance { get; set; } = 0;
        public int pi_payer { get; set; } = 0;
        public int pi_scheme { get; set; } = 0;
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
    }
}
