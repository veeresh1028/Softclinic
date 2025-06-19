using BusinessEntities.Appointment;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using RestSharp;
using System.Configuration;
using System.Threading.Tasks;
using Google.Type;
using static System.Net.Mime.MediaTypeNames;

namespace ClinicSoft.Areas.Marketing.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        int PageId = (int)Pages.Enquiries;

        #region Feedback Appointments Page Load
        [HttpGet]
        public ActionResult Feedback()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAppointmentList(AppointmentSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                AppointmentCount app_count = new AppointmentCount();
                AppointmentStatusColor aps_color = new AppointmentStatusColor();
                AppointmentListData listData = new AppointmentListData();

                listData.AppointmentList = BusinessLogicLayer.Appointment.Appointment.SearchAppointments(data, out app_count, out aps_color);
                listData.AppointmentCount = app_count;
                listData.AppointmentStatusColor = aps_color;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Searched Feedback Page!"
                });

                var jsonResult = Json(listData, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Feedback Appointments Advanced Filters
        [HttpGet]
        public ActionResult GetBranches()
        {
            List<CommonDDL> branchList = new List<CommonDDL>();
            try
            {
                DataTable dt = BusinessLogicLayer.Company.GetBranchesForAppointment();
                branchList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
        }

        [HttpGet]
        public ActionResult GetPatients(GetPatients patient)
        {
            try
            {
                List<CommonDDL> dt = BusinessLogicLayer.Appointment.Appointment.GetPatients(patient);

                var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region SMS Feedback Link to Patient
        [HttpPost]
        public async Task<ActionResult> SendFeedbackSMS(int appId, string pat_mob, int branchId)
        {
            SMSConfig config = new SMSConfig();

            try
            {
                int empId = PageControl.getLoggedinId();

                config = BusinessLogicLayer.CommunicationMedia.SMSConfig(branchId);

                if (!string.IsNullOrEmpty(config.APIKey) && !string.IsNullOrEmpty(config.SenderID))
                {
                    string feedbackLink = ConfigurationManager.AppSettings["FeedbackLink"].ToString();

                    string token = appId.ToString();

                    feedbackLink = feedbackLink + "?token=" + HttpUtility.UrlEncode(token);

                    string format_message = "Thank you for choosing our services. Would you mind sparing a moment to share your experience by leaving a review ? " + feedbackLink + " Your insights are valuable in helping us continually improve our services. Thank you!";

                    string username = string.Empty;

                    int index = config.SenderID.IndexOf('|');

                    if (index != -1)
                    {
                        string beforePipe = config.SenderID.Substring(0, index);
                        username = config.SenderID.Substring(index + 1);
                        config.SenderID = beforePipe;
                    }

                    string end_point = "/API/SendSMS?username=" + username + "&apiId=" + config.APIKey + "&source=" + config.SenderID + "&text=" + HttpUtility.UrlEncode(format_message) + "&destination=" + pat_mob + "&json=True";

                    var options = new RestClientOptions(ConfigurationManager.AppSettings["SMSGatewayEndPoint"].ToString())
                    {
                        MaxTimeout = -1,
                    };

                    var client = new RestClient(options);

                    var request = new RestRequest(end_point, Method.Get);

                    RestResponse response = await client.ExecuteAsync(request);

                    if (response.IsSuccessful)
                    {
                        if (response.Content.Trim().ToLower().Contains("success"))
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = empId,
                                log_desc = $"Employee Sent SMS to : {pat_mob}"
                            });

                            return Json(new { isSuccess = true, message = "SMS Sent Successfully to " + pat_mob }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = response.Content.Trim().ToString() }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Error while sending SMS to " + pat_mob }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = "SMS Gateway not setup in Clinic Settings!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
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