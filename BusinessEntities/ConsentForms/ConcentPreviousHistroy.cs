using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConcentForms
{
    public class ConcentPreviousHistroy
    {
        public int formId { get; set; }
        public int appId { get; set; }
        public string emp_license { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string app_fdate { get; set; }
    }
}
