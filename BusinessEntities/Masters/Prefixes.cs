using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Prefixes
    {

        public int pfxId { get; set; }
        public string pfx_prefix { get; set; }
        public string pfx_type { get; set; }
        public string pfx_slno { get; set; }
        public int pfx_branch { get; set; }
        public string pfx_change { get; set; }
        public string pfx_changeby { get; set; }
        public string pfx_status { get; set; }
        public int pfx_madeby { get; set; }
        public DateTime pfx_date_created { get; set; }
        public DateTime pfx_date_modified { get; set; }
        public List<CommonDDL> BranchList { get; set; }
        public string pfx_branch_name { get; set; }
        public string pfx_madeby_name { get; set; }
    }
}
