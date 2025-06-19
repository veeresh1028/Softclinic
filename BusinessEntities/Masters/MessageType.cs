using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class MessageType
    {
        public int mtId { get; set; }
        public string mt_type { get; set; }
        public string mt_tat { get; set; }
        public string mt_branch_name { get; set; }
        public string mt_desig_name { get; set; }
        public int mt_branch { get; set; }
        public int mt_desig { get; set; }
        public int mt_emp { get; set; }
        public string mt_status { get; set; }
        public string mt_emp_name { get; set; }
        public int mt_madeby { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public DateTime mt_date_created { get; set; }
        public List<CommonDDL> BranchList { get; set; }
    }
}
