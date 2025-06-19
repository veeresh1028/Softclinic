using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class DayMonthYearTDReport
    {
        public static BusinessEntities.Reports.DayMonthYearTDReport SearchDayMonthYearTillDateReport(DayMonthYearTDSearch search)
        {
            try
            {
                BusinessEntities.Reports.DayMonthYearTDReport reportData = new BusinessEntities.Reports.DayMonthYearTDReport();

                DataSet ds = DataAccessLayer.Reports.DayMonthYearTDReport.SearchDayMonthYearTillDateReport(search);

                List<BusinessEntities.Reports.DayTillDate> day = new List<BusinessEntities.Reports.DayTillDate>();
                List<BusinessEntities.Reports.MonthTillDate> mtds = new List<BusinessEntities.Reports.MonthTillDate>();
                List<BusinessEntities.Reports.YearTillDate> ytds = new List<BusinessEntities.Reports.YearTillDate>();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BusinessEntities.Reports.DayTillDate tilltoday = new BusinessEntities.Reports.DayTillDate();
                            tilltoday.setId = DataValidation.isIntValid(dr["setId"].ToString());
                            tilltoday.set_company = dr["set_company"].ToString();
                            tilltoday.total_inv_app = DataValidation.isIntValid(dr["total_inv_app"].ToString());
                            tilltoday.total_invoiced = DataValidation.isDecimalValid(dr["total_invoiced"].ToString());
                            tilltoday.total_pat_paid = DataValidation.isDecimalValid(dr["total_pat_paid"].ToString());
                            tilltoday.total_pat_cc_paid = DataValidation.isDecimalValid(dr["total_pp_cc"].ToString());
                            tilltoday.balance_gtotal = tilltoday.total_pat_paid + tilltoday.total_pat_cc_paid;

                            day.Add(tilltoday);
                        }
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            BusinessEntities.Reports.MonthTillDate mtd = new BusinessEntities.Reports.MonthTillDate();
                            mtd.setId = DataValidation.isIntValid(dr["setId"].ToString());
                            mtd.set_company = dr["set_company"].ToString();
                            mtd.total_inv_app1 = DataValidation.isIntValid(dr["total_inv_app1"].ToString());
                            mtd.total_invoiced1 = DataValidation.isDecimalValid(dr["total_invoiced1"].ToString());
                            mtd.total_pat_paid1 = DataValidation.isDecimalValid(dr["total_pat_paid1"].ToString());
                            mtd.total_pat_cc_paid1 = DataValidation.isDecimalValid(dr["total_pp_cc1"].ToString());
                            mtd.balance_gtotal1 = mtd.total_pat_paid1 + mtd.total_pat_cc_paid1;

                            mtds.Add(mtd);
                        }
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            BusinessEntities.Reports.YearTillDate ytd = new BusinessEntities.Reports.YearTillDate();
                            ytd.setId = DataValidation.isIntValid(dr["setId"].ToString());
                            ytd.set_company = dr["set_company"].ToString();
                            ytd.total_inv_app2 = DataValidation.isIntValid(dr["total_inv_app2"].ToString());
                            ytd.total_invoiced2 = DataValidation.isDecimalValid(dr["total_invoiced2"].ToString());
                            ytd.total_pat_paid2 = DataValidation.isDecimalValid(dr["total_pat_paid2"].ToString());
                            ytd.total_pat_cc_paid2 = DataValidation.isDecimalValid(dr["total_pp_cc2"].ToString());
                            ytd.balance_gtotal2 = ytd.total_pat_paid2 + ytd.total_pat_cc_paid2;

                            ytds.Add(ytd);
                        }
                    }
                }

                reportData.day = day;
                reportData.mtd = mtds;
                reportData.ytd = ytds;

                return reportData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
