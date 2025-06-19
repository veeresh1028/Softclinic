using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class ChiefComplaintsReport
    {
        public static List<BusinessEntities.KPIReports.ChiefComplaintsReport> SearchChiefComplaintsReport(BusinessEntities.KPIReports.ChiefComplaintsReportSearch _filters)
        {
            try
            {
                List<BusinessEntities.KPIReports.ChiefComplaintsReport> reports = new List<BusinessEntities.KPIReports.ChiefComplaintsReport>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.ChiefComplaintsReport.SearchChiefComplaintsReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.KPIReports.ChiefComplaintsReport report = new BusinessEntities.KPIReports.ChiefComplaintsReport();
                        report.visit_date = Convert.ToDateTime(dr["app_fdate"]);
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_file_no = dr["pat_code"].ToString();
                        report.pat_mobile = dr["pat_mob"].ToString();
                        report.doctor_name = dr["emp_name"].ToString();
                        report.department_name = dr["emp_dept_name"].ToString();
                        report.complaint = dr["complaint"].ToString();

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

        public static List<CommonDDL> GetPatientsByChiefComplaints(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.ChiefComplaintsReport.GetPatientsByChiefComplaints(_data);

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