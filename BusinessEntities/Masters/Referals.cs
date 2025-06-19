using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Referals
    {
        public int refId { get; set; }
        public string ref_login { get; set; }
        public string ref_pass { get; set; }
        public string ref_cpass { get; set; }
        public string ref_status { get; set; }
        public string ref_name { get; set; }
        public string actionvisible { get; set; }
        public string ref_mob { get; set; }
        public string ref_tel { get; set; }
        public string ref_fax { get; set; }
        public string ref_city { get; set; }
        public string ref_email { get; set; }
        public int ref_country { get; set; }
        public string ref_company { get; set; }
        public string ref_type { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public DateTime ref_date_created { get; set; }
        public List<CommonDDL> CountryList { get; set; }
    }
}
