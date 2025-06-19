using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.InsuranceForms
{
    public class AafiyaFormDental
    {
        public int mcdId { get; set; }
        public int mcd_appId { get; set; }
        public string mcd_referral { get; set; }
        public string mcd_radio { get; set; }
        public string mcd_investigation { get; set; }
        public decimal mcd_cost { get; set; }
        public string mcd_prescription { get; set; }
        public string mcd_status { get; set; }
        public DateTime mcd_date_created { get; set; }
        public DateTime mcd_date_modified { get; set; }
    }
}
