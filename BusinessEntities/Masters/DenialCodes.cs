using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class DenialCodes
    {
        public int dcId { get; set; }
        public string dc_code { get; set; }
        public string dc_desc { get; set; }
        public string dc_status { get; set; }

        public DateTime dc_date_created { get; set; }
        public string dc_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int dc_madeby { get; set; }
        
    }
}
