using BusinessEntities.Appointment;
using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class PackageReports
    {
        public static List<BusinessEntities.Reports.PackageReports> SearchPackageReports(PackageReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PackageReports> reports = new List<BusinessEntities.Reports.PackageReports>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.PackageReports.SearchPackageReports(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PackageReports report = new BusinessEntities.Reports.PackageReports();
                        report.apsId = Convert.ToInt32(dr["apsId"].ToString());
                        report.aps_appId = Convert.ToInt32(dr["aps_appId"].ToString());
                        report.Package = dr["Package"].ToString();
                        report.PackageAmount = DataValidation.isDecimalValid(dr["PackageAmount"].ToString());
                        report.Deposit = DataValidation.isDecimalValid(dr["Deposit"].ToString());
                        report.AdvanceBalnce = DataValidation.isDecimalValid(dr["AdvanceBalnce"].ToString());
                        report.Paid = DataValidation.isDecimalValid(dr["Paid"].ToString());
                        report.inv_no = dr["inv_no"].ToString();
                        report.tot_ses = int.Parse(dr["tot_ses"].ToString());
                        report.Balance = DataValidation.isDecimalValid(dr["Balance"].ToString());
                        

                        reports.Add(report);
                    }
                }

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CommonDDL> GetActivePackages(string query, int emp_branch)
        {
            DataTable dt = DataAccessLayer.Reports.PackageReports.GetActivePackages(query, emp_branch);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = Convert.ToInt32(dr["trId"].ToString());
                    _data.text = dr["tr_name"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
    }
}
