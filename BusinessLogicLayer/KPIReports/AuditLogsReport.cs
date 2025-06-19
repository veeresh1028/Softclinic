using BusinessEntities.Appointment;
using BusinessEntities.KPIReports;
using BusinessEntities.Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class AuditLogsReport
    {
        public static BusinessEntities.KPIReports.AuditLogsReport SearchAuditLogsReport(AuditLogsReportSearch search)
        {
            try
            {
                BusinessEntities.KPIReports.AuditLogsReport reports = new BusinessEntities.KPIReports.AuditLogsReport();

                if (search.search_type == 0)
                {
                    search.date_from = DateTime.Today;
                    search.date_to = DateTime.Now.AddDays(1);
                }

                DataSet ds = DataAccessLayer.KPIReports.AuditLogsReport.SearchAuditLogsReport(search);

                List<BusinessEntities.KPIReports.AppointmentAuditLogsKPI> auditLogsKPI = new List<BusinessEntities.KPIReports.AppointmentAuditLogsKPI>();
                List<BusinessEntities.KPIReports.AllergiesAuditLogsKPI> allergiesLogsKPI = new List<BusinessEntities.KPIReports.AllergiesAuditLogsKPI>();
                List<BusinessEntities.KPIReports.VitalSignsAuditLogsKPI> vitalLogsKPI = new List<BusinessEntities.KPIReports.VitalSignsAuditLogsKPI>();

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BusinessEntities.KPIReports.AppointmentAuditLogsKPI report = new BusinessEntities.KPIReports.AppointmentAuditLogsKPI();
                            report.appa_appId = Convert.ToInt32(dr["appa_appId"].ToString());
                            report.appa_fdate = Convert.ToDateTime(dr["appa_fdate"].ToString());
                            report.appa_branch = dr["appa_branch"].ToString();
                            report.appa_ftime = dr["appa_ftime"].ToString();
                            report.appa_ttime = dr["appa_ttime"].ToString();
                            report.appa_patient = dr["appa_patient"].ToString();
                            report.appa_doctor = dr["appa_doctor"].ToString();
                            report.appa_type = dr["appa_type"].ToString();
                            report.appa_inout = dr["appa_inout"].ToString();
                            report.appa_operation = dr["appa_operation"].ToString();
                            report.appa_status = dr["appa_status"].ToString();
                            report.appa_madeby = dr["appa_madeby"].ToString();
                            report.appa_date_created = Convert.ToDateTime(dr["appa_date_created"].ToString());
                            report.appa_date_modified = Convert.ToDateTime(dr["appa_date_modified"].ToString());

                            auditLogsKPI.Add(report);
                        }
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            BusinessEntities.KPIReports.AllergiesAuditLogsKPI report = new BusinessEntities.KPIReports.AllergiesAuditLogsKPI();
                            report.allaId = Convert.ToInt32(dr["allaId"]);
                            report.alla_appId = Convert.ToInt32(dr["alla_appId"]);
                            report.allergiesa = dr["allergiesa"].ToString();
                            report.alla_for = dr["alla_for"].ToString();
                            report.alla_pexam = dr["alla_pexam"].ToString();
                            report.alla_type = dr["alla_type"].ToString();
                            report.alla_severity = dr["alla_severity"].ToString();
                            report.alla_status = dr["alla_status"].ToString();
                            report.alla_doctor_name = dr["alla_doctor_name"].ToString();
                            report.alla_madeby_name = dr["alla_madeby_name"].ToString();
                            report.alla_operation = dr["alla_operation"].ToString();
                            report.alla_date_created = Convert.ToDateTime(dr["alla_date_created"]);

                            allergiesLogsKPI.Add(report);
                        }
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[2].Rows)
                        {
                            vitalLogsKPI.Add(new BusinessEntities.KPIReports.VitalSignsAuditLogsKPI
                            {
                                signaId = Convert.ToInt32(dr["signaId"]),
                                signa_appId = Convert.ToInt32(dr["signa_appId"]),
                                signa_doctor_name = dr["signa_doctor_name"].ToString(),
                                signa_temp = dr["signa_temp"].ToString(),
                                signa_pulse = dr["signa_pulse"].ToString(),
                                signa_bp = dr["signa_bp"].ToString(),
                                signa_notes = dr["signa_notes"].ToString(),
                                signa_height = dr["signa_height"].ToString(),
                                signa_weight = dr["signa_weight"].ToString(),
                                signa_resp = dr["signa_resp"].ToString(),
                                signa_spo2 = dr["signa_spo2"].ToString(),
                                signa_waist = dr["signa_waist"].ToString(),
                                signa_hip = dr["signa_hip"].ToString(),
                                signa_uri = dr["signa_uri"].ToString(),
                                signa_head = dr["signa_head"].ToString(),
                                signa_bmi = dr["sign_bmi"].ToString(),
                                signa_status = dr["signa_status"].ToString(),
                                signa_madeby_name = dr["signa_madeby_name"].ToString(),
                                signa_bpd = dr["signa_bpd"].ToString(),
                                signa_operation = dr["signa_operation"].ToString(),
                                signa_date_created = Convert.ToDateTime(dr["signa_date_created"]),
                                app_fdate = Convert.ToDateTime(dr["app_fdate"])
                            });
                        }
                    }
                }

                reports.auditLogsKPI = auditLogsKPI;
                reports.allergiesLogsKPI = allergiesLogsKPI;
                reports.vitalLogsKPI = vitalLogsKPI;

                return reports;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CommonDDL> GetPatientsByAuditLogsReport(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.AuditLogsReport.GetPatientsByAuditLogsReport(_data);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }

        public static List<CommonDDL> GetMadeByDropdown(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.KPIReports.AuditLogsReport.GetMadeByDropdown(_data);

            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }

            return data;
        }
    }
}