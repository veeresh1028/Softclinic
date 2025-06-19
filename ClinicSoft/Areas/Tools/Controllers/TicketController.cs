using BusinessEntities;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Common;
using BusinessEntities.Tools;
using Google.Rpc;
using Google.Type;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace ClinicSoft.Areas.Tools.Controllers
{
    public class TicketController : Controller
    {
        int PageId = (int)Pages.MyTickets;

        #region Tickets
        public ActionResult Tickets()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Tools.TicketsFilter filter = new BusinessEntities.Tools.TicketsFilter();
                filter.empId = empId;
                filter.ticket_date_from = System.DateTime.Now.AddDays(-10).ToString("MM/dd/yyyy");
                filter.ticket_date_to = System.DateTime.Now.ToString("MM/dd/yyyy");
                List<TicketsDetail> Ticketlist = BusinessLogicLayer.Tools.Tickets.GetTicketsDetail(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        public JsonResult GetTickets_1(TicketsFilter filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                if (string.IsNullOrEmpty(filter.ticket_date_from) && string.IsNullOrEmpty(filter.ticket_date_to))
                {
                    filter.ticket_date_from = System.DateTime.Now.AddDays(-10).ToString("MM/dd/yyyy");
                    filter.ticket_date_to = System.DateTime.Now.ToString("MM/dd/yyyy");
                }
                List<TicketsDetail> Ticketlist = BusinessLogicLayer.Tools.Tickets.GetTicketsDetail(filter);

                var jsonResult = Json(Ticketlist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> GetTickets(TicketsFilter filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                DataTable dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(empId);
                if (dt.Rows.Count > 0)
                {
                    filter.ticket_clientId = string.IsNullOrEmpty(dt.Rows[0]["set_permit_no"].ToString()) ? "" : dt.Rows[0]["set_permit_no"].ToString();
                }

                filter.empId = empId;
                if (string.IsNullOrEmpty(filter.ticket_date_from) && string.IsNullOrEmpty(filter.ticket_date_to))
                {
                    filter.ticket_date_from = System.DateTime.Now.AddDays(-10).ToString("MM/dd/yyyy");
                    filter.ticket_date_to = System.DateTime.Now.ToString("MM/dd/yyyy");
                }

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string controllerEndPoint = "/api/Ticket/GetTicketsDetail";
                string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                var options = new RestClientOptions(apiEndPoint)
                {
                    MaxTimeout = -1,
                };

                var client = new RestClient(options);
                var request = new RestRequest(controllerEndPoint, Method.Post);

                //string accessToken = ConfigurationManager.AppSettings["TicketAccessToken"];
                //request.AddHeader("Authorization", "Bearer " + accessToken);

                request.AddHeader("Content-Type", "application/json");
                string request_body = JsonConvert.SerializeObject(filter);

                request.AddStringBody(request_body, DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                TicketsListResponse Ticketlist = new TicketsListResponse();
                if (response.IsSuccessful)
                {
                    Ticketlist = JsonConvert.DeserializeObject<TicketsListResponse>(response.Content);
                }
                else
                {
                    string error = response.ErrorMessage;
                }
                var jsonResult = Json(Ticketlist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Compose Ticket for ClinicSoft
        [HttpGet]
        public PartialViewResult ComposeTicket()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("ComposeTicket");
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
        public async Task<ActionResult> SendTicket(ComposeTickets data, HttpPostedFileBase[] files)
        {
            try
            {
                int isInserted = 0;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    DataTable dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(empId);
                    if (dt.Rows.Count > 0)
                    {
                        data.ticket_clientId = string.IsNullOrEmpty(dt.Rows[0]["set_permit_no"].ToString()) ? "" : dt.Rows[0]["set_permit_no"].ToString();
                        data.ticket_clientName = string.IsNullOrEmpty(dt.Rows[0]["set_company"].ToString()) ? "" : dt.Rows[0]["set_company"].ToString();
                        data.ticket_senderId = empId;
                        data.ticket_branch = int.Parse(string.IsNullOrEmpty(dt.Rows[0]["setid"].ToString()) ? "1" : dt.Rows[0]["setid"].ToString());
                        data.ticket_senderName = string.IsNullOrEmpty(dt.Rows[0]["emp_name"].ToString()) ? "" : dt.Rows[0]["emp_name"].ToString();
                        data.ticket_senderDesig = string.IsNullOrEmpty(dt.Rows[0]["emp_desig_name"].ToString()) ? "" : dt.Rows[0]["emp_desig_name"].ToString();
                        data.ticket_from = "ClinicSoft";
                    }

                    data.ticket_date = System.DateTime.Now.ToString();
                    data.ticket_madeby = empId;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    DocErrorResponse err = new DocErrorResponse();

                    bool issuccess = false;

                    //Validating and Sending to Vision Help
                    if (SecurityLayer.FormValidations.Tools.Ticket.isValidTicket(data, out errors))
                    {
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        string controllerEndPoint = "/api/Ticket/CreateTickets";
                        string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                        var options = new RestClientOptions(apiEndPoint)
                        {
                            MaxTimeout = -1,
                        };

                        var client = new RestClient(options);
                        var request = new RestRequest(controllerEndPoint, Method.Post);

                        //string accessToken = ConfigurationManager.AppSettings["TicketAccessToken"];
                        //request.AddHeader("Authorization", "Bearer " + accessToken);

                        request.AddHeader("Content-Type", "application/json");
                        string request_body = JsonConvert.SerializeObject(data);

                        request.AddStringBody(request_body, DataFormat.Json);
                        RestResponse response = await client.ExecuteAsync(request);

                        if (response.IsSuccessful)
                        {
                            TicketResponse admin_response = new TicketResponse();
                            admin_response = JsonConvert.DeserializeObject<TicketResponse>(response.Content);
                            if (admin_response.ticket_code > 0)
                                data.ticket_code = admin_response.ticket_code;
                        }
                        else
                        {
                            string error = response.ErrorMessage;
                        }

                        // Uploads Support Docs
                        if (data.ticket_code > 0)
                        {
                            if (files.Length > 0)
                            {
                                string file_path = Server.MapPath("~/images/TicketsAttachments/");

                                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                                {
                                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                                    Directory.CreateDirectory(file_path);
                                }
                                else
                                {
                                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                                }

                                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                                {
                                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                                    Directory.CreateDirectory(file_path);
                                }
                                else
                                {
                                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                                }

                                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                                {
                                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                                    Directory.CreateDirectory(file_path);
                                }
                                else
                                {
                                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                                }

                                foreach (var file in files)
                                {
                                    if (file != null && file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            issuccess = true;

                                            string _extension = Path.GetExtension(file.FileName);
                                            string _file_name = System.DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                            string _path = Path.Combine(file_path, _file_name);
                                            string base64String = string.Empty;
                                            TicketDocuments doc = new TicketDocuments();
                                            doc.tdoc_ticket_code = data.ticket_code;
                                            doc.tdoc_name = _file_name;
                                            doc.tdoc_path = _path;
                                            doc.tdoc_uploadedby = empId;

                                            using (MemoryStream ms = new MemoryStream())
                                            {
                                                file.InputStream.CopyTo(ms);
                                                byte[] fileBytes = ms.ToArray();
                                                base64String = Convert.ToBase64String(fileBytes);
                                            }

                                            int docId = 0;
                                            if (doc.tdoc_ticket_code > 0 && !string.IsNullOrEmpty(doc.tdoc_name))
                                            {
                                                docId = BusinessLogicLayer.Tools.Tickets.UploadDocument(doc);

                                                if (docId > 0)
                                                {
                                                    if (System.IO.File.Exists(_path))
                                                    {
                                                        System.IO.File.Delete(_path);
                                                    }
                                                    file.SaveAs(_path);
                                                }
                                            }

                                            //Sending Support Docs to Vision Help
                                            if (!string.IsNullOrEmpty(base64String) && docId > 0)
                                            {
                                                TicketMedia media = new TicketMedia();
                                                media.Data = base64String;
                                                media.ticket_code = data.ticket_code;
                                                media.file_name = doc.tdoc_name;
                                                media.uploadedby = data.ticket_senderName;
                                                media.tdocId = docId;

                                                ServicePointManager.Expect100Continue = true;
                                                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                                                var options_Media = new RestClientOptions(apiEndPoint)
                                                {
                                                    MaxTimeout = -1,
                                                };
                                                var client_Media = new RestClient(options_Media);
                                                var request_Media = new RestRequest("/api/Documents/UploadTicketDocuments", Method.Post);
                                                request_Media.AddHeader("Content-Type", "application/json");
                                                //request_Media.AddHeader("Authorization", "Bearer " + accessToken);

                                                string body_Media = JsonConvert.SerializeObject(media);

                                                request_Media.AddStringBody(body_Media, DataFormat.Json);
                                                RestResponse response_Media = await client_Media.ExecuteAsync(request_Media);
                                                if (!response_Media.IsSuccessful)
                                                {
                                                    doc.tdoc_name = string.Empty;
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
                                }
                            }

                            //Insert Ticket in local DB
                            isInserted = BusinessLogicLayer.Tools.Tickets.ComposeTicket(data);

                            if (isInserted > 0)
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Ticket Sent Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isInserted = false, isSuccess = true, message = "Ticket Sending Error!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Ticket Sending Error!" }, JsonRequestBehavior.AllowGet);
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
                //TempData["ErrorMessage"] = ex.Message;
                return Json(new { isInserted = false, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                return View();
            }
        }

        //Change Ticket Status 
        [HttpPost]
        public async Task<ActionResult> TicketStatus(string data, string status)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    string updatedby = String.Empty;
                    DataTable dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(empId);
                    if (dt.Rows.Count > 0)
                    {
                        updatedby = string.IsNullOrEmpty(dt.Rows[0]["emp_name"].ToString()) ? "" : dt.Rows[0]["emp_name"].ToString();
                    }

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    string ticketCode = data;
                    string controllerEndPoint = $"api/Ticket/GetTicketStatus?ticketCode={ticketCode}&status={status}&updatedby={updatedby}";
                    //string controllerEndPoint = "/api/Ticket/GetTicketStatus";
                    string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                    var options = new RestClientOptions(apiEndPoint)
                    {
                        MaxTimeout = -1,
                    };

                    var client = new RestClient(options);
                    var request = new RestRequest(controllerEndPoint, Method.Post);

                    string accessToken = ConfigurationManager.AppSettings["TicketAccessToken"];
                    request.AddHeader("Authorization", "Bearer " + accessToken);

                    request.AddHeader("Content-Type", "application/json");
                    //request.AddParameter("ticketCode", int.Parse(data));
                    //request.AddParameter("status", status);
                    //request.AddParameter("updatedby", updatedby);

                    RestResponse response = await client.ExecuteAsync(request);
                    string error = string.Empty;
                    if (response.IsSuccessful)
                    {
                        TicketResponse admin_response = new TicketResponse();
                        admin_response = JsonConvert.DeserializeObject<TicketResponse>(response.Content);
                        if (admin_response.ticket_code > 0)
                            isUpdated = BusinessLogicLayer.Tools.Tickets.TicketStatus(data, status, empId, updatedby);
                    }
                    else
                    {
                        error = response.ErrorMessage;
                    }
                    if (isUpdated)
                    {
                        return Json(new { isUpdated = true, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = error }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }

        // Get Ticket Detail
        [HttpGet]
        public PartialViewResult ViewTicketDetail(int Code)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                TicketsFilter filter = new TicketsFilter();
                filter.empId = empId;
                filter.ticket_code = Code;

                TicketsList _list = BusinessLogicLayer.Tools.Tickets.ViewTicketDetail(filter);

                return PartialView("TciketDetail", _list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        #endregion

        #region Reminder
        //Open View For Reminders
        [HttpGet]
        public async Task<PartialViewResult> ReminderMessage(int code)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    TicketReminder tr = new TicketReminder();
                    tr.tr_ticket_code = code;

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    string clientId = "MR-1545";
                    string ticketCode = code.ToString();
                    string controllerEndPoint = $"api/Reminder/GetReminderMessages?clientId={clientId}&ticketCode={ticketCode}";
                    string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                    var options = new RestClientOptions(apiEndPoint)
                    {
                        MaxTimeout = -1,
                    };

                    var client = new RestClient(options);
                    var request = new RestRequest(controllerEndPoint, Method.Get);

                    //request.AddHeader("Content-Type", "application/json");

                    RestResponse response = await client.ExecuteAsync(request);
                    string error = string.Empty;
                    TicketReminderList reminderlist = new TicketReminderList();
                    if (response.IsSuccessful)
                    {
                        reminderlist = JsonConvert.DeserializeObject<TicketReminderList>(response.Content);
                    }
                    else
                    {
                        error = response.ErrorMessage;
                    }
                    reminderlist.ticket_code = code;

                    return PartialView("Reminders", reminderlist);
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

        //Send Ticket Reminder
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendTicketReminder(BusinessEntities.Tools.TicketReminder data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    DataTable dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(empId);
                    if (dt.Rows.Count > 0)
                    {
                        data.madeby = string.IsNullOrEmpty(dt.Rows[0]["emp_name"].ToString()) ? "" : dt.Rows[0]["emp_name"].ToString();
                    }
                    data.tr_madeby = empId;
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (!string.IsNullOrEmpty(data.tr_message))
                    {

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        string controllerEndPoint = "/api/Reminder/GetReminder";
                        string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                        var options = new RestClientOptions(apiEndPoint)
                        {
                            MaxTimeout = -1,
                        };

                        var client = new RestClient(options);
                        var request = new RestRequest(controllerEndPoint, Method.Post);

                        request.AddHeader("Content-Type", "application/json");
                        string request_body = JsonConvert.SerializeObject(data);

                        request.AddStringBody(request_body, DataFormat.Json);
                        RestResponse response = await client.ExecuteAsync(request);
                        string error = "";
                        if (response.IsSuccessful)
                        {
                            TicketResponse admin_response = new TicketResponse();
                            admin_response = JsonConvert.DeserializeObject<TicketResponse>(response.Content);
                            if (admin_response.ticket_code > 0)
                                isInserted = BusinessLogicLayer.Tools.Tickets.SendTicketReminder(data);
                        }
                        else
                        {
                            error = response.ErrorMessage;
                        }

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Ticket Sent Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = error }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        errors.Add("tr_message", "Enter Reminder Message");
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
                return Json(new { isInserted = false, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Comments
        //Ticket Comments View And Send
        [HttpGet]
        public async Task<PartialViewResult> TicketComments(int Code)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();


                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string clientId = "MR-1545";
                string ticketCode = Code.ToString();
                string controllerEndPoint = $"api/Comments/GetTicketComments?clientId={clientId}&ticketCode={ticketCode}";
                string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                var options = new RestClientOptions(apiEndPoint)
                {
                    MaxTimeout = -1,
                };

                var client = new RestClient(options);
                var request = new RestRequest(controllerEndPoint, Method.Get);

                //request.AddHeader("Content-Type", "application/json");

                RestResponse response = await client.ExecuteAsync(request);
                string error = string.Empty;
                TicketCommentsResponse _list = new TicketCommentsResponse();
                if (response.IsSuccessful)
                {
                    _list = JsonConvert.DeserializeObject<TicketCommentsResponse>(response.Content);
                }
                else
                {
                    error = response.ErrorMessage;
                }
                _list.ticket_code = Code;
                return PartialView("Comments", _list);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Ticket Comment Insert        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> InsertComment(TicketComments data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (!string.IsNullOrEmpty(data.tc_commnet) && data.tc_ticketCode > 0)
                    {
                        int empId = PageControl.getLoggedinId();
                        DataTable dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(empId);
                        if (dt.Rows.Count > 0)
                        {
                            data.tc_commnetby = string.IsNullOrEmpty(dt.Rows[0]["emp_name"].ToString()) ? "" : dt.Rows[0]["emp_name"].ToString();
                            data.tc_commnetby += string.IsNullOrEmpty(dt.Rows[0]["emp_desig_name"].ToString()) ? "" : " -" + dt.Rows[0]["emp_desig_name"].ToString();
                            data.emp_photo = string.IsNullOrEmpty(dt.Rows[0]["emp_photo"].ToString()) ? "" : dt.Rows[0]["emp_photo"].ToString();
                            data.tc_source = "Client";
                        }
                        data.tc_commnetby_ID = empId;
                        data.tc_status = "Unread";
                        data.tc_datecreated = System.DateTime.Now.ToString();

                        //Sending To Vision Help
                        string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                        string accessToken = ConfigurationManager.AppSettings["TicketAccessToken"];
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                        var options_Media = new RestClientOptions(apiEndPoint)
                        {
                            MaxTimeout = -1,
                        };
                        var client_Media = new RestClient(options_Media);
                        var request_Media = new RestRequest("/api/Comments/CreateTicketComment", Method.Post);
                        request_Media.AddHeader("Content-Type", "application/json");
                        request_Media.AddHeader("Authorization", "Bearer " + accessToken);

                        string body_Media = JsonConvert.SerializeObject(data);

                        request_Media.AddStringBody(body_Media, DataFormat.Json);
                        RestResponse response_Media = await client_Media.ExecuteAsync(request_Media);
                        if (!response_Media.IsSuccessful)
                        {
                            isInserted = false;
                        }
                        else
                        {
                            isInserted = BusinessLogicLayer.Tools.Tickets.InsertComment(data);
                        }
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, comment = data, message = "Comment Sent Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Sending Comment" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        errors.Add("tc_comment", "Please Entered Comment");
                        errors.Add("tc_ticketCode", "Please Select Ticket Code");
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                //TempData["ErrorMessage"] = ex.Message;
                return Json(new { isInserted = false, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

            return View();
        }
        #endregion

        #region Ticket Documents
        [HttpGet]
        public ActionResult TicketAttachments(int ticket_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TicketDocuments doc_ref = new TicketDocuments();
                doc_ref.tdocId = 0;
                doc_ref.tdoc_ticket_code = ticket_code;
                return PartialView("Attachments", doc_ref);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetDocumentsById(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                List<TicketDocuments> doc_data = new List<TicketDocuments>();
                try
                {
                    string path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString();
                    string folder = "TicketsAttachments";
                    doc_data = BusinessLogicLayer.Tools.Tickets.GetDocumentsById(id, path, folder);

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

        [HttpPost]
        public async Task<ActionResult> UploadFiles(DocData data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {

                    bool issuccess = false;
                    DocErrorResponse err = new DocErrorResponse();

                    string file_path = Server.MapPath("~/images/TicketsAttachments/");

                    if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                    {
                        file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                        Directory.CreateDirectory(file_path);
                    }
                    else
                    {
                        file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                    }

                    if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                    {
                        file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                        Directory.CreateDirectory(file_path);
                    }
                    else
                    {
                        file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                    }

                    if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                    {
                        file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                        Directory.CreateDirectory(file_path);
                    }
                    else
                    {
                        file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
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
                                    string _file_name = System.DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                    string _path = Path.Combine(file_path, _file_name);
                                    string base64String = string.Empty;


                                    TicketDocuments doc = new TicketDocuments();
                                    doc.tdoc_ticket_code = data.id;
                                    doc.tdoc_name = _file_name;
                                    doc.tdoc_path = _path;
                                    doc.tdoc_uploadedby = PageControl.getLoggedinId();

                                    using (MemoryStream ms = new MemoryStream())
                                    {
                                        _file.InputStream.CopyTo(ms);
                                        byte[] fileBytes = ms.ToArray();
                                        base64String = Convert.ToBase64String(fileBytes);
                                    }

                                    int docId = 0;
                                    if (doc.tdoc_ticket_code > 0 && !string.IsNullOrEmpty(doc.tdoc_name))
                                    {
                                        docId = BusinessLogicLayer.Tools.Tickets.UploadDocument(doc);

                                        if (docId > 0)
                                        {
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            _file.SaveAs(_path);
                                        }
                                    }

                                    //Sending Support Docs to Vision Help
                                    if (!string.IsNullOrEmpty(base64String) && docId > 0)
                                    {
                                        DataTable dt = BusinessLogicLayer.Tools.Tickets.TicketSenderDetail(PageControl.getLoggedinId());
                                        string uploadedby = string.Empty;
                                        if (dt.Rows.Count > 0)
                                        {
                                            uploadedby = string.IsNullOrEmpty(dt.Rows[0]["emp_name"].ToString()) ? "" : dt.Rows[0]["emp_name"].ToString();
                                        }

                                        TicketMedia media = new TicketMedia();
                                        media.Data = base64String;
                                        media.ticket_code = data.id;
                                        media.file_name = doc.tdoc_name;
                                        media.uploadedby = uploadedby;
                                        media.tdocId = docId;

                                        string apiEndPoint = ConfigurationManager.AppSettings["TicketEndPoint"];
                                        string accessToken = ConfigurationManager.AppSettings["TicketAccessToken"];
                                        ServicePointManager.Expect100Continue = true;
                                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                                        var options_Media = new RestClientOptions(apiEndPoint)
                                        {
                                            MaxTimeout = -1,
                                        };
                                        var client_Media = new RestClient(options_Media);
                                        var request_Media = new RestRequest("/api/Documents/UploadTicketDocuments", Method.Post);
                                        request_Media.AddHeader("Content-Type", "application/json");
                                        request_Media.AddHeader("Authorization", "Bearer " + accessToken);

                                        string body_Media = JsonConvert.SerializeObject(media);

                                        request_Media.AddStringBody(body_Media, DataFormat.Json);
                                        RestResponse response_Media = await client_Media.ExecuteAsync(request_Media);
                                        if (!response_Media.IsSuccessful)
                                        {
                                            doc.tdoc_name = string.Empty;
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
        public ActionResult DeleteDocument(int docId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                bool val = BusinessLogicLayer.Tools.Tickets.DeleteDocuments(docId);

                if (val)
                {
                    return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Unauthorised!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public FileContentResult DownloadFile(int id)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                byte[] fileContent = null;
                DataTable dt = BusinessLogicLayer.Tools.Tickets.GetFilePathDownload(id);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        string fileName = Path.Combine(Server.MapPath("~/images/TicketsAttachments/"), row["file_path"].ToString().Trim());
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();

                        //data = fileContent;
                        string[] strArr = row["file_path"].ToString().Trim().Split('\\');

                        if (strArr.Length > 0)
                        {
                            string _name = strArr[strArr.Length - 1];

                            Response.AppendHeader("Content-type", "." + _name.Split('.')[1].Trim());
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + _name);
                        }

                    }
                }

                return new FileContentResult(fileContent, "image/jpeg");
            }
            else
            {
                return new FileContentResult(null, "image/jpeg");
            }
        }

        [HttpGet]
        public ActionResult ViewDocument(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.Lists.DownloadFile file = new BusinessEntities.Lists.DownloadFile();
                DataTable dt = BusinessLogicLayer.Tools.Tickets.GetFilePathDownload(id);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/TicketsAttachments" }, StringSplitOptions.None);
                        file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/TicketsAttachments" + path[1].Trim().ToString();

                        file.id = id;
                        return PartialView("TicketDocumentView", file);
                    }
                    else
                    {
                        return PartialView("TicketDocumentView", file);
                    }
                }
                else
                {
                    return PartialView("TicketDocumentView", file);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
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