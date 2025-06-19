using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class DiagnosisController : Controller
    {
        int PageId = (int)Pages.Diagnosis;

        #region Diagnosis Master (Page Load)
        [HttpGet]
        public ActionResult Diagnosis()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Diagnosis!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult SearchDiagnosis(SearchDiagnosis data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Diagnosis> diaglist = BusinessLogicLayer.Masters.Diagnosis.SearchDiagnosis(data);

                var jsonResult = Json(diaglist, JsonRequestBehavior.AllowGet);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Diagnosis Master!"
                });

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDepartments()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Departments> departmentList = new List<BusinessEntities.Masters.Departments>();
                try
                {
                    departmentList = BusinessLogicLayer.Masters.Departments.GetActiveDepartments();

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
        public ActionResult GetDiagnosisCodes(GetDiagnosisCode code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Masters.Diagnosis.GetDiagnosisCodes(code);

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
        #endregion

        #region Diagnosis CRUD Operations
        [HttpGet]
        public PartialViewResult CreateDiagnosis(int id = 0)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Diagnosis diagnosis = new BusinessEntities.Masters.Diagnosis();
                    diagnosis.departmentlist = BusinessLogicLayer.Masters.Departments.GetActiveDepartments();

                    return PartialView("CreateDiagnosis", diagnosis);
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
        [ValidateAntiForgeryToken]
        public ActionResult InsertDiagnosis(BusinessEntities.Masters.Diagnosis diagnosis)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.Diagnosis.isValidCreateDiagnosis(diagnosis, out errors))
                {
                    isInserted = BusinessLogicLayer.Masters.Diagnosis.InsertUpdateDiagnosis(diagnosis);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created New Diagnosis : {diagnosis.diag_name}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Diagnosis Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Diagnosis already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public PartialViewResult EditDiagnosis(int diagId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Diagnosis diagnosis = BusinessLogicLayer.Masters.Diagnosis.GetDiagnosisById(diagId).FirstOrDefault();

                    diagnosis.departmentlist = BusinessLogicLayer.Masters.Departments.GetActiveDepartments();

                    return PartialView("EditDiagnosis", diagnosis);
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
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDiagnosis(BusinessEntities.Masters.Diagnosis diagnosis)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                if (SecurityLayer.FormValidations.Diagnosis.isValidUpdateDiagnosis(diagnosis, out errors))
                {
                    isUpdated = BusinessLogicLayer.Masters.Diagnosis.InsertUpdateDiagnosis(diagnosis);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated existing Diagnosis with diagId = {diagnosis.diagId}"
                        });

                        return Json(new { isUpdated = true, isSuccess = true, message = "Diagnosis Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Diagnosis already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateDiagnosisStatus(int diagId, string diag_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Diagnosis.UpdateDiagnosisStatus(diagId, diag_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Diagnosis Status to : {diag_status} with diagId = {diagId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Diagnosis with the same Name & Code already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DeleteDiagnosis(int diagId, string diag_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Diagnosis.UpdateDiagnosisStatus(diagId, diag_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Diagnosis with diagId = {diagId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Diagnosis Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, error = true, message = "Failed to Delete Diagnosis!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized Access!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
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