using BusinessEntities.Appointment;
using BusinessEntities.Patient;
using BusinessLogicLayer.Appointment.RecurrenceGenerator;
using SecurityLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Appointment
{
    public class Appointment
    {
        #region Appointment Scheduler
        public static List<BusinessEntities.Appointment.S_Appointments> GetAppointmentData(string start, string end, string val = null, int setId = 0)
        {
            List<S_Appointments> list = new List<S_Appointments>();
            try
            {
                DataTable dt = DataAccessLayer.Appointment.Appointment.GetAppointments(start, end, val, setId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        S_Appointments a = new S_Appointments();
                        a.id = dr["id"].ToString();
                        a.resourceId = dr["resourceId"].ToString();
                        a.start = DateTime.Parse(dr["start"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        a.end = DateTime.Parse(dr["end"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        a.title = dr["title"].ToString();

                        a.backgroundColor = dr["app_color"].ToString();
                        a.borderColor = dr["app_color"].ToString();
                        a.textColor = "#fff";

                        S_Appointment_Info i = new S_Appointment_Info();
                        i.pat_code = dr["pat_code"].ToString();
                        i.pat_mob = dr["pat_mob"].ToString();
                        i.pat_emirateid = dr["pat_emirateid"].ToString();
                        i.pat_name = dr["pat_name"].ToString();
                        i.pat_gender = dr["pat_gender"].ToString();
                        i.pat_age = dr["pat_age"].ToString();
                        i.pat_nationality = dr["pat_nationality"].ToString();
                        i.title_arb = dr["title_arb"].ToString();

                        DateTime _dob = DateTime.MinValue;
                        DateTime.TryParse(DateTime.Parse(dr["pat_dob"].ToString()).ToString(), out _dob);
                        i.pat_dob = _dob;

                        if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                        {
                            i.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                        }
                        else
                        {
                            if (i.pat_gender.ToLower().StartsWith("f"))
                            {
                                i.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                            }
                            else
                            {
                                i.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                            }
                        }

                        i.emp_name = dr["emp_name"].ToString();
                        i.emp_dept_name = dr["emp_dept_name"].ToString();
                        i.emp_color = dr["emp_color"].ToString();
                        i.app_doctor = dr["resourceId"].ToString();
                        i.app_fdate = DateTime.Parse(dr["start"].ToString()).ToString("yyyy-MM-dd");
                        i.app_inout = dr["app_inout"].ToString();
                        i.app_branch = dr["app_branch"].ToString();
                        i.app_room = dr["app_room"].ToString();
                        i.app_room_name = dr["app_room_name"].ToString();
                        i.app_ftime = dr["app_ftime"].ToString();
                        i.app_ttime = dr["app_ttime"].ToString();
                        i.app_ins = dr["app_ins"].ToString();
                        i.app_patient = dr["app_patient"].ToString();
                        i.app_type = dr["app_type"].ToString();
                        i.app_status = dr["app_status"].ToString();
                        i.app_emergency = dr["app_emergency"].ToString();
                        i.app_eligibility = dr["app_eligibility"].ToString();
                        i.app_resnforvisit = dr["app_resnforvisit"].ToString();
                        i.app_ic_name = dr["app_ic_name"].ToString();
                        //i.tr_code = dr["tr_code"].ToString();
                        //i.tr_name = dr["tr_name"].ToString();
                        //i.tr_price = dr["tr_price"].ToString();
                        i.app_service = dr["app_service"].ToString();
                        i.app_po = dr["app_po"].ToString();
                        i.app_comments = dr["app_comments"].ToString();
                        i.app_category = dr["app_category"].ToString();

                        a.extendedProps = i;
                        list.Add(a);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static List<BusinessEntities.Appointment.S_Appointments> GetAppointmentDataForRoomSchedule(string start, string end, string val = null, int setId = 0)
        {
            List<S_Appointments> list = new List<S_Appointments>();
            try
            {
                DataTable dt = DataAccessLayer.Appointment.Appointment.GetAppointmentsRoomSchedule(start, end, val, setId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        S_Appointments a = new S_Appointments();
                        a.id = dr["id"].ToString();
                        a.resourceId = dr["app_room"].ToString();
                        a.start = DateTime.Parse(dr["start"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        a.end = DateTime.Parse(dr["end"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                        a.title = dr["title"].ToString();
                        a.backgroundColor = dr["app_color"].ToString();
                        a.borderColor = dr["app_color"].ToString();
                        a.textColor = "#fff";

                        S_Appointment_Info i = new S_Appointment_Info();
                        i.pat_code = dr["pat_code"].ToString();
                        i.pat_mob = dr["pat_mob"].ToString();
                        i.pat_emirateid = dr["pat_emirateid"].ToString();
                        i.pat_name = dr["pat_name"].ToString();
                        i.pat_gender = dr["pat_gender"].ToString();
                        i.pat_age = dr["pat_age"].ToString();
                        i.pat_nationality = dr["pat_nationality"].ToString();

                        DateTime _dob = DateTime.MinValue;
                        DateTime.TryParse(DateTime.Parse(dr["pat_dob"].ToString()).ToString(), out _dob);
                        i.pat_dob = _dob;

                        if (!string.IsNullOrEmpty(dr["pat_photo"].ToString()))
                        {
                            i.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/patient_images/" + dr["pat_photo"].ToString();
                        }
                        else
                        {
                            if (i.pat_gender.ToLower().StartsWith("f"))
                            {
                                i.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-female.jpg";
                            }
                            else
                            {
                                i.pat_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                            }
                        }

                        i.emp_name = dr["emp_name"].ToString();
                        i.emp_dept_name = dr["emp_dept_name"].ToString();
                        i.emp_color = dr["emp_color"].ToString();
                        i.app_doctor = dr["resourceId"].ToString();
                        i.app_fdate = DateTime.Parse(dr["start"].ToString()).ToString("yyyy-MM-dd");
                        i.app_inout = dr["app_inout"].ToString();
                        i.app_branch = dr["app_branch"].ToString();
                        i.app_room = dr["app_room"].ToString();
                        i.app_ftime = dr["app_ftime"].ToString();
                        i.app_ttime = dr["app_ttime"].ToString();
                        i.app_ins = dr["app_ins"].ToString();
                        i.app_type = dr["app_type"].ToString();
                        i.app_status = dr["app_status"].ToString();
                        i.app_emergency = dr["app_emergency"].ToString();
                        i.app_eligibility = dr["app_eligibility"].ToString();
                        i.app_resnforvisit = dr["app_resnforvisit"].ToString();
                        i.app_ic_name = dr["app_ic_name"].ToString();
                        //i.tr_code = dr["tr_code"].ToString();
                        //i.tr_name = dr["tr_name"].ToString();
                        //i.tr_price = dr["tr_price"].ToString();
                        i.app_service = dr["app_service"].ToString();
                        i.app_po = dr["app_po"].ToString();
                        i.app_comments = dr["app_comments"].ToString();
                        i.room_color = dr["room_color"].ToString();

                        a.extendedProps = i;
                        list.Add(a);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
        }

        public static DataTable GetTimeSlots(int app_branch, string app_fdate, int app_doctor)
        {
            return DataAccessLayer.Appointment.Appointment.GetTimeSlots(app_branch, app_fdate, app_doctor);
        }

        public static List<CommonDDL> GetTimeSlotList(int app_branch, string app_fdate, int app_doctor)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetTimeSlots(app_branch, app_fdate, app_doctor);
            List<CommonDDL> timeslotlist = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    timeslotlist.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }
            return timeslotlist;
        }

        public static int GetTimeSlotId(int app_branch, string app_time)
        {
            return DataAccessLayer.Appointment.Appointment.GetTimeSlotId(app_branch, app_time);
        }

        public static List<CommonDDL> SearchPatients(int type, string query)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.SearchPatients(type, query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static DataTable GetAppointmentStatus()
        {
            return DataAccessLayer.Appointment.Appointment.GetAppointmentStatus();
        }

        public static List<CommonDDL> GetAppointmentStatusList()
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetAppointmentStatus();
            List<CommonDDL> statuslist = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    statuslist.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["apsId"]),
                        text = dr["aps_status"].ToString()
                    });
                }
            }
            return statuslist;
        }

        public static List<PackageOrder> GetPackageOrder(int poId = 0, int po_patient = 0, int po_piId = 0)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetPackageOrder(poId, po_patient, po_piId);

            List<PackageOrder> data = new List<PackageOrder>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageOrder _data = new PackageOrder();
                    _data.poId = int.Parse(dr["poId"].ToString());
                    _data.po_package = dr["po_package"].ToString();
                    _data.po_refno = dr["po_refno"].ToString();
                    _data.po_details = dr["po_details"].ToString();
                    _data.po_package_name = dr["po_package_name"].ToString();
                    _data.po_notes = dr["po_notes"].ToString();
                    _data.po_status = dr["po_status"].ToString();
                    _data.po_date = DateTime.Parse(dr["po_date"].ToString()).ToString("dd-MM-yyyy");
                    _data.po_exp_date = DateTime.Parse(dr["po_exp_date"].ToString()).ToString("dd-MM-yyyy");
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<PackageOrderService> GetPackageOrderServices(int poId = 0, int po_patient = 0, int po_piId = 0)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetPackageService(poId, po_patient, po_piId);

            List<PackageOrderService> data = new List<PackageOrderService>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PackageOrderService _data = new PackageOrderService();
                    _data.psId = int.Parse(dr["psId"].ToString());
                    _data.ps_info = dr["ps_info"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static string GetFollowupStatus(int piId, int app_doctor, DateTime app_fdate)
        {
            return DataAccessLayer.Appointment.Appointment.GetFollowupStatus(piId, app_doctor, app_fdate);
        }

        public static int CreateAppointment(BusinessEntities.Appointment.Appointment app)
        {
            if (app.app_status == "Enquiry")
            {
                app.app_status2 = "Marketing";
            }
            else
            {
                app.app_status2 = "Appointment";
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("po_services", typeof(string));
            dt.Columns.Add("po_package", typeof(string));
            dt.Columns.Add("po_qty", typeof(int));

            if (!string.IsNullOrEmpty(app.app_service))
            {
                string[] serviceIds = app.app_service.Split(',');

                foreach (string po_service in serviceIds)
                {
                    int ps_qty = 0;
                    DataTable dt1 = DataAccessLayer.Appointment.Appointment.GetPackage_Services_Qty(int.Parse(po_service.Trim()), int.Parse(app.app_package_order.ToString()));
                    ps_qty = int.Parse(dt1.Rows[0]["ps_qty"].ToString());

                    DataRow dr = dt.NewRow();
                    dr["po_services"] = po_service.Trim();
                    dr["po_package"] = app.app_package_order;
                    dr["po_qty"] = ps_qty;
                    dt.Rows.Add(dr);
                }
            }

            return DataAccessLayer.Appointment.Appointment.CreateAppointment(app, dt);
        }

        public static int UpdateAppointments(BusinessEntities.Appointment.Appointment app)
        {
            if (app.app_status == "Enquiry")
            {
                app.app_status2 = "Marketing";
            }
            else
            {
                app.app_status2 = "Appointment";
            }

            return DataAccessLayer.Appointment.Appointment.UpdateAppointments(app);
        }
        public static bool BlockAppointment(BusinessEntities.Appointment.Appointment app)
        {
            return DataAccessLayer.Appointment.Appointment.BlockAppointment(app);
        }
        public static int RebookAppointments(BusinessEntities.Appointment.ReBookAppointment app)
        {
            return DataAccessLayer.Appointment.Appointment.RebookAppointments(app);
        }

        public static DataTable GetAllDepartments(int deptId = 0)
        {
            return DataAccessLayer.Appointment.Appointment.GetAllDepartments(deptId);
        }

        public static int CopyCloneAppointments(BusinessEntities.Appointment.ReBookAppointment app)
        {
            return DataAccessLayer.Appointment.Appointment.CopyCloneAppointments(app);
        }

        public static int DeleteAppointments(int appId, int app_madeby)
        {
            return DataAccessLayer.Appointment.Appointment.DeleteAppointments(appId, app_madeby);
        }

        public static DataTable GetEMIDExpiry(int piId)
        {
            return DataAccessLayer.Appointment.Appointment.GetEMIDExpiry(piId);
        }
        #endregion

        #region Appointments Advanced Filters & Search
        public static List<CommonDDL> GetDoctorsByDepartments(string deptIds, string branchIds)
        {
            List<CommonDDL> doctorslist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Appointment.Appointment.GetDoctorsByDepartments(deptIds, branchIds);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    doctorslist.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }
            return doctorslist;
        }

        public static List<CommonDDL> GetBranchRooms(string branchIds)
        {
            List<CommonDDL> roomlist = new List<CommonDDL>();
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetBranchRooms(branchIds);

            foreach (DataRow dr in dt.Rows)
            {
                roomlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["id"]),
                    text = dr["text"].ToString()
                });
            }
            return roomlist;
        }

        public static List<CommonDDL> GetNationalities()
        {
            List<CommonDDL> referralslist = new List<CommonDDL>();
            DataTable dt = DataAccessLayer.Nationality.GetNationalities();

            foreach (DataRow dr in dt.Rows)
            {
                referralslist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["natId"]),
                    text = dr["nationality"].ToString()
                });
            }
            return referralslist;
        }

        public static List<CommonDDL> GetReferrals()
        {
            List<CommonDDL> referralslist = new List<CommonDDL>();
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetReferrals();

            foreach (DataRow dr in dt.Rows)
            {
                referralslist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["refId"]),
                    text = dr["ref_name"].ToString()
                });
            }
            return referralslist;
        }

        public static List<CommonDDL> GetStatus()
        {
            List<CommonDDL> statuslist = new List<CommonDDL>();
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetStatus();

            foreach (DataRow dr in dt.Rows)
            {
                statuslist.Add(new CommonDDL
                {
                    text = dr["app_status"].ToString()
                });
            }
            return statuslist;
        }

        public static List<CommonDDL> GetPatients(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetPatients(_data);
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

        public static List<CommonDDL> GetPatientsId(GetPatients _data)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetPatientsId(_data);
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

        public static List<CommonDDL> GetInsuranceCompanies(SearchQuery ins_comp)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetInsuranceCompanies(ins_comp);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    data.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["icId"]),
                        text = "[" + dr["ic_code"].ToString() + "] " + dr["ic_name"].ToString()
                    });
                }
            }

            return data;
        }

        public static List<CommonDDL> GetInsurancePayers(int? icId)
        {
            List<CommonDDL> roomlist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Appointment.Appointment.GetInsurancePayers(icId);

            foreach (DataRow dr in dt.Rows)
            {
                roomlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["ipId"]),
                    text = dr["ip_name"].ToString()
                });
            }

            return roomlist;
        }

        public static List<CommonDDL> GetInsurancePayersByIcids(string icId)
        {
            List<CommonDDL> roomlist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Appointment.Appointment.GetInsurancePayersByIcids(icId);

            foreach (DataRow dr in dt.Rows)
            {
                roomlist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["ipId"]),
                    text = dr["ip_name"].ToString()
                });
            }

            return roomlist;
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

                DataTable dt = DataAccessLayer.Appointment.Appointment.SearchAppointments(data);

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
                        app.pat_tot_balance = decimal.Parse(dr["pat_tot_balance"].ToString());
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
        #endregion

        #region Appointments JqueryDatatable Miscellaneous Actions
        public static List<CommonDDL> GetEMRPendings(int appId)
        {
            List<CommonDDL> pendinglist = new List<CommonDDL>();

            DataTable dt = DataAccessLayer.Appointment.Appointment.GetEMRPendings(appId);

            foreach (DataRow dr in dt.Rows)
            {
                pendinglist.Add(new CommonDDL
                {
                    id = Convert.ToInt32(dr["emr_actId"]),
                    text = dr["emr_act_name"].ToString()
                });
            }
            return pendinglist;
        }

        public static List<PatientLabel> GetPatientLabel(int patId)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetPatientLabel(patId);

            List<PatientLabel> plabel = new List<PatientLabel>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    plabel.Add(new PatientLabel
                    {
                        patId = Convert.ToInt32(dr["patId"]),
                        pat_name = dr["pat_name"].ToString(),
                        pat_code = dr["pat_code"].ToString(),
                        pat_gender = dr["pat_gender"].ToString(),
                        pat_mob = dr["pat_mob"].ToString(),
                        nationality = dr["nationality"].ToString(),
                        pat_ins = dr["is_ic_name"].ToString(),
                        pat_dob = Convert.ToDateTime(dr["pat_dob"].ToString())
                    });
                }
            }

            return plabel;
        }

        public static string DeleteAppointment(int appId, int app_madeby)
        {
            return DataAccessLayer.Appointment.Appointment.DeleteAppointment(appId, app_madeby);
        }

        public static string UpdateInsuranceType(int appId, string type)
        {
            return DataAccessLayer.Appointment.Appointment.UpdateInsuranceType(appId, type);
        }
        #endregion

        #region Recurring Appointments Insert
        public static DataTable AppointmentBulkSummary(BusinessEntities.Appointment.Appointment app)
        {
            try
            {
                double total_days = (app.app_tdate - app.app_fdate).TotalDays;
                string e_date_time = string.Empty;

                DataTable dt = new DataTable();
                dt.Columns.Add("app_room", typeof(int));
                dt.Columns.Add("app_fdate", typeof(DateTime));
                dt.Columns.Add("app_tdate", typeof(DateTime));
                dt.Columns.Add("app_ae_date", typeof(DateTime));
                dt.Columns.Add("app_ftime", typeof(int));
                dt.Columns.Add("app_ttime", typeof(int));
                dt.Columns.Add("app_ins", typeof(int));
                dt.Columns.Add("app_doctor", typeof(int));
                dt.Columns.Add("app_madeby", typeof(int));
                dt.Columns.Add("app_type", typeof(string));
                dt.Columns.Add("app_status", typeof(string));
                dt.Columns.Add("app_branch", typeof(int));
                dt.Columns.Add("app_inout", typeof(string));
                dt.Columns.Add("app_duplicate", typeof(int));
                dt.Columns.Add("app_rappId", typeof(int));
                dt.Columns.Add("app_emergency", typeof(string));
                dt.Columns.Add("app_source", typeof(int));
                dt.Columns.Add("app_compaign", typeof(int));
                dt.Columns.Add("app_status2", typeof(string));
                dt.Columns.Add("app_eligibility", typeof(string));
                dt.Columns.Add("app_po", typeof(int));
                dt.Columns.Add("app_Comments", typeof(string));
                dt.Columns.Add("app_service", typeof(string));
                dt.Columns.Add("isAvailable", typeof(int));
                dt.Columns.Add("isBooked", typeof(int));
                dt.Columns.Add("app_doc_ftime", typeof(string));
                dt.Columns.Add("app_doc_ttime", typeof(string));

                RecurrenceValues values = null;

                switch (app.app_rec_pattern)
                {
                    case "daily": // Daily
                        DailyRecurrenceSettings da;

                        da = new DailyRecurrenceSettings(app.app_fdate, app.app_tdate);

                        if (app.app_rec_daily == "rd_daily")
                        {
                            values = da.GetValues(int.Parse(app.app_rec_days.ToString()));
                        }
                        else
                        {
                            values = da.GetValues(1, DailyRegenType.OnEveryWeekday);
                        }
                        break;
                    case "weekly": // Weekly
                        string id = string.Empty;

                        int[] day_id = app.app_days_week.Split(',').Select(int.Parse).ToArray();

                        WeeklyRecurrenceSettings we;
                        SelectedDayOfWeekValues selectedValues = new SelectedDayOfWeekValues();

                        we = new WeeklyRecurrenceSettings(app.app_fdate, app.app_tdate);

                        foreach (int day in day_id)
                        {
                            switch (day)
                            {
                                case 0:
                                    selectedValues.Sunday = true;
                                    break;
                                case 1:
                                    selectedValues.Monday = true;
                                    break;
                                case 2:
                                    selectedValues.Tuesday = true;
                                    break;
                                case 3:
                                    selectedValues.Wednesday = true;
                                    break;
                                case 4:
                                    selectedValues.Thursday = true;
                                    break;
                                case 5:
                                    selectedValues.Friday = true;
                                    break;
                                case 6:
                                    selectedValues.Saturday = true;
                                    break;
                            }
                        }

                        values = we.GetValues(int.Parse(app.app_rec_days.ToString()), selectedValues);
                        break;
                    case "monthly": // Monthly

                        MonthlyRecurrenceSettings mo;

                        mo = new MonthlyRecurrenceSettings(app.app_fdate, app.app_tdate);

                        values = mo.GetValues(int.Parse(app.app_days_month.ToString()), Convert.ToInt32(app.app_rec_days.ToString()));

                        break;
                    case "yearly": // Yearly

                        YearlyRecurrenceSettings yr;

                        yr = new YearlyRecurrenceSettings(app.app_fdate, app.app_tdate);

                        values = yr.GetValues(int.Parse(app.app_rec_days.ToString()), app.app_days_month + 1);

                        break;
                }

                if (values != null)
                {
                    if (values.Values.Count > 0)
                    {
                        foreach (DateTime d in values.Values)
                        {
                            DataRow dr = dt.NewRow();
                            dr["app_fdate"] = d;
                            dr["app_tdate"] = d;
                            dr["app_ae_date"] = d.AddDays(1).ToString("yyyy-MM-dd") + " " + app.app_doc_ttime;
                            dr["app_ftime"] = app.app_ftime;
                            dr["app_ttime"] = app.app_ttime;
                            dr["app_room"] = app.app_room;
                            dr["app_ins"] = app.app_ins;
                            dr["app_doctor"] = app.app_doctor;
                            dr["app_madeby"] = app.app_madeby;
                            dr["app_type"] = app.app_type;
                            dr["app_status"] = app.app_status;
                            dr["app_branch"] = app.app_branch;
                            dr["app_inout"] = app.app_inout;
                            dr["app_duplicate"] = (app.app_duplicate == 0) ? 1 : app.app_duplicate;
                            dr["app_rappId"] = app.app_rappId;
                            dr["app_emergency"] = app.app_emergency;
                            dr["app_source"] = app.app_source;
                            dr["app_compaign"] = app.app_compaign;
                            dr["app_status2"] = string.IsNullOrEmpty(app.app_status2) ? "Appointment" : app.app_status2;
                            dr["app_eligibility"] = string.IsNullOrEmpty(app.app_eligibility) ? "" : app.app_eligibility;
                            dr["app_po"] = app.app_package_order;
                            dr["app_Comments"] = string.IsNullOrEmpty(app.app_comments) ? "" : app.app_comments;
                            dr["app_service"] = string.IsNullOrEmpty(app.app_service) ? "0" : app.app_service;

                            int isAvail = 0, isBooked = 0;
                            DataAccessLayer.Appointment.Appointment.SlotAvailiility(app.app_branch, app.app_doctor, d, app.app_ftime, app.app_ttime, out isAvail, out isBooked);
                            dr["isAvailable"] = isAvail;
                            dr["isBooked"] = isBooked;
                            dr["app_doc_ftime"] = app.app_doc_ftime;
                            dr["app_doc_ttime"] = app.app_doc_ttime;





                            dt.Rows.Add(dr);
                        }
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int InsertBulkAppointments(DataTable apps)
        {
            try
            {
                var latestAppFDate = apps.AsEnumerable().Where(row => row["app_status"] != DBNull.Value &&
                           ((string)row["app_status"] == "Arrived" || (string)row["app_status"] == "Invoiced") &&
                           row["app_fdate"] != DBNull.Value).Max(row => row.Field<DateTime?>("app_fdate"));

                for (int i = apps.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = apps.Rows[i];

                    if ((Convert.ToInt32(dr["isBooked"].ToString()) == 1) || (Convert.ToInt32(dr["isAvailable"].ToString()) == 0))
                    {
                        dr.Delete();
                    }
                }
                apps.AcceptChanges();

                var toRemove = new string[] { "isAvailable", "isBooked", "app_doc_ftime", "app_doc_ttime" };

                foreach (var rmv in toRemove)
                {
                    apps.Columns.Remove(rmv);
                }

                return DataAccessLayer.Appointment.Appointment.InsertRecurringAppointments(apps, latestAppFDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CommonDDL> PACKAGE_TYPE(string query)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.PACKAGE_TYPE(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<CommonDDL> GetPackageServices(int query)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.GetPackageServices(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }

        public static List<CommonDDL> SearchAppointmentPackage(int appId, string type)
        {
            DataTable dt = DataAccessLayer.Appointment.Appointment.SearchAppointmentPackage(appId, type);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }

            return data;
        }
        #endregion

        #region Appointment Details
        public static List<BusinessEntities.Appointment.AppointmentHistory> GetAppointmentByPatId(int patId)
        {
            List<BusinessEntities.Appointment.AppointmentHistory> departmentlist = new List<BusinessEntities.Appointment.AppointmentHistory>();

            DataTable dt = DataAccessLayer.Appointment.Appointment.GetAppointmentByPatId(patId);

            foreach (DataRow dr in dt.Rows)
            {
                departmentlist.Add(new BusinessEntities.Appointment.AppointmentHistory
                {
                    appId = Convert.ToInt32(dr["appId"]),
                    patId = Convert.ToInt32(dr["patId"]),
                    app_fdate = Convert.ToDateTime(dr["app_fdate"]),
                    app_ftime = dr["app_ftime"].ToString(),
                    app_ttime = dr["app_ttime"].ToString(),
                    empId = int.Parse(dr["empId"].ToString()),
                    emp_dept = int.Parse(dr["emp_dept"].ToString()),
                    emp_dept_name = dr["emp_dept_name"].ToString(),
                    emp_name = dr["emp_name"].ToString(),
                    app_type = dr["app_type"].ToString(),
                    app_status = dr["app_status"].ToString(),
                    app_instype = dr["app_instype"].ToString(),
                    patient = dr["patient"].ToString(),

                });
            }
            return departmentlist;
        }
        #endregion

        #region GenerateTocken
        public static void Generate_TockenNo(int appId)
        {
            DataAccessLayer.Appointment.Appointment.Generate_TockenNo(appId);
        }

        public static DataSet GetTockenDetails(int? appId)
        {
            return DataAccessLayer.Appointment.Appointment.GetTockenDetails(appId);
        }

        #endregion
    }

}