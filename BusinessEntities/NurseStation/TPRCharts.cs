using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
  

    public class TRPChartData
    {
        public List<string> labels { get; set; }
        public List<string> tempratures { get; set; }
        public List<string> respiratorys { get; set; }
        public List<string> pulses { get; set; }
        public List<string> weights { get; set; }
        public List<string> bmi { get; set; }

    }



}
