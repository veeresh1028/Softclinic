using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class PatientNonVisit
    {
        public static List<BusinessEntities.Reports.PatientNonVisitReport> SearchPatientNonVisitLast30Days(PatientLastDaysSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PatientNonVisitReport> reports = new List<BusinessEntities.Reports.PatientNonVisitReport>();

                DataTable dt = DataAccessLayer.Reports.PatientNonVisitReport.SearchPatientNonVisitLast30Days(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PatientNonVisitReport report = new BusinessEntities.Reports.PatientNonVisitReport();
                        report.patId = Convert.ToInt32(dr["patId"].ToString());
                        report.pat_branch = Convert.ToInt32(dr["pat_branch"].ToString());
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"].ToString());
                        report.pat_last_visited = Convert.ToDateTime(dr["pat_last_visited"].ToString());
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.no_of_days = Convert.ToInt32(dr["no_of_days"].ToString());
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

        public static List<BusinessEntities.Reports.PatientNonVisitReport> SearchPatientNonVisitLast90Days(PatientLastDaysSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PatientNonVisitReport> reports = new List<BusinessEntities.Reports.PatientNonVisitReport>();

                DataTable dt = DataAccessLayer.Reports.PatientNonVisitReport.SearchPatientNonVisitLast90Days(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PatientNonVisitReport report = new BusinessEntities.Reports.PatientNonVisitReport();
                        report.patId = Convert.ToInt32(dr["patId"].ToString());
                        report.pat_branch = Convert.ToInt32(dr["pat_branch"].ToString());
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"].ToString());
                        report.pat_last_visited = Convert.ToDateTime(dr["pat_last_visited"].ToString());
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.no_of_days = Convert.ToInt32(dr["no_of_days"].ToString());
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

        public static List<BusinessEntities.Reports.PatientNonVisitReport> SearchPatientNonVisitLast180Days(PatientLastDaysSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PatientNonVisitReport> reports = new List<BusinessEntities.Reports.PatientNonVisitReport>();

                DataTable dt = DataAccessLayer.Reports.PatientNonVisitReport.SearchPatientNonVisitLast180Days(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PatientNonVisitReport report = new BusinessEntities.Reports.PatientNonVisitReport();
                        report.patId = Convert.ToInt32(dr["patId"].ToString());
                        report.pat_branch = Convert.ToInt32(dr["pat_branch"].ToString());
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"].ToString());
                        report.pat_last_visited = Convert.ToDateTime(dr["pat_last_visited"].ToString());
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.no_of_days = Convert.ToInt32(dr["no_of_days"].ToString());
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

        public static List<BusinessEntities.Reports.PatientNonVisitReport> SearchPatientNonVisitLast360Days(PatientLastDaysSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PatientNonVisitReport> reports = new List<BusinessEntities.Reports.PatientNonVisitReport>();

                DataTable dt = DataAccessLayer.Reports.PatientNonVisitReport.SearchPatientNonVisitLast360Days(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PatientNonVisitReport report = new BusinessEntities.Reports.PatientNonVisitReport();
                        report.patId = Convert.ToInt32(dr["patId"].ToString());
                        report.pat_branch = Convert.ToInt32(dr["pat_branch"].ToString());
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"].ToString());
                        report.pat_last_visited = Convert.ToDateTime(dr["pat_last_visited"].ToString());
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.no_of_days = Convert.ToInt32(dr["no_of_days"].ToString());
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

        public static List<BusinessEntities.Reports.PatientNonVisitReport> SearchPatientNonVisitLast2Years(PatientLastDaysSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.PatientNonVisitReport> reports = new List<BusinessEntities.Reports.PatientNonVisitReport>();

                DataTable dt = DataAccessLayer.Reports.PatientNonVisitReport.SearchPatientNonVisitLast2Years(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.PatientNonVisitReport report = new BusinessEntities.Reports.PatientNonVisitReport();
                        report.patId = Convert.ToInt32(dr["patId"].ToString());
                        report.pat_branch = Convert.ToInt32(dr["pat_branch"].ToString());
                        report.pat_date_created = Convert.ToDateTime(dr["pat_date_created"].ToString());
                        report.pat_last_visited = Convert.ToDateTime(dr["pat_last_visited"].ToString());
                        report.pat_email = dr["pat_email"].ToString();
                        report.pat_code = dr["pat_code"].ToString();
                        report.nationality = dr["nationality"].ToString();
                        report.pat_gender = dr["pat_gender"].ToString();
                        report.pat_name = dr["pat_name"].ToString();
                        report.pat_emirateid = dr["pat_emirateid"].ToString();
                        report.pat_mob = dr["pat_mob"].ToString();
                        report.no_of_days = Convert.ToInt32(dr["no_of_days"].ToString());
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
