using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class CPTCodeItemsMapping
    {
        public int cptId { get; set; }
        public string cpt_item { get; set; }
        public string cpt_item1 { get; set; }
        public string cpt_code { get; set; }
        public string cpt_uom { get; set; }
        public string cpt_notes { get; set; }
        public string emp_name { get; set; }
        public string cpt_status { get; set; }

        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string item_code { get; set; }
        public string item_name { get; set; }
        public string cpt_qty { get; set; }

        public string cpt_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int cpt_madeby { get; set; }

        
    }
}
