using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class AppointmentStatusColor
    {
        public int apsId { get; set; }
        public string aps_status { get; set; }
        public string aps_color { get; set; }
        public string aps_activity_status { get; set; }

        public DateTime aps_date_created { get; set; }
        public string cm_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int aps_madeby { get; set; }
    }
}
