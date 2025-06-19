using BusinessEntities.Appointment;
using BusinessEntities.Marketing;
using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing.Reports
{
    public class DailyReport
    {
        #region Daily Enquiry Report (Managed By)
        public static DailyReportManagedBy DailyReportManagedby(BusinessEntities.Marketing.Reports.DailyReport _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.DailyReportManagedBy data = new BusinessEntities.Marketing.Reports.DailyReportManagedBy();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);                    
                }

                DataTable dt = DataAccessLayer.Marketing.Reports.DailyReport.DailyReportManagedby(_filters);

                List<string> managed_by = new List<string>();

                DataTable mytable = new DataTable();

                mytable.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    DateTime start = _filters.date_from;
                    DateTime end = _filters.date_to;
                    TimeSpan difference = end - start;

                    int dayDiff = Convert.ToInt32(difference.TotalDays);

                    // Add Columns to List Based on Made By Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        managed_by.Add(dr["app_madeby_name"].ToString());
                    }
                    // Add Columns to Datatable From List
                    foreach (string str in managed_by)
                    {
                        mytable.Columns.Add(str, typeof(string));
                    }

                    for (int i = 0; i <= dayDiff; i++)
                    {
                        DateTime _date = _filters.date_from.AddDays(i);

                        DataRow dr = mytable.NewRow();

                        dr["Date"] = _date;

                        foreach (DataRow r in dt.Rows)
                        {
                            int value = Convert.ToInt32(DataAccessLayer.Marketing.Reports.DailyReport.TotalMadebyCount(r["app_madeby_name"].ToString(), _date.ToString("yyyy-MM-dd")));

                            if (value > 0)
                            {
                                dr[r["app_madeby_name"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"dailyHistory('" + _date.ToString("yyyy-MM-dd") + "', '" + r["app_madeby_name"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["app_madeby_name"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
                            }
                        }
                        mytable.Rows.Add(dr);
                    }
                }

                data.managed_by = managed_by;
                data.report = mytable;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Daily Enquiries History (Managed By)
        public static List<DailyHistory> GetDailyHistory(string app_fdate, string app_madeby_name)
        {
            try
            {
                DataTable dt = DataAccessLayer.Marketing.Reports.DailyReport.GetDailyHistory(app_fdate, app_madeby_name);

                List<BusinessEntities.Marketing.Reports.DailyHistory> mreports = new List<BusinessEntities.Marketing.Reports.DailyHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DailyHistory report = new DailyHistory();

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

        #region Daily Enquiry Report (By Source)
        public static DailyReportBySource DailyReportBySource(BusinessEntities.Marketing.Reports.DailyReportSource _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.DailyReportBySource data = new BusinessEntities.Marketing.Reports.DailyReportBySource();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Marketing.Reports.DailyReport.DailyReportBySource(_filters);

                List<string> by_sources = new List<string>();

                DataTable mytable = new DataTable();

                mytable.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    DateTime start = _filters.date_from;
                    DateTime end = _filters.date_to;
                    TimeSpan difference = end - start;

                    int dayDiff = Convert.ToInt32(difference.TotalDays);

                    // Add Columns to List Based on Source Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        by_sources.Add(dr["app_source_name"].ToString());
                    }
                    // Add Columns to Datatable From List
                    foreach (string str in by_sources)
                    {
                        mytable.Columns.Add(str, typeof(string));
                    }

                    for (int i = 0; i <= dayDiff; i++)
                    {
                        DateTime _date = _filters.date_from.AddDays(i);

                        DataRow dr = mytable.NewRow();

                        dr["Date"] = _date;

                        foreach (DataRow r in dt.Rows)
                        {
                            int value = Convert.ToInt32(DataAccessLayer.Marketing.Reports.DailyReport.TotalMadebyCountBySource(r["app_source_name"].ToString(), _date.ToString("yyyy-MM-dd")));

                            if (value > 0)
                            {
                                dr[r["app_source_name"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"dailySourceHistory('" + _date.ToString("yyyy-MM-dd") + "', '" + r["app_source_name"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["app_source_name"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
                            }
                        }
                        mytable.Rows.Add(dr);
                    }
                }

                data.by_sources = by_sources;
                data.report = mytable;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Daily Enquiries History (By Source)
        public static List<DailySourceHistory> GetDailySourceHistory(string app_fdate, string app_source_name)
        {
            try
            {
                DataTable dt = DataAccessLayer.Marketing.Reports.DailyReport.GetDailySourceHistory(app_fdate, app_source_name);

                List<BusinessEntities.Marketing.Reports.DailySourceHistory> mreports = new List<BusinessEntities.Marketing.Reports.DailySourceHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DailySourceHistory report = new DailySourceHistory();

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
