using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Appointment.AuditLogs;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using BusinessEntities.Lists;
using BusinessEntities.MNR;
using BusinessEntities.Patient;
using Google.Protobuf.WellKnownTypes;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using DocData = BusinessEntities.Common.DocData;

namespace ClinicSoft.Areas.Patient.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        int PageId = (int)Pages.Patients;
        int PageId_Details = (int)Pages.PatientsDetails;
        int PageId_Whatsapp = (int)Pages.PatientWhatsapp;
        int PageId_Email = (int)Pages.PatientEmail;
        int PageId_SMS = (int)Pages.PatientSMS;
        int PageId_PatientInsurance = (int)Pages.PatientInsurances;

        #region Patients (Page Load & Search)
        [HttpGet]
        public ActionResult PatientIndex()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_nationalities = BusinessLogicLayer.Nationality.GetNationalities();
                SelectList NationalityList = Models.Helper.ToSelectList(dt_nationalities, "natId", "nationality");
                ViewData["NationalityList"] = NationalityList;

                DataTable dt_referals = BusinessLogicLayer.Referal.GetReferals();
                SelectList ReferalList = Models.Helper.ToSelectList(dt_referals, "refId", "ref_name");
                ViewData["ReferalList"] = ReferalList;
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPatients(PatientSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                List<BusinessEntities.Patient.Patient> patients = new List<BusinessEntities.Patient.Patient>();

                try
                {
                    if (data.mode == 0)
                    {
                        data.reg_from = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
                        data.reg_to = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
                    }

                    patients = BusinessLogicLayer.Patient.Patient.GetPatientsData(data);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Patients Page!"
                    });

                    var jsonResult = Json(new { isSuccess = true, message = patients }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isSuccess = true, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        [HttpGet]
        public ActionResult GetEthnicgroup(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }
                    string category = "Ethnic Group";
                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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
        public ActionResult Getrace(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    string category = "Race";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                        category = "Race";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                        category = "Race Code";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                        category = "Race";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }

                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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
        public ActionResult Getreligion(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    string category = "Religion";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                        category = "Religion";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                        category = "Religion Code";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                        category = "Religion";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }

                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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
        public ActionResult Getrelationship(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    string category = "Relationship";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                        category = "Relationship";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                        category = "Relationship Code";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                        category = "Relationship";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }

                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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
        public ActionResult Getprofession(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    string category = "Profession";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }

                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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
        public ActionResult Getlanguage(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    string category = "Primary Language";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }

                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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

        #region Communication Settings (SMS / WhatsApp / E-Mail)
        [HttpGet]
        public ActionResult GetTemplates(int? tempFor, int? templateId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.CommunicationTemplate> tempList = new List<BusinessEntities.CommunicationTemplate>();
                try
                {
                    tempList = BusinessLogicLayer.CommunicationMedia.GetTemplates(templateId, tempFor);

                    var jsonResult = Json(tempList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(tempList, JsonRequestBehavior.AllowGet);
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
        public async Task<ActionResult> WhatsappConfig(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_Whatsapp, Action))
            {
                WhatsappConfig config = new WhatsappConfig();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("Whatsapp", "Patient", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        config = BusinessLogicLayer.CommunicationMedia.WhatsappConfig(empId, data.branchId);
                        WhatsappResponse _response = new WhatsappResponse();

                        if (!string.IsNullOrEmpty(config.InstanceId) && !string.IsNullOrEmpty(config.AccessToken))
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string end_point = "/api/send.php?number=" + data.mobile + "&type=text&message=" + HttpUtility.UrlEncode(format_message) + "&instance_id=" + config.InstanceId + "&access_token=" + config.AccessToken;
                            var options = new RestClientOptions(ConfigurationManager.AppSettings["WhatsappEndPoint"].ToString())
                            {
                                MaxTimeout = -1,
                            };
                            var client = new RestClient(options);
                            var request = new RestRequest(end_point, RestSharp.Method.Get);
                            RestResponse response = await client.ExecuteAsync(request);


                            if (response.IsSuccessful)
                            {
                                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                {
                                    log_by = empId,
                                    log_desc = $"Employee Sent WhatsApp Message to : {data.mobile}"
                                });

                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("WhatsApp", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                _response = JsonConvert.DeserializeObject<WhatsappResponse>(response.Content);
                                return Json(new { isSuccess = true, message = "WhatsApp Message Sent Successfully to " + data.mobile, data = _response }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("WhatsApp", data.user, "Patient", data.mobile, empId, false, response.Content.ToString(), data.user, "Patient");
                                return Json(new { isSuccess = false, message = "Error while sending message through WhatsApp to " + data.mobile, data = new { } }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Instance ID/Access Token is Invalid", data = new { } }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Patient WhatsApp not enabled.", data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message, data = new { } }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SMSConfig(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_SMS, Action))
            {
                SMSConfig config = new SMSConfig();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("SMS", "Patient", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        config = BusinessLogicLayer.CommunicationMedia.SMSConfig(data.branchId);

                        if (!string.IsNullOrEmpty(config.APIKey) && !string.IsNullOrEmpty(config.SenderID))
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string end_point = "/http/sendsms.aspx?apikey=" + config.APIKey + "&sid=" + config.SenderID + "&msg=" + HttpUtility.UrlEncode(format_message) + "&msgtype=0&mobiles=" + data.mobile + "&dlr=0";
                            var options = new RestClientOptions(ConfigurationManager.AppSettings["SMSGatewayEndPoint"].ToString())
                            {
                                MaxTimeout = -1,
                            };

                            var client = new RestClient(options);
                            var request = new RestRequest(end_point, RestSharp.Method.Get);
                            RestResponse response = await client.ExecuteAsync(request);


                            if (response.IsSuccessful)
                            {
                                if (response.Content.Trim().ToLower().Contains("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent SMS to : {data.mobile}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                    return Json(new { isSuccess = true, message = "SMS Sent Successfully to " + data.mobile }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                    return Json(new { isSuccess = false, message = response.Content.Trim().ToString() }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                return Json(new { isSuccess = false, message = "Error while sending SMS to " + data.mobile }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "SMS Gateway not setup!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Patient SMS not enabled.", data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SMSConfig_AR(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_SMS, Action))
            {
                SMSConfig config = new SMSConfig();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("SMS", "Patient", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        config = BusinessLogicLayer.CommunicationMedia.SMSConfig(data.branchId);

                        if (!string.IsNullOrEmpty(config.APIKey) && !string.IsNullOrEmpty(config.SenderID))
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string end_point = "/http/sendsms.aspx?apikey=" + config.APIKey + "&sid=" + config.SenderID + "&msg=" + HttpUtility.UrlEncode(format_message) + "&msgtype=8&mobiles=" + data.mobile + "&dlr=1";
                            var options = new RestClientOptions(ConfigurationManager.AppSettings["SMSGatewayEndPoint"].ToString())
                            {
                                MaxTimeout = -1,
                            };
                            var client = new RestClient(options);
                            var request = new RestRequest(end_point, RestSharp.Method.Get);
                            RestResponse response = await client.ExecuteAsync(request);


                            if (response.IsSuccessful)
                            {
                                if (response.Content.Trim().ToLower().Contains("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent Arabic SMS to : {data.mobile}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                    return Json(new { isSuccess = true, message = "SMS Sent Successfully to " + data.mobile }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                    return Json(new { isSuccess = false, message = response.Content.Trim().ToString() }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Patient", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                return Json(new { isSuccess = false, message = "Error while sending SMS to " + data.mobile }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "SMS Gateway not setup!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Patient SMS not enabled.", data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> EmailConfig(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_Email, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("Email", "Patient", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        dt = BusinessLogicLayer.CommunicationMedia.EmailConfig(data.templateId);

                        if (dt.Rows.Count > 0)
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string val = await BusinessLogicLayer.CommunicationMedia.SentEmail(format_message, dt, data.email);

                            if (!string.IsNullOrEmpty(val))
                            {
                                if (val.ToLower().Trim().Equals("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent Email to : {data.email}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Patient", data.email, empId, true, "Email Sent Successfully", data.user, "Patient");
                                    return Json(new { isSuccess = true, message = "Email Sent Successfully to " + data.email }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Patient", data.email, empId, false, "Email Not Sent", data.user, "Patient");
                                    return Json(new { isSuccess = false, message = "Pending Email to " + data.email }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Patient", data.email, empId, false, val, data.user, "Patient");
                                return Json(new { isSuccess = false, message = "Error while sending Email to " + data.email }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Email is not setup for this Template" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Patient Email not enabled" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Patient CRUD Operations
        [HttpGet]
        public ActionResult GetPatient_CountryAndNationality(string code = null, string name = null)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CountryWithNationalityAndCitizenship> cn_selected = BusinessLogicLayer.Patient.Patient.ReadCountryAndNationalityFromEMID(code, name);

                    var jsonResult = Json(cn_selected, JsonRequestBehavior.AllowGet);
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
        public ActionResult CreatePatient(BusinessEntities.Patient.PatientWithInsurance patient)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    bool isEnabled = BusinessLogicLayer.Company.isPAPEnabled(int.Parse(emp_branch));
                    TempData["isPAP"] = isEnabled;

                    DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                    ViewData["BranchList"] = BranchList;

                    DataTable dt_religions = BusinessLogicLayer.Patient.Patient.GetReligions(0);
                    SelectList ReligionList = Models.Helper.ToSelectList(dt_religions, "rel_code", "religion");
                    ViewData["ReligionList"] = ReligionList;

                    DataTable dt_countries = BusinessLogicLayer.Patient.Patient.GetCountries(0);
                    SelectList CountryList = Models.Helper.ToSelectList(dt_countries, "countryId", "country");
                    ViewData["CountryList"] = CountryList;

                    DataTable dt_nationalities = BusinessLogicLayer.Nationality.GetNationalities();
                    SelectList NationalityList = Models.Helper.ToSelectList(dt_nationalities, "natId", "nationality");
                    ViewData["NationalityList"] = NationalityList;

                    DataTable dt_citizenship = BusinessLogicLayer.Patient.Patient.GetCitizenship(0);
                    SelectList CitizenshipList = Models.Helper.ToSelectList(dt_citizenship, "citzen_code", "citzen");
                    ViewData["CitizenshipList"] = CitizenshipList;

                    DataTable dt_referals = BusinessLogicLayer.Masters.Referals.GetReferals(0, 0);
                    SelectList ReferalList = Models.Helper.ToSelectList(dt_referals, "refId", "ref_name");
                    ViewData["ReferalList"] = ReferalList;

                    DataTable dt_profession = BusinessLogicLayer.Masters.Designations.GetProfessions(0);
                    SelectList ProfessionList = Models.Helper.ToSelectList(dt_profession, "Id", "Profession");
                    ViewData["ProfessionList"] = ProfessionList;

                    DataTable dt_relationship = BusinessLogicLayer.Patient.Patient.GetRelationship(0);
                    SelectList RelationshipList = Models.Helper.ToSelectList(dt_relationship, "rel_code", "relname");
                    ViewData["RelationshipList"] = RelationshipList;

                    PatientDetails _patient = new PatientDetails();
                    _patient.pat_class = "Normal";
                    _patient.pat_obal_type = "D";
                    _patient.pat_referal = 1;
                    _patient.pat_branch = int.Parse(emp_branch.ToString());
                    _patient.pat_religion = "VAR";
                    _patient.pat_country = 176;
                    _patient.pat_nat = 198;
                    _patient.pat_citizen = "BID";
                    _patient.pat_race = "UN";
                    _patient.pat_occupation = "72";
                    _patient.pat_code = BusinessLogicLayer.Patient.Patient.GenerateMRN();

                    PatientInsuranceDetails _insurance = new PatientInsuranceDetails();
                    _insurance.pi_cded = 0;
                    _insurance.pi_cded_limit = 0;
                    _insurance.pi_cded_type = "Fixed";

                    _insurance.pi_dded = 0;
                    _insurance.pi_dded_limit = 0;
                    _insurance.pi_dded_type = "Fixed";

                    _insurance.pi_ip_dcopay = 0;
                    _insurance.pi_ip_dcopay_limit = 0;
                    _insurance.pi_ip_dcopay_type = "Fixed";

                    _insurance.pi_dcopay = 0;
                    _insurance.pi_dcopay_limit = 0;
                    _insurance.pi_dcopay_type = "Fixed";

                    _insurance.pi_copay = 0;
                    _insurance.pi_copay_limit = 0;
                    _insurance.pi_copay_type = "Fixed";

                    _insurance.pi_hdcopay = 0;
                    _insurance.pi_hdcopay_limit = 0;
                    _insurance.pi_hdcopay_type = "Fixed";

                    _insurance.pi_pded = 0;
                    _insurance.pi_pded_limit = 0;
                    _insurance.pi_pded_type = "Fixed";

                    _insurance.pi_ided = 0;
                    _insurance.pi_ided_limit = 0;
                    _insurance.pi_ided_type = "Fixed";

                    _insurance.pi_mded = 0;
                    _insurance.pi_mded_limit = 0;
                    _insurance.pi_mded_type = "Fixed";

                    _insurance.pi_rded = 0;
                    _insurance.pi_rded_limit = 0;
                    _insurance.pi_rded_type = "Fixed";

                    patient.patient = _patient;
                    patient.insurance = _insurance;

                    return PartialView("CreatePatient", patient);
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
        public ActionResult MergePatient(BusinessEntities.Patient.PatientAndInsurance patient)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("MergePatient", patient);
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
        public ActionResult AllocatePatient(BusinessEntities.Patient.PatientAndInsurance patient)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("AllocatePatient", patient);
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
        public ActionResult InsertPatient(PatientAndInsurance data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    #region Patient
                    PatientDetails p = new PatientDetails();
                    p.patId = data.patId;
                    p.pat_title = data.pat_title;
                    p.pat_class = data.pat_class;
                    p.pat_obal = data.pat_obal;
                    p.pat_obal_type = data.pat_obal_type;
                    p.pat_branch = data.pat_branch;
                    p.pat_code = data.pat_code;
                    p.pat_name = data.pat_name;
                    p.pat_mname = data.pat_mname;
                    p.pat_lname = data.pat_lname;
                    p.pat_dob = data.pat_dob;
                    p.pat_gender = data.pat_gender;
                    p.pat_name_arabic = data.pat_name_arabic;
                    p.pat_lname_arabic = data.pat_lname_arabic;
                    p.pat_tel = data.pat_tel;
                    p.pat_mob = data.pat_mob;
                    p.pat_email = data.pat_email;
                    p.pat_religion = data.pat_religion;
                    p.pat_race = data.pat_race;
                    p.pat_nat = data.pat_nat;
                    p.pat_citizen = data.pat_citizen;
                    p.pat_rel_address = data.pat_rel_address;
                    p.pat_country = data.pat_country;
                    p.pat_ms = data.pat_ms;
                    p.pat_fax = data.pat_fax;
                    p.pat_emirateid = data.pat_emirateid;
                    p.pat_passport = data.pat_passport;
                    p.pat_occupation = data.pat_occupation;
                    p.pat_referal = data.pat_referal;
                    p.pat_city = data.pat_city;
                    p.pat_pobox = data.pat_pobox;
                    p.pat_notes = data.pat_notes;
                    p.pat_address = data.pat_address;
                    p.pat_doc_1 = data.pat_doc_1;
                    p.pat_doc_2 = data.pat_doc_2;
                    p.pat_doc_3 = data.pat_doc_3;
                    p.pat_doc_4 = data.pat_doc_4;
                    p.pat_doc_5 = data.pat_doc_5;
                    p.pat_photo = data.pat_photo;
                    p.pat_ec_name1 = data.pat_ec_name1;
                    p.pat_ec_rel1 = data.pat_ec_rel1;
                    p.pat_ec_tel1 = data.pat_ec_tel1;
                    p.pat_ec_tel11 = data.pat_ec_tel11;
                    p.pat_ec_name2 = data.pat_ec_name2;
                    p.pat_ec_rel2 = data.pat_ec_rel2;
                    p.pat_ec_tel2 = data.pat_ec_tel2;
                    p.pat_ec_tel22 = data.pat_ec_tel22;
                    p.pat_ec_name3 = data.pat_ec_name3;
                    p.pat_ec_rel3 = data.pat_ec_rel3;
                    p.pat_ec_tel3 = data.pat_ec_tel3;
                    p.pat_ec_tel33 = data.pat_ec_tel33;
                    p.id_card_front = data.id_card_front;
                    p.id_card_back = data.id_card_back;
                    p.id_card_idate = data.id_card_idate;
                    p.id_card_edate = data.id_card_edate;
                    p.pat_ethnic = data.pat_ethnic;
                    #endregion

                    #region Insurance
                    PatientInsuranceDetails i = new PatientInsuranceDetails();
                    i.piId = data.piId;
                    i.pi_insurance = data.pi_insurance;
                    i.pi_scheme = data.pi_scheme;
                    i.pi_payer = data.pi_payer;
                    i.pi_idate = data.pi_idate;
                    i.pi_edate = data.pi_edate;
                    i.pi_insno = data.pi_insno;
                    i.pi_polocyno = data.pi_polocyno;
                    i.pi_cded_type = data.pi_cded_type;
                    i.pi_cded = data.pi_cded;
                    i.pi_cded_limit = data.pi_cded_limit;
                    i.pi_ip_dcopay_type = data.pi_ip_dcopay_type;
                    i.pi_ip_dcopay = data.pi_ip_dcopay;
                    i.pi_ip_dcopay_limit = data.pi_ip_dcopay_limit;
                    i.pi_dded_type = data.pi_dded_type;
                    i.pi_dded = data.pi_dded;
                    i.pi_dded_limit = data.pi_dded_limit;
                    i.pi_copay_type = data.pi_copay_type;
                    i.pi_copay = data.pi_copay;
                    i.pi_copay_limit = data.pi_copay_limit;
                    i.pi_dcopay_type = data.pi_dcopay_type;
                    i.pi_dcopay = data.pi_dcopay;
                    i.pi_dcopay_limit = data.pi_dcopay_limit;
                    i.pi_hdcopay_type = data.pi_hdcopay_type;
                    i.pi_hdcopay = data.pi_hdcopay;
                    i.pi_hdcopay_limit = data.pi_hdcopay_limit;
                    i.pi_pded_type = data.pi_pded_type;
                    i.pi_pded = data.pi_pded;
                    i.pi_pded_limit = data.pi_pded_limit;
                    i.pi_ided_type = data.pi_ided_type;
                    i.pi_ided = data.pi_ided;
                    i.pi_ided_limit = data.pi_ided_limit;
                    i.pi_rded_type = data.pi_rded_type;
                    i.pi_rded = data.pi_rded;
                    i.pi_rded_limit = data.pi_rded_limit;
                    i.pi_mded_type = data.pi_mded_type;
                    i.pi_mded = data.pi_mded;
                    i.pi_mded_limit = data.pi_mded_limit;
                    i.pi_limit = data.pi_limit;
                    i.pi_ceiling = data.pi_ceiling;
                    i.pi_image = data.pi_image;
                    i.pi_image2 = data.pi_image2;
                    #endregion

                    PatientWithInsurance pni = new PatientWithInsurance();
                    pni.patient = p;
                    pni.insurance = i;

                    pni.patient.pat_mob = (pni.patient.pat_mob.Trim() == "+971") ? "" : pni.patient.pat_mob.Trim().Replace("+", "");
                    pni.patient.pat_tel = (pni.patient.pat_tel.Trim() == "+971") ? "" : pni.patient.pat_tel.Trim().Replace("+", "");
                    pni.patient.pat_ec_tel1 = (pni.patient.pat_ec_tel1.Trim() == "+971") ? "" : pni.patient.pat_ec_tel1.Trim().Replace("+", "");
                    pni.patient.pat_ec_tel11 = (pni.patient.pat_ec_tel11.Trim() == "+971") ? "" : pni.patient.pat_ec_tel11.Trim().Replace("+", "");
                    pni.patient.pat_ec_tel2 = (pni.patient.pat_ec_tel2.Trim() == "+971") ? "" : pni.patient.pat_ec_tel2.Trim().Replace("+", "");
                    pni.patient.pat_ec_tel22 = (pni.patient.pat_ec_tel22.Trim() == "+971") ? "" : pni.patient.pat_ec_tel22.Trim().Replace("+", "");
                    pni.patient.pat_ec_tel3 = (pni.patient.pat_ec_tel3.Trim() == "+971") ? "" : pni.patient.pat_ec_tel3.Trim().Replace("+", "");
                    pni.patient.pat_ec_tel33 = (pni.patient.pat_ec_tel33.Trim() == "+971") ? "" : pni.patient.pat_ec_tel33.Trim().Replace("+", "");
                    pni.patient.pat_photo = (string.IsNullOrEmpty(pni.patient.pat_photo)) ? string.Empty : pni.patient.pat_photo;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Patient.isValidPatient(pni, out errors))
                    {
                        string file_path = Server.MapPath("~/images/patient_images/");
                        string path = string.Empty;

                        string file_name_pat_photo = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                        string file_name_eid_front = "eid_front_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_eid_back = "eid_back_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_ins_front = "ins_front_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_ins_back = "ins_back_" + DateTime.Now.ToString("yyyyMMddHHmmss");

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

                        if (Request.Files.Count > 0)
                        {
                            HttpFileCollectionBase files = Request.Files;

                            for (int j = 0; j < files.Count; j++)
                            {
                                HttpPostedFileBase file = files[j];

                                if (files.AllKeys[j] == "id_card_front")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_eid_front = file_name_eid_front + _extension;
                                            string _path = Path.Combine(file_path, file_name_eid_front);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            pni.patient.id_card_front = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("id_card_front", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "id_card_back")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_eid_back = file_name_eid_back + _extension;
                                            string _path = Path.Combine(file_path, file_name_eid_back);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            pni.patient.id_card_back = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("id_card_back", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "pi_image")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_ins_front = file_name_ins_front + _extension;
                                            string _path = Path.Combine(file_path, file_name_ins_front);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            pni.insurance.pi_image = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("pi_image", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "pi_image2")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_ins_back = file_name_ins_back + _extension;
                                            string _path = Path.Combine(file_path, file_name_ins_back);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            pni.insurance.pi_image2 = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("pi_image2", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                            }
                        }

                        if (pni.patient.pat_photo.StartsWith("/9j"))
                        {
                            path = Path.Combine(file_path, file_name_pat_photo);
                            Byte[] bytes = Convert.FromBase64String(pni.patient.pat_photo);
                            System.IO.File.WriteAllBytes(path, bytes);
                            pni.patient.pat_photo = path.Replace(Server.MapPath("~/images/patient_images/"), "");
                        }
                        else
                        {
                            pni.patient.pat_photo = string.Empty;
                        }

                        int piId_output = 0;
                        int val = BusinessLogicLayer.Patient.Patient.InsertPatient(pni, PageControl.getLoggedinId(), out piId_output);

                        if (val > 0)
                        {
                            Dictionary<string, int> dic = new Dictionary<string, int>();
                            dic.Add("patId", val);
                            dic.Add("piId", piId_output);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Created New Patient : {data.pat_name}"
                            });

                            return Json(new { isSuccess = true, message = dic }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_ins_front))) { System.IO.File.Delete(Path.Combine(file_path, file_name_ins_front)); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_ins_back))) { System.IO.File.Delete(Path.Combine(file_path, file_name_ins_back)); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_eid_front))) { System.IO.File.Delete(Path.Combine(file_path, file_name_eid_front)); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_eid_back))) { System.IO.File.Delete(Path.Combine(file_path, file_name_eid_back)); }

                            if (val == -1)
                            {
                                errors.Add("pat_emirateid", "Another patient already exists with same emirates Id");
                            }
                            else if (val == -2)
                            {
                                errors.Add("pat_name,pat_lname,pat_mob", "Another patient already exists with combination of First and Last Name and Mobile No.");
                            }
                            else if (val == -3)
                            {
                                errors.Add("pat_passport", "Another patient already exists with same passport number");
                            }
                            else
                            {
                                errors.Add("", "Error while Creating New Patient! Please Try Again...");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult EditPatient(int patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    bool isEnabled = BusinessLogicLayer.Company.isPAPEnabled(int.Parse(emp_branch));
                    TempData["isPAP"] = isEnabled;

                    DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                    ViewData["BranchList"] = BranchList;

                    DataTable dt_religions = BusinessLogicLayer.Patient.Patient.GetReligions(0);
                    SelectList ReligionList = Models.Helper.ToSelectList(dt_religions, "rel_code", "religion");
                    ViewData["ReligionList"] = ReligionList;

                    DataTable dt_countries = BusinessLogicLayer.Patient.Patient.GetCountries(0);
                    SelectList CountryList = Models.Helper.ToSelectList(dt_countries, "countryId", "country");
                    ViewData["CountryList"] = CountryList;

                    DataTable dt_nationalities = BusinessLogicLayer.Nationality.GetNationalities();
                    SelectList NationalityList = Models.Helper.ToSelectList(dt_nationalities, "natId", "nationality");
                    ViewData["NationalityList"] = NationalityList;

                    DataTable dt_citizenship = BusinessLogicLayer.Patient.Patient.GetCitizenship(0);
                    SelectList CitizenshipList = Models.Helper.ToSelectList(dt_citizenship, "citzen_code", "citzen");
                    ViewData["CitizenshipList"] = CitizenshipList;

                    DataTable dt_referals = BusinessLogicLayer.Masters.Referals.GetReferals(0, 0);
                    SelectList ReferalList = Models.Helper.ToSelectList(dt_referals, "refId", "ref_name");
                    ViewData["ReferalList"] = ReferalList;

                    DataTable dt_profession = BusinessLogicLayer.Masters.Designations.GetProfessions(0);
                    SelectList ProfessionList = Models.Helper.ToSelectList(dt_profession, "Id", "Profession");
                    ViewData["ProfessionList"] = ProfessionList;

                    DataTable dt_relationship = BusinessLogicLayer.Patient.Patient.GetRelationship(0);
                    SelectList RelationshipList = Models.Helper.ToSelectList(dt_relationship, "rel_code", "relname");
                    ViewData["RelationshipList"] = RelationshipList;

                    PatientDetails patient = BusinessLogicLayer.Patient.Patient.GetPatientById(patId);
                    
                    return PartialView("EditPatient", patient);
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
        public async Task<ActionResult> UpdatePatient(PatientDetails data)
        {
            int Action = (int)Actions.Update;
            MNRAck ack = new MNRAck();
            int appId = data.appId;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    data.pat_mob = (data.pat_mob.Trim() == "+971") ? "" : data.pat_mob.Trim().Replace("+", "");
                    data.pat_tel = (data.pat_tel.Trim() == "+971") ? "" : data.pat_tel.Trim().Replace("+", "");
                    data.pat_ec_tel1 = (data.pat_ec_tel1.Trim() == "+971") ? "" : data.pat_ec_tel1.Trim().Replace("+", "");
                    data.pat_ec_tel11 = (data.pat_ec_tel11.Trim() == "+971") ? "" : data.pat_ec_tel11.Trim().Replace("+", "");
                    data.pat_ec_tel2 = (data.pat_ec_tel2.Trim() == "+971") ? "" : data.pat_ec_tel2.Trim().Replace("+", "");
                    data.pat_ec_tel22 = (data.pat_ec_tel22.Trim() == "+971") ? "" : data.pat_ec_tel22.Trim().Replace("+", "");
                    data.pat_ec_tel3 = (data.pat_ec_tel3.Trim() == "+971") ? "" : data.pat_ec_tel3.Trim().Replace("+", "");
                    data.pat_ec_tel33 = (data.pat_ec_tel33.Trim() == "+971") ? "" : data.pat_ec_tel33.Trim().Replace("+", "");
                    data.pat_photo = (string.IsNullOrEmpty(data.pat_photo)) ? string.Empty : data.pat_photo;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Patient.isValidForUpdatePatient(data, out errors))
                    {
                        string file_path = Server.MapPath("~/images/patient_images/");
                        string path = string.Empty;
                        string file_name_pat_photo = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                        string file_name_eid_front = "eid_front_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_eid_back = "eid_back_" + DateTime.Now.ToString("yyyyMMddHHmmss");

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

                        if (Request.Files.Count > 0)
                        {
                            HttpFileCollectionBase files = Request.Files;

                            for (int j = 0; j < files.Count; j++)
                            {
                                HttpPostedFileBase file = files[j];

                                if (files.AllKeys[j] == "uid_card_front")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_eid_front = file_name_eid_front + _extension;
                                            string _path = Path.Combine(file_path, file_name_eid_front);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.id_card_front = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("uid_card_front", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "uid_card_back")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_eid_back = file_name_eid_back + _extension;
                                            string _path = Path.Combine(file_path, file_name_eid_back);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.id_card_back = _path.Replace(Server.MapPath("~/images/patient_images/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("uid_card_back", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                            }
                        }

                        if (data.pat_photo.StartsWith("/9j"))
                        {
                            path = Path.Combine(file_path, file_name_pat_photo);
                            Byte[] bytes = Convert.FromBase64String(data.pat_photo);
                            System.IO.File.WriteAllBytes(path, bytes);
                            data.pat_photo = path.Replace(Server.MapPath("~/images/patient_images/"), "");
                        }
                        else if (string.IsNullOrEmpty(data.pat_photo))
                        {
                            data.pat_photo = string.Empty;
                        }

                        int val = BusinessLogicLayer.Patient.Patient.UpdatePatient(data, PageControl.getLoggedinId());

                        if (val > 0)
                        {
                            Dictionary<string, int> dic = new Dictionary<string, int>();
                            dic.Add("patId", val);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Updated Patient with patId = {data.patId}"
                            });

                            if (appId > 0)
                            {
                                DataSet ds = BusinessLogicLayer.EMR.EMR_Patient.GetPatientEMRInfo(appId);
                                DataTable dt = ds.Tables[0];
                                var value = appId;
                                if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                                {
                                    if (dt.Rows[0]["set_sync"].ToString() == "Yes")
                                    {
                                        if (dt.Rows[0]["set_mnr"].ToString() == "Nabidh")
                                        {
                                            ack = await MNR.Nabidh.ADTA31(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), dt.Rows[0]["app_fdate_time"].ToString(), value);

                                        }
                                        else if (dt.Rows[0]["set_mnr"].ToString() == "Riayati")
                                        {
                                            //ack = await MNR.Riayati.ADTA31(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value, app.app_inout);

                                        }
                                        else if (dt.Rows[0]["set_mnr"].ToString() == "Malaffi")
                                        {
                                            //ack = await MNR.Malaffi.ADTA31(int.Parse(dt.Rows[0]["appId"].ToString()), int.Parse(dt.Rows[0]["pat_code"].ToString()), int.Parse(dt.Rows[0]["patId"].ToString()), value);

                                        }
                                        else
                                        {
                                            ack = new MNRAck
                                            {
                                                value = value,
                                                message = "Patient Updated Successfully"
                                            };


                                        }
                                        return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = value,
                                            message = "Patient Updated Successfully"
                                        };
                                        return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                                    }
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = value,
                                        message = "Patient Updated Successfully"
                                    };
                                    return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = val,
                                    message = "Patient Updated Successfully"
                                };
                                return Json(new { isSuccess = true, message = ack }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_eid_front))) { System.IO.File.Delete(Path.Combine(file_path, file_name_eid_front)); }
                            if (System.IO.File.Exists(Path.Combine(file_path, file_name_eid_back))) { System.IO.File.Delete(Path.Combine(file_path, file_name_eid_back)); }

                            if (val == -1)
                            {
                                errors.Add("upat_emirateid", "Another patient already exists with same emirates Id");
                            }
                            else if (val == -2)
                            {
                                errors.Add("upat_name,pat_lname,pat_mob", "Another patient already exists with combination of First and Last Name and Mobile");
                            }
                            else if (val == -3)
                            {
                                errors.Add("upat_passport", "Another patient already exists with same passport number");
                            }
                            else
                            {
                                errors.Add("", "Error to inserting the new patient.. please try again...");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateBulkStatus(PatientBulkStatus data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Patient.Patient.UpdateBulkPatientStatus(data);

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Bulk Patient Status to : {data.status} with patIds = {data.patIds}"
                    });

                    return Json(new { isSuccess = true, message = val.ToString("D2") + " Status Updated to " + data.status }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Error while Updating Patient Status!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult DeletePatient(int patId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Patient.Patient.ChangePatientStatus(patId, "Deleted", PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Deleted Patient with patId = {patId}"
                    });
                    return Json(new { isAuthorized = true, success = true, message = "Appointment Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed to Delete Appointment!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = true, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult ViewDocument(int id)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Lists.DownloadEMID file = new BusinessEntities.Lists.DownloadEMID();

                    DataTable dt = BusinessLogicLayer.Lists.DownloadFile.GetEMIDPathDownload(id);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        string id_card_front = string.Empty;
                        string id_card_back = string.Empty;

                        if (!string.IsNullOrEmpty(row["file_path"].ToString()))
                        {
                            id_card_front = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images/patient_images/", row["file_path"].ToString().Trim());
                        }

                        if (!string.IsNullOrEmpty(row["file_path1"].ToString()))
                        {
                            id_card_back = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images/patient_images/", row["file_path1"].ToString().Trim());
                        }

                        file.id_card_front = id_card_front;
                        file.id_card_back = id_card_back;
                        file.id = id;

                        return PartialView("ViewEMID", file);
                    }
                    else
                    {
                        return PartialView("ViewEMID", file);
                    }
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
        #endregion

        #region Patient Miscellaneous Functions
        [HttpGet]
        public ActionResult GetCountryInfoById(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataTable dt = BusinessLogicLayer.Lists.Countries.GetCountries(id);
                    string _code = string.Empty;

                    if (dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(dt.Rows[0]["country_code"].ToString()))
                        {
                            _code = dt.Rows[0]["country_code"].ToString();
                        }
                    }
                    var jsonResult = Json(_code, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(string.Empty, JsonRequestBehavior.AllowGet);
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
        public ActionResult PatientAuditLog(int patId, string pat_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    List<BusinessEntities.Patient.PatientAudit> patients = new List<BusinessEntities.Patient.PatientAudit>();

                    PatientAuditView audit = new PatientAuditView();

                    audit.pat_name = pat_name;
                    audit.log_data = BusinessLogicLayer.Patient.Patient.PatientAuditLog(patId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Patient Audit Logs with patId = {patId}"
                    });

                    return PartialView("PatientAuditLog", audit);
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
        public ActionResult PatientRemarks(int? id, string flag, DateTime? fdate, int? ftime, int? patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_name = claims.Where(c => c.Type == ClaimTypes.Name).Select(c => c.Value).SingleOrDefault();

                    Remarks data = new Remarks();

                    data.arId = 0;
                    data.ar_employee = PageControl.getLoggedinId();
                    data.ar_employee_name = emp_name;
                    data.ar_remarks = "";
                    data.ar_date_created = DateTime.Now.Date;
                    data.ar_patId = (int)patId;

                    if (flag == "Patient")
                    {
                        data.ar_appId = 0;
                        data.ar_ftime = 0;
                        data.ar_fllowupdate = DateTime.Now.Date;
                    }
                    else if (flag == "Appointment")
                    {
                        data.ar_appId = (int)id;
                        data.ar_ftime = (int)ftime;
                        data.ar_fllowupdate = (DateTime)fdate;
                    }

                    data.ar_flag = flag;
                    data.ar_status = "Active";

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Patient Remarks"
                    });

                    return PartialView("PatientRemarks", data);
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
        public ActionResult GetPatientRemarks(int id, string flag, int patId = 0)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                List<Remarks> remarks_data = new List<Remarks>();

                try
                {
                    if (flag == "Patient")
                    {
                        remarks_data = BusinessLogicLayer.Patient.Patient.GetRemarks(id, 1);
                    }
                    else if (flag == "Appointment")
                    {
                        remarks_data = BusinessLogicLayer.Patient.Patient.GetRemarks(id, 2);
                    }

                    var jsonResult = Json(new { isSuccess = true, message = remarks_data }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isSuccess = true, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRemarks(Remarks data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (!string.IsNullOrEmpty(data.ar_remarks))
                    {
                        data.ar_employee = PageControl.getLoggedinId();

                        int val = BusinessLogicLayer.Patient.Patient.RemarksInsert(data);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.ar_employee,
                                log_desc = $"Employee Created New Remark : {data.ar_remarks}"
                            });

                            return Json(new { isAutherized = true, isSuccess = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            errors.Add("", "Error while Creating Remarks! Please try again...");

                            return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        errors.Add("ar_remarks", "Please Enter Remarks");
                        return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAutherized = false, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult DeleteRemark(int arId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Patient.Patient.RemarksDelete(arId, PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Deleted Remark with arId = {arId}"
                    });

                    return Json(new { isAuthorized = true, success = true, message = "Remark Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed To Delete Remark!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult PatientDetail(int patId, string pat_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_Details, Action))
                {
                    PatientDetailInfo info = new PatientDetailInfo();
                    info.pat_name = pat_name;
                    info.pat_info = BusinessLogicLayer.Patient.Patient.GetPatientById(patId);
                    info.acc_summary = BusinessLogicLayer.Patient.PatientProfile.PatientAccountSummary(patId);
                    info.app_status_summary = BusinessLogicLayer.Patient.PatientProfile.PatientAppStatusSummary(patId);
                    info.summary = BusinessLogicLayer.Patient.PatientProfile.PatientInfoSummary(patId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Patient Details with patId = {patId}"
                    });

                    return PartialView("PatientDetail", info);
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
        public ActionResult PatientDocuments(int patId, string pat_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DocReference doc_ref = new DocReference();
                    doc_ref.refId = patId;
                    doc_ref.reftype = "Patient";
                    doc_ref.ref_name = pat_name;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Patient Documents with patId = {patId}"
                    });

                    return PartialView("PatientDocuments", doc_ref);
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
        public ActionResult UploadFiles(BusinessEntities.Common.DocData data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    bool issuccess = false;
                    DocErrorResponse err = new DocErrorResponse();

                    string file_path = Server.MapPath("~/images/uploaded_documents/");

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

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int j = 0; j < files.Count; j++)
                        {
                            HttpPostedFileBase _file = files[j];

                            if (_file.ContentLength > 0)
                            {
                                if (_file.ContentLength <= 5242880)
                                {
                                    issuccess = true;

                                    string _extension = Path.GetExtension(_file.FileName);
                                    string _file_name = DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                    string _path = Path.Combine(file_path, _file_name);

                                    DocumentUpload doc = new DocumentUpload();
                                    doc.doc_refId = data.id;
                                    doc.doc_reftype = data.type;
                                    doc.doc_label = string.IsNullOrEmpty(data.label) ? string.Empty : data.label;
                                    doc.doc_name = _file_name;
                                    doc.doc_ext = _extension;
                                    doc.doc_path = _path;
                                    doc.doc_uploadedBy = PageControl.getLoggedinId();
                                    doc.doc_category = data.doc_category;

                                    if (doc.doc_refId > 0 && !string.IsNullOrEmpty(doc.doc_reftype))
                                    {
                                        if (BusinessLogicLayer.Common.Documents.UploadDocument(doc))
                                        {

                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            _file.SaveAs(_path);

                                        }
                                    }

                                }
                                else
                                {
                                    err.success = false;
                                    err.errorcode = HttpStatusCode.RequestEntityTooLarge.ToString();
                                    err.error = "Uploaded File should not be exceed to 5MB";
                                }
                            }
                            else
                            {
                                err.success = false;
                                err.errorcode = HttpStatusCode.NotFound.ToString();
                                err.error = "File Not Received";
                            }
                        }
                    }

                    if (issuccess)
                    {
                        DocSuccessResponse success = new DocSuccessResponse();
                        success.success = true;

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Uploaded Patient Documents"
                        });

                        return Json(success, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(err, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    DocErrorResponse err = new DocErrorResponse();
                    err.success = false;
                    err.errorcode = HttpStatusCode.InternalServerError.ToString();
                    err.error = ex.Message;

                    return Json(err, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetDocumentsById(int id, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                List<DocumentUpload> doc_data = new List<DocumentUpload>();
                try
                {
                    string path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString();
                    if (type == "Patient")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetDocumentsById(id, 1, path);
                    }
                    else if (type == "Employee")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetDocumentsById(id, 2, path);
                    }
                    else if (type == "Appointment")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetDocumentsById(id, 3, path);
                    }
                    else if (type == "EMR")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetDocumentsById(id, 5, path);
                    }
                    else if (type == "Investigation")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetDocumentsById(id, 6, path);
                    }
                    var jsonResult = Json(new { isAutherized = true, isSuccess = true, message = doc_data }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult DeleteDocument(int docId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                bool val = BusinessLogicLayer.Common.Documents.DeleteDocuments(docId, PageControl.getLoggedinId());

                if (val)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Deleted Document with docId = {docId}"
                    });

                    return Json(new { isAuthorized = true, success = true, message = "Document Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed To Delete Document!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Enquiry Patient CRUD Operations
        [HttpGet]
        public ActionResult CreateInquiryPatient(BusinessEntities.Patient.PatientWithInsurance patient)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    PatientDetails _patient = new PatientDetails();
                    _patient.pat_class = "Normal";
                    _patient.pat_obal_type = "D";
                    _patient.pat_referal = 1;
                    _patient.pat_branch = int.Parse(emp_branch.ToString());
                    _patient.pat_religion = "VAR";
                    _patient.pat_country = 176;
                    _patient.pat_nat = 198;
                    _patient.pat_citizen = "BID";
                    _patient.pat_race = "UN";
                    _patient.pat_occupation = "72";
                    _patient.pat_code = "0";

                    PatientInsuranceDetails _insurance = new PatientInsuranceDetails();
                    _insurance.pi_cded = 0;
                    _insurance.pi_cded_limit = 0;
                    _insurance.pi_cded_type = "Fixed";

                    _insurance.pi_dded = 0;
                    _insurance.pi_dded_limit = 0;
                    _insurance.pi_dded_type = "Fixed";

                    _insurance.pi_ip_dcopay = 0;
                    _insurance.pi_ip_dcopay_limit = 0;
                    _insurance.pi_ip_dcopay_type = "Fixed";

                    _insurance.pi_dcopay = 0;
                    _insurance.pi_dcopay_limit = 0;
                    _insurance.pi_dcopay_type = "Fixed";

                    _insurance.pi_copay = 0;
                    _insurance.pi_copay_limit = 0;
                    _insurance.pi_copay_type = "Fixed";

                    _insurance.pi_hdcopay = 0;
                    _insurance.pi_hdcopay_limit = 0;
                    _insurance.pi_hdcopay_type = "Fixed";

                    _insurance.pi_pded = 0;
                    _insurance.pi_pded_limit = 0;
                    _insurance.pi_pded_type = "Fixed";

                    _insurance.pi_ided = 0;
                    _insurance.pi_ided_limit = 0;
                    _insurance.pi_ided_type = "Fixed";

                    _insurance.pi_mded = 0;
                    _insurance.pi_mded_limit = 0;
                    _insurance.pi_mded_type = "Fixed";

                    _insurance.pi_rded = 0;
                    _insurance.pi_rded_limit = 0;
                    _insurance.pi_rded_type = "Fixed";

                    patient.patient = _patient;
                    patient.insurance = _insurance;

                    DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                    ViewData["BranchList"] = BranchList;

                    return PartialView("CreateInquiryPatient", patient);
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
        public ActionResult InsertInquiryPatient(PatientAndInsurance data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    #region Patient
                    PatientDetails p = new PatientDetails();
                    p.patId = data.patId;
                    p.pat_title = data.pat_title;
                    p.pat_class = data.pat_class;
                    p.pat_obal = data.pat_obal;
                    p.pat_obal_type = data.pat_obal_type;
                    p.pat_branch = data.pat_branch;
                    p.pat_code = data.pat_code;
                    p.pat_name = data.pat_name;
                    p.pat_mname = data.pat_mname;
                    p.pat_lname = data.pat_lname;
                    p.pat_dob = data.pat_dob;
                    p.pat_gender = data.pat_gender;
                    p.pat_name_arabic = data.pat_name_arabic;
                    p.pat_lname_arabic = data.pat_lname_arabic;
                    p.pat_tel = data.pat_tel;
                    p.pat_mob = data.pat_mob;
                    p.pat_email = data.pat_email;
                    p.pat_religion = data.pat_religion;
                    p.pat_race = data.pat_race;
                    p.pat_nat = data.pat_nat;
                    p.pat_citizen = data.pat_citizen;
                    p.pat_rel_address = data.pat_rel_address;
                    p.pat_country = data.pat_country;
                    p.pat_ms = data.pat_ms;
                    p.pat_fax = data.pat_fax;
                    p.pat_emirateid = data.pat_emirateid;
                    p.pat_passport = data.pat_passport;
                    p.pat_occupation = data.pat_occupation;
                    p.pat_referal = data.pat_referal;
                    p.pat_city = data.pat_city;
                    p.pat_pobox = data.pat_pobox;
                    p.pat_notes = data.pat_notes;
                    p.pat_address = data.pat_address;
                    p.pat_doc_1 = data.pat_doc_1;
                    p.pat_doc_2 = data.pat_doc_2;
                    p.pat_doc_3 = data.pat_doc_3;
                    p.pat_doc_4 = data.pat_doc_4;
                    p.pat_doc_5 = data.pat_doc_5;
                    p.pat_photo = data.pat_photo;
                    p.pat_ec_name1 = data.pat_ec_name1;
                    p.pat_ec_rel1 = data.pat_ec_rel1;
                    p.pat_ec_tel1 = data.pat_ec_tel1;
                    p.pat_ec_tel11 = data.pat_ec_tel11;
                    p.pat_ec_name2 = data.pat_ec_name2;
                    p.pat_ec_rel2 = data.pat_ec_rel2;
                    p.pat_ec_tel2 = data.pat_ec_tel2;
                    p.pat_ec_tel22 = data.pat_ec_tel22;
                    p.pat_ec_name3 = data.pat_ec_name3;
                    p.pat_ec_rel3 = data.pat_ec_rel3;
                    p.pat_ec_tel3 = data.pat_ec_tel3;
                    p.pat_ec_tel33 = data.pat_ec_tel33;
                    p.id_card_front = data.id_card_front;
                    p.id_card_back = data.id_card_back;
                    p.id_card_idate = data.id_card_idate;
                    p.id_card_edate = data.id_card_edate;
                    #endregion

                    #region Insurance
                    PatientInsuranceDetails i = new PatientInsuranceDetails();
                    i.piId = data.piId;
                    i.pit_insurance = data.pit_insurance;
                    i.pi_insurance = data.pi_insurance;
                    i.is_insurance = data.is_insurance;
                    i.pi_idate = data.pi_idate;
                    i.pi_edate = data.pi_edate;
                    i.pi_insno = data.pi_insno;
                    i.pi_polocyno = data.pi_polocyno;
                    i.pi_cded_type = data.pi_cded_type;
                    i.pi_cded = data.pi_cded;
                    i.pi_cded_limit = data.pi_cded_limit;
                    i.pi_ip_dcopay_type = data.pi_ip_dcopay_type;
                    i.pi_ip_dcopay = data.pi_ip_dcopay;
                    i.pi_ip_dcopay_limit = data.pi_ip_dcopay_limit;
                    i.pi_dded_type = data.pi_dded_type;
                    i.pi_dded = data.pi_dded;
                    i.pi_dded_limit = data.pi_dded_limit;
                    i.pi_copay_type = data.pi_copay_type;
                    i.pi_copay = data.pi_copay;
                    i.pi_copay_limit = data.pi_copay_limit;
                    i.pi_dcopay_type = data.pi_dcopay_type;
                    i.pi_dcopay = data.pi_dcopay;
                    i.pi_dcopay_limit = data.pi_dcopay_limit;
                    i.pi_hdcopay_type = data.pi_hdcopay_type;
                    i.pi_hdcopay = data.pi_hdcopay;
                    i.pi_hdcopay_limit = data.pi_hdcopay_limit;
                    i.pi_pded_type = data.pi_pded_type;
                    i.pi_pded = data.pi_pded;
                    i.pi_pded_limit = data.pi_pded_limit;
                    i.pi_ided_type = data.pi_ided_type;
                    i.pi_ided = data.pi_ided;
                    i.pi_ided_limit = data.pi_ided_limit;
                    i.pi_rded_type = data.pi_rded_type;
                    i.pi_rded = data.pi_rded;
                    i.pi_rded_limit = data.pi_rded_limit;
                    i.pi_mded_type = data.pi_mded_type;
                    i.pi_mded = data.pi_mded;
                    i.pi_mded_limit = data.pi_mded_limit;
                    i.pi_limit = data.pi_limit;
                    i.pi_ceiling = data.pi_ceiling;
                    i.pi_image = data.pi_image;
                    i.pi_image2 = data.pi_image2;
                    #endregion

                    PatientWithInsurance pni = new PatientWithInsurance();
                    pni.patient = p;
                    pni.insurance = i;

                    pni.patient.pat_mob = (pni.patient.pat_mob.Trim() == "+971") ? "" : pni.patient.pat_mob.Trim().Replace("+", "");
                    pni.patient.pat_photo = (string.IsNullOrEmpty(pni.patient.pat_photo)) ? string.Empty : pni.patient.pat_photo;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Patient.isValidForInsertInquiryPatient(pni, out errors))
                    {
                        pni.patient.pat_photo = string.Empty;

                        int piId_output = 0;
                        int val = BusinessLogicLayer.Patient.Patient.InsertInquiryPatient(pni, PageControl.getLoggedinId(), out piId_output);

                        if (val > 0)
                        {
                            Dictionary<string, int> dic = new Dictionary<string, int>();
                            dic.Add("patId", val);
                            dic.Add("piId", piId_output);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Created New Enquiry Patient : {data.pat_name}"
                            });

                            return Json(new { isSuccess = true, message = dic }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("ipat_name,ipat_lname,ipat_mob", "Another patient already exists with the combination of First & Last Name and Mobile");
                            }
                            else
                            {
                                errors.Add("", "Error While Creating New Enquiry Patient! Please Try Again...");
                            }
                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult EditInquiryPatient(int patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientInquiry patient = BusinessLogicLayer.Patient.Patient.GetInquiryPatient(patId);

                    return PartialView("EditInquiryPatient", patient);
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
        public ActionResult UpdateInquiryPatient(PatientDetails data)
        {
            int Action = (int)Actions.Update;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pat_mob = (data.pat_mob.Trim() == "+971") ? "" : data.pat_mob.Trim().Replace("+", "");

                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Patient.isValidForUpdateInquiryPatient(data, out errors))
                    {
                        data.pat_dob = DateTime.Parse("1900-01-01");
                        data.pat_country = 176;
                        data.pat_nat = 198;

                        int val = BusinessLogicLayer.Patient.Patient.UpdatePatient(data, PageControl.getLoggedinId());

                        if (val > 0)
                        {
                            Dictionary<string, int> dic = new Dictionary<string, int>();

                            dic.Add("patId", val);

                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Updated Enquiry Patient patId = {data.patId}"
                            });

                            return Json(new { isSuccess = true, message = dic }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("ipat_name,ipat_lname,ipat_mob", "Another patient already exists with the combination of First, Last Name and Mobile No.");
                            }
                            else
                            {
                                errors.Add("", "Error While Updating Patient! Please Try Again...");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Packages
        [HttpGet]
        public ActionResult patientPackages(int? patId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    PatientPackage package = new PatientPackage();


                    package.po_patId = (int)patId;
                    return PartialView("patientPackages", package);
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
        public ActionResult GetPatientPackages(int po_patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                List<PatientPackage> remarks_data = new List<PatientPackage>();

                try
                {

                    remarks_data = BusinessLogicLayer.Patient.Patient.GetPatientPackages(po_patId, 0);


                    var jsonResult = Json(new { isSuccess = true, message = remarks_data }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isSuccess = true, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public PartialViewResult EditPackage(int poId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.EMR.PatientPackage package = BusinessLogicLayer.Patient.Patient.GetPatientPackages(0, poId).FirstOrDefault();

                    return PartialView("EditPackage", package);
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
        #endregion

        #region GetPatients
        [HttpGet]
        public ActionResult SearchPatients(string query, int type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Patient.Patient.SearchPatients(query, type);

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

        [HttpGet]
        public ActionResult GetPatientMerge(PatientSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                List<BusinessEntities.Patient.PatientMerge> patients = new List<BusinessEntities.Patient.PatientMerge>();

                try
                {
                    patients = BusinessLogicLayer.Patient.Patient.GetPatientDataforMerge(data);

                    var jsonResult = Json(new { isSuccess = true, message = patients }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isSuccess = true, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult CreateMergePatient(MergeData requestData)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    int patIdT = requestData.dataTo[0].patIdT;

                    if (patIdT != 0 && requestData.dataFrom[0].piIdF != 0)
                    {
                        int madeby = PageControl.getLoggedinId();

                        int val = BusinessLogicLayer.Patient.Patient.MergePatient(requestData, madeby);

                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = madeby,
                                log_desc = $"Employee Merged piId=: {requestData.dataFrom[0].piIdF} to piId=: {requestData.dataTo[0].piIdT}"
                            });

                            return Json(new { isAutherized = true, isSuccess = true, message = "Success" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            errors.Add("", "Error while merging! Please try again...");

                            return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        errors.Add("piIdF", "Please Select To And From patients");
                        return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAutherized = false, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPatientBypiId(PatientSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                List<BusinessEntities.Patient.PatientMerge> patients = new List<BusinessEntities.Patient.PatientMerge>();

                try
                {
                    patients = BusinessLogicLayer.Patient.Patient.GetPatientDatabypiId(data);

                    var jsonResult = Json(new { isSuccess = true, message = patients }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isSuccess = true, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetPatientsByMRN(PatientSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                List<BusinessEntities.Patient.Patient> patients = new List<BusinessEntities.Patient.Patient>();

                try
                {

                    patients = BusinessLogicLayer.Patient.Patient.GetPatientsDataByMRN(data);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Patients Page!"
                    });

                    var jsonResult = Json(new { isSuccess = true, message = patients }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;

                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isSuccess = true, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateMRNNo(int patId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Patient.Patient.UpdateMRNNo(patId, PageControl.getLoggedinId());

                if (val != 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee updated Patient with MRN# = {val}"
                    });

                    return Json(new { success = true, message = "MRN# Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Failed To Update MRN#!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}