using BusinessEntities.Appointment;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Net;
using System.Web;
using Google.Type;
using System.Threading.Tasks;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class TreatmentAttachementsController : Controller
    {
        int PageId = (int)Pages.PatientTreatments;

        [HttpGet]
        public ActionResult TreatmentAttachements(int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.EMR.TreatmentAttachments attachments = new BusinessEntities.EMR.TreatmentAttachments();
                attachments.ptId = ptId;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Treatment Atachments Page!"
                });

                return PartialView("TreatmentAttachements", attachments);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertTreatmentAttachment(BusinessEntities.EMR.TreatmentAttachments data)
        {
            int Action = (int)Actions.Create;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    int isInserted = 0;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];

                            string path = "";
                            string filename = Path.GetFileNameWithoutExtension(file.FileName);
                            string extension = Path.GetExtension(file.FileName);

                            filename = "PT_" + filename + "_" + data.ti_ptId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                            string key = files.AllKeys[i];

                            if (key == "ti_img")
                            {
                                path = Server.MapPath("~/images/treatment_images/");
                            }
                            else if (key == "ti_img_2")
                            {
                                path = Server.MapPath("~/images/treatment_images/");
                            }

                            string file_path = Path.Combine(path, filename);

                            if (files.AllKeys[i] == "ti_img")
                            {
                                if (file.ContentLength <= 4194304)
                                {
                                    if (extension.ToLower() == ".pdf")
                                    {
                                        if (System.IO.File.Exists(file_path))
                                        {
                                            System.IO.File.Delete(file_path);
                                        }

                                        data.ti_image = filename;

                                        file.SaveAs(file_path);

                                        if (data.ti_category == "MOH")
                                        {
                                            await GetImageRefno(file_path, filename, data, 1);
                                        }
                                    }
                                    else
                                    {
                                        errors.Add("ti_img", "Invalid format for Sign! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                    }
                                }
                                else
                                {
                                    errors.Add("ti_img", "Employee Sign image size should be less than 4 MB!");
                                }
                            }
                            else if (files.AllKeys[i] == "ti_img_2")
                            {
                                if (file.ContentLength <= 4194304)
                                {
                                    if (extension.ToLower() == ".pdf")
                                    {
                                        if (System.IO.File.Exists(file_path))
                                        {
                                            System.IO.File.Delete(file_path);
                                        }

                                        data.ti_image_2 = filename;

                                        file.SaveAs(file_path);

                                        if (data.ti_category == "MOH")
                                        {
                                            await GetImageRefno(file_path, filename, data, 2);
                                        }
                                    }
                                    else
                                    {
                                        errors.Add("ti_img_2", "Invalid format for Photo! Allowed formats : .pdf");
                                    }
                                }
                                else
                                {
                                    errors.Add("ti_img_2", "Employee Photo image size should be less than 4 MB!");
                                }
                            }
                        }
                    }

                    if (errors.Count == 0)
                    {
                        data.ti_madeby = PageControl.getLoggedinId();


                        isInserted = BusinessLogicLayer.EMR.TreatmentAttachments.InsertTreatmentAttachment(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = true, isSuccess = true, message = "Attachment Details Saved Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Attachment Details Already Exists with the same info!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        public async static Task GetImageRefno(string strFilePath, string strFileName, BusinessEntities.EMR.TreatmentAttachments data, int img)
        {
            string FacilityId = ConfigurationManager.AppSettings["FacilityId"].ToString();
            string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
            string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
            string strApiUrl = ConfigurationManager.AppSettings["RiayatiDocAPIUrl"].ToString();
            HttpClient client = new HttpClient { BaseAddress = new Uri(strApiUrl) };
            client.DefaultRequestHeaders.Add("Username", strUsername);
            client.DefaultRequestHeaders.Add("Password", strPassword);
            Stream fileStream = System.IO.File.Open(@"" + strFilePath + "", FileMode.Open);
            using (var br = new BinaryReader(fileStream))
            {
                try
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    ByteArrayContent bytes = new ByteArrayContent(br.ReadBytes((int)fileStream.Length));
                    bytes.Headers.TryAddWithoutValidation("Content-Type", "application/pdf");
                    HttpResponseMessage response = await client.PostAsync("Attachments/UploadAttachment", new MultipartFormDataContent() { { bytes, "file", strFileName } });
                    var jsonSerializerOptions = new JsonSerializer();
                    using (HttpClient client1 = new HttpClient())
                    {
                        using (HttpContent content = response.Content)
                        {
                            string mycontent = await content.ReadAsStringAsync();

                            BusinessEntities.EMR.UploadDocumentResponse.UploadDocument_Response Response = JsonConvert.DeserializeObject<BusinessEntities.EMR.UploadDocumentResponse.UploadDocument_Response>(mycontent);
                            if (Response.StatusCode == "200")
                            {
                                if (img == 1)
                                {
                                    data.ti_img_refno1 = Response.EntityID.ToString();
                                }
                                else if (img == 2)
                                {
                                    data.ti_img_refno2 = Response.EntityID.ToString();
                                }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());
                    string responseFromServer = sr.ReadToEnd();
                    BusinessEntities.EMR.UploadDocumentResponse.UploadDocument_Response Response1 = JsonConvert.DeserializeObject<BusinessEntities.EMR.UploadDocumentResponse.UploadDocument_Response>(responseFromServer);
                    if (Response1.StatusCode == "400")
                    {

                        //MessageBox.Show(Response1.Message);
                    }
                }
            }


        }
        [HttpGet]
        public JsonResult GetTreatmentAttachments(int ptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.EMR.TreatmentAttachments> attachments = BusinessLogicLayer.EMR.TreatmentAttachments.GetTreatmentAttachments(ptId);

                var jsonResult = Json(attachments, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteTreatmentAttachment(int tiId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.TreatmentAttachments.DeleteTreatmentAttachment(tiId, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Treatment Attachment tiId = {tiId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Treatment Attachment Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Treatment Attachment!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult GetLOINCForDropdown(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDLFORMS> list = BusinessLogicLayer.EMR.TreatmentAttachments.GetLOINCForDropdown(query);

                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}