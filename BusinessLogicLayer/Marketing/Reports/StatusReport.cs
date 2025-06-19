using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing.Reports
{
    public class StatusReport
    {
        #region Enquiry Details Report (By Status)
        public static StatusReportDetails DailyReportByStatus(BusinessEntities.Marketing.Reports.StatusReport _filters)
        {
            try
            {
                BusinessEntities.Marketing.Reports.StatusReportDetails data = new BusinessEntities.Marketing.Reports.StatusReportDetails();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Marketing.Reports.StatusReport.EnquiryReportByStatus(_filters);

                List<string> statuses = new List<string>();

                DataTable status_dt = new DataTable();

                status_dt.Columns.Add("Date", typeof(string));

                if (dt.Rows.Count > 0)
                {
                    DateTime start = _filters.date_from;
                    DateTime end = _filters.date_to;
                    TimeSpan difference = end - start;

                    int dayDiff = Convert.ToInt32(difference.TotalDays);

                    // Add Columns to List Based on Made By Name
                    foreach (DataRow dr in dt.Rows)
                    {
                        statuses.Add(dr["as_status"].ToString());
                    }
                    // Add Columns to Datatable From List
                    foreach (string str in statuses)
                    {
                        status_dt.Columns.Add(str, typeof(string));
                    }

                    for (int i = 0; i <= dayDiff; i++)
                    {
                        DateTime _date = _filters.date_from.AddDays(i);

                        DataRow dr = status_dt.NewRow();

                        dr["Date"] = _date;

                        foreach (DataRow r in dt.Rows)
                        {
                            int value = Convert.ToInt32(DataAccessLayer.Marketing.Reports.StatusReport.TotalMadebyCount(r["as_status"].ToString(), _date.ToString("yyyy-MM-dd")));

                            if (value > 0)
                            {
                                dr[r["as_status"].ToString()] = "<a class='text-info font-weight-semibold' style='cursor:pointer' onclick=\"enquiryStatusHistory('" + _date.ToString("yyyy-MM-dd") + "', '" + r["as_status"].ToString() + "')\">" + value.ToString() + "</a>";
                            }
                            else
                            {
                                dr[r["as_status"].ToString()] = "<span class='text-danger font-weight-semibold'>0</span>";
                            }
                        }
                        status_dt.Rows.Add(dr);
                    }
                }

                data.statuses = statuses;
                data.report = status_dt;

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Enquiry Details Report History (By Status)
        public static List<StatusHistory> GetEnquiryStatusHistory(string app_fdate, string as_status)
        {
            try
            {
                DataTable dt = DataAccessLayer.Marketing.Reports.StatusReport.GetEnquiryStatusHistory(app_fdate, as_status);

                List<BusinessEntities.Marketing.Reports.StatusHistory> mreports = new List<BusinessEntities.Marketing.Reports.StatusHistory>();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        StatusHistory report = new StatusHistory();

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
