using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class PatientDiagnosisReport
    {
        public static List<BusinessEntities.KPIReports.PatientDiagnosisReport> SearchPatientDiagnosisReport(BusinessEntities.KPIReports.PatientDiagnosisReportSearch _filters)
        {
            try
            {
                List<BusinessEntities.KPIReports.PatientDiagnosisReport> reports = new List<BusinessEntities.KPIReports.PatientDiagnosisReport>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.PatientDiagnosisReport.SearchPatientDiagnosisReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.KPIReports.PatientDiagnosisReport report = new BusinessEntities.KPIReports.PatientDiagnosisReport();
                        report.visit_date = Convert.ToDateTime(dr["app_fdate"]);
                        report.doctor_name = dr["emp_name"].ToString();
                        report.department_name = dr["emp_dept_name"].ToString();
                        report.pat_file_no = dr["pat_code"].ToString();
                        report.pat_mobile = dr["pat_mob"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.ic_type = dr["is_ic_name"].ToString();
                        report.payer_name = dr["is_ip_name"].ToString();
                        report.ins_no = dr["pi_insno"].ToString();
                        report.diag_codes = dr["diag_codes"].ToString();
                        report.diag_names = dr["diag_names"].ToString();

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

        public static List<CommonDDL> GetPatientsByDiagnosis(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.PatientDiagnosisReport.GetPatientsByDiagnosis(_data);

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

        public static List<PatientDiagnosisDDL> GetDiagnosis(SearchQuery _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.PatientDiagnosisReport.GetDiagnosis(_data);

            List<PatientDiagnosisDDL> data = new List<PatientDiagnosisDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new PatientDiagnosisDDL
                    {
                        id = dr["code"].ToString(),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }
    }
}