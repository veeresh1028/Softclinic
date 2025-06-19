using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.Invoice;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    public class ConsultationEMRController : Controller
    {
        // GET: EMR/ConsultationEMR
        int PageId = (int)Pages.NurseNotes;

        public ActionResult Consultation()
        {
            
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Quick EMR Page!"
                });
                TempData["Layout"] = "True";
                return View("Consultation");
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }

        public JsonResult GetAppointmentConsultation(int? appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ConsultationEMR_Details> details = BusinessLogicLayer.EMR.ConsultationEMR.GetAppointmentConsultation(appId);

                return Json(details, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPreAppointmentConsultation(int? appId,int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ConsultationEMR_Details> details = BusinessLogicLayer.EMR.ConsultationEMR.GetPreAppointmentConsultation(appId,patId);

                return Json(details, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult ConsultationEMR(int appId)
        {
            
           
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.EMR.ConsultationEMR consultation = BusinessLogicLayer.EMR.ConsultationEMR.GetConsultationEMR(appId);
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Quick EMR Page!"
                });
                return PartialView("ConsultationEMR", consultation);
            }
            else
            {
                return PartialView("_Unauthorized");
            }

        }

        //GET:Complaints Master
        [HttpGet]
        public ActionResult GetTemplates(string query)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> template = BusinessLogicLayer.EMR.ConsultationEMR.GetTemplates(query);
                    var jsonResult = Json(template, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetConsultationEMRTemplate(int cemtId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    ConsultationEMR_Details dt = BusinessLogicLayer.EMR.ConsultationEMR.GetConsultationEMRTemplate(cemtId);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public ActionResult InsertConsultationTemplate(ConsultationEMR_Main data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = string.Empty;
                    if (!string.IsNullOrEmpty(data.template_details.cemr_bodyimage))
                    {
                        string file_path = Server.MapPath("~/images/Therapy/Template");

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

                        //Save Body Image 1
                        string[] contents = data.template_details.image.Split(',');
                        string base64 = contents[1].ToString(); //data:image/png;base64
                        string[] filedata = contents[0].Split('/');
                        string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_body1." + ext;
                        string path =  Path.Combine(file_path, filename);

                        data.template_details.cemr_bodyimage = path;
                        System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                        //Save Body Image 2
                        string[] contents2 = data.template_details.image2.Split(',');
                        string base64_2 = contents2[1].ToString(); //data:image/png;base64
                        string[] filedata2 = contents2[0].Split('/');
                        string ext2 = filedata2[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                        string filename2 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_body2." + ext2;
                        string path2 = Path.Combine(file_path, filename2);

                        data.template_details.cemr_bodyimage2 = path2;
                        System.IO.File.WriteAllBytes(path2, Convert.FromBase64String(base64_2.ToString()));

                        //Save Face Image 
                        string[] contents3 = data.template_details.image3.Split(',');
                        string base64_3 = contents3[1].ToString(); //data:image/png;base64
                        string[] filedata3 = contents3[0].Split('/');
                        string ext3 = filedata3[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                        string filename3 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_face1." + ext3;
                        string path3 = Path.Combine(file_path, filename3);

                        data.template_details.cemr_faceimage = path3;
                        System.IO.File.WriteAllBytes(path3, Convert.FromBase64String(base64_3.ToString()));
                    }
                    int val = BusinessLogicLayer.EMR.ConsultationEMR.Generate_ConsultationEMR(data, PageControl.getLoggedinId(), out inv_no);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = "Employee Created New Template"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Template  is generated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "An empty Template Created with this Name" }, JsonRequestBehavior.AllowGet);
                    }
                    else if ( val == -3)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Invalid Template Name" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the Template " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        [HttpGet]
        public PartialViewResult EditConsultationEMR(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {

                    ConsultationEMR_Main _emr = new ConsultationEMR_Main();
                    BusinessEntities.EMR.ConsultationEMR consultation = BusinessLogicLayer.EMR.ConsultationEMR.GetConsultationEMR(appId);
                    List<ConsultationEMR_Details> emr = BusinessLogicLayer.EMR.ConsultationEMR.GetAppointmentConsultation(appId);
                    _emr.template_info = consultation;
                    _emr.template_details = new ConsultationEMR_Details(); 

                    if (emr.Count > 0)
                    {
                        _emr.template_details = emr[0];
                    }

                    return PartialView("EditConsultationEMR", _emr);
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
        public PartialViewResult EditConsultationEMR2(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {

                    ConsultationEMR_Main _emr = new ConsultationEMR_Main();
                    ConsultationEMRTemplate template = BusinessLogicLayer.EMR.ConsultationEMR.GetConsultationTemplateEMR(appId);
                    ConsultationEMR_Details template_details = BusinessLogicLayer.EMR.ConsultationEMR.GetAppointmentConsultationEMR(appId);
                    BusinessEntities.EMR.ConsultationEMR consultation = BusinessLogicLayer.EMR.ConsultationEMR.GetConsultationEMR(appId);
                    List<ConsultationEMR_Details> emr = BusinessLogicLayer.EMR.ConsultationEMR.GetAppointmentConsultation(appId);
                    _emr.template_info = consultation;
                    _emr.template_details = template_details;
                    _emr.template = template;
                      

                    if (emr.Count > 0)
                    {
                        _emr.template_details = emr[0];
                    }

                    return PartialView("EditConsultationEMR2", _emr);
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
        public ActionResult UpdateConsultationTemplate(ConsultationEMR_Details data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    data.cemr_madeby = PageControl.getLoggedinId();

                    string file_path = Server.MapPath("~/images/Therapy/Template");

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

                    //Save Body Image 1
                    string[] contents = data.image.Split(',');
                    string base64 = contents[1].ToString(); //data:image/png;base64
                    string[] filedata = contents[0].Split('/');
                    string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "_body1." + ext;
                    string path = Path.Combine(file_path, filename);

                    data.cemr_bodyimage = path;
                    System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                    //Save Body Image 2
                    string[] contents2 = data.image2.Split(',');
                    string base64_2 = contents2[1].ToString(); //data:image/png;base64
                    string[] filedata2 = contents2[0].Split('/');
                    string ext2 = filedata2[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                    string filename2 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_body2." + ext2;
                    string path2 = Path.Combine(file_path, filename2);
                   
                    data.cemr_bodyimage2 = path2;
                    System.IO.File.WriteAllBytes(path2, Convert.FromBase64String(base64_2.ToString()));

                    //Save Face Image 2
                    string[] contents3 = data.image3.Split(',');
                    string base64_3 = contents3[1].ToString(); //data:image/png;base64
                    string[] filedata3 = contents3[0].Split('/');
                    string ext3 = filedata3[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                    string filename3 = DateTime.Now.ToString("yyyyMMddHHmmss") + "_face1." + ext3;
                    string path3 =  Path.Combine(file_path, filename3);

                    data.cemr_faceimage = path3;
                    System.IO.File.WriteAllBytes(path3, Convert.FromBase64String(base64_3.ToString()));

                    int val = BusinessLogicLayer.EMR.ConsultationEMR.Update_ConsultationEMR(data);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = "Employee Created New Template"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Template  is Updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "An empty Template Created with this Name" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -3)
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Invalid Template Name" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in creating the Template " }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        [HttpPost]
        public ActionResult DeleteConsultationEMR(int cemrId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int cemr_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.EMR.ConsultationEMR.DeleteConsultationEMR(cemrId, cemr_madeby);

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


        [HttpGet]
        public ActionResult PrintPreConsultEMR(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    //List<ConsultationEMR_Details> print = BusinessLogicLayer.EMR.ConsultationEMR.GetAppointmentConsultation(appId);
                    ConsultationEMR_Details print = BusinessLogicLayer.EMR.ConsultationEMR.GetAppointmentConsultation(appId).FirstOrDefault();
                    print.set_header_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "header_images", emr.set_header_image);
                    print.set_footer_image = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images", "footer_images", emr.set_footer_image);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed ConsultationEMR with cemr_appId = {appId}"
                    });

                    return View("PrintPreConsultEMR", print);
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
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}