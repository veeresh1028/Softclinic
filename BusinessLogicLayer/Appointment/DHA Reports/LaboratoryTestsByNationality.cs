using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class LaboratoryTestsByNationality
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsByNationality> SearchLaboratoryTestsByNationality(LaboratoryTestsReportSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsByNationality> reports = new List<BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsByNationality>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.LaboratoryTestsByNationality.SearchLaboratoryTestsByNationality(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsByNationality report = new BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsByNationality();
                        report.department = dr["department"].ToString();
                        report.tests_count = Convert.ToInt32(dr["tests_count"]);
                        report.M_0_1 = Convert.ToInt32(dr["1_m"]);
                        report.F_0_1 = Convert.ToInt32(dr["1_f"]);
                        report.M_1_4 = Convert.ToInt32(dr["4_m"]);
                        report.F_1_4 = Convert.ToInt32(dr["4_f"]);
                        report.M_4_9 = Convert.ToInt32(dr["9_m"]);
                        report.F_4_9 = Convert.ToInt32(dr["9_f"]);
                        report.M_10_14 = Convert.ToInt32(dr["14_m"]);
                        report.F_10_14 = Convert.ToInt32(dr["14_f"]);
                        report.M_15_19 = Convert.ToInt32(dr["19_m"]);
                        report.F_15_19 = Convert.ToInt32(dr["19_f"]);
                        report.M_20_24 = Convert.ToInt32(dr["24_m"]);
                        report.F_20_24 = Convert.ToInt32(dr["24_f"]);
                        report.M_25_44 = Convert.ToInt32(dr["44_m"]);
                        report.F_25_44 = Convert.ToInt32(dr["44_f"]);
                        report.M_45_59 = Convert.ToInt32(dr["59_m"]);
                        report.F_45_59 = Convert.ToInt32(dr["59_f"]);
                        report.M_60_64 = Convert.ToInt32(dr["64_m"]);
                        report.F_60_64 = Convert.ToInt32(dr["64_f"]);
                        report.M_65_100 = Convert.ToInt32(dr["65_m"]);
                        report.F_65_100 = Convert.ToInt32(dr["65_f"]);

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

        public static List<BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsReport> SearchLaboratoryTestsReport(LaboratoryTestsReportSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsReport> reports = new List<BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsReport>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.LaboratoryTestsByNationality.SearchLaboratoryTestsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsReport report = new BusinessEntities.Appointment.DHA_Reports.LaboratoryTestsReport();
                        report.diag_code_name = dr["diag_code_name"].ToString();
                        report.M_0_1 = Convert.ToInt32(dr["0_1M"]);
                        report.F_0_1 = Convert.ToInt32(dr["0_1F"]);
                        report.M_1_4 = Convert.ToInt32(dr["1_4M"]);
                        report.F_1_4 = Convert.ToInt32(dr["1_4F"]);
                        report.M_4_9 = Convert.ToInt32(dr["4_9M"]);
                        report.F_4_9 = Convert.ToInt32(dr["4_9F"]);
                        report.M_10_14 = Convert.ToInt32(dr["10_14M"]);
                        report.F_10_14 = Convert.ToInt32(dr["10_14F"]);
                        report.M_15_19 = Convert.ToInt32(dr["15_19M"]);
                        report.F_15_19 = Convert.ToInt32(dr["15_19F"]);
                        report.M_20_24 = Convert.ToInt32(dr["20_24M"]);
                        report.F_20_24 = Convert.ToInt32(dr["20_24F"]);
                        report.M_25_44 = Convert.ToInt32(dr["25_44M"]);
                        report.F_25_44 = Convert.ToInt32(dr["25_44F"]);
                        report.M_45_64 = Convert.ToInt32(dr["45_64M"]);
                        report.F_45_64 = Convert.ToInt32(dr["45_64F"]);
                        report.M_65_100 = Convert.ToInt32(dr["65_100M"]);
                        report.F_65_100 = Convert.ToInt32(dr["65_100F"]);

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