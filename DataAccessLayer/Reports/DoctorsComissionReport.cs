using BusinessEntities.Reports;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataAccessLayer.Reports
{
    public class DoctorsComissionReport
    {
        public static DataTable SearchDoctorsCommissionReports(DoctorsCommissionSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Doctors_Commission_Report");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_dept))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.select_dept);
                }

                if (!string.IsNullOrEmpty(filters.select_type))
                {
                    string select_type = string.Join(",", filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, select_type);
                }

                if (!string.IsNullOrEmpty(filters.select_doctor))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.select_doctor);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable GetDoctorsComissionDetails(int empId, string type)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Doctors_Commission_Details");

                if (!string.IsNullOrEmpty(type))
                {
                    string pt_type = string.Join(",", type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "type", DbType.String, pt_type);
                }

                db.AddInParameter(dbCommand, "empId", DbType.Int32, empId);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}