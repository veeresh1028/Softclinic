using BusinessEntities.Reports;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Reports
{
    public class PackageReports
    {
        public static DataTable SearchPackageReports(PackageReportSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_PatientPackage_Report");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_dept))
                {
                    db.AddInParameter(dbCommand, "select_dept", DbType.String, filters.select_dept);
                }

                if (!string.IsNullOrEmpty(filters.select_doctor))
                {
                    db.AddInParameter(dbCommand, "select_doctor", DbType.String, filters.select_doctor);
                }

                if (filters.select_treat > 0)
                {
                    db.AddInParameter(dbCommand, "select_Package", DbType.Int32, filters.select_treat);
                }

                if (!string.IsNullOrEmpty(filters.select_type))
                {
                    string type = string.Join(",", filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, type);
                }

                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, filters.date_from);

                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, filters.date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetActivePackages(string query, int emp_branch)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_ACTIVE_PackageS");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, emp_branch);
                db.AddInParameter(dbCommand, "query", DbType.String, query);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
