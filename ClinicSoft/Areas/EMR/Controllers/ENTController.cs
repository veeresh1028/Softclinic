using BusinessEntities;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class ENTController : Controller
    {
        int PageId = (int)Pages.ENT;
        // GET: EMR/ENT

        #region  Audiology Note (Page Load)
        // GET: EMR/Audiology Note
        public ActionResult AudiologyNote()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Audiology Note Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllAudiologyNote(int? appId, int? audId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<AudiologyNote> request = BusinessLogicLayer.EMR.ENT.GetAllAudiologyNote(appId, audId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/AudiologyNote

        public JsonResult GetAllPreAudiologyNote(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<AudiologyNote> request = BusinessLogicLayer.EMR.ENT.GetAllPreAudiologyNote(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Audiology Note (Page Load)

        #region  Audiology Note CRUD Operations


        // Create: AudiologyNote
        public PartialViewResult CreateAudiologyNote()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateAudiologyNote");
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

        //INSERT: AudiologyNote
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertAudiologyNote(AudiologyNote data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.aud_madeby = PageControl.getLoggedinId();
                    
                        isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateAudiologyNote(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Audiology Note already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: AudiologyNote
        [HttpGet]
        public PartialViewResult EditAudiologyNote(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<AudiologyNote> extraoral = BusinessLogicLayer.EMR.ENT.GetAllAudiologyNote(appId, 0);

                    return PartialView("EditAudiologyNote", extraoral.FirstOrDefault());
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
        public ActionResult UpdateAudiologyNote(AudiologyNote data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.aud_madeby = PageControl.getLoggedinId();
                    
                        isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateAudiologyNote(data);

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
        // Print: AudiologyNote
        [HttpGet]
        public ActionResult PrintAudiologyNote(int audId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    AudiologyNote print = BusinessLogicLayer.EMR.ENT.GetAllAudiologyNote(0, audId).FirstOrDefault();
                     BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Audiology Note with audId = {audId}"
                    });

                    return View("PrintAudiologyNote", print);
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
        // Delete: AudiologyNote
        [HttpPost]
        public ActionResult DeleteAudiologyNote(int audId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int aud_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteAudiologyNote(audId, aud_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  Audiology Note CRUD Operations
        #region  Vestibular (Page Load)
        // GET: EMR/Vestibular
        public ActionResult Vestibular()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Vestibular Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllVestibular(int? appId, int? eeId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Vestibular> request = BusinessLogicLayer.EMR.ENT.GetAllVestibular(appId, eeId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/Vestibular

        public JsonResult GetAllPreVestibular(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Vestibular> request = BusinessLogicLayer.EMR.ENT.GetAllPreVestibular(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Vestibular (Page Load)

        #region  Vestibular CRUD Operations


        // Create: Vestibular
        public PartialViewResult CreateVestibular()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateVestibular");
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

        //INSERT: Vestibular
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertVestibular(Vestibular data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ee_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateVestibular(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Vestibular already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Vestibular
        [HttpGet]
        public PartialViewResult EditVestibular(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<Vestibular> extraoral = BusinessLogicLayer.EMR.ENT.GetAllVestibular(appId, 0);

                    return PartialView("EditVestibular", extraoral.FirstOrDefault());
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
        public ActionResult UpdateVestibular(Vestibular data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ee_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateVestibular(data);

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
        // Print: Vestibular
        [HttpGet]
        public ActionResult PrintVestibular(int eeId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Vestibular print = BusinessLogicLayer.EMR.ENT.GetAllVestibular(0, eeId).FirstOrDefault();
                     BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Vestibular with eeId = {eeId}"
                    });

                    return View("PrintVestibular", print);
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
        // Delete: Vestibular
        [HttpPost]
        public ActionResult DeleteVestibular(int eeId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ee_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteVestibular(eeId, ee_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  Vestibular CRUD Operations
        #region  Ear Microscopy Report (Page Load)
        // GET: EMR/Ear Microscopy Report
        public ActionResult EarMicroscopy()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Ear Microscopy Report Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllEarMicroscopy(int? appId, int? emrId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EarMicroscopy> request = BusinessLogicLayer.EMR.ENT.GetAllEarMicroscopy(appId, emrId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/EarMicroscopy

        public JsonResult GetAllPreEarMicroscopy(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EarMicroscopy> request = BusinessLogicLayer.EMR.ENT.GetAllPreEarMicroscopy(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Ear Microscopy Report (Page Load)

        #region  Ear Microscopy Report CRUD Operations


        // Create: EarMicroscopy
        public PartialViewResult CreateEarMicroscopy()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateEarMicroscopy");
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

        //INSERT: EarMicroscopy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertEarMicroscopy(EarMicroscopy data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.emr_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateEarMicroscopy(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Ear Microscopy Report already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: EarMicroscopy
        [HttpGet]
        public PartialViewResult EditEarMicroscopy(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<EarMicroscopy> extraoral = BusinessLogicLayer.EMR.ENT.GetAllEarMicroscopy(appId, 0);

                    return PartialView("EditEarMicroscopy", extraoral.FirstOrDefault());
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
        public ActionResult UpdateEarMicroscopy(EarMicroscopy data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.emr_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateEarMicroscopy(data);

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
        // Print: EarMicroscopy
        [HttpGet]
        public ActionResult PrintEarMicroscopy(int emrId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    EarMicroscopy print = BusinessLogicLayer.EMR.ENT.GetAllEarMicroscopy(0, emrId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Ear Microscopy Report with emrId = {emrId}"
                    });

                    return View("PrintEarMicroscopy", print);
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
        // Delete: EarMicroscopy
        [HttpPost]
        public ActionResult DeleteEarMicroscopy(int emrId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int emr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteEarMicroscopy(emrId, emr_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  Ear Microscopy Report CRUD Operations

        #region  Nasal Endoscopy Report (Page Load)
        // GET: EMR/Nasal Endoscopy Report
        public ActionResult NasalEndoscopy()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Nasal Endoscopy Report Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllNasalEndoscopy(int? appId, int? nerId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasalEndoscopy> request = BusinessLogicLayer.EMR.ENT.GetAllNasalEndoscopy(appId, nerId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/NasalEndoscopy

        public JsonResult GetAllPreNasalEndoscopy(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasalEndoscopy> request = BusinessLogicLayer.EMR.ENT.GetAllPreNasalEndoscopy(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Nasal Endoscopy Report (Page Load)

        #region  Nasal Endoscopy Report CRUD Operations


        // Create: NasalEndoscopy
        public PartialViewResult CreateNasalEndoscopy()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateNasalEndoscopy");
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

        //INSERT: NasalEndoscopy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNasalEndoscopy(NasalEndoscopy data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ner_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateNasalEndoscopy(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Nasal Endoscopy Report already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: NasalEndoscopy
        [HttpGet]
        public PartialViewResult EditNasalEndoscopy(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<NasalEndoscopy> extraoral = BusinessLogicLayer.EMR.ENT.GetAllNasalEndoscopy(appId, 0);

                    return PartialView("EditNasalEndoscopy", extraoral.FirstOrDefault());
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
        public ActionResult UpdateNasalEndoscopy(NasalEndoscopy data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ner_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateNasalEndoscopy(data);

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
        // Print: NasalEndoscopy
        [HttpGet]
        public ActionResult PrintNasalEndoscopy(int nerId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NasalEndoscopy print = BusinessLogicLayer.EMR.ENT.GetAllNasalEndoscopy(0, nerId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Nasal Endoscopy Report with nerId = {nerId}"
                    });

                    return View("PrintNasalEndoscopy", print);
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
        // Delete: NasalEndoscopy
        [HttpPost]
        public ActionResult DeleteNasalEndoscopy(int nerId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ner_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteNasalEndoscopy(nerId, ner_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  Nasal Endoscopy Report CRUD Operations
        #region  Fibroptic Laryngoscopy Report (Page Load)
        // GET: EMR/Fibroptic Laryngoscopy Report
        public ActionResult FibropticLaryngoscopy()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Fibroptic Laryngoscopy Report Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllFibropticLaryngoscopy(int? appId, int? flrId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<FibropticLaryngoscopy> request = BusinessLogicLayer.EMR.ENT.GetAllFibropticLaryngoscopy(appId, flrId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/FibropticLaryngoscopy

        public JsonResult GetAllPreFibropticLaryngoscopy(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<FibropticLaryngoscopy> request = BusinessLogicLayer.EMR.ENT.GetAllPreFibropticLaryngoscopy(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Fibroptic Laryngoscopy Report (Page Load)

        #region  Fibroptic Laryngoscopy Report CRUD Operations


        // Create: FibropticLaryngoscopy
        public PartialViewResult CreateFibropticLaryngoscopy()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateFibropticLaryngoscopy");
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

        //INSERT: FibropticLaryngoscopy
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertFibropticLaryngoscopy(FibropticLaryngoscopy data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.flr_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateFibropticLaryngoscopy(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Fibroptic Laryngoscopy Report already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: FibropticLaryngoscopy
        [HttpGet]
        public PartialViewResult EditFibropticLaryngoscopy(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<FibropticLaryngoscopy> Fibroptic = BusinessLogicLayer.EMR.ENT.GetAllFibropticLaryngoscopy(appId, 0);

                    return PartialView("EditFibropticLaryngoscopy", Fibroptic.FirstOrDefault());
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
        public ActionResult UpdateFibropticLaryngoscopy(FibropticLaryngoscopy data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.flr_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateFibropticLaryngoscopy(data);

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
        // Print: FibropticLaryngoscopy
        [HttpGet]
        public ActionResult PrintFibropticLaryngoscopy(int flrId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    FibropticLaryngoscopy print = BusinessLogicLayer.EMR.ENT.GetAllFibropticLaryngoscopy(0, flrId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Fibroptic Laryngoscopy Report with flrId = {flrId}"
                    });

                    return View("PrintFibropticLaryngoscopy", print);
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
        // Delete: FibropticLaryngoscopy
        [HttpPost]
        public ActionResult DeleteFibropticLaryngoscopy(int flrId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int flr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteFibropticLaryngoscopy(flrId, flr_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  Fibroptic Laryngoscopy Report CRUD Operations
        #region  ENT Examination Throat (Page Load)
        // GET: EMR/ENT Examination Throat
        public ActionResult ENTExamThroat()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed ENT Examination Throat Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllENTExamThroat(int? appId, int? etId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ENTExamThroat> request = BusinessLogicLayer.EMR.ENT.GetAllENTExamThroat(appId, etId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/ENTExamThroat

        public JsonResult GetAllPreENTExamThroat(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ENTExamThroat> request = BusinessLogicLayer.EMR.ENT.GetAllPreENTExamThroat(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  ENT Examination Throat (Page Load)

        #region  ENT Examination Throat CRUD Operations


        // Create: ENTExamThroat
        public PartialViewResult CreateENTExamThroat()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateENTExamThroat");
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

        //INSERT: ENTExamThroat
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertENTExamThroat(ENTExamThroat data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.et_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateENTExamThroat(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "ENT Examination Throat already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: ENTExamThroat
        [HttpGet]
        public PartialViewResult EditENTExamThroat(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<ENTExamThroat> throat = BusinessLogicLayer.EMR.ENT.GetAllENTExamThroat(appId, 0);

                    return PartialView("EditENTExamThroat", throat.FirstOrDefault());
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
        public ActionResult UpdateENTExamThroat(ENTExamThroat data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.et_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateENTExamThroat(data);

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
        // Print: ENTExamThroat
        [HttpGet]
        public ActionResult PrintENTExamThroat(int etId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    ENTExamThroat print = BusinessLogicLayer.EMR.ENT.GetAllENTExamThroat(0, etId).FirstOrDefault();
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed ENT Examination Throat with etId = {etId}"
                    });

                    return View("PrintENTExamThroat", print);
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
        // Delete: ENTExamThroat
        [HttpPost]
        public ActionResult DeleteENTExamThroat(int etId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int et_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteENTExamThroat(etId, et_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  ENT Examination Throat CRUD Operations

        #region  ENT Examination Nose (Page Load)
        // GET: EMR/ENT Examination Nose
        public ActionResult ENTExamNose()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed ENT Examination Nose Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllENTExamNose(int? appId, int? enId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ENTExamNose> request = BusinessLogicLayer.EMR.ENT.GetAllENTExamNose(appId, enId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/ENTExamNose

        public JsonResult GetAllPreENTExamNose(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ENTExamNose> request = BusinessLogicLayer.EMR.ENT.GetAllPreENTExamNose(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  ENT Examination Nose (Page Load)

        #region  ENT Examination Nose CRUD Operations


        // Create: ENTExamNose
        public PartialViewResult CreateENTExamNose()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateENTExamNose");
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

        //INSERT: ENTExamNose
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertENTExamNose(ENTExamNose data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.en_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateENTExamNose(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "ENT Examination Nose already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: ENTExamNose
        [HttpGet]
        public PartialViewResult EditENTExamNose(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<ENTExamNose> Nose = BusinessLogicLayer.EMR.ENT.GetAllENTExamNose(appId, 0);

                    return PartialView("EditENTExamNose", Nose.FirstOrDefault());
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
        public ActionResult UpdateENTExamNose(ENTExamNose data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.en_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.EMR.ENT.InsertUpdateENTExamNose(data);

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
        // Print: ENTExamNose
        [HttpGet]
        public ActionResult PrintENTExamNose(int enId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    ENTExamNose print = BusinessLogicLayer.EMR.ENT.GetAllENTExamNose(0, enId).FirstOrDefault();
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed ENT Examination Nose with enId = {enId}"
                    });

                    return View("PrintENTExamNose", print);
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
        // Delete: ENTExamNose
        [HttpPost]
        public ActionResult DeleteENTExamNose(int enId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int en_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ENT.DeleteENTExamNose(enId, en_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        #endregion  ENT Examination Nose CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}