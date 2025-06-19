using BusinessEntities.Appointment;
using BusinessEntities.PriorRequests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.PriorRequests
{
    public class PriorRequests
    {

        #region Appointment History  Advanced Filters & Search
        public static List<PriorAppointmentList> PriorSearchAppointments(PriorAppointmentSearch priorData, out PriorAppointmentCount priorApp_count, out PriorAppointmentStatusColor priorAps_color)
        {
            try
            {
                priorApp_count = new PriorAppointmentCount();
                priorAps_color = new PriorAppointmentStatusColor();
                List<PriorAppointmentList> priorAppointmentList = new List<PriorAppointmentList>();
                DataTable dt = new DataTable();
                if (priorData.search_type == 0)
                {
                    priorData.date_from = DateTime.Now.Date;
                    priorData.date_to = DateTime.Now.Date.AddDays(1);
                    dt = DataAccessLayer.PriorRequests.PriorRequests.SearchPriorAppointments(priorData); 
                }
                else
                {
                    dt = DataAccessLayer.PriorRequests.PriorRequests.SearchPriorAppointments(priorData);
                }

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        PriorAppointmentList priorApp = new PriorAppointmentList();
                        priorApp.appId = Convert.ToInt32(dr["appId"]);
                        priorApp.app_pat_code = dr["app_pat_code"].ToString();
                        priorApp.app_fdate = Convert.ToDateTime(dr["app_fdate"]);
                        priorApp.app_status = dr["app_status"].ToString();
                        priorApp.app_type = dr["app_type"].ToString();
                        priorApp.app_doc_ftime = dr["app_doc_ftime"].ToString();
                        priorApp.app_doc_ttime = dr["app_doc_ttime"].ToString();
                        priorApp.app_resnforvisit = dr["app_resnforvisit"].ToString();
                        priorApp.app_branch = Convert.ToInt32(dr["app_branch"]);
                        priorApp.app_inout = dr["app_inout"].ToString();
                        priorApp.app_doctor = Convert.ToInt32(dr["app_doctor"]);
                        priorApp.app_emergency = dr["app_emergency"].ToString();
                        priorApp.app_ftime = dr["app_ftime"].ToString();
                        priorApp.app_ttime = dr["app_ttime"].ToString();
                        priorApp.app_ins = Convert.ToInt32(dr["app_ins"]);
                        priorApp.app_eligibility = dr["app_eligibility"].ToString();
                        priorApp.app_po = Convert.ToInt32(dr["app_po"]);
                        priorApp.app_service = Convert.ToInt32(dr["app_service"]);
                        priorApp.app_patient = Convert.ToInt32(dr["app_patient"]);
                        priorApp.app_comments = dr["app_comments"].ToString();
                        priorApp.patId = Convert.ToInt32(dr["patId"].ToString());
                        priorApp.pat_gender = dr["pat_gender"].ToString();
                        priorApp.pat_dob = Convert.ToDateTime(dr["pat_dob"].ToString());
                        priorApp.pat_name = dr["pat_name"].ToString();
                        priorApp.pat_emirateid = dr["pat_emirateid"].ToString();
                        priorApp.pat_mob = dr["pat_mob"].ToString();
                        priorApp.pat_class = dr["pat_class"].ToString();
                        priorApp.pat_referal = Convert.ToInt32(dr["pat_referal"].ToString());
                        priorApp.pat_email = dr["pat_email"].ToString();
                        priorApp.id_card_edate = Convert.ToDateTime(dr["id_card_edate"].ToString());
                        priorApp.empId = Convert.ToInt32(dr["empId"].ToString());
                        priorApp.emp_name = dr["emp_name"].ToString();
                        priorApp.emp_dept_name = dr["emp_dept_name"].ToString();
                        priorApp.emp_license = dr["emp_license"].ToString();
                        priorApp.emp_color = dr["emp_color"].ToString();
                        priorApp.aps_color = dr["aps_color"].ToString();
                        priorApp.ins_exp = dr["ins_exp"].ToString();
                        priorApp.pendings = Convert.ToInt32(dr["pendings"]);
                        priorApp.date_arrived = Convert.ToDateTime(dr["date_arrived"].ToString());
                        priorApp.date_invoiced = Convert.ToDateTime(dr["date_invoiced"].ToString());
                        priorApp.app_ae_date = Convert.ToDateTime(dr["app_ae_date"]);
                        priorApp.set_emr_lock = dr["set_emr_lock"].ToString();

                        if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                        {
                            priorApp.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                        }
                        else
                        {
                            if (priorApp.pat_gender.ToLower().StartsWith("f"))
                            {
                                priorApp.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                            }
                            else
                            {
                                priorApp.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                            }
                        }
                        priorAppointmentList.Add(priorApp);
                    }
                }

                // Appointment Status Count
                //priorApp_count.Booked = dt.Select("app_status = 'Booked'").Count();
                //priorApp_count.Confirmed = dt.Select("app_status = 'Confirmed'").Count();
                //priorApp_count.Arrived = dt.Select("app_status = 'Arrived'").Count();
                //priorApp_count.Invoiced = dt.Select("app_status = 'Invoiced'").Count();
                //priorApp_count.WithDoctor = dt.Select("app_status = 'WithDoctor'").Count();
                //priorApp_count.NurseStation = dt.Select("app_status = 'NurseStation'").Count();
                //priorApp_count.Cancelled = dt.Select("app_status = 'Cancelled'").Count();
                //priorApp_count.Total = priorApp_count.Booked + priorApp_count.Arrived + priorApp_count.Confirmed + priorApp_count.Cancelled + priorApp_count.Invoiced + priorApp_count.WithDoctor;

                //// Appointment Status Color
                //priorAps_color.Booked = (priorApp_count.Booked > 0) ? dt.Select("app_status = 'Booked'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                //priorAps_color.Confirmed = (priorApp_count.Confirmed > 0) ? dt.Select("app_status = 'Confirmed'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                //priorAps_color.Arrived = (priorApp_count.Arrived > 0) ? dt.Select("app_status = 'Arrived'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                //priorAps_color.Invoiced = (priorApp_count.Invoiced > 0) ? dt.Select("app_status = 'Invoiced'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                //priorAps_color.WithDoctor = (priorApp_count.WithDoctor > 0) ? dt.Select("app_status = 'WithDoctor'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                //priorAps_color.NurseStation = (priorApp_count.NurseStation > 0) ? dt.Select("app_status = 'NurseStation'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";
                //priorAps_color.Cancelled = (priorApp_count.Cancelled > 0) ? dt.Select("app_status = 'Cancelled'").CopyToDataTable().Rows[0]["aps_color"].ToString() : "#ABABAB";

                return priorAppointmentList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
