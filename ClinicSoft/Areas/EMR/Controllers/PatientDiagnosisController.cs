using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.MNR;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using static BusinessEntities.EClaims.ClaimSubmissionRequest;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class PatientDiagnosisController : Controller
    {
        int PageId = (int)Pages.PatientDiagnosis;

        #region Patient Diagnosis (Page Load)
        [HttpGet]
        public PartialViewResult PatientDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Patient Diagnosis Page!"
                    });

                    return PartialView("PatientDiagnosis");
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
        public PartialViewResult PatientDiagnosisModal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Patient Diagnosis Page!"
                    });

                    return PartialView("PatientDiagnosisModal");
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
        public JsonResult GetAllPatientDiagnosis(int appId, int? padId)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PatientDiagnosis> diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, padId);

                    return Json(new { isAuthorized = true, message = diagnosis }, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAllPrePatientDiagnosis(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PatientDiagnosis> pre_diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPrePatientDiagnosis(appId, patId);

                return Json(new { isAuthorized = true, message = pre_diagnosis }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Patient Diagnosis CRUD Operations
        [HttpGet]
        public PartialViewResult CreatePatientDiagnosis(int? padId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientDiagnosis diagnosis = new PatientDiagnosis();

                    if (padId > 0)
                    {
                        diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(0, padId).FirstOrDefault();

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Copied Previous Appointment Patient Diagnosis with Id = {padId}"
                        });
                    }

                    return PartialView("CreatePatientDiagnosis", diagnosis);
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsertPatientDiagnosis(PatientDiagnosis data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                data.pad_madeby = PageControl.getLoggedinId();

                try
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Diagnosis.isValidPatientDiagnosis(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.PatientDiagnosis.InsertPatientDiagnosis(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pad_madeby,
                                log_desc = $"Employee Created New Patient Diagnosis (Id) : {data.pad_diagnosis}"
                            });

                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 4,
                                AJ_AJSCId = 15,
                                AJ_AppId = data.pad_appId
                            });

                            EMRInfo emr = (EMRInfo)TempData["emr_data"];
                            TempData.Keep("emr_data");

                            MNRAck ack = new MNRAck();

                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_3(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Patient Diagnosis Updated Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA08_3(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Diagnosis Inserted Successfully! Please Update The conectivity for sharing data."
                                    };
                                }

                                return Json(new { isSuccess = true, isAuthorized = true, ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isSuccess = true, isAuthorized = true, message = "Patient Diagnosis Inserted Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("pad_diagnosis", "Patient Diagnosis already exists with the same type!");
                            }
                            else if (val == -2)
                            {
                                errors.Add("pad_type", "Primary Diagnosis already exists!");
                            }
                            else if (val == -3)
                            {
                                errors.Add("pad_diagnosis", "Patient Diagnosis already exists!");
                            }
                            else if (val == -5)
                            {
                                errors.Add("pad_diagnosis", "Please Enter Complaints First!");
                            }
                            else
                            {
                                errors.Add("", "Error while Creating Patient Diagnosis! Please Try Again.");
                            }

                            return Json(new { isSuccess = false, isAuthorized = true, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, isAuthorized = true, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, isAuthorized = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult EditPatientDiagnosis(int appId, int padId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientDiagnosis diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(appId, padId).FirstOrDefault();

                    return PartialView("EditPatientDiagnosis", diagnosis);
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
        public async Task<ActionResult> UpdatePatientDiagnosis(PatientDiagnosis data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isUpdated = false;

                    data.pad_madeby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Diagnosis.isValidPatientDiagnosis(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.EMR.PatientDiagnosis.UpdatePatientDiagnosis(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pad_madeby,
                                log_desc = $"Employee Updated Patient Diagnosis with Id = {data.padId}"
                            });

                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_3(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Patient Diagnosis Updated Successfully Without Sharing Data!"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA08_3(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Diagnosis Updated Successfully! Please Update the conectivity for sharing data"
                                    };
                                }

                                return Json(new { isUpdated = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isUpdated = true, isSuccess = true, message = "Patient Diagnosis Updated Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Patient Diagnosis Already Exists with the same details!" }, JsonRequestBehavior.AllowGet);
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
        public async Task<ActionResult> DeletePatientDiagnosis(int padId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int pad_madeby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    int val = BusinessLogicLayer.EMR.PatientDiagnosis.DeletePatientDiagnosis(padId, pad_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Patient Diagnosis with Id = {padId}"
                        });

                        if (emr.set_sync == "Yes")
                        {
                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA08_3(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Diagnosis Deleted Successfully Without Sharing Data!"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA08_3(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Patient Diagnosis Deleted Successfully! Please Update The conectivity for sharing data."
                                };
                            }

                            return Json(new { success = true, isAuthorized = true, ack.message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Patient Diagnosis Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Patient Diagnosis!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult CopyPatientDiagnosis(int padId)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                PatientDiagnosis diagnosis = BusinessLogicLayer.EMR.PatientDiagnosis.GetAllPatientDiagnosis(0, padId).FirstOrDefault();

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Copied Previous Patient Diagnosis with Id = {padId}"
                });

                return Json(new { isAuthorized = true, message = diagnosis }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ChangeDiagnosisType(int padId, string pad_type)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.PatientDiagnosis.ChangeDiagnosisType(padId, pad_type);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Patient Diagnosis Type to : {pad_type} with padId = {padId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Patient Diagnosis Type Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Primary Patient Diagnosis Already Exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}