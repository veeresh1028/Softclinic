using BusinessEntities;
using BusinessEntities.Appointment;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class ToothTreatmentsCategoryController : Controller
    {
        int PageId = (int)Pages.ToothTreatmentsCategory;

        #region Tooth Treatments Category Master (Page Load)
        [HttpGet]
        public ActionResult ToothTreatmentsCategory()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Tooth Treatments Category!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllToothTreatmentsCategory()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.ToothTreatmentsCategory> categories = BusinessLogicLayer.Masters.ToothTreatmentsCategory.GetToothTreatmentsCategory(0);

                return Json(categories, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Load Dropdowns
        [HttpGet]
        public JsonResult GetToothTreatmentsMainCategory(int? ctcyId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt = BusinessLogicLayer.Lists.ToothCategoryMain.GetToothCategoryMain(ctcyId);
                    SelectList toothcategorymain = Models.Helper.ToSelectList(dt, "ctcyId", "ctcy_category");
                    var jsonResult = Json(toothcategorymain, JsonRequestBehavior.AllowGet);
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
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetToothTreatmentsSubCategory(int? ctsyId, int? ctsy_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt = BusinessLogicLayer.Lists.ToothCategoryMain.GetToothSubCategory(ctsyId, ctsy_code);
                    SelectList toothcategorysub = Models.Helper.ToSelectList(dt, "ctsyId", "ctsy_category");
                    var jsonResult = Json(toothcategorysub, JsonRequestBehavior.AllowGet);
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
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Tooth Treatments Category CRUD Operations
        [HttpGet]
        public PartialViewResult CreateToothTreatmentsCategory()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.ToothTreatmentsCategory category = new BusinessEntities.Masters.ToothTreatmentsCategory();

                    category.toothTreatmentsList = BusinessLogicLayer.Lists.ToothCategoryMain.GetActiveTreatmentCodes();

                    return PartialView("CreateToothTreatmentsCategory", category);
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
        public ActionResult InsertToothTreatmentsCategory(BusinessEntities.Masters.ToothTreatmentsCategory data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ToothTreatmentsCategory.isValidToothTreatmentsCategory(data, out errors))
                    {
                        data.cct_madeby = PageControl.getLoggedinId();

                        isInserted = BusinessLogicLayer.Masters.ToothTreatmentsCategory.InserUpdatetToothTreatmentsCategory(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.cct_madeby,
                                log_desc = $"Employee Created New Tooth Treatments Category : {data.cct_code}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Tooth Treatments Category Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Tooth Treatments Category already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditToothTreatmentsCategory(int cctId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.ToothTreatmentsCategory category = BusinessLogicLayer.Masters.ToothTreatmentsCategory.GetToothTreatmentsCategoryByID(cctId).FirstOrDefault();

                    category.toothTreatmentsList = BusinessLogicLayer.Lists.ToothCategoryMain.GetActiveTreatmentCodes();

                    return PartialView("EditToothTreatmentsCategory", category);
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
        public ActionResult UpdateToothTreatmentsCategory(BusinessEntities.Masters.ToothTreatmentsCategory data)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ToothTreatmentsCategory.isValidToothTreatmentsCategory(data, out errors))
                    {
                        data.cct_madeby = PageControl.getLoggedinId();

                        isUpdated = BusinessLogicLayer.Masters.ToothTreatmentsCategory.InserUpdatetToothTreatmentsCategory(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Updated Tooth Treatments Category with cctId = {data.cctId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Tooth Treatments Category Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Tooth Treatments Category already exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateToothTreatmentsCategoryStatus(int cctId, string cct_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.ToothTreatmentsCategory.UpdateToothTreatmentsCategoryStatus(cctId, cct_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Tooth Treatments Category Status to : {cct_status} with cctId = {cctId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Tooth Treatments Category with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteToothTreatmentsCategory(int cctId, string cct_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.ToothTreatmentsCategory.UpdateToothTreatmentsCategoryStatus(cctId, cct_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Tooth Treatments Category with cctId = {cctId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Tooth Treatments Category Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Tooth Treatments Category!" }, JsonRequestBehavior.AllowGet);
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