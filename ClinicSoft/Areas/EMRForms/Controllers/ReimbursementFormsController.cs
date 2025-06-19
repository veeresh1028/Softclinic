                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        using BusinessEntities;
using BusinessEntities.EMRForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ClinicSoft.Areas.EMRForms.Controllers
{
    [Authorize]
    public class ReimbursementFormsController : Controller
    {
        // GET: EMRForms/ReimbursementForms
        int PageId = (int)Pages.Forms;
        #region Adnic (Page Load)
        public PartialViewResult Adnic()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Adnic Adnic = new Adnic();
                return PartialView("Adnic", Adnic);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }


        // GET: Adnic Claim
        public JsonResult GetAllAdnic(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Adnic> pastadnic = BusinessLogicLayer.EMRForms.Adnic.GetAllAdnic(appId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Previous/Adnic
        public JsonResult GetAllPreAdnic(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Adnic> pastadnic = BusinessLogicLayer.EMRForms.Adnic.GetAllPreAdnic(appId, patId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetAllPatientTreatments(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Adnic> pastadnic = BusinessLogicLayer.EMRForms.Adnic.GetAllPatientTreatments(appId, patId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_Patient_Complaints(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Adnic> pastadnic = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Complaints(appId, patId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_Patient_Signs(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Adnic> pastadnic = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Signs(appId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Get_Patient_Treatment(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Adnic> pastadnic = BusinessLogicLayer.EMRForms.Adnic.Get_Patient_Treatment(appId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintAdnic(int adsId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Adnic print = BusinessLogicLayer.EMRForms.Adnic.GetPrintAdnic(adsId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "adnic1.gif");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Adnic Claim with adsId = {adsId}"
                    });

                    return View("PrintAdnic", print);
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
        #endregion 

        #region Adnic  CRUD Operations
        //CREATE:Adnic

        public PartialViewResult CreateAdnic()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Adnic adnic = new Adnic();
                    return PartialView("CreateAdnic", adnic);
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
        public ActionResult InsertAdnic(Adnic data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ads_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAdnic(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMRForms.Adnic.InsertUpdateAdnic(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Adnic Form already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Edit: Adnic
        [HttpGet]
        public PartialViewResult EditAdnic(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Adnic allergy = BusinessLogicLayer.EMRForms.Adnic.GetAllAdnic(appId).FirstOrDefault();
                    return PartialView("EditAdnic", allergy);
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
        public ActionResult UpdateAdnic(Adnic data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ads_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAdnic(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMRForms.Adnic.InsertUpdateAdnic(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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
        // Delete: Adnic
        [HttpPost]
        public ActionResult DeleteAdnic(int adsId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ads_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Adnic.DeleteAdnic(adsId, ads_madeby);

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
        #endregion 

        #region Aetna (Page Load)
        //public ActionResult Aetna()
        //{
        //    int Action = (int)Actions.Read;

        //    if (PageControl.haveAccess(PageId, Action))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public PartialViewResult Aetna()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Aetna Aetna = new Aetna();
                return PartialView("Aetna", Aetna);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Aetna Claim
        public JsonResult GetAllAetna(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Aetna> pastadnic = BusinessLogicLayer.EMRForms.Aetna.GetAllAetna(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreAetna(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Aetna> pastaetna = BusinessLogicLayer.EMRForms.Aetna.GetAllPreAetna(appId, patId);
                return Json(pastaetna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis

        public JsonResult Get_Patient_Diagnosis(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Aetna> pastaetne = BusinessLogicLayer.EMRForms.Aetna.Get_Patient_Diagnosis(appId);
                return Json(pastaetne, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Get_Patient_Lab_Treatments(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Aetna> pastadnic = BusinessLogicLayer.EMRForms.Aetna.Get_Patient_Lab_Treatment(appId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintAetna(int car_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Aetna print = BusinessLogicLayer.EMRForms.Aetna.GetPrintAetna(car_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "aetna2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Aetna Claim with car_Id = {car_Id}"
                    });

                    return View("PrintAetna", print);
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

        #endregion 

        #region Aetna  CRUD Operations
        //CREATE:Aetna

        public PartialViewResult CreateAetna()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Aetna aetna = new Aetna();
                    return PartialView("CreateAetna", aetna);
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
        public ActionResult InsertAetna(Aetna data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.car_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAetna(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMRForms.Aetna.InsertUpdateAetna(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Aetna Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Aetna
        [HttpGet]
        public PartialViewResult EditAetna(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Aetna allergy = BusinessLogicLayer.EMRForms.Aetna.GetAllAetna(appId).FirstOrDefault();
                    return PartialView("EditAetna", allergy);
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
        public ActionResult UpdateAetna(Aetna data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.car_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAetna(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMRForms.Aetna.InsertUpdateAetna(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Aetna
        [HttpPost]
        public ActionResult DeleteAetna(int car_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int car_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Aetna.DeleteAetna(car_Id, car_madeby);

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
        #endregion

        #region Alico (Page Load)
        //public ActionResult Alico()
        //{
        //    int Action = (int)Actions.Read;

        //    if (PageControl.haveAccess(PageId, Action))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        public PartialViewResult Alico()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Alico Alico = new Alico();
                return PartialView("Alico", Alico);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: Alico Claim
        public JsonResult GetAllAlico(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Alico> pastadnic = BusinessLogicLayer.EMRForms.Alico.GetAllAlico(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreAlico(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Alico> pastalico = BusinessLogicLayer.EMRForms.Alico.GetAllPreAlico(appId, patId);
                return Json(pastalico, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintAlico(int aliId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Alico print = BusinessLogicLayer.EMRForms.Alico.GetPrintAlico(aliId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "alico2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Alico Claim with aliId = {aliId}"
                    });

                    return View("PrintAlico", print);
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
        #endregion 

        #region Alico  CRUD Operations
        //CREATE:Alico
        public PartialViewResult CreateAlico()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Alico alico = new Alico();
                    return PartialView("CreateAlico", alico);
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
        public ActionResult InsertAlico(Alico data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ali_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAlico(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Alico.InsertUpdateAlico(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Alico Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: Alico
        [HttpGet]
        public PartialViewResult EditAlico(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Alico allergy = BusinessLogicLayer.EMRForms.Alico.GetAllAlico(appId).FirstOrDefault();
                    return PartialView("EditAlico", allergy);
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
        public ActionResult UpdateAlico(Alico data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ali_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAlico(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Alico.InsertUpdateAlico(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Alico
        [HttpPost]
        public ActionResult DeleteAlico(int aliId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ali_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Alico.DeleteAlico(aliId, ali_madeby);

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
        #endregion

        #region Allianz (Page Load)
        public PartialViewResult Allianz()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Allianz Allianz = new Allianz();
                return PartialView("Allianz", Allianz);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: Allianz Claim
        public JsonResult GetAllAllianz(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Allianz> pastadnic = BusinessLogicLayer.EMRForms.Allianz.GetAllAllianz(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreAllianz(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Allianz> pastallianz = BusinessLogicLayer.EMRForms.Allianz.GetAllPreAllianz(appId, patId);
                return Json(pastallianz, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintAllianz(int allId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Allianz print = BusinessLogicLayer.EMRForms.Allianz.GetPrintAllianz(allId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "allianz2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Allianz Claim with allId = {allId}"
                    });

                    return View("PrintAllianz", print);
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
        #endregion 

        #region Allianz  CRUD Operations
        //CREATE:Allianz
        public PartialViewResult CreateAllianz()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Allianz allianz = new Allianz();
                    return PartialView("CreateAllianz", allianz);
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
        public ActionResult InsertAllianz(Allianz data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.all_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAllianz(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMRForms.Allianz.InsertUpdateAllianz(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Allianz Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Allianz
        [HttpGet]
        public PartialViewResult EditAllianz(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Allianz allergy = BusinessLogicLayer.EMRForms.Allianz.GetAllAllianz(appId).FirstOrDefault();
                    return PartialView("EditAllianz", allergy);
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
        public ActionResult UpdateAllianz(Allianz data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.all_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAllianz(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Allianz.InsertUpdateAllianz(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Allianz
        [HttpPost]
        public ActionResult DeleteAllianz(int allId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int all_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Allianz.DeleteAllianz(allId, all_madeby);

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
        #endregion

        #region Axa (Page Load)
        public PartialViewResult Axa()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Axa Axa = new Axa();
                return PartialView("Axa", Axa);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Axa Claim
        public JsonResult GetAllAxa(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Axa> pastaxa = BusinessLogicLayer.EMRForms.Axa.GetAllAxa(appId);
                return Json(pastaxa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreAxa(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Axa> pastaxa = BusinessLogicLayer.EMRForms.Axa.GetAllPreAxa(appId, patId);
                return Json(pastaxa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis
        public JsonResult GetAllPatientDiagnosis(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Axa> pastadnic = BusinessLogicLayer.EMRForms.Axa.GetAllPatientDiagnosis(appId, patId);
                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Drugs
        public JsonResult Get_AllPatientDrugs(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Axa> drugs = BusinessLogicLayer.EMRForms.Axa.GetAllPatientDrugs(appId, patId);
                return Json(drugs, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }




        //Print:
        [HttpGet]
        public ActionResult PrintAxa(int carfId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Axa print = BusinessLogicLayer.EMRForms.Axa.GetPrintAxa(carfId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "axa_reimbursement.jpg");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Axa Claim with carfId = {carfId}"
                    });

                    return View("PrintAxa", print);
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

        #endregion

        #region Axa  CRUD Operations
        //CREATE:Axa

        public PartialViewResult CreateAxa()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Axa axa = new Axa();
                    return PartialView("CreateAxa", axa);
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
        public ActionResult InsertAxa(Axa data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.carf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAxa(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMRForms.Axa.InsertUpdateAxa(data);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Axa Form already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Axa
        [HttpGet]
        public PartialViewResult EditAxa(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Axa allergy = BusinessLogicLayer.EMRForms.Axa.GetAllAxa(appId).FirstOrDefault();
                    return PartialView("EditAxa", allergy);
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
        public ActionResult UpdateAxa(Axa data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.carf_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidAxa(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Axa.InsertUpdateAxa(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Axa
        [HttpPost]
        public ActionResult DeleteAxa(int carfId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int carf_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Axa.DeleteAxa(carfId, carf_madeby);

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
        #endregion 

        #region MSH (Page Load)
        public PartialViewResult MSH()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                MSH MSH = new MSH();
                return PartialView("MSH", MSH);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: MSH Claim
        public JsonResult GetAllMSH(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MSH> pastmsh = BusinessLogicLayer.EMRForms.MSH.GetAllMSH(appId);
                return Json(pastmsh, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreMSH(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MSH> pastmsh = BusinessLogicLayer.EMRForms.MSH.GetAllPreMSH(appId, patId);
                return Json(pastmsh, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintMSH(int cmr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    MSH print = BusinessLogicLayer.EMRForms.MSH.GetPrintMSH(cmr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "msh2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed MSH Claim with cmr_Id = {cmr_Id}"
                    });

                    return View("PrintMSH", print);
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

        #endregion

        #region MSH  CRUD Operations
        //CREATE:MSH

        public PartialViewResult CreateMSH()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    MSH msh = new MSH();
                    return PartialView("CreateMSH", msh);
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
        public ActionResult InsertMSH(MSH data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cmr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidMSH(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.MSH.InsertUpdateMSH(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "MSH Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: MSH
        [HttpGet]
        public PartialViewResult EditMSH(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    MSH allergy = BusinessLogicLayer.EMRForms.MSH.GetAllMSH(appId).FirstOrDefault();
                    return PartialView("EditMSH", allergy);
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
        public ActionResult UpdateMSH(MSH data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cmr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidMSH(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.MSH.InsertUpdateMSH(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: MSH
        [HttpPost]
        public ActionResult DeleteMSH(int cmr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cmr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.MSH.DeleteMSH(cmr_Id, cmr_madeby);

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
        #endregion

        #region Dubaicare (Page Load)
        public PartialViewResult Dubaicare()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dubaicare Dubaicare = new Dubaicare();
                return PartialView("Dubaicare", Dubaicare);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Dubaicare Claim
        public JsonResult GetAllDubaicare(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Dubaicare> pastdubaicare = BusinessLogicLayer.EMRForms.Dubaicare.GetAllDubaicare(appId);
                return Json(pastdubaicare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreDubaicare(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Dubaicare> pastdubaicare = BusinessLogicLayer.EMRForms.Dubaicare.GetAllPreDubaicare(appId, patId);
                return Json(pastdubaicare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintDubaicare(int cdr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Dubaicare print = BusinessLogicLayer.EMRForms.Dubaicare.GetPrintDubaicare(cdr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "dubaicare.jpg");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Dubaicare Claim with cdr_Id = {cdr_Id}"
                    });

                    return View("PrintDubaicare", print);
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

        #endregion 

        #region Dubaicare  CRUD Operations
        //CREATE:Dubaicare

        public PartialViewResult CreateDubaicare()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dubaicare dubaicare = new Dubaicare();
                    return PartialView("CreateDubaicare", dubaicare);
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
        public ActionResult InsertDubaicare(Dubaicare data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDubaicare(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Dubaicare.InsertUpdateDubaicare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Dubaicare Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: Dubaicare
        [HttpGet]
        public PartialViewResult EditDubaicare(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dubaicare allergy = BusinessLogicLayer.EMRForms.Dubaicare.GetAllDubaicare(appId).FirstOrDefault();
                    return PartialView("EditDubaicare", allergy);
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
        public ActionResult UpdateDubaicare(Dubaicare data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDubaicare(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Dubaicare.InsertUpdateDubaicare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Dubaicare
        [HttpPost]
        public ActionResult DeleteDubaicare(int cdr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cdr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Dubaicare.DeleteDubaicare(cdr_Id, cdr_madeby);

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
        #endregion

        #region Emirates (Page Load)
        public PartialViewResult Emirates()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Emirates Emirates = new Emirates();
                return PartialView("Emirates", Emirates);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Emirates Claim
        public JsonResult GetAllEmirates(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Emirates> pastemirates = BusinessLogicLayer.EMRForms.Emirates.GetAllEmirates(appId);
                return Json(pastemirates, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreEmirates(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Emirates> pastemirates = BusinessLogicLayer.EMRForms.Emirates.GetAllPreEmirates(appId, patId);
                return Json(pastemirates, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintEmirates(int cer_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Emirates print = BusinessLogicLayer.EMRForms.Emirates.GetPrintEmirates(cer_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "EmiratesDnata.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Emirates Claim with cer_Id = {cer_Id}"
                    });

                    return View("PrintEmirates", print);
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

        #endregion 

        #region Emirates  CRUD Operations
        //CREATE:Emirates

        public PartialViewResult CreateEmirates()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Emirates emirates = new Emirates();
                    return PartialView("CreateEmirates", emirates);
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
        public ActionResult InsertEmirates(Emirates data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cer_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidEmirates(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Emirates.InsertUpdateEmirates(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Emirates Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: Emirates
        [HttpGet]
        public PartialViewResult EditEmirates(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Emirates allergy = BusinessLogicLayer.EMRForms.Emirates.GetAllEmirates(appId).FirstOrDefault();
                    return PartialView("EditEmirates", allergy);
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
        public ActionResult UpdateEmirates(Emirates data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cer_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidEmirates(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Emirates.InsertUpdateEmirates(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Emirates
        [HttpPost]
        public ActionResult DeleteEmirates(int cer_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cer_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Emirates.DeleteEmirates(cer_Id, cer_madeby);

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
        #endregion

        #region FMC (Page Load)
        public PartialViewResult FMC()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                FMC FMC = new FMC();
                return PartialView("FMC", FMC);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: FMC Claim
        public JsonResult GetAllFMC(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<FMC> pastfmc = BusinessLogicLayer.EMRForms.FMC.GetAllFMC(appId);
                return Json(pastfmc, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreFMC(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<FMC> pastfmc = BusinessLogicLayer.EMRForms.FMC.GetAllPreFMC(appId, patId);
                return Json(pastfmc, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintFMC(int fcId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    FMC print = BusinessLogicLayer.EMRForms.FMC.GetPrintFMC(fcId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "fmc.gif");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed FMC Claim with fcId = {fcId}"
                    });

                    return View("PrintFMC", print);
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

        #endregion

        #region FMC  CRUD Operations
        //CREATE:FMC
        public PartialViewResult CreateFMC()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    FMC fmc = new FMC();
                    return PartialView("CreateFMC", fmc);
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
        public ActionResult InsertFMC(FMC data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.fc_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidFMC(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.FMC.InsertUpdateFMC(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "FMC Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Edit: FMC
        [HttpGet]
        public PartialViewResult EditFMC(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    FMC allergy = BusinessLogicLayer.EMRForms.FMC.GetAllFMC(appId).FirstOrDefault();
                    return PartialView("EditFMC", allergy);
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
        public ActionResult UpdateFMC(FMC data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.fc_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidFMC(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.FMC.InsertUpdateFMC(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: FMC
        [HttpPost]
        public ActionResult DeleteFMC(int fcId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int fc_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.FMC.DeleteFMC(fcId, fc_madeby);

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
        #endregion

        #region Neuron (Page Load)
        public PartialViewResult Neuron()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Neuron Neuron = new Neuron();
                return PartialView("Neuron", Neuron);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Neuron Claim
        public JsonResult GetAllNeuron(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Neuron> pastneuron = BusinessLogicLayer.EMRForms.Neuron.GetAllNeuron(appId);
                return Json(pastneuron, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNeuron(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Neuron> pastneuron = BusinessLogicLayer.EMRForms.Neuron.GetAllPreNeuron(appId, patId);
                return Json(pastneuron, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintNeuron(int nrId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Neuron print = BusinessLogicLayer.EMRForms.Neuron.GetPrintNeuron(nrId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "neuron-insurance.gif");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Neuron Claim with nrId = {nrId}"
                    });

                    return View("PrintNeuron", print);
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

        #endregion 

        #region Neuron  CRUD Operations
        //CREATE:Neuron

        public PartialViewResult CreateNeuron()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Neuron neuron = new Neuron();
                    return PartialView("CreateNeuron", neuron);
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
        public ActionResult InsertNeuron(Neuron data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.nr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNeuron(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Neuron.InsertUpdateNeuron(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Neuron Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: Neuron
        [HttpGet]
        public PartialViewResult EditNeuron(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Neuron allergy = BusinessLogicLayer.EMRForms.Neuron.GetAllNeuron(appId).FirstOrDefault();
                    return PartialView("EditNeuron", allergy);
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
        public ActionResult UpdateNeuron(Neuron data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.nr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNeuron(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Neuron.InsertUpdateNeuron(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Neuron
        [HttpPost]
        public ActionResult DeleteNeuron(int nrId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int nr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Neuron.DeleteNeuron(nrId, nr_madeby);

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
        #endregion

        #region Starwell (Page Load)
        public PartialViewResult Starwell()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Starwell Starwell = new Starwell();
                return PartialView("Starwell", Starwell);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: Starwell Claim
        public JsonResult GetAllStarwell(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Starwell> pastadnic = BusinessLogicLayer.EMRForms.Starwell.GetAllStarwell(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreStarwell(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Starwell> paststarwell = BusinessLogicLayer.EMRForms.Starwell.GetAllPreStarwell(appId, patId);
                return Json(paststarwell, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintStarwell(int swId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Starwell print = BusinessLogicLayer.EMRForms.Starwell.GetPrintStarwell(swId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "starwell.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Starwell Claim with swId = {swId}"
                    });

                    return View("PrintStarwell", print);
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
        #endregion 

        #region Starwell  CRUD Operations
        //CREATE:Starwell
        public PartialViewResult CreateStarwell()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Starwell starwell = new Starwell();
                    return PartialView("CreateStarwell", starwell);
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
        public ActionResult InsertStarwell(Starwell data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sw_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Starwell.InsertUpdateStarwell(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Starwell Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Starwell
        [HttpGet]
        public PartialViewResult EditStarwell(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Starwell allergy = BusinessLogicLayer.EMRForms.Starwell.GetAllStarwell(appId).FirstOrDefault();
                    return PartialView("EditStarwell", allergy);
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
        public ActionResult UpdateStarwell(Starwell data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sw_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidStarwell(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Starwell.InsertUpdateStarwell(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Starwell
        [HttpPost]
        public ActionResult DeleteStarwell(int swId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int sw_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Starwell.DeleteStarwell(swId, sw_madeby);

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
        #endregion

        #region NGI (Page Load)
        public PartialViewResult NGI()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NGI NGI = new NGI();
                return PartialView("NGI", NGI);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: NGI Claim
        public JsonResult GetAllNGI(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NGI> pastadnic = BusinessLogicLayer.EMRForms.NGI.GetAllNGI(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreNGI(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NGI> pastngl = BusinessLogicLayer.EMRForms.NGI.GetAllPreNGI(appId, patId);
                return Json(pastngl, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintNGI(int ngId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NGI print = BusinessLogicLayer.EMRForms.NGI.GetPrintNGI(ngId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "ngl.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NGI Claim with ngId = {ngId}"
                    });

                    return View("PrintNGI", print);
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
        #endregion 

        #region NGI  CRUD Operations
        //CREATE:NGI
        public PartialViewResult CreateNGI()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NGI ngl = new NGI();
                    return PartialView("CreateNGI", ngl);
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
        public ActionResult InsertNGI(NGI data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ng_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.NGI.InsertUpdateNGI(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NGI Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NGI
        [HttpGet]
        public PartialViewResult EditNGI(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NGI allergy = BusinessLogicLayer.EMRForms.NGI.GetAllNGI(appId).FirstOrDefault();
                    return PartialView("EditNGI", allergy);
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
        public ActionResult UpdateNGI(NGI data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ng_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNGI(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NGI.InsertUpdateNGI(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: NGI
        [HttpPost]
        public ActionResult DeleteNGI(int ngId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ng_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NGI.DeleteNGI(ngId, ng_madeby);

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

        public JsonResult GetEmrInfo(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NGI> pastadnic = BusinessLogicLayer.EMRForms.NGI.GetEmrInfo(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion 

        #region Inayah (Page Load)
        public PartialViewResult Inayah()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Inayah Inayah = new Inayah();
                return PartialView("Inayah", Inayah);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: Inayah Claim
        public JsonResult GetAllInayah(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Inayah> pastadnic = BusinessLogicLayer.EMRForms.Inayah.GetAllInayah(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreInayah(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Inayah> pastinayah = BusinessLogicLayer.EMRForms.Inayah.GetAllPreInayah(appId, patId);
                return Json(pastinayah, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintInayah(int cir_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Inayah print = BusinessLogicLayer.EMRForms.Inayah.GetPrintInayah(cir_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "inayah_2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Inayah Claim with cir_Id = {cir_Id}"
                    });

                    return View("PrintInayah", print);
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
        #endregion

        #region Inayah  CRUD Operations
        //CREATE:Inayah
        public PartialViewResult CreateInayah()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Inayah inayah = new Inayah();
                    return PartialView("CreateInayah", inayah);
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
        public ActionResult InsertInayah(Inayah data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cir_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Inayah.InsertUpdateInayah(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Inayah Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Inayah
        [HttpGet]
        public PartialViewResult EditInayah(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Inayah allergy = BusinessLogicLayer.EMRForms.Inayah.GetAllInayah(appId).FirstOrDefault();
                    return PartialView("EditInayah", allergy);
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
        public ActionResult UpdateInayah(Inayah data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cir_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidInayah(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Inayah.InsertUpdateInayah(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Inayah
        [HttpPost]
        public ActionResult DeleteInayah(int cir_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cir_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Inayah.DeleteInayah(cir_Id, cir_madeby);

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
        #endregion

        #region Healthnet (Page Load)
        public PartialViewResult Healthnet()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Healthnet Healthnet = new Healthnet();
                return PartialView("Healthnet", Healthnet);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: Healthnet Claim
        public JsonResult GetAllHealthnet(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Healthnet> pasthealthnet = BusinessLogicLayer.EMRForms.Healthnet.GetAllHealthnet(appId);

                return Json(pasthealthnet, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreHealthnet(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Healthnet> pastngl = BusinessLogicLayer.EMRForms.Healthnet.GetAllPreHealthnet(appId, patId);
                return Json(pastngl, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintHealthnet(int chr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Healthnet print = BusinessLogicLayer.EMRForms.Healthnet.GetPrintHealthnet(chr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "healthnet.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Healthnet Claim with chr_Id = {chr_Id}"
                    });

                    return View("PrintHealthnet", print);
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
        #endregion 

        #region Healthnet  CRUD Operations
        //CREATE:Healthnet
        public PartialViewResult CreateHealthnet()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Healthnet ngl = new Healthnet();
                    return PartialView("CreateHealthnet", ngl);
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
        public ActionResult InsertHealthnet(Healthnet data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.chr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Healthnet.InsertUpdateHealthnet(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Healthnet Form already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Healthnet
        [HttpGet]
        public PartialViewResult EditHealthnet(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Healthnet allergy = BusinessLogicLayer.EMRForms.Healthnet.GetAllHealthnet(appId).FirstOrDefault();
                    return PartialView("EditHealthnet", allergy);
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
        public ActionResult UpdateHealthnet(Healthnet data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.chr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidHealthnet(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Healthnet.InsertUpdateHealthnet(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Healthnet
        [HttpPost]
        public ActionResult DeleteHealthnet(int chr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int chr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Healthnet.DeleteHealthnet(chr_Id, chr_madeby);

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

        #endregion

        #region Daman (Page Load)
        public PartialViewResult Daman()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Daman Daman = new Daman();
                return PartialView("Daman", Daman);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Daman Claim
        public JsonResult GetAllDaman(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Daman> pastdaman = BusinessLogicLayer.EMRForms.Daman.GetAllDaman(appId);

                return Json(pastdaman, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreDaman(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Daman> pastaetna = BusinessLogicLayer.EMRForms.Daman.GetAllPreDaman(appId, patId);
                return Json(pastaetna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis



        //Print:
        [HttpGet]
        public ActionResult PrintDaman(int cdr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Daman print = BusinessLogicLayer.EMRForms.Daman.GetPrintDaman(cdr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "daman.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Daman Claim with cdr_Id = {cdr_Id}"
                    });

                    return View("PrintDaman", print);
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

        #endregion 

        #region Daman  CRUD Operations
        //CREATE:Daman

        public PartialViewResult CreateDaman()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Daman aetna = new Daman();
                    return PartialView("CreateDaman", aetna);
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
        public ActionResult InsertDaman(Daman data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDaman(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Daman.InsertUpdateDaman(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Daman Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: Daman
        [HttpGet]
        public PartialViewResult EditDaman(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Daman allergy = BusinessLogicLayer.EMRForms.Daman.GetAllDaman(appId).FirstOrDefault();
                    return PartialView("EditDaman", allergy);
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
        public ActionResult UpdateDaman(Daman data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDaman(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Daman.InsertUpdateDaman(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Daman
        [HttpPost]
        public ActionResult DeleteDaman(int cdr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cdr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Daman.DeleteDaman(cdr_Id, cdr_madeby);

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
        #endregion 

        #region DamanArabic (Page Load)
        public PartialViewResult DamanArabic()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DamanArabic DamanArabic = new DamanArabic();
                return PartialView("DamanArabic", DamanArabic);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: DamanArabic Claim
        public JsonResult GetAllDamanArabic(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DamanArabic> pastdaman = BusinessLogicLayer.EMRForms.DamanArabic.GetAllDamanArabic(appId);

                return Json(pastdaman, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreDamanArabic(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DamanArabic> pastaetna = BusinessLogicLayer.EMRForms.DamanArabic.GetAllPreDamanArabic(appId, patId);
                return Json(pastaetna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis



        //Print:
        [HttpGet]
        public ActionResult PrintDamanArabic(int cdr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    DamanArabic print = BusinessLogicLayer.EMRForms.DamanArabic.GetPrintDamanArabic(cdr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "aetna2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed DamanArabic Claim with cdr_Id = {cdr_Id}"
                    });

                    return View("PrintDamanArabic", print);
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

        #endregion 

        #region DamanArabic  CRUD Operations
        //CREATE:DamanArabic

        public PartialViewResult CreateDamanArabic()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    DamanArabic aetna = new DamanArabic();
                    return PartialView("CreateDamanArabic", aetna);
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
        public ActionResult InsertDamanArabic(DamanArabic data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDamanArabic(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.DamanArabic.InsertUpdateDamanArabic(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "DamanArabic Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: DamanArabic
        [HttpGet]
        public PartialViewResult EditDamanArabic(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    DamanArabic allergy = BusinessLogicLayer.EMRForms.DamanArabic.GetAllDamanArabic(appId).FirstOrDefault();
                    return PartialView("EditDamanArabic", allergy);
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
        public ActionResult UpdateDamanArabic(DamanArabic data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDamanArabic(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.DamanArabic.InsertUpdateDamanArabic(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: DamanArabic
        [HttpPost]
        public ActionResult DeleteDamanArabic(int cdr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cdr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.DamanArabic.DeleteDamanArabic(cdr_Id, cdr_madeby);

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
        #endregion

        #region DamanWT (Page Load)
        public PartialViewResult DamanWT()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DamanWT DamanWT = new DamanWT();
                return PartialView("DamanWT", DamanWT);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: DamanWT Claim
        public JsonResult GetAllDamanWT(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DamanWT> pastdamanWT = BusinessLogicLayer.EMRForms.DamanWT.GetAllDamanWT(appId);

                return Json(pastdamanWT, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreDamanWT(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DamanWT> pastaetna = BusinessLogicLayer.EMRForms.DamanWT.GetAllPreDamanWT(appId, patId);
                return Json(pastaetna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous getDataDaman
        public JsonResult getDataDaman(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DamanWT> pastaetna = BusinessLogicLayer.EMRForms.DamanWT.getDataDaman(appId, patId);
                return Json(pastaetna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        //Print:
        [HttpGet]
        public ActionResult PrintDamanWT(int cdr_Id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    DamanWT print = BusinessLogicLayer.EMRForms.DamanWT.GetPrintDamanWT(cdr_Id).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "aetna2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed DamanWT Claim with cdr_Id = {cdr_Id}"
                    });

                    return View("PrintDamanWT", print);
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

        #endregion 

        #region DamanWT  CRUD Operations
        //CREATE:DamanWT

        public PartialViewResult CreateDamanWT()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    DamanWT aetna = new DamanWT();
                    return PartialView("CreateDamanWT", aetna);
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
        public ActionResult InsertDamanWT(DamanWT data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDamanWT(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.DamanWT.InsertUpdateDamanWT(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "DamanWT Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: DamanWT
        [HttpGet]
        public PartialViewResult EditDamanWT(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    DamanWT allergy = BusinessLogicLayer.EMRForms.DamanWT.GetAllDamanWT(appId).FirstOrDefault();
                    return PartialView("EditDamanWT", allergy);
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
        public ActionResult UpdateDamanWT(DamanWT data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cdr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidDamanWT(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.DamanWT.InsertUpdateDamanWT(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: DamanWT
        [HttpPost]
        public ActionResult DeleteDamanWT(int cdr_Id)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cdr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.DamanWT.DeleteDamanWT(cdr_Id, cdr_madeby);

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
        #endregion

        #region NAS (Page Load)
        public PartialViewResult NAS()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NAS NAS = new NAS();
                return PartialView("NAS", NAS);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NAS Claim
        public JsonResult GetAllNAS(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NAS> pastnas = BusinessLogicLayer.EMRForms.NAS.GetAllNAS(appId);

                return Json(pastnas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNAS(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NAS> pastnas = BusinessLogicLayer.EMRForms.NAS.GetAllPreNAS(appId, patId);
                return Json(pastnas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis



        //Print:
        [HttpGet]
        public ActionResult PrintNAS(int nasnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NAS print = BusinessLogicLayer.EMRForms.NAS.GetPrintNAS(nasnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "nas.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NAS Claim with nasnId = {nasnId}"
                    });

                    return View("PrintNAS", print);
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

        #endregion

        #region NAS  CRUD Operations
        //CREATE:NAS

        public PartialViewResult CreateNAS()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NAS nas = new NAS();
                    return PartialView("CreateNAS", nas);
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
        public ActionResult InsertNAS(NAS data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.nasn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNAS(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NAS.InsertUpdateNAS(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NAS Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: NAS
        [HttpGet]
        public PartialViewResult EditNAS(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NAS nas = BusinessLogicLayer.EMRForms.NAS.GetAllNAS(appId).FirstOrDefault();
                    return PartialView("EditNAS", nas);
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
        public ActionResult UpdateNAS(NAS data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.nasn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNAS(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NAS.InsertUpdateNAS(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: NAS
        [HttpPost]
        public ActionResult DeleteNAS(int nasnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int nasn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMRForms.NAS.DeleteNAS(nasnId, nasn_madeby);

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
        #endregion 

        #region Metlife (Page Load)
        public PartialViewResult Metlife()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Metlife Metlife = new Metlife();
                return PartialView("Metlife", Metlife);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Metlife Claim
        public JsonResult GetAllMetlife(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Metlife> pastmetlife = BusinessLogicLayer.EMRForms.Metlife.GetAllMetlife(appId);

                return Json(pastmetlife, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreMetlife(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Metlife> pastaetna = BusinessLogicLayer.EMRForms.Metlife.GetAllPreMetlife(appId, patId);
                return Json(pastaetna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis



        //Print:
        [HttpGet]
        public ActionResult PrintMetlife(int metId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Metlife print = BusinessLogicLayer.EMRForms.Metlife.GetPrintMetlife(metId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "metlife.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Metlife Claim with metId = {metId}"
                    });

                    return View("PrintMetlife", print);
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

        #endregion

        #region Metlife  CRUD Operations
        //CREATE:Metlife

        public PartialViewResult CreateMetlife()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Metlife aetna = new Metlife();
                    return PartialView("CreateMetlife", aetna);
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
        public ActionResult InsertMetlife(Metlife data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.met_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidMetlife(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Metlife.InsertUpdateMetlife(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Metlife Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: Metlife
        [HttpGet]
        public PartialViewResult EditMetlife(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Metlife allergy = BusinessLogicLayer.EMRForms.Metlife.GetAllMetlife(appId).FirstOrDefault();
                    return PartialView("EditMetlife", allergy);
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
        public ActionResult UpdateMetlife(Metlife data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.met_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidMetlife(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Metlife.InsertUpdateMetlife(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Metlife
        [HttpPost]
        public ActionResult DeleteMetlife(int metId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int met_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Metlife.DeleteMetlife(metId, met_madeby);

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
        #endregion

        #region Mednet (Page Load)
        public PartialViewResult Mednet()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Mednet Mednet = new Mednet();
                return PartialView("Mednet", Mednet);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Mednet Claim
        public JsonResult GetAllMednet(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Mednet> pastaxa = BusinessLogicLayer.EMRForms.Mednet.GetAllMednet(appId);
                return Json(pastaxa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreMednet(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Mednet> pastaxa = BusinessLogicLayer.EMRForms.Mednet.GetAllPreMednet(appId, patId);
                return Json(pastaxa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintMednet(int cmcnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Mednet print = BusinessLogicLayer.EMRForms.Mednet.GetPrintMednet(cmcnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "mednet.jpg");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Mednet Claim with cmcnId = {cmcnId}"
                    });

                    return View("PrintMednet", print);
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

        #endregion 

        #region Mednet  CRUD Operations
        //CREATE:Mednet

        public PartialViewResult CreateMednet()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Mednet axa = new Mednet();
                    return PartialView("CreateMednet", axa);
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
        public ActionResult InsertMednet(Mednet data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cmcn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Mednet.InsertUpdateMednet(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Mednet Form already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Mednet
        [HttpGet]
        public PartialViewResult EditMednet(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Mednet allergy = BusinessLogicLayer.EMRForms.Mednet.GetAllMednet(appId).FirstOrDefault();
                    return PartialView("EditMednet", allergy);
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
        public ActionResult UpdateMednet(Mednet data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cmcn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidMednet(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Mednet.InsertUpdateMednet(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Mednet
        [HttpPost]
        public ActionResult DeleteMednet(int cmcnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cmcn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Mednet.DeleteMednet(cmcnId, cmcn_madeby);

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
        #endregion

        #region Nextcare (Page Load)
        public PartialViewResult Nextcare()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Nextcare Nextcare = new Nextcare();
                return PartialView("Nextcare", Nextcare);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Nextcare Claim
        public JsonResult GetAllNextcare(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Nextcare> pastnextcare = BusinessLogicLayer.EMRForms.Nextcare.GetAllNextcare(appId);
                return Json(pastnextcare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNextcare(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Nextcare> pastnextcare = BusinessLogicLayer.EMRForms.Nextcare.GetAllPreNextcare(appId, patId);
                return Json(pastnextcare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNextcare(int cncnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Nextcare print = BusinessLogicLayer.EMRForms.Nextcare.GetPrintNextcare(cncnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "nextcare.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Nextcare Claim with cncnId = {cncnId}"
                    });

                    return View("PrintNextcare", print);
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

        #endregion

        #region Nextcare  CRUD Operations
        //CREATE:Nextcare

        public PartialViewResult CreateNextcare()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Nextcare nextcare = new Nextcare();
                    return PartialView("CreateNextcare", nextcare);
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
        public ActionResult InsertNextcare(Nextcare data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cncn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Nextcare.InsertUpdateNextcare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Nextcare Form already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Nextcare
        [HttpGet]
        public PartialViewResult EditNextcare(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Nextcare allergy = BusinessLogicLayer.EMRForms.Nextcare.GetAllNextcare(appId).FirstOrDefault();
                    return PartialView("EditNextcare", allergy);
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
        public ActionResult UpdateNextcare(Nextcare data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cncn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNextcare(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Nextcare.InsertUpdateNextcare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Nextcare
        [HttpPost]
        public ActionResult DeleteNextcare(int cncnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cncn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Nextcare.DeleteNextcare(cncnId, cncn_madeby);

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
        #endregion

        #region Alkhazna (Page Load)
        public PartialViewResult Alkhazna()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Alkhazna Alkhazna = new Alkhazna();
                return PartialView("Alkhazna", Alkhazna);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Alkhazna Claim
        public JsonResult GetAllAlkhazna(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Alkhazna> pastadnic = BusinessLogicLayer.EMRForms.Alkhazna.GetAllAlkhazna(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreAlkhazna(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Alkhazna> pastalkhazna = BusinessLogicLayer.EMRForms.Alkhazna.GetAllPreAlkhazna(appId, patId);
                return Json(pastalkhazna, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        //Print:
        [HttpGet]
        public ActionResult PrintAlkhazna(int ckneId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Alkhazna print = BusinessLogicLayer.EMRForms.Alkhazna.GetPrintAlkhazna(ckneId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "khazna.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Alkhazna Claim with ckneId = {ckneId}"
                    });

                    return View("PrintAlkhazna", print);
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

        #endregion 

        #region Alkhazna  CRUD Operations
        //CREATE:Alkhazna

        public PartialViewResult CreateAlkhazna()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Alkhazna alkhazna = new Alkhazna();
                    return PartialView("CreateAlkhazna", alkhazna);
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
        public ActionResult InsertAlkhazna(Alkhazna data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ckne_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Alkhazna.InsertUpdateAlkhazna(data);
                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Alkhazna Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Alkhazna
        [HttpGet]
        public PartialViewResult EditAlkhazna(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Alkhazna allergy = BusinessLogicLayer.EMRForms.Alkhazna.GetAllAlkhazna(appId).FirstOrDefault();
                    return PartialView("EditAlkhazna", allergy);
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
        public ActionResult UpdateAlkhazna(Alkhazna data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ckne_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Alkhazna.InsertUpdateAlkhazna(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Alkhazna
        [HttpPost]
        public ActionResult DeleteAlkhazna(int ckneId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ckne_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Alkhazna.DeleteAlkhazna(ckneId, ckne_madeby);

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
        #endregion

        #region ArabOrient (Page Load)
        public PartialViewResult ArabOrient()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                ArabOrient ArabOrient = new ArabOrient();
                return PartialView("ArabOrient", ArabOrient);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: ArabOrient Claim
        public JsonResult GetAllArabOrient(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ArabOrient> pastadnic = BusinessLogicLayer.EMRForms.ArabOrient.GetAllArabOrient(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreArabOrient(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ArabOrient> pastaraborient = BusinessLogicLayer.EMRForms.ArabOrient.GetAllPreArabOrient(appId, patId);
                return Json(pastaraborient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        //Print:
        [HttpGet]
        public ActionResult PrintArabOrient(int caonId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    ArabOrient print = BusinessLogicLayer.EMRForms.ArabOrient.GetPrintArabOrient(caonId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "arab.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed ArabOrient Claim with caonId = {caonId}"
                    });

                    return View("PrintArabOrient", print);
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

        #endregion 

        #region ArabOrient  CRUD Operations
        //CREATE:ArabOrient

        public PartialViewResult CreateArabOrient()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    ArabOrient araborient = new ArabOrient();
                    return PartialView("CreateArabOrient", araborient);
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
        public ActionResult InsertArabOrient(ArabOrient data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.caon_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.ArabOrient.InsertUpdateArabOrient(data);
                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "ArabOrient Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: ArabOrient
        [HttpGet]
        public PartialViewResult EditArabOrient(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    ArabOrient allergy = BusinessLogicLayer.EMRForms.ArabOrient.GetAllArabOrient(appId).FirstOrDefault();
                    return PartialView("EditArabOrient", allergy);
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
        public ActionResult UpdateArabOrient(ArabOrient data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.caon_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.ArabOrient.InsertUpdateArabOrient(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: ArabOrient
        [HttpPost]
        public ActionResult DeleteArabOrient(int caonId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int caon_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.ArabOrient.DeleteArabOrient(caonId, caon_madeby);

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
        #endregion 

        #region EmiratesDental (Page Load)
        public PartialViewResult EmiratesDental()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                EmiratesDental EmiratesDental = new EmiratesDental();
                return PartialView("EmiratesDental", EmiratesDental);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: EmiratesDental Claim
        public JsonResult GetAllEmiratesDental(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmiratesDental> pastadnic = BusinessLogicLayer.EMRForms.EmiratesDental.GetAllEmiratesDental(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreEmiratesDental(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmiratesDental> pastemiratesdental = BusinessLogicLayer.EMRForms.EmiratesDental.GetAllPreEmiratesDental(appId, patId);
                return Json(pastemiratesdental, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintEmiratesDental(int emdnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    EmiratesDental print = BusinessLogicLayer.EMRForms.EmiratesDental.GetPrintEmiratesDental(emdnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "emirates.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed EmiratesDental Claim with emdnId = {emdnId}"
                    });

                    return View("PrintEmiratesDental", print);
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

        #endregion

        #region EmiratesDental  CRUD Operations
        //CREATE:EmiratesDental
        public PartialViewResult CreateEmiratesDental()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EmiratesDental emiratesdental = new EmiratesDental();
                    return PartialView("CreateEmiratesDental", emiratesdental);
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
        public ActionResult InsertEmiratesDental(EmiratesDental data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.emdn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.EmiratesDental.InsertUpdateEmiratesDental(data);
                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "EmiratesDental Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: EmiratesDental
        [HttpGet]
        public PartialViewResult EditEmiratesDental(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EmiratesDental allergy = BusinessLogicLayer.EMRForms.EmiratesDental.GetAllEmiratesDental(appId).FirstOrDefault();
                    return PartialView("EditEmiratesDental", allergy);
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
        public ActionResult UpdateEmiratesDental(EmiratesDental data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.emdn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.EmiratesDental.InsertUpdateEmiratesDental(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: EmiratesDental
        [HttpPost]
        public ActionResult DeleteEmiratesDental(int emdnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int emdn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.EmiratesDental.DeleteEmiratesDental(emdnId, emdn_madeby);

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
        #endregion

        #region MednetTakaful (Page Load)
        public PartialViewResult MednetTakaful()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                MednetTakaful MednetTakaful = new MednetTakaful();
                return PartialView("MednetTakaful", MednetTakaful);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: MednetTakaful Claim
        public JsonResult GetAllMednetTakaful(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MednetTakaful> pastaxa = BusinessLogicLayer.EMRForms.MednetTakaful.GetAllMednetTakaful(appId);
                return Json(pastaxa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreMednetTakaful(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<MednetTakaful> pastaxa = BusinessLogicLayer.EMRForms.MednetTakaful.GetAllPreMednetTakaful(appId, patId);
                return Json(pastaxa, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintMednetTakaful(int cmtnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    MednetTakaful print = BusinessLogicLayer.EMRForms.MednetTakaful.GetPrintMednetTakaful(cmtnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "mednettakaful.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed MednetTakaful Claim with cmtnId = {cmtnId}"
                    });

                    return View("PrintMednetTakaful", print);
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

        #endregion 

        #region MednetTakaful  CRUD Operations
        //CREATE:MednetTakaful

        public PartialViewResult CreateMednetTakaful()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    MednetTakaful axa = new MednetTakaful();
                    return PartialView("CreateMednetTakaful", axa);
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
        public ActionResult InsertMednetTakaful(MednetTakaful data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cmtn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.MednetTakaful.InsertUpdateMednetTakaful(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "MednetTakaful Form already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: MednetTakaful
        [HttpGet]
        public PartialViewResult EditMednetTakaful(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    MednetTakaful allergy = BusinessLogicLayer.EMRForms.MednetTakaful.GetAllMednetTakaful(appId).FirstOrDefault();
                    return PartialView("EditMednetTakaful", allergy);
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
        public ActionResult UpdateMednetTakaful(MednetTakaful data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cmtn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidMednetTakaful(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.MednetTakaful.InsertUpdateMednetTakaful(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: MednetTakaful
        [HttpPost]
        public ActionResult DeleteMednetTakaful(int cmtnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cmtn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.MednetTakaful.DeleteMednetTakaful(cmtnId, cmtn_madeby);

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
        #endregion

        #region NASQIC (Page Load)
        public PartialViewResult NASQIC()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NASQIC NASQIC = new NASQIC();
                return PartialView("NASQIC", NASQIC);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NASQIC Claim
        public JsonResult GetAllNASQIC(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NASQIC> pastnasqic = BusinessLogicLayer.EMRForms.NASQIC.GetAllNASQIC(appId);

                return Json(pastnasqic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNASQIC(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NASQIC> pastnasqic = BusinessLogicLayer.EMRForms.NASQIC.GetAllPreNASQIC(appId, patId);
                return Json(pastnasqic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis



        //Print:
        [HttpGet]
        public ActionResult PrintNASQIC(int nasqId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NASQIC print = BusinessLogicLayer.EMRForms.NASQIC.GetPrintNASQIC(nasqId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "qic.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NAS-QIC Claim with nasqId = {nasqId}"
                    });

                    return View("PrintNASQIC", print);
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

        #endregion

        #region NASQIC  CRUD Operations
        //CREATE:NASQIC

        public PartialViewResult CreateNASQIC()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NASQIC nasqic = new NASQIC();
                    return PartialView("CreateNASQIC", nasqic);
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
        public ActionResult InsertNASQIC(NASQIC data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.nasq_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNASQIC(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NASQIC.InsertUpdateNASQIC(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NAS-QIC Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: NASQIC
        [HttpGet]
        public PartialViewResult EditNASQIC(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NASQIC nasqic = BusinessLogicLayer.EMRForms.NASQIC.GetAllNASQIC(appId).FirstOrDefault();
                    return PartialView("EditNASQIC", nasqic);
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
        public ActionResult UpdateNASQIC(NASQIC data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.nasq_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNASQIC(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NASQIC.InsertUpdateNASQIC(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: NASQIC
        [HttpPost]
        public ActionResult DeleteNASQIC(int nasqId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int nasq_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMRForms.NASQIC.DeleteNASQIC(nasqId, nasq_madeby);

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
        #endregion

        #region SAICO (Page Load)
        public PartialViewResult SAICO()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                SAICO SAICO = new SAICO();
                return PartialView("SAICO", SAICO);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: SAICO Claim
        public JsonResult GetAllSAICO(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SAICO> pastsaico = BusinessLogicLayer.EMRForms.SAICO.GetAllSAICO(appId);

                return Json(pastsaico, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreSAICO(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SAICO> pastsaico = BusinessLogicLayer.EMRForms.SAICO.GetAllPreSAICO(appId, patId);
                return Json(pastsaico, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Diagnosis



        //Print:
        [HttpGet]
        public ActionResult PrintSAICO(int sacnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    SAICO print = BusinessLogicLayer.EMRForms.SAICO.GetPrintSAICO(sacnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "saico.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NAS-QIC Claim with sacnId = {sacnId}"
                    });

                    return View("PrintSAICO", print);
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

        #endregion

        #region SAICO  CRUD Operations
        //CREATE:SAICO

        public PartialViewResult CreateSAICO()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    SAICO saico = new SAICO();
                    return PartialView("CreateSAICO", saico);
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
        public ActionResult InsertSAICO(SAICO data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sacn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidSAICO(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.SAICO.InsertUpdateSAICO(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NAS-QIC Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: SAICO
        [HttpGet]
        public PartialViewResult EditSAICO(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    SAICO saico = BusinessLogicLayer.EMRForms.SAICO.GetAllSAICO(appId).FirstOrDefault();
                    return PartialView("EditSAICO", saico);
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
        public ActionResult UpdateSAICO(SAICO data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sacn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidSAICO(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.SAICO.InsertUpdateSAICO(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: SAICO
        [HttpPost]
        public ActionResult DeleteSAICO(int sacnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int sacn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMRForms.SAICO.DeleteSAICO(sacnId, sacn_madeby);

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
        #endregion

        #region Wamped (Page Load)
        public PartialViewResult Wamped()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Wamped Wamped = new Wamped();
                return PartialView("Wamped", Wamped);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Wamped Claim
        public JsonResult GetAllWamped(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Wamped> pastwamped = BusinessLogicLayer.EMRForms.Wamped.GetAllWamped(appId);

                return Json(pastwamped, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreWamped(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Wamped> pastwamped = BusinessLogicLayer.EMRForms.Wamped.GetAllPreWamped(appId, patId);
                return Json(pastwamped, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintWamped(int wapnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Wamped print = BusinessLogicLayer.EMRForms.Wamped.GetPrintWamped(wapnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "wamped2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Wamped Claim with wapnId = {wapnId}"
                    });

                    return View("PrintWamped", print);
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

        #endregion 

        #region Wamped  CRUD Operations
        //CREATE:Wamped

        public PartialViewResult CreateWamped()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Wamped wamped = new Wamped();
                    return PartialView("CreateWamped", wamped);
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
        public ActionResult InsertWamped(Wamped data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.wapn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Wamped.InsertUpdateWamped(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Wamped Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Wamped
        [HttpGet]
        public PartialViewResult EditWamped(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Wamped allergy = BusinessLogicLayer.EMRForms.Wamped.GetAllWamped(appId).FirstOrDefault();
                    return PartialView("EditWamped", allergy);
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
        public ActionResult UpdateWamped(Wamped data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.wapn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Wamped.InsertUpdateWamped(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Wamped
        [HttpPost]
        public ActionResult DeleteWamped(int wapnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int wapn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Wamped.DeleteWamped(wapnId, wapn_madeby);

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
        #endregion

        #region Orient (Page Load)
        public PartialViewResult Orient()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Orient Orient = new Orient();
                return PartialView("Orient", Orient);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Orient Claim
        public JsonResult GetAllOrient(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Orient> pastorient = BusinessLogicLayer.EMRForms.Orient.GetAllOrient(appId);
                return Json(pastorient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreOrient(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Orient> pastorient = BusinessLogicLayer.EMRForms.Orient.GetAllPreOrient(appId, patId);
                return Json(pastorient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintOrient(int orntId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Orient print = BusinessLogicLayer.EMRForms.Orient.GetPrintOrient(orntId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "orient.jpg");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Orient Claim with orntId = {orntId}"
                    });

                    return View("PrintOrient", print);
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

        #endregion

        #region Orient  CRUD Operations
        //CREATE:Orient

        public PartialViewResult CreateOrient()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Orient orient = new Orient();
                    return PartialView("CreateOrient", orient);
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
        public ActionResult InsertOrient(Orient data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ornt_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Orient.InsertUpdateOrient(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Orient Form already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Orient
        [HttpGet]
        public PartialViewResult EditOrient(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Orient allergy = BusinessLogicLayer.EMRForms.Orient.GetAllOrient(appId).FirstOrDefault();
                    return PartialView("EditOrient", allergy);
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
        public ActionResult UpdateOrient(Orient data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ornt_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidOrient(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.Orient.InsertUpdateOrient(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: Orient
        [HttpPost]
        public ActionResult DeleteOrient(int orntId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ornt_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Orient.DeleteOrient(orntId, ornt_madeby);

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
        #endregion

        #region QICNAS (Page Load)
        public PartialViewResult QICNAS()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                QICNAS QICNAS = new QICNAS();
                return PartialView("QICNAS", QICNAS);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: QICNAS Claim
        public JsonResult GetAllQICNAS(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<QICNAS> pastqicnas = BusinessLogicLayer.EMRForms.QICNAS.GetAllQICNAS(appId);

                return Json(pastqicnas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreQICNAS(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<QICNAS> pastqicnas = BusinessLogicLayer.EMRForms.QICNAS.GetAllPreQICNAS(appId, patId);
                return Json(pastqicnas, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintQICNAS(int qnasId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    QICNAS print = BusinessLogicLayer.EMRForms.QICNAS.GetPrintQICNAS(qnasId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "qicnas.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed QICNAS Claim with qnasId = {qnasId}"
                    });

                    return View("PrintQICNAS", print);
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

        #endregion 

        #region QICNAS  CRUD Operations
        //CREATE:QICNAS

        public PartialViewResult CreateQICNAS()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    QICNAS qicnas = new QICNAS();
                    return PartialView("CreateQICNAS", qicnas);
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
        public ActionResult InsertQICNAS(QICNAS data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.qnas_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.QICNAS.InsertUpdateQICNAS(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "QICNAS Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: QICNAS
        [HttpGet]
        public PartialViewResult EditQICNAS(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    QICNAS allergy = BusinessLogicLayer.EMRForms.QICNAS.GetAllQICNAS(appId).FirstOrDefault();
                    return PartialView("EditQICNAS", allergy);
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
        public ActionResult UpdateQICNAS(QICNAS data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.qnas_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.QICNAS.InsertUpdateQICNAS(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: QICNAS
        [HttpPost]
        public ActionResult DeleteQICNAS(int qnasId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int qnas_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.QICNAS.DeleteQICNAS(qnasId, qnas_madeby);

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
        #endregion

        #region Gulfcare (Page Load)
        public PartialViewResult Gulfcare()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Gulfcare Gulfcare = new Gulfcare();
                return PartialView("Gulfcare", Gulfcare);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Gulfcare Claim
        public JsonResult GetAllGulfcare(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Gulfcare> pastgulfcare = BusinessLogicLayer.EMRForms.Gulfcare.GetAllGulfcare(appId);

                return Json(pastgulfcare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreGulfcare(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Gulfcare> pastgulfcare = BusinessLogicLayer.EMRForms.Gulfcare.GetAllPreGulfcare(appId, patId);
                return Json(pastgulfcare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintGulfcare(int gucnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Gulfcare print = BusinessLogicLayer.EMRForms.Gulfcare.GetPrintGulfcare(gucnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "gulfcare.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Gulfcare Claim with gucnId = {gucnId}"
                    });

                    return View("PrintGulfcare", print);
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

        #endregion 

        #region Gulfcare  CRUD Operations
        //CREATE:Gulfcare

        public PartialViewResult CreateGulfcare()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Gulfcare gulfcare = new Gulfcare();
                    return PartialView("CreateGulfcare", gulfcare);
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
        public ActionResult InsertGulfcare(Gulfcare data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.gucn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Gulfcare.InsertUpdateGulfcare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Gulfcare Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Gulfcare
        [HttpGet]
        public PartialViewResult EditGulfcare(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Gulfcare allergy = BusinessLogicLayer.EMRForms.Gulfcare.GetAllGulfcare(appId).FirstOrDefault();
                    return PartialView("EditGulfcare", allergy);
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
        public ActionResult UpdateGulfcare(Gulfcare data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.gucn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Gulfcare.InsertUpdateGulfcare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Gulfcare
        [HttpPost]
        public ActionResult DeleteGulfcare(int gucnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int gucn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Gulfcare.DeleteGulfcare(gucnId, gucn_madeby);

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
        #endregion

        #region Goldstar (Page Load)
        public PartialViewResult Goldstar()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Goldstar Goldstar = new Goldstar();
                return PartialView("Goldstar", Goldstar);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Goldstar Claim
        public JsonResult GetAllGoldstar(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Goldstar> pastgoldstar = BusinessLogicLayer.EMRForms.Goldstar.GetAllGoldstar(appId);

                return Json(pastgoldstar, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreGoldstar(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Goldstar> pastgoldstar = BusinessLogicLayer.EMRForms.Goldstar.GetAllPreGoldstar(appId, patId);
                return Json(pastgoldstar, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintGoldstar(int cgsnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Goldstar print = BusinessLogicLayer.EMRForms.Goldstar.GetPrintGoldstar(cgsnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "goldstar.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Goldstar Claim with cgsnId = {cgsnId}"
                    });

                    return View("PrintGoldstar", print);
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

        #endregion 

        #region Goldstar  CRUD Operations
        //CREATE:Goldstar

        public PartialViewResult CreateGoldstar()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Goldstar goldstar = new Goldstar();
                    return PartialView("CreateGoldstar", goldstar);
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
        public ActionResult InsertGoldstar(Goldstar data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cgsn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Goldstar.InsertUpdateGoldstar(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Goldstar Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Goldstar
        [HttpGet]
        public PartialViewResult EditGoldstar(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Goldstar allergy = BusinessLogicLayer.EMRForms.Goldstar.GetAllGoldstar(appId).FirstOrDefault();
                    return PartialView("EditGoldstar", allergy);
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
        public ActionResult UpdateGoldstar(Goldstar data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cgsn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Goldstar.InsertUpdateGoldstar(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Goldstar
        [HttpPost]
        public ActionResult DeleteGoldstar(int cgsnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cgsn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Goldstar.DeleteGoldstar(cgsnId, cgsn_madeby);

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
        #endregion

        #region HealthInternational (Page Load)
        public PartialViewResult HealthInternational()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                HealthInternational HealthInternational = new HealthInternational();
                return PartialView("HealthInternational", HealthInternational);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: HealthInternational Claim
        public JsonResult GetAllHealthInternational(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<HealthInternational> pasthealthinternational = BusinessLogicLayer.EMRForms.HealthInternational.GetAllHealthInternational(appId);

                return Json(pasthealthinternational, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreHealthInternational(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<HealthInternational> pasthealthinternational = BusinessLogicLayer.EMRForms.HealthInternational.GetAllPreHealthInternational(appId, patId);
                return Json(pasthealthinternational, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintHealthInternational(int chinId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    HealthInternational print = BusinessLogicLayer.EMRForms.HealthInternational.GetPrintHealthInternational(chinId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "healthinternational2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed HealthInternational Claim with chinId = {chinId}"
                    });

                    return View("PrintHealthInternational", print);
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

        #endregion 

        #region HealthInternational  CRUD Operations
        //CREATE:HealthInternational

        public PartialViewResult CreateHealthInternational()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    HealthInternational healthinternational = new HealthInternational();
                    return PartialView("CreateHealthInternational", healthinternational);
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
        public ActionResult InsertHealthInternational(HealthInternational data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.chin_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.HealthInternational.InsertUpdateHealthInternational(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "HealthInternational Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: HealthInternational
        [HttpGet]
        public PartialViewResult EditHealthInternational(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    HealthInternational allergy = BusinessLogicLayer.EMRForms.HealthInternational.GetAllHealthInternational(appId).FirstOrDefault();
                    return PartialView("EditHealthInternational", allergy);
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
        public ActionResult UpdateHealthInternational(HealthInternational data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.chin_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.HealthInternational.InsertUpdateHealthInternational(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: HealthInternational
        [HttpPost]
        public ActionResult DeleteHealthInternational(int chinId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int chin_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.HealthInternational.DeleteHealthInternational(chinId, chin_madeby);

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
        #endregion

        #region NasDental (Page Load)
        public PartialViewResult NasDental()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NasDental NasDental = new NasDental();
                return PartialView("NasDental", NasDental);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: NasDental Claim
        public JsonResult GetAllNasDental(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasDental> pastsasdental = BusinessLogicLayer.EMRForms.NasDental.GetAllNasDental(appId);

                return Json(pastsasdental, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNasDental(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasDental> pastsasdental = BusinessLogicLayer.EMRForms.NasDental.GetAllPreNasDental(appId, patId);
                return Json(pastsasdental, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNasDental(int cndnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NasDental print = BusinessLogicLayer.EMRForms.NasDental.GetPrintNasDental(cndnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "sasdental.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NasDental Claim with cndnId = {cndnId}"
                    });

                    return View("PrintNasDental", print);
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

        #endregion 

        #region NasDental  CRUD Operations
        //CREATE:NasDental

        public PartialViewResult CreateNasDental()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NasDental sasdental = new NasDental();
                    return PartialView("CreateNasDental", sasdental);
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
        public ActionResult InsertNasDental(NasDental data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cndn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NasDental.InsertUpdateNasDental(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NasDental Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NasDental
        [HttpGet]
        public PartialViewResult EditNasDental(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NasDental allergy = BusinessLogicLayer.EMRForms.NasDental.GetAllNasDental(appId).FirstOrDefault();
                    return PartialView("EditNasDental", allergy);
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
        public ActionResult UpdateNasDental(NasDental data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cndn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NasDental.InsertUpdateNasDental(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: NasDental
        [HttpPost]
        public ActionResult DeleteNasDental(int cndnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cndn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NasDental.DeleteNasDental(cndnId, cndn_madeby);

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
        #endregion

        #region NasPrescription (Page Load)
        public PartialViewResult NasPrescription()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NasPrescription NasPrescription = new NasPrescription();
                return PartialView("NasPrescription", NasPrescription);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NasPrescription Claim
        public JsonResult GetAllNasPrescription(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasPrescription> pastsasdental = BusinessLogicLayer.EMRForms.NasPrescription.GetAllNasPrescription(appId);

                return Json(pastsasdental, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNasPrescription(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasPrescription> pastsasdental = BusinessLogicLayer.EMRForms.NasPrescription.GetAllPreNasPrescription(appId, patId);
                return Json(pastsasdental, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNasPrescription(int cnrnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NasPrescription print = BusinessLogicLayer.EMRForms.NasPrescription.GetPrintNasPrescription(cnrnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "sasdental.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NasPrescription Claim with cnrnId = {cnrnId}"
                    });

                    return View("PrintNasPrescription", print);
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

        #endregion 

        #region NasPrescription  CRUD Operations
        //CREATE:NasPrescription

        public PartialViewResult CreateNasPrescription()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NasPrescription sasdental = new NasPrescription();
                    return PartialView("CreateNasPrescription", sasdental);
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
        public ActionResult InsertNasPrescription(NasPrescription data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cnrn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NasPrescription.InsertUpdateNasPrescription(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NasPrescription Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NasPrescription
        [HttpGet]
        public PartialViewResult EditNasPrescription(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NasPrescription allergy = BusinessLogicLayer.EMRForms.NasPrescription.GetAllNasPrescription(appId).FirstOrDefault();
                    return PartialView("EditNasPrescription", allergy);
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
        public ActionResult UpdateNasPrescription(NasPrescription data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cnrn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NasPrescription.InsertUpdateNasPrescription(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: NasPrescription
        [HttpPost]
        public ActionResult DeleteNasPrescription(int cnrnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cnrn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NasPrescription.DeleteNasPrescription(cnrnId, cnrn_madeby);

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
        #endregion

        #region OmanDental (Page Load)
        public PartialViewResult OmanDental()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                OmanDental omandental = new OmanDental();
                return PartialView("OmanDental", omandental);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: OmanDental Claim
        public JsonResult GetAllOmanDental(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<OmanDental> pastadnic = BusinessLogicLayer.EMRForms.OmanDental.GetAllOmanDental(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreOmanDental(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<OmanDental> pastomandental = BusinessLogicLayer.EMRForms.OmanDental.GetAllPreOmanDental(appId, patId);
                return Json(pastomandental, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        //Print:
        [HttpGet]
        public ActionResult PrintOmanDental(int codnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    OmanDental print = BusinessLogicLayer.EMRForms.OmanDental.GetPrintOmanDental(codnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "omandental2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed OmanDental Claim with codnId = {codnId}"
                    });

                    return View("PrintOmanDental", print);
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

        #endregion 

        #region OmanDental  CRUD Operations
        //CREATE:OmanDental

        public PartialViewResult CreateOmanDental()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    OmanDental omandental = new OmanDental();
                    return PartialView("CreateOmanDental", omandental);
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
        public ActionResult InsertOmanDental(OmanDental data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.codn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.OmanDental.InsertUpdateOmanDental(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "OmanDental Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: OmanDental
        [HttpGet]
        public PartialViewResult EditOmanDental(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    OmanDental allergy = BusinessLogicLayer.EMRForms.OmanDental.GetAllOmanDental(appId).FirstOrDefault();
                    return PartialView("EditOmanDental", allergy);
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
        public ActionResult UpdateOmanDental(OmanDental data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.codn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.OmanDental.InsertUpdateOmanDental(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: OmanDental
        [HttpPost]
        public ActionResult DeleteOmanDental(int codnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int codn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.OmanDental.DeleteOmanDental(codnId, codn_madeby);

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
        #endregion

        #region NasDarAlTakaful (Page Load)
        public PartialViewResult NasDarAlTakaful()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NasDarAlTakaful NasDarAlTakaful = new NasDarAlTakaful();
                return PartialView("NasDarAlTakaful", NasDarAlTakaful);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NasDarAlTakaful Claim
        public JsonResult GetAllNasDarAlTakaful(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasDarAlTakaful> pastnasdaraltakaful = BusinessLogicLayer.EMRForms.NasDarAlTakaful.GetAllNasDarAlTakaful(appId);

                return Json(pastnasdaraltakaful, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNasDarAlTakaful(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NasDarAlTakaful> pastnasdaraltakaful = BusinessLogicLayer.EMRForms.NasDarAlTakaful.GetAllPreNasDarAlTakaful(appId, patId);
                return Json(pastnasdaraltakaful, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNasDarAlTakaful(int ndtnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NasDarAlTakaful print = BusinessLogicLayer.EMRForms.NasDarAlTakaful.GetPrintNasDarAlTakaful(ndtnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "nasdaraltakaful.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NasDarAlTakaful Claim with ndtnId = {ndtnId}"
                    });

                    return View("PrintNasDarAlTakaful", print);
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

        #endregion 

        #region NasDarAlTakaful  CRUD Operations
        //CREATE:NasDarAlTakaful

        public PartialViewResult CreateNasDarAlTakaful()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NasDarAlTakaful nasdaraltakaful = new NasDarAlTakaful();
                    return PartialView("CreateNasDarAlTakaful", nasdaraltakaful);
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
        public ActionResult InsertNasDarAlTakaful(NasDarAlTakaful data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.ndtn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NasDarAlTakaful.InsertUpdateNasDarAlTakaful(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NasDarAlTakaful Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NasDarAlTakaful
        [HttpGet]
        public PartialViewResult EditNasDarAlTakaful(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NasDarAlTakaful allergy = BusinessLogicLayer.EMRForms.NasDarAlTakaful.GetAllNasDarAlTakaful(appId).FirstOrDefault();
                    return PartialView("EditNasDarAlTakaful", allergy);
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
        public ActionResult UpdateNasDarAlTakaful(NasDarAlTakaful data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.ndtn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NasDarAlTakaful.InsertUpdateNasDarAlTakaful(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: NasDarAlTakaful
        [HttpPost]
        public ActionResult DeleteNasDarAlTakaful(int ndtnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int ndtn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NasDarAlTakaful.DeleteNasDarAlTakaful(ndtnId, ndtn_madeby);

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
        #endregion

        #region OmanInsurance (Page Load)
        public PartialViewResult OmanInsurance()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                OmanInsurance omaninsurance = new OmanInsurance();
                return PartialView("OmanInsurance", omaninsurance);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: OmanInsurance Claim
        public JsonResult GetAllOmanInsurance(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<OmanInsurance> pastadnic = BusinessLogicLayer.EMRForms.OmanInsurance.GetAllOmanInsurance(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreOmanInsurance(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<OmanInsurance> pastomaninsurance = BusinessLogicLayer.EMRForms.OmanInsurance.GetAllPreOmanInsurance(appId, patId);
                return Json(pastomaninsurance, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        //Print:
        [HttpGet]
        public ActionResult PrintOmanInsurance(int cornId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    OmanInsurance print = BusinessLogicLayer.EMRForms.OmanInsurance.GetPrintOmanInsurance(cornId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "omaninsurance2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed OmanInsurance Claim with cornId = {cornId}"
                    });

                    return View("PrintOmanInsurance", print);
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

        #endregion 

        #region OmanInsurance  CRUD Operations
        //CREATE:OmanInsurance

        public PartialViewResult CreateOmanInsurance()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    OmanInsurance omaninsurance = new OmanInsurance();
                    return PartialView("CreateOmanInsurance", omaninsurance);
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
        public ActionResult InsertOmanInsurance(OmanInsurance data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.corn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.OmanInsurance.InsertUpdateOmanInsurance(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "OmanInsurance Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: OmanInsurance
        [HttpGet]
        public PartialViewResult EditOmanInsurance(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    OmanInsurance allergy = BusinessLogicLayer.EMRForms.OmanInsurance.GetAllOmanInsurance(appId).FirstOrDefault();
                    return PartialView("EditOmanInsurance", allergy);
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
        public ActionResult UpdateOmanInsurance(OmanInsurance data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.corn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.OmanInsurance.InsertUpdateOmanInsurance(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: OmanInsurance
        [HttpPost]
        public ActionResult DeleteOmanInsurance(int cornId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int corn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.OmanInsurance.DeleteOmanInsurance(cornId, corn_madeby);

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
        #endregion

        #region Union (Page Load)
        public PartialViewResult Union()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Union Union = new Union();
                return PartialView("Union", Union);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Union Claim
        public JsonResult GetAllUnion(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Union> pastunion = BusinessLogicLayer.EMRForms.Union.GetAllUnion(appId);

                return Json(pastunion, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreUnion(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Union> pastunion = BusinessLogicLayer.EMRForms.Union.GetAllPreUnion(appId, patId);
                return Json(pastunion, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintUnion(int curnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Union print = BusinessLogicLayer.EMRForms.Union.GetPrintUnion(curnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "union2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Union Claim with curnId = {curnId}"
                    });

                    return View("PrintUnion", print);
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

        #endregion

        #region Union  CRUD Operations
        //CREATE:Union

        public PartialViewResult CreateUnion()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Union union = new Union();
                    return PartialView("CreateUnion", union);
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
        public ActionResult InsertUnion(Union data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.curn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Union.InsertUpdateUnion(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Union Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Union
        [HttpGet]
        public PartialViewResult EditUnion(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Union allergy = BusinessLogicLayer.EMRForms.Union.GetAllUnion(appId).FirstOrDefault();
                    return PartialView("EditUnion", allergy);
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
        public ActionResult UpdateUnion(Union data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.curn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Union.InsertUpdateUnion(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Union
        [HttpPost]
        public ActionResult DeleteUnion(int curnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int curn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Union.DeleteUnion(curnId, curn_madeby);

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
        #endregion

        #region NextcareOrient (Page Load)
        public PartialViewResult NextcareOrient()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NextcareOrient NextcareOrient = new NextcareOrient();
                return PartialView("NextcareOrient", NextcareOrient);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NextcareOrient Claim
        public JsonResult GetAllNextcareOrient(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NextcareOrient> pastnextcareorient = BusinessLogicLayer.EMRForms.NextcareOrient.GetAllNextcareOrient(appId);

                return Json(pastnextcareorient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNextcareOrient(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NextcareOrient> pastnextcareorient = BusinessLogicLayer.EMRForms.NextcareOrient.GetAllPreNextcareOrient(appId, patId);
                return Json(pastnextcareorient, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNextcareOrient(int cnonId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NextcareOrient print = BusinessLogicLayer.EMRForms.NextcareOrient.GetPrintNextcareOrient(cnonId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "nextcareorient2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NextcareOrient Claim with cnonId = {cnonId}"
                    });

                    return View("PrintNextcareOrient", print);
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

        #endregion

        #region NextcareOrient  CRUD Operations
        //CREATE:NextcareOrient

        public PartialViewResult CreateNextcareOrient()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NextcareOrient nextcareorient = new NextcareOrient();
                    return PartialView("CreateNextcareOrient", nextcareorient);
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
        public ActionResult InsertNextcareOrient(NextcareOrient data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cnon_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NextcareOrient.InsertUpdateNextcareOrient(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NextcareOrient Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NextcareOrient
        [HttpGet]
        public PartialViewResult EditNextcareOrient(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NextcareOrient allergy = BusinessLogicLayer.EMRForms.NextcareOrient.GetAllNextcareOrient(appId).FirstOrDefault();
                    return PartialView("EditNextcareOrient", allergy);
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
        public ActionResult UpdateNextcareOrient(NextcareOrient data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cnon_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NextcareOrient.InsertUpdateNextcareOrient(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: NextcareOrient
        [HttpPost]
        public ActionResult DeleteNextcareOrient(int cnonId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cnon_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NextcareOrient.DeleteNextcareOrient(cnonId, cnon_madeby);

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
        #endregion

        #region NextcareMajid (Page Load)
        public PartialViewResult NextcareMajid()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NextcareMajid NextcareMajid = new NextcareMajid();
                return PartialView("NextcareMajid", NextcareMajid);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NextcareMajid Claim
        public JsonResult GetAllNextcareMajid(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NextcareMajid> pastnextcaremajid = BusinessLogicLayer.EMRForms.NextcareMajid.GetAllNextcareMajid(appId);

                return Json(pastnextcaremajid, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNextcareMajid(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NextcareMajid> pastnextcaremajid = BusinessLogicLayer.EMRForms.NextcareMajid.GetAllPreNextcareMajid(appId, patId);
                return Json(pastnextcaremajid, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNextcareMajid(int cnmnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NextcareMajid print = BusinessLogicLayer.EMRForms.NextcareMajid.GetPrintNextcareMajid(cnmnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "nextcaremajid2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NextcareMajid Claim with cnmnId = {cnmnId}"
                    });

                    return View("PrintNextcareMajid", print);
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

        #endregion

        #region NextcareMajid  CRUD Operations
        //CREATE:NextcareMajid

        public PartialViewResult CreateNextcareMajid()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NextcareMajid nextcaremajid = new NextcareMajid();
                    return PartialView("CreateNextcareMajid", nextcaremajid);
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
        public ActionResult InsertNextcareMajid(NextcareMajid data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cnmn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NextcareMajid.InsertUpdateNextcareMajid(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NextcareMajid Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NextcareMajid
        [HttpGet]
        public PartialViewResult EditNextcareMajid(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NextcareMajid allergy = BusinessLogicLayer.EMRForms.NextcareMajid.GetAllNextcareMajid(appId).FirstOrDefault();
                    return PartialView("EditNextcareMajid", allergy);
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
        public ActionResult UpdateNextcareMajid(NextcareMajid data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cnmn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NextcareMajid.InsertUpdateNextcareMajid(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: NextcareMajid
        [HttpPost]
        public ActionResult DeleteNextcareMajid(int cnmnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cnmn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NextcareMajid.DeleteNextcareMajid(cnmnId, cnmn_madeby);

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
        #endregion

        #region NextcareAsnic (Page Load)
        public PartialViewResult NextcareAsnic()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NextcareAsnic NextcareAsnic = new NextcareAsnic();
                return PartialView("NextcareAsnic", NextcareAsnic);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NextcareAsnic Claim
        public JsonResult GetAllNextcareAsnic(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NextcareAsnic> pastnextcareasnic = BusinessLogicLayer.EMRForms.NextcareAsnic.GetAllNextcareAsnic(appId);

                return Json(pastnextcareasnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNextcareAsnic(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NextcareAsnic> pastnextcareasnic = BusinessLogicLayer.EMRForms.NextcareAsnic.GetAllPreNextcareAsnic(appId, patId);
                return Json(pastnextcareasnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintNextcareAsnic(int cnanId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NextcareAsnic print = BusinessLogicLayer.EMRForms.NextcareAsnic.GetPrintNextcareAsnic(cnanId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "nextcareasnic2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NextcareAsnic Claim with cnanId = {cnanId}"
                    });

                    return View("PrintNextcareAsnic", print);
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

        #endregion

        #region NextcareAsnic  CRUD Operations
        //CREATE:NextcareAsnic

        public PartialViewResult CreateNextcareAsnic()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NextcareAsnic nextcareasnic = new NextcareAsnic();
                    return PartialView("CreateNextcareAsnic", nextcareasnic);
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
        public ActionResult InsertNextcareAsnic(NextcareAsnic data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cnan_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NextcareAsnic.InsertUpdateNextcareAsnic(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NextcareAsnic Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: NextcareAsnic
        [HttpGet]
        public PartialViewResult EditNextcareAsnic(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NextcareAsnic allergy = BusinessLogicLayer.EMRForms.NextcareAsnic.GetAllNextcareAsnic(appId).FirstOrDefault();
                    return PartialView("EditNextcareAsnic", allergy);
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
        public ActionResult UpdateNextcareAsnic(NextcareAsnic data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cnan_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.NextcareAsnic.InsertUpdateNextcareAsnic(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: NextcareAsnic
        [HttpPost]
        public ActionResult DeleteNextcareAsnic(int cnanId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cnan_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.NextcareAsnic.DeleteNextcareAsnic(cnanId, cnan_madeby);

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
        #endregion

        #region Maxcare (Page Load)
        public PartialViewResult Maxcare()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Maxcare Maxcare = new Maxcare();
                return PartialView("Maxcare", Maxcare);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Maxcare Claim
        public JsonResult GetAllMaxcare(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Maxcare> pastmaxcare = BusinessLogicLayer.EMRForms.Maxcare.GetAllMaxcare(appId);

                return Json(pastmaxcare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreMaxcare(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Maxcare> pastmaxcare = BusinessLogicLayer.EMRForms.Maxcare.GetAllPreMaxcare(appId, patId);
                return Json(pastmaxcare, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Print:
        [HttpGet]
        public ActionResult PrintMaxcare(int maxnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Maxcare print = BusinessLogicLayer.EMRForms.Maxcare.GetPrintMaxcare(maxnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "maxcare2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Maxcare Claim with maxnId = {maxnId}"
                    });

                    return View("PrintMaxcare", print);
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

        #endregion

        #region Maxcare  CRUD Operations
        //CREATE:Maxcare

        public PartialViewResult CreateMaxcare()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Maxcare maxcare = new Maxcare();
                    return PartialView("CreateMaxcare", maxcare);
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
        public ActionResult InsertMaxcare(Maxcare data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.maxn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Maxcare.InsertUpdateMaxcare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Maxcare Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Maxcare
        [HttpGet]
        public PartialViewResult EditMaxcare(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Maxcare allergy = BusinessLogicLayer.EMRForms.Maxcare.GetAllMaxcare(appId).FirstOrDefault();
                    return PartialView("EditMaxcare", allergy);
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
        public ActionResult UpdateMaxcare(Maxcare data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.maxn_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Maxcare.InsertUpdateMaxcare(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Maxcare
        [HttpPost]
        public ActionResult DeleteMaxcare(int maxnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int maxn_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Maxcare.DeleteMaxcare(maxnId, maxn_madeby);

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
        #endregion

        #region Cowan (Page Load)
        //public ActionResult Cowan()
        //{
        //    int Action = (int)Actions.Read;

        //    if (PageControl.haveAccess(PageId, Action))
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public PartialViewResult Cowan()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Cowan Cowan = new Cowan();
                return PartialView("Cowan", Cowan);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: Cowan Claim
        public JsonResult GetAllCowan(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Cowan> pastadnic = BusinessLogicLayer.EMRForms.Cowan.GetAllCowan(appId);

                return Json(pastadnic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreCowan(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Cowan> pastCowan = BusinessLogicLayer.EMRForms.Cowan.GetAllPreCowan(appId, patId);
                return Json(pastCowan, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintCowan(int cownId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Cowan print = BusinessLogicLayer.EMRForms.Cowan.GetPrintCowan(cownId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "Cowan2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Cowan Claim with cownId = {cownId}"
                    });

                    return View("PrintCowan", print);
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

        #endregion

        #region Cowan  CRUD Operations
        //CREATE:Cowan

        public PartialViewResult CreateCowan()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Cowan Cowan = new Cowan();
                    return PartialView("CreateCowan", Cowan);
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
        public ActionResult InsertCowan(Cowan data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cown_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Cowan.InsertUpdateCowan(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Cowan Form already exists!" }, JsonRequestBehavior.AllowGet);
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


        // Edit: Cowan
        [HttpGet]
        public PartialViewResult EditCowan(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Cowan allergy = BusinessLogicLayer.EMRForms.Cowan.GetAllCowan(appId).FirstOrDefault();
                    return PartialView("EditCowan", allergy);
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
        public ActionResult UpdateCowan(Cowan data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cown_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Cowan.InsertUpdateCowan(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Cowan
        [HttpPost]
        public ActionResult DeleteCowan(int cownId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cown_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Cowan.DeleteCowan(cownId, cown_madeby);

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
        #endregion

        #region NASNLGIC (Page Load)
        public PartialViewResult NASNLGIC()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                NASNLGIC NASNLGIC = new NASNLGIC();
                return PartialView("NASNLGIC", NASNLGIC);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // GET: NASNLGIC Claim
        public JsonResult GetAllNASNLGIC(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NASNLGIC> pastnasnlgic = BusinessLogicLayer.EMRForms.NASNLGIC.GetAllNASNLGIC(appId);

                return Json(pastnasnlgic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Previous History
        public JsonResult GetAllPreNASNLGIC(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NASNLGIC> pastnasnlgic = BusinessLogicLayer.EMRForms.NASNLGIC.GetAllPreNASNLGIC(appId, patId);
                return Json(pastnasnlgic, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Print:
        [HttpGet]
        public ActionResult PrintNASNLGIC(int nalnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    NASNLGIC print = BusinessLogicLayer.EMRForms.NASNLGIC.GetPrintNASNLGIC(nalnId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "qic.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed NAS-QIC Claim with nalnId = {nalnId}"
                    });

                    return View("PrintNASNLGIC", print);
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

        #endregion

        #region NASNLGIC  CRUD Operations
        //CREATE:NASNLGIC

        public PartialViewResult CreateNASNLGIC()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NASNLGIC nasnlgic = new NASNLGIC();
                    return PartialView("CreateNASNLGIC", nasnlgic);
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
        public ActionResult InsertNASNLGIC(NASNLGIC data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.naln_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNASNLGIC(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NASNLGIC.InsertUpdateNASNLGIC(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "NAS-QIC Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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


        // Edit: NASNLGIC
        [HttpGet]
        public PartialViewResult EditNASNLGIC(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NASNLGIC nasnlgic = BusinessLogicLayer.EMRForms.NASNLGIC.GetAllNASNLGIC(appId).FirstOrDefault();
                    return PartialView("EditNASNLGIC", nasnlgic);
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
        public ActionResult UpdateNASNLGIC(NASNLGIC data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.naln_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    //if (SecurityLayer.FormValidations.EMRForms.ReimbursementForms.isValidNASNLGIC(data, out errors))
                    //{
                    isInserted = BusinessLogicLayer.EMRForms.NASNLGIC.InsertUpdateNASNLGIC(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    //}
                    //else
                    //{
                    //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    //}
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

        // Delete: NASNLGIC
        [HttpPost]
        public ActionResult DeleteNASNLGIC(int nalnId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int naln_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMRForms.NASNLGIC.DeleteNASNLGIC(nalnId, naln_madeby);

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
        #endregion

        #region EmiratesInsurance (Page Load)
        public PartialViewResult EmiratesInsurance()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                EmiratesInsurance EmiratesInsurance = new EmiratesInsurance();
                return PartialView("EmiratesInsurance", EmiratesInsurance);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: EmiratesInsurance Claim
        public JsonResult GetAllEmiratesInsurance(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmiratesInsurance> pastemiratesinsurance = BusinessLogicLayer.EMRForms.EmiratesInsurance.GetAllEmiratesInsurance(appId);

                return Json(pastemiratesinsurance, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreEmiratesInsurance(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmiratesInsurance> pastEmiratesInsurance = BusinessLogicLayer.EMRForms.EmiratesInsurance.GetAllPreEmiratesInsurance(appId, patId);
                return Json(pastEmiratesInsurance, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintEmiratesInsurance(int cceId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    EmiratesInsurance print = BusinessLogicLayer.EMRForms.EmiratesInsurance.GetPrintEmiratesInsurance(cceId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "EmiratesInsurance2.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed EmiratesInsurance Claim with cceId = {cceId}"
                    });

                    return View("PrintEmiratesInsurance", print);
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
        #endregion

        #region EmiratesInsurance  CRUD Operations
        //CREATE:EmiratesInsurance
        public PartialViewResult CreateEmiratesInsurance()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EmiratesInsurance EmiratesInsurance = new EmiratesInsurance();
                    return PartialView("CreateEmiratesInsurance", EmiratesInsurance);
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
        public ActionResult InsertEmiratesInsurance(EmiratesInsurance data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cce_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.EmiratesInsurance.InsertUpdateEmiratesInsurance(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "EmiratesInsurance Form already exists!" }, JsonRequestBehavior.AllowGet);
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
        //Edit: EmiratesInsurance
        [HttpGet]
        public PartialViewResult EditEmiratesInsurance(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EmiratesInsurance allergy = BusinessLogicLayer.EMRForms.EmiratesInsurance.GetAllEmiratesInsurance(appId).FirstOrDefault();
                    return PartialView("EditEmiratesInsurance", allergy);
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
        public ActionResult UpdateEmiratesInsurance(EmiratesInsurance data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cce_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.EmiratesInsurance.InsertUpdateEmiratesInsurance(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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
        //Delete: EmiratesInsurance
        [HttpPost]
        public ActionResult DeleteEmiratesInsurance(int cceId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cce_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.EmiratesInsurance.DeleteEmiratesInsurance(cceId, cce_madeby);

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
        #endregion

        #region Mapfre (Page Load)
        public PartialViewResult Mapfre()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Mapfre Mapfre = new Mapfre();
                return PartialView("Mapfre", Mapfre);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: Mapfre Claim
        public JsonResult GetAllMapfre(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Mapfre> pastmapfre = BusinessLogicLayer.EMRForms.Mapfre.GetAllMapfre(appId);

                return Json(pastmapfre, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreMapfre(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Mapfre> pastMapfre = BusinessLogicLayer.EMRForms.Mapfre.GetAllPreMapfre(appId, patId);
                return Json(pastMapfre, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintMapfre(int maprId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Mapfre print = BusinessLogicLayer.EMRForms.Mapfre.GetPrintMapfre(maprId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "mapfre1.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Mapfre Claim with maprId = {maprId}"
                    });

                    return View("PrintMapfre", print);
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
        #endregion

        #region Mapfre  CRUD Operations
        //CREATE:Mapfre
        public PartialViewResult CreateMapfre()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Mapfre Mapfre = new Mapfre();
                    return PartialView("CreateMapfre", Mapfre);
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
        public ActionResult InsertMapfre(Mapfre data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.mapr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.Mapfre.InsertUpdateMapfre(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Mapfre Form already exists!" }, JsonRequestBehavior.AllowGet);
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
        //Edit: Mapfre
        [HttpGet]
        public PartialViewResult EditMapfre(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Mapfre allergy = BusinessLogicLayer.EMRForms.Mapfre.GetAllMapfre(appId).FirstOrDefault();
                    return PartialView("EditMapfre", allergy);
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
        public ActionResult UpdateMapfre(Mapfre data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.mapr_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.Mapfre.InsertUpdateMapfre(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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
        //Delete: Mapfre
        [HttpPost]
        public ActionResult DeleteMapfre(int maprId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int mapr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.Mapfre.DeleteMapfre(maprId, mapr_madeby);

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
        #endregion

        #region AAFIYA (Page Load)
        public PartialViewResult AAFIYA()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                AAFIYA AAFIYA = new AAFIYA();
                return PartialView("AAFIYA", AAFIYA);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        // GET: AAFIYA Claim
        public JsonResult GetAllAAFIYA(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<AAFIYA> pastaafiya = BusinessLogicLayer.EMRForms.AAFIYA.GetAllAAFIYA(appId);

                return Json(pastaafiya, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Previous History
        public JsonResult GetAllPreAAFIYA(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<AAFIYA> pastAAFIYA = BusinessLogicLayer.EMRForms.AAFIYA.GetAllPreAAFIYA(appId, patId);
                return Json(pastAAFIYA, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        //Print:
        [HttpGet]
        public ActionResult PrintAAFIYA(int ccaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    AAFIYA print = BusinessLogicLayer.EMRForms.AAFIYA.GetPrintAAFIYA(ccaId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "Reimbursement_Forms", "aafiya.png");
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed AAFIYA Claim with ccaId = {ccaId}"
                    });

                    return View("PrintAAFIYA", print);
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
        #endregion

        #region AAFIYA  CRUD Operations
        //CREATE:AAFIYA
        public PartialViewResult CreateAAFIYA()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    AAFIYA AAFIYA = new AAFIYA();
                    return PartialView("CreateAAFIYA", AAFIYA);
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
        public ActionResult InsertAAFIYA(AAFIYA data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.cca_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.EMRForms.AAFIYA.InsertUpdateAAFIYA(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "AAFIYA Form already exists!" }, JsonRequestBehavior.AllowGet);
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
        //Edit: AAFIYA
        [HttpGet]
        public PartialViewResult EditAAFIYA(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    AAFIYA allergy = BusinessLogicLayer.EMRForms.AAFIYA.GetAllAAFIYA(appId).FirstOrDefault();
                    return PartialView("EditAAFIYA", allergy);
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
        public ActionResult UpdateAAFIYA(AAFIYA data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.cca_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.EMRForms.AAFIYA.InsertUpdateAAFIYA(data);

                    if (isInserted)
                    {
                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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
        //Delete: AAFIYA
        [HttpPost]
        public ActionResult DeleteAAFIYA(int ccaId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cca_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMRForms.AAFIYA.DeleteAAFIYA(ccaId, cca_madeby);

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
        #endregion
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
} 