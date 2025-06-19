using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class OutPatientsWaitingTimeByMinutes
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.OutPatientsWaitingTimeByMinutes> SearchOutPatientsWaitingTime(OutPatientsWaitingTimeReportSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.OutPatientsWaitingTimeByMinutes> reports = new List<BusinessEntities.Appointment.DHA_Reports.OutPatientsWaitingTimeByMinutes>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.OutPatientsWaitingTimeByMinutes.SearchPatientVisitByDiagnosis(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.OutPatientsWaitingTimeByMinutes report = new BusinessEntities.Appointment.DHA_Reports.OutPatientsWaitingTimeByMinutes();
                        report.emp_speciality = dr["emp_speciality"].ToString();
                        report.M_0_1 = Convert.ToInt32(dr["M_0_1"]);
                        report.F_0_1 = Convert.ToInt32(dr["F_0_1"]);
                        report.M_1_4 = Convert.ToInt32(dr["M_1_4"]);
                        report.F_1_4 = Convert.ToInt32(dr["F_1_4"]);
                        report.M_5_9 = Convert.ToInt32(dr["M_5_9"]);
                        report.F_5_9 = Convert.ToInt32(dr["F_5_9"]);
                        report.M_10_14 = Convert.ToInt32(dr["M_10_14"]);
                        report.F_10_14 = Convert.ToInt32(dr["F_10_14"]);
                        report.M_15_19 = Convert.ToInt32(dr["M_15_19"]);
                        report.F_15_19 = Convert.ToInt32(dr["F_15_19"]);
                        report.M_20_24 = Convert.ToInt32(dr["M_20_24"]);
                        report.F_20_24 = Convert.ToInt32(dr["F_20_24"]);
                        report.M_25_44 = Convert.ToInt32(dr["M_25_44"]);
                        report.F_25_44 = Convert.ToInt32(dr["F_25_44"]);
                        report.M_45_64 = Convert.ToInt32(dr["M_45_64"]);
                        report.F_45_64 = Convert.ToInt32(dr["F_45_64"]);
                        report.M_65_100 = Convert.ToInt32(dr["M_65_100"]);
                        report.F_65_100 = Convert.ToInt32(dr["F_65_100"]);

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