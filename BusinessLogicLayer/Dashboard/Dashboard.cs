using BusinessEntities.Masters.Rights;
using BusinessEntities.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities.Dashboard;
using System.IO;
using SecurityLayer;
using BusinessEntities.Marketing.Reports;
using System.Collections.ObjectModel;

namespace BusinessLogicLayer.Dashboard
{
    public class Dashboard
    {
        #region Dashboard (Page Load & Search)
        public static BusinessEntities.Dashboard.Dashboard SearchDashboardReports(DashboardSearch search)
        {
            try
            {
                BusinessEntities.Dashboard.Dashboard dashboard = new BusinessEntities.Dashboard.Dashboard();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now.AddMonths(-1);
                    search.date_to = DateTime.Now;
                }

                DataSet ds = DataAccessLayer.Dashboard.Dashboard.SearchDashboardReports(search);

                DashboardCashInsSales sales = new DashboardCashInsSales();
                DashboardTotalCollections collections = new DashboardTotalCollections();
                List<DashboardAppointmentTypes> appointmentTypes = new List<DashboardAppointmentTypes>();
                List<DashboardPatientCollections> patientCollections = new List<DashboardPatientCollections>();
                List<DashboardInvRecMonth> invRecMonth = new List<DashboardInvRecMonth>();
                List<DashboardStatuswise> statusList = new List<DashboardStatuswise>();
                List<DashboardCollectionByDoctor> collectionByDoctors = new List<DashboardCollectionByDoctor>();
                List<DashboardRevenueByInsCompanies> revenueByInsCompanies = new List<DashboardRevenueByInsCompanies>();
                List<DashboardCollectionByMonth> collectionByMonths = new List<DashboardCollectionByMonth>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    sales.total_cash_net = DataValidation.isDecimalValid(dr["total_cash_net"].ToString());
                    sales.total_ins_net = DataValidation.isDecimalValid(dr["total_ins_net"].ToString());
                    sales.total_copay = DataValidation.isDecimalValid(dr["total_copay"].ToString());
                    sales.total_remittance_amt = DataValidation.isDecimalValid(dr["total_remittance_amt"].ToString());
                    sales.total_consultation = DataValidation.isDecimalValid(dr["total_consultation"].ToString());
                    sales.total_proc = DataValidation.isDecimalValid(dr["total_proc"].ToString());
                    sales.total_lab = DataValidation.isDecimalValid(dr["total_lab"].ToString());
                    sales.total_radiology = DataValidation.isDecimalValid(dr["total_radiology"].ToString());
                    sales.total_pharmacy = DataValidation.isDecimalValid(dr["total_pharmacy"].ToString());
                }
                else
                {
                    sales.total_cash_net = 0;
                    sales.total_ins_net = 0;
                    sales.total_copay = 0;
                    sales.total_remittance_amt = 0;
                    sales.total_consultation = 0;
                    sales.total_proc = 0;
                    sales.total_lab = 0;
                    sales.total_radiology = 0;
                    sales.total_pharmacy = 0;
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[1].Rows[0];
                    collections.total_cash = DataValidation.isDecimalValid(dr["total_cash"].ToString());
                    collections.total_cc = DataValidation.isDecimalValid(dr["total_cc"].ToString());
                    collections.total_cheques = DataValidation.isDecimalValid(dr["total_cheques"].ToString());
                    collections.total_bt = DataValidation.isDecimalValid(dr["total_bt"].ToString());
                    collections.total_advances = DataValidation.isDecimalValid(dr["total_advances"].ToString());
                    collections.total_allocations = DataValidation.isDecimalValid(dr["total_allocations"].ToString());
                    collections.total_bad_debits = DataValidation.isDecimalValid(dr["total_bad_debits"].ToString());
                }
                else
                {
                    collections.total_cash = 0;
                    collections.total_cc = 0;
                    collections.total_cheques = 0;
                    collections.total_bt = 0;
                    collections.total_advances = 0;
                    collections.total_allocations = 0;
                    collections.total_bad_debits = 0;
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        BusinessEntities.Dashboard.DashboardAppointmentTypes type = new BusinessEntities.Dashboard.DashboardAppointmentTypes();
                        type.labels = dr["app_type"].ToString();
                        type.total = Convert.ToInt32(dr["total"]);

                        appointmentTypes.Add(type);
                    }
                }
                else
                {
                    BusinessEntities.Dashboard.DashboardAppointmentTypes type = new BusinessEntities.Dashboard.DashboardAppointmentTypes();
                    type.labels = "N/A";
                    type.total = 0;
                    appointmentTypes.Add(type);
                }

                if (ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        BusinessEntities.Dashboard.DashboardPatientCollections mode = new BusinessEntities.Dashboard.DashboardPatientCollections();
                        mode.labels = dr["Property"].ToString();
                        mode.total = Convert.ToInt32(dr["Value"]);
                        patientCollections.Add(mode);
                    }
                }
                else
                {
                    BusinessEntities.Dashboard.DashboardPatientCollections mode = new BusinessEntities.Dashboard.DashboardPatientCollections();
                    mode.labels = "N/A";
                    mode.total = 0;
                    patientCollections.Add(mode);
                }

                Dictionary<string, string> labelMappings = new Dictionary<string, string>
                {
                    { "inv_total", "Invoices Total" },
                    { "sales_total", "Sales Total" }
                };

                if (ds.Tables[4].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[4].Rows[0];

                    foreach (KeyValuePair<string, string> mapping in labelMappings)
                    {
                        string columnName = mapping.Key;
                        string labelName = mapping.Value;

                        invRecMonth.Add(new DashboardInvRecMonth
                        {
                            labels = labelName,
                            total = DataValidation.isDecimalValid(dr[columnName].ToString())
                        });
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, string> mapping in labelMappings)
                    {
                        string labelName = mapping.Value;

                        invRecMonth.Add(new DashboardInvRecMonth
                        {
                            labels = labelName,
                            total = 0
                        });
                    }
                }

                if (ds.Tables[5].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[5].Rows)
                    {
                        DashboardStatuswise status = new DashboardStatuswise();
                        status.app_status = dr["app_status"].ToString();
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

                if (ds.Tables[6].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[6].Rows)
                    {
                        DashboardCollectionByDoctor collectionByDoctor = new DashboardCollectionByDoctor();
                        collectionByDoctor.labels = dr["emp_name"].ToString();
                        collectionByDoctor.total = Convert.ToInt32(dr["total_sales"]);
                        collectionByDoctors.Add(collectionByDoctor);
                    }
                }
                else
                {
                    DashboardCollectionByDoctor collectionByDoctor = new DashboardCollectionByDoctor();
                    collectionByDoctor.labels = "N/A";
                    collectionByDoctor.total = 0;
                    collectionByDoctors.Add(collectionByDoctor);
                }

                if (ds.Tables[7].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[7].Rows)
                    {
                        DashboardRevenueByInsCompanies revenueByCompany = new DashboardRevenueByInsCompanies();
                        revenueByCompany.labels = dr["ic_name"].ToString();
                        revenueByCompany.total = Convert.ToInt32(dr["total_sales"]);
                        revenueByInsCompanies.Add(revenueByCompany);
                    }
                }
                else
                {
                    DashboardRevenueByInsCompanies revenueByCompany = new DashboardRevenueByInsCompanies();
                    revenueByCompany.labels = "N/A";
                    revenueByCompany.total = 0;
                    revenueByInsCompanies.Add(revenueByCompany);
                }

                if (ds.Tables[8].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[8].Rows)
                    {
                        DashboardCollectionByMonth collection = new DashboardCollectionByMonth();
                        collection.labels = dr["month_name"].ToString();
                        collection.total = Convert.ToInt32(dr["total"]);
                        collectionByMonths.Add(collection);
                    }
                }
                else
                {
                    DashboardCollectionByMonth collection = new DashboardCollectionByMonth();
                    collection.labels = "N/A";
                    collection.total = 0;
                    collectionByMonths.Add(collection);
                }

                dashboard.dbSales = sales;
                dashboard.dbCollections = collections;
                dashboard.dbAppTypes = appointmentTypes;
                dashboard.patientCollections = patientCollections;
                dashboard.invRecMonth = invRecMonth;
                dashboard.appStatusList = statusList;
                dashboard.collectionByDoctors = collectionByDoctors;
                dashboard.RevenueByInsCompanies = revenueByInsCompanies;
                dashboard.collectionByMonths = collectionByMonths;

                return dashboard;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}