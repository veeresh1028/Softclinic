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
    public class PediatricController : Controller
    {
        int PageId = (int)Pages.Pediatric;

        #region Growth Chart Boy Below 2Y (Page Load)
        // GET: EMR/GrowthChartBoyB2Y
        public ActionResult GrowthChartBoyBelow2Y()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Growth Chart Boy Below 2Y Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllGrowthChartBoyB2Y(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> GrowthChartBoyB2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(GrowthChartBoyB2Y, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/GrowthChartBoyB2Y

        public JsonResult GetPreGrowthChartBoyB2Y(int appId, int patId, string lfm_form)
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
        #endregion Growth Chart Boy Below 2Y (Page Load)

        #region Growth Chart Boy Below 2Y  CRUD Operations
        public PartialViewResult CreateGrowthChartBoyB2Y()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking GrowthBoyBelow2Y = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateGrowthChartBoyB2Y", GrowthBoyBelow2Y);
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

        // upload: GrowthChartBoyB2Y
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadGrowthChartBoyB2Y(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Growth_Charts/Boys/");

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
        public PartialViewResult EditGrowthChartBoyB2Y(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> GrowthBoyBelow2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "GrowthBoyBelow2Y");

                    return PartialView("EditGrowthChartBoyB2Y", GrowthBoyBelow2Y.FirstOrDefault());
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
        public ActionResult DeleteGrowthChartBoyB2Y(int lfmId)
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

        // Print: GrowthChartBoyB2Y
        [HttpGet]
        public ActionResult PrintGrowthChartBoyB2Y(int lfmId)
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
                        log_desc = $"Employee Printed Growth Chart Boy Below 2Year with lfmId = {lfmId}"
                    });

                    return View("PrintGrowthChartBoyB2Y", print);
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
        #endregion Growth Chart Boy Below 2Y  CRUD Operations

        #region Growth Chart Boy Above 2Y (Page Load)
        // GET: EMR/GrowthChartBoyAbove2Y
        public ActionResult GrowthChartBoyAbove2Y()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Growth Chart Boy Above 2Y Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllGrowthChartBoyAbove2Y(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> GrowthChartBoyAbove2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(GrowthChartBoyAbove2Y, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/GrowthChartBoyAbove2Y

        public JsonResult GetPreGrowthChartBoyAbove2Y(int appId, int patId, string lfm_form)
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
        #endregion Growth Chart Boy Above 2Y (Page Load)

        #region Growth Chart Boy Above 2Y  CRUD Operations
        public PartialViewResult CreateGrowthChartBoyAbove2Y()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking GrowthBoyBelow2Y = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateGrowthChartBoyAbove2Y", GrowthBoyBelow2Y);
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

        // upload: GrowthChartBoyAbove2Y
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadGrowthChartBoyAbove2Y(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Growth_Charts/Boys/");

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
        public PartialViewResult EditGrowthChartBoyAbove2Y(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> GrowthBoyBelow2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "GrowthBoyAbove2Y");

                    return PartialView("EditGrowthChartBoyAbove2Y", GrowthBoyBelow2Y.FirstOrDefault());
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
        public ActionResult DeleteGrowthChartBoyAbove2Y(int lfmId)
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

        // Print: GrowthChartBoyAbove2Y
        [HttpGet]
        public ActionResult PrintGrowthChartBoyAbove2Y(int lfmId)
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
                        log_desc = $"Employee Printed Growth Chart Boy Above 2Year with lfmId = {lfmId}"
                    });

                    return View("PrintGrowthChartBoyAbove2Y", print);
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
        #endregion Growth Chart Boy Above 2Y  CRUD Operations

        #region Growth Chart Girl Below 2Y (Page Load)
        // GET: EMR/GrowthChartGirlBelow2Y
        public ActionResult GrowthChartGirlBelow2Y()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Growth Chart Girl Below 2Y Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllGrowthChartGirlBelow2Y(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> GrowthChartGirlBelow2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(GrowthChartGirlBelow2Y, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/GrowthChartGirlBelow2Y

        public JsonResult GetPreGrowthChartGirlBelow2Y(int appId, int patId, string lfm_form)
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
        #endregion Growth Chart Girl Below 2Y (Page Load)

        #region Growth Chart Girl Below 2Y  CRUD Operations
        public PartialViewResult CreateGrowthChartGirlBelow2Y()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking GrowthBoyBelow2Y = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateGrowthChartGirlBelow2Y", GrowthBoyBelow2Y);
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

        // upload: GrowthChartGirlBelow2Y
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadGrowthChartGirlBelow2Y(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Growth_Charts/Girls/");

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
        public PartialViewResult EditGrowthChartGirlBelow2Y(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> GrowthBoyBelow2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "GrowthGirlBelow2Y");

                    return PartialView("EditGrowthChartGirlBelow2Y", GrowthBoyBelow2Y.FirstOrDefault());
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
        public ActionResult DeleteGrowthChartGirlBelow2Y(int lfmId)
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

        // Print: GrowthChartGirlBelow2Y
        [HttpGet]
        public ActionResult PrintGrowthChartGirlBelow2Y(int lfmId)
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
                        log_desc = $"Employee Printed Growth Chart Girl Below 2Year with lfmId = {lfmId}"
                    });

                    return View("PrintGrowthChartGirlBelow2Y", print);
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
        #endregion Growth Chart Girl Below 2Y  CRUD Operations

        #region Growth Chart Girl Above 2Y (Page Load)
        // GET: EMR/GrowthChartGirlAbove2Y
        public ActionResult GrowthChartGirlAbove2Y()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Growth Chart Girl Above 2Y Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllGrowthChartGirlAbove2Y(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> GrowthChartGirlAbove2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, lfmId, lfm_form);

                return Json(GrowthChartGirlAbove2Y, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/GrowthChartGirlAbove2Y

        public JsonResult GetPreGrowthChartGirlAbove2Y(int appId, int patId, string lfm_form)
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
        #endregion Growth Chart Girl Above 2Y (Page Load)

        #region Growth Chart Girl Above 2Y  CRUD Operations
        public PartialViewResult CreateGrowthChartGirlAbove2Y()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking GrowthGirlBelow2Y = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateGrowthChartGirlAbove2Y", GrowthGirlBelow2Y);
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

        // upload: GrowthChartGirlAbove2Y
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadGrowthChartGirlAbove2Y(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Growth_Charts/Girls/");

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
        public PartialViewResult EditGrowthChartGirlAbove2Y(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> GrowthGirlBelow2Y = BusinessLogicLayer.EMR.LaserMarking.GetLaserMarking(appId, 0, "GrowthGirlAbove2Y");

                    return PartialView("EditGrowthChartGirlAbove2Y", GrowthGirlBelow2Y.FirstOrDefault());
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
        public ActionResult DeleteGrowthChartGirlAbove2Y(int lfmId)
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

        // Print: GrowthChartGirlAbove2Y
        [HttpGet]
        public ActionResult PrintGrowthChartGirlAbove2Y(int lfmId)
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
                        log_desc = $"Employee Printed Growth Chart Girl Above 2Year with lfmId = {lfmId}"
                    });

                    return View("PrintGrowthChartGirlAbove2Y", print);
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
        #endregion Growth Chart Girl Above 2Y  CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}