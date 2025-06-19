using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Patient.Treatments
{
    public class PatientTreatment
    {
        public int ptId { get; set; }
        public int pt_appId { get; set; }
        public int pt_treatment { get; set; }
        public string pt_comments { get; set; }
        public decimal pt_qty { get; set; }
        public string pt_notes { get; set; }
        public string pt_type { get; set; }
        public string pt_teeth { get; set; }
        public string pt_sur { get; set; }
        public string pt_auth_code { get; set; }
        public int pt_ses { get; set; }
        public int pt_treat_type { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_total { get; set; }
        public Nullable<decimal> pt_disc { get; set; } = 0;
        public decimal pt_ded { get; set; }
        public decimal pt_copay { get; set; }
        public decimal pt_net { get; set; }
        public decimal pt_dcopay { get; set; }
        public string pt_barcode { get; set; }
        public DateTime pt_auth_edate { get; set; }
        public DateTime pt_auth_adate { get; set; }
        public decimal pt_share { get; set; }
        public int pt_insurance { get; set; }
        public decimal pt_dded { get; set; }
        public decimal pt_lded { get; set; }
        public decimal pt_rded { get; set; }
        public decimal pt_mded { get; set; }
        public decimal pt_sded { get; set; }
        public decimal pt_pded { get; set; }
        public decimal pt_netvat { get; set; }
        public decimal pt_ceiling { get; set; }
        public decimal pt_vat { get; set; }
        public string pt_vat_type { get; set; }
        public Nullable<decimal> pt_pdisc { get; set; } = 0;
        public string pt_coupon { get; set; }
        public Nullable<decimal> pt_coupon_disc { get; set; } = 0;
        public int isAllowed { get; set; } = 0;
        public string pt_status { get; set; }
    }
}