using BusinessEntities;
using BusinessEntities.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class SourceCampaignsController : Controller
    {
        int PageId = (int)Pages.SourceCampaigns;

        #region Source Master (Page Load)
        [HttpGet]
        public ActionResult SourceCampaigns()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Source & Campaigns!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetAllSourceCampaigns(int? eqcId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.SourceCampaigns> sclist = BusinessLogicLayer.Masters.SourceCampaigns.GetSourceCampaigns(eqcId);

                return Json(sclist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Source CRUD Operations
        [HttpGet]
        public PartialViewResult CreateSource()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.SourceCampaigns source = new BusinessEntities.Masters.SourceCampaigns();

                    source.eqc_code = BusinessLogicLayer.Masters.SourceCampaigns.GenerateSourceCode();

                    return PartialView("CreateSource", source);
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
        public ActionResult InsertSource(BusinessEntities.Masters.SourceCampaigns data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.SourceCampaigns.isValidSourceCampaigns(data, out errors))
                    {
                        data.eqc_madeby = PageControl.getLoggedinId();

                        int sourceId = 0;

                        isInserted = BusinessLogicLayer.Masters.SourceCampaigns.InsertUpdateSource(data, out sourceId);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.eqc_madeby,
                                log_desc = $"Employee Created New Source : {data.eqc_title}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = sourceId }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public PartialViewResult EditSource(int eqcId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.SourceCampaigns source = BusinessLogicLayer.Masters.SourceCampaigns.GetSourceCampaigns(eqcId).FirstOrDefault();

                    return PartialView("EditSource", source);
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateSource(BusinessEntities.Masters.SourceCampaigns data)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.eqc_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.SourceCampaigns.isValidSourceCampaigns(data, out errors))
                    {
                        int sourceId = 0;

                        isUpdated = BusinessLogicLayer.Masters.SourceCampaigns.InsertUpdateSource(data, out sourceId);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.eqc_madeby,
                                log_desc = $"Employee Updated Source with eqcId = {data.eqcId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = sourceId }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Source already exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateSourceStatus(int eqcId, string eqc_status)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Masters.SourceCampaigns.UpdateSourceCampaignstatus(eqcId, eqc_status, PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Source Status to : {eqc_status} with eqcId = {eqcId}"
                    });

                    return Json(new { isAuthorized = true, success = true, message = "Source Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else if (val == -1)
                {
                    return Json(new { isAuthorized = true, success = false, message = "An active Source with the same name already exists!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed To Change Source Status!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteSource(int eqcId, string eqc_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.SourceCampaigns.UpdateSourceCampaignstatus(eqcId, eqc_status, PageControl.getLoggedinId());

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Source with eqcId = {eqcId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Source Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Source Status!" }, JsonRequestBehavior.AllowGet);
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

        #region Sourcewise Campaigns Master (Page Load)
        [HttpGet]
        public ActionResult SourcewiseCampains(int eqcId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<SourcewiseCampaigns> sclist = BusinessLogicLayer.Masters.SourceCampaigns.GetCampaigns(eqcId);

                TempData["eqcId"] = eqcId;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Viewed Sourcewise Campaigns with eqcId = {eqcId}!"
                });

                return PartialView("SourcewiseCampains", sclist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetAllCampaigns()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TempData.Keep("eqcId");

                int eqcId = int.Parse(TempData["eqcId"].ToString());

                List<SourcewiseCampaigns> sclist = BusinessLogicLayer.Masters.SourceCampaigns.GetCampaigns(eqcId);

                TempData["EQCID"] = eqcId;

                return Json(sclist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Sourcewise Campaigns CRUD Operations
        public PartialViewResult CreateCampaign()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.SourcewiseCampaigns campaign = new BusinessEntities.Masters.SourcewiseCampaigns();

                    return PartialView("CreateCampaign", campaign);
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
        public ActionResult InsertCampaign(BusinessEntities.Masters.SourcewiseCampaigns campaign)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    TempData.Keep("EQCID");
                    campaign.esc_eqcId = int.Parse(TempData["EQCID"].ToString());
                    campaign.esc_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.SourceCampaigns.isValidCampaigns(campaign, out errors))
                    {
                        isInserted = BusinessLogicLayer.Masters.SourceCampaigns.InsertUpdateCampaign(campaign);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = campaign.esc_madeby,
                                log_desc = $"Employee Created New Campaign : {campaign.esc_title}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Campaign Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Campaign already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditCampaign(int escId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<SourcewiseCampaigns> campaign = BusinessLogicLayer.Masters.SourceCampaigns.GetCampaignsById(escId);

                    return PartialView("EditCampaign", campaign.FirstOrDefault());
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
        public ActionResult UpdateCampaign(BusinessEntities.Masters.SourcewiseCampaigns campaign)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    TempData.Keep("EQCID");
                    campaign.esc_eqcId = int.Parse(TempData["EQCID"].ToString());
                    campaign.esc_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.SourceCampaigns.isValidCampaigns(campaign, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Masters.SourceCampaigns.InsertUpdateCampaign(campaign);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = campaign.esc_madeby,
                                log_desc = $"Employee Updated with eqcId = {campaign.eqcId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Campaign Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Campaign already exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateCampaignStatus(int escId, string esc_status)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Masters.SourceCampaigns.UpdateCampaignStatus(escId, esc_status, PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Campaign Status to : {esc_status} with escId = {escId}"
                    });

                    return Json(new { isAuthorized = true, success = true, message = "Campaign Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else if (val == -1)
                {
                    return Json(new { isAuthorized = true, success = false, message = "An active Campaign with the same name already exists!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed To Change Campaign Status!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteCampaign(int escId, string esc_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.SourceCampaigns.UpdateCampaignStatus(escId, esc_status, PageControl.getLoggedinId());

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Campaign Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Campaign!" }, JsonRequestBehavior.AllowGet);
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