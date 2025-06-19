using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Reports.Controllers
{
    [Authorize]
    public class PreSubmissionReportController : Controller
    {
        int PageId = (int)Pages.PreSubmissionsReport;

        [HttpGet]
        public ActionResult PreSubmissionReport()
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
        public JsonResult GetPreSubmissionReport(PreSubmissionReportSearch search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Reports.PreSubmissionReport> submissions = BusinessLogicLayer.Reports.PreSubmissionReport.GetPreSubmissionReport(search);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Pre Submission Report!"
                });

                var jsonResult = Json(submissions, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #region Report Advanced Filters
        [HttpGet]
        public ActionResult GetBranches(int? empId, int? setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranchesForEmployees(empId, setId);
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
    }
}