using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities.Common;
using BusinessEntities;
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

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class PurchaseRequestsController : Controller
    {
        int PageId = (int)Pages.PurchaseRequests;

        #region Purchase Requests (Page Load)
        [HttpGet]
        public ActionResult PurchaseRequests()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");

                ViewData["BranchList"] = BranchList;

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetPurchaseRequests(PurchaseRequestFilters filter)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    int empId = PageControl.getLoggedinId();

                    filter.empId = empId;

                    if (!string.IsNullOrEmpty(filter.from_date) && !string.IsNullOrEmpty(filter.to_date))
                    {
                        filter.from_date = DateTime.Parse(filter.from_date).ToString("MM/dd/yyyy");
                        filter.to_date = DateTime.Parse(filter.to_date).ToString("MM/dd/yyyy");
                    }

                    List<PurchaseRequests> purchaseRequestslist = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequests(filter);

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
        public PartialViewResult PurchaseRequestItems()
        {
            DataTable dt_uom = BusinessLogicLayer.Accounts.Masters.CentralStore.GetUOMList(0);

            SelectList UOMList = Models.Helper.ToSelectList(dt_uom, "uom", "uom");

            ViewData["UOMList"] = UOMList;

            return PartialView();
        }

        [HttpGet]
        public ActionResult GetChildTableItems(int purqId)
        {
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseRequestItems> _purchaseRequestItems = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.GetChildTableItems(purqId);

            return PartialView("PurchaseItems", _purchaseRequestItems);
        }

        [HttpGet]
        public ActionResult GetPurchaseItems(int purqId)
        {
            List<BusinessEntities.Accounts.MaterialManagement.PurchaseRequestItems> _purchaseRequestItems = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequestItems(purqId);

            return PartialView("PurchaseItems", _purchaseRequestItems);
        }
        #endregion

        #region Load Dropdowns
        [HttpGet]
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
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

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

        [HttpGet]
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
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Purchase Requests (CRUD Operations)
        [HttpGet]
        public PartialViewResult CreatePurchaseRequest()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreatePurchaseRequest");
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
        [ValidateAntiForgeryToken]
        public ActionResult InsertPurchaseRequest(PurchaseRequestsAndItems data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isInserted = false;

                    data.purchaseRequests.empId = PageControl.getLoggedinId();
                    data.purchaseRequests.purq_omadeby = data.purchaseRequests.empId;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPurchaseRequestInsert(data, out errors))
                    {
                        string purq_code;

                        int purq_Id;

                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.InsertPurchaseRequest(data, out purq_code, out purq_Id);

                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Purchase Request Created Successfully!", purqCode = purq_code, purqId = purq_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Creating Purchase Request!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Session Expired!" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult EditPurchaseRequest(int purqId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                PurchaseRequestsAndItems PR_edit = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequestPrint(purqId, empId);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("EditPurchaseRequest", PR_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePurchaseRequest(PurchaseRequestsAndItems data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isUpdated = false;

                    data.purchaseRequests.empId = PageControl.getLoggedinId();
                    data.purchaseRequests.purq_omadeby = data.purchaseRequests.empId;

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.MaterialManagement.isValidPurchaseRequestUpdate(data, out errors))
                    {
                        string purq_code;
                        int purq_Id;

                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.InsertPurchaseRequest(data, out purq_code, out purq_Id);

                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Purchase Request Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Updating Purchase Request!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Session Expired!" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult PrintPurchaseRequest(int purqId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                PurchaseRequestsAndItems PO_print = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.GetPurchaseRequestPrint(purqId, empId);

                return View("PrintPurchaseRequest", PO_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeletePurchaseRequest(string data, string status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isDeleted = false;

                    int empId = PageControl.getLoggedinId();

                    isDeleted = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.PurchaseRequestActionStatus(data, status, empId);

                    if (isDeleted)
                    {
                        return Json(new { isUpdatisDeleteded = true, message = "Purchase Request Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isDeleted = false, message = "Error While Deleting Purchase Request!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isDeleted = false, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isDeleted = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeletePurchaseRequestItems(string data)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<int> prqiId = new List<int>();
                    string[] arr = data.Split(',');

                    foreach (string str in arr)
                    {
                        prqiId.Add(int.Parse(str));
                    }

                    int val = BusinessLogicLayer.Accounts.MaterialManagement.PurchaseRequests.DeletePurchaseRequestItems(prqiId, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        return Json(new { isSuccess = true, message = val }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = 0 }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Purchase Requests Audit Logs
        [HttpGet]
        public PartialViewResult PurchaseRequestAuditLogs(string purqa_ocode)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs log = new BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs();

                log.purqa_ocode = purqa_ocode;

                return PartialView("PurchaseRequestAuditLogs", log);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        [HttpGet]
        public JsonResult GetPurchaseRequestLogs(string purqa_ocode)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();

                List<BusinessEntities.Accounts.AuditLogs.PurchaseRequestLogs> _purchaseRequestsLogs = BusinessLogicLayer.Accounts.AuditLogs.PurchaseRequestLogs.GetPurchaseRequestAuditLogs(purqa_ocode);

                return Json(_purchaseRequestsLogs, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
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