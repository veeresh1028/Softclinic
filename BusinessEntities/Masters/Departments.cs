using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Departments
    {
        public int deptId { get; set; }
        public int dept_code { get; set; }
        public string department { get; set; }
        public string dept_status { get; set; }
        public string actionvisible { get; set; }
        public string dept_flag { get; set; }
    }
    public class EmployeesByDepartment
    {
        public int empId { get; set; }
        public int emp_desig { get; set; }
        public string emp_mob { get; set; }
        public string emp_license { get; set; }
        public string emp_name { get; set; }
        public string emp_status { get; set; }
        public string emp_desig_name { get; set; }
        public string emp_dept_name { get; set; }
    }
}
