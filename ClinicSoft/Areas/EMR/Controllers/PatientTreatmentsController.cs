using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using BusinessEntities.MNR;
using Google.Protobuf.WellKnownTypes;
using Google.Type;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Crypto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Google.Apis.Requests.BatchRequest;
using Method = RestSharp.Method;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class PatientTreatmentsController : Controller
    {
        int PageId = (int)Pages.PatientTreatments;

        #region Cash Treatments (Page Load & Search)
        [HttpGet]
        public PartialViewResult CashTreatments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);
                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                invoice_info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Cash");
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Cash Treatments Page!"
                    });
                    return PartialView("CashTreatments", invoice_info);
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

        [HttpGet]
        public PartialViewResult CashTreatmentsModal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);
                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Cash Treatments Page!"
                    });
                    return PartialView("CashTreatmentsModal", invoice_info);
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

        [HttpGet]
        public JsonResult GetAllPatientTreatments(int appId, int? ptId, string pt_type)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PatientTreatments> patientTreatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, ptId, pt_type);

                    return Json(patientTreatments, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetAllPrePatientTreatments(int appId, int patId, string pt_type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PatientTreatments> treatment = BusinessLogicLayer.EMR.PatientTreatments.GetAllPrePatientTreatments(appId, patId, pt_type);

                return Json(treatment, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Cash Treatments CRUD Operations
        [HttpGet]
        public PartialViewResult CreateCashTreatment(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.EMR.Cash_PatientTreat qc_info = new Cash_PatientTreat();

                    return PartialView("CreateCashTreatment", qc_info);
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
        public async Task<ActionResult> InsertPatientTreatments(Cash_Treatments data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int ptId = 0;

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    MNRAck ack = new MNRAck();
                    TempData.Keep("emr_data");

                    int val = BusinessLogicLayer.EMR.PatientTreatments.InsertPatientTreatments(data, PageControl.getLoggedinId(), out ptId);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Inserted Patient Treatments with ptId = {ptId}"
                        });

                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 4,
                            AJ_AJSCId = 16,
                            AJ_AppId = int.Parse(emr.appId)
                        });

                        if (emr.set_sync == "Yes")
                        {

                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), val, emr.app_fdate_time);
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully Without Sharing Data"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                };
                            }
                            return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { isInserted = true, isSuccess = true, invId = val, message = "Patient Treatments Invoiced Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, invId = -1, message = "Patient Treatment(s) already exist for this Appointment!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = -2, message = "Please Enter Patient Diagnosis & Progress Notes!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = -1, message = "Error while Inserting Patient Treatment(s)!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = -3, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Account" });
            }
        }

        [HttpGet]
        public PartialViewResult EditCashTreat(int appId, int ptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PatientTreatments> treatment = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, ptId, "Cash");
                    return PartialView("EditCashTreat", treatment.FirstOrDefault());
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
        public async Task<ActionResult> UpdatePatientTreatments(Cash_PatientTreat data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int ptId = 0;
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    int val = BusinessLogicLayer.EMR.PatientTreatments.UpdatePatientTreatments(data, PageControl.getLoggedinId(), out ptId);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updtaed Treatment for with = {ptId}"
                        });
                        if (data.pt_status == "Invoiced")
                        {
                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Patient Treatments Invoiced Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Patient Treatments Invoiced Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Patient Treatments Invoiced Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the treatments " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTreatments(string data, string pt_status)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    List<int> ptIds = new List<int>();

                    string[] arr = data.Split(',');

                    foreach (string str in arr)
                    {
                        ptIds.Add(int.Parse(str));
                    }

                    int val = BusinessLogicLayer.Patient.Treatments.PatientTreatment.DeletePatientTreatments(ptIds, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Patient Treatments for ptIds = {ptIds}"
                        });

                        if (pt_status == "Invoiced")
                        {
                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Patient Treatments Deleted Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");
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
                                        message = "Patient Treatments Deleted Successfully! Please Update The conectivity for sharing data"
                                    };
                                }

                                return Json(new { isAuthorized = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isAuthorized = true, isSuccess = true, message = "Patient Treatment Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isAuthorized = true, isSuccess = true, message = "Patient Treatment Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, message = "Failed To Delete Patient Treatment!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = false, isSuccess = false, message = ex }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult CreatePackage(int ptId)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int pt_madeby = PageControl.getLoggedinId();
                    int val = BusinessLogicLayer.EMR.PatientTreatments.CreatePackage(ptId, pt_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created Package for Treatment with ptId = {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "ptId. " + ptId + " is generated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the Invoices " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdatePatientTreatmentStatus(int ptId, string pt_status, string pt_notes)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int pt_madeby = PageControl.getLoggedinId();
                    ptId = BusinessLogicLayer.EMR.PatientTreatments.UpdatePatientTreatmentStatus(ptId, pt_status, pt_notes);

                    if (ptId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee updated treatment status to Prior Request for the id= {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "ptId. " + ptId + " is updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in Updating status " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Insurance Treatments (Page Load & Search)
        [HttpGet]
        public ActionResult InsuranceTreatments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);

                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                invoice_info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Insurance");
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Insurance Treatments Page!"
                    });

                    return PartialView("InsuranceTreatments", invoice_info);
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

        [HttpGet]
        public ActionResult SearchInsuranceTreatments(string query, string appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.EMR.PatientTreatments.GetInsuranceTreatments(query, appId);

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

        #region Insurance Treatments CRUD Operations
        [HttpGet]
        public PartialViewResult CreateInsTreatment(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Cash_PatientTreat pt = new Cash_PatientTreat();

                    pt.pt_appId = appId;

                    return PartialView("CreateInsTreatment", pt);
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
        public async Task<ActionResult> InsertInsPatientTreatments(Cash_Treatments data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int val = BusinessLogicLayer.EMR.PatientTreatments.InsertInsurancePatientTreatments(data, PageControl.getLoggedinId());
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Inserted Insurance Patient Treatments"
                        });

                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 4,
                            AJ_AJSCId = 16,
                            AJ_AppId = data.treatment_items.FirstOrDefault().pt_appId
                        });

                        if (emr.set_sync == "Yes")
                        {

                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), val, emr.app_fdate_time);
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully Without Sharing Data"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                };
                            }
                            return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { isInserted = true, isSuccess = true, invId = val, message = "Patient Treatments Invoiced Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, invId = val, message = "Insurance Patient Treatment already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Please Enter Patient Diagnosis First!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -5)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Allowed Limit Exceeded!!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while Saving Insurance Treatement." }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, invId = 0, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult EditInsTreatment(int ptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PatientTreatments> treatment = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(0, ptId, "Insurance");

                    return PartialView("EditInsTreatment", treatment.FirstOrDefault());
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
        public async Task<ActionResult> UpdateInsuranceTreatments(BusinessEntities.Patient.Treatments.PatientTreatment data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();

                    int val = BusinessLogicLayer.EMR.PatientTreatments.UpdateInsurancePatientTreatments(data, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Patient Insurance Treatment!"
                        });

                        if (data.pt_status == "Invoiced")
                        {
                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Patient Insurance Treatment Invoiced Successfully Without Sharing Data."
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                    };
                                }

                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Patient Insurance Treatment Invoiced Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Patient Insurance Treatment Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, invId = val, message = "Patient Insurance Treatment already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Please Enter Patient Diagnosis First!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -5)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Allowed Limit Exceeded!!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while Updating Patient Insurance Treatment." }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, invId = 0, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Dental Cash Treatments (Page Load)
        public PartialViewResult DentCashTreatments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);

                BusinessEntities.EMR.PatientTreatments treatmentInfo = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                treatmentInfo.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Cash");
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Dental Cash Treatments!"
                    });

                    return PartialView("DentCashTreatments", treatmentInfo);
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
        #endregion

        #region Dental Cash Treatments CRUD Operations
        public PartialViewResult CreateDentCashTreatment()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.EMR.Cash_PatientTreat dentalTreatments = new Cash_PatientTreat();

                    return PartialView("CreateDentCashTreatment", dentalTreatments);
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

        public PartialViewResult EditDentCashTreatment(int appId, int ptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientTreatments treatment = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, ptId, "Cash").FirstOrDefault();

                    return PartialView("EditDentCashTreatment", treatment);
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
        #endregion

        #region Dental Insurance Treatments (Page Load)
        [HttpGet]
        public PartialViewResult DentalTreatments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                int appId = int.Parse(emr.appId);
                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                invoice_info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Insurance");
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Dental Insurance Treatments Page!"
                    });

                    return PartialView("DentalTreatments", invoice_info);
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
        #endregion

        #region Dental Insurance Treatments CRUD Operations
        [HttpGet]
        public PartialViewResult CreateDentalTreatments(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Cash_PatientTreat pt = new Cash_PatientTreat();
                    pt.pt_appId = appId;

                    return PartialView("CreateDentalTreatments", pt);
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

        [HttpGet]
        public JsonResult GetPatientShare(int appId, int ptId, decimal qty, decimal uprice, decimal disc)
        {
            try
            {
                decimal pat_net = 0;
                int allowed_limit = 0;

                decimal pat_share = BusinessLogicLayer.EMR.PatientTreatments.GetPatientShare(appId, ptId, qty, uprice, disc, out pat_net, out allowed_limit);

                return Json(new { share = pat_share, net = pat_net, allowed_limit = allowed_limit }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult InsertDentInsPatientTreatment(Cash_Treatments data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int val = BusinessLogicLayer.EMR.PatientTreatments.InsertDentInsPatientTreatments(data, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Inserted Dental Insurance Patient Treatments."
                        });

                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 4,
                            AJ_AJSCId = 16,
                            AJ_AppId = int.Parse(emr.appId)
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Dental Insurance Patient Treatement(s) Saved successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, invId = val, message = "Patient Treatment already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Please Enter Patient Diagnosis First!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -5)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Allowed Limit Exceeded!!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while Saving Dental Insurance Treatement." }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, invId = 0, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult EditDentalTreatments(int ptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientTreatments treatment = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(0, ptId, "Insurance").FirstOrDefault();

                    return PartialView("EditDentalTreatments", treatment);
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
        public JsonResult CopyInsuranceTreatment(int pt_appId, int ptId, string type)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.PatientTreatments.CopyInsuranceTreatment(pt_appId, ptId, type);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Insurance Patient Treatment with ptId = {ptId} to Appointment with appId = {pt_appId}"
                        });

                        return Json(new { isAuthorized = true, isSuccess = true, val, message = "Insurance Patient Treatment Copied Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, val, message = "Insurance Patient Treatment already exists with same details!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, val, message = "Error while Copying Insurance Patient Treatment!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, isSuccess = false, message = "You're not Authorized to Copy Patient Treatment!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, message = "Session Expired!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult MoveInsuranceTreatment(int pt_appId, int ptId, string type)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.PatientTreatments.MoveInsuranceTreatment(pt_appId, ptId, type);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Moved Insurance Patient Treatment with ptId = {ptId} to Appointment with appId = {pt_appId}"
                        });

                        return Json(new { isAuthorized = true, isSuccess = true, val, message = "Insurance Patient Treatment Moved Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, val, message = "Invoiced Insurance Patient Treatment can't be moved!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, val, message = "Insurance Patient Treatment already exists for the Appointment!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, val, message = "Error while Moving Insurance Patient Treatment!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, isSuccess = false, message = "You're not Authorized to Moved Patient Treatment!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, message = "Session Expired!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetPatientShareEdit(int appId, int ptId, decimal qty, decimal uprice, decimal disc, int id, decimal new_share)
        {
            try
            {
                decimal pat_net = 0;
                int allowed_limit = 0;

                decimal pat_share = BusinessLogicLayer.EMR.PatientTreatments.GetPatientShareEdit(appId, ptId, qty, uprice, disc, id, new_share, out pat_net, out allowed_limit);

                return Json(new { share = pat_share, net = pat_net, allowed_limit = allowed_limit }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> UpdateDentalInsuranceTreatment(BusinessEntities.Patient.Treatments.PatientTreatment data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();

                    int val = BusinessLogicLayer.EMR.PatientTreatments.UpdateDentInsPatientTreatment(data, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Dental Patient Insurance Treatment!"
                        });

                        if (data.pt_status == "Invoiced")
                        {
                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Dental Patient Insurance Treatment Invoiced Successfully Without Sharing Data."
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                    };
                                }

                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Dental Patient Insurance Treatment Invoiced Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Dental Patient Insurance Treatment Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, invId = val, message = "Dental Patient Insurance Treatment already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Please Enter Patient Diagnosis First!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -5)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Allowed Limit Exceeded!!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while Updating Dental Patient Insurance Treatment." }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Account" });
            }
        }
        #endregion

        #region Treatments Plan
        public PartialViewResult TreatmentsPlan()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);
                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Treatments Plan Page!"
                    });
                    return PartialView("TreatmentsPlan", invoice_info);
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

        public JsonResult GetAllPatientTreatmentsPlan(int appId, int? ptId, string pt_type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PatientTreatments> narrative = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatmentsPlan(appId, ptId, pt_type);

                return Json(narrative, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public PartialViewResult CreateTreatmentsPlan(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.EMR.Cash_PatientTreat qc_info = new Cash_PatientTreat();
                    return PartialView("CreateTreatmentsPlan", qc_info);
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
        #endregion

        #region Miscellaneous Functions
        [HttpGet]
        public ActionResult GetTeeth(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> tooth = BusinessLogicLayer.EMR.PatientTreatments.GetTeeth(query);
                    var jsonResult = Json(tooth, JsonRequestBehavior.AllowGet);
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
        public ActionResult Print_Quotation(string ids, int appId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + appId + ".pdf";
                string filePath = Server.MapPath("~/Documents/Quotations/Cash_Quotations");

                if (!Directory.Exists(Path.Combine(filePath, System.DateTime.Now.ToString("yyyy"))))
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(filePath, System.DateTime.Now.ToString("MMMM"))))
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(filePath, System.DateTime.Now.ToString("dd"))))
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("dd"));
                }

                string path = Path.Combine(filePath, fileName);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                string htmlContent = BusinessLogicLayer.EMR.PatientTreatments.HtmlQuotation(ids);
                var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);

                System.IO.File.WriteAllBytes(path, pdfBytes);

                string file_path = Server.MapPath("~/");

                if (System.IO.File.Exists(path))
                {
                    if (path.StartsWith(file_path))
                    {
                        path = path.Replace(file_path, "");
                    }

                    path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + path.ToString();

                    var result = new
                    {
                        isSuccess = true,
                        contentType = "application/pdf",
                        fileName = path
                    };

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Qutation PDF is Generated for Patient Treatment(s) : {ids}"
                    });

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new
                    {
                        isSuccess = false,
                        errorMessage = "Error while Generating Quotation!"
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Your Session has been Timed Out!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GenerateInvoice(InvoiceNew data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = string.Empty;
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    data.inv_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.EMR.PatientTreatments.GenerateInvoice(data, out inv_no, int.Parse(emr.multi_bill));

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Generated Quick Cash Invoice for inv_no = {inv_no}"
                        });

                        if (emr.set_sync == "Yes")
                        {
                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully Without Sharing Data!"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = val,
                                    message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                };
                            }

                            return Json(new { isInserted = true, isSuccess = true, invId=val, msg = ack.message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            ack = new MNRAck
                            {
                                value = val,
                                message = "Patient Treatment(s) Invoiced Successfully"
                            };
                            return Json(new { isInserted = true, isSuccess = true, invId = val, msg = ack.message }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        ack = new MNRAck
                        {
                            value = val,
                            message = "Error while Generating Invoice"
                        };
                        return Json(new { isInserted = true, isSuccess = true, invId = val, msg = ack.message }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isInserted = true, isSuccess = true, invId = 0, msg = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isInserted = true, isSuccess = true, invId = 0, msg = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> GenerateInsuranceInvoice(TreatmentBulkInvoice data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    MNRAck ack = new MNRAck();
                    string inv_no = string.Empty;

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    data.inv_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.EMR.PatientTreatments.GenerateInsuranceInvoice(data, out inv_no, int.Parse(emr.multi_bill));

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Generated Quick Cash Invoice for inv_no = {inv_no}"
                        });

                        if (emr.set_sync == "Yes")
                        {
                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Patient Treatments Invoiced Successfully Without Sharing Data!"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA03(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Invoiced");
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Patient Treatments Invoiced Successfully! Please Update The conectivity for sharing data"
                                };
                            }

                            return Json(new { isAuthorized = true, isSuccess = true, invId = val, message = ack.message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isAuthorized = true, isSuccess = true, invId = val, message = "Patient Treatment(s) Invoiced Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, invId = -1, message = "Patient Treatment(s) is already Invoiced!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, invId = -2, message = "No Approved Dental Insurance Treatment(s) Available to Generate Invoice!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, invId = 0, message = "Error while Generating Invoice for Patient Treatment(s)!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, invId = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Print_Insurance_Quotation(string ids, int appId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + appId + ".pdf";
                string filePath = Server.MapPath("~/Documents/Quotations/Insurance_Quotations");

                if (!Directory.Exists(Path.Combine(filePath, System.DateTime.Now.ToString("yyyy"))))
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(filePath, System.DateTime.Now.ToString("MMMM"))))
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(filePath, System.DateTime.Now.ToString("dd"))))
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(filePath);
                }
                else
                {
                    filePath = Path.Combine(filePath, System.DateTime.Now.ToString("dd"));
                }

                string path = Path.Combine(filePath, fileName);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                string htmlContent = BusinessLogicLayer.EMR.PatientTreatments.HtmlInsuranceQuotation(ids);
                var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);

                System.IO.File.WriteAllBytes(path, pdfBytes);

                string file_path = Server.MapPath("~/");

                if (System.IO.File.Exists(path))
                {
                    if (path.StartsWith(file_path))
                    {
                        path = path.Replace(file_path, "");
                    }

                    path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + path.ToString();

                    var result = new
                    {
                        isSuccess = true,
                        contentType = "application/pdf",
                        fileName = path
                    };

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Qutation PDF is Generated for Patient Treatment(s) : {ids}"
                    });

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new
                    {
                        isSuccess = false,
                        errorMessage = "Error while Generating Quotation!"
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Your Session has been Timed Out!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateStatusToPriorRequest(int ptId, int inv_appId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int pt_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.EMR.PatientTreatments.UpdateStatusToPriorRequest(ptId, inv_appId);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created Prior Request for Treatment with ptId = {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Prior Request is Generated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isSuccess = false, invId = val, message = "Unable to Change Patient Treatment Status as already Invoiced." }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error While Changing Status to Prior Request!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateApproval(int ptId, string auth_code, DateTime appr_date, DateTime exp_date)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int pt_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.EMR.PatientTreatments.UpdateApproval(ptId, auth_code, appr_date, exp_date);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee updated Approval Details for the id= {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "Approval Details Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while Updating Approval Details!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetInvoiceId(int inv_appId)
        {
            int invId = BusinessLogicLayer.EMR.PatientTreatments.GetInvoiceId(inv_appId);

            return Json(invId, JsonRequestBehavior.AllowGet);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
        #endregion

        #region Package Orders
        public PartialViewResult PackageOrder()
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
                    return PartialView("PackageOrder", package);
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
        public ActionResult GetPatientPackageOrders(int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PackageOrder> dt = BusinessLogicLayer.EMR.PatientTreatments.GetPatientPackageOrders(patId);

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

        public PartialViewResult PatientPackageServiceBilling(int poId, int appId, int patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);
                BusinessEntities.EMR.Cash_PackService PackageOrder = BusinessLogicLayer.EMR.PatientTreatments.PatientPackageOrder(poId, appId, patId);
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Cash Treatments Page!"
                    });

                    // Create an instance of PackageBillingModel and pass it to the partial view
                    var model = new PackageBillingModel
                    {
                        PackageOrder = PackageOrder,
                        qc_info = qc_info
                    };

                    return PartialView("PatientPackageServiceBilling", model);
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

        //public PartialViewResult PatientPackageServiceBilling(int poId,int appId,int patId)
        //{
        //    if (PageControl.getLoggedinId() > 0)
        //    {
        //        int Action = (int)Actions.Read;
        //        EMRInfo emr = (EMRInfo)TempData["emr_data"];
        //        TempData.Keep("emr_data");
        //        BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);
        //        BusinessEntities.EMR.Cash_PackService PackageOrder = BusinessLogicLayer.EMR.PatientTreatments.PatientPackageOrder(poId,appId, patId);
        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
        //            {
        //                log_by = PageControl.getLoggedinId(),
        //                log_desc = "Employee Viewed Cash Treatments Page!"
        //            });
        //            return PartialView("PatientPackageServiceBilling", PackageOrder);
        //        }
        //        else
        //        {
        //            return PartialView("_Unauthorized");
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("_SessionExpired");
        //    }

        //}

        public JsonResult GetPatientPackageServices(int poId, int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Cash_PackService> PackageService = BusinessLogicLayer.EMR.PatientTreatments.GetPatientPackageServices(poId, appId, patId);

                return Json(PackageService, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult GenerateTreatmentsandInvoice(PT_treatments data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = "";
                    int val = BusinessLogicLayer.EMR.PatientTreatments.GenerateTreatmentsandInvoice(data, PageControl.getLoggedinId(), out inv_no);
                    if (val > 0)
                    {
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Generated Invoice for inv_no = {inv_no}"
                        });
                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 4,
                            AJ_AJSCId = 16,
                            AJ_AppId = int.Parse(emr.appId)
                        });
                        return Json(new { isSuccess = true, invId = val, message = "Treatement  Saved successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Please Enter Patient Diagnosis First... " }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -5)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Allowed Limit Exceeded !!!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the treatments " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Account" });
            }
        }

        [HttpPost]
        public ActionResult GenerateTreatments(PT_treatments data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {

                    int val = BusinessLogicLayer.EMR.PatientTreatments.GenerateTreatments(data, PageControl.getLoggedinId());
                    if (val > 0)
                    {
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee added {val} treatments"
                        });
                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 4,
                            AJ_AJSCId = 16,
                            AJ_AppId = int.Parse(emr.appId)
                        });
                        return Json(new { isSuccess = true, invId = val, message = "Treatement  Saved successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Please Enter Patient Diagnosis First... " }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -5)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Allowed Limit Exceeded !!!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the treatments " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Account" });
            }
        }
        #endregion        
    }
}