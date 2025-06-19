using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.Masters
{
    public class ComplaintsMaster
    {
        public int cmId { get; set; }
        public string cm_title { get; set; }
        [AllowHtml]

        public string cm_desc { get; set; }
        public string cm_status { get; set; }

        public DateTime cm_date_created { get; set; }
        public string cm_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int cm_madeby { get; set; }
    }
}
