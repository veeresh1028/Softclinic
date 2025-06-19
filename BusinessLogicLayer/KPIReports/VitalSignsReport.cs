using BusinessEntities.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class VitalSignsReport
    {
        public static List<BusinessEntities.KPIReports.VitalSignsReport> SearchVitalSignsReport(BusinessEntities.KPIReports.VitalSignsReportSearch _filters)
        {
            try
            {
                List<BusinessEntities.KPIReports.VitalSignsReport> reports = new List<BusinessEntities.KPIReports.VitalSignsReport>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.VitalSignsReport.SearchVitalSignsReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.KPIReports.VitalSignsReport report = new BusinessEntities.KPIReports.VitalSignsReport();
                        report.visit_date = Convert.ToDateTime(dr["app_fdate"]);
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.emp_name = dr["emp_name"].ToString();
                        report.emp_dept_name = dr["emp_dept_name"].ToString();
                        report.sign_temp = DataValidation.isDecimalValid(dr["sign_temp"].ToString());
                        report.sign_pulse = DataValidation.isDecimalValid(dr["sign_pulse"].ToString());
                        report.sign_bp = DataValidation.isDecimalValid(dr["sign_bp"].ToString());
                        report.sign_bpd = DataValidation.isDecimalValid(dr["sign_bpd"].ToString());
                        report.sign_height = DataValidation.isDecimalValid(dr["sign_height"].ToString());
                        report.sign_weight = DataValidation.isDecimalValid(dr["sign_weight"].ToString());
                        report.sign_bmi = DataValidation.isDecimalValid(dr["sign_bmi"].ToString());
                        report.sign_resp = DataValidation.isDecimalValid(dr["sign_resp"].ToString());
                        report.sign_spo2 = DataValidation.isDecimalValid(dr["sign_spo2"].ToString());
                        report.sign_hip = DataValidation.isDecimalValid(dr["sign_hip"].ToString());
                        report.sign_waist = DataValidation.isDecimalValid(dr["sign_waist"].ToString());
                        report.sign_head = DataValidation.isDecimalValid(dr["sign_head"].ToString());
                        report.sign_uri = DataValidation.isDecimalValid(dr["sign_uri"].ToString());
                        report.sign_notes = dr["sign_notes"].ToString();

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

        public static List<CommonDDL> GetPatientsByVitalSignsReport(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.VitalSignsReport.GetPatientsByVitalSignsReport(_data);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }
    }
}