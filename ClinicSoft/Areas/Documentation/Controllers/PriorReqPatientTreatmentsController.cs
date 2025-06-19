using BusinessEntities;
using BusinessEntities.EMR;
using BusinessEntities.PriorRequests;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Xml;
using System.Xml.Linq;
using static BusinessEntities.EClaims.ClaimSubmissionRequest;
using static BusinessEntities.PriorRequests.PriorRequestsMOH;


namespace ClinicSoft.Areas.Documentation.Controllers
{
    [Authorize]
    public class PriorReqPatientTreatmentsController : Controller
    {
        int PageId = (int)Pages.Procedure;

        #region Prior Request Procedures
        [HttpGet]
        public PartialViewResult PriorReqPatientTreatments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Insurance Treatments Page!"
                    });

                    return PartialView("PriorReqPatientTreatments", invoice_info);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpGet]
        public PartialViewResult PriorReqDentalTreatments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Insurance Treatments Page!"
                    });

                    return PartialView("PriorReqDentalTreatments", invoice_info);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpGet]
        public JsonResult GetAllPatientTreatments(int appId, int? ptId, string pt_type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PatientTreatments> patientTreatments = BusinessLogicLayer.EMR.PatientTreatments.GetAllPatientTreatments(appId, ptId, pt_type);

                return Json(patientTreatments, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetAllPrePatientTreatments(int appId, int patId, string pt_type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PatientTreatments> treatment = BusinessLogicLayer.EMR.PatientTreatments.GetAllPrePatientTreatments(appId, patId, pt_type);

                return Json(treatment, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdatePatientTreatmentStatus(int ptId, string pt_status)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    ptId = BusinessLogicLayer.EMR.PatientTreatments.UpdatePatientTreatmentPRStatus(ptId, pt_status);

                    if (ptId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee updated treatment status to {pt_status} for the id= {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "ptId. " + ptId + " is updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in Updating status " }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Prior Request Resubmission Comments
        [HttpPost]
        public ActionResult UpdateResubTypeComments(string ptIds, string pt_resub_type, string pt_resub_notes)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int ptId = 0;

                    ptId = BusinessLogicLayer.EMR.PatientTreatments.UpdateResubTypeComments(ptIds, pt_resub_type, pt_resub_notes);

                    if (ptId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Resub type for Treatments with ptId = {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "ptIds. " + ptIds + " is generated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in updating status " }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Prior Request Direct
        [HttpGet]
        public ActionResult GenerateXmlDirect(int appId, string ptIds, string s_flag)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DateTime TransactionDate = DateTime.Now;

                    DataSet ds = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestDirect(appId, ptIds);
                    DataTable dt = ds.Tables[0];
                    DataRow dr = dt.Rows[0];

                    string filename = "PR-" + dt.Rows[0]["set_permit_no"].ToString() + "-" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH-mm-ss") + ".xml".Replace(" ", "");

                    string file = Server.MapPath("~/PriorRequests/Direct/DHA/" + filename);

                    StringWriter stringWriter = new StringWriter();
                    XmlTextWriter writer = new XmlTextWriter(stringWriter);

                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();

                    // Start Claim.Submission element
                    writer.WriteStartElement("Prior.Request");

                    if (dr["set_city"].ToString() == "HAAD")
                    {
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "https://www.haad.ae/DataDictionary/CommonTypes/PriorRequest.xsd");
                    }
                    else
                    {
                        writer.WriteAttributeString("xmlns:tns", "https://www.eclaimlink.ae/DHD/ValidationSchema");
                        writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                        writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "https://www.eclaimlink.ae/DHD/ValidationSchema/PriorRequest.xsd");
                    }

                    writer.WriteStartElement("Header");
                    // Write Header elements
                    writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                    writer.WriteElementString("ReceiverID", dr["ic_code"].ToString());
                    writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                    writer.WriteElementString("RecordCount", "1");
                    writer.WriteElementString("DispositionFlag", s_flag);
                    // End Header element
                    writer.WriteEndElement();

                    // Write Authorization elements
                    writer.WriteStartElement("Authorization");
                    writer.WriteElementString("Type", "Authorization");
                    writer.WriteElementString("ID", dr["pt_barcode_img"].ToString());
                    writer.WriteElementString("IDPayer", dr["pt_auth_code"].ToString());
                    writer.WriteElementString("MemberID", dr["pi_insno"].ToString());
                    writer.WriteElementString("PayerID", dr["ip_code"].ToString());
                    writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                    writer.WriteElementString("DateOrdered", DateTime.Now.ToString("dd/MM/yyyy"));

                    //Encounter Generation Starts Here.....
                    writer.WriteStartElement("Encounter");
                    writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                    writer.WriteElementString("Type", "1");
                    writer.WriteEndElement();
                    //Encounter Generation Ends Here.....

                    string tr_date_time = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd/MM/yyyy HH:mm");

                    DataTable dtDiag = BusinessLogicLayer.Documentation.CoderDiagnosis.GetAllCoderDiagnosisForPriorRequests(int.Parse(dr["appId"].ToString()), 0);

                    int diag_count = 0;

                    foreach (DataRow drDiag in dtDiag.Rows)
                    {
                        diag_count = diag_count + 1;
                        writer.WriteStartElement("Diagnosis");

                        if (drDiag["cod_type"].ToString() == "Primary")
                        {
                            writer.WriteElementString("Type", "Principal");
                        }
                        else
                        {
                            writer.WriteElementString("Type", "Secondary");
                        }

                        writer.WriteElementString("Code", drDiag["diag_Code"].ToString());

                        writer.WriteEndElement();
                    }

                    int y = 0;

                    foreach (DataRow drTreat in dt.Rows)
                    {
                        float pt_net = float.Parse(drTreat["pt_net"].ToString());
                        string act_no = drTreat["ptId"].ToString();

                        int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), drTreat["pt_resub_type"].ToString(), act_no, PageControl.getLoggedinId(), pt_net, "Submissions");

                        DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                        y = y + 1;

                        writer.WriteStartElement("Activity");
                        writer.WriteElementString("ID", act_no);
                        writer.WriteElementString("Start", tr_date_time);
                        writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                        writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                        writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                        writer.WriteElementString("Net", pt_net.ToString("0.00"));

                        if (!string.IsNullOrEmpty(drTreat["pt_teeth"].ToString()))
                        {
                            if (drTreat["pt_teeth"].ToString() != "N/A")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Universal Dental");
                                writer.WriteElementString("Code", drTreat["pt_teeth"].ToString());
                                writer.WriteEndElement();

                                //string[] pt__teeth = drTreat["pt_teeth"].ToString().Split(',');
                                //for (int j = 0; j < pt__teeth.Length; j++)
                                //{
                                //    if (pt__teeth[j].Trim() != "")
                                //    {
                                //        writer.WriteStartElement("Observation");
                                //        writer.WriteElementString("Type", "Universal Dental");
                                //        writer.WriteElementString("Code", pt__teeth[j].Trim());
                                //        writer.WriteEndElement();
                                //    }
                                //}
                            }
                        }
                        if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Prior Request")
                        {
                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "File");
                            writer.WriteElementString("Code", "PDF");
                            string path = "";
                            path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                            string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());

                            byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                            string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                            writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                            writer.WriteElementString("ValueType", "PDF File");
                            writer.WriteEndElement();
                        }
                        if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Prior Request")
                        {
                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "File");
                            writer.WriteElementString("Code", "PDF");
                            string path = "";
                            path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                            string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());

                            byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                            string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                            writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                            writer.WriteElementString("ValueType", "PDF File");
                            writer.WriteEndElement();
                        }
                        if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Prior Request")
                        {
                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "File");
                            writer.WriteElementString("Code", "PDF");
                            string path = "";
                            path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                            string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());

                            byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                            string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                            writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                            writer.WriteElementString("ValueType", "PDF File");
                            writer.WriteEndElement();
                        }
                        if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Prior Request")
                        {
                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "File");
                            writer.WriteElementString("Code", "PDF");
                            string path = "";
                            path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                            string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());

                            byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                            string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                            writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                            writer.WriteElementString("ValueType", "PDF File");
                            writer.WriteEndElement();
                        }
                        if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Prior Request")
                        {
                            writer.WriteStartElement("Observation");
                            writer.WriteElementString("Type", "File");
                            writer.WriteElementString("Code", "PDF");
                            string path = "";
                            path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                            string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());

                            byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                            string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                            writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                            writer.WriteElementString("ValueType", "PDF File");
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();

                        if (!string.IsNullOrEmpty(drTreat["pt_resub_type"].ToString()))
                        {
                            writer.WriteStartElement("Resubmission");
                            writer.WriteElementString("Type", drTreat["pt_resub_type"].ToString());
                            writer.WriteElementString("Comment", drTreat["pt_resub_notes"].ToString());
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                    string e_auth_ErrorMessage = string.Empty;
                    string transactionId = string.Empty;
                    byte[] e_auth_ErrorReport = new byte[1000];

                    if (dt.Rows[0]["set_city"].ToString() == "HAAD")
                    {
                        ae.gov.doh.shafafiya.Webservices e_auth = new ae.gov.doh.shafafiya.Webservices();

                        e_auth.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"")), filename, out e_auth_ErrorMessage, out e_auth_ErrorReport, out transactionId);
                    }
                    else
                    {
                        ae.eclaimlink.dhpo1.ValidateTransactions e_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();

                        e_auth.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString().Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"")), filename, out e_auth_ErrorMessage, out e_auth_ErrorReport);
                    }

                    string atr = string.Empty;

                    if (e_auth_ErrorMessage.Contains("successful") == false)
                    {
                        if (e_auth_ErrorMessage.Contains("invalid") == false)
                        {
                            if (e_auth_ErrorMessage.Contains("input") == false)
                            {
                                if (e_auth_ErrorReport != null)
                                {
                                    if (dt.Rows[0]["set_city"].ToString().ToUpper() == "HAAD")
                                    {
                                        FileStream destFile = System.IO.File.Open(Server.MapPath("~/PriorRequests/ErrorReport/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".zip"), FileMode.Create);
                                        destFile.Write(e_auth_ErrorReport, 0, e_auth_ErrorReport.Length);
                                        destFile.Close();
                                        string atr1 = "Error Msg: " + e_auth_ErrorMessage + " Error Report <a href='PriorRequests/ErrorReport/ErrorReportHAAD' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";
                                        atr = HttpUtility.HtmlDecode(atr1);
                                    }
                                    else
                                    {
                                        string path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                        string fileName = Path.Combine(path, "~/PriorRequests/ErrorReport/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls");
                                        // string fileName = "~/PriorRequests/ErrorReport/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls";
                                        FileStream destFile = System.IO.File.Open(Server.MapPath("~/PriorRequests/ErrorReport/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".xls"), FileMode.Create);
                                        destFile.Write(e_auth_ErrorReport, 0, e_auth_ErrorReport.Length);
                                        destFile.Close();

                                        string atr2 = "Error Msg: " + e_auth_ErrorMessage + " Error Report  <a href='PriorRequests/submissions/ErrorReportDHA' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-excel-o text-white'></i ></a>";
                                        atr = HttpUtility.HtmlDecode(atr2);

                                        return File(e_auth_ErrorReport, "application/vnd.ms-excel", fileName);
                                    }
                                }
                                else
                                {
                                    atr = "Error Msg: " + e_auth_ErrorMessage;
                                }
                            }
                            else
                            {
                                atr = "Error Msg: " + e_auth_ErrorMessage;
                            }
                        }
                        else
                        {
                            atr = "Error Msg: " + e_auth_ErrorMessage;
                        }
                    }
                    else
                    {
                        int epr_Id = 0;

                        if (s_flag == "PRODUCTION")
                        {
                            epr_Id = BusinessLogicLayer.EMR.PatientTreatments.EAUTH_Prior_Requests_insert(DateTime.Parse(DateTime.Now.ToString()), ptIds, dt.Rows[0]["set_permit_no"].ToString(), dt.Rows[0]["ic_code"].ToString(), filename, stringWriter.ToString(), e_auth_ErrorMessage, appId, PageControl.getLoggedinId());

                            String contents = stringWriter.ToString();

                            int length = contents.Length;
                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                            Response.AppendHeader("Content-Length", length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(contents);
                            Response.End();

                            if (epr_Id > 0)
                            {
                                atr = "Selected Treatment(s) submitted for eAuthorization Successfully!";
                            }
                            else
                            {
                                atr = "Error while Creating eAuthorization for Treatment(s)!";
                            }
                        }
                        else
                        {
                            atr = "Selected Treatment(s) submitted for eAuthorization Successfully in " + s_flag + " Mode!";
                        }
                    }

                    return Json(new { isSuccess = true, message = atr }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult PriorRequestCancel(int appId, string ptIds, string s_flag)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataSet ds = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestCancel(appId, ptIds);

                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        string file_name = string.Empty;

                        string filename = Server.MapPath("~/PriorRequests/Cancel/DHA/PRC-" + dt.Rows[0]["set_permit_no"].ToString() + "-" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH-mm-ss") + ".xml");

                        StringWriter stringWriter = new StringWriter();
                        XmlTextWriter writer = new XmlTextWriter(stringWriter);

                        writer.Formatting = System.Xml.Formatting.Indented;
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Prior.Request");

                        if (dr["set_city"].ToString() == "HAAD")
                        {
                            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "https://www.haad.ae/DataDictionary/CommonTypes/PriorRequest.xsd");
                        }
                        else
                        {
                            writer.WriteAttributeString("xmlns:tns", "https://www.eclaimlink.ae/DHD/ValidationSchema");
                            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "https://www.eclaimlink.ae/DHD/ValidationSchema/PriorRequest.xsd");
                        }

                        writer.WriteStartElement("Header");

                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("ReceiverID", dr["ic_code"].ToString());
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", "1");
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();

                        // Write Authorization elements
                        writer.WriteStartElement("Authorization");
                        writer.WriteElementString("Type", "Cancellation");
                        writer.WriteElementString("ID", dr["pt_barcode_img"].ToString());
                        writer.WriteElementString("IDPayer", dr["pt_auth_code"].ToString());
                        writer.WriteElementString("MemberID", dr["pi_insno"].ToString());
                        writer.WriteElementString("PayerID", dr["ip_code"].ToString());
                        writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");

                        writer.WriteEndElement();
                        // End Authorization element                       
                        writer.WriteEndElement();
                        // End Claim element
                        //writer.WriteEndElement();
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();

                        file_name = "PAC-" + dt.Rows[0]["set_permit_no"].ToString() + "-" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ".xml";

                        string e_auth_ErrorMessage = string.Empty;
                        string transactionId = string.Empty;

                        byte[] e_auth_ErrorReport = new byte[1000];

                        if (dt.Rows[0]["set_city"].ToString() == "HAAD")
                        {
                            ae.gov.doh.shafafiya.Webservices e_auth = new ae.gov.doh.shafafiya.Webservices();

                            e_auth.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString()), file_name, out e_auth_ErrorMessage, out e_auth_ErrorReport, out transactionId);
                        }
                        else
                        {
                            ae.eclaimlink.dhpo1.ValidateTransactions e_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();

                            e_auth.UploadTransaction(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), Encoding.UTF8.GetBytes(stringWriter.ToString()), file_name, out e_auth_ErrorMessage, out e_auth_ErrorReport);
                        }

                        TempData["ErrorMessage"] = e_auth_ErrorMessage;

                        string atr = string.Empty;

                        if (e_auth_ErrorMessage.Contains("successful") == false)
                        {
                            FileStream destFile = System.IO.File.Open(Server.MapPath("~/PriorRequests/ErrorReport/ERROR_REPORT_" + DateTime.Now.ToString("ddMMyyyyhhsstt") + ".zip"), FileMode.Create);
                            destFile.Write(e_auth_ErrorReport, 0, e_auth_ErrorReport.Length);
                            destFile.Close();

                            string atr1 = "Error Msg: " + e_auth_ErrorMessage + " Error Report <a href='/ResubmissionClaims/ErrorReportHAAD' class='fs-25 text-primary font-weight-bold text-center'><i class='fa fa-file-archive-o text-white'></i ></a>";

                            atr = HttpUtility.HtmlDecode(atr1);

                            return Json(new { isSuccess = true, message = "Failed To Cancel e-Authorization" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            int epr_Id = 0;

                            epr_Id = BusinessLogicLayer.EMR.PatientTreatments.EAUTH_Prior_Requests_insert(DateTime.Parse(DateTime.Now.ToString()), ptIds, dt.Rows[0]["set_permit_no"].ToString(), dt.Rows[0]["ic_code"].ToString(), file_name, stringWriter.ToString(), e_auth_ErrorMessage, appId, PageControl.getLoggedinId());

                            Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                            Response.AppendHeader("Content-Length", stringWriter.ToString().Length.ToString());
                            Response.ContentType = "text/xml";
                            Response.Write(stringWriter.ToString());
                            Response.End();

                            if (epr_Id > 0)
                            {
                                return Json(new { isSuccess = true, message = "Selected Treatment submitted for e-Request Cancellation Successfully!" }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isSuccess = false, message = "Error while Cancellation!" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "There are no Prior Auth XML Details for the Selected Treatment(s)!" }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Prior Request Manual
        [HttpGet]
        public ActionResult GenerateXml(string ptIds, int appId, string s_flag)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DateTime TransactionDate = DateTime.Now;

                    DataSet ds = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestDirect(appId, ptIds);

                    DataTable dt_signs = ds.Tables[0];

                    string filename = "PR-" + dt_signs.Rows[0]["set_permit_no"].ToString() + "-" + DateTime.Parse(dt_signs.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH-mm-ss") + ".xml";

                    string file = Server.MapPath("~/PriorRequests/Direct/DHA/" + filename);

                    XmlTextWriter writer = new XmlTextWriter(file, System.Text.Encoding.UTF8);
                    writer.Formatting = System.Xml.Formatting.Indented;
                    writer.WriteStartDocument();

                    if (dt_signs.Rows.Count > 0)
                    {
                        DataRow dr = dt_signs.Rows[0];

                        writer.WriteStartElement("Prior.Request");

                        if (dr["set_city"].ToString() == "HAAD")
                        {
                            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "https://www.haad.ae/DataDictionary/CommonTypes/PriorRequest.xsd");
                        }
                        else
                        {
                            writer.WriteAttributeString("xmlns:tns", "https://www.eclaimlink.ae/DHD/ValidationSchema");
                            writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
                            writer.WriteAttributeString("xsi:noNamespaceSchemaLocation", "https://www.eclaimlink.ae/DHD/ValidationSchema/PriorRequest.xsd");
                        }

                        writer.WriteStartElement("Header");
                        // Write Header elements
                        writer.WriteElementString("SenderID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("ReceiverID", dr["ic_code"].ToString());
                        writer.WriteElementString("TransactionDate", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        writer.WriteElementString("RecordCount", "1");
                        writer.WriteElementString("DispositionFlag", s_flag);
                        // End Header element
                        writer.WriteEndElement();

                        // Write Authorization elements
                        writer.WriteStartElement("Authorization");
                        writer.WriteElementString("Type", "Authorization");
                        writer.WriteElementString("ID", dr["pt_barcode_img"].ToString());
                        writer.WriteElementString("IDPayer", dr["pt_auth_code"].ToString());
                        writer.WriteElementString("MemberID", dr["pi_insno"].ToString());
                        writer.WriteElementString("PayerID", dr["ip_code"].ToString());
                        writer.WriteElementString("EmiratesIDNumber", "999-9999-9999999-9");
                        writer.WriteElementString("DateOrdered", DateTime.Now.ToString("dd/MM/yyyy"));

                        //Encounter Generation Starts Here.....
                        writer.WriteStartElement("Encounter");
                        writer.WriteElementString("FacilityID", dr["set_permit_no"].ToString());
                        writer.WriteElementString("Type", "1");
                        writer.WriteEndElement();
                        // Encounter Generation Ends Here.....

                        string tr_date_time = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd/MM/yyyy HH:mm");

                        DataTable dtDiag = BusinessLogicLayer.Documentation.CoderDiagnosis.GetAllCoderDiagnosisForPriorRequests(int.Parse(dr["appId"].ToString()), 0);

                        int diag_count = 0;

                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            diag_count = diag_count + 1;
                            writer.WriteStartElement("Diagnosis");

                            if (drDiag["cod_type"].ToString() == "Primary")
                            {
                                writer.WriteElementString("Type", "Principal");
                            }
                            else
                            {
                                writer.WriteElementString("Type", "Secondary");
                            }
                            writer.WriteElementString("Code", drDiag["diag_Code"].ToString());

                            writer.WriteEndElement();
                        }

                        int y = 0;

                        foreach (DataRow drTreat in dt_signs.Rows)
                        {
                            float pt_net = float.Parse(drTreat["pt_net"].ToString());

                            string act_no = drTreat["ptId"].ToString();

                            int ActDetails = BusinessLogicLayer.EMR.PatientTreatments.InsertActivityDetails(int.Parse(drTreat["ptId"].ToString()), int.Parse(dr["appId"].ToString()), drTreat["pt_resub_type"].ToString(), act_no, PageControl.getLoggedinId(), pt_net, "Submissions");

                            DateTime app_date = DateTime.Parse(drTreat["app_fdate"].ToString());
                            y = y + 1;
                            //Activity Generation Starts Here.....
                            writer.WriteStartElement("Activity");
                            writer.WriteElementString("ID", act_no);
                            writer.WriteElementString("Start", tr_date_time);
                            writer.WriteElementString("Type", drTreat["tr_itype"].ToString());
                            writer.WriteElementString("Code", drTreat["tr_code"].ToString());
                            writer.WriteElementString("Quantity", drTreat["pt_qty"].ToString());
                            writer.WriteElementString("Net", pt_net.ToString("0.00"));

                            if (!string.IsNullOrEmpty(drTreat["pt_teeth"].ToString()))
                            {
                                if (drTreat["pt_teeth"].ToString() != "N/A")
                                {
                                    writer.WriteStartElement("Observation");
                                    writer.WriteElementString("Type", "Universal Dental");
                                    writer.WriteElementString("Code", drTreat["pt_teeth"].ToString());
                                    writer.WriteEndElement();
                                }
                            }

                            if (!string.IsNullOrEmpty(drTreat["ti_lab_17"].ToString()))
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "Text");
                                writer.WriteElementString("Code", drTreat["ti_lab_17"].ToString());
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_1"].ToString() != "" && drTreat["ti_image_1_type"].ToString() == "Prior Request")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_1"].ToString());

                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }

                            if (drTreat["ti_image_2"].ToString() != "" && drTreat["ti_image_2_type"].ToString() == "Prior Request")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_2"].ToString());

                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_3"].ToString() != "" && drTreat["ti_image_3_type"].ToString() == "Prior Request")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_3"].ToString());

                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_4"].ToString() != "" && drTreat["ti_image_4_type"].ToString() == "Prior Request")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_4"].ToString());

                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            if (drTreat["ti_image_5"].ToString() != "" && drTreat["ti_image_5_type"].ToString() == "Prior Request")
                            {
                                writer.WriteStartElement("Observation");
                                writer.WriteElementString("Type", "File");
                                writer.WriteElementString("Code", "PDF");
                                string path = "";
                                path = Server.MapPath(ConfigurationManager.AppSettings["Attachment"]);
                                string file_path = Path.Combine(path, drTreat["ti_image_5"].ToString());

                                byte[] pdfByte = System.IO.File.ReadAllBytes(file_path);
                                string base64String = Convert.ToBase64String(pdfByte).Trim().Replace(" ", "");
                                writer.WriteElementString("Value", SpliceText((Convert.ToBase64String(pdfByte).Trim().Replace(" ", "")), 100));
                                writer.WriteElementString("ValueType", "PDF File");
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            if (!string.IsNullOrEmpty(drTreat["pt_resub_type"].ToString()))
                            {
                                writer.WriteStartElement("Resubmission");
                                writer.WriteElementString("Type", drTreat["pt_resub_type"].ToString());
                                writer.WriteElementString("Comment", drTreat["pt_resub_notes"].ToString());
                                writer.WriteEndElement();
                            }
                        }

                        writer.WriteEndElement();
                        // End Authorization element                       
                        writer.WriteEndElement();
                        // End Claim element
                        //writer.WriteEndElement();
                        writer.WriteEndDocument();
                        // string val= stringWriter.ToString();
                        writer.Flush();
                        writer.Close();

                        byte[] fileContent = null;

                        string fileName = Path.Combine(file);

                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        fileContent = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();

                        return new FileContentResult(fileContent, "application/xml");
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatment(s) to Generate Prior Request Manual!" }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateApproval(int ptId, string pt_auth_code, DateTime pt_auth_adate, DateTime pt_auth_edate)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    ptId = BusinessLogicLayer.EMR.PatientTreatments.UpdateApproval(ptId, pt_auth_code, pt_auth_adate, pt_auth_edate);

                    if (ptId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee updated approval details for the id= {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "ptIds : " + ptId + " is updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in Updating status " }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Prior Request Direct (MOH - Riayathi)
        [HttpGet]
        public async Task<ActionResult> GenerateJsonDirect(int appId, string ptIds, string s_flag)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataSet ds = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestDirect(appId, ptIds);

                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        string emId = string.Empty;
                        string empLicense = string.Empty;
                        float pt_net = 0;
                        string emirateId = dr["pat_emirateid"].ToString().Trim();

                        DateTime existingDate = DateTime.Parse(dr["app_fdate"].ToString());
                        DateTime currentTime = DateTime.Now;
                        DateTime combinedDateTime = new DateTime(existingDate.Year, existingDate.Month, existingDate.Day, currentTime.Hour, currentTime.Minute, 0);

                        string tr_date_time = combinedDateTime.ToString("dd/MM/yyyy HH:mm");

                        string transaction_date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                        if (!string.IsNullOrEmpty(emirateId))
                        {
                            if (emirateId.Length == 15)
                            {
                                emId = $"{emirateId.Substring(0, 3)}-{emirateId.Substring(3, 4)}-{emirateId.Substring(7, 7)}-{emirateId.Substring(14)}";
                            }
                            else if (emirateId.Length == 18)
                            {
                                emId = emirateId;
                            }
                            else
                            {
                                emId = "999-9999-9999999-9";
                            }
                        }
                        else
                        {
                            emId = "999-9999-9999999-9";
                        }

                        DataTable dtDiag = BusinessLogicLayer.Documentation.CoderDiagnosis.GetAllCoderDiagnosisForPriorRequests(int.Parse(dr["appId"].ToString()), 0);

                        PriorRequestsMOH.Prior_Request prior_request = new PriorRequestsMOH.Prior_Request();
                        PriorRequestsMOH.PriorRequest priorrequest = new PriorRequestsMOH.PriorRequest();

                        PriorRequestsMOH.Header header = new PriorRequestsMOH.Header();
                        header.SenderID = dr["set_sat_ftime"].ToString();
                        header.ReceiverID = dr["ic_code"].ToString().Trim();
                        header.TransactionDate = transaction_date;
                        header.RecordCount = "1";
                        header.DispositionFlag = s_flag;
                        header.PayerID = dr["ip_code"].ToString().Trim();
                        priorrequest.Header = header;

                        PriorRequestsMOH.Authorization authorization = new PriorRequestsMOH.Authorization();
                        authorization.Type = "Authorization";
                        authorization.ID = dt.Rows[0]["pt_barcode_img"].ToString().Trim();
                        authorization.RequestType = "New";
                        authorization.RequestReferenceNumber = "";
                        authorization.MemberID = dt.Rows[0]["pi_insno"].ToString().Trim();
                        authorization.Weight = "1.0";
                        authorization.EmiratesIDNumber = emId;
                        authorization.DateOrdered = transaction_date;
                        authorization.DateOfBirth = DateTime.Parse(dr["pat_dob"].ToString()).ToString("dd/MM/yyyy");
                        authorization.Gender = dr["pat_gender"].ToString();

                        PriorRequestsMOH.Encounter encounter = new PriorRequestsMOH.Encounter();
                        encounter.FacilityID = dr["set_sat_ftime"].ToString();
                        encounter.Type = "1";
                        authorization.Encounter = encounter;

                        List<PriorRequestsMOH.Diagnosis> DiagnosisMain = new List<PriorRequestsMOH.Diagnosis>();

                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            PriorRequestsMOH.Diagnosis diagnosis = new PriorRequestsMOH.Diagnosis();

                            if (drDiag["cod_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }

                            diagnosis.Code = drDiag["diag_Code"].ToString().Trim();
                            DiagnosisMain.Add(diagnosis);
                        }

                        authorization.Diagnosis = DiagnosisMain;

                        List<PriorRequestsMOH.Activity> ActivityMain = new List<PriorRequestsMOH.Activity>();

                        foreach (DataRow drTreat in dt.Rows)
                        {
                            pt_net = float.Parse(drTreat["pt_net"].ToString());

                            empLicense = drTreat["emp_license"].ToString().Trim();

                            if (empLicense.StartsWith("MOH", StringComparison.OrdinalIgnoreCase) && empLicense.Length > 3)
                            {
                                empLicense = empLicense.Substring(3);
                            }
                            else if (empLicense.StartsWith("DHA-P-MOH", StringComparison.OrdinalIgnoreCase) && empLicense.Length > 9)
                            {
                                empLicense = empLicense.Substring(9);
                            }
                            PriorRequestsMOH.Activity activity = new PriorRequestsMOH.Activity();
                            activity.ID = drTreat["ptId"].ToString();
                            activity.ActivityReference = "";
                            activity.Start = tr_date_time;
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Unit = "1";
                            activity.Net = pt_net.ToString("0.00");
                            activity.Clinician = empLicense;
                            activity.Duration = "1";

                            List<PriorRequestsMOH.Observation> ObservationMain = new List<PriorRequestsMOH.Observation>();
                            PriorRequestsMOH.Observation observation = new PriorRequestsMOH.Observation();

                            if (!string.IsNullOrEmpty(drTreat["pt_teeth"].ToString()))
                            {
                                if (drTreat["pt_teeth"].ToString() != "N/A")
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "UniversalDental";
                                    _observation.Code = "UniversalNumberingSystemDental";
                                    _observation.Value = drTreat["pt_teeth"].ToString();
                                    _observation.ValueType = "ToothNumber";
                                    ObservationMain.Add(_observation);
                                }
                            }

                            if (!string.IsNullOrEmpty(drTreat["ti_image_1"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno1"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_2"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno2"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_3"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno3"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_4"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno4"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_5"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno5"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }

                            if (ObservationMain.Count > 0)
                            {
                                activity.Observation = ObservationMain;
                            }
                            ActivityMain.Add(activity);
                        }

                        authorization.Activity = ActivityMain;
                        priorrequest.Authorization = authorization;
                        prior_request.PriorRequest = priorrequest;

                        string myDeserializedClass = JsonConvert.SerializeObject(prior_request);

                        string filename = "PR-" + dt.Rows[0]["set_sat_ftime"].ToString() + "-" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH-mm-ss") + ".json";

                        string path = Server.MapPath("~/PriorRequests/Direct/MOH/Requests/");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        Path.Combine(path, filename);

                        System.IO.File.WriteAllText(Path.Combine(path, filename), myDeserializedClass.ToString());

                        string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString().Trim();
                        string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString().Trim();
                        string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString().Trim();

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        var options = new RestClientOptions(strApiUrl)
                        {
                            MaxTimeout = -1,
                        };

                        var client = new RestClient(options);
                        var request = new RestRequest("/Authorization/PostRequest", Method.Post);

                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("username", strUsername);
                        request.AddHeader("password", strPassword);
                        request.AddParameter("application/json", myDeserializedClass, ParameterType.RequestBody);

                        RestResponse response = await client.ExecuteAsync(request);

                        PriorRequestsMOH.Prior_request_response result = JsonConvert.DeserializeObject<PriorRequestsMOH.Prior_request_response>(response.Content);

                        string rpath = Server.MapPath("~/PriorRequests/Direct/MOH/Response/");

                        if (!Directory.Exists(rpath))
                        {
                            Directory.CreateDirectory(rpath);
                        }

                        System.IO.File.WriteAllText(Path.Combine(rpath, filename), response.Content.ToString());

                        bool isSubmitted = false;
                        string mesg = string.Empty;

                        if (result.StatusCode == "201" || result.StatusCode == "200")
                        {
                            if (s_flag == "PRODUCTION")
                            {
                                int epr_Id = BusinessLogicLayer.EMR.PatientTreatments.EAUTH_Prior_Requests_insert(DateTime.Parse(DateTime.Now.ToString()), ptIds, dt.Rows[0]["set_sat_ftime"].ToString(), dt.Rows[0]["ic_code"].ToString(), filename, filename, result.UserMessage.ToString().Trim(), appId, PageControl.getLoggedinId());

                                if (epr_Id > 0)
                                {
                                    isSubmitted = true;

                                    mesg = "Selected Treatment(s) submitted for eAuthorization Successfully!";
                                }
                                else
                                {
                                    mesg = "Error while Creating eAuthorization for Treatment(s)!";
                                }
                            }
                            else
                            {
                                isSubmitted = true;

                                mesg = "Selected Treatment(s) submitted for eAuthorization Successfully in " + s_flag + " Mode!";
                            }

                            return Json(new { isSuccess = isSubmitted, message = mesg, response = result }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            int count = 1;

                            foreach (var err in result.Error)
                            {
                                string ErrMsg = " " + count + "." + err.ErrorText + ".</br>";
                                mesg += ErrMsg;
                                count = count + 1;
                            }

                            return Json(new { isSuccess = isSubmitted, message = mesg, response = result }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatment(s) to Submit eAuthorization!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (WebException ex)
                {
                    string message = ex.Message;
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    string responseFromServer = sr.ReadToEnd();

                    PriorRequestsMOH.Prior_request_response result = JsonConvert.DeserializeObject<PriorRequestsMOH.Prior_request_response>(responseFromServer);

                    if (result.StatusCode == "400" || result.StatusCode == "401")
                    {
                        int count = 1;

                        foreach (var err in result.Error)
                        {
                            string ErrMsg = " " + count + "." + err.ErrorText + ".";
                            message += ErrMsg;
                            count = count + 1;
                        }
                    }

                    return Json(new { isSuccess = false, message = message, response = result }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PriorRequestJsonCancel(int appId, string ptIds, string s_flag)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataSet ds = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestDirect(appId, ptIds);

                    DataTable dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        string emId = string.Empty;
                        string empLicense = string.Empty;
                        float pt_net = 0;
                        string emirateId = dr["pat_emirateid"].ToString().Trim();

                        DateTime existingDate = DateTime.Parse(dr["app_fdate"].ToString());
                        DateTime currentTime = DateTime.Now;
                        DateTime combinedDateTime = new DateTime(existingDate.Year, existingDate.Month, existingDate.Day, currentTime.Hour, currentTime.Minute, 0);

                        string tr_date_time = combinedDateTime.ToString("dd/MM/yyyy HH:mm");

                        string transaction_date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                        if (!string.IsNullOrEmpty(emirateId))
                        {
                            if (emirateId.Length == 15)
                            {
                                emId = $"{emirateId.Substring(0, 3)}-{emirateId.Substring(3, 4)}-{emirateId.Substring(7, 7)}-{emirateId.Substring(14)}";
                            }
                            else if (emirateId.Length == 18)
                            {
                                emId = emirateId;
                            }
                            else
                            {
                                emId = "999-9999-9999999-9";
                            }
                        }
                        else
                        {
                            emId = "999-9999-9999999-9";
                        }

                        DataTable dtDiag = BusinessLogicLayer.Documentation.CoderDiagnosis.GetAllCoderDiagnosisForPriorRequests(int.Parse(dr["appId"].ToString()), 0);

                        PriorRequestsMOH.Prior_Request prior_request = new PriorRequestsMOH.Prior_Request();
                        PriorRequestsMOH.PriorRequest priorrequest = new PriorRequestsMOH.PriorRequest();

                        PriorRequestsMOH.Header header = new PriorRequestsMOH.Header();
                        header.SenderID = dr["set_sat_ftime"].ToString();
                        header.ReceiverID = dr["ic_code"].ToString().Trim();
                        header.TransactionDate = transaction_date;
                        header.RecordCount = "1";
                        header.DispositionFlag = s_flag;
                        header.PayerID = dr["ip_code"].ToString().Trim();
                        priorrequest.Header = header;

                        PriorRequestsMOH.Authorization authorization = new PriorRequestsMOH.Authorization();
                        authorization.Type = "Cancellation";
                        authorization.ID = dt.Rows[0]["pt_barcode_img"].ToString().Trim();
                        authorization.RequestType = "New";
                        authorization.RequestReferenceNumber = "";
                        authorization.MemberID = dt.Rows[0]["pi_insno"].ToString().Trim();
                        authorization.Weight = "1.0";
                        authorization.EmiratesIDNumber = emId;
                        authorization.DateOrdered = transaction_date;
                        authorization.DateOfBirth = DateTime.Parse(dr["pat_dob"].ToString()).ToString("dd/MM/yyyy");
                        authorization.Gender = dr["pat_gender"].ToString();

                        PriorRequestsMOH.Encounter encounter = new PriorRequestsMOH.Encounter();
                        encounter.FacilityID = dr["set_sat_ftime"].ToString();
                        encounter.Type = "1";
                        authorization.Encounter = encounter;

                        List<PriorRequestsMOH.Diagnosis> DiagnosisMain = new List<PriorRequestsMOH.Diagnosis>();

                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            PriorRequestsMOH.Diagnosis diagnosis = new PriorRequestsMOH.Diagnosis();

                            if (drDiag["cod_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }

                            diagnosis.Code = drDiag["diag_Code"].ToString().Trim();
                            DiagnosisMain.Add(diagnosis);
                        }

                        authorization.Diagnosis = DiagnosisMain;

                        List<PriorRequestsMOH.Activity> ActivityMain = new List<PriorRequestsMOH.Activity>();

                        foreach (DataRow drTreat in dt.Rows)
                        {
                            pt_net = float.Parse(drTreat["pt_net"].ToString());

                            empLicense = drTreat["emp_license"].ToString().Trim();

                            if (empLicense.StartsWith("MOH", StringComparison.OrdinalIgnoreCase) && empLicense.Length > 3)
                            {
                                empLicense = empLicense.Substring(3);
                            }
                            else if (empLicense.StartsWith("DHA-P-MOH", StringComparison.OrdinalIgnoreCase) && empLicense.Length > 9)
                            {
                                empLicense = empLicense.Substring(9);
                            }
                            PriorRequestsMOH.Activity activity = new PriorRequestsMOH.Activity();
                            activity.ID = drTreat["ptId"].ToString();
                            activity.ActivityReference = "";
                            activity.Start = tr_date_time;
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Unit = "1";
                            activity.Net = pt_net.ToString("0.00");
                            activity.Clinician = empLicense;
                            activity.Duration = "1";

                            List<PriorRequestsMOH.Observation> ObservationMain = new List<PriorRequestsMOH.Observation>();
                            PriorRequestsMOH.Observation observation = new PriorRequestsMOH.Observation();

                            if (!string.IsNullOrEmpty(drTreat["pt_teeth"].ToString()))
                            {
                                if (drTreat["pt_teeth"].ToString() != "N/A")
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "UniversalDental";
                                    _observation.Code = "UniversalNumberingSystemDental";
                                    _observation.Value = drTreat["pt_teeth"].ToString();
                                    _observation.ValueType = "ToothNumber";
                                    ObservationMain.Add(_observation);
                                }
                            }

                            if (!string.IsNullOrEmpty(drTreat["ti_image_1"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno1"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_2"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno2"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_3"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno3"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_4"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno4"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_5"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno5"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }

                            if (ObservationMain.Count > 0)
                            {
                                activity.Observation = ObservationMain;
                            }
                            ActivityMain.Add(activity);
                        }

                        authorization.Activity = ActivityMain;
                        priorrequest.Authorization = authorization;
                        prior_request.PriorRequest = priorrequest;

                        string myDeserializedClass = JsonConvert.SerializeObject(prior_request);

                        string filename = "PRC-" + dt.Rows[0]["set_sat_ftime"].ToString() + "-" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH-mm-ss") + ".json";

                        string path = Server.MapPath("~/PriorRequests/Cancel/MOH/Requests/");

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        Path.Combine(path, filename);

                        System.IO.File.WriteAllText(Path.Combine(path, filename), myDeserializedClass.ToString());

                        string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString().Trim();
                        string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString().Trim();
                        string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString().Trim();

                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                        var options = new RestClientOptions(strApiUrl)
                        {
                            MaxTimeout = -1,
                        };

                        var client = new RestClient(options);
                        var request = new RestRequest("/Authorization/PostRequest", Method.Post);

                        request.AddHeader("Content-Type", "application/json");
                        request.AddHeader("username", strUsername);
                        request.AddHeader("password", strPassword);
                        request.AddParameter("application/json", myDeserializedClass, ParameterType.RequestBody);

                        RestResponse response = await client.ExecuteAsync(request);

                        PriorRequestsMOH.Prior_request_response result = JsonConvert.DeserializeObject<PriorRequestsMOH.Prior_request_response>(response.Content);

                        string rpath = Server.MapPath("~/PriorRequests/Cancel/MOH/Response/");

                        if (!Directory.Exists(rpath))
                        {
                            Directory.CreateDirectory(rpath);
                        }

                        System.IO.File.WriteAllText(Path.Combine(rpath, filename), response.Content.ToString());

                        bool isSubmitted = false;
                        string mesg = string.Empty;

                        if (result.StatusCode == "201" || result.StatusCode == "200")
                        {
                            if (s_flag == "PRODUCTION")
                            {
                                int epr_Id = BusinessLogicLayer.EMR.PatientTreatments.EAUTH_Prior_Requests_insert(DateTime.Parse(DateTime.Now.ToString()), ptIds, dt.Rows[0]["set_sat_ftime"].ToString(), dt.Rows[0]["ic_code"].ToString(), filename, filename, result.UserMessage.ToString().Trim(), appId, PageControl.getLoggedinId());

                                if (epr_Id > 0)
                                {
                                    isSubmitted = true;
                                    mesg = "Selected Treatment(s) submitted for eAuthorization Successfully!";
                                }
                                else
                                {
                                    mesg = "Error while Creating eAuthorization for Treatment(s)!";
                                }
                            }
                            else
                            {
                                isSubmitted = true;
                                mesg = "Selected Treatment(s) submitted for eAuthorization Successfully in " + s_flag + " Mode!";
                            }

                            return Json(new { isSuccess = isSubmitted, message = mesg, response = result }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            int count = 1;

                            foreach (var err in result.Error)
                            {
                                string ErrMsg = " " + count + "." + err.ErrorText + ".<br/>";
                                mesg += ErrMsg;
                                count = count + 1;
                            }

                            return Json(new { isSuccess = false, message = mesg, response = result }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "There are no Prior Auth XML Details for the Selected Treatment(s)!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (WebException ex)
                {
                    string message = ex.Message;
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    string responseFromServer = sr.ReadToEnd();

                    PriorRequestsMOH.Prior_request_response result = JsonConvert.DeserializeObject<PriorRequestsMOH.Prior_request_response>(responseFromServer);

                    if (result.StatusCode == "400" || result.StatusCode == "401")
                    {
                        int count = 1;

                        foreach (var err in result.Error)
                        {
                            string ErrMsg = " " + count + "." + err.ErrorText + ".";
                            message += ErrMsg;
                            count = count + 1;
                        }
                    }

                    return Json(new { isSuccess = false, message = message, response = result }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Prior Request Manual (MOH - Riayathi)
        [HttpGet]
        public ActionResult GenerateJsonManual(string ptIds, int appId, string s_flag)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    DataSet ds = BusinessLogicLayer.EMR.PatientTreatments.GetPatientTreatmentsPriorRequestDirect(appId, ptIds);

                    DataTable dt = ds.Tables[0];

                    string file = "PR-" + dt.Rows[0]["set_sat_ftime"].ToString() + "-" + DateTime.Parse(dt.Rows[0]["app_fdate"].ToString()).ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("HH-mm-ss") + ".json";

                    string filename = Server.MapPath("~/PriorRequests/Manual/MOH/" + file);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        string emId = string.Empty;
                        float pt_net = 0;
                        string empLicense = string.Empty;
                        string emirateId = dr["pat_emirateid"].ToString().Trim();
                        //string tr_date_time = DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd/MM/yyyy HH:mm");

                        DateTime existingDate = DateTime.Parse(dr["app_fdate"].ToString());
                        DateTime currentTime = DateTime.Now;
                        DateTime combinedDateTime = new DateTime(existingDate.Year, existingDate.Month, existingDate.Day, currentTime.Hour, currentTime.Minute, 0);
                        string tr_date_time = combinedDateTime.ToString("dd/MM/yyyy HH:mm");

                        string transaction_date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                        if (!string.IsNullOrEmpty(emirateId))
                        {
                            if (emirateId.Length == 15)
                            {
                                emId = $"{emirateId.Substring(0, 3)}-{emirateId.Substring(3, 4)}-{emirateId.Substring(7, 7)}-{emirateId.Substring(14)}";
                            }
                            else if (emirateId.Length == 18)
                            {
                                emId = emirateId;
                            }
                            else
                            {
                                emId = "999-9999-9999999-9";
                            }
                        }
                        else
                        {
                            emId = "999-9999-9999999-9";
                        }

                        DataTable dtDiag = BusinessLogicLayer.Documentation.CoderDiagnosis.GetAllCoderDiagnosisForPriorRequests(int.Parse(dr["appId"].ToString()), 0);

                        PriorRequestsMOH.Prior_Request prior_request = new PriorRequestsMOH.Prior_Request();
                        PriorRequestsMOH.PriorRequest priorrequest = new PriorRequestsMOH.PriorRequest();

                        PriorRequestsMOH.Header header = new PriorRequestsMOH.Header();
                        header.SenderID = dr["set_sat_ftime"].ToString();
                        header.ReceiverID = dr["ic_code"].ToString().Trim();
                        header.TransactionDate = transaction_date;
                        header.RecordCount = "1";
                        header.DispositionFlag = s_flag;
                        header.PayerID = dr["ip_code"].ToString().Trim();
                        priorrequest.Header = header;

                        PriorRequestsMOH.Authorization authorization = new PriorRequestsMOH.Authorization();
                        authorization.Type = "Authorization";
                        authorization.ID = dt.Rows[0]["pt_barcode_img"].ToString().Trim();
                        authorization.RequestType = "New";
                        authorization.RequestReferenceNumber = "";
                        authorization.MemberID = dt.Rows[0]["pi_insno"].ToString().Trim();
                        authorization.Weight = "1.0";
                        authorization.EmiratesIDNumber = emId;
                        authorization.DateOrdered = transaction_date;
                        authorization.DateOfBirth = DateTime.Parse(dr["pat_dob"].ToString()).ToString("dd/MM/yyyy");
                        authorization.Gender = dr["pat_gender"].ToString();

                        PriorRequestsMOH.Encounter encounter = new PriorRequestsMOH.Encounter();
                        encounter.FacilityID = dr["set_sat_ftime"].ToString();
                        encounter.Type = "1";
                        authorization.Encounter = encounter;

                        List<PriorRequestsMOH.Diagnosis> DiagnosisMain = new List<PriorRequestsMOH.Diagnosis>();

                        foreach (DataRow drDiag in dtDiag.Rows)
                        {
                            PriorRequestsMOH.Diagnosis diagnosis = new PriorRequestsMOH.Diagnosis();

                            if (drDiag["cod_type"].ToString() == "Primary")
                            {
                                diagnosis.Type = "Principal";
                            }
                            else
                            {
                                diagnosis.Type = "Secondary";
                            }

                            diagnosis.Code = drDiag["diag_Code"].ToString().Trim();
                            DiagnosisMain.Add(diagnosis);
                        }

                        authorization.Diagnosis = DiagnosisMain;

                        List<PriorRequestsMOH.Activity> ActivityMain = new List<PriorRequestsMOH.Activity>();

                        foreach (DataRow drTreat in dt.Rows)
                        {
                            pt_net = float.Parse(drTreat["pt_net"].ToString());

                            empLicense = drTreat["emp_license"].ToString().Trim();

                            if (empLicense.StartsWith("MOH", StringComparison.OrdinalIgnoreCase) && empLicense.Length > 3)
                            {
                                empLicense = empLicense.Substring(3);
                            }
                            else if (empLicense.StartsWith("DHA-P-MOH", StringComparison.OrdinalIgnoreCase) && empLicense.Length > 9)
                            {
                                empLicense = empLicense.Substring(9);
                            }
                            PriorRequestsMOH.Activity activity = new PriorRequestsMOH.Activity();
                            activity.ID = drTreat["ptId"].ToString();
                            activity.ActivityReference = "";
                            activity.Start = tr_date_time;
                            activity.Type = drTreat["tr_itype"].ToString().Trim();
                            activity.Code = drTreat["tr_code"].ToString().Trim();
                            activity.Location = "2";
                            activity.Quantity = drTreat["pt_qty"].ToString().Trim();
                            activity.Unit = "1";
                            activity.Net = pt_net.ToString("0.00");
                            activity.Clinician = empLicense;
                            activity.Duration = "1";

                            List<PriorRequestsMOH.Observation> ObservationMain = new List<PriorRequestsMOH.Observation>();
                            PriorRequestsMOH.Observation observation = new PriorRequestsMOH.Observation();

                            if (!string.IsNullOrEmpty(drTreat["pt_teeth"].ToString()))
                            {
                                if (drTreat["pt_teeth"].ToString() != "N/A")
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "UniversalDental";
                                    _observation.Code = "UniversalNumberingSystemDental";
                                    _observation.Value = drTreat["pt_teeth"].ToString();
                                    _observation.ValueType = "ToothNumber";
                                    ObservationMain.Add(_observation);
                                }
                            }

                            if (!string.IsNullOrEmpty(drTreat["ti_image_1"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno1"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno1"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_2"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno2"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno2"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_3"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno3"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno3"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_4"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno4"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno4"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }
                            if (!string.IsNullOrEmpty(drTreat["ti_image_5"].ToString()))
                            {
                                if (!string.IsNullOrEmpty(drTreat["ti_img_refno5"].ToString()))
                                {
                                    PriorRequestsMOH.Observation _observation = new PriorRequestsMOH.Observation();
                                    _observation.Type = "File";
                                    _observation.Code = "File";
                                    _observation.Value = drTreat["ti_img_refno5"].ToString().Trim();
                                    _observation.ValueType = "File";
                                    ObservationMain.Add(_observation);
                                }
                            }

                            if (ObservationMain.Count > 0)
                            {
                                activity.Observation = ObservationMain;
                            }
                            ActivityMain.Add(activity);
                        }

                        authorization.Activity = ActivityMain;
                        priorrequest.Authorization = authorization;
                        prior_request.PriorRequest = priorrequest;

                        string myDeserializedClass = JsonConvert.SerializeObject(prior_request);

                        string path = Server.MapPath("~/PriorRequests/Manual/MOH/");

                        Path.Combine(path, file);

                        System.IO.File.WriteAllText(Path.Combine(path, file), myDeserializedClass.ToString());

                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + file);
                        Response.AppendHeader("Content-Length", myDeserializedClass.Length.ToString());
                        Response.ContentType = "text/json";
                        Response.Write(myDeserializedClass.ToString());
                        Response.End();

                        byte[] fileContents = System.Text.Encoding.UTF8.GetBytes(myDeserializedClass);

                        return File(fileContents, "application/json", file);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select Treatment(s) to Generate Prior Request Manual!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (WebException ex)
                {
                    string message = ex.Message;
                    StreamReader sr = new StreamReader(ex.Response.GetResponseStream());

                    string responseFromServer = sr.ReadToEnd();

                    PriorRequestsMOH.Prior_request_response result = JsonConvert.DeserializeObject<PriorRequestsMOH.Prior_request_response>(responseFromServer);

                    if (result.StatusCode == "400")
                    {
                        int count = 1;

                        foreach (var err in result.Error)
                        {
                            string ErrMsg = " " + count + "." + err.ErrorText + ".";
                            message += ErrMsg;
                            count = count + 1;
                        }
                    }

                    return Json(new { isSuccess = false, message = message }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Update / Clear Batches
        [HttpPost]
        public ActionResult UpdateBatch(int ptId, int pt_appId)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    ptId = BusinessLogicLayer.EMR.PatientTreatments.UpdateBatch(ptId, pt_appId);

                    if (ptId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee updated treatment batch no for the id= {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "Batch(es) Updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (ptId == -1)
                    {
                        return Json(new { isSuccess = false, invId = -1, message = "Batch(es) already Updated for the selected Treatment(s)!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while Updating Batch(es)!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult ClearBatch(int ptId, int pt_appId)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    ptId = BusinessLogicLayer.EMR.PatientTreatments.ClearBatch(ptId, pt_appId);

                    if (ptId > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Cleared treatment batch no for the id = {ptId}"
                        });

                        return Json(new { isSuccess = true, invId = ptId, message = "Batch Cleared Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while clearing batch!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, invId = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Miscellaenous Functions
        static string SpliceText(string text, int spliceLength)
        {
            // Implement your SpliceText logic here
            // This is just a placeholder implementation
            return text;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
        #endregion
    }
}