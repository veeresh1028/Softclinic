using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Appointment
{
    public class Doctors
    {
        public static DataTable GetDoctors(string val = null, int setId = 0)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Resources");

                if (!string.IsNullOrEmpty(val))
                {
                    db.AddInParameter(dbCommand, "empIds", DbType.String, val);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "emp_branch", DbType.Int32, setId);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDoctorsWithDateRange(string val = null, int setId = 0, string start = null, string end = null)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Resources_DateRange");

                if (!string.IsNullOrEmpty(val))
                {
                    db.AddInParameter(dbCommand, "empIds", DbType.String, val);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "emp_branch", DbType.Int32, setId);
                }
                db.AddInParameter(dbCommand, "start", DbType.String, start);
                db.AddInParameter(dbCommand, "end", DbType.String, end);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDoctorsBusinessHours(int docId, int branchId, DateTime day)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Resources_BusinessHours");

                db.AddInParameter(dbCommand, "empId", DbType.Int32, docId);
                db.AddInParameter(dbCommand, "emp_branch", DbType.Int32, branchId);
                db.AddInParameter(dbCommand, "day", DbType.DateTime, day);

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable Doctors_Active(int docId, int setId)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_Doctors");

                if (docId > 0)
                {
                    db.AddInParameter(dbCommand, "docId", DbType.Int32, docId);
                }
                if (setId > 0)
                {
                    db.AddInParameter(dbCommand, "setId", DbType.Int32, setId);
                }
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDoctorsByDepartments(string deptIds, string doctor)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Calender_Get_Doctors_By_Departments");

                if (!string.IsNullOrEmpty(deptIds))
                {
                    db.AddInParameter(dbCommand, "deptId", DbType.String, deptIds);
                }

                if (!string.IsNullOrEmpty(doctor))
                {
                    db.AddInParameter(dbCommand, "empId", DbType.String, doctor);
                }

                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetActiveDoctorsByBranches(string branchIds)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_DOCTORS_BY_BRANCHES");

                if (!string.IsNullOrEmpty(branchIds))
                {
                    db.AddInParameter(dbCommand, "branchIds", DbType.String, branchIds);
                }
                DataTable data = db.ExecuteDataSet(dbCommand).Tables[0];

                return data;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
