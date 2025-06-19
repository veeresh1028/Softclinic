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
    public class LaserMarkingController : Controller
    {
        // GET: EMR/LaserMarking

        int PageId = (int)Pages.LaserMarking;
        
        #region Botox Picture Men (Page Load)
        // GET: EMR/LaserMarking
        public ActionResult BotoxPictureMen()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Botox Picture Men Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllBotoxPictureMen(int? appId, int? lfmId,string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> BotoxPictureMen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(BotoxPictureMen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreBotoxPictureMen(int appId, int patId,string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Botox Picture Men (Page Load)

        #region Botox Picture Men  CRUD Operations
        public PartialViewResult CreateBotoxPictureMen()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking Botoxmen = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateBotoxPictureMen", Botoxmen);
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

        // upload: BotoxPictureMen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadBotoxPictureMen(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Men/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditBotoxPictureMen(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> BotoxMen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "BotoxMen");

                    return PartialView("EditBotoxPictureMen", BotoxMen.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteBotoxPictureMen(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: LaserMarking
        [HttpGet]
        public ActionResult PrintBotoxPictureMen(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Face Marking Women with lfmId = {lfmId}"
                    });

                    return View("PrintBotoxPictureMen", print);
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
        #endregion Botox Picture Men  CRUD Operations


        #region Face Marking Men (Page Load)
        // GET: EMR/Face Marking Men
        public ActionResult FaceMarkingMen()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Face arking Men Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllFaceMarkingMen(int? appId, int? lfmId ,string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> BotoxPictureMen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(BotoxPictureMen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/Face Marking Men

        public JsonResult GetPreFaceMarkingMen(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> facemen = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(facemen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Face Marking Men (Page Load)

        #region Face Marking Men  CRUD Operations
        public PartialViewResult CreateFaceMarkingMen()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking facemen = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateFaceMarkingMen", facemen);
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

        // upload: Face Marking Men
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFaceMarkingMen(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Men/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Face Marking Men
        [HttpGet]
        public PartialViewResult EditFaceMarkingMen(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> facemen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "FaceMen");

                    return PartialView("EditFaceMarkingMen", facemen.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteFaceMarkingMen(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: Face Marking Men
        [HttpGet]
        public ActionResult PrintFaceMarkingMen(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Face Marking Men with lfmId = {lfmId}"
                    });

                    return View("PrintFaceMarkingMen", print);
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
        #endregion Face Marking Men  CRUD Operations


        #region Thread Picture Men (Page Load)
        // GET: EMR/LaserMarking
        public ActionResult ThreadPictureMen()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Thread Picture Men Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllThreadPictureMen(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> ThreadPictureMen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(ThreadPictureMen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreThreadPictureMen(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Thread Picture Men (Page Load)

        #region Thread Picture Men  CRUD Operations
        public PartialViewResult CreateThreadPictureMen()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking Threadmen = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateThreadPictureMen", Threadmen);
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

        // upload: ThreadPictureMen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadThreadPictureMen(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Men/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditThreadPictureMen(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> ThreadMen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "ThreadMen");

                    return PartialView("EditThreadPictureMen", ThreadMen.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteThreadPictureMen(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: LaserMarking
        [HttpGet]
        public ActionResult PrintThreadPictureMen(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Thread Picture Men with lfmId = {lfmId}"
                    });

                    return View("PrintThreadPictureMen", print);
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
        #endregion Thread Picture Men  CRUD Operations



        #region Face Marking Women (Page Load)
        // GET: EMR/LaserMarking
        public ActionResult FaceMarkingWomen()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Face Marking Women Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllFaceMarkingWomen(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> FaceMarkingWomen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(FaceMarkingWomen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreFaceMarkingWomen(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Face Marking Women (Page Load)

        #region Face Marking Women  CRUD Operations
        public PartialViewResult CreateFaceMarkingWomen()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking FaceWomen = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateFaceMarkingWomen", FaceWomen);
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

        // upload: FaceMarkingWomen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFaceMarkingWomen(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Women/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditFaceMarkingWomen(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> FaceWomen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "FaceWomen");

                    return PartialView("EditFaceMarkingWomen", FaceWomen.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteFaceMarkingWomen(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: LaserMarking
        [HttpGet]
        public ActionResult PrintFaceMarkingWomen(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Face Marking Women with lfmId = {lfmId}"
                    });

                    return View("PrintFaceMarkingWomen", print);
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
        #endregion Face Marking Women  CRUD Operations

        #region Face Marking Filter (Page Load)
        // GET: EMR/LaserMarking
        public ActionResult FaceMarkingFilter()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Face Marking Filter Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllFaceMarkingFilter(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> FaceMarkingFilter = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(FaceMarkingFilter, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreFaceMarkingFilter(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Face Marking Filter (Page Load)

        #region Face Marking Filter  CRUD Operations
        public PartialViewResult CreateFaceMarkingFilter()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking FaceFilter = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateFaceMarkingFilter", FaceFilter);
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

        // upload: FaceMarkingFilter
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFaceMarkingFilter(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Women/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditFaceMarkingFilter(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> FaceFilter = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "FaceFilter");

                    return PartialView("EditFaceMarkingFilter", FaceFilter.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteFaceMarkingFilter(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: LaserMarking
        [HttpGet]
        public ActionResult PrintFaceMarkingFilter(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Face Marking Filter with lfmId = {lfmId}"
                    });

                    return View("PrintFaceMarkingFilter", print);
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
        #endregion Face Marking Filter  CRUD Operations


        #region Botox Picture Women (Page Load)
        // GET: EMR/LaserMarking
        public ActionResult BotoxPictureWomen()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Botox Picture Women Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllBotoxPictureWomen(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> BotoxPictureWomen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(BotoxPictureWomen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreBotoxPictureWomen(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Botox Picture Women (Page Load)

        #region Botox Picture Women  CRUD Operations
        public PartialViewResult CreateBotoxPictureWomen()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking BotoxWomen = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateBotoxPictureWomen", BotoxWomen);
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

        // upload: BotoxPictureWomen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadBotoxPictureWomen(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Women/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditBotoxPictureWomen(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> BotoxWomen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "BotoxWomen");

                    return PartialView("EditBotoxPictureWomen", BotoxWomen.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteBotoxPictureWomen(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: LaserMarking
        [HttpGet]
        public ActionResult PrintBotoxPictureWomen(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Botox Picture Women with lfmId = {lfmId}"
                    });

                    return View("PrintBotoxPictureWomen", print);
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
        #endregion Botox Picture Women  CRUD Operations


        #region Thread Picture Women (Page Load)
        // GET: EMR/LaserMarking
        public ActionResult ThreadPictureWomen()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Thread Picture Women Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllThreadPictureWomen(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> ThreadPictureWomen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(ThreadPictureWomen, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreThreadPictureWomen(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.LaserMarking.GetAllPreLaserMarking(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Thread Picture Women (Page Load)

        #region Thread Picture Women  CRUD Operations
        public PartialViewResult CreateThreadPictureWomen()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking ThreadWomen = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateThreadPictureWomen", ThreadWomen);
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

        // upload: ThreadPictureWomen
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadThreadPictureWomen(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Laser/Women/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.image.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    //data.image = path.Replace(Server.MapPath("~/"), "");
                    data.image = path.Replace(Server.MapPath("~/"), "").Replace("\\", "/");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.EMR.LaserMarking.UploadLaserMarking(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditThreadPictureWomen(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> ThreadWomen = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "ThreadWomen");

                    return PartialView("EditThreadPictureWomen", ThreadWomen.FirstOrDefault());
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

        // Delete: SickLeave
        [HttpPost]
        public ActionResult DeleteThreadPictureWomen(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.LaserMarking.DeleteLaserMarking(lfmId, lfm_madeby);

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

        // Print: LaserMarking
        [HttpGet]
        public ActionResult PrintThreadPictureWomen(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Thread Picture Women with lfmId = {lfmId}"
                    });

                    return View("PrintThreadPictureWomen", print);
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
        #endregion Thread Picture Women  CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}