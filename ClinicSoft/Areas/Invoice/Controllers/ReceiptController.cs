using BusinessEntities.Appointment;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Invoice;
using System.Security.Claims;
using Microsoft.Ajax.Utilities;
using BusinessEntities.Common;
using System.Configuration;
using System.IO;
using System.Net;
using BusinessEntities.MNR;
using System.Threading.Tasks;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class ReceiptController : Controller
    {
        int PageId = (int)Pages.Receipts;

        #region Receipt for Invoices (Page Load & Search)
        [HttpGet]
        public ActionResult ReceiptIndex()
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
        public ActionResult GetInvoiceReceipts(BusinessEntities.Invoice.ReceiptSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.ReceiptData> dataList = new List<BusinessEntities.Invoice.ReceiptData>();

                try
                {
                    dataList = BusinessLogicLayer.Invoice.Receipts.GetInvoiceReceipts(data);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Reeipts for Invoices Page!"
                    });

                    var jsonResult = Json(dataList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(dataList, JsonRequestBehavior.AllowGet);
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

        #region Receipt for Invoices (Miscellaneous Functions)
        [HttpGet]
        public ActionResult BankNamesForBankTransfers()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BankNamesBT> bankList = new List<BankNamesBT>();
                try
                {
                    bankList = BusinessLogicLayer.Invoice.Receipts.BankNamesForBankTransfers();
                    var jsonResult = Json(bankList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(bankList, JsonRequestBehavior.AllowGet);
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
        public ActionResult ReceiptAdvanceByPatId(int patId,int? rec_doctor=0)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ReceiptAdvance> list = new List<ReceiptAdvance>();
                try
                {
                    list = BusinessLogicLayer.Invoice.Receipts.ReceiptAdvanceByPatId(patId, rec_doctor);
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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
        public ActionResult ReceiptVouchers()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ReceiptVoucher> list = new List<ReceiptVoucher>();
                try
                {
                    list = BusinessLogicLayer.Invoice.Receipts.ReceiptVouchers();
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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
        public ActionResult ReceiptLoyalityEarnsByPatId(int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ReceiptLoyality> list = new List<ReceiptLoyality>();
                try
                {
                    list = BusinessLogicLayer.Invoice.Receipts.ReceiptLoyalityEarnsByPatId(patId);
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
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

        #region Receipt for Invoices CRUD Operations
        [HttpGet]
        public PartialViewResult NewReceipt()
        {
            int Action = (int)Actions.Create;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    BusinessEntities.Invoice.Receipts receipts = BusinessLogicLayer.Invoice.Receipts.AutoCreateReceiptCode(int.Parse(emp_branch));

                    return PartialView("NewReceipt", receipts);
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
        public ActionResult GenerateReceipt(Receipts data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    data.rec_madeby = PageControl.getLoggedinId();
                    data.rec_branch = int.Parse(emp_branch.ToString());

                    int val = BusinessLogicLayer.Invoice.Receipts.CreateReceipts(data);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.rec_madeby,
                            log_desc = $"Employee Generated New Receipt with recId = {val}"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "New Receipt is Generated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while creating Receipt." }, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetReceiptById(int recId)
        {
            int Action = (int)Actions.Read;

            ReceiptWithInvoiceInfo rni = new ReceiptWithInvoiceInfo();
            Receipts r = new Receipts();

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    rni = BusinessLogicLayer.Invoice.Receipts.GetReceiptById(recId);
                    r = rni.receipts;

                    if (r.recId > 0 && r.total > 0)
                    {
                        return Json(new { isAuthorized = true, isSuccess = true, data = r, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, data = r, message = "No Data Found" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, data = r, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, data = r, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdatePayReceipt(Receipts data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    data.rec_madeby = PageControl.getLoggedinId();
                    data.rec_branch = int.Parse(emp_branch.ToString());

                    int val = BusinessLogicLayer.Invoice.Receipts.UpdateReceipts(data);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.rec_madeby,
                            log_desc = $"Employee Updated Receipt with recId = {data.recId}"
                        });

                        return Json(new { isSuccess = true, invId = val, message = "Receipt Updated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error while creating the receipt " }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeletePayReceipt(int recId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int i = BusinessLogicLayer.Invoice.Receipts.DeleteReceiptById(recId, PageControl.getLoggedinId());

                    if (i > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Receipt with recId = {recId}"
                        });

                        return Json(new { isAuthorized = true, isSuccess = true, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, message = "Error while Deleting the Receipt" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult PrintReceipt(int recId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.ReceiptPrint print = BusinessLogicLayer.Invoice.Receipts.PrintReceipt(recId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Receipt with recId = {recId}"
                    });

                    return View("PrintReceipt", print);
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
        public PartialViewResult EditReceipt(int recId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    ReceiptWithInvoiceInfo rni = new ReceiptWithInvoiceInfo();
                    rni = BusinessLogicLayer.Invoice.Receipts.GetReceiptById(recId);

                    return PartialView("EditReceipt", rni);
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
        public ActionResult SearchPatients(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Invoice.Invoice.SearchInvoicedPatients(query);

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

        [HttpGet]
        public PartialViewResult InvoiceReceipts(int invId, int patId, string rec_date)
        {
            int Action = (int)Actions.Read;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    ReceiptViewModel dataModel = BusinessLogicLayer.Invoice.Receipts.GetAllReceiptsForInvoice(invId, patId, rec_date);

                    return PartialView(dataModel);
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
        public ActionResult GenerateMultiReceipt(MultiInvoiceReceiptsViewModal data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    data.receipts.rec_madeby = PageControl.getLoggedinId();
                    data.receipts.rec_branch = int.Parse(emp_branch.ToString());

                    int val = BusinessLogicLayer.Invoice.Receipts.CreateMultiReceipts(data);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = data.receipts.rec_madeby,
                            log_desc = $"Employee Generated Receipts with recId = {val}"
                        });

                        return Json(new { isSuccess = true, message = "Receipts are generated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Error in creating the receipts " }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult MultiReceipts(List<MultiReceiptInvoice> selected_invoices)
        {
            return PartialView("MultiReceipts", selected_invoices);
        }

        [HttpGet]
        public ActionResult ReceiptDocument(int recId, string rec_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DocReference doc_ref = new DocReference();
                doc_ref.refId = recId;
                doc_ref.reftype = "Receipt";
                doc_ref.ref_name = rec_code;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Viewed Receipt Documents with recId = {recId}"
                });


                return PartialView("ReceiptDocument", doc_ref);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UploadFiles(DocData data)
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
                            log_desc = $"Employee Uploaded Files (Receipts)"
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
                    else if (type == "Receipt")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetDocumentsById(id, 4, path);
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
                        log_desc = $"Employee Deleted Receipt Document with docId = {docId}"
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

        [HttpGet]
        public ActionResult ViewDocument(string type, int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.Lists.DownloadFile file = new BusinessEntities.Lists.DownloadFile();
                DataTable dt = BusinessLogicLayer.Lists.DownloadFile.GetFilePathDownload(id, type);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        if (type == "pat_doc")
                        {
                            string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/patient_images" }, StringSplitOptions.None);
                            file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/patient_images" + path[1].Trim().ToString();
                        }
                        else if (type == "rec_doc")
                        {
                            string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/uploaded_documents" }, StringSplitOptions.None);
                            file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/uploaded_documents" + path[1].Trim().ToString();
                        }
                        else
                        {
                            string fileName = Path.Combine(ConfigurationManager.AppSettings["ClinicSoftEndPoint"], "images/patient_images/", row["file_path"].ToString().Trim());
                            file.file = fileName;
                        }

                        file.id = id;
                        file.type = type;
                        return PartialView("ViewDocument", file);
                    }
                    else
                    {
                        return PartialView("ViewDocument", file);
                    }
                }
                else
                {
                    return PartialView("ViewDocument", file);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public FileContentResult DownloadFile(string type, int id)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                byte[] fileContent = null;
                DataTable dt = BusinessLogicLayer.Lists.DownloadFile.GetFilePathDownload(id, type);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        string fileName = Path.Combine(Server.MapPath("~/images/uploaded_documents/"), row["file_path"].ToString().Trim());


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
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Downloaded File with id = {id} and Type = {type}"
                });

                return new FileContentResult(fileContent, "image/jpeg");
            }
            else
            {
                return new FileContentResult(null, "image/jpeg");
            }
        }

        [HttpGet]
        public PartialViewResult ReceiptAuditLog(int recId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Invoice.ReceiptAudit> log = BusinessLogicLayer.Invoice.Receipts.GetReceiptLog(recId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Receipts Audit Logs with recId = {recId}"
                    });

                    return PartialView("ReceiptAuditLog", log);
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
        public ActionResult PostToAccountReceipts(ReceiptsBulkStatus data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Invoice.Receipts.PostToAccountReceipt(data.recIds, PageControl.getLoggedinId());

                if (val > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Posted Receipt(s) to Chart of Account : {data.recIds}"
                    });

                    return Json(new { isSuccess = true, message = "Selected Receipt(s) Posted to Chart of Account" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Error while posting the Receipt to Chart of Account " }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }


        [HttpPost]
        public ActionResult PostReceiptToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Invoice.Receipts.PostReceiptToAccount(data, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Posted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Receipt Posting Error to Accounts" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Posting Receipt to Accounts!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = -3, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Create Service Wise Receipts
        [HttpGet]
        public ActionResult ServiceWiseReceipts(int recId, string rec_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt_ptIds = BusinessLogicLayer.Invoice.Receipts.GetTreatmentList(recId);
                SelectList TreatmentList = Models.Helper.ToSelectList(dt_ptIds, "ptId", "tr_name");
                ViewData["TreatmentList"] = TreatmentList;

                ServiceWiseReceiptsInfo REC = new ServiceWiseReceiptsInfo();
                REC.rec_code = rec_code;
                REC.recId = recId;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Viewed Service Wise Receipts with recId = {recId}"
                });


                return PartialView("ServiceWiseReceipts", REC);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult GenerateServiceWiseReceipts(QC_InvoiceReceipts data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string inv_no = string.Empty;
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    int val = BusinessLogicLayer.Invoice.Receipts.GenerateServiceWiseReceipts(data, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        return Json(new { isSuccess = true, invId = val, message = "Service Wise Receipts are generated successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0, message = "Error in generating the Receipts " }, JsonRequestBehavior.AllowGet);
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

        public JsonResult GetServiceReceipts(int recId,int srId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ServiceWiseReceiptsInfo> notes = BusinessLogicLayer.Invoice.Receipts.GetServiceReceipts(recId, srId);

                return Json(notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult UpdateServiceReceipts(BusinessEntities.Invoice.ServiceWiseReceiptsInfo data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    isInserted = BusinessLogicLayer.Invoice.Receipts.InsertUpdateServiceWiseReceipts(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Department to : {data.srId}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Service wise Receipt Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Failed to update Service wise Receipt" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult SearchTreatmentsforEdit(int ptId, string appId)
        {
            int Action = (int)Actions.Read;
            try
            {
                List<CommonDDL> dt = BusinessLogicLayer.Invoice.Receipts.SearchTreatmentsforEdit(ptId, appId);

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
        [HttpPost]
        public ActionResult DeleteServiceReceipts(int srId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int i = BusinessLogicLayer.Invoice.Receipts.DeleteServiceReceiptsById(srId, PageControl.getLoggedinId());

                    if (i > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Receipt with recId = {srId}"
                        });

                        return Json(new { isAuthorized = true, isSuccess = true, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, message = "Error while Deleting the Receipt" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
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