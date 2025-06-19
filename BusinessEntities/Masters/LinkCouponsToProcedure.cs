using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class LinkCouponsToProcedure
    {

        public int dtlId { get; set; }
        public string dtl_tr_code { get; set; }
        public int dtl_discId { get; set; }
        public string dtl_status { get; set; }
        public string tr_name { get; set; }
        public string disc_name { get; set; }

        public DateTime dtl_date_created { get; set; }
        public string dtl_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int dtl_madeby { get; set; }
    }
}
