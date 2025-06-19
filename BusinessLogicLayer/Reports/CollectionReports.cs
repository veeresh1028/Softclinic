using BusinessEntities.Dashboard;
using BusinessEntities.Marketing.Reports;
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
    public class CollectionReports
    {
        #region Dashboard Weekly Collection Reports (Page Load & Search)
        public static BusinessEntities.Reports.CollectionReports SearchCollectionReports(CollectionReportSearch search)
        {
            try
            {
                BusinessEntities.Reports.CollectionReports report = new BusinessEntities.Reports.CollectionReports();

                DataSet ds = DataAccessLayer.Reports.CollectionReports.SearchCollectionReports(search);

                List<CollectionWeekly> weeklyCollections = new List<CollectionWeekly>();
                List<CollectionDepartment> deptCollections = new List<CollectionDepartment>();
                List<CashInsReport> cashInsCollections = new List<CashInsReport>();
                List<CollectionReport> collectionReports = new List<CollectionReport>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BusinessEntities.Reports.CollectionWeekly weekly = new BusinessEntities.Reports.CollectionWeekly();
                        weekly.s_no = Convert.ToInt32(dr["Sno"]);
                        weekly.sales_date = Convert.ToDateTime(dr["Sales_Date"]);
                        weekly.sales = Convert.ToDecimal(dr["Sales"]);

                        weeklyCollections.Add(weekly);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        BusinessEntities.Reports.CollectionDepartment department = new BusinessEntities.Reports.CollectionDepartment();
                        department.department = dr["department"].ToString();
                        department.daily = Convert.ToDecimal(dr["daily"]);
                        department.weekly = Convert.ToDecimal(dr["weekly"]);
                        department.monthly = Convert.ToDecimal(dr["monthly"]);
                        department.daily_sales_perc = Convert.ToDecimal(dr["daily_sales_percentage"]);

                        deptCollections.Add(department);
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        BusinessEntities.Reports.CashInsReport cashInsReport = new BusinessEntities.Reports.CashInsReport();
                        cashInsReport.inv_type = dr["inv_type"].ToString();
                        cashInsReport.daily = Convert.ToDecimal(dr["daily"]);
                        cashInsReport.weekly = Convert.ToDecimal(dr["weekly"]);
                        cashInsReport.monthly = Convert.ToDecimal(dr["monthly"]);

                        cashInsCollections.Add(cashInsReport);
                    }
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        BusinessEntities.Reports.CollectionReport collection = new BusinessEntities.Reports.CollectionReport();
                        collection.description = dr["Description"].ToString();
                        collection.dailyNos = Convert.ToInt32(dr["Daily Nos"]);
                        collection.daily = Convert.ToDecimal(dr["DAmount"]);
                        collection.weeklyNos = Convert.ToInt32(dr["Weekly Nos"]);
                        collection.weekly = Convert.ToDecimal(dr["WAmount"]);
                        collection.monthlyNos = Convert.ToInt32(dr["Monthly Nos"]);
                        collection.monthly = Convert.ToDecimal(dr["MAmount"]);

                        collectionReports.Add(collection);
                    }
                }

                report.weeklyCollection = weeklyCollections;
                report.deptCollections = deptCollections;
                report.cashInsCollections = cashInsCollections;
                report.collectionReports = collectionReports;

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}