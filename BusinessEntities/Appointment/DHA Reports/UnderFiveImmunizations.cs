using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment.DHA_Reports
{
    public class UnderFiveImmunizations
    {
        public string v_name { get; set; }
        public int M_0_1 { get; set; }
        public int F_0_1 { get; set; }
        public int M_0_2 { get; set; }
        public int F_0_2 { get; set; }
        public int M_0_5 { get; set; }
        public int F_0_5 { get; set; }
    }

    public class UnderFiveImmunizationsSearch
    {
        public int search_type { get; set; } = 0;
        public string select_branch { get; set; }
        public int select_month { get; set; }
        public int select_year { get; set; }
        public string select_nat { get; set; }
    }
}