using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.FrontDesk
{
    public class GeneralConsent
    {
        public int patId { get; set; }
        public int appId { get; set; }
        public int app_branch { get; set; }
        public string pat_dob { get; set; }
        public string app_fdate { get; set; }
        public string nationality { get; set; }
        public string pat_address { get; set; }
        public string pat_email { get; set; }
        public string pat_tel { get; set; }
        public string pat_mob { get; set; }
        public string pat_gender { get; set; }
        public string pat_sign { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string doc_name { get; set; }
        public string ic_name { get; set; }
        public string pat_emirateid { get; set; }
        public int gcf_madeby { get; set; }
        public int gcfId { get; set; }
        public int gcf_appId { get; set; }
        public string gcf_witness { get; set; }
        public DateTime psb_date_patient { get; set; }
        public DateTime psb_date_witness { get; set; }
    }

    
}
