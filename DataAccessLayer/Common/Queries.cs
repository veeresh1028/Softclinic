using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Common;
using System.Web.Mvc;
using System.Xml.Linq;

namespace DataAccessLayer.Common
{
    public class Queries
    {
        #region Queries Page Load
        public static DataTable GetAllQueries(QueriesSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_GetQueries_Auth_Queries");

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

                db.AddInParameter(dbCommand, "select_date_from", DbType.DateTime, filters.select_date_from);
                db.AddInParameter(dbCommand, "select_date_to", DbType.DateTime, filters.select_date_to);

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool InsertUpdateResponses(BusinessEntities.Common.Queries data)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();
                DbCommand dbCommand = db.GetStoredProcCommand("SP_RESPONSES_insert");
                if (data.resId > 0)
                {
                    db.AddInParameter(dbCommand, "resId", DbType.Int32, data.resId);
                }
                db.AddInParameter(dbCommand, "res_query", DbType.Int32, data.res_query);
                db.AddInParameter(dbCommand, "res_desc", DbType.String, data.res_desc);

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
                throw ex;
            }
        } 
        #endregion
    }
}