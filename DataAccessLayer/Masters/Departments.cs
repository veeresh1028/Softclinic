using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Masters
{
    public class Departments
    {
        #region Departments Page Load
        public static DataTable GetDepartments(int? deptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DEPARTMENTS_select_all_info");
                if (deptId > 0)
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.Int32, deptId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Departments CRUD Operations
        public static bool InsertUpdateDepartment(BusinessEntities.Masters.Departments department)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DEPARTMENTS_INSERT_UPDATE");
                if (department.deptId > 0)
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.Int32, department.deptId);
                }
                db.AddInParameter(dbCommand, "department", DbType.String, department.department);
                db.AddInParameter(dbCommand, "dept_flag", DbType.String, department.dept_flag);

                int result = db.ExecuteNonQuery(dbCommand);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetDepartmentById(int deptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DEPARTMENTS_select_all_info");
                if (deptId > 0)
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.Int32, deptId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static int UpdateDepartmentStatus(int deptId, string dept_status)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DEPARTMENTS_UPDATE_STATUS");

                db.AddInParameter(dbCommand, "deptId", DbType.Int32, deptId);
                db.AddInParameter(dbCommand, "dept_status", DbType.String, dept_status);
                db.AddOutParameter(dbCommand, "dept_output", DbType.Int32, 100);

                db.ExecuteNonQuery(dbCommand);

                return Convert.ToInt32(db.GetParameterValue(dbCommand, "dept_output").ToString());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetEmployeesByDepartment(int deptId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_EMPLYOEES_BY_DESIGNATION_DEPARTMENT");
                if (deptId > 0)
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.Int32, deptId);
                }
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetActiveDepartments()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_DEPARTMENTS_SELECT_ALL_ACTIVE");
                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}