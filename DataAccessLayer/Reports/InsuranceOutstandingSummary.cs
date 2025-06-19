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
    public class InsuranceOutstandingSummary
    {
        public static DataTable SearchInsuranceOutstandingSummary()
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_INSURANCE_OUTSTANDING_REPORT");

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static decimal GetBalance(int inv_insurance, int inv_date_month, int inv_date_year)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_GET_INSURANCE_OUTSTANDING_BALANCE");

                if (inv_date_month == 0)
                {
                    db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv_insurance);
                    db.AddInParameter(dbCommand, "inv_date_year", DbType.Int32, inv_date_year);
                }
                else
                {
                    db.AddInParameter(dbCommand, "inv_insurance", DbType.Int32, inv_insurance);
                    db.AddInParameter(dbCommand, "inv_date_month", DbType.Int32, inv_date_month);
                    db.AddInParameter(dbCommand, "inv_date_year", DbType.Int32, inv_date_year);
                }

                DataTable dt = db.ExecuteDataSet(dbCommand).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToDecimal(dt.Rows[0]["balance_amount"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
