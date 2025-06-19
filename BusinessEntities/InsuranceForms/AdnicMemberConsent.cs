using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class AdnicMemberConsent
    {
        public int mcafId { get; set; }
        public int mcaf_appId { get; set; }
        public string mcaf_mem_name { get; set; }
        public string mcaf_pat_name { get; set; }
        public string mcaf_pat_memno { get; set; }
        public string mcaf_relationship { get; set; }
        public string mcaf_pat_fileno { get; set; }
        public string mcaf_pat_mob { get; set; }
        public string mcaf_auth { get; set; }
        public string mcaf_auth1 { get; set; }
        public string mcaf_status { get; set; }
    }
}
