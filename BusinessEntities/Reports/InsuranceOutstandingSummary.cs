using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Reports
{
    public class InsuranceOutstandingSummary
    {
        public List<OutstandingInsurances> outstandings { get; set; }
    }

    public class OutstandingInsurances
    {
        public int inv_insurance { get; set; }
        public string ic_name { get; set; }
    }
}