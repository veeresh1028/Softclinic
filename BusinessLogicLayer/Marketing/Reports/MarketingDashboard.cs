using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Marketing.Reports
{
    public class MarketingDashboard
    {
        #region Marketing Dashboard Reports
        public static DashboardReport GetDashboardReports(BusinessEntities.Marketing.Reports.MarketingDashboard _filters)
        {
            try
            {
                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataSet ds = DataAccessLayer.Marketing.Reports.MarketingDashboard.GetDashboardReports(_filters);

                BusinessEntities.Marketing.Reports.DashboardReport dbReport = new BusinessEntities.Marketing.Reports.DashboardReport();

                DashboardCount dbcount = new DashboardCount();
                List<DashboardManagedBy> mbList = new List<DashboardManagedBy>();
                List<DashboardSourcewise> sbList = new List<DashboardSourcewise>();
                List<DashboardMonthwise> monthList = new List<DashboardMonthwise>();
                List<DashboardDaywise> dayList = new List<DashboardDaywise>();
                List<DashboardStatuswise> statusList = new List<DashboardStatuswise>();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[0].Rows[0];

                        dbcount.total_enquiries = Convert.ToInt32(dr["total_enquiries"]);
                        dbcount.total_followups = Convert.ToInt32(dr["total_followups"]);
                    }
                    else
                    {
                        dbcount.total_enquiries = 0;
                        dbcount.total_followups = 0;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            DashboardManagedBy managedBy = new DashboardManagedBy();
                            managedBy.app_madeby_name = dr["app_madeby_name"].ToString();
                            managedBy.total = Convert.ToInt32(dr["total"]);
                            mbList.Add(managedBy);
                        }
                    }
                    else
                    {
                        DashboardManagedBy managedBy = new DashboardManagedBy();
                        managedBy.app_madeby_name = "N/A";
                        managedBy.total = 0;
                        mbList.Add(managedBy);
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            DashboardSourcewise bySource = new DashboardSourcewise();
                            bySource.app_source_name = dr["app_source_name"].ToString();
                            bySource.total = Convert.ToInt32(dr["total"]);
                            sbList.Add(bySource);
                        }
                    }
                    else
                    {
                        DashboardSourcewise bySource = new DashboardSourcewise();
                        bySource.app_source_name = "N/A";
                        bySource.total = 0;
                        sbList.Add(bySource);
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[3].Rows)
                        {
                            DashboardMonthwise month = new DashboardMonthwise();
                            month.month_name = dr["month_name"].ToString();
                            month.total = Convert.ToInt32(dr["total"]);
                            monthList.Add(month);
                        }
                    }
                    else
                    {
                        DashboardMonthwise month = new DashboardMonthwise();
                        month.month_name = "N/A";
                        month.total = 0;
                        monthList.Add(month);
                    }

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[4].Rows)
                        {
                            DashboardDaywise day = new DashboardDaywise();
                            day.day_name = "Day " + dr["day_name"].ToString();
                            day.total = Convert.ToInt32(dr["total"]);
                            dayList.Add(day);
                        }
                    }
                    else
                    {
                        DashboardDaywise day = new DashboardDaywise();
                        day.day_name = "N/A";
                        day.total = 0;
                        dayList.Add(day);
                    }

                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[5].Rows)
                        {
                            DashboardStatuswise status = new DashboardStatuswise();
                            status.app_status =  dr["app_status"].ToString();
                            status.total = Convert.ToInt32(dr["total"]);
                            statusList.Add(status);
                        }
                    }
                    else
                    {
                        DashboardStatuswise status = new DashboardStatuswise();
                        status.app_status = "N/A";
                        status.total = 0;
                        statusList.Add(status);
                    }
                }

                dbReport.dbCount = dbcount;
                dbReport.mbList = mbList;
                dbReport.sourceList = sbList;
                dbReport.monthList = monthList;
                dbReport.dayList = dayList;
                dbReport.statusList = statusList;

                return dbReport;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
