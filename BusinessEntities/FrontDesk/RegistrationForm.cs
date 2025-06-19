using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.FrontDesk
{
    public class RegistrationForm
    {
        public int patId { get; set; }
        public int appId { get; set; }
        public DateTime pat_dob { get; set; }
        public DateTime app_fdate { get; set; }
        public int pat_nat { get; set; }
        public string set_company { get; set; }
        public string pat_address { get; set; }
        public string pat_email { get; set; }
        public string pat_tel { get; set; }
        public string pat_mob { get; set; }
        public string pat_hear { get; set; }
        public string pat_gender { get; set; }
        public int pat_referal { get; set; }
        public string psb_sign { get; set; }
        public string psb_person { get; set; }
        public DateTime psb_date_created { get; set; }
        public string psb_form { get; set; }
        public string pat_sign { get; set; }
        public string pat_name { get; set; }
        public string pat_code { get; set; }
        public string ic_name { get; set; }
        public string nationality { get; set; }
        public string ref_name { get; set; }
        public int pat_madeby { get; set; }
        public int app_branch { get; set; }
    }
}
