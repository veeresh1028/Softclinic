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
    public class MaterialsConsumptionController : Controller
    {
        int PageId = (int)Pages.MaterialsConsumption;
        public ActionResult MaterialsConsumptions()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                MaterialConsumption_filter filter = new MaterialConsumption_filter();
                filter.empId = empId;
                filter.from_date = DateTime.Now.ToString("MM/dd/yyyy");
                filter.to_date = DateTime.Now.ToString("MM/dd/yyyy");
                List<MaterialConsumption> mclist = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumption(filter);

                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                return View(mclist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Materials Consumption Detail
        public JsonResult GetMaterialsConsumption(MaterialConsumption_filter filter)
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
                List<MaterialConsumption> mclist = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumption(filter);

                var jsonResult = Json(mclist, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Get Doctors, Rooms and Madeby On Branch Change
        [HttpGet]
        public JsonResult GetDoctorsRoomsMadeby_ByBranch(int branchId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                MaterialOtherlist ddl_ist = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.GetDoctorsRoomsMadeby_ByBranch(branchId);
                return Json(ddl_ist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Get Materials Consumption Audit Log Detail
        [HttpGet]
        public PartialViewResult MaterialsConsumptionAuditLogs(int scra_scrId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.MaterialConsumptionLogList _porLog = BusinessLogicLayer.Accounts.AuditLogs.PurchaseInvoiceLogs.MaterialsConsumptionAuditLogs(scra_scrId);

                return PartialView("MaterialConsumptionAuditLog", _porLog);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        //Print Materials Consumption Detail
        [HttpGet]
        public ActionResult PrintMaterialsConsumption(int scr_refno)
        {
            int Action = (int)Actions.Print;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                MaterialConsumptionList mc_print = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumption_Print(scr_refno, empId);
                return View("MaterialConsumptionPrint", mc_print);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Get Items on search
        [HttpGet]
        public ActionResult SearchItems(string query, int branch, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
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

            if (PageControl.haveAccess(PageId, Action))
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

        // Get Batches Detail From Database
        [HttpGet]
        public JsonResult ConsumedBatch_Detail(int ibId)
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

        //Create Materials Consumption Request
        [HttpGet]
        public PartialViewResult CreateMaterialConsumptions()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;

                    return PartialView("CreateMaterialsConsumption");
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

        //Insert Materials Consumption Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertMaterialConsumptions(MaterialConsumptionList data)
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
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidMaterialConsumption(data, out errors))
                    {
                        string por_code;
                        int scr_Id;
                        isInserted = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.InsertMaterialsConsumptions(data, madeby, out scr_Id);
                        if (isInserted)
                        {
                            return Json(new { isInserted = true, message = "Material Consumptions Inserted Successfully!", scrId = scr_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error While Inserting Material Consumptions!", scrId = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = false, message = "Not Authorized To Perform This Action!", scrId = 0 }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        //Change Materials Consumption Request Status 
        [HttpPost]
        public ActionResult MaterialConsumption_Status(string data, string status)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.MaterialConsumption_Status(data, status, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Status Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if(isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Allocated Qty Excceds Batch Qty" }, JsonRequestBehavior.AllowGet);
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

        //Get Detail For Edit Materials Consumption
        [HttpGet]
        public ActionResult MaterialConsumptionEdit(int scrId)
        {
            int Action = (int)Actions.Update;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                MaterialConsumption scr_edit = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.GetMaterialsConsumptionEditDetail(scrId, empId);
                return View("MaterialConsumptionEdit", scr_edit);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Insert Materials Consumption Detail in Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMaterialConsumptions(MaterialConsumption data)
        {
            try
            {
                bool isUpdated = false;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidUpdateMaterialConsumption(data, out errors))
                    {
                        string por_code;
                        int por_Id;
                        isUpdated = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.UpdateMaterialsConsumptions(data, madeby, out por_Id);
                        if (isUpdated)
                        {
                            return Json(new { isUpdated = true, message = "Material Consumptions Updated Successfully!", porId = por_Id }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Error While Updating Material Consumptions!", porId = 0 }, JsonRequestBehavior.AllowGet);
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
        public ActionResult PostMaterialConsumptionToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Accounts.MaterialManagement.MaterialConsumption.PostMaterialConsumptionToAccount(data, empId);
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