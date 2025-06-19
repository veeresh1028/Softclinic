using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class VaccinationsController : Controller
    {
        int PageId = (int)Pages.Vaccinations;

        #region Vaccinations Master (Page Load)
        [HttpGet]
        public ActionResult Vaccinations()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Vaccinations!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllVaccinations()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Vaccinations> vaccinations = BusinessLogicLayer.Masters.Vaccinations.GetVaccinations(0);

                return Json(vaccinations, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Vaccinations CRUD Operations
        [HttpGet]
        public PartialViewResult CreateVaccinations()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Vaccinations vaccination = new BusinessEntities.Masters.Vaccinations();

                    return PartialView("CreateVaccinations", vaccination);
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
        public ActionResult InsertVaccination(BusinessEntities.Masters.Vaccinations data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Vaccinations.isValidVaccinations(data, out errors))
                    {
                        data.v_madeby = PageControl.getLoggedinId();

                        isInserted = BusinessLogicLayer.Masters.Vaccinations.InserUpdatetVaccinations(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.v_madeby,
                                log_desc = $"Employee Created New Vaccination : {data.v_name}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Vaccination Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Vaccinations already exists with the same details!" }, JsonRequestBehavior.AllowGet);
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
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult EditVaccinations(int vId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Vaccinations vaccination = BusinessLogicLayer.Masters.Vaccinations.GetVaccinations(vId).FirstOrDefault();

                    return PartialView("EditVaccinations", vaccination);
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
        public ActionResult UpdateVaccination(BusinessEntities.Masters.Vaccinations data)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Vaccinations.isValidVaccinations(data, out errors))
                    {
                        data.v_madeby = PageControl.getLoggedinId();

                        isUpdated = BusinessLogicLayer.Masters.Vaccinations.InserUpdatetVaccinations(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.v_madeby,
                                log_desc = $"Employee Updated Vaccination with vId = {data.vId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Vaccination Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Vaccination already exists wih the same details!" }, JsonRequestBehavior.AllowGet);
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
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult UpdateVaccinationStatus(int vId, string v_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Vaccinations.UpdateVaccinationsStatus(vId, v_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Vaccination Status to : {v_status} with vId = {vId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Vaccination Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Vaccination with the same name already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Vaccination Status!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteVaccination(int vId, string v_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Vaccinations.UpdateVaccinationsStatus(vId, v_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Vaccination with vId = {vId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Vaccination Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Vaccination!" }, JsonRequestBehavior.AllowGet);
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
        #endregion
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}