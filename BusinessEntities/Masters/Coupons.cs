using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.Masters
{
    public class Coupons
    {
        public int discId { get; set; }
        public string disc_name { get; set; }
        public decimal disc_float { get; set; }
        public string disc_status { get; set; }
        public int disc_madeby { get; set; }      
        public string disc_branches { get; set; }
        public string disc_branch_name { get; set; }
        public string disc_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public List<CommonDDL> BranchList { get; set; }
    }
}
