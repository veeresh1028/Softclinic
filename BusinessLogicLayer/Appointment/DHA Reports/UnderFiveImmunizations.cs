using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class UnderFiveImmunizations
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.UnderFiveImmunizations> SearchUnderFiveImmunizationsReport(UnderFiveImmunizationsSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.UnderFiveImmunizations> reports = new List<BusinessEntities.Appointment.DHA_Reports.UnderFiveImmunizations>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.UnderFiveImmunizations.SearchUnderFiveImmunizationsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.UnderFiveImmunizations report = new BusinessEntities.Appointment.DHA_Reports.UnderFiveImmunizations();
                        report.v_name = dr["v_name"].ToString();
                        report.M_0_1 = Convert.ToInt32(dr["M_0_1"]);
                        report.F_0_1 = Convert.ToInt32(dr["F_0_1"]);
                        report.M_0_2 = Convert.ToInt32(dr["M_0_2"]);
                        report.F_0_2 = Convert.ToInt32(dr["F_0_2"]);
                        report.M_0_5 = Convert.ToInt32(dr["M_0_5"]);
                        report.F_0_5 = Convert.ToInt32(dr["F_0_5"]);

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