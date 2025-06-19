using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class PatientCountFollowUpVisits
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.PatientCountFollowUpVisits> SearchPatientFollowUpVisits(PatientCountFollowUpVisitsSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.PatientCountFollowUpVisits> reports = new List<BusinessEntities.Appointment.DHA_Reports.PatientCountFollowUpVisits>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.PatientCountFollowUpVisits.SearchPatientFollowUpVisits(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.PatientCountFollowUpVisits report = new BusinessEntities.Appointment.DHA_Reports.PatientCountFollowUpVisits();
                        report.pad_diagnosis = Convert.ToInt32(dr["pad_diagnosis"]);
                        report.diag_code_name = dr["diag_code_name"].ToString();
                        report.M_0_1 = Convert.ToInt32(dr["dpn_0_1M"]);
                        report.F_0_1 = Convert.ToInt32(dr["dpn_0_1F"]);
                        report.M_1_4 = Convert.ToInt32(dr["dpn_1_4M"]);
                        report.F_1_4 = Convert.ToInt32(dr["dpn_1_4F"]);
                        report.M_5_9 = Convert.ToInt32(dr["dpn_5_9M"]);
                        report.F_5_9 = Convert.ToInt32(dr["dpn_5_9F"]);
                        report.M_10_14 = Convert.ToInt32(dr["dpn_10_14M"]);
                        report.F_10_14 = Convert.ToInt32(dr["dpn_10_14F"]);
                        report.M_15_19 = Convert.ToInt32(dr["dpn_15_19M"]);
                        report.F_15_19 = Convert.ToInt32(dr["dpn_15_19F"]);
                        report.M_20_24 = Convert.ToInt32(dr["dpn_20_24M"]);
                        report.F_20_24 = Convert.ToInt32(dr["dpn_20_24F"]);
                        report.M_25_44 = Convert.ToInt32(dr["dpn_25_44M"]);
                        report.F_25_44 = Convert.ToInt32(dr["dpn_25_44F"]);
                        report.M_45_64 = Convert.ToInt32(dr["dpn_45_64M"]);
                        report.F_45_64 = Convert.ToInt32(dr["dpn_45_64F"]);
                        report.M_65_100 = Convert.ToInt32(dr["dpn_0_65M"]);
                        report.F_65_100 = Convert.ToInt32(dr["dpn_0_65F"]);

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