using BusinessEntities;
using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Common;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class GRNController : Controller
    {
        int PageId = (int)Pages.GRN;

        // GRN Page Load
        public ActionResult GRN()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                GRN_Filters filter = new GRN_Filters();
                filter.empId = empId;
                filter.pr_fdate = DateTime.Now.ToString("MM/dd/yyyy");
                filter.pr_tdate = DateTime.Now.ToString("MM/dd/yyyy");
                List<BusinessEntities.Accounts.MaterialManagement.GRN> grnlist = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetPurchaseReceived(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View(grnlist);
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
        public JsonResult GetPurchaseReceived(GRN_Filters filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                if (!string.IsNullOrEmpty(filter.pr_fdate) && !string.IsNullOrEmpty(filter.pr_tdate))
                {
                    filter.pr_fdate = DateTime.Parse(filter.pr_fdate).ToString("MM/dd/yyyy");
                    filter.pr_tdate = DateTime.Parse(filter.pr_tdate).ToString("MM/dd/yyyy");
                }
                List<BusinessEntities.Accounts.MaterialManagement.GRN> grnlist = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetPurchaseReceived(filter);

                var jsonResult = Json(grnlist, JsonRequestBehavior.AllowGet);

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
        public ActionResult GetPurchaseReceivedItems(int prId)
        {
            GRN_Filters filter = new GRN_Filters();
            filter.prId = prId;
            filter.empId = PageControl.getLoggedinId();
            List<BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS> _grnItems = new List<BusinessEntities.Accounts.MaterialManagement.GRN_ITEMS>();
            _grnItems = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetPurchaseReceivedItems(filter);
            return PartialView("GRN_Items", _grnItems);
        }

        // Print Items Barcode Based On GRN
        [HttpPost]
        public async Task<ActionResult> PrintBarcodeService(string pr_code)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    List<BarcodeService> _barcodeService = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetBarcodePrintData(pr_code, empId);
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

        //Change Goods Received Notes Status
        [HttpPost]
        public ActionResult GRN_Status(string data, string status)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GRN_Status(data, status, empId);
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

        // Get GRN Audit Log Detail
        [HttpGet]
        public PartialViewResult grnAuditLogs_detail(int prId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.GRN_Log_list _grnLog = BusinessLogicLayer.Accounts.AuditLogs.GRN_Log.GetgrnAuditLogs(prId);

                return PartialView("GRN_AuditLogs", _grnLog);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Print Goods Received Notes Detail
        [HttpGet]
        public ActionResult PrintGoodsReceivedNote(int prId, int pr_branch)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                GRN_and_Items grn_print = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetGRN_Print(prId, pr_branch, empId);
                return View("GRN_Print", grn_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Goods Received Notes Documents
        #region Goods Received Notes Documents
        [HttpGet]
        public ActionResult GRN_Documents(int prId, string pr_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DocReference doc_ref = new DocReference();
                doc_ref.refId = prId;
                doc_ref.reftype = "Goods Received Notes";
                doc_ref.ref_name = pr_code;
                return PartialView("GRN_Documents", doc_ref);
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

                    string file_path = Server.MapPath("~/images/MaterialManagement/GoodsReceivedNotes/");

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
                    string folder = "GoodsReceivedNotes";
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
                bool val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.DeleteDocuments(docId, "Goods Received Notes");

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
                        string fileName = Path.Combine(Server.MapPath("~/images/MaterialManagement/GoodsReceivedNotes/"), row["file_path"].ToString().Trim());
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
                        string[] path = row["file_path"].ToString().Trim().ToString().Replace("\\", "/").Split(new string[] { "images/MaterialManagement/GoodsReceivedNotes" }, StringSplitOptions.None);
                        file.file = ConfigurationManager.AppSettings["ClinicSoftEndPoint"] + "images/MaterialManagement/GoodsReceivedNotes" + path[1].Trim().ToString();

                        file.id = id;
                        file.type = type;
                        return PartialView("GRN_ViewDocument", file);
                    }
                    else
                    {
                        return PartialView("GRN_ViewDocument", file);
                    }
                }
                else
                {
                    return PartialView("GRN_ViewDocument", file);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion Goods Received Notes Documents

        //Create Goods Received Notes 
        [HttpGet]
        public PartialViewResult CreateGRN()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;
                    return PartialView("CreateGRN");
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

        //Get Purchase Order on search
        [HttpGet]
        public ActionResult SearchPurchaseOrder(string query, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PurchaseOrderDDL> dt = BusinessLogicLayer.Accounts.MaterialManagement.GRN.SearchPurchaseOrder(query, branch);
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

        //Get Purchase Order Detail on Select Event
        [HttpGet]
        public ActionResult GetPurchaseOrderDetail(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrderItems> _purchaseOrderItems = new List<BusinessEntities.Accounts.MaterialManagement.PurchaseOrderItems>();
                    _purchaseOrderItems = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseOrders.GetPurchaseOrdersItems(id);
                    var jsonResult = Json(_purchaseOrderItems, JsonRequestBehavior.AllowGet);
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

        //Get UOM Detail on Select Event
        [HttpGet]
        public ActionResult GetUOMDetail(int piId, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PurchaseOrderDDL> dt = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetUOMDetail(piId);
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

        //Insert Goods Received Notes Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertGRN(GRN_and_Items data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.grn.pr_madeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidGRN(data, out errors))
                    {
                        string grn_code;
                        int pir_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.GRN.InsertGRN(data, out grn_code, out pir_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "GRN Added Successfully!", prCode = grn_code, prId = pir_Id }, JsonRequestBehavior.AllowGet);
                            }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Creating GRN!" }, JsonRequestBehavior.AllowGet);
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

        //Get Detail For Edit Goods Received Notes 
        [HttpGet]
        public ActionResult EditGRN(int prId, int pr_branch)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                GRN_and_Items grn_edit = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetGRN_Edit(prId, pr_branch, empId);
                
                return View("EditGRN", grn_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get UOM Detail on Select Event
        [HttpGet]
        public ActionResult GetEditGRN_UOMDetail(int pirId, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PurchaseOrderDDL> dt = BusinessLogicLayer.Accounts.MaterialManagement.GRN.GetEditGRN_UOMDetail(pirId);
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

        //Update Goods Received Notes Detail
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateGRN(GRN_and_Items data)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.grn.pr_madeby = PageControl.getLoggedinId();

                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidUpdateGRN(data, out errors))
                    {
                        string grn_code;
                        int pir_Id;
                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.GRN.UpdateGRN(data, out grn_code, out pir_Id);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "GRN Updated Successfully!", prCode = grn_code, prId = pir_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Creating GRN!" }, JsonRequestBehavior.AllowGet);
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
                TempData["ErrorMessage_Update"] = ex.Message;
            }

            return View();
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}