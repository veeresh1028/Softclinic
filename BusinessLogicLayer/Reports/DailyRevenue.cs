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
    public class DailyRevenue
    {
        public static List<BusinessEntities.Reports.DailyRevenue> SearchDailyRevenueReport(DailyRevenueSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.DailyRevenue> reports = new List<BusinessEntities.Reports.DailyRevenue>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.DailyRevenue.SearchDailyRevenueReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.DailyRevenue report = new BusinessEntities.Reports.DailyRevenue();
                        report.app_doctor = Convert.ToInt32(dr["app_doctor"].ToString());
                        report.doctor = dr["emp_name"].ToString();
                        report.pat_walkin = Convert.ToInt32(dr["tot_cash_patients"].ToString());
                        report.pat_ins = Convert.ToInt32(dr["tot_ins_patients"].ToString());
                        report.pat_old = Convert.ToInt32(dr["tot_old_patients"].ToString());
                        report.pat_new = Convert.ToInt32(dr["tot_new_patients"].ToString());
                        report.tot_cash_inv = DataValidation.isDecimalValid(dr["tot_cash_inv"].ToString());
                        report.tot_ins_inv = DataValidation.isDecimalValid(dr["tot_ins_inv"].ToString());

                        if (report.pat_walkin > 0)
                        {
                            report.tot_cash_avg = Convert.ToDecimal(report.tot_cash_inv / report.pat_walkin);
                        }
                        else
                        {
                            report.tot_cash_avg = 0;
                        }
                        
                        if (report.pat_ins > 0)
                        {
                            report.tot_ins_avg = Convert.ToDecimal(report.tot_ins_inv / report.pat_ins);
                        }
                        else
                        {
                            report.tot_ins_avg = 0;
                        }
                        
                        report.tot_old_inv = DataValidation.isDecimalValid(dr["tot_old_inv"].ToString());
                        report.tot_new_inv = DataValidation.isDecimalValid(dr["tot_new_inv"].ToString());

                        if (report.pat_old > 0)
                        {
                            report.tot_old_avg = Convert.ToDecimal(report.tot_old_inv / report.pat_old);
                        }
                        else
                        {
                            report.tot_old_avg = 0;
                        }

                        if (report.pat_new > 0)
                        {
                            report.tot_new_avg = Convert.ToDecimal(report.tot_new_inv / report.pat_new);
                        }
                        else
                        {
                            report.tot_new_avg = 0;
                        }

                        report.tot_cash = DataValidation.isDecimalValid(dr["cash_total"].ToString());
                        report.tot_cc = DataValidation.isDecimalValid(dr["cc_total"].ToString());
                        report.tot_chq = DataValidation.isDecimalValid(dr["cq_total"].ToString());
                        report.tot_bt = DataValidation.isDecimalValid(dr["bt_total"].ToString());
                        report.tot_bd = DataValidation.isDecimalValid(dr["bd_total"].ToString());
                        report.tot_alloc = DataValidation.isDecimalValid(dr["alloc_total"].ToString());

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