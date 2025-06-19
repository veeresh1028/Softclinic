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
    public class TreatmentReports
    {
        public static List<BusinessEntities.Reports.TreatmentReports> SearchTreatmentReports(TreatmentReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.TreatmentReports> reports = new List<BusinessEntities.Reports.TreatmentReports>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.TreatmentReports.SearchTreatmentReports(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.TreatmentReports report = new BusinessEntities.Reports.TreatmentReports();
                        report.ptId = Convert.ToInt32(dr["ptId"].ToString());
                        report.pt_inv_status = dr["pt_inv_status"].ToString();
                        report.pt_vat = DataValidation.isDecimalValid(dr["pt_vat"].ToString());
                        report.pt_total = DataValidation.isDecimalValid(dr["pt_total"].ToString());
                        report.pt_disc = DataValidation.isDecimalValid(dr["pt_disc"].ToString());
                        report.pt_ded = DataValidation.isDecimalValid(dr["pt_ded"].ToString());
                        report.pt_invno = dr["pt_invno"].ToString();
                        report.pt_copay = DataValidation.isDecimalValid(dr["pt_copay"].ToString());
                        report.pt_share = DataValidation.isDecimalValid(dr["pt_share"].ToString());
                        report.pt_net = DataValidation.isDecimalValid(dr["pt_net"].ToString());
                        report.pt_treatment = Convert.ToInt32(dr["pt_treatment"].ToString());
                        report.pt_inv_date = Convert.ToDateTime(dr["pt_inv_date"].ToString());
                        report.pat_code = dr["pat_code"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.ins_exp = dr["ins_exp"].ToString();
                        report.emp_name = dr["emp_name"].ToString();
                        report.emp_dept_name = dr["emp_dept_name"].ToString();
                        report.emp_license = dr["emp_license"].ToString();
                        report.tr_name = dr["tr_name"].ToString();
                        report.tr_cost = DataValidation.isDecimalValid(dr["tr_cost"].ToString());
                        report.tr_type = dr["tr_type"].ToString();

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

        public static List<CommonDDL> GetActiveTreatments(string query, int emp_branch)
        {
            DataTable dt = DataAccessLayer.Reports.TreatmentReports.GetActiveTreatments(query, emp_branch);

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