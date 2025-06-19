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
    public class VATReport
    {
        public static DataSet SearchVATReport(VATSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_VAT_REPORT");

                db.AddInParameter(dbCommand, "select_branch", DbType.Int32, search.select_branch);
                db.AddInParameter(dbCommand, "select_type", DbType.String, search.select_type);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                DataSet ds = db.ExecuteDataSet(dbCommand);

                return ds;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static DataTable GetVATTypeReport(VATTypeSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_VAT_TYPE_REPORT");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_type))
                {
                    string select_type = string.Join(",", filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, select_type);
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

        public static DataTable GetPurchaseVATReport(PurchaseVATSearch filters)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Purchase_VAT_Report");

                if (!string.IsNullOrEmpty(filters.select_branch))
                {
                    db.AddInParameter(dbCommand, "select_branch", DbType.String, filters.select_branch);
                }

                if (!string.IsNullOrEmpty(filters.select_type))
                {
                    string select_type = string.Join(",", filters.select_type.Split(',').Select(x => string.Format("'{0}'", x)).ToList());
                    db.AddInParameter(dbCommand, "select_type", DbType.String, select_type);
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

        public static DataTable GetSalesInvoiceVATDetail(VATSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Sales_Invoice_VAT_Detail");

                db.AddInParameter(dbCommand, "branch", DbType.Int32, search.select_branch);
                db.AddInParameter(dbCommand, "date_from", DbType.DateTime, search.date_from);
                db.AddInParameter(dbCommand, "date_to", DbType.DateTime, search.date_to);

                db.ExecuteNonQuery(dbCommand);

                DataTable result = db.ExecuteDataSet(dbCommand).Tables[0];

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}