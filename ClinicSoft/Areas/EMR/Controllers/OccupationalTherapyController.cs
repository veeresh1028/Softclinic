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
    public class OccupationalTherapyController : Controller
    {
        int PageId = (int)Pages.OccupationalTherapy;

        #region  Approval Revision Request (Page Load)
        // GET: EMR/Approval Revision Request
        public ActionResult ApprovalRevisionRequest()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Approval Revision Request Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllApprovalRevisionRequest(int? appId, int? jlId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RevisionRequest> request = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllApprovalRevisionRequest(appId, jlId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/RevisionRequest

        public JsonResult GetAllPreApprovalRevisionRequest(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<RevisionRequest> request = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllPreApprovalRevisionRequest(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Approval Revision Request (Page Load)

        #region  Approval Revision Request CRUD Operations


        // Create: ApprovalRevisionRequest
        public PartialViewResult CreateApprovalRevisionRequest()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateApprovalRevisionRequest");
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

        //INSERT: ApprovalRevisionRequest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertApprovalRevisionRequest(RevisionRequest data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.carr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidRevisionRequest(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateApprovalRevisionRequest(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Approval Revision Request already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: RevisionRequest
        [HttpGet]
        public PartialViewResult EditApprovalRevisionRequest(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<RevisionRequest> extraoral = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllApprovalRevisionRequest(appId, 0);

                    return PartialView("EditApprovalRevisionRequest", extraoral.FirstOrDefault());
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
        public ActionResult UpdateApprovalRevisionRequest(RevisionRequest data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.carr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidRevisionRequest(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateApprovalRevisionRequest(data);

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
        // Print: RevisionRequest
        [HttpGet]
        public ActionResult PrintApprovalRevisionRequest(int carr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    RevisionRequest print = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllApprovalRevisionRequest(0, carr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Approval Revision Request with carr_Id = {carr_Id}"
                    });

                    return View("PrintApprovalRevisionRequest", print);
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
        // Delete: RevisionRequest
        [HttpPost]
        public ActionResult DeleteApprovalRevisionRequest(int carr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int carr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OccupationalTherapy.DeleteApprovalRevisionRequest(carr_Id, carr_madeby);

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
        #endregion  Approval Revision Request CRUD Operations

        #region  FIM Instrument (Page Load)
        // GET: EMR/FIMInstrument
        public ActionResult FIMInstrument()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Functional Independence Measure (FIM) Instrument Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAllFIMInstrument(int? appId, int? cfim_Id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<FIMInstrument> fimi = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllFIMInstrument(appId, cfim_Id);

                return Json(fimi, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/FIMInstrument

        public JsonResult GetAllPreFIMInstrument(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<FIMInstrument> fimi = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllPreFIMInstrument(appId, patId);

                return Json(fimi, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion FIM Instrument (Page Load)

        #region  FIM Instrument CRUD Operations


        // Create: FIMInstrument
        public PartialViewResult CreateFIMInstrument()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    FIMInstrument FIM = new FIMInstrument();

                    return PartialView("CreateFIMInstrument", FIM);
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
        //INSERT: FIMInstrument
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertFIMInstrument(FIMInstrument data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cfim_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidFIMInstrument(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateFIMInstrument(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Approval Revision Request already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: FIMInstrument
        [HttpGet]
        public PartialViewResult EditFIMInstrument(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<FIMInstrument> extraoral = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllFIMInstrument(appId, 0);

                    return PartialView("EditFIMInstrument", extraoral.FirstOrDefault());
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
        public ActionResult UpdateFIMInstrument(FIMInstrument data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cfim_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidFIMInstrument(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateFIMInstrument(data);

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
        // Print: FIMInstrument
        [HttpGet]
        public ActionResult PrintFIMInstrument(int cfim_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    FIMInstrument print = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllFIMInstrument(0, cfim_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed FIM Instrument with cfim_Id = {cfim_Id}"
                    });

                    return View("PrintFIMInstrument", print);
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
        // Delete: FIMInstrument
        [HttpPost]
        public ActionResult DeleteFIMInstrument(int cfim_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cfim_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OccupationalTherapy.DeleteFIMInstrument(cfim_Id, cfim_madeby);

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
        #endregion  FIM Instrument CRUD Operations

        #region  Monthly Evaluation  (Page Load)
        // GET: EMR/Monthly Evaluation 
        public ActionResult MonthlyEvaluation()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Monthly Evaluation Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        public JsonResult GetAllMonthlyEvaluation(int? appId, int? cme_Id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MonthlyEvaluation> request = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllMonthlyEvaluation(appId, cme_Id);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/Monthly Evaluation

        public JsonResult GetAllPreMonthlyEvaluation(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MonthlyEvaluation> request = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllPreMonthlyEvaluation(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Monthly Evaluation  (Page Load)

        #region  Monthly Evaluation CRUD Operations


        // Create: Monthly Evaluation
        public PartialViewResult CreateMonthlyEvaluation()
        {
            if (PageControl.getLoggedinId() > 0)
            {

                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    MonthlyEvaluation eval = new MonthlyEvaluation();

                    return PartialView("CreateMonthlyEvaluation", eval);
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

        //INSERT: MonthlyEvaluation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertMonthlyEvaluation(MonthlyEvaluation data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cme_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidMonthlyEvaluation(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateMonthlyEvaluation(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Monthly Evaluation already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: MonthlyEvaluation
        [HttpGet]
        public PartialViewResult EditMonthlyEvaluation(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<MonthlyEvaluation> extraoral = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllMonthlyEvaluation(appId, 0);

                    return PartialView("EditMonthlyEvaluation", extraoral.FirstOrDefault());
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
        public ActionResult UpdateMonthlyEvaluation(MonthlyEvaluation data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cme_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidMonthlyEvaluation(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateMonthlyEvaluation(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Monthly Evaluation already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: MonthlyEvaluation
        [HttpGet]
        public ActionResult PrintMonthlyEvaluation(int cme_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    MonthlyEvaluation print = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllMonthlyEvaluation(0, cme_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Monthly Evaluation with cme_Id = {cme_Id}"
                    });

                    return View("PrintMonthlyEvaluation", print);
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
        // Delete: MonthlyEvaluation
        [HttpPost]
        public ActionResult DeleteMonthlyEvaluation(int cme_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cme_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OccupationalTherapy.DeleteMonthlyEvaluation(cme_Id, cme_madeby);

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
        #endregion  Monthly Evaluation CRUD Operations

        #region  Initial Therapy Screening  (Page Load)
        // GET: EMR/Initial Therapy Screening 
        public ActionResult InitialTherapyScreening()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Initial Therapy Screening Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        public JsonResult GetAllInitialTherapyScreening(int? appId, int? cot_Id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<InitialTherapyScreening> request = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllInitialTherapyScreening(appId, cot_Id);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/Initial Therapy Screening

        public JsonResult GetAllPreInitialTherapyScreening(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<InitialTherapyScreening> request = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllPreInitialTherapyScreening(appId, patId);

                return Json(request, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion  Initial Therapy Screening  (Page Load)

        #region  Initial Therapy Screening CRUD Operations


        // Create: Initial Therapy Screening
        public PartialViewResult CreateInitialTherapyScreening()
        {
            if (PageControl.getLoggedinId() > 0)
            {

                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    InitialTherapyScreening eval = new InitialTherapyScreening();

                    return PartialView("CreateInitialTherapyScreening", eval);
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

        //INSERT: InitialTherapyScreening
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertInitialTherapyScreening(InitialTherapyScreening data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cot_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidInitialTherapyScreening(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateInitialTherapyScreening(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Initial Therapy Screening already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: InitialTherapyScreening
        [HttpGet]
        public PartialViewResult EditInitialTherapyScreening(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<InitialTherapyScreening> extraoral = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllInitialTherapyScreening(appId, 0);

                    return PartialView("EditInitialTherapyScreening", extraoral.FirstOrDefault());
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
        public ActionResult UpdateInitialTherapyScreening(InitialTherapyScreening data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cot_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Forms.isValidInitialTherapyScreening(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.OccupationalTherapy.InsertUpdateInitialTherapyScreening(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Initial Therapy Screening already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Print: InitialTherapyScreening
        [HttpGet]
        public ActionResult PrintInitialTherapyScreening(int cot_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    InitialTherapyScreening print = BusinessLogicLayer.EMR.OccupationalTherapy.GetAllInitialTherapyScreening(0, cot_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Initial Therapy Screening with cot_Id = {cot_Id}"
                    });

                    return View("PrintInitialTherapyScreening", print);
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
        // Delete: InitialTherapyScreening
        [HttpPost]
        public ActionResult DeleteInitialTherapyScreening(int cot_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cot_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.OccupationalTherapy.DeleteInitialTherapyScreening(cot_Id, cot_madeby);

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
        #endregion  Initial Therapy Screening CRUD Operations

        #region  Physiotherapy evaluation/ monthly progress (Page Load)
        // GET: EMR/Physiotherapy evaluation/ monthly progress
        public ActionResult EvaluationMonthlyProgress()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Physiotherapy evaluation/ monthly progress Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        #endregion  Physiotherapy evaluation/ monthly progress (Page Load)

        #region  Physiotherapy evaluation/ monthly progress CRUD Operations


        // Create: Evaluation Monthly Progress
        public PartialViewResult CreateEvaluationMonthlyProgress()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateEvaluationMonthlyProgress");
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
        #endregion  Physiotherapy evaluation/ monthly progress CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}