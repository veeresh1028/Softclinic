using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.EMR;
using BusinessEntities.Tools;
using Newtonsoft.Json;
using RestSharp;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class CentralStoreController : Controller
    {
        #region CentralStore

        int PageId = (int)Pages.CentralStore;

        // Get CentralStore on Page Load
        public ActionResult CentralStore()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                ItemsFilter data = new ItemsFilter();
                data.empId = empId;

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["ItemGroupList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["ItemLocationList"] = ItemLocationList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Items Detail
        public JsonResult GetItems(ItemsFilter data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                data.empId = empId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItems(data);

                var jsonResult = Json(Itemslist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Open Partial View to Create New Stock Items
        [HttpGet]
        public PartialViewResult CreateItem()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                    SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                    ViewData["CategoryList"] = ItemGroupList;

                    DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                    SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                    ViewData["lcoationList"] = ItemLocationList;

                    DataTable dt_uom = BusinessLogicLayer.Accounts.Masters.CentralStore.GetUOMList(0);
                    SelectList UOMList = Models.Helper.ToSelectList(dt_uom, "uom", "uom");
                    ViewData["UOMList"] = UOMList;

                    return PartialView("CreateItem");
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

        // Update Items Status for Inactive or Delete
        [HttpPost]
        public ActionResult UpdateItems_Status(int itemId, string item_status)
        {
            try
            {
                int isStatsuChanged = 0;
                int Action = 0;
                if (item_status == "Deleted")
                    Action = (int)Actions.Delete;
                else
                    Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isStatsuChanged = BusinessLogicLayer.Accounts.Masters.CentralStore.UpdateItems_Status(itemId, item_status, empId);

                    if (isStatsuChanged > 0)
                    {
                        if (item_status == "Deleted")
                            return Json(new { isAuthorized = true, success = true, message = "Item Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { isAuthorized = true, success = true, message = "Item Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isStatsuChanged == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Item already exists with same name!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, success = false, message = "Unauthorised!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Opening Items Audit Logs View
        [HttpGet]
        public PartialViewResult ItemsAuditLog(string item_code)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.ItemsLog ItemsLogList = new BusinessEntities.Accounts.AuditLogs.ItemsLog();
                ItemsLogList.itema_code = item_code;
                return PartialView("ItemsAuditLog", ItemsLogList);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Items Audit Log Detail From Database
        [HttpGet]
        public JsonResult ItemAuditLog_Detail(string itema_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<BusinessEntities.Accounts.AuditLogs.ItemsLog> ItemsAudtiLogsList = BusinessLogicLayer.Accounts.AuditLogs.ItemsLog.GetItemsAuditLogs(itema_code);
                return Json(ItemsAudtiLogsList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Insert New Item in DataBase
        [HttpPost]
        public ActionResult InsertItem(Items data, HttpPostedFileBase[] files)
        {
            int Action = (int)Actions.Create;
            int insert = 0;
            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                try
                {
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidItemForm(data, out errors))
                    {
                        bool issuccess = false;

                        if (Request.Files.Count > 0)
                        //if (files.Length > 0)
                        {
                            string file_path = Server.MapPath("~/images/StockImage/");

                            if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                            }

                            if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                            }

                            if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                            }

                            foreach (var file in files)
                            {
                                if (file != null && file.ContentLength > 0)
                                {
                                    if (file.ContentLength <= 5242880)
                                    {
                                        issuccess = true;

                                        string _extension = Path.GetExtension(file.FileName);
                                        string _file_name = System.DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                        string _path = Path.Combine(file_path, _file_name);

                                        if (System.IO.File.Exists(_path))
                                        {
                                            System.IO.File.Delete(_path);
                                        }
                                        file.SaveAs(_path);
                                        data.item_image = _file_name;
                                        data.item_image_path = _path;
                                    }
                                }
                            }
                        }

                        data.item_madeby = PageControl.getLoggedinId();
                        data.item_opening_date = DateTime.Now.ToString("MM/dd/yyy");

                        insert = BusinessLogicLayer.Accounts.Masters.CentralStore.InsertUpdateItems(data);

                        if (insert > 0)
                        {
                            return Json(new { isInserted = insert, message = "Stock Item Added Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (insert == -1)
                        {
                            return Json(new { isInserted = insert, message = "Item already exists with same name or code!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = insert, message = "Error while Item Creating!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = -2, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add("db_error", ex.Message);
                    return Json(new { isInserted = 0, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Data From Databse to Edit Item Detail By itemId
        [HttpGet]
        public PartialViewResult EditItem(int itemId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Items data = new Items();
                int empId = PageControl.getLoggedinId();
                data.itemId = itemId;
                data.empId = empId;
                List<Items> items = BusinessLogicLayer.Accounts.Masters.CentralStore.GetAllItems(data);

                DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                ViewData["BranchList"] = branchlist;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["CategoryList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["lcoationList"] = ItemLocationList;

                DataTable dt_uom = BusinessLogicLayer.Accounts.Masters.CentralStore.GetUOMList(0);
                SelectList UOMList = Models.Helper.ToSelectList(dt_uom, "uom", "uom");
                ViewData["UOMList"] = UOMList;

                return PartialView("EditItem", items.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Update Item Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateItem(Items data)
        {
            try
            {
                int updated = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidItemForm(data, out errors))
                    {
                        HttpFileCollectionBase files = Request.Files;
                        if (files.Count > 0)
                        {
                            HttpPostedFileBase file = files[0];
                            string file_path = Server.MapPath("~/images/StockImage/");

                            if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                            }

                            if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                            }

                            if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                            }

                            if (file != null && file.ContentLength > 0)
                            {
                                if (file.ContentLength <= 5242880)
                                {
                                    string _extension = Path.GetExtension(file.FileName);
                                    string _file_name = System.DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                    string _path = Path.Combine(file_path, _file_name);

                                    if (System.IO.File.Exists(_path))
                                    {
                                        System.IO.File.Delete(_path);
                                    }
                                    file.SaveAs(_path);
                                    data.item_image = _file_name;
                                    data.item_image_path = _path;
                                }

                            }

                        }
                        data.item_madeby = PageControl.getLoggedinId();
                        data.item_opening_date = DateTime.Now.ToString("MM/dd/yyy");
                        updated = BusinessLogicLayer.Accounts.Masters.CentralStore.InsertUpdateItems(data);
                        if (updated > 0)
                        {
                            return Json(new { isUpdated = updated, message = "Stock Item Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (updated == -1)
                        {
                            return Json(new { isUpdated = updated, message = "Item already exists with same name or code!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = updated, message = "Error while Item Updating!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        // Opening Item Opening Stock Detail
        [HttpGet]
        public PartialViewResult ItemOpeningStock(Items data)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                return PartialView("ItemOpeningStock", data);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Insert Item Opening Stock
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertItemOpeningStock(Items data)
        {
            int Action = (int)Actions.Update;
            int isInserted = 0;
            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                try
                {
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidItems_OpeningStock(data, out errors))
                    {
                        data.item_madeby = PageControl.getLoggedinId();
                        isInserted = BusinessLogicLayer.Accounts.Masters.CentralStore.InsertItemOpeningStock(data);
                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = true, message = "Item opening stock added successfully!", code = 1 }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = false, message = "Item not available in this branch!", code = -1 }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error while adding item opening stock!", code = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors, code = -2 }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isInserted = false, message = ex.Message, code = -3 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Opening Item Batches View
        [HttpGet]
        public PartialViewResult ItemBatchesDetail(string item_code, int item_branch, string item_name, string branch_name)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                Items ItemsList = new Items();
                ItemsList.item_code = item_code;
                ItemsList.item_branch = item_branch;
                ItemsList.item_name = item_name;
                ItemsList.branch_name = branch_name;
                return PartialView("ItemBatchesDetail", ItemsList);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Items Batches Detail From Database
        [HttpGet]
        public JsonResult ItemBatches_Detail(string item_code, int item_branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<ItemsBactch> ItemsAudtiLogsList = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemBatches(0, item_code, item_branch, empId);
                return Json(ItemsAudtiLogsList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Opening Item Detail View
        [HttpGet]
        public PartialViewResult ItemsDetailView(int itemId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                ItemsFilter data = new ItemsFilter();
                data.empId = empId;
                data.itemId = itemId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItems(data);

                return PartialView("ItemsDetailView", Itemslist.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Data From Databse to Print Item Detail By ItemId
        [HttpGet]
        public PartialViewResult PrintItemDetail(int itemId)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                ItemsFilter data = new ItemsFilter();
                data.empId = empId;
                data.itemId = itemId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItems(data);
                return PartialView("PrintItemDetail", Itemslist.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Items History Detail
        [HttpGet]
        public PartialViewResult ItemHistory(int itemId, int item_branch, string item_code)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                ItemsHistory itemsHistory = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemHistory(itemId, item_code, item_branch, empId);

                return PartialView("ItemHistory", itemsHistory);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Check Decimal Value
        public decimal isDecimalValid(string value)
        {
            decimal return_value = 0;
            bool successfullyParsed = decimal.TryParse(value, out return_value);
            if (successfullyParsed)
            {
                return_value = decimal.Parse(value.ToString());
                return_value = decimal.Parse(return_value.ToString("N2"));
            }

            return return_value;
        }

        // Print Items Barcode
        [HttpPost]
        public async Task<ActionResult> PrintBarcodeService(BarcodeService data)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();
                    BarcodeService barcodeService = BusinessLogicLayer.Accounts.Masters.CentralStore.GetBarcodePrintData(data, empId);
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
                        return Json(new { isSuccess = true, message = response.Content, data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = response.Content, data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message, data = new { } }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Items Group On Branch Selection
        [HttpGet]
        public JsonResult GetItemGroup(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataTable dt_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroup(branchId);
                SelectList GroupList = Models.Helper.ToSelectList(dt_group, "igId", "ig_group");
                return Json(GroupList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
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