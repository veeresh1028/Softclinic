using BusinessEntities;
using BusinessEntities.Appointment;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ClinicSoft.Areas.Appointment.Controllers
{
    [Authorize]
    public class RoomSchedulerController : Controller
    {
        int PageId = (int)Pages.RoomSchedule;

        public ActionResult RoomSchedulerIndex()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Room Scheduler!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

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
                        emr.pat_code = dt.Rows[0]["pat_code"].ToString();
                        emr.pat_name = dt.Rows[0]["pat_name"].ToString();
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
                        emr.emp_photo = dt.Rows[0]["emp_photo"].ToString();
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

                //Session["emr_data"] = emr;
                TempData["emr_data"] = emr;

                return Json(emr, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.EMR_Data = string.Empty;
                return Json(emr, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetRooms(string roomIds, string setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.Rooms> list = new List<BusinessEntities.Appointment.Rooms>();

                try
                {
                    string id = string.Empty;
                    if (!string.IsNullOrEmpty(roomIds))
                    {
                        string[] arr_id = roomIds.Split(',');

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
                            list = BusinessLogicLayer.Appointment.Rooms.GetRoomData(id, int.Parse(setId));
                        }
                        else
                        {
                            list = BusinessLogicLayer.Appointment.Rooms.GetRoomData(string.Empty, int.Parse(setId));
                        }
                    }
                    else
                    {
                        list = BusinessLogicLayer.Appointment.Rooms.GetRoomData();
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
        public ActionResult GetAppointmentsForRoomSchedule(string start, string end, string docIds, string setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Appointments> appointments = new List<BusinessEntities.Appointment.S_Appointments>();
                try
                {
                    appointments = BusinessLogicLayer.Appointment.Appointment.GetAppointmentDataForRoomSchedule(start, end, docIds, int.Parse(setId));

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
        public ActionResult GetActiveRooms(string roomId, string setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.Rooms> list = new List<BusinessEntities.Appointment.Rooms>();

                try
                {
                    int _roomId = 0;
                    int _setId = 0;

                    if (!string.IsNullOrEmpty(setId))
                    {
                        int.TryParse(setId, out _setId);
                    }

                    if (!string.IsNullOrEmpty(roomId))
                    {
                        int.TryParse(roomId, out _roomId);
                    }

                    if (_roomId > 0 || _setId > 0)
                    {
                        list = BusinessLogicLayer.Appointment.Rooms.RoomsActive(_roomId, _setId);
                    }


                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreateAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_rooms = BusinessLogicLayer.Masters.Rooms.GetBranchRooms(app.app_branch);
                SelectList RoomList = Models.Helper.ToSelectList(dt_rooms, "rId", "room");
                ViewData["RoomList"] = RoomList;

                List<BusinessEntities.Appointment.S_Doctor> doctor_list = BusinessLogicLayer.Appointment.Doctor.Doctors_Active(0, app.app_branch);
                SelectList DoctorsList = new SelectList(doctor_list, "id", "title");
                ViewData["DoctorsList"] = DoctorsList;

                DataTable dt_timeslots = BusinessLogicLayer.Appointment.Appointment.GetTimeSlots(app.app_branch, app.app_fdate.ToString("yyyy-MM-dd"), app.app_doctor);
                SelectList FromTimeList = Models.Helper.ToSelectList(dt_timeslots, "id", "text");
                ViewData["FromTimeList"] = FromTimeList;

                SelectList ToTimeList = Models.Helper.ToSelectList(dt_timeslots, "id", "text");
                ViewData["ToTimeList"] = ToTimeList;

                DataTable dt_status = BusinessLogicLayer.Appointment.Appointment.GetAppointmentStatus();
                SelectList StatusList = Models.Helper.ToSelectList(dt_status, "aps_status", "aps_status");
                ViewData["StatusList"] = StatusList;

                return PartialView("CreateAppointment", app);
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
        public ActionResult InsertAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    app.app_madeby = PageControl.getLoggedinId();
                    int value = BusinessLogicLayer.Appointment.Appointment.CreateAppointment(app);

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
        public ActionResult UpdateAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_rooms = BusinessLogicLayer.Masters.Rooms.GetBranchRooms(app.app_branch);
                SelectList RoomList = Models.Helper.ToSelectList(dt_rooms, "rId", "room");
                ViewData["RoomList"] = RoomList;

                List<BusinessEntities.Appointment.S_Doctor> doctor_list = BusinessLogicLayer.Appointment.Doctor.Doctors_Active(0, app.app_branch);
                SelectList DoctorsList = new SelectList(doctor_list, "id", "title");
                ViewData["DoctorsList"] = DoctorsList;

                DataTable dt_timeslots = BusinessLogicLayer.Appointment.Appointment.GetTimeSlots(app.app_branch, app.app_fdate.ToString("yyyy-MM-dd"), app.app_doctor);
                SelectList FromTimeList = Models.Helper.ToSelectList(dt_timeslots, "id", "text");
                ViewData["FromTimeList"] = FromTimeList;

                SelectList ToTimeList = Models.Helper.ToSelectList(dt_timeslots, "id", "text");
                ViewData["ToTimeList"] = ToTimeList;

                DataTable dt_status = BusinessLogicLayer.Appointment.Appointment.GetAppointmentStatus();
                SelectList StatusList = Models.Helper.ToSelectList(dt_status, "aps_status", "aps_status");
                ViewData["StatusList"] = StatusList;

                return PartialView("UpdateAppointment", app);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult EditAppointment(BusinessEntities.Appointment.Appointment app)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    app.app_madeby = PageControl.getLoggedinId();
                    int value = BusinessLogicLayer.Appointment.Appointment.UpdateAppointments(app);

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

        [HttpPost]
        public ActionResult GetDoctorsByDepartments(DepartmentSearchList dept)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Appointment.S_Doctor> data = new List<BusinessEntities.Appointment.S_Doctor>();
                if (dept.Departments.Length > 0)
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