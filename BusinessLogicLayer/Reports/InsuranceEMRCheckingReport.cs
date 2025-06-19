using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class InsuranceEMRCheckingReport
    {
        public static List<BusinessEntities.Reports.InsuranceEMRCheckingReport> GetInsuranceEMRReport(InsuranceEMRReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.InsuranceEMRCheckingReport> report = new List<BusinessEntities.Reports.InsuranceEMRCheckingReport>();

                DataTable dt = DataAccessLayer.Reports.InsuranceEMRCheckingReport.GetInsuranceEMRReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.InsuranceEMRCheckingReport data = new BusinessEntities.Reports.InsuranceEMRCheckingReport();
                        data.ic_code = dr["ic_code"].ToString();
                        data.ic_name = dr["ic_name"].ToString();
                        data.ip_code = dr["ip_code"].ToString();
                        data.ip_name = dr["ip_name"].ToString();
                        data.is_title = dr["is_title"].ToString();
                        data.patId = Convert.ToInt32(dr["patId"].ToString());
                        data.pat_code = Convert.ToInt32(dr["pat_code"].ToString());
                        data.pat_mob = dr["pat_mob"].ToString();
                        data.pat_name = dr["pat_name"].ToString();
                        data.empId = Convert.ToInt32(dr["empId"].ToString());
                        data.emp_name = dr["emp_name"].ToString();
                        data.emp_dept_name = dr["emp_dept_name"].ToString();
                        data.emp_license = dr["emp_license"].ToString();
                        data.inv_no = dr["inv_no"].ToString();
                        data.inv_date = Convert.ToDateTime(dr["inv_date"].ToString());
                        data.inv_net = SecurityLayer.DataValidation.isDecimalValid(dr["inv_net"].ToString());
                        data.pat_share = SecurityLayer.DataValidation.isDecimalValid(dr["pat_share"].ToString());

                        report.Add(data);
                    }
                }

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}