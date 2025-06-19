using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Accounts.MaterialManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecurityLayer;
using BusinessEntities.Appointment;
using RestSharp;
using System.Configuration;
using System.Threading.Tasks;
using BusinessEntities.Common;
using System.IO;
using System.Net;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    
    public class PurchaseOrdersController : Controller
    {
        int PageId = (int)Pages.PurchaseOrders;

        #region Purchase Orders
        public ActionResult PurchaseOrders()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PurchaseOrderFilters filter = new PurchaseOrderFilters();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrders> purchaseOrderslist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrders(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View(purchaseOrderslist);
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
        public JsonResult GetPurchaseOrders(PurchaseOrderFilters filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                if (!string.IsNullOrEmpty(filter.from_date) && !string.IsNullOrEmpty(filter.to_date))
                {
                    filter.from_date = DateTime.Parse(filter.from_date).ToString("MM/dd/yyyy");
                    filter.to_date = DateTime.Parse(filter.to_date).ToString("MM/dd/yyyy");
                }
                List<PurchaseOrders> purchaseOrderslist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrders(filter);

                var jsonResult = Json(purchaseOrderslist, JsonRequestBehavior.AllowGet);

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
        public ActionResult GetChildTableItems(int purId)
        {
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrderItems> _purchaseOrderItems = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrderItems>();
            _purchaseOrderItems = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetChildTableItems(purId);
            return PartialView("PurchaseItems", _purchaseOrderItems);
        }

        //Get Purchase Order Items
        [HttpGet]
        public ActionResult GetPurchaseOrdersItems(int purId)
        {
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrderItems> _purchaseOrderItems = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrderItems>();
            _purchaseOrderItems = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrdersItems(purId);
            return PartialView("PurchaseItems", _purchaseOrderItems);
        }

        //Create Purchase Order 
        [HttpGet]
        public PartialViewResult CreatePurchaseOrder()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;
                    return PartialView("CreatePurchaseOrder");
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

        // Add Items Partial View
        public PartialViewResult PurchaseOrderItems()
        {
            DataTable dt_uom = BusinessLogicLayer.Accounts.Masters.CentralStore.GetUOMList(0);
            SelectList UOMList = Models.Helper.ToSelectList(dt_uom, "uom", "uom");
            ViewData["UOMList"] = UOMList;
            return PartialView();
        }

        //Get Items on search
        [HttpGet]
        public ActionResult SearchItems(string query, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PurchaseOrderDDL> dt = BusinessLogicLayer.Accounts.Masters.CentralStore.SearchItems(query, branch);
                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
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

        //Get Items Detail on Select Event
        [HttpGet]
        public ActionResult GetItemDetail(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    BusinessEntities.Accounts.Masters.ItemsFilter data = new BusinessEntities.Accounts.Masters.ItemsFilter();
                    data.itemId = id;
                    data.empId = empId;
                    List<BusinessEntities.Accounts.Masters.Items> item_detail = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItems(data);
                    var jsonResult = Json(item_detail, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
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

        // Get Suppliers for Filter
        public JsonResult GetShippingAddress(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Company> dataList = BusinessLogicLayer.Company.GetBranchDetails(branchId);

                return Json(dataList.FirstOrDefault(), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert Purchase Order Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertPurchaseOrder(PurchaseOrderAndItems data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.purchaseOrders.empId = PageControl.getLoggedinId();
                    data.purchaseOrders.pur_omadeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPurchaseOrder(data, out errors))
                    {
                        string pur_code;
                        int pur_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.InsertPurchaseOrder(data, out pur_code, out pur_Id, "General", 0);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Purchase Order Added Successfully!", purCode = pur_code, purId = pur_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Creating Purchase Order!" }, JsonRequestBehavior.AllowGet);
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

        //Print Purchase Order Detail
        [HttpGet]
        public ActionResult PrintPurchaseOrder(int purId)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PurchaseOrderAndItems PO_print = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrdersPrint(purId, empId);
                return View("PurchaseOrderPrint", PO_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Print Items Barcode Based On Purchase Order
        [HttpPost]
        public async Task<ActionResult> PrintBarcodeService(int purId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    List<BarcodeService> _barcodeService = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetBarcodePrintData(purId, empId);
                    if (_barcodeService != null)
                    {
                        bool isSuccess = false;
                        string response_message = "";
                        foreach (BarcodeService barcodeService in _barcodeService)
                        {
                            if (barcodeService.Qty > 0)
                            {
                                decimal qty = 0;
                                bool qty1 = decimal.TryParse(barcodeService.Qty.ToString(), out qty);
                                barcodeService.Qty = Decimal.ToInt32(qty);
                                for (int i = 0; i < qty; i++)
                                {
                                    if (barcodeService.ItemName.Length > 33)
                                    {
                                        barcodeService.ItemName = (barcodeService.ItemName.Substring(0, 30) + "...");
                                    }
                                    string end_point = "Device/PrintBarcodeData?BarCodeNo=" + barcodeService.ItemCode + "&PatientName=AED " + barcodeService.ItemPrice + " Expiry" + barcodeService.Expdate + "&AgeGender=" + HttpUtility.UrlEncode(barcodeService.BranchName) + "&Collectiondate=" + HttpUtility.UrlEncode(barcodeService.ItemName) + "&Analyzer=" + barcodeService.BranchName;
                                    var options = new RestClientOptions(ConfigurationManager.AppSettings["BarcodeServiceEndPoint"].ToString())
                                    {
                                        MaxTimeout = -1,
                                    };
                                    var client = new RestClient(options);
                                    var request = new RestRequest(end_point, Method.Get);
                                    RestResponse response = await client.ExecuteAsync(request);
                                    if (response.IsSuccessful)
                                    {
                                        isSuccess = true;
                                        response_message = response.Content;
                                    }
                                }
                            }

                        }
                        return Json(new { isSuccess = isSuccess, message = response_message, data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "No Batch Found To Print", data = new { } }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message, data = new { } }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isSuccess = false, message = "You are not authorized to perform this action", data = new { } }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        //Change Purchase Order Status 
        [HttpPost]
        public ActionResult PurchaseOrderActionStatus(string data, string status)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.PurchaseOrderActionStatus(data, status, empId);
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

        // Opening Purchase Order Audit Logs View
        [HttpGet]
        public PartialViewResult PurchaseOrderAuditLogs(string pura_ocode)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog POLogList = new BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog();
                POLogList.pura_ocode = pura_ocode;
                return PartialView("PurchaseOrderAuditLogs", POLogList);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Purchase Order Audit Log Detail From Database
        [HttpGet]
        public JsonResult PurchaseOrderAuditLogs_detail(string pura_ocode)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<BusinessEntities.Accounts.AuditLogs.PurchaseOrderLog> _purchaseOrderLog = BusinessLogicLayer.Accounts.AuditLogs.PurchaseOrderLog.GetPurchaseOrderAuditLogs(pura_ocode);
                return Json(_purchaseOrderLog, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }



        //Get Detail For Edit Purchase Order 
        [HttpGet]
        public ActionResult EditPurchaseOrder(int purId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                PurchaseOrderAndItems PO_edit = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrdersPrint(purId, empId);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("EditPurchaseOrder", PO_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Delete Purchase Items Detail in Database 
        [HttpPost]
        public ActionResult DeletePurchaseItems(string data)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<int> piId = new List<int>();
                    string[] arr = data.Split(',');
                    foreach (string str in arr)
                    {
                        piId.Add(int.Parse(str));
                    }
                    int val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.DeletePurchaseItems(piId, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        return Json(new { isSuccess = true, invId = val }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, invId = 0 }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception)
                {
                    return Json(new { isSuccess = false, invId = -1 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        //Update Purchase Order Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePurchaseOrder(PurchaseOrderAndItems data)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.purchaseOrders.empId = PageControl.getLoggedinId();
                    data.purchaseOrders.pur_omadeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidUpdatePO(data, out errors))
                    {
                        string pur_code;
                        int pur_Id;
                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.InsertPurchaseOrder(data, out pur_code, out pur_Id, "General", 0);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Purchase Order Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Updating Purchase Order!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage_update"] = ex.Message;
            }

            return View();
        }


        // Get Purchase Order History Detail
        [HttpGet]
        public PartialViewResult PurchaseOrderHistory(string code, int branch)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                PurchaseOrderHistory history = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrderHistory(code, branch, empId);

                return PartialView("PurchaseOrderHistory", history);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        #endregion

        #region Purchase Order Documents
        [HttpGet]
        public ActionResult PurchaseOrderDocuments(int purId, string pur_ocode)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DocReference doc_ref = new DocReference();
                doc_ref.refId = purId;
                doc_ref.reftype = "Purchase Order";
                doc_ref.ref_name = pur_ocode;

                return PartialView("PurchaseOrderDocuments", doc_ref);
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

                    string file_path = Server.MapPath("~/images/MaterialManagement/PurchaseOrders/");

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
                    string folder = "PurchaseOrders";
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
                bool val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.DeleteDocuments(docId, "Purchase Order");

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
                        string fileName = Path.Combine(Server.MapPath("~/images/MaterialManagement/PurchaseOrders/"), row["file_path"].ToString().Trim());
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
                        string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/MaterialManagement/PurchaseOrders" }, StringSplitOptions.None);
                        file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/MaterialManagement/PurchaseOrders" + path[1].Trim().ToString();

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

        #endregion

        #region Purchase Request Convertion
        //Create Purchase Order 
        [HttpGet]
        public PartialViewResult ConvertPurchaseRequest()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;
                    return PartialView("PurchaseRequestConvert");
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

        public JsonResult GetPurchaseRequests(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataTable dt_suppliers = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseRequests(branchId);
                SelectList SupplierList = Models.Helper.ToSelectList(dt_suppliers, "purqId", "purq_ocode");
                return Json(SupplierList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetPurchaseRequestsDetail(int purqId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    PurchaseRequestFilters filter = new PurchaseRequestFilters();

                    PurchaseRequestsAndItems purchaseRequestslist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseRequestAndRequestItems(purqId);

                    var jsonResult = Json(purchaseRequestslist, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetUOMItemWise(int itemId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    PurchaseRequestFilters filter = new PurchaseRequestFilters();

                    List<PurchaseOrderDDL> uom_list = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetUOMItemWise(itemId);

                    var jsonResult = Json(uom_list, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert Purchase Order Detail Converted From Purchase Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConvertionPurchaseOrderInsert(string purqId, PurchaseOrderAndItems data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.purchaseOrders.empId = PageControl.getLoggedinId();
                    data.purchaseOrders.pur_omadeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPurchaseOrder(data, out errors))
                    {
                        string pur_code;
                        int pur_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.InsertPurchaseOrder(data, out pur_code, out pur_Id, "General", 0);

                        if (isInserted)
                        {
                            bool isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.PurchaseRequestActionStatus(purqId, "Converted to PO", PageControl.getLoggedinId());

                            return Json(new { isInserted = true, message = "Purchase Order Added Successfully!", purCode = pur_code, purId = pur_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Creating Purchase Order!" }, JsonRequestBehavior.AllowGet);
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

        #endregion

        #region Stock Item Enquiry

        // Get Items History Detail
        [HttpGet]
        public PartialViewResult StockItemEnquiry()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                int itemId = 0; int item_branch = 1; string item_code = "";

                ItemsHistory _items = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemHistory(itemId, item_code, item_branch, empId);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return PartialView("StockItemEnquiry", _items);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        [HttpGet]
        public ActionResult GetEnquiryItemDetail(int branch, int itemId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    
                    ItemsHistory item_list = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetItemEnquiryDetail(itemId, "", branch, empId);
                    var jsonResult = Json(item_list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}