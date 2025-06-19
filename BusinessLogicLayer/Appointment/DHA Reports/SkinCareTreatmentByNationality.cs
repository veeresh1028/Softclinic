using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class SkinCareTreatmentByNationality
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.SkinCareTreatmentByNationality> SearchSkinCareTreatmentReport(SkinCareTreatmentReportSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.SkinCareTreatmentByNationality> reports = new List<BusinessEntities.Appointment.DHA_Reports.SkinCareTreatmentByNationality>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.SkinCareTreatmentByNationality.SearchSkinCareTreatmentReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.SkinCareTreatmentByNationality report = new BusinessEntities.Appointment.DHA_Reports.SkinCareTreatmentByNationality();
                        report.tr_name = dr["tr_name"].ToString();
                        report.tr_count = Convert.ToInt32(dr["no_treatment"]);
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
                        report.M_45_64 = Convert.ToInt32(dr["64_m"]);
                        report.F_45_64 = Convert.ToInt32(dr["64_f"]);
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
    }
}