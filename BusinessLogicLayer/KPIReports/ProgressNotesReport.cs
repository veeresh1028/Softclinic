using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class ProgressNotesReport
    {
        public static List<BusinessEntities.KPIReports.ProgressNotesReport> SearchProgressNotesReport(BusinessEntities.KPIReports.ProgressNotesReportSearch _filters)
        {
            try
            {
                List<BusinessEntities.KPIReports.ProgressNotesReport> reports = new List<BusinessEntities.KPIReports.ProgressNotesReport>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.ProgressNotesReport.SearchProgressNotesReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.KPIReports.ProgressNotesReport report = new BusinessEntities.KPIReports.ProgressNotesReport();
                        report.visit_date = Convert.ToDateTime(dr["app_fdate"]);
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.emp_name = dr["emp_name"].ToString();
                        report.emp_dept_name = dr["emp_dept_name"].ToString();
                        report.mn_notes = dr["mn_notes"].ToString();
                        report.mn_visitPlan = dr["mn_visitPlan"].ToString();
                        report.mn_instructions = dr["mn_instructions"].ToString();
                        report.mn_date_created = Convert.ToDateTime(dr["mn_date_created"]);

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

        public static List<CommonDDL> GetPatientsByProgressNotes(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.ProgressNotesReport.GetPatientsByProgressNotes(_data);

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