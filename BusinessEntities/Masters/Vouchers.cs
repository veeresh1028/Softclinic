using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Vouchers
    {
        public int vouId { get; set; }
        public string vou_code { get; set; }
        public string vou_from { get; set; }
        public decimal vou_amount { get; set; }
        public string vou_notes { get; set; }
        public string vou_branch { get; set; }
        public int vou_madeby { get; set; }
        public string vou_status { get; set; }
        public string vou_branch_name { get; set; }
        public string vou_madeby_name { get; set; }
        public DateTime vou_date { get; set; }
        public DateTime vou_edate { get; set; }
        public string actionvisible { get; set; }
        public List<CommonDDL> BranchList { get; set; }
    }
}