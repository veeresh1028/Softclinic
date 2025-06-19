using BusinessEntities.Appointment.DHA_Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class ManpowerByDesignations
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.ManpowerByDesignations> SearchManpowerByDesignationsReport(ManpowerByDesignationsSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.ManpowerByDesignations> reports = new List<BusinessEntities.Appointment.DHA_Reports.ManpowerByDesignations>();

                DataTable dt = DataAccessLayer.Appointment.DHA_Reports.ManpowerByDesignations.SearchManpowerByDesignationsReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Appointment.DHA_Reports.ManpowerByDesignations report = new BusinessEntities.Appointment.DHA_Reports.ManpowerByDesignations();
                        report.designation = dr["designations"].ToString();
                        report.M_20 = Convert.ToInt32(dr["M_20"]);
                        report.F_20 = Convert.ToInt32(dr["F_20"]);
                        report.M_20_29 = Convert.ToInt32(dr["M_20_29"]);
                        report.F_20_29 = Convert.ToInt32(dr["F_20_29"]);
                        report.M_30_39 = Convert.ToInt32(dr["M_30_39"]);
                        report.F_30_39 = Convert.ToInt32(dr["F_30_39"]);
                        report.M_40_49 = Convert.ToInt32(dr["M_40_49"]);
                        report.F_40_49 = Convert.ToInt32(dr["F_40_49"]);
                        report.M_50_59 = Convert.ToInt32(dr["M_50_59"]);
                        report.F_50_59 = Convert.ToInt32(dr["F_50_59"]);
                        report.M_60_100 = Convert.ToInt32(dr["M_60_100"]);
                        report.F_60_100 = Convert.ToInt32(dr["F_60_100"]);

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