using BusinessEntities.Marketing.Reports;
using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class ReferralReport
    {
        #region Yearly Referral Report
        public static BusinessEntities.Reports.ReferralReport GetYearlyReferralReport(BusinessEntities.Reports.ReferralReportSearch _filters)
        {
            try
            {
                BusinessEntities.Reports.ReferralReport data = new BusinessEntities.Reports.ReferralReport();

                DataTable dt = DataAccessLayer.Reports.ReferralReport.GetYearlyReferralReport(_filters);

                List<string> sources = new List<string>();

                DataTable yearTable = new DataTable();

                yearTable.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    // Add Columns to List Based on Made By Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        sources.Add(dr["pat_source_name"].ToString());
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

                            int value = Convert.ToInt32(DataAccessLayer.Reports.ReferralReport.TotalReferralPatientCount(r["pat_source_name"].ToString(), _date, m.Key.ToString("D2")));

                            if (value > 0)
                            {
                                dr[r["pat_source_name"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"yearlySourceHistory('" + _date + "', '" + m.Key + "', '" + r["pat_source_name"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["pat_source_name"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
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

        #region Yearly Referral Report History
        public static List<YearlyReportHistory> GetYearlyReferralHistory(string pat_year, string pat_source_name, int pat_month)
        {
            try
            {
                DataTable dt = DataAccessLayer.Reports.ReferralReport.GetYearlyReferralHistory(pat_year, pat_source_name, pat_month);

                List<BusinessEntities.Reports.YearlyReportHistory> ysreports = new List<BusinessEntities.Reports.YearlyReportHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        YearlyReportHistory report = new YearlyReportHistory();

                        report.patId = Convert.ToInt32(dr["patId"]);
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"]);
                        report.pat_madeby_name = dr["pat_madeby_name"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();

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

        #region Monthly Referral Report
        public static BusinessEntities.Reports.ReferralReport GetMonthlyReferralReport(BusinessEntities.Reports.MonthlyReferralReportSearch _filters)
        {
            try
            {
                BusinessEntities.Reports.ReferralReport data = new BusinessEntities.Reports.ReferralReport();

                DateTime date_from = new DateTime(_filters.select_year, _filters.select_month, 1);

                int daysInMonth = DateTime.DaysInMonth(date_from.Year, date_from.Month);

                DateTime date_to = date_from.AddDays(daysInMonth - 1);

                _filters.date_from = date_from;
                _filters.date_to = date_to;

                DataTable dt = DataAccessLayer.Reports.ReferralReport.GetMonthlyReferralReport(_filters);

                List<string> by_sources = new List<string>();

                DataTable mytable = new DataTable();

                mytable.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    TimeSpan difference = date_to - date_from;

                    int dayDiff = Convert.ToInt32(difference.TotalDays);

                    // Add Columns to List Based on Referral Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        by_sources.Add(dr["pat_source_name"].ToString());
                    }

                    // Add Columns to Datatable From List
                    foreach (string str in by_sources)
                    {
                        mytable.Columns.Add(str, typeof(string));
                    }

                    for (int i = 0; i <= dayDiff; i++)
                    {
                        DateTime _date = date_from.AddDays(i);

                        DataRow dr = mytable.NewRow();

                        dr["Date"] = _date;

                        foreach (DataRow r in dt.Rows)
                        {
                            int value = Convert.ToInt32(DataAccessLayer.Reports.ReferralReport.TotalMonthlyReferralPatientCount(r["pat_source_name"].ToString(), _date.ToString("yyyy-MM-dd")));

                            if (value > 0)
                            {
                                dr[r["pat_source_name"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"dailySourceHistory('" + _date.ToString("yyyy-MM-dd") + "', '" + r["pat_source_name"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["pat_source_name"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
                            }
                        }

                        mytable.Rows.Add(dr);
                    }
                }

                data.sources = by_sources;
                data.report = mytable;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Monthly Referral History
        public static List<MonthlyReferralReportHistory> GetMonthlyReferralHistory(string pat_date, string pat_source_name)
        {
            try
            {
                DataTable dt = DataAccessLayer.Reports.ReferralReport.GetMonthlyReferralHistory(pat_date, pat_source_name);

                List<BusinessEntities.Reports.MonthlyReferralReportHistory> mreports = new List<BusinessEntities.Reports.MonthlyReferralReportHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        MonthlyReferralReportHistory report = new MonthlyReferralReportHistory();

                        report.patId = Convert.ToInt32(dr["patId"]);
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"]);
                        report.pat_madeby_name = dr["pat_madeby_name"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();

                        mreports.Add(report);
                    }
                }
                return mreports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}