using BusinessEntities;
using BusinessEntities.Appointment;
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
    public class VaccinationController : Controller
    {
        int PageId = (int)Pages.PatientVaccination;
        #region  Patient Vaccination (Page Load)
        // GET: EMR/Patient Vaccination
        public ActionResult Vaccination()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Patient Vaccination Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        public JsonResult GetAllVaccination(int appId, int? pvId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Vaccination> Vaccination = BusinessLogicLayer.EMR.Vaccination.GetAllVaccination(appId, pvId);

                return Json(Vaccination, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/Vaccination

        public JsonResult GetAllPreVaccination(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Vaccination> notes = BusinessLogicLayer.EMR.Vaccination.GetAllPreVaccination(appId, patId);

                return Json(notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //GET:Complaints Master

        public ActionResult GetVaccine(string query, string flag)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<GetByName> notes = BusinessLogicLayer.EMR.Vaccination.GetVaccine(query, flag);
                    var jsonResult = Json(notes, JsonRequestBehavior.AllowGet);
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
        #endregion  Patient Vaccination (Page Load)

        #region Patient Vaccination  CRUD Operations
        // Create: Vaccination
        public PartialViewResult CreateVaccination()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    Vaccination notes = new Vaccination();
                    return PartialView("CreateVaccination", notes);
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
        public ActionResult InsertVaccination(Vaccination data)
        {
            try
            {
                bool isInserted = false;
                data.pv_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Vaccination.isValidVaccination(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.Vaccination.InsertUpdateVaccination(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pv_madeby,
                                log_desc = $"Employee Created New Vaccination (Id) : {data.pvId}"
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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

        //EDIT :Cheif Vaccination
        public PartialViewResult EditVaccination(int appId, int pvId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<Vaccination> Vaccination = BusinessLogicLayer.EMR.Vaccination.GetAllVaccination(appId, pvId);
                    return PartialView("EditVaccination", Vaccination.FirstOrDefault());
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
        public ActionResult UpdateVaccination(Vaccination data)
        {
            try
            {
                bool isUpdated = false;
                data.pv_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Vaccination.isValidVaccination(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.EMR.Vaccination.InsertUpdateVaccination(data);
                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pv_madeby,
                                log_desc = $"Employee Created New Vaccination (Id) : {data.pvId}"
                            });
                            return Json(new { isUpdated = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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
        //DELETE :Vaccination

        [HttpPost]
        public ActionResult DeleteVaccination(int pvId)
        {
            try
            {
                int pv_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.Vaccination.DeleteVaccination(pvId, pv_madeby);
                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = pv_madeby,
                            log_desc = $"Employee Deleted Vaccination for (Id) : {pvId}"
                        });
                        return Json(new { success = true, isAuthorized = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
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

        #endregion Patient Vaccination  CRUD Operations


        #region  Patient Vaccination Record (Page Load)
        // GET: EMR/Patient Vaccination Record
        public ActionResult VaccinationRecord()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Patient Vaccination Record Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        public JsonResult GetAllVaccinationRecord(int patId, int? vac_recId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<VaccinationRecord> Vaccination = BusinessLogicLayer.EMR.Vaccination.GetAllVaccinationRecord(patId, vac_recId);

                return Json(Vaccination, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Patient Vaccination Record (Page Load)

        #region Patient Vaccination Record  CRUD Operations
        // Create: Vaccination
        public PartialViewResult CreateVaccinationRecord()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    VaccinationRecord vacrecord = new VaccinationRecord();
                    return PartialView("CreateVaccinationRecord", vacrecord);
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
        public ActionResult InsertVaccinationRecord(VaccinationRecord data)
        {
            try
            {
                bool isInserted = false;
                data.vac_rec_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                      isInserted = BusinessLogicLayer.EMR.Vaccination.InsertUpdateVaccinationRecord(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.vac_rec_madeby,
                                log_desc = $"Employee Created New Vaccination with patient (Id) : {data.vac_rec_patId}"
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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

        //EDIT :Cheif Vaccination
        public PartialViewResult EditVaccinationRecord(int ? patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<VaccinationRecord> Vaccination = BusinessLogicLayer.EMR.Vaccination.GetAllVaccinationRecord(patId, 0);
                    return PartialView("EditVaccinationRecord", Vaccination.FirstOrDefault());
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
        public ActionResult UpdateVaccinationRecord(VaccinationRecord data)
        {
            try
            {
                bool isUpdated = false;
                data.vac_rec_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    
                    isUpdated = BusinessLogicLayer.EMR.Vaccination.InsertUpdateVaccinationRecord(data);
                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.vac_rec_madeby,
                            log_desc = $"Employee Updated Vaccination  with Patient (Id) : {data.vac_rec_patId}"
                        });
                        return Json(new { isUpdated = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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
        //DELETE :Vaccination

        [HttpPost]
        public ActionResult DeleteVaccinationRecord(int vac_recId)
        {
            try
            {
                int vac_rec_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.Vaccination.DeleteVaccinationRecord(vac_recId, vac_rec_madeby);
                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = vac_rec_madeby,
                            log_desc = $"Employee Deleted Vaccination Record for (Id) : {vac_recId}"
                        });
                        return Json(new { success = true, isAuthorized = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
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

        // Print: AudiologyNote
        [HttpGet]
        public ActionResult PrintVaccinationRecord(int vac_recId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    
                    VaccinationRecord print = BusinessLogicLayer.EMR.Vaccination.GetAllVaccinationRecord(0, vac_recId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Vaccination Record with Id = {vac_recId}"
                    });

                    return View("PrintVaccinationRecord", print);
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
        #endregion Patient Vaccination  CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}