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
    public class OralExaminationController : Controller
    {
        int PageId = (int)Pages.OralExamination;
        #region  Extra Oral Examination (Page Load)

        // GET: EMR/OralExamination
        public ActionResult ExtraOralExam()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Extra Oral Examination Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllExtraOralExam(int? appId,int ? ceoId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ExtraOralExam> pasthis = BusinessLogicLayer.EMR.OralExamination.GetAllExtraOralExam(appId, ceoId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/ExtraOralExam

        public JsonResult GetAllPreExtraOralExam(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ExtraOralExam> pasthis = BusinessLogicLayer.EMR.OralExamination.GetAllPreExtraOralExam(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion  Extra Oral Examination (Page Load)

        #region  Extra Oral Examination CRUD Operations


        // Create: ExtraOralExam
        public PartialViewResult CreateExtraOralExam(int? ceoId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    ExtraOralExam oralexam = new ExtraOralExam();
                    if (ceoId == 0)
                    {
                        oralexam = new ExtraOralExam();
                    }
                    else
                    {
                        oralexam = BusinessLogicLayer.EMR.OralExamination.GetAllExtraOralExam(0, ceoId).FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous ExtraOral Examination with Id = {ceoId}"
                        });
                    }
                    return PartialView("CreateExtraOralExam", oralexam);
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
        // INSERT: ExtraOralExam
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertExtraOralExam(ExtraOralExam data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ceo_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.OralExamination.isValidExtraOralExam(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OralExamination.InsertUpdateExtraOralExam(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "HPI already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: ExtraOralExam
        [HttpGet]
        public PartialViewResult EditExtraOralExam(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<ExtraOralExam> extraoral = BusinessLogicLayer.EMR.OralExamination.GetAllExtraOralExam(appId, 0);

                    return PartialView("EditExtraOralExam", extraoral.FirstOrDefault());
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
        public ActionResult UpdateExtraOralExam(ExtraOralExam data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ceo_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.OralExamination.isValidExtraOralExam(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OralExamination.InsertUpdateExtraOralExam(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Extra Oral already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: ExtraOralExam
        [HttpGet]
        public ActionResult PrintExtraOralExam(int ceoId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    ExtraOralExam print = BusinessLogicLayer.EMR.OralExamination.GetAllExtraOralExam(0, ceoId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed ExtraOral Examination with ceoId = {ceoId}"
                    });

                    return View("PrintExtraOralExam", print);
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
        // Delete: ExtraOralExam
        [HttpPost]
        public ActionResult DeleteExtraOralExam(int ceoId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ceo_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OralExamination.DeleteExtraOralExam(ceoId, ceo_madeby);

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

        #endregion  Extra Oral Examination CRUD Operations

        #region  IntraOral SoftTissue (Page Load)

        // GET: EMR/IntraOralSoftTissue
        public ActionResult IntraOralSoftTissue()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed IntraOral SoftTissue Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllIntraOralSoftTissue(int? appId, int? cstId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<IntraOralSoftTissue> softtissue = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralSoftTissue(appId, cstId);

                return Json(softtissue, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/IntraOralSoftTissue

        public JsonResult GetAllPreIntraOralSoftTissue(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<IntraOralSoftTissue> softtissue = BusinessLogicLayer.EMR.OralExamination.GetAllPreIntraOralSoftTissue(appId, patId);

                return Json(softtissue, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        #endregion  IntraOral SoftTissue (Page Load)

        #region  IntraOral SoftTissue CRUD Operations

        // Create: IntraOralSoftTissue
        public PartialViewResult CreateIntraOralSoftTissue(int? cstId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    IntraOralSoftTissue softtissue = new IntraOralSoftTissue();
                    if (cstId == 0)
                    {
                        softtissue = new IntraOralSoftTissue();
                    }
                    else
                    {
                        softtissue = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralSoftTissue(0, cstId).FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous IntraOral SoftTissue with Id = {cstId}"
                        });
                    }
                    return PartialView("CreateIntraOralSoftTissue", softtissue);
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
        // INSERT: IntraOralSoftTissue
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertIntraOralSoftTissue(IntraOralSoftTissue data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cst_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.OralExamination.isValidIntraOralSoftTissue(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OralExamination.InsertUpdateIntraOralSoftTissue(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "IntraOral SoftTissue already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: IntraOralSoftTissue
        [HttpGet]
        public PartialViewResult EditIntraOralSoftTissue(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<IntraOralSoftTissue> softtissue = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralSoftTissue(appId, 0);

                    return PartialView("EditIntraOralSoftTissue", softtissue.FirstOrDefault());
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
        public ActionResult UpdateIntraOralSoftTissue(IntraOralSoftTissue data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cst_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.OralExamination.isValidIntraOralSoftTissue(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OralExamination.InsertUpdateIntraOralSoftTissue(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "IntraOral SoftTissue already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: IntraOralSoftTissue
        [HttpGet]
        public ActionResult PrintIntraOralSoftTissue(int cstId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    IntraOralSoftTissue print = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralSoftTissue(0, cstId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed IntraOral SoftTissue with cstId = {cstId}"
                    });

                    return View("PrintIntraOralSoftTissue", print);
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
        // Delete: IntraOralSoftTissue
        [HttpPost]
        public ActionResult DeleteIntraOralSoftTissue(int cstId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cst_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OralExamination.DeleteIntraOralSoftTissue(cstId, cst_madeby);

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

        #endregion  IntraOral SoftTissue CRUD Operations

        #region  IntraOral HardTissue (Page Load)

        // GET: EMR/IntraOralHardTissue
        public ActionResult IntraOralHardTissue()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed IntraOral HardTissue Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllIntraOralHardTissue(int? appId, int? chtId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<IntraOralHardTissue> pasthis = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralHardTissue(appId, chtId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/IntraOralHardTissue

        public JsonResult GetAllPreIntraOralHardTissue(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<IntraOralHardTissue> pasthis = BusinessLogicLayer.EMR.OralExamination.GetAllPreIntraOralHardTissue(appId, patId);

                return Json(pasthis, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //GET:Tooth Surface

        public ActionResult GetToothSurface(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> surface = BusinessLogicLayer.EMR.OralExamination.GetToothSurface(query);
                    var jsonResult = Json(surface, JsonRequestBehavior.AllowGet);
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
        #endregion  IntraOral HardTissue (Page Load)

        #region  IntraOral HardTissue CRUD Operations

        // Create: IntraOralHardTissue
        public PartialViewResult CreateIntraOralHardTissue(int? chtId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    IntraOralHardTissue HardTissue = new IntraOralHardTissue();
                    if (chtId == 0)
                    {
                        HardTissue = new IntraOralHardTissue();
                    }
                    else
                    {
                        HardTissue = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralHardTissue(0, chtId).FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous IntraOral HardTissue with Id = {chtId}"
                        });
                    }
                    return PartialView("CreateIntraOralHardTissue", HardTissue);
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
        // INSERT: IntraOralHardTissue
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertIntraOralHardTissue(HardTissue data)
        {
            int  val = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.OralExamination.isValidIntraOralHardTissue(data, out errors))
                    {
                        val = BusinessLogicLayer.EMR.OralExamination.InsertUpdateIntraOralHardTissue(data, PageControl.getLoggedinId());

                        if (val>0)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "IntraOral HardTissue already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: IntraOralHardTissue
        [HttpGet]
        public PartialViewResult EditIntraOralHardTissue(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    HardTissue HardTissue = BusinessLogicLayer.EMR.OralExamination.GetIntraOralHardTissue(appId, 0);
                    return PartialView("EditIntraOralHardTissue", HardTissue);
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
        public ActionResult UpdateIntraOralHardTissue(HardTissue data)
        {
            try
            {
                int val = 0;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.OralExamination.isValidIntraOralHardTissue(data, out errors))
                    {
                        val = BusinessLogicLayer.EMR.OralExamination.InsertUpdateIntraOralHardTissue(data, PageControl.getLoggedinId());

                        if (val>0)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "IntraOral HardTissue already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: IntraOralHardTissue
        [HttpGet]
        public ActionResult PrintIntraOralHardTissue(int chtId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    IntraOralHardTissue print = BusinessLogicLayer.EMR.OralExamination.GetAllIntraOralHardTissue(0, chtId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed IntraOral HardTissue with chtId = {chtId}"
                    });

                    return View("PrintIntraOralHardTissue", print);
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
        // Delete: IntraOralHardTissue
        [HttpPost]
        public ActionResult DeleteIntraOralHardTissue(int chtId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cht_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OralExamination.DeleteIntraOralHardTissue(chtId, cht_madeby);

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

        [HttpPost]
        public ActionResult DeleteHardTissueTooth(string data)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<int> chtdIds = new List<int>();
                    string[] arr = data.Split(',');
                    foreach (string str in arr)
                    {
                        chtdIds.Add(int.Parse(str));
                    }

                    int val = BusinessLogicLayer.EMR.OralExamination.DeleteHardTissueTooth(chtdIds, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Hard Tissue Tooth for chtdIds = {chtdIds}"
                        });

                        return Json(new { isSuccess = true, invId = val }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0 }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = -1 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion  IntraOral HardTissue CRUD Operations

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}