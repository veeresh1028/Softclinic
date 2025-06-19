using BusinessEntities;
using BusinessEntities.PriorRequests;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO.Compression;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using static BusinessEntities.PriorRequests.PriorRequestsMOH;
using System.Xml.Serialization;
using BusinessEntities.Appointment;
namespace ClinicSoft.Areas.PriorRequests.Controllers
{
    public class PriorRequestDownloadController : Controller
    {
        int PageId = (int)Pages.PriorRequests;

        [HttpGet]
        public ActionResult PriorRequestDownload()
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
        public ActionResult GetPriorReqBranches()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.PriorRequests.PriorRequest.GetBranchesForPriorReq();
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
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetFromOnline(PriorAppointmentSearch Authdata)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int log_empId = PageControl.getLoggedinId();

                if (Authdata.app_branch.ToString() != "")
                {
                    DataTable dt = new DataTable();
                    DataSet ds = BusinessLogicLayer.PriorRequests.PriorRequest.GetByID(Authdata.app_branch, log_empId);
                    dt = ds.Tables[0];

                    if ((dt.Rows[0]["set_user"].ToString() != "") || (dt.Rows[0]["set_pass"].ToString() != ""))
                    {
                        string e_prior_auth_error_message = "";
                        string e_prior_auth_found = "";
                        string e_prior_auth_file_name = "";
                        byte[] e_prior_auth_file = new byte[1000];

                        DateTime from_date = DateTime.Parse(Authdata.date_from.ToString());
                        DateTime to_date = DateTime.Parse(Authdata.date_to.ToString());

                        int found = 0;
                        if (dt.Rows[0]["set_city"].ToString() == "HAAD")
                        {
                            ae.gov.doh.shafafiya.Webservices e_prior_auth = new ae.gov.doh.shafafiya.Webservices();
                            found = e_prior_auth.SearchTransactions(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), 2, dt.Rows[0]["set_permit_no"].ToString(), null, 32, int.Parse(Authdata.s_status), null, from_date.ToString("dd/MM/yyyy"), to_date.ToString("dd/MM/yyyy"), -1, -1, out e_prior_auth_found, out e_prior_auth_error_message);
                        }
                        else
                        {
                            ae.eclaimlink.dhpo1.ValidateTransactions e_prior_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();
                            found = e_prior_auth.SearchTransactions(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), 2, dt.Rows[0]["set_permit_no"].ToString(), null, 32, int.Parse(Authdata.s_status), null, from_date.ToString("dd/MM/yyyy"), to_date.ToString("dd/MM/yyyy"), -1, -1, out e_prior_auth_found, out e_prior_auth_error_message);
                        }
                        if (found == 0 && !string.IsNullOrEmpty(e_prior_auth_found) && e_prior_auth_found != "<Files></Files>")
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(PriorRequestsMOH.Prior_request_response));
                            PriorRequestsMOH.Prior_request_response response;
                            List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList = new List<BusinessEntities.PriorRequests.PriorAuthXMLDetails>();
                            List<BusinessEntities.PriorRequests.PriorAuthXML> XMLList = new List<BusinessEntities.PriorRequests.PriorAuthXML>();

                            using (StringReader sr1 = new StringReader(e_prior_auth_found))
                            {
                                response = (PriorRequestsMOH.Prior_request_response)serializer.Deserialize(sr1);
                            }

                            foreach (var file in response.Files)
                            {
                                string fileId_ = file.FileID;
                                int result = 0;

                                if (dt.Rows[0]["set_city"].ToString() == "HAAD")
                                {
                                    ae.gov.doh.shafafiya.Webservices e_prior_auth = new ae.gov.doh.shafafiya.Webservices();
                                    result = e_prior_auth.DownloadTransactionFile(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), fileId_, out e_prior_auth_file_name, out e_prior_auth_file, out e_prior_auth_error_message);
                                }
                                else
                                {
                                    ae.eclaimlink.dhpo1.ValidateTransactions e_prior_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();
                                    result = e_prior_auth.DownloadTransactionFile(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), fileId_, out e_prior_auth_file_name, out e_prior_auth_file, out e_prior_auth_error_message);
                                }

                                if (result == 0)
                                {
                                    string fileExtension = Path.GetExtension(e_prior_auth_file_name).ToLower();

                                    string filePath = Server.MapPath("extracted\\" + e_prior_auth_file_name);

                                    if (fileExtension == ".zip")
                                    {
                                        using (FileStream destFile2 = System.IO.File.Open(Server.MapPath("authorizations\\" + e_prior_auth_file_name), FileMode.Create))
                                        {
                                            destFile2.Write(e_prior_auth_file, 0, e_prior_auth_file.Length);
                                        }

                                        Process_Authorizations(Authdata.s_status);
                                    }
                                    else if (fileExtension == ".xml")
                                    {
                                        if (!System.IO.File.Exists(filePath))
                                        {
                                            using (FileStream destFile2 = System.IO.File.Open(filePath, FileMode.Create))
                                            {
                                                destFile2.Write(e_prior_auth_file, 0, e_prior_auth_file.Length);
                                            }
                                        }

                                        BusinessEntities.PriorRequests.PriorAuthXML xml = new BusinessEntities.PriorRequests.PriorAuthXML();
                                        xml.XMLFile = e_prior_auth_file_name;
                                        xml.XMLData = filePath;
                                        xml.XML_type = Authdata.s_status.ToString();
                                        XMLList.Add(xml);

                                        if (System.IO.File.Exists(filePath))
                                        {
                                            string fileContent = System.IO.File.ReadAllText(filePath);
                                            XmlDocument doc = new XmlDocument();
                                            doc.LoadXml(fileContent);
                                            XmlNodeList AuthorizationNodes = doc.SelectNodes("/Prior.Authorization/Authorization");

                                            foreach (XmlNode AuthNode in AuthorizationNodes)
                                            {
                                                BusinessEntities.PriorRequests.PriorAuthXMLDetails px = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();

                                                px.pxd_SenderID = doc.SelectSingleNode("/Prior.Authorization/Header/SenderID")?.InnerText;
                                                px.pxd_ReceiverID = doc.SelectSingleNode("/Prior.Authorization/Header/ReceiverID")?.InnerText;
                                                px.pxd_TransactionDate = doc.SelectSingleNode("/Prior.Authorization/Header/TransactionDate")?.InnerText;
                                                px.pxd_ptcomments = doc.SelectSingleNode("/Prior.Authorization/Authorization/Activity/Observation/Value")?.InnerText;

                                                px.pxd_Result = AuthNode.SelectSingleNode("Result")?.InnerText;
                                                px.pxd_ID = AuthNode.SelectSingleNode("ID")?.InnerText;
                                                px.pxd_IDPayer = AuthNode.SelectSingleNode("IDPayer")?.InnerText;
                                                px.pxd_Start = AuthNode.SelectSingleNode("Start")?.InnerText;
                                                px.pxd_End = AuthNode.SelectSingleNode("End")?.InnerText;
                                                px.pxd_Comments = AuthNode.SelectSingleNode("Comments")?.InnerText;

                                                XmlNodeList activityNodes = AuthNode.SelectNodes("Activity");
                                                foreach (XmlNode activityNode in activityNodes)
                                                {
                                                    BusinessEntities.PriorRequests.PriorAuthXMLDetails pxActivity = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();
                                                    pxActivity.pxd_SenderID = px.pxd_SenderID;
                                                    pxActivity.pxd_ReceiverID = px.pxd_ReceiverID;
                                                    pxActivity.pxd_TransactionDate = px.pxd_TransactionDate;
                                                    pxActivity.pxd_Result = px.pxd_Result;
                                                    pxActivity.pxd_ID = px.pxd_ID;
                                                    pxActivity.pxd_IDPayer = px.pxd_IDPayer;
                                                    pxActivity.pxd_Start = px.pxd_Start;
                                                    pxActivity.pxd_End = px.pxd_End;
                                                    pxActivity.pxd_Comments = px.pxd_Comments;

                                                    pxActivity.pxd_ActID = activityNode.SelectSingleNode("ID")?.InnerText;
                                                    pxActivity.pxd_Atype = activityNode.SelectSingleNode("Type")?.InnerText;
                                                    pxActivity.pxd_ACode = activityNode.SelectSingleNode("Code")?.InnerText;
                                                    pxActivity.pxd_AQty = activityNode.SelectSingleNode("Quantity")?.InnerText;
                                                    pxActivity.pxd_Net = activityNode.SelectSingleNode("Net")?.InnerText;
                                                    pxActivity.pxd_Share = activityNode.SelectSingleNode("PatientShare")?.InnerText;
                                                    pxActivity.pxd_Apay = activityNode.SelectSingleNode("PaymentAmount")?.InnerText;
                                                    pxActivity.pxd_DenialCode = activityNode.SelectSingleNode("DenialCode")?.InnerText;
                                                    pxActivity.pxd_ptcomments = px.pxd_ptcomments;
                                                    pxActivity.pxd_xmlfile = filePath;
                                                    pxList.Add(pxActivity);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    return Json(new { isAuthorized = true, success = true, message = e_prior_auth_error_message }, JsonRequestBehavior.AllowGet);
                                }
                            }

                            int rslt = ADD_INTO_TABLE(pxList, XMLList, Authdata.s_status);
                            if (rslt > 0)
                            {
                                return Json(new { isAuthorized = true, success = true, message = "Downloaded Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isAuthorized = true, success = false, message = "Downloading Failed" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isAuthorized = true, success = false, message = "Downloading Failed" }, JsonRequestBehavior.AllowGet);
                        }

                        //if ((found == 0) && ((e_prior_auth_found != "") && (e_prior_auth_found != "<Files></Files>")))
                        //{
                        //    string fileId = "";
                        //    int count = 0;
                        //    XmlSerializer serializer = new XmlSerializer(typeof(PriorRequestsMOH.Prior_request_response));
                        //    PriorRequestsMOH.Prior_request_response response;

                        //    using (StringReader sr1 = new StringReader(e_prior_auth_found))
                        //    {
                        //        response = (PriorRequestsMOH.Prior_request_response)serializer.Deserialize(sr1);
                        //    }
                        //    List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList = new List<BusinessEntities.PriorRequests.PriorAuthXMLDetails>();
                        //    List<BusinessEntities.PriorRequests.PriorAuthXML> XMLList = new List<BusinessEntities.PriorRequests.PriorAuthXML>();
                        //    foreach (var file in response.Files)
                        //    {
                        //        string fileId_ = file.FileID;
                        //        int result = 0;
                        //        if (dt.Rows[0]["set_city"].ToString() == "HAAD")
                        //        {
                        //            ae.gov.doh.shafafiya.Webservices e_prior_auth = new ae.gov.doh.shafafiya.Webservices();
                        //            result = e_prior_auth.DownloadTransactionFile(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), fileId_, out e_prior_auth_file_name, out e_prior_auth_file, out e_prior_auth_error_message);
                        //        }
                        //        else
                        //        {
                        //            ae.eclaimlink.dhpo1.ValidateTransactions e_prior_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();
                        //            result = e_prior_auth.DownloadTransactionFile(dt.Rows[0]["set_user"].ToString(), dt.Rows[0]["set_pass"].ToString(), fileId_, out e_prior_auth_file_name, out e_prior_auth_file, out e_prior_auth_error_message);
                        //        }
                        //        if (result == 0)
                        //        {
                        //            if ((e_prior_auth_file_name.EndsWith(".ZIP") == true) || (e_prior_auth_file_name.EndsWith(".zip") == true))
                        //            {
                        //                FileStream destFile2 = System.IO.File.Open(Server.MapPath("authorizations\\" + e_prior_auth_file_name), FileMode.Create);
                        //                destFile2.Write(e_prior_auth_file, 0, e_prior_auth_file.Length);
                        //                destFile2.Close();

                        //                Process_Authorizations(Authdata.s_status);
                        //            }
                        //            else if ((e_prior_auth_file_name.EndsWith(".xml") == true) || (e_prior_auth_file_name.EndsWith(".XML") == true))
                        //            { 
                        //                if ((System.IO.File.Exists(Path.Combine(Server.MapPath("PriorRequests\\PriorRequestDownload\\extracted\\"), e_prior_auth_file_name))) == false)
                        //                {
                        //                    FileStream destFile2 = System.IO.File.Open(Server.MapPath("extracted\\" + e_prior_auth_file_name), FileMode.Create);
                        //                    destFile2.Write(e_prior_auth_file, 0, e_prior_auth_file.Length);
                        //                    destFile2.Close();
                        //                }

                        //                string extractedPath = Server.MapPath("~/PriorRequests/PriorRequestDownload/extracted/") + e_prior_auth_file_name;
                        //                BusinessEntities.PriorRequests.PriorAuthXML xml = new BusinessEntities.PriorRequests.PriorAuthXML();
                        //                xml.XMLFile = e_prior_auth_file_name;
                        //                xml.XMLData = extractedPath;
                        //                xml.XML_type = Authdata.s_status.ToString();
                        //                XMLList.Add(xml);

                        //                if (System.IO.File.Exists(extractedPath))
                        //                {
                        //                    string fileContent = System.IO.File.ReadAllText(extractedPath);

                        //                    XmlDocument doc = new XmlDocument();
                        //                    doc.LoadXml(fileContent);
                        //                    XmlNodeList AuthorizationNodes = doc.SelectNodes("/Prior.Authorization/Authorization");


                        //                    foreach (XmlNode AuthNode in AuthorizationNodes)
                        //                    {
                        //                        BusinessEntities.PriorRequests.PriorAuthXMLDetails px = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();

                        //                        px.pxd_SenderID = doc.SelectSingleNode("/Prior.Authorization/Header/SenderID")?.InnerText;
                        //                        px.pxd_ReceiverID = doc.SelectSingleNode("/Prior.Authorization/Header/ReceiverID")?.InnerText;
                        //                        px.pxd_TransactionDate = doc.SelectSingleNode("/Prior.Authorization/Header/TransactionDate")?.InnerText;

                        //                        px.pxd_Result = AuthNode.SelectSingleNode("Result")?.InnerText;
                        //                        px.pxd_ID = AuthNode.SelectSingleNode("ID")?.InnerText;
                        //                        px.pxd_IDPayer = AuthNode.SelectSingleNode("IDPayer")?.InnerText;
                        //                        px.pxd_Start = AuthNode.SelectSingleNode("Start")?.InnerText;
                        //                        px.pxd_End = AuthNode.SelectSingleNode("End")?.InnerText;
                        //                        px.pxd_Comments = AuthNode.SelectSingleNode("Comments")?.InnerText;
                        //                        //XmlNodeList activityNodes = doc.SelectNodes("/Prior.Authorization/Authorization/Activity");
                        //                        // Get Activity details
                        //                        XmlNodeList activityNodes = AuthNode.SelectNodes("Activity");
                        //                        foreach (XmlNode activityNode in activityNodes)
                        //                        {
                        //                            px = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();

                        //                            px.pxd_SenderID = doc.SelectSingleNode("/Prior.Authorization/Header/SenderID")?.InnerText;
                        //                            px.pxd_ReceiverID = doc.SelectSingleNode("/Prior.Authorization/Header/ReceiverID")?.InnerText;
                        //                            px.pxd_TransactionDate = doc.SelectSingleNode("/Prior.Authorization/Header/TransactionDate")?.InnerText;
                        //                            px.pxd_TransactionDate = doc.SelectSingleNode("/Prior.Authorization/Authorization/TransactionDate")?.InnerText;

                        //                            px.pxd_Result = AuthNode.SelectSingleNode("Result")?.InnerText;
                        //                            px.pxd_ID = AuthNode.SelectSingleNode("ID")?.InnerText;
                        //                            px.pxd_IDPayer = AuthNode.SelectSingleNode("IDPayer")?.InnerText;
                        //                            px.pxd_Start = AuthNode.SelectSingleNode("Start")?.InnerText;
                        //                            px.pxd_End = AuthNode.SelectSingleNode("End")?.InnerText;
                        //                            px.pxd_Comments = AuthNode.SelectSingleNode("Comments")?.InnerText;

                        //                            px.pxd_ActID = activityNode.SelectSingleNode("ID")?.InnerText;
                        //                            px.pxd_Atype = activityNode.SelectSingleNode("Type")?.InnerText;
                        //                            px.pxd_ACode = activityNode.SelectSingleNode("Code")?.InnerText;
                        //                            px.pxd_AQty = activityNode.SelectSingleNode("Quantity")?.InnerText;
                        //                            px.pxd_Net = activityNode.SelectSingleNode("Net")?.InnerText;
                        //                            px.pxd_Share = activityNode.SelectSingleNode("PatientShare")?.InnerText;
                        //                            px.pxd_Apay = activityNode.SelectSingleNode("PaymentAmount")?.InnerText;
                        //                            px.pxd_DenialCode = activityNode.SelectSingleNode("DenialCode")?.InnerText;
                        //                            XmlNode observationNode = activityNode.SelectSingleNode("Observation");
                        //                            px.pxd_ptcomments = observationNode?.SelectSingleNode("Value")?.InnerText;
                        //                            px.pxd_xmlfile = extractedPath;
                        //                            pxList.Add(px);
                        //                        }
                        //                    }
                        //                }                                        
                        //            }
                        //        }
                        //        else
                        //        {
                        //            return Json(new { isAuthorized = true, success = true, message = e_prior_auth_error_message }, JsonRequestBehavior.AllowGet);
                        //        }
                        //        count++;
                        //    }

                        //    ADD_INTO_TABLE(pxList, XMLList, Authdata.s_status);
                        //}
                        //else
                        //{
                        //    return Json(new { isAuthorized = true, success = true, message = "Downloading Failed" }, JsonRequestBehavior.AllowGet);
                        //}
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Please Enter HAAD/DHA User Name and Password in Setup!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = true, success = true, message = "Please Select Branch!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public void Process_Authorizations(string s_status)
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/authorizations/"));
            List<ListItem> files = new List<ListItem>();
            foreach (string filePath in filePaths)
            {
                files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                using (ZipArchive archive = ZipFile.OpenRead(filePath))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        {
                            DirectoryInfo di = new DirectoryInfo(Server.MapPath("PriorRequests\\PriorRequestDownload\\"));
                            FileInfo[] TXTFiles = di.GetFiles("*.xml");
                            if (System.IO.File.Exists(Path.Combine(Server.MapPath("PriorRequests\\PriorRequestDownload\\"), entry.FullName)) == false)
                            {
                                entry.ExtractToFile(Path.Combine(Server.MapPath("PriorRequests\\PriorRequestDownload\\"), entry.FullName));
                                if (BusinessLogicLayer.PriorRequests.PriorRequest.IS_ALREADY_INSERTED_IN_TABLE(entry.FullName) == false)
                                {
                                    string extractedPath = Server.MapPath("~/PriorRequests/PriorRequestDownload/extracted/") + entry.FullName;

                                    List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList = new List<BusinessEntities.PriorRequests.PriorAuthXMLDetails>();
                                    List<BusinessEntities.PriorRequests.PriorAuthXML> XMLList = new List<BusinessEntities.PriorRequests.PriorAuthXML>();
                                    if (System.IO.File.Exists(extractedPath))
                                    {
                                        string fileContent = System.IO.File.ReadAllText(extractedPath);
                                        BusinessEntities.PriorRequests.PriorAuthXML xml = new BusinessEntities.PriorRequests.PriorAuthXML();
                                        xml.XMLFile = entry.FullName;
                                        xml.XMLData = extractedPath;
                                        xml.XML_type = s_status;
                                        XMLList.Add(xml);

                                        XmlDocument doc = new XmlDocument();
                                        doc.LoadXml(fileContent);

                                        XmlNodeList AuthorizationNodes = doc.SelectNodes("/Prior.Authorization/Authorization");

                                        foreach (XmlNode AuthNode in AuthorizationNodes)
                                        {
                                            BusinessEntities.PriorRequests.PriorAuthXMLDetails px = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();

                                            px.pxd_SenderID = doc.SelectSingleNode("/Prior.Authorization/Header/SenderID")?.InnerText;
                                            px.pxd_ReceiverID = doc.SelectSingleNode("/Prior.Authorization/Header/ReceiverID")?.InnerText;
                                            px.pxd_TransactionDate = doc.SelectSingleNode("/Prior.Authorization/Header/TransactionDate")?.InnerText;

                                            px.pxd_Result = AuthNode.SelectSingleNode("Result")?.InnerText;
                                            px.pxd_ID = AuthNode.SelectSingleNode("ID")?.InnerText;
                                            px.pxd_IDPayer = AuthNode.SelectSingleNode("IDPayer")?.InnerText;
                                            px.pxd_Start = AuthNode.SelectSingleNode("Start")?.InnerText;
                                            px.pxd_End = AuthNode.SelectSingleNode("End")?.InnerText;
                                            px.pxd_Comments = AuthNode.SelectSingleNode("Comments")?.InnerText;

                                            // Get Activity details
                                            XmlNode activityNode = AuthNode.SelectSingleNode("Activity");
                                            if (activityNode != null)
                                            {
                                                px.pxd_ActID = activityNode.SelectSingleNode("ID")?.InnerText;
                                                px.pxd_Atype = activityNode.SelectSingleNode("Type")?.InnerText;
                                                px.pxd_ACode = activityNode.SelectSingleNode("Code")?.InnerText;
                                                px.pxd_AQty = activityNode.SelectSingleNode("Quantity")?.InnerText;
                                                px.pxd_Net = activityNode.SelectSingleNode("Net")?.InnerText;
                                                px.pxd_Share = activityNode.SelectSingleNode("PatientShare")?.InnerText;
                                                px.pxd_Apay = activityNode.SelectSingleNode("PaymentAmount")?.InnerText;
                                                px.pxd_DenialCode = activityNode.SelectSingleNode("DenialCode")?.InnerText;
                                            }

                                            px.pxd_xmlfile = extractedPath;

                                            pxList.Add(px);
                                        }
                                    }

                                    int paxId = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert(XMLList);
                                    if (paxId > 0)
                                    {
                                        int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
                                    }
                                }
                            }
                            else
                            {
                                if (BusinessLogicLayer.PriorRequests.PriorRequest.IS_ALREADY_INSERTED_IN_TABLE(entry.FullName) == false)
                                {
                                    string extractedPath = Server.MapPath("~/PriorRequests/PriorRequestDownload/extracted/") + entry.FullName;
                                    List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList = new List<BusinessEntities.PriorRequests.PriorAuthXMLDetails>();

                                    List<BusinessEntities.PriorRequests.PriorAuthXML> XMLList = new List<BusinessEntities.PriorRequests.PriorAuthXML>();
                                    if (System.IO.File.Exists(extractedPath))
                                    {
                                        string fileContent = System.IO.File.ReadAllText(extractedPath);

                                        XmlDocument doc = new XmlDocument();
                                        doc.LoadXml(fileContent);

                                        XmlNodeList AuthorizationNodes = doc.SelectNodes("/Prior.Authorization/Authorization");

                                        foreach (XmlNode AuthNode in AuthorizationNodes)
                                        {
                                            BusinessEntities.PriorRequests.PriorAuthXMLDetails px = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();
                                            BusinessEntities.PriorRequests.PriorAuthXML xml = new BusinessEntities.PriorRequests.PriorAuthXML();
                                            xml.XMLFile = entry.FullName;
                                            xml.XMLData = extractedPath;
                                            xml.XML_type = s_status;
                                            XMLList.Add(xml);
                                            px.pxd_SenderID = doc.SelectSingleNode("/Prior.Authorization/Header/SenderID")?.InnerText;
                                            px.pxd_ReceiverID = doc.SelectSingleNode("/Prior.Authorization/Header/ReceiverID")?.InnerText;
                                            px.pxd_TransactionDate = doc.SelectSingleNode("/Prior.Authorization/Header/TransactionDate")?.InnerText;

                                            px.pxd_Result = AuthNode.SelectSingleNode("Result")?.InnerText;
                                            px.pxd_ID = AuthNode.SelectSingleNode("ID")?.InnerText;
                                            px.pxd_IDPayer = AuthNode.SelectSingleNode("IDPayer")?.InnerText;
                                            px.pxd_Start = AuthNode.SelectSingleNode("Start")?.InnerText;
                                            px.pxd_End = AuthNode.SelectSingleNode("End")?.InnerText;
                                            px.pxd_Comments = AuthNode.SelectSingleNode("Comments")?.InnerText;

                                            // Get Activity details
                                            XmlNode activityNode = AuthNode.SelectSingleNode("Activity");
                                            if (activityNode != null)
                                            {
                                                px.pxd_ActID = activityNode.SelectSingleNode("ID")?.InnerText;
                                                px.pxd_Atype = activityNode.SelectSingleNode("Type")?.InnerText;
                                                px.pxd_ACode = activityNode.SelectSingleNode("Code")?.InnerText;
                                                px.pxd_AQty = activityNode.SelectSingleNode("Quantity")?.InnerText;
                                                px.pxd_Net = activityNode.SelectSingleNode("Net")?.InnerText;
                                                px.pxd_Share = activityNode.SelectSingleNode("PatientShare")?.InnerText;
                                                px.pxd_Apay = activityNode.SelectSingleNode("PaymentAmount")?.InnerText;
                                                px.pxd_DenialCode = activityNode.SelectSingleNode("DenialCode")?.InnerText;
                                            }

                                            px.pxd_xmlfile = extractedPath;

                                            pxList.Add(px);
                                        }
                                    }
                                    int paxId = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert(XMLList);
                                    if (paxId > 0)
                                    {
                                        int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public int ADD_INTO_TABLE(List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList, List<BusinessEntities.PriorRequests.PriorAuthXML> xmlList, string s_status)
        {
            int paxId = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert(xmlList);
            int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
            if (new_Id > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        [HttpGet]
        public JsonResult GetPriorReqDownloadList(PriorAppointmentSearch Authdata)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {

                    List<PriorReqDownloadList> PriorReqDownload = BusinessLogicLayer.PriorRequests.PriorRequest.GetPriorReqDownloadList(Authdata);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Downloaded Prior Authorizations!"
                    });

                    var jsonResult = Json(PriorReqDownload, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
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

        [HttpGet]
        public JsonResult GetFromOnlineMOH(PriorAppointmentSearch Authdata)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int log_empId = PageControl.getLoggedinId();

                if (Authdata.app_branch.ToString() != "")
                {
                    DataTable dt = new DataTable();
                    DataSet ds = BusinessLogicLayer.PriorRequests.PriorRequest.GetByID(Authdata.app_branch, log_empId);
                    dt = ds.Tables[0];

                    if ((dt.Rows[0]["set_user"].ToString() != "") || (dt.Rows[0]["set_pass"].ToString() != ""))
                    {
                        DateTime from_date = DateTime.Parse(Authdata.date_from.ToString());
                        DateTime to_date = DateTime.Parse(Authdata.date_to.ToString());
                        var s_status = Authdata.s_status.ToString();

                        string FacilityId = ConfigurationManager.AppSettings["FacilityId"].ToString();
                        string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
                        string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
                        string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString();
                        var reqUrl = "";
                        if (s_status == "2")
                        {
                            reqUrl = strApiUrl + "Authorization/Search?direction=0&fromDate=" + from_date.ToString("dd/MM/yyyy HH:mm") + "&toDate=" + to_date.ToString("dd/MM/yyyy HH:mm") + "&downloaded=1";
                        }
                        else
                        {
                            reqUrl = strApiUrl + "Authorization/GetNew";
                        }

                        //var reqUrl = strApiUrl + "Authorization/GetNew";
                        var httpWebRequestQR = (HttpWebRequest)WebRequest.Create(reqUrl);
                        httpWebRequestQR.ContentType = "application/json";
                        httpWebRequestQR.Method = "GET";
                        httpWebRequestQR.Headers.Add("Username", strUsername);
                        httpWebRequestQR.Headers.Add("Password", strPassword);
                        var httpResponseQR = (HttpWebResponse)httpWebRequestQR.GetResponse();
                        using (var streamReader = new StreamReader(httpResponseQR.GetResponseStream()))
                        {
                            var resultQR = streamReader.ReadToEnd();
                            string jsonStringsign = resultQR;
                            List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList = new List<BusinessEntities.PriorRequests.PriorAuthXMLDetails>();
                            PriorAuthorizationGetNewResponse.PriorAuthorization_GetNew result = JsonConvert.DeserializeObject<PriorAuthorizationGetNewResponse.PriorAuthorization_GetNew>(jsonStringsign);
                            if (result.StatusCode == "200" || result.StatusCode == "201")
                            {
                                foreach (var entities in result.Entities)
                                {
                                    if (!string.IsNullOrEmpty(entities.ID.ToString()))
                                    {
                                        //string file_name = "PA-" + FacilityId + "-" + entities.ID.ToString() + DateTime.Now.ToString("ddMMyyyyHHmmssfff") + ".json";
                                        string file_name = "PA-" + FacilityId + "-" + entities.ID.ToString() + ".json";
                                        var reqAuthUrl = "";
                                        if (s_status == "2")
                                        {
                                            reqAuthUrl = strApiUrl + "Authorization/View?direction=0&id=" + entities.ID.ToString();
                                        }
                                        else
                                        {
                                            reqAuthUrl = strApiUrl + "Authorization/View?id=" + entities.ID.ToString();
                                        }

                                        // var reqAuthUrl = strApiUrl + "Authorization/View?id=" + entities.ID.ToString();
                                        var httpWebRequestAuth = (HttpWebRequest)WebRequest.Create(reqAuthUrl);
                                        httpWebRequestAuth.ContentType = "application/json";
                                        httpWebRequestAuth.Method = "GET";
                                        httpWebRequestAuth.Headers.Add("Username", strUsername);
                                        httpWebRequestAuth.Headers.Add("Password", strPassword);
                                        var httpResponseAuth = (HttpWebResponse)httpWebRequestAuth.GetResponse();
                                        using (var streamAuthReader = new StreamReader(httpResponseAuth.GetResponseStream()))
                                        {
                                            var resultAuth = streamAuthReader.ReadToEnd();
                                            string jsonStringAuthorization = resultAuth;

                                            PriorAuthorizationViewResponse.PriorAuthorization_ViewResponse response = JsonConvert.DeserializeObject<PriorAuthorizationViewResponse.PriorAuthorization_ViewResponse>(jsonStringAuthorization);
                                            if (response.StatusCode.ToString() == "200" || response.StatusCode.ToString() == "201")
                                            {
                                                Response.AppendHeader("'Content-Disposition'", "'attachment; filename='" + file_name + "'");
                                                //Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
                                                string path = Server.MapPath("~/PriorRequests/PriorRequestDownload/extracted");
                                                Path.Combine(path, file_name);
                                                System.IO.File.WriteAllText(Path.Combine(path, file_name), jsonStringAuthorization);

                                                string filePath = Server.MapPath("~/PriorRequests/PriorRequestDownload/extracted\\" + file_name);


                                                string ActivityId = string.Empty;
                                                string ActivityType = string.Empty;
                                                string ActivityQuantity = string.Empty;
                                                string ActivityCode = string.Empty;
                                                string ActivityPaymentAmount = string.Empty;
                                                string Net = string.Empty;
                                                string PatientShare = string.Empty;
                                                string DenialCode = string.Empty;
                                                string strComment = string.Empty;
                                                string authResult = string.Empty;
                                                string authId = string.Empty;
                                                string authIdpayer = string.Empty;
                                                string start = string.Empty;
                                                string end = string.Empty;
                                                if (!string.IsNullOrEmpty(response.Entity.Authorization.DenialCode))
                                                {
                                                    DenialCode = response.Entity.Authorization.DenialCode;
                                                }
                                                if (response.Entity.Authorization.Activity.Count > 0)
                                                {
                                                    foreach (var Activity in response.Entity.Authorization.Activity)
                                                    {
                                                        if (!string.IsNullOrEmpty(Activity.ID))
                                                        {
                                                            ActivityId = Activity.ID;
                                                        }
                                                        if (!string.IsNullOrEmpty(Activity.Type))
                                                        {
                                                            ActivityType = Activity.Type;
                                                        }
                                                        if (!string.IsNullOrEmpty(Convert.ToString(Activity.Quantity)))
                                                        {
                                                            ActivityQuantity = Convert.ToString(Activity.Quantity);
                                                        }
                                                        if (!string.IsNullOrEmpty(Activity.Code))
                                                        {
                                                            ActivityCode = Activity.Code;
                                                        }
                                                        if (!string.IsNullOrEmpty(Convert.ToString(Activity.Net)))
                                                        {
                                                            Net = Convert.ToString(Activity.Net);
                                                        }
                                                        if (!string.IsNullOrEmpty(Convert.ToString(Activity.PatientShare)))
                                                        {
                                                            PatientShare = Convert.ToString(Activity.PatientShare);
                                                        }
                                                        if (!string.IsNullOrEmpty(Convert.ToString(Activity.PaymentAmount)))
                                                        {
                                                            ActivityPaymentAmount = Convert.ToString(Activity.PaymentAmount);
                                                        }
                                                        if (!string.IsNullOrEmpty(Activity.DenialCode))
                                                        {
                                                            DenialCode = Activity.DenialCode;
                                                        }
                                                        if (!string.IsNullOrEmpty(response.Entity.Authorization.ID))
                                                        {
                                                            authId = response.Entity.Authorization.ID;
                                                        }
                                                        if (!string.IsNullOrEmpty(response.Entity.Authorization.IDPayer))
                                                        {
                                                            authIdpayer = response.Entity.Authorization.IDPayer;
                                                        }
                                                        if (!string.IsNullOrEmpty(response.Entity.Authorization.Start))
                                                        {
                                                            start = response.Entity.Authorization.Start;
                                                        }
                                                        if (!string.IsNullOrEmpty(response.Entity.Authorization.End))
                                                        {
                                                            end = response.Entity.Authorization.End;
                                                        }
                                                        if (!string.IsNullOrEmpty(response.Entity.Authorization.Comments))
                                                        {
                                                            strComment = response.Entity.Authorization.Comments.Replace("'", "\"");
                                                        }
                                                        else
                                                        {
                                                            strComment = "";
                                                        }

                                                        if (!string.IsNullOrEmpty(response.Entity.Authorization.Result))
                                                        {
                                                            authResult = response.Entity.Authorization.Result.Replace("'", "\"");
                                                        }
                                                        else
                                                        {
                                                            authResult = "";
                                                        }

                                                        BusinessEntities.PriorRequests.PriorAuthXMLDetails pxActivity = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();
                                                        pxActivity.pxd_SenderID = response.Entity.Header.SenderID;
                                                        pxActivity.pxd_ReceiverID = response.Entity.Header.ReceiverID;
                                                        pxActivity.pxd_TransactionDate = response.Entity.Header.TransactionDate;
                                                        pxActivity.pxd_Result = authResult;
                                                        pxActivity.pxd_ID = authId;
                                                        pxActivity.pxd_IDPayer = authIdpayer;
                                                        pxActivity.pxd_Start = start;
                                                        pxActivity.pxd_End = end;
                                                        pxActivity.pxd_Comments = strComment;

                                                        pxActivity.pxd_ActID = ActivityId;
                                                        pxActivity.pxd_Atype = ActivityType;
                                                        pxActivity.pxd_ACode = ActivityCode;
                                                        pxActivity.pxd_AQty = ActivityQuantity;
                                                        pxActivity.pxd_Net = Net;
                                                        pxActivity.pxd_Share = PatientShare;
                                                        pxActivity.pxd_Apay = ActivityPaymentAmount;
                                                        pxActivity.pxd_DenialCode = DenialCode;
                                                        pxActivity.pxd_ptcomments = "";
                                                        pxActivity.pxd_xmlfile = file_name;
                                                        pxList.Add(pxActivity);
                                                        List<BusinessEntities.PriorRequests.PriorAuthXML> XMLList = new List<BusinessEntities.PriorRequests.PriorAuthXML>();
                                                        BusinessEntities.PriorRequests.PriorAuthXML xml = new BusinessEntities.PriorRequests.PriorAuthXML();
                                                        xml.XMLFile = file_name;
                                                        xml.XMLData = filePath;
                                                        xml.XML_type = Authdata.s_status.ToString();
                                                        XMLList.Add(xml);

                                                        int paxId = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert(XMLList);
                                                        int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
                                                    }
                                                }
                                                else
                                                {
                                                    BusinessEntities.PriorRequests.PriorAuthXMLDetails pxActivity = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();
                                                    pxActivity.pxd_SenderID = response.Entity.Header.SenderID;
                                                    pxActivity.pxd_ReceiverID = response.Entity.Header.ReceiverID;
                                                    pxActivity.pxd_TransactionDate = response.Entity.Header.TransactionDate;
                                                    pxActivity.pxd_Result = authResult;
                                                    pxActivity.pxd_ID = authId;
                                                    pxActivity.pxd_IDPayer = authIdpayer;
                                                    pxActivity.pxd_Start = start;
                                                    pxActivity.pxd_End = end;
                                                    pxActivity.pxd_Comments = strComment;

                                                    pxActivity.pxd_ActID = ActivityId;
                                                    pxActivity.pxd_Atype = ActivityType;
                                                    pxActivity.pxd_ACode = ActivityCode;
                                                    pxActivity.pxd_AQty = ActivityQuantity;
                                                    pxActivity.pxd_Net = Net;
                                                    pxActivity.pxd_Share = PatientShare;
                                                    pxActivity.pxd_Apay = ActivityPaymentAmount;
                                                    pxActivity.pxd_DenialCode = DenialCode;
                                                    pxActivity.pxd_ptcomments = "";
                                                    pxActivity.pxd_xmlfile = file_name;
                                                    pxList.Add(pxActivity);
                                                    List<BusinessEntities.PriorRequests.PriorAuthXML> XMLList = new List<BusinessEntities.PriorRequests.PriorAuthXML>();
                                                    BusinessEntities.PriorRequests.PriorAuthXML xml = new BusinessEntities.PriorRequests.PriorAuthXML();
                                                    xml.XMLFile = file_name;
                                                    xml.XMLData = filePath;
                                                    xml.XML_type = Authdata.s_status.ToString();
                                                    XMLList.Add(xml);

                                                    int paxId = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Insert(XMLList);
                                                    int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
                                                    if (new_Id > 0)
                                                    {
                                                        int rtnvalue = BusinessLogicLayer.PriorRequests.PriorRequest.UPDATE_INS_ELIGIBILITY_DATA_IN_APPOINTMENT(file_name, PageControl.getLoggedinId());
                                                    }
                                                }

                                            }

                                        }

                                    }
                                    if (s_status == "1")
                                    {
                                        using (WebClient webClient = new WebClient())
                                        {
                                            webClient.BaseAddress = strApiUrl + "Authorization/SetDownloaded?id=" + entities.ID.ToString();
                                            var url = strApiUrl + "Authorization/SetDownloaded?id=" + entities.ID.ToString();
                                            webClient.Headers.Add("Username", strUsername);
                                            webClient.Headers.Add("Password", strPassword);
                                            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                                            string data = string.Empty;
                                            var response = webClient.UploadString(url, data);
                                            PriorAuthorizationSetDownloadedResponse.PriorAuthorization_SetDownloaded_Response PRresponse = JsonConvert.DeserializeObject<PriorAuthorizationSetDownloadedResponse.PriorAuthorization_SetDownloaded_Response>(response);

                                            if (PRresponse.StatusCode == "201" || PRresponse.StatusCode == "200")
                                            {
                                                return Json(new { isAuthorized = true, success = true, message = PRresponse.Message }, JsonRequestBehavior.AllowGet);

                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                return Json(new { isAuthorized = true, success = false, message = "Error ,Please check" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Please Enter MOH User Name and Password in Setup!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = true, success = true, message = "Please Select Branch!" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { isAuthorized = true, success = true, message = "Successfully Downloaded" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //[HttpGet]
        //public JsonResult GetFromOnlineMOH(PriorAppointmentSearch Authdata)
        //{
        //    int Action = (int)Actions.Read;

        //    try
        //    {
        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            int log_empId = PageControl.getLoggedinId();

        //            if (Authdata.app_branch.ToString() != "")
        //            {
        //                DataTable dt = new DataTable();
        //                DataSet ds = BusinessLogicLayer.PriorRequests.PriorRequest.GetByID(Authdata.app_branch, log_empId);
        //                dt = ds.Tables[0];

        //                if ((dt.Rows[0]["set_user"].ToString() != "") || (dt.Rows[0]["set_pass"].ToString() != ""))
        //                {
        //                    DateTime from_date = DateTime.Parse(Authdata.date_from.ToString());
        //                    DateTime to_date = DateTime.Parse(Authdata.date_to.ToString());

        //                    string FacilityId = ConfigurationManager.AppSettings["FacilityId"].ToString();
        //                    string strUsername = ConfigurationManager.AppSettings["RiayatiPOUsername"].ToString();
        //                    string strPassword = ConfigurationManager.AppSettings["RiayatiPOPassword"].ToString();
        //                    string strApiUrl = ConfigurationManager.AppSettings["RiayatiAPIUrl"].ToString();

        //                    var reqUrl = strApiUrl + "Authorization/GetNew";
        //                    var httpWebRequestQR = (HttpWebRequest)WebRequest.Create(reqUrl);
        //                    httpWebRequestQR.ContentType = "application/json";
        //                    httpWebRequestQR.Method = "GET";
        //                    httpWebRequestQR.Headers.Add("Username", strUsername);
        //                    httpWebRequestQR.Headers.Add("Password", strPassword);
        //                    var httpResponseQR = (HttpWebResponse)httpWebRequestQR.GetResponse();
        //                    using (var streamReader = new StreamReader(httpResponseQR.GetResponseStream()))
        //                    {
        //                        var resultQR = streamReader.ReadToEnd();
        //                        string jsonStringsign = resultQR;
        //                        List<BusinessEntities.PriorRequests.PriorAuthXMLDetails> pxList = new List<BusinessEntities.PriorRequests.PriorAuthXMLDetails>();
        //                        PriorAuthorizationGetNewResponse.PriorAuthorization_GetNew result = JsonConvert.DeserializeObject<PriorAuthorizationGetNewResponse.PriorAuthorization_GetNew>(jsonStringsign);
        //                        if (result.StatusCode == "200")
        //                        {
        //                            foreach (var entities in result.Entities)
        //                            {
        //                                if (!string.IsNullOrEmpty(entities.ID.ToString()))
        //                                {
        //                                    string file_name = "PA-" + FacilityId + "-" + entities.ID.ToString() + DateTime.Now.ToString("ddMMyyyyHHmmssfff") + ".json";

        //                                    var reqAuthUrl = strApiUrl + "Authorization/View?id=" + entities.ID.ToString();
        //                                    var httpWebRequestAuth = (HttpWebRequest)WebRequest.Create(reqAuthUrl);
        //                                    httpWebRequestAuth.ContentType = "application/json";
        //                                    httpWebRequestAuth.Method = "GET";
        //                                    httpWebRequestAuth.Headers.Add("Username", strUsername);
        //                                    httpWebRequestAuth.Headers.Add("Password", strPassword);
        //                                    var httpResponseAuth = (HttpWebResponse)httpWebRequestAuth.GetResponse();
        //                                    using (var streamAuthReader = new StreamReader(httpResponseAuth.GetResponseStream()))
        //                                    {
        //                                        var resultAuth = streamAuthReader.ReadToEnd();
        //                                        string jsonStringAuthorization = resultAuth;

        //                                        PriorAuthorizationViewResponse.PriorAuthorization_ViewResponse response = JsonConvert.DeserializeObject<PriorAuthorizationViewResponse.PriorAuthorization_ViewResponse>(jsonStringAuthorization);
        //                                        if (response.StatusCode.ToString() == "200")
        //                                        {
        //                                            Response.AppendHeader("'Content-Disposition'", "'attachment; filename='" + file_name + "'");
        //                                            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + file_name);
        //                                            string path = Server.MapPath("~/PriorRequests/PriorRequestDownload/");
        //                                            Path.Combine(path, file_name);
        //                                            System.IO.File.WriteAllText(Path.Combine(path, file_name), jsonStringAuthorization);


        //                                            string ActivityId = string.Empty;
        //                                            string ActivityType = string.Empty;
        //                                            string ActivityQuantity = string.Empty;
        //                                            string ActivityCode = string.Empty;
        //                                            string ActivityPaymentAmount = string.Empty;
        //                                            string Net = string.Empty;
        //                                            string PatientShare = string.Empty;
        //                                            string DenialCode = string.Empty;
        //                                            string strComment = string.Empty;
        //                                            string authResult = string.Empty;
        //                                            string authId = string.Empty;
        //                                            string authIdpayer = string.Empty;
        //                                            string start = string.Empty;
        //                                            string end = string.Empty;
        //                                            if (!string.IsNullOrEmpty(response.Entity.Authorization.DenialCode))
        //                                            {
        //                                                DenialCode = response.Entity.Authorization.DenialCode;
        //                                            }
        //                                            if (response.Entity.Authorization.Activity.Count > 0)
        //                                            {
        //                                                foreach (var Activity in response.Entity.Authorization.Activity)
        //                                                {
        //                                                    if (!string.IsNullOrEmpty(Activity.ID))
        //                                                    {
        //                                                        ActivityId = Activity.ID;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Activity.Type))
        //                                                    {
        //                                                        ActivityType = Activity.Type;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Convert.ToString(Activity.Quantity)))
        //                                                    {
        //                                                        ActivityQuantity = Convert.ToString(Activity.Quantity);
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Activity.Code))
        //                                                    {
        //                                                        ActivityCode = Activity.Code;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Convert.ToString(Activity.Net)))
        //                                                    {
        //                                                        Net = Convert.ToString(Activity.Net);
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Convert.ToString(Activity.PatientShare)))
        //                                                    {
        //                                                        PatientShare = Convert.ToString(Activity.PatientShare);
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Convert.ToString(Activity.PaymentAmount)))
        //                                                    {
        //                                                        ActivityPaymentAmount = Convert.ToString(Activity.PaymentAmount);
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(Activity.DenialCode))
        //                                                    {
        //                                                        DenialCode = Activity.DenialCode;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(response.Entity.Authorization.ID))
        //                                                    {
        //                                                        authId = response.Entity.Authorization.ID;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(response.Entity.Authorization.IDPayer))
        //                                                    {
        //                                                        authIdpayer = response.Entity.Authorization.IDPayer;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(response.Entity.Authorization.Start))
        //                                                    {
        //                                                        start = response.Entity.Authorization.Start;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(response.Entity.Authorization.End))
        //                                                    {
        //                                                        end = response.Entity.Authorization.End;
        //                                                    }
        //                                                    if (!string.IsNullOrEmpty(response.Entity.Authorization.Comments))
        //                                                    {
        //                                                        strComment = response.Entity.Authorization.Comments.Replace("'", "\"");
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        strComment = "";
        //                                                    }

        //                                                    if (!string.IsNullOrEmpty(response.Entity.Authorization.Result))
        //                                                    {
        //                                                        authResult = response.Entity.Authorization.Result.Replace("'", "\"");
        //                                                    }
        //                                                    else
        //                                                    {
        //                                                        authResult = "";
        //                                                    }

        //                                                    BusinessEntities.PriorRequests.PriorAuthXMLDetails pxActivity = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();
        //                                                    pxActivity.pxd_SenderID = response.Entity.Header.SenderID;
        //                                                    pxActivity.pxd_ReceiverID = response.Entity.Header.ReceiverID;
        //                                                    pxActivity.pxd_TransactionDate = response.Entity.Header.TransactionDate;
        //                                                    pxActivity.pxd_Result = authResult;
        //                                                    pxActivity.pxd_ID = authId;
        //                                                    pxActivity.pxd_IDPayer = authIdpayer;
        //                                                    pxActivity.pxd_Start = start;
        //                                                    pxActivity.pxd_End = end;
        //                                                    pxActivity.pxd_Comments = strComment;

        //                                                    pxActivity.pxd_ActID = ActivityId;
        //                                                    pxActivity.pxd_Atype = ActivityType;
        //                                                    pxActivity.pxd_ACode = ActivityCode;
        //                                                    pxActivity.pxd_AQty = ActivityQuantity;
        //                                                    pxActivity.pxd_Net = Net;
        //                                                    pxActivity.pxd_Share = PatientShare;
        //                                                    pxActivity.pxd_Apay = ActivityPaymentAmount;
        //                                                    pxActivity.pxd_DenialCode = DenialCode;
        //                                                    pxActivity.pxd_ptcomments = "";
        //                                                    pxActivity.pxd_xmlfile = file_name;
        //                                                    pxList.Add(pxActivity);
        //                                                    int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                BusinessEntities.PriorRequests.PriorAuthXMLDetails pxActivity = new BusinessEntities.PriorRequests.PriorAuthXMLDetails();
        //                                                pxActivity.pxd_SenderID = response.Entity.Header.SenderID;
        //                                                pxActivity.pxd_ReceiverID = response.Entity.Header.ReceiverID;
        //                                                pxActivity.pxd_TransactionDate = response.Entity.Header.TransactionDate;
        //                                                pxActivity.pxd_Result = authResult;
        //                                                pxActivity.pxd_ID = authId;
        //                                                pxActivity.pxd_IDPayer = authIdpayer;
        //                                                pxActivity.pxd_Start = start;
        //                                                pxActivity.pxd_End = end;
        //                                                pxActivity.pxd_Comments = strComment;

        //                                                pxActivity.pxd_ActID = ActivityId;
        //                                                pxActivity.pxd_Atype = ActivityType;
        //                                                pxActivity.pxd_ACode = ActivityCode;
        //                                                pxActivity.pxd_AQty = ActivityQuantity;
        //                                                pxActivity.pxd_Net = Net;
        //                                                pxActivity.pxd_Share = PatientShare;
        //                                                pxActivity.pxd_Apay = ActivityPaymentAmount;
        //                                                pxActivity.pxd_DenialCode = DenialCode;
        //                                                pxActivity.pxd_ptcomments = "";
        //                                                pxActivity.pxd_xmlfile = file_name;
        //                                                pxList.Add(pxActivity);
        //                                                int new_Id = BusinessLogicLayer.PriorRequests.PriorRequest.PRIOR_AUTH_XML_Details_Insert(pxList, PageControl.getLoggedinId());
        //                                                if (new_Id > 0)
        //                                                {
        //                                                    int rtnvalue = BusinessLogicLayer.PriorRequests.PriorRequest.UPDATE_INS_ELIGIBILITY_DATA_IN_APPOINTMENT(file_name, PageControl.getLoggedinId());
        //                                                }
        //                                            }

        //                                        }

        //                                    }

        //                                }

        //                                using (WebClient webClient = new WebClient())
        //                                {
        //                                    webClient.BaseAddress = strApiUrl + "Authorization/SetDownloaded?id=" + entities.ID.ToString();
        //                                    var url = strApiUrl + "Authorization/SetDownloaded?id=" + entities.ID.ToString();
        //                                    webClient.Headers.Add("Username", strUsername);
        //                                    webClient.Headers.Add("Password", strPassword);
        //                                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
        //                                    string data = string.Empty;
        //                                    var response = webClient.UploadString(url, data);
        //                                    PriorAuthorizationSetDownloadedResponse.PriorAuthorization_SetDownloaded_Response PRresponse = JsonConvert.DeserializeObject<PriorAuthorizationSetDownloadedResponse.PriorAuthorization_SetDownloaded_Response>(response);

        //                                    if (PRresponse.StatusCode == "201")
        //                                    {
        //                                        return Json(new { isAuthorized = true, success = true, message = PRresponse.Message }, JsonRequestBehavior.AllowGet);

        //                                    }
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            return Json(new { isAuthorized = true, success = false, message = "Error ,Please check" }, JsonRequestBehavior.AllowGet);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    return Json(new { isAuthorized = true, success = true, message = "Please Enter MOH User Name and Password in Setup!" }, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                return Json(new { isAuthorized = true, success = true, message = "Please Select Branch!" }, JsonRequestBehavior.AllowGet);
        //            }

        //            return Json(new { isAuthorized = true, success = true, message = "Successfully Downloaded" }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}