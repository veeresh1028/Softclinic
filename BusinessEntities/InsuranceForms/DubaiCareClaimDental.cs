using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class DubaiCareClaimDental
    {
        public int dcdId { get; set; }
        public int dcd_appId { get; set; }
        public string dcd_1 { get; set; }
        public string dcd_2 { get; set; }
        public string dcd_3 { get; set; }
        public string dcd_4 { get; set; }
        public string dcd_5 { get; set; }
        public decimal dcd_6 { get; set; }
        public string dcd_status { get; set; }
        public DateTime dcd_date_created { get; set; }
        public DateTime dcd_date_modified { get; set; }
    }
}
