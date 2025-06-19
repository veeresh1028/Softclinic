using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System.Security.Claims;
using System.Web.UI;
using BusinessEntities.Common;
using System.Configuration;
using System.IO;
using System.Net;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class PaymentAgainstInvoicesController : Controller
    {
        int PageId = (int)Pages.PaymentAgainstInvoices;
        public ActionResult PaymentAgainstInvoices()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PaymentFilter filter = new PaymentFilter();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.pay_type = "Invoice";
                List<Payment> paylist = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;
                return View(paylist);

            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Invoice Payments Detail
        public JsonResult GetInvoicePayments(PaymentFilter filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;

                if (string.IsNullOrEmpty(filter.pay_type))
                    filter.pay_type = "Invoice";

                if (!string.IsNullOrEmpty(filter.from_date) && !string.IsNullOrEmpty(filter.to_date))
                {
                    filter.from_date = DateTime.Parse(filter.from_date).ToString("MM/dd/yyyy");
                    filter.to_date = DateTime.Parse(filter.to_date).ToString("MM/dd/yyyy");
                }

                List<Payment> paylist = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter);

                var jsonResult = Json(paylist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Create Invoice Payment 
        [HttpGet]
        public PartialViewResult CreatePaymentInvoice()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreatePaymentInvoice");
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

        // Get Suppliers on Branch Change Event
        public ActionResult GetSupplierByBranchesAndPending(string query, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = null;
                    if(branch > 0)
                        dt = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetSupplierByBranchesAndPending(query, branch);

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

        // Get Invoice List on Supplier Selection
        [HttpGet]
        public ActionResult GetSupplierInvoiceList(string pay_supplier, int branch)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PurchaseInvoice> list = new List<PurchaseInvoice>();

                try
                {
                    int empId = PageControl.getLoggedinId();
                    list = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetSupplierInvoiceList(pay_supplier, branch, empId);

                    if (list.Count > 0)
                    {
                        return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, data = list }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, data = ex }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Sigle Invoice Detail on Invoice Click
        [HttpGet]
        public PartialViewResult InvoicePayment(int pinvId, int pay_supplier, string pay_date)
        {
            PaymentViewModal dataModel = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAllPaymentsForPurchaseInvoice(pinvId, pay_supplier, pay_date);
            return PartialView(dataModel);
        }
        
        // Get Advance Payment Supplier wise on Invoice Click
        [HttpGet]
        public ActionResult AdvancePaymentsBySupllier(int pay_supplier)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<PaymentAdvance> list = new List<PaymentAdvance>();
                try
                {
                    list = BusinessLogicLayer.Accounts.MaterialManagement.Payment.AdvancePaymentsBySupllier(pay_supplier);
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
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
        
        //Insert Payment Against invoice Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertPayment(Payment data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pay_madeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPayment(data, out errors))
                    {
                        string pay_code;
                        int pay_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.Payment.InsertPayment(data, out pay_code, out pay_Id);
                        if (isInserted)
                        {
                            return Json(new { isSuccess = true, message = "Payment Added Successfully!", payCode = pay_code, payId = pay_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Error While Adding Payment!" }, JsonRequestBehavior.AllowGet);
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
                return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }

        }
        
        // Get Payment Detail on Edit Click
        [HttpGet]
        public ActionResult GetPaymentById(int payId)
        {
            int Action = (int)Actions.Read;
            Payment paylist = new Payment();
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    PaymentFilter filter = new PaymentFilter();
                    filter.empId = empId;
                    filter.payId = payId;
                    filter.pay_type = "Invoice";
                    paylist = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter).SingleOrDefault();

                    if (paylist.payId > 0 && paylist.total_paid > 0)
                    {
                        return Json(new { isAuthorized = true, isSuccess = true, data = paylist, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, data = paylist, message = "No Data Found" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, data = paylist, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, data = paylist, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
            }
        }
        
        //Update Payment Against invoice Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePayment(Payment data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.pay_madeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPayment(data, out errors))
                    {
                        string pay_code;
                        int pay_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.Payment.InsertPayment(data, out pay_code, out pay_Id);
                        if (isInserted)
                        {
                            return Json(new { isSuccess = true, message = "Payment Updated Successfully!", payCode = pay_code, payId = pay_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Error While Updating Payment!" }, JsonRequestBehavior.AllowGet);
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
                return Json(new { isSuccess = false, invId = 0, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        
        //Delete Payment Against invoice Detail
        [HttpPost]
        public ActionResult DeletePayment(int payId, int pay_invoice, int pay_supplier)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int i = BusinessLogicLayer.Accounts.MaterialManagement.Payment.DeletePaymentById(payId, PageControl.getLoggedinId(), pay_invoice, pay_supplier);
                    if (i > 0)
                    {
                        return Json(new { isAuthorized = true, isSuccess = true, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, message = "Error to Delete the Receipt" }, JsonRequestBehavior.AllowGet);
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
        
        //Print Invoice Payment Detail
        [HttpGet]
        public ActionResult PrintPayment(int payId)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PaymentFilter filter = new PaymentFilter();
                filter.empId = empId;
                filter.payId = payId;
                filter.pay_type = "Invoice";
                List<Payment> Payment_print = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter);
                return View("PrintPayment", Payment_print.FirstOrDefault());
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        
        //Purchase Invoice Payment Documents
        #region Purchase Invoice Payment Documents
        [HttpGet]
        public ActionResult Payment_Documents(int payId, string pay_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DocReference doc_ref = new DocReference();
                doc_ref.refId = payId;
                doc_ref.reftype = "Invoice Payment";
                doc_ref.ref_name = pay_code;
                return PartialView("Payment_Documents", doc_ref);
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

                    string file_path = Server.MapPath("~/images/MaterialManagement/PurchaseInvoicePayment/");

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
                                        if (BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.UploadDocument(doc))
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
                    string folder = "PurchaseInvoicePayment";
                    doc_data = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetDocumentsById(id, type, path, folder);

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
                bool val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.DeleteDocuments(docId, "Invoice Payment");

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
        public FileContentResult DownloadFile(string type, int id)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                byte[] fileContent = null;
                DataTable dt = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetFilePathDownload(id, type);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        string fileName = Path.Combine(Server.MapPath("~/images/MaterialManagement/PurchaseInvoicePayment/"), row["file_path"].ToString().Trim());
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
        public ActionResult ViewDocument(string type, int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessEntities.Lists.DownloadFile file = new BusinessEntities.Lists.DownloadFile();
                DataTable dt = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetFilePathDownload(id, type);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    if ((row["file_path"].ToString().Trim() != "") &&
                    (row["file_path"].ToString().Trim() != null) &&
                    (row["file_path"].ToString().Trim() != "NA"))
                    {
                        string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/MaterialManagement/PurchaseInvoicePayment" }, StringSplitOptions.None);
                        file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/MaterialManagement/PurchaseInvoicePayment" + path[1].Trim().ToString();

                        file.id = id;
                        file.type = type;
                        return PartialView("PaymentDocumentView", file);
                    }
                    else
                    {
                        return PartialView("PaymentDocumentView", file);
                    }
                }
                else
                {
                    return PartialView("PaymentDocumentView", file);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        #endregion Purchase Invoice Payment Documents

        // Get Purchase Invoice Payment Audit Log Detail
        [HttpGet]
        public PartialViewResult PaymentAuditLogs(string pay_code)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.PaymentLogsList _payLog = BusinessLogicLayer.Accounts.AuditLogs.PaymentLogs.GetAdvancePaymentAuditLogs(pay_code, empId);

                return PartialView("PaymentAuditLogs", _payLog);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Open Multi Payment Model
        [HttpPost]
        public PartialViewResult MultiPayments(List<MultiPaymentInvoices> selected_invoices)
        {
            return PartialView("MultiPayments", selected_invoices);
        }


        [HttpPost]
        public ActionResult GenerateMultiPayments(MultiInvoicepaymentsViewModal data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {                    
                    data.payments.pay_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.Accounts.MaterialManagement.Payment.CreateMultiPayments(data);

                    if (val > 0)
                    {
                        return Json(new { isSuccess = true, message = "Payments are added successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Error in creating the payments " }, JsonRequestBehavior.AllowGet);
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

        //Get Detail For Edit Purchase Invoice Payment
        [HttpGet]
        public ActionResult EditPayment(int payId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PaymentFilter filter = new PaymentFilter();
                filter.payId = payId;
                filter.empId = empId;
                filter.pay_type = "Invoice";
                Payment paylist = BusinessLogicLayer.Accounts.MaterialManagement.Payment.GetAdvancePayments(filter).SingleOrDefault();
                return View("EditPaymentInvoice", paylist);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult PostPaymentToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.Payment.PostPaymentToAccount(data, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Posted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Payment Posting Error to Accounts" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Posting Payment to Accounts!" }, JsonRequestBehavior.AllowGet);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}