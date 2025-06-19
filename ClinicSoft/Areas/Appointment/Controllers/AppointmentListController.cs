using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Appointment.AuditLogs;
using BusinessEntities.Invoice;
using BusinessEntities.KPIReports;
using BusinessEntities.Patient;
using Google.Type;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Appointment.Controllers
{
    [Authorize]
    public class AppointmentListController : Controller
    {
        int PageId = (int)Pages.AppointmentList;

        #region Appointments (Page Load & Search)
        [HttpGet]
        public ActionResult AppointmentList()
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
        public JsonResult GetAppointmentList(AppointmentSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                AppointmentCount app_count = new AppointmentCount();
                AppointmentStatusColor aps_color = new AppointmentStatusColor();
                AppointmentListData listData = new AppointmentListData();

                listData.AppointmentList = BusinessLogicLayer.Appointment.Appointment.SearchAppointments(data, out app_count, out aps_color);
                listData.AppointmentCount = app_count;
                listData.AppointmentStatusColor = aps_color;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Appointments Page!"
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
        #endregion

        #region Appointments Advanced Filters
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
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
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
        #endregion

        #region Appointments Jquery Datatable Miscellaneous Actions
        [HttpGet]
        public ActionResult GetEMRPendings(int data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetEMRPendings(data);

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
        public ActionResult DeleteAppointment(int appId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int app_madeby = PageControl.getLoggedinId();
                    string result = BusinessLogicLayer.Appointment.Appointment.DeleteAppointment(appId, app_madeby);

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
        public PartialViewResult AppointmentAuditLogs(Log log)
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
                        log_desc = $"Employee Viewed Appointment Logs with appId = {log.appaId}"
                    });

                    return PartialView("AppointmentAuditLogs", app_logs);
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
        public JsonResult GetAppointmentHistory(int piId)
        {
            bool isAuthorized = false;
            string message = "";
            List<AppointmentHistory> appList = new List<AppointmentHistory>();

            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    isAuthorized = true;
                    PatientInsuranceDetails piDetails = BusinessLogicLayer.Patient.PatientInsurance.GetInsuranceDataByInsuranceID(piId);
                    int patId = piDetails.pi_patient;
                    appList = BusinessLogicLayer.Appointment.Appointment.GetAppointmentByPatId(patId);
                    message = "Fetched all Appointments of the patient";
                }
                else
                {
                    message = "You are not authorized to view the Appointments of this patient";
                }
            }
            else
            {
                message = "Please Login to view this information";
            }

            return Json(new { message, isAuthorized, data = appList }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public PartialViewResult ViewBillingHistory(int patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientBillingInfo info = BusinessLogicLayer.Patient.Patient.PatientInvoiceSummary(patId);
                    
                    return PartialView("ViewBillingHistory", info);
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
        public PartialViewResult ViewAppointmentHistory(int patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<AppointmentHistory> data = BusinessLogicLayer.Appointment.Appointment.GetAppointmentByPatId(patId);
                    return PartialView("ViewAppointmentHistory", data);
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
        public ActionResult AuditLogs(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    AuditLogsReport info = new AuditLogsReport();
                    info.appId = appId;
                    info.vitalLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.VitalSignsAudit(appId);
                    info.allergiesLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.AllergiesAudit(appId);
                    info.pfaLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.PastHistoryAudit(appId);
                    info.complaintLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.CheifComplaintsAudit(appId);
                    info.hpiLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.HPIAudit(appId);
                    info.rosLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.ROSAudit(appId);
                    info.nusenoteLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.NurseNotesAudit(appId);
                    info.narrativeLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.NarrativeDiagnosisAudit(appId);
                    info.patdiagLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.PatDiagnosisAudit(appId);
                    info.addendumLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.AddendumAudit(appId);
                    info.progressnoteLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.ProgressNotesAudit(appId);
                    info.treatmentLogsKPI = BusinessLogicLayer.AuditLogs.AuditLogs.PatientTreatemntsAudit(appId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Audit Logs with appId = {appId}"
                    });

                    return PartialView("AuditLogs", info);
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
        public PartialViewResult InsuranceBilling(int appId, string app_dept, string app_status)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.QI_Info info = new BusinessEntities.Invoice.QI_Info();
                    info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Cash");
                    info.InvNosList.Add(new BusinessEntities.Appointment.CommonDDL { id = 0, text = "NEW INVOICE" });
                    info.InvNosList = info.InvNosList;
                    info.appId = appId;
                    info.app_dept = app_dept;
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);
                    info.prev_invoices = qc_info.qc_invoice_info.invId.ToString();
                    info.app_status = app_status;

                    return PartialView("InsuranceBilling", info);
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
        public PartialViewResult CashBilling(int appId, string app_dept, string app_status)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.QC_Info info = new BusinessEntities.Invoice.QC_Info();
                    info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Cash");
                    info.InvNosList.Add(new BusinessEntities.Appointment.CommonDDL { id = 0, text = "NEW INVOICE" });
                    info.InvNosList = info.InvNosList;
                    info.appId = appId;
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);
                    info.app_dept = app_dept;
                    info.prev_invoices = qc_info.qc_invoice_info.invId.ToString();
                    info.app_status = app_status;
                    info.multi_bill = qc_info.qc_invoice_info.multi_bill;

                    return PartialView("CashBilling", info);
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
        public PartialViewResult MedicalSheet(Log log)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Appointment Logs with appId = {log.appaId}"
                    });

                    return PartialView("MedicalSheet");
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
                            log_desc = $"Employee Updated Appointment Insurance Category = {appId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Updated Appointment Type Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Failed to Update Appointment Type!" }, JsonRequestBehavior.AllowGet);
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

        #region Package Orders
        [HttpGet]
        public ActionResult GetPatientsId(GetPatients patient)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetPatientsId(patient);

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
        public PartialViewResult PackOrder()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("PackOrder");
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
        public PartialViewResult AppPackageOrder()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                BusinessEntities.EMR.PatientPackage package = BusinessLogicLayer.EMR.PatientPackage.AutoCreatepackageRefNo(int.Parse("1"));
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Package Order Page!"
                    });
                    return PartialView("AppPackageOrder", package);
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
        #endregion

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