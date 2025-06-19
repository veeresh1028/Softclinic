using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters.AuditLogs
{
    public class EmployeeLogs
    {
        public int empId { get; set; }
        public int empaId { get; set; }
        public string empa_login { get; set; }
        public string empa_name { get; set; }
        public string empa_lname { get; set; }
        public string empa_license { get; set; }
        public string empa_dept_name { get; set; }
        public string empa_desig_name { get; set; }
        public string empa_mob { get; set; }
        public string empa_status { get; set; }
        public string empa_operation { get; set; }
        public string empa_madeby_name { get; set; }
        public DateTime empa_date_created { get; set; }
        public DateTime empa_date_modified { get; set; }
    }
}
