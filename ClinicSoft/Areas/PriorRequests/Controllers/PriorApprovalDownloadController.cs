using BusinessEntities.PriorRequests;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing.Drawing2D;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace ClinicSoft.Areas.PriorRequests.Controllers
{
    public class PriorApprovalDownloadController : Controller
    {
        int PageId = (int)Pages.PriorRequests;
        // GET: PriorRequests/PriorApprovalDownload
        public ActionResult PriorApprovalDownload()
        {
            return View();
        }

        [HttpGet]
        public JsonResult DownloadAndSearchFromOnline(PriorApprovalDownloadSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    int log_empId = PageControl.getLoggedinId();

                    if (data.app_branch.ToString() != "")
                    {
                        int branchId = 0;
                        int.TryParse(data.app_branch, out branchId);
                        DataTable dt = new DataTable();
                        DataSet ds = BusinessLogicLayer.PriorRequests.PriorRequest.GetByID(branchId, log_empId);
                        dt = ds.Tables[0];

                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (data.search_type.Contains("DHA"))
                                {
                                    DownloadOnlineDHA(dt.Rows[0], data);
                                }

                                //if (data.search_type.Contains("MOH"))
                                //{

                                //}
                            }
                        }



                        //List<PriorReqDownloadList> PriorReqDownload = BusinessLogicLayer.PriorRequests.PriorRequest.GetPriorReqDownloadList(Authdata);
                        //BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        //{
                        //    log_by = PageControl.getLoggedinId(),
                        //    log_desc = "Employee Searched Downloaded Prior Authorizations!"
                        //});

                        var jsonResult = Json("", JsonRequestBehavior.AllowGet);

                        jsonResult.MaxJsonLength = int.MaxValue;

                        return jsonResult;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void DownloadOnlineDHA(DataRow row, PriorApprovalDownloadSearch search)
        {
            string e_prior_auth_error_message = "";
            string e_prior_auth_found = "";
            string e_prior_auth_file_name = "";
            byte[] e_prior_auth_file = new byte[1000];

            DateTime from_date = DateTime.Parse(search.date_from.ToString());
            DateTime to_date = DateTime.Parse(search.date_to.ToString()).AddDays(1).AddSeconds(-1);

            int found = 0;
            if (row["set_city"].ToString() == "HAAD")
            {
                ae.gov.doh.shafafiya.Webservices e_prior_auth = new ae.gov.doh.shafafiya.Webservices();
                found = e_prior_auth.SearchTransactions(row["set_user"].ToString(), row["set_pass"].ToString(), 2,
                    row["set_permit_no"].ToString(), null, 32, int.Parse(search.s_status), null,
                    from_date.ToString("dd/MM/yyyy"), to_date.ToString("dd/MM/yyyy"), -1, -1,
                    out e_prior_auth_found, out e_prior_auth_error_message);
            }
            else
            {
                ae.eclaimlink.dhpo1.ValidateTransactions e_prior_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();
                found = e_prior_auth.SearchTransactions(row["set_user"].ToString(), row["set_pass"].ToString(), 2,
                    row["set_permit_no"].ToString(), null, 32, int.Parse(search.s_status), null,
                    from_date.ToString("dd/MM/yyyy"), to_date.ToString("dd/MM/yyyy"), -1, -1,
                    out e_prior_auth_found, out e_prior_auth_error_message);
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

                    if (row["set_city"].ToString() == "HAAD")
                    {
                        ae.gov.doh.shafafiya.Webservices e_prior_auth = new ae.gov.doh.shafafiya.Webservices();
                        result = e_prior_auth.DownloadTransactionFile(row["set_user"].ToString(), row["set_pass"].ToString(),
                            fileId_, out e_prior_auth_file_name, out e_prior_auth_file, out e_prior_auth_error_message);
                    }
                    else
                    {
                        ae.eclaimlink.dhpo1.ValidateTransactions e_prior_auth = new ae.eclaimlink.dhpo1.ValidateTransactions();
                        result = e_prior_auth.DownloadTransactionFile(row["set_user"].ToString(), row["set_pass"].ToString(),
                            fileId_, out e_prior_auth_file_name, out e_prior_auth_file, out e_prior_auth_error_message);
                    }

                    if (result == 0)
                    {
                        string fileExtension = Path.GetExtension(e_prior_auth_file_name).ToLower();
                        string filePath = Server.MapPath("~/PriorRequests");
                        string filePath_download = Path.Combine(filePath, "PriorRequestDownload");
                        string filePath_type = Path.Combine(filePath_download, "DHA");

                        if (!Directory.Exists(filePath))
                        {

                        }
                        else
                        {

                        }

                       
                    }
                }
            }
        }


        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}