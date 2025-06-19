using BusinessEntities;
using BusinessEntities.EMR;
using BusinessEntities.KPIReports;
using BusinessEntities.NurseStation;
using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.MNR;
using System.Data;
using System.Threading.Tasks;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class QuickEMRController : Controller
    {
        // GET: EMR/QuickEMR
        int PageId_AuditLogs = (int)Pages.AuditLogs;
        int PageId_MedicalSheet = (int)Pages.MedicalSheet;
        int PageId_QuickEMR = (int)Pages.QuickEMR;
        public ActionResult QuickEMR()
        {

            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_QuickEMR, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Quick EMR Page!"
                });
                TempData["Layout"] = "True";
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        // GET: EMR/PrintMedicalSheet
        public ActionResult PrintMedicalSheet()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_MedicalSheet, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Print Medical Sheet Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        #region Audit Logs (Page Load)
        // GET: EMR/AuditLog      
        public PartialViewResult AuditLog()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId_AuditLogs, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Audit Log Sheet Page!"
                    });

                    return PartialView("AuditLog");
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
        public JsonResult VitalSignsAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<VitalSignsAuditLogsKPI> vital = BusinessLogicLayer.AuditLogs.AuditLogs.VitalSignsAudit(appId);

                return Json(vital, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AllergiesAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<AllergiesAuditLogsKPI> allergy = BusinessLogicLayer.AuditLogs.AuditLogs.AllergiesAudit(appId);

                return Json(allergy, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PastHistoryAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<PastHistoryAuditLogs> history = BusinessLogicLayer.AuditLogs.AuditLogs.PastHistoryAudit(appId);

                return Json(history, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CheifComplaintsAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<CheifComplaintsAuditLogs> complaint = BusinessLogicLayer.AuditLogs.AuditLogs.CheifComplaintsAudit(appId);

                return Json(complaint, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult HPIAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<HPIAudit> hpi = BusinessLogicLayer.AuditLogs.AuditLogs.HPIAudit(appId);

                return Json(hpi, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ROSAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<ROSAudit> ros = BusinessLogicLayer.AuditLogs.AuditLogs.ROSAudit(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult NurseNotesAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<NurseNotesAudit> ros = BusinessLogicLayer.AuditLogs.AuditLogs.NurseNotesAudit(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult NarrativeDiagnosisAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<NarrativeDiagnosisAudit> ros = BusinessLogicLayer.AuditLogs.AuditLogs.NarrativeDiagnosisAudit(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PatDiagnosisAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<PatDiagnosisAudit> ros = BusinessLogicLayer.AuditLogs.AuditLogs.PatDiagnosisAudit(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult AddendumAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<AddendumAudit> ros = BusinessLogicLayer.AuditLogs.AuditLogs.AddendumAudit(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ProgressNotesAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<ProgressNotesAudit> ros = BusinessLogicLayer.AuditLogs.AuditLogs.ProgressNotesAudit(appId);

                return Json(ros, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult PatientTreatemntsAudit(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_AuditLogs, Action))
            {
                List<PatientTreatmentAudit> treatment = BusinessLogicLayer.AuditLogs.AuditLogs.PatientTreatemntsAudit(appId);

                return Json(treatment, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Audit Logs (Page Load)
        #region Signed Documents (Page Load)
        // GET: EMR/SignedDocuments
        public ActionResult SignedDocuments()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId_MedicalSheet, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Signed Documents Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        public JsonResult GetAllSignedDocuments(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_MedicalSheet, Action))
            {
                List<SignedDocuments> SignedDocuments = BusinessLogicLayer.EMR.QuickEMR.GetAllSignedDocuments(appId);

                return Json(SignedDocuments, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/SignedDocuments

        public JsonResult GetAllPreSignedDocuments(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_MedicalSheet, Action))
            {
                List<SignedDocuments> notes = BusinessLogicLayer.EMR.QuickEMR.GetAllPreSignedDocuments(appId, patId);

                return Json(notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Signed Documents (Page Load)
        #region Start End Time (Page Load)
        public JsonResult GetStartEndTime(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_MedicalSheet, Action))
            {
                List<StartEndTime> time = BusinessLogicLayer.EMR.QuickEMR.GetStartEndTime(appId);

                return Json(time, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //INSERT: StartEnd
        [HttpPost]
        public ActionResult InsertStartTime(StartEndTime data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId_MedicalSheet, Action))
                {


                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMR.QuickEMR.InsertUpdateStartEndTime(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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
        //INSERT: StartEnd
        [HttpPost]
        public ActionResult UpdateendTime(StartEndTime data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId_MedicalSheet, Action))
                {

                    StartEndTime time = new StartEndTime();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMR.QuickEMR.InsertUpdateStartEndTime(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Sick Leave already exists!" }, JsonRequestBehavior.AllowGet);
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
        [HttpGet]
        public ActionResult PrintPDFConsent(int appId, string form)
        {
            try
            {                
                int madeby = PageControl.getLoggedinId();

                //BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();

                //if (pdf != null)
                //{
                //    return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    PDF _pdf = CreatePDF(appId, form);
                //    return Json(new { success = true, isAuthorized = true, message = _pdf }, JsonRequestBehavior.AllowGet);
                //}
                //BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();
                PDF _pdf = CreatePDF(appId, form);
                BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();
                return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PDF CreatePDF(int appId, string form)
        {
            PDF _pdf = new PDF();

            try
            {
                int madeby = PageControl.getLoggedinId();
                string fileName = appId + "_" + form + ".pdf";
                string file_path = Server.MapPath("~/Documents/MedicalSheet");

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                }

                string path = Path.Combine(file_path, fileName);

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                int setId = int.Parse(emp_branch);
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlMedicalSheet(appId, emr, setId);
                var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);
                System.IO.File.WriteAllBytes(path, pdfBytes);



                if (System.IO.File.Exists(path))
                {
                    _pdf.pdfAppId = appId;
                    _pdf.pdfForm = form;
                    _pdf.pdfPath = path;
                    _pdf.pdfFileName = fileName;
                    _pdf.pdfUploadedBy = madeby;

                    bool isInserted = BusinessLogicLayer.Common.PDF.UploadDocument(_pdf);
                }

                return _pdf;
            }
            catch (Exception ex)
            {
                return _pdf;
            }
        }
        public JsonResult GetPatientTreatments(int appId)
        {   
            List<PatientTreatments> narrative = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatments(appId);
            return Json(narrative, JsonRequestBehavior.AllowGet);
        }
        #endregion Start End Time (Page Load)


        [HttpGet]
        public async Task<ActionResult> NabidhPDFConsent(int appId, string form)
        {
            try
            {
                int madeby = PageControl.getLoggedinId();
                PDF _pdf = CreateNabidhPDF(appId, form);
                string tittle = "Outpatient Encounter - Summary";
                BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();
                int val = BusinessLogicLayer.Common.PDF.CreateClinicalDocs(appId, tittle, _pdf.pdfPath, PageControl.getLoggedinId());
                if (val > 0)
                {
                    var value = appId;
                    DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(value);
                    DataTable dt = ds.Tables[0];
                    MNRAck ack = new MNRAck();
                    if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                    {
                        if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                        {
                            if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                            {
                                ack = await MNR.Nabidh.MDMT02(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate_time"].ToString(), value);
                            }
                            else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                            {
                                //ack = await MNR.Riayati.ORUR01_2(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);
                            }
                            else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                            {
                                //ack = await MNR.Malaffi.ORUR01_2(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = value,
                                    message = "Documents uploaded Successfully and message send to nabidh"
                                };


                            }
                            return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            ack = new MNRAck
                            {
                                value = value,
                                message = "Documents uploaded Successfully"
                            };
                            return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        ack = new MNRAck
                        {
                            value = value,
                            message = "Documents uploaded Successfully"
                        };
                        return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = -1 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public PDF CreateNabidhPDF(int appId, string form)
        {
            PDF _pdf = new PDF();

            try
            {
                int madeby = PageControl.getLoggedinId();
                string fileName = "Outpatient Encounter - Summary_" + appId + ".pdf"; //VisitID 
                string file_path = Server.MapPath("~/Documents/Clinical_Docs");

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                }

                string path = Path.Combine(file_path, fileName);

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                int setId = int.Parse(emp_branch);
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlMedicalSheet(appId, emr, setId);
                var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);
                System.IO.File.WriteAllBytes(path, pdfBytes);



                if (System.IO.File.Exists(path))
                {
                    _pdf.pdfAppId = appId;
                    _pdf.pdfForm = form;
                    _pdf.pdfPath = path;
                    _pdf.pdfFileName = fileName;
                    _pdf.pdfUploadedBy = madeby;

                    bool isInserted = BusinessLogicLayer.Common.PDF.UploadDocument(_pdf);
                }

                return _pdf;
            }
            catch (Exception ex)
            {
                return _pdf;
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;

            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}