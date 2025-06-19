using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using BusinessEntities.MNR;
using Google.Rpc;
using Google.Type;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI;
using static BusinessEntities.EClaims.ClaimSubmissionRequest;
using DateTime = System.DateTime;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class PrescriptionController : Controller
    {
        int PageId = (int)Pages.Prescription;

        #region Prescription (Page Load)
        [HttpGet]
        public PartialViewResult Prescription()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Cash Prescription Page!"
                    });

                    return PartialView("Prescription");
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
        public PartialViewResult PrescriptionModal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Cash Prescription Page!"
                    });

                    return PartialView("PrescriptionModal");
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
        public JsonResult GetAllPrescription(int appId, int? preId, string pre_med_type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Prescription> prescription = BusinessLogicLayer.EMR.Prescription.GetAllPrescription(appId, 0, pre_med_type);

                return Json(prescription, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetPrePrescription(int appId, int patId, string pre_med_type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Prescription> previous = BusinessLogicLayer.EMR.Prescription.GetPrePrescription(appId, patId, pre_med_type);

                return Json(previous, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetPrescriptionType(string query, int type)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> presc_type = BusinessLogicLayer.EMR.Prescription.GetPrescriptionType(query, type);
                    var jsonResult = Json(presc_type, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetMedicine(string query, string type, string plan, int pre_doctor)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                type = string.IsNullOrEmpty(type) ? "0" : type;

                try
                {
                    List<CommonDDL> diagnosis = BusinessLogicLayer.EMR.Prescription.GetMedicine(query, int.Parse(type), plan, pre_doctor);
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

        [HttpGet]
        public ActionResult GetRouteOfAdmin(string query, string flag)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    //if (flag == "DHA")
                    //{
                    //    flag = "DHA";
                    //}
                    //else if (flag == "MOH")
                    //{
                    //    flag = "MOH";
                    //}
                    //else if (flag == "MALAFFI")
                    //{
                    //    flag = "MALAFFI";
                    //}
                    //else if (flag == "Cash")
                    //{
                    //    flag = "Cash";
                    //}
                    //else
                    //{
                    //    flag = "";
                    //}
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    flag = string.IsNullOrEmpty(flag) ? (@emr.app_category) : flag;

                    List<GetByName> presc_type = BusinessLogicLayer.EMR.Prescription.GetRouteOfAdmin(query, flag);
                    var jsonResult = Json(presc_type, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception)
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

        #region Prescription CRUD Operations
        [HttpGet]
        public PartialViewResult CreatePrescription(int? preId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Prescription prescription = new Prescription();
                    if (preId == 0)
                    {
                        prescription = new Prescription();
                    }
                    else
                    {
                        prescription = BusinessLogicLayer.EMR.Prescription.GetAllPrescription(0, preId, "Cash").FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous Patient HPI with Id = {preId}"
                        });
                    }

                    return PartialView("CreatePrescription", prescription);
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
        public async Task<ActionResult> InsertPrescription(Prescription data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pre_madeby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidPrescription(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.Prescription.InsertPrescription(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pre_madeby,
                                log_desc = $"Employee Created New Prescription (Id) : {data.pre_medicine}"
                            });

                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 4,
                                AJ_AJSCId = 17,
                                AJ_AppId = int.Parse(emr.appId)
                            });

                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Prescription Inserted Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Inserted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Prescription Inserted Successfully! Please Update The conectivity for sharing data."
                                    };
                                }

                                return Json(new { isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isSuccess = true, message = "Prescription Inserted Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("", "Prescription already exists with same Code! Duplicate Not Allowed");
                            }
                            else
                            {
                                errors.Add("", "Error while Updating Prescription! Please Try Again..");
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
        public PartialViewResult EditPrescription(int appId, int preId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Prescription prescription = BusinessLogicLayer.EMR.Prescription.GetAllPrescription(appId, preId, "CASH").FirstOrDefault();

                    return PartialView("EditPrescription", prescription);
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
        public async Task<ActionResult> UpdatePrescription(Prescription data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pre_madeby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidPrescription(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.Prescription.UpdatePrescription(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pre_madeby,
                                log_desc = $"Employee Updated Prescription with Id = {data.preId}"
                            });

                            if (emr.set_sync == "Yes")
                            {
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Prescription Updated Successfully Without Sharing Data!"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Updated");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Prescription Updated Successfully! Please Update The conectivity for sharing data."
                                    };
                                }

                                return Json(new { isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isSuccess = true, message = "Prescription Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("", "Prescription already exists with the same details!");
                            }
                            else
                            {
                                errors.Add("", "Error while Updating Prescription! Please Try Again.");
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

        [HttpPost]
        public async Task<ActionResult> DeletePrescription(int preId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int pre_madeby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    int val = BusinessLogicLayer.EMR.Prescription.DeletePrescription(preId, pre_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Insurance Prescription with Id = {preId}"
                        });

                        if (emr.set_sync == "Yes")
                        {
                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Prescription Deleted Successfully Without Sharing Data."
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.OMP009(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, "Deleted");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Prescription Deleted Successfully! Please Update The conectivity for sharing data."
                                };
                            }

                            return Json(new { success = true, isAuthorized = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Insurance Prescription Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Insurance Prescription!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Print_Prescription(string id, int pre_appId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + pre_appId + ".pdf";
                string filePath = Server.MapPath("~/Documents/Prescription/Cash_Prescriptions");

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

                string htmlContent = BusinessLogicLayer.EMR.Prescription.HtmlPrescription(id, pre_appId);
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
                        log_desc = $"Employee generated Prescription PDF with ids : {id}"
                    });

                    return Json(new { isSuccess = true, message = path }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new
                    {
                        isSuccess = false,
                        message = "Error while Generating Prescription!"
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult Print_Insurance_Prescription(string id, int pre_appId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + pre_appId + ".pdf";
                string filePath = Server.MapPath("~/Documents/Prescription/Insurance_Prescriptions");

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

                string htmlContent = BusinessLogicLayer.EMR.Prescription.HtmlPrescription(id, pre_appId);
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
                        log_desc = $"Employee generated Prescription PDF with ids : {id}"
                    });

                    return Json(new { isSuccess = true, message = path }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new
                    {
                        isSuccess = false,
                        message = "Error while Generating Prescription!"
                    };

                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Prescription Favourites (Page Load)
        [HttpGet]
        public ActionResult PrescriptionFavourites()
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Prescription Favourites Page!"
                    });

                    return View("PrescriptionFavourites");
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
        public JsonResult GetAllPrescriptionFavourites(int empId, int? prefId)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PrescriptionFavourites> favrouite = BusinessLogicLayer.EMR.Prescription.GetAllPrescriptionFavourites(empId, prefId);

                    return Json(favrouite, JsonRequestBehavior.AllowGet);
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

        #region Prescription Favourites CRUD Operations
        [HttpGet]
        public PartialViewResult CreatePrescriptionFavourite()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PrescriptionFavourites presc_fav = new PrescriptionFavourites();

                    return PartialView("CreatePrescriptionFavourite", presc_fav);
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
        public ActionResult InsertCreatePrescriptionFavourite(PrescriptionFavourites data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pref_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidPrescriptionFavourite(data.pref_medicine, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.Prescription.InsertUpdatePrescriptionFavourites(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pref_madeby,
                                log_desc = $"Employee Created New Prescription Favourites (Id) : {data.pref_medicine}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Prescription Favourites Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("pref_medicine", "Prescription Favourites already exists with same Code! Duplicate Not Allowed");
                            }

                            else
                            {
                                errors.Add("", "Error while Creating Prescription Favourites! Please Try Again.");
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
        public PartialViewResult EditPrescriptionFavourite(int empId, int prefId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<PrescriptionFavourites> presc_fav = BusinessLogicLayer.EMR.Prescription.GetAllPrescriptionFavourites(empId, prefId);

                    return PartialView("EditPrescriptionFavourite", presc_fav.FirstOrDefault());
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
        public ActionResult UpdatePrescriptionFavourites(PrescriptionFavourites data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pref_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidPrescriptionFavourite(data.pref_medicine, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.Prescription.InsertUpdatePrescriptionFavourites(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pref_madeby,
                                log_desc = $"Employee Updated Patient Prescription with Id = {data.prefId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Patient Prescription Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Patient Prescription Already Exists with the same details!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeletePrescriptionFavourites(int prefId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int pref_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.EMR.Prescription.DeletePrescriptionFavourites(prefId, pref_madeby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Favourite Prescription with Id = {prefId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Favourite Prescription Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Favourite Prescription!" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Prescription Controlled (Page Load)
        [HttpGet]
        public ActionResult PrescriptionControlled()
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Controlled Medicine Page!"
                    });
                    return View("PrescriptionControlled");
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public ActionResult GetDrugMedicine(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> drug = BusinessLogicLayer.EMR.Prescription.GetDrugMedicine(query);
                    var jsonResult = Json(drug, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetControlledDrugPrescription(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ControlledDrug> drug = BusinessLogicLayer.EMR.Prescription.GetControlledDrugPrescription(appId);

                return Json(drug, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Prescription Controlled CRUD Operations
        [HttpGet]
        public PartialViewResult CreatePrescriptionControlled()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    return PartialView("CreatePrescriptionControlled");
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
        public ActionResult SubmitControllDrug(ControlledDrug data)
        {
            try
            {
                //  bool isInserted = false;
                data.prec_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidPrescriptionFavourite(data.prec_medicine, out errors))
                    {
                        DataTable dtAppInfo = new DataTable();
                        DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(data.prec_appId);
                        dtAppInfo = ds.Tables[0];
                        bool isCreated = false;
                        string _token = string.Empty;
                        Token token = new Token();
                        string _identifier = string.Empty;
                        //string token;
                        if (dtAppInfo.Rows.Count > 0)
                        {


                            switch (int.Parse(dtAppInfo.Rows[0]["isEMID"].ToString()))
                            {
                                case 1: _identifier = dtAppInfo.Rows[0]["pat_emirateid"].ToString().Replace("-", ""); break;
                                case 2: _identifier = dtAppInfo.Rows[0]["pat_ec_name3"].ToString() + dtAppInfo.Rows[0]["nat_ISO2"].ToString(); break;
                                default: _identifier = dtAppInfo.Rows[0]["pat_emirateid"].ToString().Replace("-", ""); break;
                            }

                            //for token
                            var Base64_Bytes = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["CD_ClientId"].ToString() + ":" + ConfigurationManager.AppSettings["CD_SecretKey"].ToString());
                            string Base64 = Convert.ToBase64String(Base64_Bytes);


                            var client3 = new RestClient("https://erxqa.inhealth.ae/cas/oidc/token");
                            //var client3 = new RestClient("https://openjet2.inhealth.ae/cas/oidc/token");
                            //client.Timeout = -1;
                            //var request = new RestRequest(Method.POST);
                            var request3 = new RestRequest();
                            request3.Timeout = 30000;
                            request3.Method = Method.Post;
                            request3.AddHeader("Authorization", "Basic " + Base64);
                            request3.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                            request3.AddParameter("Client_Id", ConfigurationManager.AppSettings["CD_ClientId"].ToString());
                            request3.AddParameter("Client_Secret", ConfigurationManager.AppSettings["CD_SecretKey"].ToString());
                            request3.AddParameter("grant_type", ConfigurationManager.AppSettings["CD_GrantType"].ToString());
                            RestResponse response3 = client3.Execute(request3);
                            token = JsonConvert.DeserializeObject<Token>(response3.Content);
                            //token
                            _token = token.access_token;

                            var client = new RestClient(ConfigurationManager.AppSettings["CDEndPointUrl"].ToString() + "Patient?identifier=" + _identifier);
                            var request = new RestRequest();
                            request.Timeout = 30000;
                            request.Method = Method.Get;
                            request.AddHeader("Authorization", "Bearer " + _token);
                            var body = @"";
                            request.AddParameter("text/plain", body, ParameterType.RequestBody);
                            RestResponse response = client.Execute(request);

                            Patient_Response response1 = new Patient_Response();
                            response1 = JsonConvert.DeserializeObject<Patient_Response>(response.Content);

                            if (response1.total != 1)
                            {
                                List<Name> name = new List<Name>();
                                List<string> given = new List<string>();

                                Name _name = new Name();
                                _name.family = dtAppInfo.Rows[0]["pat_name"].ToString();

                                if (!string.IsNullOrEmpty(dtAppInfo.Rows[0]["pat_lname"].ToString().Trim())) { given.Add(dtAppInfo.Rows[0]["pat_lname"].ToString().Trim()); }
                                if (!string.IsNullOrEmpty(dtAppInfo.Rows[0]["pat_mname"].ToString().Trim())) { given.Add(dtAppInfo.Rows[0]["pat_mname"].ToString().Trim()); }

                                _name.given = given;
                                name.Add(_name);

                                List<Telecom> telecoms = new List<Telecom>();

                                if (!string.IsNullOrEmpty(dtAppInfo.Rows[0]["pat_mob"].ToString().Trim()))
                                {
                                    Telecom telecom = new Telecom();
                                    telecom.use = "work";
                                    telecom.rank = 1;
                                    telecom.value = dtAppInfo.Rows[0]["pat_mob"].ToString().Trim();
                                    telecom.system = "phone";
                                    telecoms.Add(telecom);
                                }

                                if (!string.IsNullOrEmpty(dtAppInfo.Rows[0]["pat_email"].ToString().Trim()))
                                {
                                    Telecom telecom = new Telecom();
                                    telecom.use = "work";
                                    telecom.rank = 1;
                                    telecom.value = dtAppInfo.Rows[0]["pat_email"].ToString().Trim();
                                    telecom.system = "email";
                                    telecoms.Add(telecom);
                                }

                                List<Identifier> identifiers = new List<Identifier>();

                                if (!string.IsNullOrEmpty(dtAppInfo.Rows[0]["pat_emirateid"].ToString().Trim()))
                                {
                                    Identifier identifier = new Identifier();
                                    identifier.use = "official";
                                    identifier.value = dtAppInfo.Rows[0]["pat_emirateid"].ToString().Trim().Replace("-", "");
                                    identifier.system = "http://fhir.inhealth.ae/EmiratesId";
                                    identifiers.Add(identifier);
                                }

                                if (!string.IsNullOrEmpty(dtAppInfo.Rows[0]["pat_ec_name3"].ToString()))
                                {
                                    Identifier identifier = new Identifier();
                                    identifier.use = "official";
                                    identifier.value = dtAppInfo.Rows[0]["pat_ec_name3"].ToString() + dtAppInfo.Rows[0]["nat_ISO2"].ToString();
                                    identifier.system = "http://fhir.inhealth.ae/InternationalIdAndCountry";
                                    identifiers.Add(identifier);
                                }

                                Patient_Resquest patient_resquest = new Patient_Resquest();
                                patient_resquest.resourceType = "Patient";
                                patient_resquest.name = name;
                                patient_resquest.active = true;
                                patient_resquest.gender = dtAppInfo.Rows[0]["pat_gender"].ToString().Trim().ToLower();
                                patient_resquest.telecom = telecoms;
                                patient_resquest.birthDate = DateTime.Parse(dtAppInfo.Rows[0]["pat_dob"].ToString()).ToString("yyyy-MM-dd");
                                patient_resquest.identifier = identifiers;

                                var client2 = new RestClient(ConfigurationManager.AppSettings["CDEndPointUrl"].ToString() + "Patient");
                                var request2 = new RestRequest();
                                request2.Timeout = 30000;
                                request2.Method = Method.Post;
                                request2.AddHeader("Authorization", "Bearer " + token.access_token);
                                request2.AddHeader("Content-Type", "application/json");
                                var body2 = @JsonConvert.SerializeObject(patient_resquest);
                                request2.AddParameter("application / json", body2, ParameterType.RequestBody);
                                RestResponse response2 = client2.Execute(request2);


                                if (response2.StatusCode == System.Net.HttpStatusCode.Created)
                                {
                                    isCreated = true;
                                }
                                else
                                {

                                    // return Json(new { isSuccess = false, message = response.Content }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                isCreated = true;
                            }
                            if (isCreated)
                            {
                                ControlDrugRequest cd_request = BusinessLogicLayer.EMR.Prescription.GetRequestString(dtAppInfo, data);

                                var client4 = new RestClient("https://erxqa.inhealth.ae/blaze/MedicationRequest");
                                var request4 = new RestRequest();
                                request4.Timeout = 30000;
                                request4.Method = Method.Post;
                                request4.AddHeader("Authorization", "Bearer " + _token);
                                request4.AddHeader("Content-Type", "application/json");

                                var body4 = @JsonConvert.SerializeObject(cd_request);
                                request4.AddParameter("application /json", body4, ParameterType.RequestBody);
                                RestResponse response4 = client4.Execute(request4);
                                ControlDrugResponse cd_response = new ControlDrugResponse();
                                cd_response = JsonConvert.DeserializeObject<ControlDrugResponse>(response4.Content);
                                if (response4.StatusCode == System.Net.HttpStatusCode.Created)
                                {
                                    int val = BusinessLogicLayer.EMR.Prescription.InsertControlledDrugs(data);
                                    return Json(new { isSuccess = true, isInserted = true, message = "Controll Drugs Submitted Succesfully" }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    return Json(new { isSuccess = true, isInserted = true, message = "Failed to Submit Controll Drugs" }, JsonRequestBehavior.AllowGet);
                                }


                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Patient Can't empty " }, JsonRequestBehavior.AllowGet);
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
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();

        }
        #endregion

        #region General Prescription (Page Load)
        [HttpGet]
        public ActionResult GeneralPrescription()
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed General Prescription!"
                    });

                    return PartialView("GeneralPrescription");
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
        public JsonResult GetAllGeneralPrescription(int appId, int? gpreId)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<GeneralPrescription> prescription = BusinessLogicLayer.EMR.Prescription.GetAllGeneralPrescription(appId, gpreId);

                    return Json(prescription, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetPreGeneralPrescription(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<GeneralPrescription> previous = BusinessLogicLayer.EMR.Prescription.GetPrevGeneralPrescription(appId, patId);

                return Json(previous, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region General Prescription CRUD Operations
        [HttpGet]
        public PartialViewResult CreateGeneralPrescription(int? gpreId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    GeneralPrescription gen_presc = new GeneralPrescription();

                    if (gpreId == 0 || gpreId == null)
                    {
                        gen_presc = new GeneralPrescription();
                    }
                    else
                    {
                        gen_presc = BusinessLogicLayer.EMR.Prescription.GetAllGeneralPrescription(0, gpreId).FirstOrDefault();

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous Appointment General Prescription with gpreId = {gpreId}"
                        });
                    }

                    return PartialView("CreateGeneralPrescription", gen_presc);
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
        public ActionResult InsertGeneralPrescription(GeneralPrescription data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.gpre_madeby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    MNRAck ack = new MNRAck();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidGeneralPrescription(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.Prescription.InsertGeneralPrescription(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.gpre_madeby,
                                log_desc = $"Employee Created New General Prescription (Id) : {val}"
                            });

                            return Json(new { isAuthorized = true, isInserted = true, message = "General Prescription Created Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("gpre_desc", "General Prescription already exists!");
                            }

                            return Json(new { isAuthorized = true, isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, isInserted = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult EditGeneralPrescription(int appId, int gpreId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    GeneralPrescription edit_gen_presc = BusinessLogicLayer.EMR.Prescription.GetAllGeneralPrescription(appId, gpreId).FirstOrDefault();

                    return PartialView("EditGeneralPrescription", edit_gen_presc);
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
        public ActionResult UpdateGeneralPrescription(GeneralPrescription data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.gpre_modifiedby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.EMR.Prescription.isValidGeneralPrescription(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.Prescription.UpdateGeneralPrescription(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.gpre_madeby,
                                log_desc = $"Employee Updated General Prescription (Id) : {data.gpreId}"
                            });

                            return Json(new { isAuthorized = true, isUpdated = true, message = "General Prescription Updated Successfully" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("gpre_desc", "General Prescription already exists!");
                            }

                            return Json(new { isAuthorized = true, isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, isUpdated = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DeleteGeneralPrescription(int gpreId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int gpre_modifiedby = PageControl.getLoggedinId();

                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    int val = BusinessLogicLayer.EMR.Prescription.DeleteGeneralPrescription(gpreId, gpre_modifiedby);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = gpre_modifiedby,
                            log_desc = $"Employee Deleted General Prescription with Id = {gpreId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "General Prescription Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete General Prescription!" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Insurance Prescription (Page Load)
        [HttpGet]
        public ActionResult PrescriptionInsurance()
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Insurance Prescription!"
                    });

                    return PartialView("PrescriptionInsurance");
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
        #endregion

        #region Insurance Prescription CRUD Operations
        [HttpGet]
        public PartialViewResult CreateInsurancePrescription(int? preId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Prescription ins_presc = new Prescription();

                    if (preId == 0)
                    {
                        ins_presc = new Prescription();
                    }
                    else
                    {
                        ins_presc = BusinessLogicLayer.EMR.Prescription.GetAllPrescription(0, preId, "Insurance").FirstOrDefault();

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous Patient HPI with Id = {preId}"
                        });
                    }

                    return PartialView("CreateInsurancePrescription", ins_presc);
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
        public PartialViewResult EditInsurancePrescription(int appId, int preId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Prescription editins_presc = BusinessLogicLayer.EMR.Prescription.GetAllPrescription(appId, preId, "Insurance").FirstOrDefault();

                    return PartialView("EditInsurancePrescription", editins_presc);
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

        #region Generate eRX (DHA/MOH)
        [HttpPost]
        public ActionResult Generate_DHAerx(int appId, string preIds)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    DataTable dt = new DataTable();

                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;

                    DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(appId);

                    dt = ds.Tables[0];

                    DataTable dt_signs = ds.Tables[1];

                    if (dt_signs.Rows.Count > 0)
                    {
                        string file_name = "";

                        string sb = BusinessLogicLayer.EMR.Prescription.GenerateTemplate(dt, dt_signs, preIds, madeby);

                        int day = DateTime.Now.Day;
                        int month = DateTime.Now.Month;
                        int hour = DateTime.Now.Hour;
                        int minute = DateTime.Now.Minute;
                        int second = DateTime.Now.Second;
                        string day_value = string.Empty;
                        string month_value = string.Empty;
                        string hour_value = string.Empty;
                        string minute_value = string.Empty;
                        string second_value = string.Empty;

                        if (day < 10)
                        {
                            day_value = "0" + day.ToString();
                        }
                        else
                        {
                            day_value = day.ToString();
                        }
                        if (month < 10)
                        {
                            month_value = "0" + month.ToString();
                        }
                        else
                        {
                            month_value = month.ToString();
                        }

                        if (hour < 10)
                        {
                            hour_value = "0" + hour.ToString();
                        }
                        else
                        {
                            hour_value = hour.ToString();
                        }

                        if (minute < 10)
                        {
                            minute_value = "0" + minute.ToString();
                        }
                        else
                        {
                            minute_value = minute.ToString();
                        }

                        if (second < 10)
                        {
                            second_value = "0" + second.ToString();
                        }
                        else
                        {
                            second_value = second.ToString();
                        }

                        string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;
                        file_name = dt.Rows[0]["set_permit_no"].ToString() + "-" + dt.Rows[0]["ic_code"].ToString() + "-" + Tr__date2 + ".xml";

                        ae.eclaimlink.dhpo.eRxValidateTransaction e_rx = new ae.eclaimlink.dhpo.eRxValidateTransaction();

                        int eRx_ReferenceNo = 0;

                        string eRx_ErrorMessage = string.Empty;

                        byte[] eRx_ErrorReport = new byte[99];

                        int er_x = e_rx.UploadERxRequest(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), dt.Rows[0]["emp_dha_login"].ToString(), dt.Rows[0]["emp_dha_pass"].ToString(), Encoding.UTF8.GetBytes(sb), file_name, out eRx_ReferenceNo, out eRx_ErrorMessage, out eRx_ErrorReport);

                        if (er_x == 0)
                        {
                            TempData["ErrorMessage"] = eRx_ErrorMessage;

                            val = BusinessLogicLayer.EMR.Prescription.Generate_eRX(appId, file_name, eRx_ReferenceNo.ToString(), eRx_ErrorMessage, preIds, madeby, Tr__date2);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = madeby,
                                log_desc = "Employee Generated ERX Prescription For preId = " + preIds
                            });

                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                            Response.AppendHeader("Content-Length", sb.Length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(sb);
                            Response.End();
                            Response.Flush();
                        }
                        else
                        {
                            if (eRx_ErrorReport != null)
                            {
                                Response.AppendHeader("Content-Disposition", "attachment; filename=ERX_ERROR_REPORT.xls");
                                Response.AppendHeader("Content-Length", System.Text.Encoding.UTF8.GetString(eRx_ErrorReport).Length.ToString());
                                Response.ContentType = "text/xls";
                                Response.Write(System.Text.Encoding.UTF8.GetString(eRx_ErrorReport));
                                Response.End();

                                TempData["ErrorMessage"] = eRx_ErrorMessage;
                            }
                            else
                            {
                                TempData["ErrorMessage"] = eRx_ErrorMessage;
                            }

                            return Json(new { isSuccess = false, message = eRx_ErrorMessage }, JsonRequestBehavior.AllowGet);
                        }

                        if (val > 0)
                        {

                            return Json(new { isSuccess = true, message = "eRX Prescription Generated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Error while Generating eRX!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Vital Sign - Weight is Not Added for The Appointment" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Generate_MOHerx(int appId, string preIds)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt = new DataTable();

                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;

                    DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(appId);

                    dt = ds.Tables[0];

                    DataTable dt_signs = ds.Tables[1];

                    if (dt_signs.Rows.Count > 0)
                    {
                        string file_name = string.Empty;

                        ERX_Request erx = BusinessLogicLayer.EMR.Prescription.GenerateMOHerx(dt, dt_signs, preIds, madeby);

                        int day = DateTime.Now.Day;
                        int month = DateTime.Now.Month;
                        int hour = DateTime.Now.Hour;
                        int minute = DateTime.Now.Minute;
                        int second = DateTime.Now.Second;
                        string day_value = string.Empty;
                        string month_value = string.Empty;
                        string hour_value = string.Empty;
                        string minute_value = string.Empty;
                        string second_value = string.Empty;
                        string emp__license = string.Empty;
                        string Route_of_Admin = string.Empty;

                        string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString().Trim();
                        string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString().Trim();
                        string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString().Trim();

                        if (day < 10)
                        {
                            day_value = "0" + day.ToString();
                        }
                        else
                        {
                            day_value = day.ToString();
                        }
                        if (month < 10)
                        {
                            month_value = "0" + month.ToString();
                        }
                        else
                        {
                            month_value = month.ToString();
                        }

                        if (hour < 10)
                        {
                            hour_value = "0" + hour.ToString();
                        }
                        else
                        {
                            hour_value = hour.ToString();
                        }

                        if (minute < 10)
                        {
                            minute_value = "0" + minute.ToString();
                        }
                        else
                        {
                            minute_value = minute.ToString();
                        }

                        if (second < 10)
                        {
                            second_value = "0" + second.ToString();
                        }
                        else
                        {
                            second_value = second.ToString();
                        }

                        string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;
                        file_name = dt.Rows[0]["set_permit_no"].ToString() + "-" + dt.Rows[0]["ic_code"].ToString() + "-" + Tr__date2 + ".json";

                        string myDeserializedClass = Newtonsoft.Json.JsonConvert.SerializeObject(erx);

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        var options = new RestClientOptions(strApiUrl)
                        {
                            MaxTimeout = -1,
                        };

                        var client = new RestClient(options);
                        var request = new RestRequest("/ERX/PostRequest", Method.Post);

                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("username", strUsername);
                        request.AddHeader("password", strPassword);

                        request.AddStringBody(myDeserializedClass, DataFormat.Json);

                        RestResponse response = await client.ExecuteAsync(request);

                        ERX_Response result = Newtonsoft.Json.JsonConvert.DeserializeObject<ERX_Response>(response.Content);

                        if (result.StatusCode == "201" || result.StatusCode == "201")
                        {
                            TempData["ErrorMessage"] = result.ReferenceNumber;
                            TempData["ErrorMessage"] = result.UserMessage;

                            val = BusinessLogicLayer.EMR.Prescription.Generate_eRX(appId, file_name, result.ReferenceNumber, result.UserMessage, preIds, madeby, Tr__date2);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = madeby,
                                log_desc = "Employee Generated eRX For preId = " + preIds
                            });
                        }
                        else
                        {
                            return Json(new { isSuccess = false, api = -1, message = result.Error.ToArray() }, JsonRequestBehavior.AllowGet);
                        }

                        if (val > 0)
                        {
                            return Json(new { isSuccess = true, api = 1, message = "eRX Generated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, api = -2, message = "Failed to Generate eRX!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, api = -3, message = "Vital Signs (Weight Param) is Not Added for The Appointment!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, api = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region erX Cancellation (DHA/MOH)
        [HttpPost]
        public ActionResult Cancel_DHAerx(int appId, string preIds)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt = new DataTable();

                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;

                    DataSet ds = BusinessLogicLayer.EMR.Prescription.GetPatientEMRInfoPresc(appId, preIds);

                    dt = ds.Tables[0];

                    DataTable dt_signs = ds.Tables[1];

                    if (dt_signs.Rows.Count > 0)
                    {
                        string file_name = string.Empty;

                        string sb = BusinessLogicLayer.EMR.Prescription.GenerateERXCancellationTemplate(dt, dt_signs, preIds, madeby);

                        int day = DateTime.Now.Day;
                        int month = DateTime.Now.Month;
                        int hour = DateTime.Now.Hour;
                        int minute = DateTime.Now.Minute;
                        int second = DateTime.Now.Second;
                        string day_value = string.Empty;
                        string month_value = string.Empty;
                        string hour_value = string.Empty;
                        string minute_value = string.Empty;
                        string second_value = string.Empty;

                        if (day < 10)
                        {
                            day_value = "0" + day.ToString();
                        }
                        else
                        {
                            day_value = day.ToString();
                        }
                        if (month < 10)
                        {
                            month_value = "0" + month.ToString();
                        }
                        else
                        {
                            month_value = month.ToString();
                        }

                        if (hour < 10)
                        {
                            hour_value = "0" + hour.ToString();
                        }
                        else
                        {
                            hour_value = hour.ToString();
                        }

                        if (minute < 10)
                        {
                            minute_value = "0" + minute.ToString();
                        }
                        else
                        {
                            minute_value = minute.ToString();
                        }

                        if (second < 10)
                        {
                            second_value = "0" + second.ToString();
                        }
                        else
                        {
                            second_value = second.ToString();
                        }

                        string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;
                        file_name = dt.Rows[0]["set_permit_no"].ToString() + "-" + dt.Rows[0]["ic_code"].ToString() + "-" + Tr__date2 + ".xml";

                        ae.eclaimlink.dhpo.eRxValidateTransaction e_rx = new ae.eclaimlink.dhpo.eRxValidateTransaction();

                        int eRx_ReferenceNo = 0;

                        string eRx_ErrorMessage = string.Empty;

                        byte[] eRx_ErrorReport = new byte[99];

                        int er_x = e_rx.UploadERxRequest(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), dt.Rows[0]["emp_dha_login"].ToString(), dt.Rows[0]["emp_dha_pass"].ToString(), Encoding.UTF8.GetBytes(sb), file_name, out eRx_ReferenceNo, out eRx_ErrorMessage, out eRx_ErrorReport);

                        if (er_x == 0)
                        {
                            TempData["ErrorMessage"] = eRx_ErrorMessage;

                            val = BusinessLogicLayer.EMR.Prescription.Generate_Cancel_eRX(appId, file_name, eRx_ReferenceNo.ToString(), eRx_ErrorMessage, preIds, madeby, Tr__date2);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = madeby,
                                log_desc = "Employee Cancelled ERX Prescription For preId = " + preIds
                            });

                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                            Response.AppendHeader("Content-Length", sb.Length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(sb);
                            Response.End();
                            Response.Flush();
                        }
                        else
                        {
                            if (eRx_ErrorReport != null)
                            {
                                Response.AppendHeader("Content-Disposition", "attachment; filename=ERX_ERROR_REPORT.xls");
                                Response.AppendHeader("Content-Length", System.Text.Encoding.UTF8.GetString(eRx_ErrorReport).Length.ToString());
                                Response.ContentType = "text/xls";
                                Response.Write(System.Text.Encoding.UTF8.GetString(eRx_ErrorReport));
                                Response.End();

                                TempData["ErrorMessage"] = eRx_ErrorMessage;
                            }
                            else
                            {
                                TempData["ErrorMessage"] = eRx_ErrorMessage;
                            }

                            return Json(new { isSuccess = false, message = eRx_ErrorMessage }, JsonRequestBehavior.AllowGet);
                        }

                        if (val > 0)
                        {

                            return Json(new { isSuccess = true, message = "eRX Prescription Cancelled Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Error while Cancelling eRX!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Vital Sign - Weight is Not Added for The Appointment" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Cancel_MOHerx(int appId, string preIds)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt = new DataTable();

                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int madeby = PageControl.getLoggedinId();
                    int val = 0;

                    DataSet ds = BusinessLogicLayer.EMR.Prescription.GetPatientEMRInfoPresc(appId, preIds);

                    dt = ds.Tables[0];

                    DataTable dt_signs = ds.Tables[1];

                    if (dt_signs.Rows.Count > 0)
                    {
                        string file_name = string.Empty;

                        ERX_Request erx = BusinessLogicLayer.EMR.Prescription.GenerateMOHERXCancellation(dt, dt_signs, preIds, madeby);

                        int day = DateTime.Now.Day;
                        int month = DateTime.Now.Month;
                        int hour = DateTime.Now.Hour;
                        int minute = DateTime.Now.Minute;
                        int second = DateTime.Now.Second;
                        string day_value = string.Empty;
                        string month_value = string.Empty;
                        string hour_value = string.Empty;
                        string minute_value = string.Empty;
                        string second_value = string.Empty;
                        string emp__license = string.Empty;
                        string Route_of_Admin = string.Empty;

                        string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString().Trim();
                        string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString().Trim();
                        string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString().Trim();

                        if (day < 10)
                        {
                            day_value = "0" + day.ToString();
                        }
                        else
                        {
                            day_value = day.ToString();
                        }
                        if (month < 10)
                        {
                            month_value = "0" + month.ToString();
                        }
                        else
                        {
                            month_value = month.ToString();
                        }

                        if (hour < 10)
                        {
                            hour_value = "0" + hour.ToString();
                        }
                        else
                        {
                            hour_value = hour.ToString();
                        }

                        if (minute < 10)
                        {
                            minute_value = "0" + minute.ToString();
                        }
                        else
                        {
                            minute_value = minute.ToString();
                        }

                        if (second < 10)
                        {
                            second_value = "0" + second.ToString();
                        }
                        else
                        {
                            second_value = second.ToString();
                        }

                        string Tr__date2 = DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).Year + month_value + day_value + hour_value + minute_value + second_value;
                        file_name = dt.Rows[0]["set_permit_no"].ToString() + "-" + dt.Rows[0]["ic_code"].ToString() + "-" + Tr__date2 + ".json";

                        string myDeserializedClass = Newtonsoft.Json.JsonConvert.SerializeObject(erx);

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        var options = new RestClientOptions(strApiUrl)
                        {
                            MaxTimeout = -1,
                        };

                        var client = new RestClient(options);
                        var request = new RestRequest("/ERX/PostRequest", Method.Post);

                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("username", strUsername);
                        request.AddHeader("password", strPassword);

                        request.AddStringBody(myDeserializedClass, DataFormat.Json);

                        RestResponse response = await client.ExecuteAsync(request);

                        ERX_Response result = Newtonsoft.Json.JsonConvert.DeserializeObject<ERX_Response>(response.Content);

                        if (result.StatusCode == "201" || result.StatusCode == "201")
                        {
                            TempData["ErrorMessage"] = result.ReferenceNumber;
                            TempData["ErrorMessage"] = result.UserMessage;

                            val = BusinessLogicLayer.EMR.Prescription.Generate_Cancel_eRX(appId, file_name, result.ReferenceNumber, result.UserMessage, preIds, madeby, Tr__date2);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = madeby,
                                log_desc = "Employee Cancelled eRX For preId = " + preIds
                            });
                        }
                        else
                        {
                            return Json(new { isSuccess = false, api = -1, message = result.Error.ToArray() }, JsonRequestBehavior.AllowGet);
                        }

                        if (val > 0)
                        {
                            return Json(new { isSuccess = true, api = 1, message = "eRX Cancelled Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, api = -2, message = "Failed to Cancel eRX!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, api = -3, message = "Vital Signs (Weight Param) is Not Added for The Appointment!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, api = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region ERX Submissions (Page Load)
        [HttpGet]
        public ActionResult eRXSubmissions()
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Prescription ERX Page!"
                    });
                    return View("eRXSubmissions");
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        [HttpGet]
        public JsonResult GeterxSubmissions(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<erxSubmissions> erx = BusinessLogicLayer.EMR.Prescription.GeterxSubmissions(appId);

                return Json(erx, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
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