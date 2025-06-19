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
    public class DoctorsComissionReport
    {
        public static List<BusinessEntities.Reports.DoctorsComissionReport> SearchDoctorsCommissionReports(DoctorsCommissionSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.DoctorsComissionReport> reports = new List<BusinessEntities.Reports.DoctorsComissionReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.DoctorsComissionReport.SearchDoctorsCommissionReports(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.DoctorsComissionReport report = new BusinessEntities.Reports.DoctorsComissionReport();
                        report.empId = Convert.ToInt32(dr["empId"].ToString());
                        report.pt_app_doctor_name = dr["pt_app_doctor_name"].ToString();
                        report.pt_consultation_commi = DataValidation.isDecimalValid(dr["pt_consultation_commi"].ToString());
                        report.pt_procedure_commi = DataValidation.isDecimalValid(dr["pt_procedure_commi"].ToString());
                        report.pt_lab_commi = DataValidation.isDecimalValid(dr["pt_lab_commi"].ToString());
                        report.pt_rad_commi = DataValidation.isDecimalValid(dr["pt_rad_commi"].ToString());
                        report.pt_pha_commi = DataValidation.isDecimalValid(dr["pt_pha_commi"].ToString());
                        report.pt_met_commi = DataValidation.isDecimalValid(dr["pt_met_commi"].ToString());

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

        public static List<BusinessEntities.Reports.DoctorsComissionReportDetails> GetDoctorsComissionDetails(int empId, string type)
        {
            try
            {
                List<BusinessEntities.Reports.DoctorsComissionReportDetails> details = new List<BusinessEntities.Reports.DoctorsComissionReportDetails>();

                DataTable dt = DataAccessLayer.Reports.DoctorsComissionReport.GetDoctorsComissionDetails(empId, type);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.DoctorsComissionReportDetails detail = new BusinessEntities.Reports.DoctorsComissionReportDetails();
                        detail.ptId = Convert.ToInt32(dr["ptId"].ToString());
                        detail.pt_appId = Convert.ToInt32(dr["pt_appId"].ToString());
                        detail.pt_type = dr["pt_type"].ToString();
                        detail.pt_tr_code = dr["pt_tr_code"].ToString();
                        detail.pt_tr_name = dr["pt_tr_name"].ToString();
                        detail.pt_qty = DataValidation.isDecimalValid(dr["pt_qty"].ToString());
                        detail.pt_total = DataValidation.isDecimalValid(dr["pt_total"].ToString());
                        detail.pt_uprice = DataValidation.isDecimalValid(dr["pt_uprice"].ToString());
                        detail.pt_disc = DataValidation.isDecimalValid(dr["pt_disc"].ToString());
                        detail.pt_net = DataValidation.isDecimalValid(dr["pt_net"].ToString());
                        detail.pt_vat = DataValidation.isDecimalValid(dr["pt_vat"].ToString());
                        detail.pt_app_fdate = Convert.ToDateTime(dr["pt_app_fdate"].ToString());
                        detail.pt_netvat = detail.pt_net + detail.pt_vat;
                        detail.pat_name = dr["pat_name"].ToString();

                        details.Add(detail);
                    }
                }

                return details;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}