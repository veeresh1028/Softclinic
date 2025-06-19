using BusinessEntities;
using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class DentalChartingController : Controller
    {
        int PageId = (int)Pages.DentalHistory;
        #region DentalCharting (Page Load)
        // GET: EMR/DentalCharting
        public ActionResult DentalCharting()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Dental History Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllDentalChart(int? appId, int? cdcId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DentalCharting> Dentalchart = BusinessLogicLayer.EMR.DentalCharting.GetDentalChart(appId, cdcId);

                return Json(Dentalchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetAllPreDentalChart(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DentalCharting> dentchart = BusinessLogicLayer.EMR.DentalCharting.GetAllPreDentalCharts(appId, patId);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion DentalCharting (Page Load)
        #region DentalCharting  CRUD Operations
        public PartialViewResult CreateDentalChart()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                DentalCharting Dentalchart = new DentalCharting();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateDentalChart", Dentalchart);
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

        // upload: DentalChart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadDentalChart(BusinessEntities.EMR.DentalCharting data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/tooth_chart/");

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
                    isInserted = BusinessLogicLayer.EMR.DentalCharting.UploadDentalChart(data, madeBy);
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
        public PartialViewResult EditDentalChart(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<DentalCharting> Dentalchart = BusinessLogicLayer.EMR.DentalCharting.GetDentalChart(appId, 0);

                    return PartialView("EditDentalChart", Dentalchart.FirstOrDefault());
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
        public ActionResult DeleteDentalChart(int cdcId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cdc_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.DentalCharting.DeleteDentalChart(cdcId, cdc_madeby);

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

        // Print: DentalCharting
        [HttpGet]
        public ActionResult PrintDentalChart(int cdcId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    DentalCharting print = BusinessLogicLayer.EMR.DentalCharting.GetDentalChart(0, cdcId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Dental Chart with cdcId = {cdcId}"
                    });

                    return View("PrintDentalChart", print);
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
        #endregion DentalCharting  CRUD Operations


        #region Perio Chart (Page Load)
        // GET: EMR/PerioChart
        public ActionResult PerioChart()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Perio Chart Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
        public JsonResult GetAllPerioChart(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dental_PerioChart periochart = BusinessLogicLayer.EMR.DentalCharting.GetPerioChart(appId, 0);

                return Json(periochart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPerioChartDetails(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PerioChartDetails> genexam = BusinessLogicLayer.EMR.DentalCharting.GetPerioChartDetails(appId, 0);

                return Json(genexam, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Perio Chart (Page Load)

        #region Perio Chart  CRUD Operations
        public PartialViewResult CreatePerioChart()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                Dental_PerioChart periochart = new Dental_PerioChart();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreatePerioChart", periochart);
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
        public ActionResult InsertPerioChart(Dental_PerioChart data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {


                    int val = BusinessLogicLayer.EMR.DentalCharting.InsertPerioChart(data, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Inserted PerioChart = {data.dental_perio.perioId}"
                        });
                        return Json(new { isInserted = true, isSuccess = true, message = "Perio Chart Inserted successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Error in creating the Perio Chart " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, isInserted = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditPerioChart(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dental_PerioChart periochart = BusinessLogicLayer.EMR.DentalCharting.GetPerioChart(appId, 0);

                    return PartialView("EditPerioChart", periochart);
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
        public ActionResult UpdatePerioChart(Dental_PerioChart data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    bool isInserted = false;

                    int val = BusinessLogicLayer.EMR.DentalCharting.InsertPerioChart(data, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        isInserted = true;
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Inserted PerioChart = {data.dental_perio.perioId}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Perio Chart Inserted successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Error in creating the Perio Chart " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, isInserted = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Delete: PerioChart
        [HttpPost]
        public ActionResult DeletePerioChart(int perioId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int perio_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.DentalCharting.DeletePerioChart(perioId, perio_madeby);

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

        // Print: DentalCharting
        [HttpGet]
        public ActionResult PrintPerioChart(int perio_appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    Dental_PerioChart print = BusinessLogicLayer.EMR.DentalCharting.GetPerioChart(perio_appId, 0);
                    print.dental_perio.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.dental_perio.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Perio Chart with perio_appId = {perio_appId}"
                    });

                    return View("PrintPerioChart", print);
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
        #endregion Perio Chart  CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}