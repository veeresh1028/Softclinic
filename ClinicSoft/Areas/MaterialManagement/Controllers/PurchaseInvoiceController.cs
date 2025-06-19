using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Common;
using System.Configuration;
using System.IO;
using System.Net;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class PurchaseInvoiceController : Controller
    {
        int PageId = (int)Pages.PurchaseInvoices;

        // Purchase Invoice Page Load
        public ActionResult PurchaseInvoices()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PurchaseInvoice_Filter filter = new PurchaseInvoice_Filter();
                filter.empId = empId;
                filter.pinv_fdate = DateTime.Now.ToString("MM/dd/yyyy");
                filter.pinv_tdate = DateTime.Now.ToString("MM/dd/yyyy");
                List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View(pinvlist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Suppliers for Filter
        public JsonResult GetSupplierByBranches(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataTable dt_suppliers = BusinessLogicLayer.Accounts.Masters.Supplier.GetSuppliersList(0, branchId);
                SelectList SupplierList = Models.Helper.ToSelectList(dt_suppliers, "supId", "sup_name");
                return Json(SupplierList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        // Get Purchase Orders Detail
        public JsonResult GetPurchaseInvoices(PurchaseInvoice_Filter filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                if (!string.IsNullOrEmpty(filter.pinv_fdate) && !string.IsNullOrEmpty(filter.pinv_tdate))
                {
                    filter.pinv_fdate = DateTime.Parse(filter.pinv_fdate).ToString("MM/dd/yyyy");
                    filter.pinv_tdate = DateTime.Parse(filter.pinv_tdate).ToString("MM/dd/yyyy");
                }
                List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoice> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoices(filter);

                var jsonResult = Json(pinvlist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Child Table Data
        [HttpGet]
        public ActionResult GetPurchaseInvoiceItems(int pinvId)
        {
            PurchaseInvoice_Filter filter = new PurchaseInvoice_Filter();
            filter.pinvId = pinvId;
            filter.empId = PageControl.getLoggedinId();
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoiceItems> _pinvItems = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseInvoiceItems>();
            _pinvItems = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoiceItems (filter);
            return PartialView("PurchaseInvoiceItems", _pinvItems);
        }

        //Change Purchase Invoice Status 
        [HttpPost]
        public ActionResult PurchaseInvoice_Status(string data, string status)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.PurchaseInvoice_StatusChange(data, status, empId);
                    if (isUpdated)
                    {
                        return Json(new { isUpdated = true, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = "Error While Status Updating!" }, JsonRequestBehavior.AllowGet);
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

        // Get Purchase Invoice Audit Log Detail
        [HttpGet]
        public PartialViewResult PurchaseInvoiceAuditLogs(string pinv_icode)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.PurchaseInvoiceLogs_list _pinvLog = BusinessLogicLayer.Accounts.AuditLogs.PurchaseInvoiceLogs.GetPurchaseInvoiceAuditLogs(pinv_icode);

                return PartialView("PurchaseInvoiceAuditLogs", _pinvLog);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Print Purchase Invoice Detail
        [HttpGet]
        public ActionResult PrintPurchaseInvoice(int pinvId)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                purchaseInvoiceWithItems pinv_print = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoice_Print(pinvId, empId);
                return View("PurchaseInvoicePrint", pinv_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Goods Purchase Invoice Documents
        #region Purchase Invoice Documents
        [HttpGet]
        public ActionResult PurchaseInvoice_Documents(int pinvId, string pinv_icode)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DocReference doc_ref = new DocReference();
                doc_ref.refId = pinvId;
                doc_ref.reftype = "Purchase Invoice";
                doc_ref.ref_name = pinv_icode;
                return PartialView("PurchaseInvoice_Documents", doc_ref);
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

                    string file_path = Server.MapPath("~/images/MaterialManagement/PurchaseInvoice/");

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
                    string folder = "PurchaseInvoice";
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
                bool val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.DeleteDocuments(docId, "Purchase Invoice");

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
                        string fileName = Path.Combine(Server.MapPath("~/images/MaterialManagement/PurchaseInvoice/"), row["file_path"].ToString().Trim());
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
                        string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/MaterialManagement/PurchaseInvoice" }, StringSplitOptions.None);
                        file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/MaterialManagement/PurchaseInvoice" + path[1].Trim().ToString();

                        file.id = id;
                        file.type = type;
                        return PartialView("Invoice_ViewDocuments", file);
                    }
                    else
                    {
                        return PartialView("Invoice_ViewDocuments", file);
                    }
                }
                else
                {
                    return PartialView("Invoice_ViewDocuments", file);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion Purchase Invoice Documents

        //Create Purchase Invoice 
        [HttpGet]
        public PartialViewResult CreatePurchaseInvoice()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreatePurchaseInvoice");
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

        // Get Suppliers with Pending GRN for Create Invoice
        public JsonResult GetSupplierByBranches_grn(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataTable dt_suppliers = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetSupplierByBranches_grn(0, branchId);
                SelectList SupplierList = Models.Helper.ToSelectList(dt_suppliers, "supId", "sup_name");
                return Json(SupplierList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Get GRN For Dropdown On Supplier Id
        public JsonResult GetGRN_Dropdown_Detail(int branchId, int supId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataTable dt_grn = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Dropdown_Detail(branchId, supId);
                SelectList grnList = Models.Helper.ToSelectList(dt_grn, "prId", "pr_code");
                return Json(grnList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Get GRNs Based On Supplier Detail
        public JsonResult GetGRN_Details(int branchId, int supId, string grnIds)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<BusinessEntities.Accounts.MaterialManagement.GRN> grnlist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Details(branchId, supId, grnIds, empId);
                
                return Json(grnlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert Purchase Invoice Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertPurchaseInvoice(purchaseInvoiceWithItems data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.purchaseInvoice.pinv_imadeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPurchaseInvoice(data, out errors))
                    {
                        string pinv_code;
                        int pinv_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.InsertPurchaseInvoice(data, out pinv_code, out pinv_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Purchase Invoice Added Successfully!", pinvCode = pinv_code, pinvId = pinv_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Creating Purchase Invoice!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage_Insert"] = ex.Message;
            }

            return View();
        }

        //Get Detail For Edit Purchase Invoice
        [HttpGet]
        public ActionResult EditPurchaseInvoice(int pinvId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                purchaseInvoiceWithItems pinv_edit = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetPurchaseInvoice_Edit(pinvId, empId);               
                return View("EditPurchaseInvoice", pinv_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Get GRN For Dropdown On Supplier Id Update
        public JsonResult GetGRN_Dropdown_Edit(int branchId, int supId, int pinvId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataTable dt_suppliers = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.GetGRN_Dropdown_Edit(branchId, supId, pinvId);
                SelectList SupplierList = Models.Helper.ToSelectList(dt_suppliers, "prId", "pr_code");
                return Json(SupplierList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Update Purchase Invoice Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePurchaseInvoice(purchaseInvoiceWithItems data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.purchaseInvoice.pinv_imadeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPurchaseInvoice(data, out errors))
                    {
                        string pinv_code;
                        int pinv_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.UpdatePurchaseInvoice(data, out pinv_code, out pinv_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Purchase Invoice Updated Successfully!", pinvCode = pinv_code, pinvId = pinv_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Updating Purchase Invoice!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage_Update"] = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult PostPurchaseInvoiceToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseInvoice.PostPurchaseInvoiceToAccount(data, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Posted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Purchase Invoice Posting Error" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Posting Purchase Invoice!" }, JsonRequestBehavior.AllowGet);
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
