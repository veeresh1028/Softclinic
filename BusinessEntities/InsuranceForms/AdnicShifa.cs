using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class AdnicShifa
    {
        public int adsId { get; set; }
        public int ads_appId { get; set; }
        public string ads_voucher { get; set; }
        public string ads_group_mem { get; set; }
        public string ads_type_plan { get; set; }
        public string ads_reason { get; set; }
        public string ads_reason_other { get; set; }
        public string ads_condition { get; set; }
        public string ads_visit { get; set; }
        public string ads_treat_details { get; set; }
        public string ads_addr1 { get; set; }
        public string ads_bill1 { get; set; }
        public string ads_tdate1 { get; set; }
        public string ads_desc1 { get; set; }
        public string ads_amt1 { get; set; }
        public string ads_addr2 { get; set; }
        public string ads_bill2 { get; set; }
        public string ads_tdate2 { get; set; }
        public string ads_desc2 { get; set; }
        public string ads_amt2 { get; set; }
        public string ads_addr3 { get; set; }
        public string ads_bill3 { get; set; }
        public string ads_tdate3 { get; set; }
        public string ads_desc3 { get; set; }
        public string ads_amt3 { get; set; }
        public string ads_addr4 { get; set; }
        public string ads_bill4 { get; set; }
        public string ads_tdate4 { get; set; }
        public string ads_desc4 { get; set; }
        public string ads_amt4 { get; set; }
        public string ads_addr5 { get; set; }
        public string ads_bill5 { get; set; }
        public string ads_tdate5 { get; set; }
        public string ads_desc5 { get; set; }
        public string ads_amt5 { get; set; }
        public string ads_total { get; set; }
       public string ads_oth_above { get; set; }
        public string ads_oth_above_det { get; set; }
        public string ads_oth_claim { get; set; }
        public string ads_oth_claim_det { get; set; }
        public string ads_onset { get; set; }
        public string ads_bank { get; set; }
        public string ads_account { get; set; }
        public string ads_bname { get; set; }
        public string ads_baddress { get; set; }
        public string ads_bcurrency { get; set; }
        public string ads_bswiftcode { get; set; }
        public string ads_witnessname { get; set; }
        public string ads_contact { get; set; }
        public string ads_status { get; set; }
        public DateTime today { get; set; } = DateTime.Now;
    }
}
