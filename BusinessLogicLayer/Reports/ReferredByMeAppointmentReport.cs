﻿using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Reports
{
    public class ReferredByMeAppointmentReport
    {
        public static List<BusinessEntities.Reports.ReferredByMeAppointmentReport> SearchReferredByMeReport(ReferredByMeReportSearch search)
        {
            try
            {
                List<BusinessEntities.Reports.ReferredByMeAppointmentReport> reports = new List<BusinessEntities.Reports.ReferredByMeAppointmentReport>();

                DataTable dt = DataAccessLayer.Reports.ReferredByMeAppointmentReport.SearchReferredByMeReport(search);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.Reports.ReferredByMeAppointmentReport report = new BusinessEntities.Reports.ReferredByMeAppointmentReport();
                        report.patId = Convert.ToInt32(dr["patId"].ToString());
                        report.app_ins = Convert.ToInt32(dr["app_ins"].ToString());
                        report.app_doctor = Convert.ToInt32(dr["app_doctor"].ToString());
                        report.iref_app_date_time = dr["iref_app_date_time"].ToString();
                        report.iref_app_doc_ftime = dr["iref_app_doc_ftime"].ToString();
                        report.iref_app_doc_ttime = dr["iref_app_doc_ttime"].ToString();
                        report.pat_code_mob = dr["pat_code_mob"].ToString();
                        report.app_madeby_name = dr["app_madeby_name"].ToString();
                        report.app_status = dr["app_status"].ToString();
                        report.iref_doctor_from_name = dr["iref_doctor_from_name"].ToString();
                        report.iref_doctor_to_name = dr["iref_doctor_to_name"].ToString();
                        report.ins_exp = dr["ins_exp"].ToString();
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
