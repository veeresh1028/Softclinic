using BusinessEntities;
using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    public class PackagesAndServicesController : Controller
    {
        int PageId = (int)Pages.Packages;
        // GET: Masters/PackagesAndServices
        public ActionResult PackagesAndServices()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Packages And Services!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetAllPackagesServices()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.PackagesAndServices> pkglist = BusinessLogicLayer.Masters.PackagesAndServices.GetAllPackagesServices(0);

                return Json(pkglist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public PartialViewResult CreatePackagesService()
        {
            int Action = (int)Actions.Create;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.PackagesAndServices packages = new BusinessEntities.Masters.PackagesAndServices();

                    return PartialView("CreatePackagesService", packages);
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

        [HttpGet]
        public PartialViewResult CreateSevicesToPackage(int id = 0)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Packages package = new BusinessEntities.Masters.Packages();

                    return PartialView("CreateSevicesToPackage", package);
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
        public ActionResult InsertPackage(BusinessEntities.Masters.PackagesAndServices data)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                data.pkg_madeby = PageControl.getLoggedinId();
                isInserted = BusinessLogicLayer.Masters.PackagesAndServices.InsertUpdatePackages(data);

                if (isInserted)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Created New Package : {data.pkg_name}"
                    });

                    return Json(new { isInserted = true, isSuccess = true, message = "Package Created Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isInserted = false, isSuccess = true, message = "Package Already Exists!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdatePackageStatus(int psId, string ps_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.PackagesAndServices.UpdatePackageStatus(psId, ps_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Package Status to : {ps_status} with psId = {psId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Package Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Package with the same name already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Package Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DeletePackage(int psId, string ps_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.PackagesAndServices.UpdatePackageStatus(psId, ps_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Package with psId = {psId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Package Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Package!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Package Tests (Document Load)
        [HttpGet]
        public PartialViewResult Packages(int pkgId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.Packages> packages = BusinessLogicLayer.Masters.PackagesAndServices.GetPackages(pkgId);

                    TempData["pkgId"] = pkgId;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Package with pkgId = {pkgId}"
                    });

                    return PartialView("Packages", packages);
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

        [HttpGet]
        public JsonResult GetPackages()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TempData.Keep("pkgId");
                int pkgId = int.Parse(TempData["pkgId"].ToString());

                List<BusinessEntities.Masters.Packages> packages = BusinessLogicLayer.Masters.PackagesAndServices.GetPackages(pkgId);

                TempData["pkgId"] = pkgId;

                return Json(packages, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion


        public ActionResult InsertSevicesToPackage(BusinessEntities.Masters.Packages data)
        {
            bool isInserted = false;
            int Action = (int)Actions.Create;
            TempData.Keep("pkgId");

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.TreatmentGroups.isValidPackages(data, out errors))
                {
                    data.ps_package = int.Parse(TempData["pkgId"].ToString());
                    data.ps_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.Masters.PackagesAndServices.InsertSevicesToPackage(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created New Package : {data.ps_services}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Package Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Package Already Exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetCPTCodes(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> CPTIList = BusinessLogicLayer.Masters.PackagesAndServices.GetCPTCodes(query);
                    var jsonResult = Json(CPTIList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
    }
}