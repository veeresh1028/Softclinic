using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Accounts.Masters;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class StockQtyAdjustmentController : Controller
    {
        int PageId = (int)Pages.StockQtyAdjustment;
        public ActionResult StockAdjustment()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                StockQtyAdjustment_filter filter = new StockQtyAdjustment_filter();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                List<BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetStockQtyAdjustment(filter);

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

        // Get Stock Qty Adjustment Detail
        public JsonResult GetStockQtyAdjustment(StockQtyAdjustment_filter filter)
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
                List<BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment> pinvlist = BusinessLogicLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetStockQtyAdjustment(filter);

                var jsonResult = Json(pinvlist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Create Stock Qty Adjustment
        [HttpGet]
        public PartialViewResult CreateStockQtyAdjustment()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreateStockAdjustment");
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

        //Get Items on search
        [HttpGet]
        public ActionResult SearchItems(string query, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<AdjustmentDDL> dt = null;
                    if(!string.IsNullOrEmpty(query) && branch > 0)
                        dt = BusinessLogicLayer.Accounts.MaterialManagement.StockQtyAdjustment.SearchItems(query, branch);
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

        //Get Batches Detail on Item Select Event
        [HttpGet]
        public ActionResult GetBatchesDetail(string Item_code, int branchId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<AdjustmentDDL> rt_detail = BusinessLogicLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetBatchesDetail(Item_code, branchId);
                    var jsonResult = Json(rt_detail, JsonRequestBehavior.AllowGet);
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

        // Get Items Batches Detail From Database
        [HttpGet]
        public JsonResult AdjustedBatch_Detail(int ibId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<ItemsBactch> ItemsAudtiLogsList = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemBatches(ibId, "", 0, empId);
                return Json(ItemsAudtiLogsList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Post Account for Stock Qty Adjustment
        public JsonResult GetPostToAccount(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                List<AdjustmentDDL> dt_AC = BusinessLogicLayer.Accounts.MaterialManagement.StockQtyAdjustment.GetPostToAccount_Assest(0 ,branchId);                
                return Json(dt_AC, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert Stock Qty Adjustment Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertStockQtyAdjustment(StockQtyAdjustment_List data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidStockQtyAdjustment(data, out errors))
                    {
                        string por_code;
                        int por_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.StockQtyAdjustment.InsertStockQtyAdjustment(data, madeby, out por_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Stock Qty Adjustment Inserted Successfully!", porId = por_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Inserting Stock Qty Adjustment!", porId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Not Authorized To Perform This Action!", porId = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage_Insert"] = ex.Message;
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