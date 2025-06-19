using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Marketing;
using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Marketing.Controllers
{
    [Authorize]
    public class MarketingController : Controller
    {
        int PageId = (int)Pages.Enquiries;

        #region Page Load & Search
        [HttpGet]
        public ActionResult Marketing(MarketingSearch filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetMarketingList(MarketingSearch filters)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Marketing.Marketing> marketingList = BusinessLogicLayer.Marketing.Marketing.SearchMarketing(filters);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Enquiries Page!"
                });

                var jsonResult = Json(marketingList, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Marketing Advanced Filters
        [HttpGet]
        public ActionResult GetEmployees()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> empList = BusinessLogicLayer.Marketing.Marketing.GetEmployees();

                    var jsonResult = Json(empList, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult GetSources()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> sourceList = BusinessLogicLayer.Marketing.Marketing.GetSources();

                    var jsonResult = Json(sourceList, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult GetCampaignsBySources(CampaignsBySources data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> campaigns = BusinessLogicLayer.Marketing.Marketing.GetCampaignsBySources(string.Join(",", data.Sources));

                    var jsonResult = Json(campaigns, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Marketing CRUD Operations
        [HttpGet]
        public PartialViewResult CreateEnquiry()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    Enquiry enquiry = new Enquiry();
                    enquiry.app_branch = Convert.ToInt32(emp_branch);
                    enquiry.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("CreateEnquiry", enquiry);
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
        public ActionResult InsertEnquiry(BusinessEntities.Marketing.Enquiry enquiry)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int isInserted = 0;

                    enquiry.app_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Appointment.isValidInsertEnquiry(enquiry, out errors))
                    {
                        isInserted = BusinessLogicLayer.Marketing.Marketing.InsertEnquiry(enquiry);

                        if (isInserted > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = enquiry.app_madeby,
                                log_desc = "Employee Created New Enquiry"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Enquiry Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Enquiry already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditEnquiry(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Enquiry enquiry = new Enquiry();

                    enquiry = BusinessLogicLayer.Marketing.Marketing.GetInquiryById(appId);
                    enquiry.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    enquiry.StatusList = BusinessLogicLayer.Appointment.Appointment.GetAppointmentStatusList();

                    return PartialView("EditEnquiry", enquiry);
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
        public ActionResult UpdateEnquiry(BusinessEntities.Marketing.Enquiry enquiry)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int isUpdated = 0;

                    enquiry.app_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Appointment.isValidUpdateEnquiry(enquiry, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Marketing.Marketing.UpdateEnquiry(enquiry);

                        if (isUpdated > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = enquiry.app_madeby,
                                log_desc = $"Employee Updated Enquiry with appId = {enquiry.appId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Enquiry Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Enquiry already exists!" }, JsonRequestBehavior.AllowGet);
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
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isInserted = false;

                    campaign.esc_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.SourceCampaigns.isValidCampaigns(campaign, out errors))
                    {
                        int campId = 0;

                        isInserted = BusinessLogicLayer.Marketing.Marketing.InsertCampaign(campaign, out campId);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = campaign.esc_madeby,
                                log_desc = $"Employee Created New Campaign : {campaign.esc_title}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = campId }, JsonRequestBehavior.AllowGet);
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
        public ActionResult EnquiryRemarks(int app_branch, int patId, string flag)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                var emp_name = claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

                Remarks remark = new Remarks();

                remark.ar_appId = 0;
                remark.ar_employee_name = emp_name;
                remark.ar_patId = patId;
                remark.ar_flag = flag;
                remark.ar_status = "Active";

                remark.FromTimeList = BusinessLogicLayer.Masters.Employees.GetTimeSlotList(app_branch);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Viewed Enquiry Remarks with patId = {patId}"
                });

                return PartialView("EnquiryRemarks", remark);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Miscellaneous Functions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            bool isPartial = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            TempData["error"] = filterContext;

            string actionName = isPartial ? "ErrorPartialView" : "Error";

            filterContext.Result = RedirectToAction(actionName, "Error", new { area = "Common" });
        }
        #endregion
    }
}