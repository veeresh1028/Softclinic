using BusinessEntities.Appointment.DHA_Reports;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment.DHA_Reports
{
    public class InternationalPatientsData
    {
        public static List<BusinessEntities.Appointment.DHA_Reports.InternationalPatientsData> SearchInternationalPatientsDataReport(InternationalPatientsDataReportSearch search)
        {
            try
            {
                List<BusinessEntities.Appointment.DHA_Reports.InternationalPatientsData> reports = new List<BusinessEntities.Appointment.DHA_Reports.InternationalPatientsData>();

                DataSet ds = DataAccessLayer.Appointment.DHA_Reports.InternationalPatientsData.SearchInternationalPatientsDataReport(search);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            BusinessEntities.Appointment.DHA_Reports.InternationalPatientsData report = new BusinessEntities.Appointment.DHA_Reports.InternationalPatientsData();

                            report.pat_code = dr["pat_code"].ToString();
                            report.app_inout = dr["app_inout"].ToString();
                            report.pat_prof_id = dr["pat_prof_id"].ToString();
                            report.country_code = dr["country_code"].ToString();
                            report.pat_emirateid = dr["pat_emirateid"].ToString();
                            report.pat_mob = dr["pat_mob"].ToString();
                            report.pat_email = dr["pat_email"].ToString();
                            report.pat_dob = DateTime.Parse(dr["pat_dob"].ToString());
                            report.pat_gender = dr["pat_gender"].ToString();
                            report.country = dr["country"].ToString();
                            report.nationality = dr["nationality"].ToString();
                            report.nat_cpq = dr["nat_cpq"].ToString();
                            report.pat_city = dr["pat_city"].ToString();
                            report.app_fdate = DateTime.Parse(dr["app_fdate"].ToString());
                            report.emp_address = dr["Speciality"].ToString();
                            report.inv_total = DataValidation.isDecimalValid(dr["inv_total"].ToString());
                            int count = 0;

                            foreach (DataRow dr2 in ds.Tables[1].Rows)
                            {
                                if (dr["inv_appId"].ToString() == dr2["pad_appId"].ToString())
                                {
                                    count++;

                                    switch (count)
                                    {
                                        case 1:
                                            report.diag_code1 = dr2["diag_code"].ToString();
                                            break;
                                        case 2:
                                            report.diag_code2 = dr2["diag_code"].ToString();
                                            break;
                                        case 3:
                                            report.diag_code3 = dr2["diag_code"].ToString();
                                            break;
                                        case 4:
                                            report.diag_code4 = dr2["diag_code"].ToString();
                                            break;
                                        case 5:
                                            report.diag_code5 = dr2["diag_code"].ToString();
                                            break;
                                        case 6:
                                            report.diag_code6 = dr2["diag_code"].ToString();
                                            break;
                                        case 7:
                                            report.diag_code7 = dr2["diag_code"].ToString();
                                            break;
                                        case 8:
                                            report.diag_code8 = dr2["diag_code"].ToString();
                                            break;
                                    }
                                }
                            }

                            int count2 = 0;

                            foreach (DataRow dr3 in ds.Tables[2].Rows)
                            {
                                if (dr["inv_appId"].ToString() == dr3["pt_appId"].ToString())
                                {
                                    count2++;

                                    switch (count2)
                                    {
                                        case 1:
                                            report.pt_tr_code1 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 2:
                                            report.pt_tr_code2 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 3:
                                            report.pt_tr_code3 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 4:
                                            report.pt_tr_code4 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 5:
                                            report.pt_tr_code5 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 6:
                                            report.pt_tr_code6 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 7:
                                            report.pt_tr_code7 = dr3["pt_tr_code"].ToString();
                                            break;
                                        case 8:
                                            report.pt_tr_code8 = dr3["pt_tr_code"].ToString();
                                            break;
                                    }
                                }
                            }

                            reports.Add(report);
                        }
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