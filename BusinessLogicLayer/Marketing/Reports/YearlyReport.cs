using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing.Reports
{
    public class YearlyReport
    {
        #region Yearly Enquiry Report (Managed By)
        public static YearlyReportManagedBy YearlyReportManagedby(BusinessEntities.Marketing.Reports.YearlyReport _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.YearlyReportManagedBy data = new BusinessEntities.Marketing.Reports.YearlyReportManagedBy();

                DataTable dt = DataAccessLayer.Marketing.Reports.YearlyReport.YearlyReportManagedby(_filters);

                List<string> managed_by = new List<string>();

                DataTable yearTable = new DataTable();

                yearTable.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    // Add Columns to List Based on Made By Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        managed_by.Add(dr["app_madeby_name"].ToString());
                    }
                    // Add Columns to Datatable From List
                    foreach (string str in managed_by)
                    {
                        yearTable.Columns.Add(str, typeof(string));
                    }

                    IDictionary<int, string> months = BusinessEntities.Marketing.Reports.YearlyReport.MonthList();

                    foreach (var m in months)
                    {
                        DataRow dr = yearTable.NewRow();
                        dr["Date"] = m.Value;

                        foreach (DataRow r in dt.Rows)
                        {
                            string _date = _filters.select_year;

                            int value = Convert.ToInt32(DataAccessLayer.Marketing.Reports.YearlyReport.TotalMadebyCount(r["app_madeby_name"].ToString(), _date, m.Key.ToString("D2")));

                            if (value > 0)
                            {
                                dr[r["app_madeby_name"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"yearlyHistory('" + _date + "', '" + m.Key + "', '" + r["app_madeby_name"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["app_madeby_name"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
                            }
                        }
                        yearTable.Rows.Add(dr);
                    }
                }

                data.managed_by = managed_by;
                data.report = yearTable;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Yearly Enquiries History (Managed By)
        public static List<YearlyHistory> GetYearlyHistory(string app_year, string app_madeby_name, int app_month)
        {
            try
            {
                DataTable dt = DataAccessLayer.Marketing.Reports.YearlyReport.GetYearlyHistory(app_year, app_madeby_name, app_month);

                List<BusinessEntities.Marketing.Reports.YearlyHistory> yreports = new List<BusinessEntities.Marketing.Reports.YearlyHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        YearlyHistory report = new YearlyHistory();

                        report.appId = Convert.ToInt32(dr["appId"]);
                        report.app_status = dr["app_status"].ToString();
                        report.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        report.app_date_created = Convert.ToDateTime(dr["app_date_created"]);
                        report.emp_name = dr["emp_name"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_email = dr["pat_email"].ToString();
                        report.source_details = dr["source_details"].ToString();
                        report.campaign_details = dr["campaign_details"].ToString();
                        report.app_comments = dr["app_comments"].ToString();
                        report.app_madeby_name = dr["app_madeby_name"].ToString();

                        yreports.Add(report);
                    }
                }
                return yreports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Yearly Enquiry Report (By Source)
        public static YearlySourceReportData GetYearlyReportBySource(BusinessEntities.Marketing.Reports.YearlySourceReport _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.YearlySourceReportData data = new BusinessEntities.Marketing.Reports.YearlySourceReportData();

                DataTable dt = DataAccessLayer.Marketing.Reports.YearlyReport.GetYearlyReportBySource(_filters);

                List<string> sources = new List<string>();

                DataTable yearTable = new DataTable();

                yearTable.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    // Add Columns to List Based on Made By Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        sources.Add(dr["app_source_name"].ToString());
                    }
                    // Add Columns to Datatable From List
                    foreach (string str in sources)
                    {
                        yearTable.Columns.Add(str, typeof(string));
                    }

                    IDictionary<int, string> months = BusinessEntities.Marketing.Reports.YearlyReport.MonthList();

                    foreach (var m in months)
                    {
                        DataRow dr = yearTable.NewRow();
                        dr["Date"] = m.Value;

                        foreach (DataRow r in dt.Rows)
                        {
                            string _date = _filters.select_year;

                            int value = Convert.ToInt32(DataAccessLayer.Marketing.Reports.YearlyReport.TotalMadebyCountSource(r["app_source_name"].ToString(), _date, m.Key.ToString("D2")));

                            if (value > 0)
                            {
                                dr[r["app_source_name"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"yearlySourceHistory('" + _date + "', '" + m.Key + "', '" + r["app_source_name"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["app_source_name"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
                            }
                        }
                        yearTable.Rows.Add(dr);
                    }
                }
                data.sources = sources;
                data.report = yearTable;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Yearly Enquiries History (By Source)
        public static List<YearlySourceHistory> GetYearlySourceHistory(string app_year, string app_source_name, int app_month)
        {
            try
            {
                DataTable dt = DataAccessLayer.Marketing.Reports.YearlyReport.GetYearlySourceHistory(app_year, app_source_name, app_month);

                List<BusinessEntities.Marketing.Reports.YearlySourceHistory> ysreports = new List<BusinessEntities.Marketing.Reports.YearlySourceHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        YearlySourceHistory report = new YearlySourceHistory();

                        report.appId = Convert.ToInt32(dr["appId"]);
                        report.app_status = dr["app_status"].ToString();
                        report.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        report.app_date_created = Convert.ToDateTime(dr["app_date_created"]);
                        report.emp_name = dr["emp_name"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_email = dr["pat_email"].ToString();
                        report.source_details = dr["source_details"].ToString();
                        report.campaign_details = dr["campaign_details"].ToString();
                        report.app_comments = dr["app_comments"].ToString();
                        report.app_madeby_name = dr["app_madeby_name"].ToString();

                        ysreports.Add(report);
                    }
                }
                return ysreports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
