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
    public class InsuranceEMRCheckingReport
    {
        public static DataTable GetInsuranceEMRReport(InsuranceEMRReportSearch search)
        {
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database db = factory.CreateDefault();

                DbCommand dbCommand = db.GetStoredProcCommand("SP_Get_Insurance_EMR_Checking_Report");

                db.AddInParameter(dbCommand, "select_branch", DbType.String, search.select_branch);

                if (!string.IsNullOrEmpty(search.select_doctors))
                {
                    db.AddInParameter(dbCommand, "select_doctors", DbType.String, search.select_doctors);
                }

                if (!string.IsNullOrEmpty(search.select_ins_tpa))
                {
                    db.AddInParameter(dbCommand, "select_ins_tpa", DbType.String, search.select_ins_tpa);
                }

                if (!string.IsNullOrEmpty(search.select_ins_payer))
                {
                    db.AddInParameter(dbCommand, "select_ins_payer", DbType.String, search.select_ins_payer);
                }

                db.AddInParameter(dbCommand, "select_date_from", DbType.DateTime, search.select_date_from);

                db.AddInParameter(dbCommand, "select_date_to", DbType.DateTime, search.select_date_to);

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