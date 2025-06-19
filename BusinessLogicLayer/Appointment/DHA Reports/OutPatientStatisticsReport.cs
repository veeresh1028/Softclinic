using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class OutPatientStatisticsReport
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.OutPatientStatisticsReport> SearchOutPatientStatisticsReport(OutPatientStatisticsReportSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.OutPatientStatisticsReport> reports = new List<BusinessEntities.Appointment.DHA_Reports.OutPatientStatisticsReport>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.OutPatientStatisticsReport.SearchOutPatientStatisticsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.OutPatientStatisticsReport report = new BusinessEntities.Appointment.DHA_Reports.OutPatientStatisticsReport();
                        report.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        report.app_type = dr["app_type"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.pat_emid = dr["pat_emirateid"].ToString();
                        report.pat_resident_status = dr["pat_resident_status"].ToString();
                        report.pat_city = dr["pat_city"].ToString();
                        report.department = dr["department"].ToString();
                        report.diagnosis_code_1 = dr["diagnosis_code_1"].ToString();
                        report.diagnosis_code_2 = dr["diagnosis_code_2"].ToString();
                        report.diagnosis_code_3 = dr["diagnosis_code_3"].ToString();
                        report.diagnosis_code_4 = dr["diagnosis_code_4"].ToString();
                        report.diagnosis_code_5 = dr["diagnosis_code_5"].ToString();
                        report.treatment_code_1 = dr["treatment_code_1"].ToString();
                        report.treatment_code_2 = dr["treatment_code_2"].ToString();
                        report.treatment_code_3 = dr["treatment_code_3"].ToString();
                        report.treatment_code_4 = dr["treatment_code_4"].ToString();
                        report.treatment_code_5 = dr["treatment_code_5"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_age_years = Convert.ToInt32(dr["pat_age_years"].ToString());
                        report.nationality = dr["nationality"].ToString();

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
    }
}