using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.MNR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace ClinicSoft.Areas.Appointment.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        int PageId = (int)Pages.Appointments;

        #region Appointment Scheduler (Page Load)
        public ActionResult AppointmentIndex()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Appointment Scheduler!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Electronic Medical Record(s)
        [HttpPost]
        public JsonResult GetEMRPatientInfo(int appId)
        {
            EMRInfo emr = new EMRInfo();

            try
            {
                DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(appId);
                if (ds.Tables.Count > 0)
                {
                    string signs = string.Empty;
                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        emr.multi_bill = dt.Rows[0]["multi_bill"].ToString();
                        emr.pat_code = dt.Rows[0]["pat_code"].ToString();
                        emr.pat_name = dt.Rows[0]["pat_name"].ToString();
                        emr.pat_fname = dt.Rows[0]["pat_fname"].ToString();
                        emr.pat_mname = dt.Rows[0]["pat_mname"].ToString();
                        emr.pat_lname = dt.Rows[0]["pat_lname"].ToString();
                        emr.pat_emirateid = dt.Rows[0]["pat_emirateid"].ToString();
                        emr.pat_age = dt.Rows[0]["pat_age"].ToString();
                        emr.pat_gender = dt.Rows[0]["pat_gender"].ToString();
                        emr.pat_nationality = dt.Rows[0]["pat_nationality"].ToString();
                        emr.pat_photo = dt.Rows[0]["pat_photo"].ToString();
                        emr.pat_ms = (dt.Rows[0]["pat_ms"].ToString() == "S") ? "Single" : ((dt.Rows[0]["pat_ms"].ToString() == "M") ? "Married" : dt.Rows[0]["pat_ms"].ToString());
                        emr.appId = dt.Rows[0]["appId"].ToString();
                        emr.app_ic_name = dt.Rows[0]["app_ic_name"].ToString();
                        emr.app_fdate_time = dt.Rows[0]["app_fdate_time"].ToString();
                        emr.app_doctor_department = dt.Rows[0]["emp_name"].ToString() + " - " + dt.Rows[0]["emp_dept_name"].ToString() + " (" + dt.Rows[0]["emp_license"].ToString() + ")";
                        emr.set_emr_lock = dt.Rows[0]["set_emr_lock"].ToString();
                        emr.patId = int.Parse(dt.Rows[0]["patId"].ToString());
                        emr.icId = int.Parse(dt.Rows[0]["icId"].ToString());
                        emr.isId = int.Parse(dt.Rows[0]["isId"].ToString());
                        emr.app_branch = int.Parse(dt.Rows[0]["app_branch"].ToString());
                        emr.app_ae_date = DateTime.Parse(dt.Rows[0]["app_ae_date"].ToString());
                        emr.app_ae_date1 = Convert.ToDateTime(dt.Rows[0]["app_ae_date"]);
                        emr.emp_photo = dt.Rows[0]["emp_photo"].ToString();
                        emr.app_doctor = int.Parse(dt.Rows[0]["app_doctor"].ToString());
                        emr.set_header_image = dt.Rows[0]["set_header_image"].ToString();
                        emr.set_footer_image = dt.Rows[0]["set_footer_image"].ToString();
                        emr.app_category = dt.Rows[0]["app_category"].ToString();
                        emr.pat_mob = dt.Rows[0]["pat_mob"].ToString();
                        emr.pat_email = dt.Rows[0]["pat_email"].ToString();
                        emr.pat_address = dt.Rows[0]["pat_address"].ToString();
                        emr.pi_insno = dt.Rows[0]["pi_insno"].ToString();
                        emr.pi_polocyno = dt.Rows[0]["pi_polocyno"].ToString();
                        emr.pat_dob = dt.Rows[0]["pat_dob"].ToString();
                        emr.app_fdate = dt.Rows[0]["app_fdate"].ToString();
                        emr.is_title = dt.Rows[0]["is_title"].ToString();
                        emr.ic_name = dt.Rows[0]["ic_name"].ToString();
                        emr.doc_name = dt.Rows[0]["doc_name"].ToString();
                        emr.pat_city = dt.Rows[0]["pat_city"].ToString();
                        emr.pat_country = dt.Rows[0]["pat_country"].ToString();
                        emr.pat_pobox = dt.Rows[0]["pat_pobox"].ToString();
                        emr.set_company = dt.Rows[0]["set_company"].ToString();
                        emr.set_permit_no = dt.Rows[0]["set_permit_no"].ToString();
                        emr.emp_license = dt.Rows[0]["emp_license"].ToString();
                        emr.emp_tel = dt.Rows[0]["emp_tel"].ToString();
                        emr.emp_fax = dt.Rows[0]["emp_fax"].ToString();
                        emr.emp_address = dt.Rows[0]["emp_address"].ToString();
                        emr.emp_nat = dt.Rows[0]["emp_nat"].ToString();
                        emr.emp_email = dt.Rows[0]["emp_email"].ToString();
                        emr.app_room = int.Parse(dt.Rows[0]["app_room"].ToString());
                        emr.emp_dept_name = dt.Rows[0]["emp_dept_name"].ToString();
                        emr.emp_designation = dt.Rows[0]["emp_desig_name"].ToString();
                        emr.pat_fax = dt.Rows[0]["pat_fax"].ToString();
                        emr.set_fax = dt.Rows[0]["set_fax"].ToString();
                        emr.set_tel = dt.Rows[0]["set_tel"].ToString();
                        emr.set_address = dt.Rows[0]["set_address"].ToString();
                        emr.set_city = dt.Rows[0]["set_city"].ToString();
                        emr.emp_speciality = dt.Rows[0]["emp_speciality"].ToString();
                        emr.pat_contact_role = dt.Rows[0]["pat_contact_role"].ToString();
                        emr.pi_edate = dt.Rows[0]["pi_edate"].ToString();
                        emr.set_email = dt.Rows[0]["set_email"].ToString();
                        emr.emp_speciality = dt.Rows[0]["emp_speciality"].ToString();
                        emr.doc_sign = (dt.Rows[0]["emp_sign"].ToString() == "") ? string.Empty : Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dt.Rows[0]["emp_sign"].ToString());
                        emr.pi_image = (dt.Rows[0]["pi_image"].ToString() == "") ? string.Empty : Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Insurance_Cards", dt.Rows[0]["pi_image"].ToString());
                        emr.is_allowed_limit = Convert.ToDecimal(dt.Rows[0]["is_allowed_limit"].ToString());
                        emr.app_status = dt.Rows[0]["app_status"].ToString();
                        emr.pat_class = dt.Rows[0]["pat_class"].ToString();
                        emr.set_sync = dt.Rows[0]["set_sync"].ToString();
                        emr.set_mnr = dt.Rows[0]["set_mnr"].ToString();
                        emr.app_ip_code = dt.Rows[0]["app_ip_code"].ToString();
                    }

                    DataTable dt_signs = ds.Tables[1];

                    if (dt_signs.Rows.Count > 0)
                    {
                        DataRow dr = dt_signs.Rows[0];
                        signs += (!string.IsNullOrEmpty(dr["sign_temp"].ToString())) ? (" Temp:" + dr["sign_temp"].ToString() + "°C,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_pulse"].ToString())) ? (" Pulse:" + dr["sign_pulse"].ToString() + "bpm,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_bp"].ToString())) ? (" BPS:" + dr["sign_bp"].ToString() + "mmHg,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_bpd"].ToString())) ? (" BPD:" + dr["sign_bpd"].ToString() + "mmHg,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_height"].ToString())) ? (" Height:" + dr["sign_height"].ToString() + "cm,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_weight"].ToString())) ? (" Weight:" + dr["sign_weight"].ToString() + "kg,") : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_bmi"].ToString())) ? (" BMI:" + dr["sign_bmi"].ToString()) : string.Empty;
                        signs += (!string.IsNullOrEmpty(dr["sign_uri"].ToString())) ? (" Blood Sugar:" + dr["sign_uri"].ToString()) : string.Empty;
                    }

                    emr.vital_sign = signs;

                    string allergy = string.Empty;
                    DataTable dt_allergy = ds.Tables[2];

                    if (dt_allergy.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt_allergy.Rows)
                        {
                            string _for = dr["all_for"].ToString();
                            string _pexam = dr["all_pexam"].ToString();

                            allergy += (!string.IsNullOrEmpty(_for)) ? (!string.IsNullOrEmpty(_pexam) ? (_for.ToString() + " " + _pexam + ",") : (_for + ",")) : string.Empty;
                        }
                    }

                    emr.allergy = allergy;

                    if (!string.IsNullOrEmpty(signs) || !string.IsNullOrEmpty(allergy))
                    {
                        emr.isAlert = true;
                    }
                    else
                    {
                        emr.isAlert = false;
                    }
                }

                TempData["emr_data"] = emr;

                return Json(emr, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.EMR_Data = ex.Message;

                return Json(emr, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Load Resources
        [HttpGet]
        public ActionResult GetDoctors(string docIds, string setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();

                try
                {
                    string id = string.Empty;
                    if (!string.IsNullOrEmpty(docIds))
                    {
                        string[] arr_id = docIds.Split(',');

                        foreach (string s in arr_id)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                id += "," + s;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(setId))
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            id = id.Remove(0, 1);
                            list = BusinessLogicLayer.Appointment.Doctor.GetDoctorData(id, int.Parse(setId));
                        }
                        else
                        {
                            list = BusinessLogicLayer.Appointment.Doctor.GetDoctorData(string.Empty, int.Parse(setId));
                        }
                    }
                    else
                    {
                        list = BusinessLogicLayer.Appointment.Doctor.GetDoctorData();
                    }

                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetDoctorsWithRange(string docIds, string setId, string start, string end)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();

                try
                {
                    string id = string.Empty;
                    if (!string.IsNullOrEmpty(docIds))
                    {
                        string[] arr_id = docIds.Split(',');

                        foreach (string s in arr_id)
                        {
                            if (!string.IsNullOrEmpty(s))
                            {
                                id += "," + s;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(setId))
                    {
                        if (!string.IsNullOrEmpty(id))
                        {
                            id = id.Remove(0, 1);
                            list = BusinessLogicLayer.Appointment.Doctor.GetDoctorDataWithDateRange(id, int.Parse(setId), start, end);
                        }
                        else
                        {
                            list = BusinessLogicLayer.Appointment.Doctor.GetDoctorDataWithDateRange(string.Empty, int.Parse(setId), start, end);
                        }
                    }
                    else
                    {
                        list = BusinessLogicLayer.Appointment.Doctor.GetDoctorDataWithDateRange();
                    }


                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetBranches()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranchesForAppointment();
                    branchList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetDepartments()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> departmentList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Appointment.Appointment.GetAllDepartments();
                    departmentList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(departmentList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(departmentList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetAppointments(string start, string end, string docIds, string setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Appointments> appointments = new List<BusinessEntities.Appointment.S_Appointments>();
                try
                {
                    appointments = BusinessLogicLayer.Appointment.Appointment.GetAppointmentData(start, end, docIds, int.Parse(setId));

                    var jsonResult = Json(appointments, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(appointments, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetActive_Doctors(string docId, string setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Doctor> list = new List<BusinessEntities.Appointment.S_Doctor>();

                try
                {
                    int _docId = 0;
                    int _setId = 0;

                    if (!string.IsNullOrEmpty(setId))
                    {
                        int.TryParse(setId, out _setId);
                    }

                    if (!string.IsNullOrEmpty(docId))
                    {
                        int.TryParse(docId, out _docId);
                    }

                    list = BusinessLogicLayer.Appointment.Doctor.Doctors_Active(_docId, _setId);

                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPackageOrders(int app_ins)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PackageOrder> dt = BusinessLogicLayer.Appointment.Appointment.GetPackageOrder(0, 0, app_ins);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPackageOrderServices(int piId, int poId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PackageOrderService> dt = BusinessLogicLayer.Appointment.Appointment.GetPackageOrderServices(poId, 0, piId);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        [HttpGet]
        public ActionResult GetAppointmentFollowupStatus(int piId, int app_doctor, string app_fdate)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string value = BusinessLogicLayer.Appointment.Appointment.GetFollowupStatus(piId, app_doctor, DateTime.Parse(app_fdate));

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetTimeSlotId(int app_branch, string app_time)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int tId = BusinessLogicLayer.Appointment.Appointment.GetTimeSlotId(app_branch, app_time);

                    var jsonResult = Json(tId, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetRoomsByBranch(int app_branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_rooms = BusinessLogicLayer.Masters.Rooms.GetBranchRooms(app_branch);
                    SelectList RoomList = Models.Helper.ToSelectList(dt_rooms, "rId", "room");

                    var jsonResult = Json(RoomList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetDoctorsByBranch(int app_branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<BusinessEntities.Appointment.S_Doctor> doctor_list = BusinessLogicLayer.Appointment.Doctor.Doctors_Active(0, app_branch);
                    SelectList DoctorsList = new SelectList(doctor_list, "id", "title");

                    var jsonResult = Json(DoctorsList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult GetDoctorsByDepartments(DepartmentSearchList dept)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Doctor> data = new List<BusinessEntities.Appointment.S_Doctor>();

                if (dept.Departments != null)
                {
                    data = BusinessLogicLayer.Appointment.Doctor.GetDoctorsByDepartments(string.Join(",", dept.Departments), dept.Doctor);
                }

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult SearchPatients(string query, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.SearchPatients(int.Parse(type), query);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetEMIDExpiry(int piId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt = BusinessLogicLayer.Appointment.Appointment.GetEMIDExpiry(piId);

                var list = JsonConvert.SerializeObject(dt, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore });

                return Content(list, "application/json");
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Insert / Update / Rebook / Clone / Delete Appointment
        [HttpGet]
        public ActionResult CreateAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                app.BranchList = BusinessLogicLayer.Company.GetBranchList();
                app.RoomsList = BusinessLogicLayer.Masters.Rooms.GetBranchRoomsList(app.app_branch);
                app.DoctorsList = BusinessLogicLayer.Appointment.Doctor.Doctors_Active(0, app.app_branch);
                app.FromTimeList = BusinessLogicLayer.Appointment.Appointment.GetTimeSlotList(app.app_branch, app.app_fdate.ToString("yyyy-MM-dd"), app.app_doctor);
                app.ToTimeList = app.FromTimeList;
                app.StatusList = BusinessLogicLayer.Appointment.Appointment.GetAppointmentStatusList();

                return PartialView("CreateAppointment", app);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    app.app_madeby = PageControl.getLoggedinId();

                    int value = BusinessLogicLayer.Appointment.Appointment.CreateAppointment(app);

                    DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(value);

                    DataTable dt = ds.Tables[0];

                    MNRAck ack = new MNRAck();

                    if (value > 0)
                    {
                        if (app.app_status == "Booked")
                        {
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 1,
                                AJ_AJSCId = 1,
                                AJ_AppId = int.Parse(dt.Rows[0]["appId"].ToString())
                            });
                        }
                        else if (app.app_status == "Arrived")
                        {
                            BusinessLogicLayer.Appointment.Appointment.Generate_TockenNo(int.Parse(dt.Rows[0]["appId"].ToString()));
                            GenerateTocken(int.Parse(dt.Rows[0]["appId"].ToString()));
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 1,
                                AJ_AJSCId = 3,
                                AJ_AppId = int.Parse(dt.Rows[0]["appId"].ToString())
                            });
                        }
                        else if (app.app_status == "Confirmation")
                        {
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 1,
                                AJ_AJSCId = 2,
                                AJ_AppId = int.Parse(dt.Rows[0]["appId"].ToString())
                            });
                        }

                        if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                        {
                            if (app.app_status == "Booked")
                            {
                                if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.SIUS12(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = value,
                                        message = "Appointment Booked Successfully!"
                                    };
                                }

                                var jsonResult = new JsonResult
                                {
                                    Data = ack,
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };

                                jsonResult.MaxJsonLength = int.MaxValue;

                                return jsonResult;
                            }
                            else if (app.app_status == "Arrived")
                            {
                                if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                                {
                                    ack = await MNR.Nabidh.ADTA04(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate"].ToString(), value);

                                }
                                else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA04(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);

                                }
                                else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA04(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = value,
                                        message = "Appointment Inserted Successfully!"
                                    };
                                }

                                var jsonResult = new JsonResult
                                {
                                    Data = ack,
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };

                                jsonResult.MaxJsonLength = int.MaxValue;

                                return jsonResult;
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Inserted Successfully"
                                };

                                var jsonResult = new JsonResult
                                {
                                    Data = ack,
                                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                                };

                                jsonResult.MaxJsonLength = int.MaxValue;

                                return jsonResult;
                            }
                        }
                        else
                        {
                            ack = new MNRAck
                            {
                                value = value,
                                message = "Appointment Inserted Successfully"
                            };

                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                    }
                    else
                    {
                        //var jsonResult = Json(value, JsonRequestBehavior.AllowGet);

                        //jsonResult.MaxJsonLength = int.MaxValue;

                        //return jsonResult;


                        ack = new MNRAck
                        {
                            value = value,
                            message = "Failed to Book Appointment. Please Try Again"
                        };

                        var jsonResult = new JsonResult
                        {
                            Data = ack,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };

                        jsonResult.MaxJsonLength = int.MaxValue;

                        return jsonResult;
                    }
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult UpdateAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                app.BranchList = BusinessLogicLayer.Company.GetBranchList();
                app.RoomsList = BusinessLogicLayer.Masters.Rooms.GetBranchRoomsList(app.app_branch);
                app.DoctorsList = BusinessLogicLayer.Appointment.Doctor.Doctors_Active(0, app.app_branch);
                app.FromTimeList = BusinessLogicLayer.Appointment.Appointment.GetTimeSlotList(app.app_branch, app.app_fdate.ToString("yyyy-MM-dd"), app.app_doctor);
                app.ToTimeList = app.FromTimeList;
                app.StatusList = BusinessLogicLayer.Appointment.Appointment.GetAppointmentStatusList();

                return PartialView("UpdateAppointment", app);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> EditAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    app.app_madeby = PageControl.getLoggedinId();
                    int value = BusinessLogicLayer.Appointment.Appointment.UpdateAppointments(app);
                    DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(app.appId);
                    DataTable dt = ds.Tables[0];

                    MNRAck ack = new MNRAck();

                    if (value > 0)
                    {
                        if (app.app_status == "Arrived")
                        {
                            if (dt.Rows[0]["app_startDate"].ToString() == "")
                            {
                                BusinessLogicLayer.Appointment.Appointment.Generate_TockenNo(int.Parse(dt.Rows[0]["appId"].ToString()));
                                GenerateTocken(int.Parse(dt.Rows[0]["appId"].ToString()));

                            }
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 1,
                                AJ_AJSCId = 3,
                                AJ_AppId = int.Parse(dt.Rows[0]["appId"].ToString())
                            });
                        }
                        else if (app.app_status == "Confirmation")
                        {
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 1,
                                AJ_AJSCId = 2,
                                AJ_AppId = int.Parse(dt.Rows[0]["appId"].ToString())
                            });
                        }
                    }

                    if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                    {
                        if (app.app_status == "Arrived")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                            {
                                ack = await MNR.Nabidh.ADTA04(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate"].ToString(), value);
                            }
                            else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA04(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);
                            }
                            else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA04(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Inserted Successfully"
                                };
                            }

                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                            if (ack.value == -2)
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Inserted Successfully,But Error While Conecting Nabidh!!!!"
                                };
                            }

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                        else if (app.app_status == "Discharged")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                            {
                                ack = await MNR.Nabidh.ADTA03(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, dt.Rows[0]["app_fdate"].ToString());
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Discharged Successfully"
                                };
                            }

                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                        else if (app.app_status == "Cancelled")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                            {
                                ack = await MNR.Nabidh.ADTA11(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate"].ToString(), value);

                            }
                            else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA11(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);

                            }
                            else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                            {
                                ack = await MNR.Malaffi.SIUS15(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Cancelled Successfully"
                                };
                            }
                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                        else if (app.app_status == "Deleted")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                            {
                                ack = await MNR.Malaffi.SIUS17(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Deleted Successfully"
                                };
                            }

                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                        else if (app.app_status == "No Show")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                            {
                                ack = await MNR.Malaffi.SIUS26(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Updated Successfully"
                                };
                            }
                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };
                            jsonResult.MaxJsonLength = int.MaxValue;
                            return jsonResult;
                        }
                        else if (app.app_status == "Re-scheduled")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                            {
                                ack = await MNR.Malaffi.SIUS13(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Appointment Updated Successfully"
                                };
                            }

                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                        else
                        {
                            ack = new MNRAck
                            {
                                value = value,
                                message = "Appointment Updated Successfully"
                            };
                            var jsonResult = new JsonResult
                            {
                                Data = ack,
                                JsonRequestBehavior = JsonRequestBehavior.AllowGet
                            };

                            jsonResult.MaxJsonLength = int.MaxValue;

                            return jsonResult;
                        }
                    }
                    else
                    {
                        ack = new MNRAck
                        {
                            value = value,
                            message = "Appointment Updated Successfully"
                        };
                        var jsonResult = new JsonResult
                        {
                            Data = ack,
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                        jsonResult.MaxJsonLength = int.MaxValue;

                        return jsonResult;
                    }
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult RebookAppointment(BusinessEntities.Appointment.ReBookAppointment app)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int value = BusinessLogicLayer.Appointment.Appointment.RebookAppointments(app);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = app.app_madeby,
                        log_desc = $"Employee Rebooked Appointment with appId = {app.appId}"
                    });

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        [HttpGet]
        public ActionResult CloneAppointment(BusinessEntities.Appointment.ReBookAppointment app)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int value = BusinessLogicLayer.Appointment.Appointment.CopyCloneAppointments(app);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = app.app_madeby,
                        log_desc = $"Employee Cloned Appointment with appId = {app.appId}"
                    });

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        [HttpPost]
        public JsonResult BlockAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Create;
            string message;
            bool isAuthorized = false, isSuccess = false;
            int loginId = PageControl.getLoggedinId();

            if (loginId > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    isAuthorized = true;

                    app.app_madeby = loginId;

                    BusinessEntities.Masters.Employees empDetail = BusinessLogicLayer.Masters.Employees.GetEmployeeById(app.app_doctor).FirstOrDefault();
                    app.app_branch = empDetail.emp_branch;

                    isSuccess = BusinessLogicLayer.Appointment.Appointment.BlockAppointment(app);

                    if (isSuccess)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = loginId,
                            log_desc = $"Employee Blocked Appointment Time Slot {app.app_fdate.ToString("dd-MM-yyyy")} {app.app_doc_ftime} - {app.app_tdate.ToString("dd-MM-yyyy")} {app.app_doc_ttime}"
                        });

                        message = "Time slot blocking successful";
                    }
                    else
                    {
                        message = "Error occured when blocking time slot";
                    }
                }
                else
                {
                    message = "You are not authorized to block this appointment time slot";
                }
            }
            else
            {
                message = "You are currently Logged Out from the session. Please login and try again";
            }


            return Json(new { isAuthorized, isSuccess, message }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DeleteAppointment(string appId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int value = BusinessLogicLayer.Appointment.Appointment.DeleteAppointments(int.Parse(appId), PageControl.getLoggedinId());

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        #endregion

        #region Recurring Appointments Insert
        [HttpGet]
        public ActionResult BulkAppointmentsOverview(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    app.app_madeby = PageControl.getLoggedinId();

                    DataTable dt = BusinessLogicLayer.Appointment.Appointment.AppointmentBulkSummary(app);

                    TempData["BulkAppointments"] = dt;

                    return PartialView("BulkSummary", dt);
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult InsertBulkAppointments()
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable data = (DataTable)TempData["BulkAppointments"];
                    TempData.Remove("BulkAppointments");

                    int value = BusinessLogicLayer.Appointment.Appointment.InsertBulkAppointments(data);

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult PACKAGE_TYPE(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.PACKAGE_TYPE(query);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPackageServices(int query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetPackageServices(query);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult SearchAppointmentPackage(int appId, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.SearchAppointmentPackage(int.Parse(appId.ToString()), type);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        [HttpGet]
        public ActionResult GetPatientPackageOrders(int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PackageOrder> dt = BusinessLogicLayer.Appointment.Appointment.GetPackageOrder(0, patId, 0);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public void GenerateTocken(int appId)
        {
            int Action = (int)Actions.Create;
            DataTable dt = new DataTable();
            try
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                DataSet ds = BusinessLogicLayer.Appointment.Appointment.GetTockenDetails(appId);
                dt = ds.Tables[0];
                string filename = Server.MapPath("~/Documents/Tockens/Token_" + dt.Rows[0]["app_startDate"].ToString() + ".xml"); // Specify the output filename
                string filename_ = "Token_" + dt.Rows[0]["app_startDate"].ToString() + ".xml";

                XmlTextWriter writer = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
                writer.Formatting = System.Xml.Formatting.Indented;
                writer.WriteStartDocument();

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    writer.WriteStartElement("Token_Details");

                    writer.WriteElementString("Doctor_Name", dr["emp_name"].ToString());
                    writer.WriteElementString("Clinic", dr["set_company"].ToString());
                    writer.WriteElementString("Room_Name", dr["room"].ToString());
                    writer.WriteElementString("MRN", dr["pat_code"].ToString());
                    writer.WriteElementString("Patient_Name", dr["pat_name"].ToString());
                    writer.WriteElementString("Token_Number", dr["app_startDate"].ToString());
                    writer.WriteElementString("Visit_DateTime", DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd/mm/yyyy") + " " + dt.Rows[0]["app_doc_ftime"].ToString());
                    writer.WriteElementString("Visit_Created_By", dr["app_madeby_name"].ToString());

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Flush();
                    writer.Close();
                    byte[] fileContent = null;
                    string fileName = Path.Combine(filename);
                    System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                    long byteLength = new System.IO.FileInfo(fileName).Length;
                    fileContent = binaryReader.ReadBytes((Int32)byteLength);
                    fs.Close();
                    fs.Dispose();
                    binaryReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region Miscellaneous Functions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            bool isPartial = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            TempData["error"] = filterContext;

            string actionName = isPartial ? "ErrorPartialView" : "Error";

            filterContext.Result = RedirectToAction(actionName, "Error", new { area = "Common" });
        }
        #endregion
    }
}