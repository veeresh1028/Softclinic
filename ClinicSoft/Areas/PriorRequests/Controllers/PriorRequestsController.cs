using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Appointment.AuditLogs;
using BusinessEntities.Documentation;
using BusinessEntities.Patient;
using BusinessEntities.PriorRequests;
using BusinessLogicLayer.PriorRequests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.PriorRequests.Controllers
{
    [Authorize]
    public class PriorRequestsController : Controller
    {
        int PageId = (int)Pages.PriorRequests;

        #region Prior Requests (Page Load & Search)
        public ActionResult PriorRequests()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetPriorAppointmentList(PriorAppointmentSearch Authdata)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    PriorAppointmentCount PriorApp_count = new PriorAppointmentCount();
                    PriorAppointmentStatusColor Prioraps_color = new PriorAppointmentStatusColor();
                    PriorAppointmentListData listData = new PriorAppointmentListData();

                    listData.PriorAppointmentList = BusinessLogicLayer.PriorRequests.PriorRequest.SearchPriorAppointments(Authdata, out PriorApp_count, out Prioraps_color);
                    listData.PriorAppointmentCount = PriorApp_count;
                    listData.PriorAppointmentStatusColor = Prioraps_color;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched PriorRequest Page!"
                    });

                    var jsonResult = Json(listData, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        [HttpPost]
        public ActionResult GetDoctorsByDepartment(DoctorsByDeptBranch depts)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> data = BusinessLogicLayer.Appointment.Appointment.GetDoctorsByDepartments(string.Join(",", depts.Departments), string.Join(",", depts.Branches));

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GetRoomsByBranch(RoomsByDeptBranch branchIds)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> RoomList = BusinessLogicLayer.Appointment.Appointment.GetBranchRooms(string.Join(",", branchIds.Rooms));

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
        public ActionResult GetNationalities()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> NationalitiesList = BusinessLogicLayer.Appointment.Appointment.GetNationalities();

                    var jsonResult = Json(NationalitiesList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetReferrals()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> ReferralsList = BusinessLogicLayer.Appointment.Appointment.GetReferrals();

                    var jsonResult = Json(ReferralsList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetStatus()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> Status = BusinessLogicLayer.Appointment.Appointment.GetStatus();

                    var jsonResult = Json(Status, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetPatients(GetPatients patient)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetPatients(patient);

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
        public ActionResult GetInsuranceCompanies(SearchQuery ins_comp)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetInsuranceCompanies(ins_comp);

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
        public ActionResult GetInsuranceSchemes(string icIds)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt_schemes = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceSchemesByTPA(icIds);

                    SelectList schemesList = Models.Helper.ToSelectList(dt_schemes, "isId", "is_title");

                    var jsonResult = Json(schemesList, JsonRequestBehavior.AllowGet);

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
        public ActionResult GetInsurancePayersByIcIds(string icIds)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> data = BusinessLogicLayer.Appointment.Appointment.GetInsurancePayersByIcids(icIds);

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
        public PartialViewResult EditPriorRequest()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("EditPriorRequest");
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        public JsonResult GetDocPatInfo(int appId)
        {
            EMRInfo docInfo = new EMRInfo();
            try
            {
                DataSet ds = BusinessLogicLayer.Documentation.Doc_patient.GetPatientDocInfo(appId);
                if (ds.Tables.Count > 0)
                {
                    string signs = string.Empty;
                    DataTable dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        docInfo.pat_code = dt.Rows[0]["pat_code"].ToString();
                        docInfo.pat_name = dt.Rows[0]["pat_name"].ToString();
                        docInfo.pat_fname = dt.Rows[0]["pat_fname"].ToString();
                        docInfo.pat_mname = dt.Rows[0]["pat_mname"].ToString();
                        docInfo.pat_lname = dt.Rows[0]["pat_lname"].ToString();
                        docInfo.pat_emirateid = dt.Rows[0]["pat_emirateid"].ToString();
                        docInfo.pat_age = dt.Rows[0]["pat_age"].ToString();
                        docInfo.pat_gender = dt.Rows[0]["pat_gender"].ToString();
                        docInfo.pat_nationality = dt.Rows[0]["pat_nationality"].ToString();
                        docInfo.pat_photo = dt.Rows[0]["pat_photo"].ToString();
                        docInfo.pat_ms = (dt.Rows[0]["pat_ms"].ToString() == "S") ? "Single" : ((dt.Rows[0]["pat_ms"].ToString() == "M") ? "Married" : dt.Rows[0]["pat_ms"].ToString());
                        docInfo.appId = dt.Rows[0]["appId"].ToString();
                        docInfo.app_ic_name = dt.Rows[0]["app_ic_name"].ToString();
                        docInfo.app_fdate_time = dt.Rows[0]["app_fdate_time"].ToString();
                        docInfo.app_doctor_department = dt.Rows[0]["emp_name"].ToString() + " - " + dt.Rows[0]["emp_dept_name"].ToString() + " (" + dt.Rows[0]["emp_license"].ToString() + ")";
                        docInfo.set_emr_lock = dt.Rows[0]["set_emr_lock"].ToString();
                        docInfo.patId = int.Parse(dt.Rows[0]["patId"].ToString());
                        docInfo.app_branch = int.Parse(dt.Rows[0]["app_branch"].ToString());
                        docInfo.app_ae_date = DateTime.Parse(dt.Rows[0]["app_ae_date"].ToString());
                        docInfo.app_ae_date1 = Convert.ToDateTime(dt.Rows[0]["app_ae_date"]);
                        docInfo.emp_photo = dt.Rows[0]["emp_photo"].ToString();
                        docInfo.app_doctor = int.Parse(dt.Rows[0]["app_doctor"].ToString());
                        docInfo.set_header_image = dt.Rows[0]["set_header_image"].ToString();
                        docInfo.set_footer_image = dt.Rows[0]["set_footer_image"].ToString();
                        docInfo.app_category = dt.Rows[0]["app_category"].ToString();
                        docInfo.pat_mob = dt.Rows[0]["pat_mob"].ToString();
                        docInfo.pat_email = dt.Rows[0]["pat_email"].ToString();
                        docInfo.pat_address = dt.Rows[0]["pat_address"].ToString();
                        docInfo.pi_insno = dt.Rows[0]["pi_insno"].ToString();
                        docInfo.pi_polocyno = dt.Rows[0]["pi_polocyno"].ToString();
                        docInfo.pat_dob = dt.Rows[0]["pat_dob"].ToString();
                        docInfo.app_fdate = dt.Rows[0]["app_fdate"].ToString();
                        docInfo.ic_name = dt.Rows[0]["ic_name"].ToString();
                        docInfo.doc_name = dt.Rows[0]["doc_name"].ToString();
                        docInfo.pat_city = dt.Rows[0]["pat_city"].ToString();
                        docInfo.pat_country = dt.Rows[0]["pat_country"].ToString();
                        docInfo.pat_pobox = dt.Rows[0]["pat_pobox"].ToString();
                        docInfo.set_company = dt.Rows[0]["set_company"].ToString();
                        docInfo.set_permit_no = dt.Rows[0]["set_permit_no"].ToString();
                        docInfo.emp_license = dt.Rows[0]["emp_license"].ToString();
                        docInfo.emp_tel = dt.Rows[0]["emp_tel"].ToString();
                        docInfo.emp_fax = dt.Rows[0]["emp_fax"].ToString();
                        docInfo.emp_address = dt.Rows[0]["emp_address"].ToString();
                        docInfo.emp_nat = dt.Rows[0]["emp_nat"].ToString();
                        docInfo.emp_email = dt.Rows[0]["emp_email"].ToString();
                        docInfo.emp_dept_name = dt.Rows[0]["emp_dept_name"].ToString();
                        docInfo.pat_fax = dt.Rows[0]["pat_fax"].ToString();

                        docInfo.doc_sign = (dt.Rows[0]["emp_sign"].ToString() == "") ? string.Empty : Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "EMPLOYEE_SIGNS", dt.Rows[0]["emp_sign"].ToString());
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

                    docInfo.vital_sign = signs;

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

                    docInfo.allergy = allergy;

                    if (!string.IsNullOrEmpty(signs) || !string.IsNullOrEmpty(allergy))
                    {
                        docInfo.isAlert = true;
                    }
                    else
                    {
                        docInfo.isAlert = false;
                    }
                }

                TempData["emr_data"] = docInfo;

                return Json(docInfo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.emr_data = string.Empty;
                return Json(docInfo, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Prior Requests Jquery Datatable Miscellaneous Actions
        [HttpGet]
        public ActionResult GetProceduresAlert(int data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.PriorRequests.PriorRequest.GetProceduresAlert(data);

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
        public PartialViewResult EditAppointment()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("EditAppointment");
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        public ActionResult DeletePriorRequest(int appId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int app_madeby = PageControl.getLoggedinId();
                    string result = BusinessLogicLayer.PriorRequests.PriorRequest.DeletePriorRequests(appId, app_madeby);

                    if (result == "Success")
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = app_madeby,
                            log_desc = $"Employee Deleted Appointment with appId = {appId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Appointment Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Failed to Delete Appointment!" }, JsonRequestBehavior.AllowGet);
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
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ChangeStatusPriorRequest(int appId, string Auth_status)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int app_madeby = PageControl.getLoggedinId();

                    string result = BusinessLogicLayer.PriorRequests.PriorRequest.ChangeStatusPriorRequest(appId, Auth_status, app_madeby);

                    if (result == "Success")
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = app_madeby,
                            log_desc = $"Employee updated this  prior request status {Auth_status} with appId = {appId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Prior request Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Failed to Delete Prior Request!" }, JsonRequestBehavior.AllowGet);
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
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult PatientLabel(PatientLabel label)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PatientLabel> pat_label = BusinessLogicLayer.Appointment.Appointment.GetPatientLabel(label.patId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Patient Label with patId = {label.patId}"
                    });

                    return PartialView("PatientLabel", pat_label.FirstOrDefault());
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpGet]
        public PartialViewResult PrintPatientLabel(PatientLabel pat_label)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Export;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("PrintPatientLabel", pat_label);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpGet]
        public PartialViewResult PriorRequestAuditLogs(Log log)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<AppointmentLogs> app_logs = BusinessLogicLayer.Appointment.AuditLogs.AppointmentLogs.GetAppointmentLogs(log);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Prior Requests Logs with appId = {log.appaId}"
                    });

                    return PartialView("PriorRequestAuditLogs", app_logs);
                }
                else
                {
                    return PartialView("_Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        public ActionResult UpdateInsuranceType(int appId, string type)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int app_madeby = PageControl.getLoggedinId();

                    string result = BusinessLogicLayer.Appointment.Appointment.UpdateInsuranceType(appId, type);

                    if (result == "Success")
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = app_madeby,
                            log_desc = $"Employee Updated Prior Request Insurance Category = {appId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Updated Prior Request Type Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Failed to Update Prior Request Type!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Json(new { isAuthorized = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}