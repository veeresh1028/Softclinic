using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Rooms
    {
        public int rId { get; set; }
        public string room { get; set; }
        public string room_branch { get; set; }
        public string room_branch_name { get; set; }
        public string room_account { get; set; }
        public string ActionVisible { get; set; }
        public string room_status { get; set; }
        public List<CommonDDL> BranchList { get; set; }
    }
}
