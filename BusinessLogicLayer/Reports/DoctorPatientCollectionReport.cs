using BusinessEntities.Reports;
using BusinessLogicLayer.Appointment;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class DoctorPatientCollectionReport
    {
        public static BusinessEntities.Reports.DoctorPatientCollectionReport SearchDoctorPatientCollectionReport(DoctorPatientCollectionReportSearch search)
        {
            try
            {
                BusinessEntities.Reports.DoctorPatientCollectionReport reports = new BusinessEntities.Reports.DoctorPatientCollectionReport();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataSet ds = DataAccessLayer.Reports.DoctorPatientCollectionReport.SearchDoctorPatientCollectionReport(search);

                List<DoctorsList> doctorList = new List<DoctorsList>();
                List<DoctorPatientCollection> collections = new List<DoctorPatientCollection>();
                List<DatesForReport> dates = new List<DatesForReport>();

                // Get Doctor Names
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DoctorsList doctor = new DoctorsList();
                        doctor.app_doctor = Convert.ToInt32(dr["app_doctor"]);
                        doctor.emp_name = dr["emp_name"].ToString();
                        doctorList.Add(doctor);
                    }
                }

                // Get Doctor & Patient Collection Report
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        DoctorPatientCollection collection = new DoctorPatientCollection();
                        collection.inv_date = Convert.ToDateTime(dr["inv_date"]);
                        collection.inv_doctor = Convert.ToInt32(dr["inv_doctor"]);
                        collection.inv_doctor_name = dr["inv_doctor_name"].ToString();
                        collection.inv_pat = Convert.ToInt32(dr["inv_pat"].ToString());
                        collection.inv_net = DataValidation.isDecimalValid(dr["inv_net"].ToString());
                        collection.inv_avg = DataValidation.isDecimalValid(dr["inv_avg"].ToString());

                        collections.Add(collection);
                    }
                }

                // Get All Dates
                double no_of_days = (search.date_to - search.date_from).TotalDays + 1;

                for (int i = 0; i < no_of_days; i++)
                {
                    DatesForReport date = new DatesForReport();
                    date.date = search.date_from.AddDays(i);
                    dates.Add(date);
                }

                reports.collectionReport = collections;
                reports.doctors = doctorList;
                reports.dates = dates;

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<DoctorwiseCollectionReport> SearchDoctorwiseCollectionReport(DoctorPatientCollectionReportSearch search)
        {
            try
            {
                List<DoctorwiseCollectionReport> reports = new List<DoctorwiseCollectionReport>();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Now;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataTable dt = DataAccessLayer.Reports.DoctorPatientCollectionReport.SearchDoctorwiseCollectionReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        DoctorwiseCollectionReport report = new DoctorwiseCollectionReport();
                        report.app_doctor = Convert.ToInt32(dr["app_doctor"]);
                        report.doctor_name = dr["emp_name"].ToString();
                        report.total_ipatients = Convert.ToInt32(dr["total_ipatients"]);
                        report.total_inet = DataValidation.isDecimalValid(dr["total_inet"].ToString());

                        if (report.total_ipatients > 0)
                        {
                            report.total_iavg = report.total_inet / report.total_ipatients;
                        }

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