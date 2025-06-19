using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment.DHA_Reports
{
    public class ManpowerByDesignations
    {
        public string designation { get; set; }
        public int M_20 { get; set; }
        public int F_20 { get; set; }
        public int M_20_29 { get; set; }
        public int F_20_29 { get; set; }
        public int M_30_39 { get; set; }
        public int F_30_39 { get; set; }
        public int M_40_49 { get; set; }
        public int F_40_49 { get; set; }
        public int M_50_59 { get; set; }
        public int F_50_59 { get; set; }
        public int M_60_100 { get; set; }
        public int F_60_100 { get; set; }
    }

    public class ManpowerByDesignationsSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; }
        public int select_year { get; set; }
        public string select_nat { get; set; }
    }
}