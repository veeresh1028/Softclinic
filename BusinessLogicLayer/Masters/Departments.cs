using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Departments
    {
        #region Departments Page Load
        public static List<BusinessEntities.Masters.Departments> GetDepartments(int? deptId)
        {
            List<BusinessEntities.Masters.Departments> departmentlist = new List<BusinessEntities.Masters.Departments>();
            DataTable dt = DataAccessLayer.Masters.Departments.GetDepartments(deptId);

            foreach (DataRow dr in dt.Rows)
            {
                departmentlist.Add(new BusinessEntities.Masters.Departments
                {
                    deptId = Convert.ToInt32(dr["deptId"]),
                    dept_code = Convert.ToInt32(dr["dept_code"]),
                    department = dr["department"].ToString(),
                    dept_flag = dr["dept_flag"].ToString(),
                    actionvisible = dr["actionvisible"].ToString(),
                    dept_status = dr["dept_status"].ToString()
                });
            }
            return departmentlist;
        }
        #endregion

        #region Departments CRUD Operations
        public static bool InsertUpdateDepartment(BusinessEntities.Masters.Departments department)
        {
            return DataAccessLayer.Masters.Departments.InsertUpdateDepartment(department);
        }

        public static int UpdateDepartmentStatus(int deptId, string dept_status)
        {
            return DataAccessLayer.Masters.Departments.UpdateDepartmentStatus(deptId, dept_status);
        }

        public static List<BusinessEntities.Masters.EmployeesByDepartment> GetEmpDepartmentById(int deptId)
        {
            List<BusinessEntities.Masters.EmployeesByDepartment> departmentlist = new List<BusinessEntities.Masters.EmployeesByDepartment>();

            DataTable dt = DataAccessLayer.Masters.Departments.GetEmployeesByDepartment(deptId);

            foreach (DataRow dr in dt.Rows)
            {
                departmentlist.Add(new BusinessEntities.Masters.EmployeesByDepartment
                {
                    empId = Convert.ToInt32(dr["empId"]),
                    emp_desig = Convert.ToInt32(dr["emp_desig"]),
                    emp_license = dr["emp_license"].ToString(),
                    emp_mob = dr["emp_mob"].ToString(),
                    emp_name = dr["emp_name"].ToString(),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    emp_desig_name = dr["emp_desig_name"].ToString(),
                    emp_status = dr["emp_status"].ToString()
                });
            }
            return departmentlist;
        }

        public static List<BusinessEntities.Masters.Departments> GetActiveDepartments()
        {
            List<BusinessEntities.Masters.Departments> departmentlist = new List<BusinessEntities.Masters.Departments>();
            DataTable dt = DataAccessLayer.Masters.Departments.GetActiveDepartments();

            foreach (DataRow dr in dt.Rows)
            {
                departmentlist.Add(new BusinessEntities.Masters.Departments
                {
                    deptId = Convert.ToInt32(dr["deptId"]),
                    department = dr["department"].ToString()
                });
            }
            return departmentlist;
        }

        public static DataTable GetDepartment(int? deptId)
        {
            return DataAccessLayer.Masters.Departments.GetDepartments(deptId);
        }
        #endregion
    }
}
