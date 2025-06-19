using BusinessEntities.Masters.Rights;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Designations
    {
        public int desiId { get; set; }
        public string designation { get; set; }
        public string desi_status { get; set; }
        public string actionvisible { get; set; }
        public int empId { get; set; }
        public int desi_madeby { get; set; }

        public int emp_desig { get; set; }
        public string emp_mob { get; set; }
        public string emp_license { get; set; }
        public string emp_name { get; set; }
        public string emp_status { get; set; }
        public string emp_desig_name { get; set; }
        public string emp_dept_name { get; set; }
    }
    public class EmployeesByDesignation
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

    public class DesignationRights
    {
        public int desiId { get; set; }
        public List<Module> modules_list { get; set; }
        public List<Sub_Module> sub_modules_list { get; set; }
        public List<Rights.Pages> pages_list { get; set; }
        public List<string> checked_pages { get; set; }
    }
}