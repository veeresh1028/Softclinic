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
    public class CuppingController : Controller
    {
        // GET: EMR/Cupping
        int PageId = (int)Pages.CuppingTherapy;

        #region Cupping Therapy (Page Load)
        // GET: EMR/Cupping
        public ActionResult Cupping()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Cupping Therapy Page!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }


        public JsonResult GetAllCupping(int? appId, int? lfmId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> Cupping = BusinessLogicLayer.EMR.Cupping.GetCupping(appId, lfmId, lfm_form);

                return Json(Cupping, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // GET: Previous/DentalCharting

        public JsonResult GetPreCupping(int appId, int patId, string lfm_form)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<LaserMarking> dentchart = BusinessLogicLayer.EMR.Cupping.GetAllPreCupping(appId, patId, lfm_form);

                return Json(dentchart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Cupping Therapy (Page Load)

        #region Cupping Therapy  CRUD Operations
        public PartialViewResult CreateCupping()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                LaserMarking cupping = new LaserMarking();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateCupping", cupping);
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

        // upload: Cupping
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadCupping(BusinessEntities.EMR.LaserMarking data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.image))
            {
                string file_path = Server.MapPath("~/images/Therapy/");

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
                    isInserted = BusinessLogicLayer.EMR.Cupping.UploadCupping(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Cupping Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }


        // Edit: Dental Charting
        [HttpGet]
        public PartialViewResult EditCupping(int? appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<LaserMarking> CuppingTherapy = BusinessLogicLayer.EMR.Cupping.GetCupping(appId, 0, "CuppingTherapy");

                    return PartialView("EditCupping", CuppingTherapy.FirstOrDefault());
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
        public ActionResult DeleteCupping(int lfmId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int lfm_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.Cupping.DeleteCupping(lfmId, lfm_madeby);

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

        // Print: Cupping
        [HttpGet]
        public ActionResult PrintCupping(int lfmId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    LaserMarking print = BusinessLogicLayer.EMR.Cupping.GetCupping(0, lfmId, "").FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Cupping Therapy with lfmId = {lfmId}"
                    });

                    return View("PrintCupping", print);
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
        #endregion Cupping Therapy  CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}