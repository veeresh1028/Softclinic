using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Vaccinations
    {

        public int vId { get; set; }
        public string v_code { get; set; }
        public string v_name { get; set; }
        public string v_status { get; set; }
        public DateTime v_date_created { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int v_madeby { get; set; }
        
    }
}
