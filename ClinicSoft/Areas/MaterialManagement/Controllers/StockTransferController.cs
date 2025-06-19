using BusinessEntities.Accounts.MaterialManagement;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class StockTransferController : Controller
    {
        int directStock = (int)Pages.DirectStockTransfer;
        int requestStock = (int)Pages.StockTransferRequest;
        int transferStock = (int)Pages.TransferStock;

        #region Direct Stock Transfer
        public ActionResult DirectStockTransfer()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(directStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                List<DirectStockTransfer> mclist = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("DirectStockTransfer", mclist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Direct Stock Transfer Detail
        public JsonResult GetDirectStockTransfer(DirectStockTransferFilter filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(directStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                if (!string.IsNullOrEmpty(filter.from_date) && !string.IsNullOrEmpty(filter.to_date))
                {
                    filter.from_date = DateTime.Parse(filter.from_date).ToString("MM/dd/yyyy");
                    filter.to_date = DateTime.Parse(filter.to_date).ToString("MM/dd/yyyy");
                }
                List<DirectStockTransfer> mclist = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter);

                var jsonResult = Json(mclist, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Create Direct Stock Transfer
        [HttpGet]
        public PartialViewResult CreateDirectStockTransfer()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(directStock, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreateDirectStockTransfer");
                    //return PartialView("~/Areas/Accounting/Views/StockTransfer/DirectStockTransfer/CreateDirectStockTransfer.cshtml");
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

        //Search Direct Stock Transfer Items
        [HttpGet]
        public ActionResult SearchItems(string query, int branch, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(directStock, Action))
            {
                try
                {
                    List<AdjustmentDDL> dt = null;
                    if (!string.IsNullOrEmpty(query) && branch > 0)
                        dt = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.SearchItems(query, branch, type);
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
        public ActionResult GetBatchesDetail(string Item_code, int branchId, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(directStock, Action))
            {
                try
                {
                    List<AdjustmentDDL> rt_detail = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.GetBatchesDetail(Item_code, branchId, type);
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

        //Insert Direct Stock Transfer Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDirectStockTransfer(DirectStockTransferList data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(directStock, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidDirectStockTransfer(data, out errors))
                    {
                        int std_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.InsertDirectStockTransfer(data, madeby, out std_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Direct Stock Transfer Inserted Successfully!", stdId = std_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Inserting Direct Stock Transfer!", stdId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Not Authorized To Perform This Action!", stdId = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        //Change Direct Stock Transfer Status
        [HttpPost]
        public ActionResult DirectStockTransfer_Status(string data, string status)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(directStock, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.DirectStockTransfer_Status(data, status, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Transfer Qty Excceds Batch Qty" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Updating Status!" }, JsonRequestBehavior.AllowGet);
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

        // Get Direct Stock Transfer Audit Log Detail
        [HttpGet]
        public PartialViewResult DirectStockTransferAuditLogs(int stda_stdId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(directStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.DirectStockTransferLogsList _stdLog = BusinessLogicLayer.Accounts.AuditLogs.StockTransferLogs.DirectStockTransferAuditLogs(stda_stdId, empId);

                return PartialView("DirectStockTransferAuditLogs", _stdLog);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Print Direct Stock Transfer Detail
        [HttpGet]
        public ActionResult PrintDirectStockTransfer(string std_refno)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(directStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.std_refno = std_refno;
                filter.std_status = "New,Transfered";
                DirectStockTransferList mc_print = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.PrintDirectStockTransfer(filter);
                return View("DirectStockTransferPrint", mc_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Detail For Edit Direct Stock Transfer
        [HttpGet]
        public ActionResult DirectStockTransferEdit(int stdId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(directStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.stdId = stdId;                
                DirectStockTransfer std_edit = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter).FirstOrDefault();

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("EditDirectStockTransfer", std_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Update Direct Stock Transfer Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDirectStockTransfer(DirectStockTransfer data)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(directStock, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidDirectStockTransfer_Update(data, out errors))
                    {
                        int por_Id;
                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.UpdateDirectStockTransfer(data, madeby, out por_Id);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Direct Stock Transfer Updated Successfully!", porId = por_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Updating Direct Stock Transfer!", porId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = "Not Authorized To Perform This Action!", porId = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        [HttpPost]
        public ActionResult PostDirectStockTransferToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(directStock, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.PostDirectStockTransferToAccount(data, empId);
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
        #endregion

        #region Stock Transfer Request
        public ActionResult StockTransferRequest()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(requestStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                List<DirectStockTransfer> mclist = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("StockTransferRequest", mclist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        //Open Create Stock Transfer Request Modal
        [HttpGet]
        public PartialViewResult CreateStockTransferRequest()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(requestStock, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreateStockTransferRequest");
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

        // Get Stock Transfer Request Detail
        public JsonResult GetStockTransferRquestDetail(DirectStockTransferFilter filter)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(requestStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                filter.empId = empId;
                if (!string.IsNullOrEmpty(filter.from_date) && !string.IsNullOrEmpty(filter.to_date))
                {
                    filter.from_date = DateTime.Parse(filter.from_date).ToString("MM/dd/yyyy");
                    filter.to_date = DateTime.Parse(filter.to_date).ToString("MM/dd/yyyy");
                }
                List<StockTransferRequest> mclist = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetStockTransferRquestDetail(filter);

                var jsonResult = Json(mclist, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Items Detail on Select Event
        [HttpGet]
        public ActionResult GetRequestedItemDetail(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(requestStock, Action))
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

        //Insert Direct Stock Transfer Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertStockTransferRequest(StockTransferRequestList data)
        {
            try
            {
                bool isInserted = false;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(requestStock, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidStockTransferRequest(data, out errors))
                    {
                        int std_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.InsertStockTransferRequest(data, madeby, out std_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Stock Transfer Request Inserted Successfully!", stdId = std_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Inserting Stock Transfer Request!", stdId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Not Authorized To Perform This Action!", stdId = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        //Get Detail For Edit Stock Transfer Request
        [HttpGet]
        public ActionResult EditStockTransferRequest(int strId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(requestStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.stdId = strId;
                StockTransferRequest str_edit = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetStockTransferRquestDetail(filter).FirstOrDefault();

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("EditStockTransferRequest", str_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Update Stock Transfer Transfer Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStockTransferRequest(StockTransferRequest data)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(requestStock, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidStockTransferRequest_Update(data, out errors))
                    {
                        int por_Id;
                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.UpdateStockTransferRequest(data, madeby, out por_Id);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Stock Transfer Request Updated Successfully!", porId = por_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Updating Stock Transfer Request!", porId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = "Not Authorized To Perform This Action!", porId = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        // Get Stock Transfer Request Audit Log Detail
        [HttpGet]
        public PartialViewResult StockTransferRequestAuditLogs(int stra_strId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(requestStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.StockTransferRequestLogsList _strLog = BusinessLogicLayer.Accounts.AuditLogs.StockTransferLogs.StockTransferRequestAuditLogs(stra_strId, empId);

                return PartialView("StockTransferRequestAuditLogs", _strLog);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Change Direct Stock Transfer Status 
        [HttpPost]
        public ActionResult StockTransferRequest_Status(string data, string status)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(requestStock, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.StockTransferRequest_Status(data, status, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Transfer Qty Excceds Batch Qty" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Updating Status!" }, JsonRequestBehavior.AllowGet);
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

        //Print Direct Stock Transfer Detail
        [HttpGet]
        public ActionResult PrintStockTransferRequest(string str_refno)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(requestStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.std_refno = str_refno;
                filter.std_status = "New,Transfered";
                StockTransferRequestList mc_print = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.PrintStockTransferRequest(filter);
                return View("StockTransferRequestPrint", mc_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Transfer Stock Based on Request
        public ActionResult TransferStock()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(transferStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                List<DirectStockTransfer> mclist = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetDirectStockTransfer(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("TransferStock", mclist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        
        [HttpGet]
        public ActionResult OpenAllocateBatachesModal(int strId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(transferStock, Action))
            {
                int empId = PageControl.getLoggedinId();
                DirectStockTransferFilter filter = new DirectStockTransferFilter();
                filter.empId = empId;
                filter.stdId = strId;
                StockTransferRequest str_edit = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.GetStockTransferRquestDetail(filter).FirstOrDefault();

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View("AllocateBataches", str_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        //Update Stock Transfer Transfer Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AllocateBatchesToRequest(StockTransferRequest data)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(transferStock, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidAllocateBatches(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.StockTransfer.AllocateBatchesToRequest(data, madeby);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Stock Transfer Request Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Updating Stock Transfer Request!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = "Not Authorized To Perform This Action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
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