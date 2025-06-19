using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Documentation;
using Google.Type;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    [Authorize]
    public class CoderDiagnosisController : Controller
    {
        int PageId = (int)Pages.CoderDiagnosis;

        #region Coder Diagnosis Page Load & CRUD Operations
        [HttpGet]
        public ActionResult CoderDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Coder Diagnosis Page!"
                    });

                    return View("CoderDiagnosis");
                }
                else
                {
                    return View("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpGet]
        public JsonResult GetCoderDiagnosis(int appId, int? codId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CoderDiagnosis> coderDiagnosis = BusinessLogicLayer.Documentation.CoderDiagnosis.GetCoderDiagnosis(appId, codId);

                return Json(new { isAuthorized = true, message = coderDiagnosis }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllPreviousCoderDiagnosis(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CoderDiagnosis> pcoderDiagnosis = BusinessLogicLayer.Documentation.CoderDiagnosis.GetAllPreviousCoderDiagnosis(appId, patId);

                return Json(new { isAuthorized = true, message = pcoderDiagnosis }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateCoderDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    CoderDiagnosis Coddiagnosis = new CoderDiagnosis();

                    return PartialView("CreateCoderDiagnosis", Coddiagnosis);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("SessionExpired");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertCoderDiagnosis(CoderDiagnosis data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Documentation.CoderDiagnosis.isValidPatientDiagnosis(data, out errors))
                    {
                        data.cod_madeby = PageControl.getLoggedinId();

                        int val = BusinessLogicLayer.Documentation.CoderDiagnosis.InsertCoderDiagnosis(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.cod_madeby,
                                log_desc = $"Employee Created New Coder Diagnosis (Id) : {data.cod_diagnosis}"
                            });
                            return Json(new { isSuccess = true, message = "Coder Diagnosis Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("pad_diagnosis", "Coder Diagnosis already exists with same Code! Duplicate Not Allowed.");
                            }
                            else if (val == -2)
                            {
                                errors.Add("pad_type", " Primary Diagnosis already Exists! Only One Allowed.");
                            }
                            else
                            {
                                errors.Add("", "Error while Creating Primary Diagnosis! Please Try Again...");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult EditCoderDiagnosis(int appId, int codId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    CoderDiagnosis coderDiagnosis = BusinessLogicLayer.Documentation.CoderDiagnosis.GetCoderDiagnosis(appId, codId).FirstOrDefault();

                    return PartialView("EditCoderDiagnosis", coderDiagnosis);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("SessionExpired");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCoderDiagnosis(CoderDiagnosis data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isUpdated = false;

                    data.cod_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Documentation.CoderDiagnosis.isValidPatientDiagnosis(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Documentation.CoderDiagnosis.UpdateCoderDiagnosis(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.cod_madeby,
                                log_desc = $"Employee Updated Coder Diagnosis with Id = {data.codId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Coder Diagnosis Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Coder Diagnosis Already Exists with the same details!" }, JsonRequestBehavior.AllowGet);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DeleteCoderDiagnosis(int codId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int cod_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.Documentation.CoderDiagnosis.DeleteCoderDiagnosis(codId, cod_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Coder Diagnosis with Id = {codId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Coder Diagnosis Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Coder Diagnosis!" }, JsonRequestBehavior.AllowGet);
                    }
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

        [HttpPost]
        public ActionResult ChangeDiagnosisType(int codId, string cod_type)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Documentation.CoderDiagnosis.ChangeDiagnosisType(codId, cod_type);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Coder Diagnosis Type to : {cod_type} with padId = {codId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Coder Diagnosis Type Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Primary Coder Diagnosis Already Exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Coder Diagnosis Type!" }, JsonRequestBehavior.AllowGet);
                    }
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
        public ActionResult GetDiagnosis(string query, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int pad_madeby = PageControl.getLoggedinId();

                type = string.IsNullOrEmpty(type) ? "0" : type;

                try
                {
                    List<CommonDDL> diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetDiagnosis(query, int.Parse(type), pad_madeby);
                    var jsonResult = Json(diagnosis, JsonRequestBehavior.AllowGet);
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
        public ActionResult CopyCoderDiagnosis(int codId, int cod_appId)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int cod_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.Documentation.CoderDiagnosis.CopyCoderDiagnosis(codId, cod_appId, cod_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Coder Diagnosis Type to : {cod_appId} from  codId = {codId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Coder Diagnosis Copied Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Primary Coder Diagnosis Alreedy Exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Coder Diagnosis!" }, JsonRequestBehavior.AllowGet);
                    }
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
        #endregion
    }
}