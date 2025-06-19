using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CurrentUser
    {
        public bool isValid { get; set; }
        public int empId { get; set; }
        public string emp_name { get; set; }
        public string emp_login { get; set; }
        public int emp_desig { get; set; }
        public string designation { get; set; }
        public int emp_dept { get; set; }
        public string emp_dept_name { get; set; }
        public int emp_branch { get; set; }
        public string set_company { get; set; }
        public string header_logo { get; set; }
        public string footer_logo { get; set; }
        public string emp_whatsappId { get; set; }
        public string emp_photo { get; set; }
        public int password_validity { get; set; }
        public string emp_outside_access { get; set; }
    }
}