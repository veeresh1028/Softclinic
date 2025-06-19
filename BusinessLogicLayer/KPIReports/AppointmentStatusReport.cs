using BusinessEntities.Appointment;
using BusinessEntities.Marketing.Reports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.KPIReports
{
    public class AppointmentStatusReport
    {
        public static List<BusinessEntities.KPIReports.AppointmentStatusReport> SearchAppointmentStatusReport(BusinessEntities.KPIReports.AppointmentStatusSearch _filters)
        {
            try
            {
                List<BusinessEntities.KPIReports.AppointmentStatusReport> report = new List<BusinessEntities.KPIReports.AppointmentStatusReport>();

                if (_filters.search_type == 0)
                {
                    _filters.date_from = DateTime.Now.Date;
                    _filters.date_to = DateTime.Now.Date.AddDays(1);
                }

                DataTable dt = DataAccessLayer.KPIReports.AppointmentStatusReport.SearchAppointmentStatusReport(_filters);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BusinessEntities.KPIReports.AppointmentStatusReport status = new BusinessEntities.KPIReports.AppointmentStatusReport();
                        status.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        status.Booked = Convert.ToInt32(dr["Booked"]);
                        status.Enquiry = Convert.ToInt32(dr["Enquiry"]);
                        status.Confirmed = Convert.ToInt32(dr["Confirmed"]);
                        status.Cancelled = Convert.ToInt32(dr["Cancelled"]);
                        status.Arrived = Convert.ToInt32(dr["Arrived"]);
                        status.Invoiced = Convert.ToInt32(dr["Invoiced"]);
                        status.CallBack = Convert.ToInt32(dr["CallBack"]);
                        status.NoAnswer = Convert.ToInt32(dr["NoAnswer"]);
                        status.NoShow = Convert.ToInt32(dr["NoShow"]);
                        status.WithDoctor = Convert.ToInt32(dr["WithDoctor"]);
                        status.Deleted = Convert.ToInt32(dr["Deleted"]);
                        status.NurseStation = Convert.ToInt32(dr["Nursestation"]);
                        status.NurseCompleted = Convert.ToInt32(dr["nursecompleted"]);
                        status.ConsultationCompleted = Convert.ToInt32(dr["consultationCompleted"]);
                        status.InProcess = Convert.ToInt32(dr["InProcess"]);
                        status.Getting = Convert.ToInt32(dr["Getting"]);
                        status.PriorRequest = Convert.ToInt32(dr["PriorRequest"]);

                        report.Add(status);
                    }
                }

                return report;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AppointmentList> SearchAppointments(AppointmentSearch data, out AppointmentCount app_count, out AppointmentStatusColor aps_color)
        {
            try
            {
                app_count = new AppointmentCount();
                aps_color = new AppointmentStatusColor();
                List<AppointmentList> appointmentList = new List<AppointmentList>();

                if (data.search_type == 0)
                {
                    data.date_from = DateTime.Now.Date;
                    data.date_to = DateTime.Now.Date;
                }

                DataTable dt = DataAccessLayer.KPIReports.AppointmentStatusReport.SearchAppointments(data);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        AppointmentList app = new AppointmentList();
                        app.appId = Convert.ToInt32(dr["appId"]);
                        app.app_pat_code = dr["app_pat_code"].ToString();
                        app.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        app.app_status = dr["app_status"].ToString();
                        app.app_type = dr["app_type"].ToString();
                        app.app_doc_ftime = dr["app_doc_ftime"].ToString();
                        app.app_doc_ttime = dr["app_doc_ttime"].ToString();
                        app.app_resnforvisit = dr["app_resnforvisit"].ToString();
                        app.app_branch = Convert.ToInt32(dr["app_branch"]);
                        app.app_inout = dr["app_inout"].ToString();
                        app.app_doctor = Convert.ToInt32(dr["app_doctor"]);
                        app.app_emergency = dr["app_emergency"].ToString();
                        app.app_room = Convert.ToInt32(dr["app_room"]);
                        app.app_ftime = dr["app_ftime"].ToString();
                        app.app_ttime = dr["app_ttime"].ToString();
                        app.app_ins = Convert.ToInt32(dr["app_ins"]);
                        app.app_eligibility = dr["app_eligibility"].ToString();
                        app.app_po = Convert.ToInt32(dr["app_po"]);
                        app.app_service = dr["app_service"].ToString();
                        app.app_patient = Convert.ToInt32(dr["app_patient"]);
                        app.app_comments = dr["app_comments"].ToString();
                        app.app_category = dr["app_category"].ToString();
                        app.app_ic_name = dr["app_ic_name"].ToString();

                        app.patId = Convert.ToInt32(dr["patId"].ToString());
                        app.pat_gender = dr["pat_gender"].ToString();
                        app.pat_dob = Convert.ToDateTime(dr["pat_dob"].ToString());
                        app.pat_name = dr["pat_name"].ToString();
                        app.pat_emirateid = dr["pat_emirateid"].ToString();
                        app.pat_mob = dr["pat_mob"].ToString();
                        app.pat_class = dr["pat_class"].ToString();
                        app.pat_referal = Convert.ToInt32(dr["pat_referal"].ToString());
                        app.pat_email = dr["pat_email"].ToString();
                        app.id_card_edate = Convert.ToDateTime(dr["id_card_edate"].ToString());

                        app.empId = Convert.ToInt32(dr["empId"].ToString());
                        app.emp_name = dr["emp_name"].ToString();
                        app.emp_dept_name = dr["emp_dept_name"].ToString();
                        app.emp_license = dr["emp_license"].ToString();
                        app.emp_color = dr["emp_color"].ToString();
                        app.emp_status = dr["emp_status"].ToString();

                        app.aps_color = dr["aps_color"].ToString();
                        app.room = dr["room"].ToString();
                        app.nationality = dr["nationality"].ToString();
                        app.pt_auth_code = dr["pt_auth_code"].ToString();

                        app.ins_exp = dr["ins_exp"].ToString();
                        app.balance = decimal.Parse(dr["balance"].ToString());

                        if (app.balance < 0)
                        {
                            app.balance = 0;
                        }

                        app.pendings = Convert.ToInt32(dr["pendings"]);
                        app.date_arrived = Convert.ToDateTime(dr["date_arrived"].ToString());
                        app.date_invoiced = Convert.ToDateTime(dr["date_invoiced"].ToString());
                        //app.app_ae_date = DataValidation.isDateValid(dr["app_ae_date"].ToString());
                        app.set_emr_lock = dr["set_emr_lock"].ToString();

                        if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                        {
                            app.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                        }
                        else
                        {
                            if (app.pat_gender.ToLower().StartsWith("f"))
                            {
                                app.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                            }
                            else
                            {
                                app.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                            }
                        }

                        appointmentList.Add(app);
                    }
                }

                // Appointment Status Count
                app_count.Booked = dt.Select("app_status = 'Booked'").Count();
                app_count.Confirmed = dt.Select("app_status = 'Confirmed'").Count();
                app_count.Arrived = dt.Select("app_status = 'Arrived'").Count();
                app_count.Invoiced = dt.Select("app_status = 'Invoiced'").Count();
                app_count.WithDoctor = dt.Select("app_status = 'WithDoctor'").Count();
                app_count.NurseStation = dt.Select("app_status = 'NurseStation'").Count();
                app_count.Cancelled = dt.Select("app_status = 'Cancelled'").Count();
                app_count.Total = app_count.Booked + app_count.Arrived + app_count.Confirmed + app_count.Cancelled + app_count.Invoiced + app_count.WithDoctor;

                // Appointment Status Color
                aps_color.Booked = (app_count.Booked > 0) ? dt.Select("app_status = 'Booked'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                aps_color.Confirmed = (app_count.Confirmed > 0) ? dt.Select("app_status = 'Confirmed'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                aps_color.Arrived = (app_count.Arrived > 0) ? dt.Select("app_status = 'Arrived'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                aps_color.Invoiced = (app_count.Invoiced > 0) ? dt.Select("app_status = 'Invoiced'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                aps_color.WithDoctor = (app_count.WithDoctor > 0) ? dt.Select("app_status = 'WithDoctor'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                aps_color.NurseStation = (app_count.NurseStation > 0) ? dt.Select("app_status = 'NurseStation'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                aps_color.Cancelled = (app_count.Cancelled > 0) ? dt.Select("app_status = 'Cancelled'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";

                return appointmentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}