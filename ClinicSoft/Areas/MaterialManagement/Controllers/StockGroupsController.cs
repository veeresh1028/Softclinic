using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class StockGroupsController : Controller
    {
        int PageId = (int)Pages.StockGroup;
        // Stock Groups
        #region Stock Groups 

        // Get Stock Groups Detail on Page Load
        public ActionResult StockGroups()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<StockGroup> StockGrouplist = BusinessLogicLayer.Accounts.Masters.StockGroup.GetStockGroup(0, null, null, null, empId);

                return View(StockGrouplist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Stock Groups Detail
        public JsonResult GetStockGroups()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<StockGroup> GetStockGroupslist = BusinessLogicLayer.Accounts.Masters.StockGroup.GetStockGroup(0, null, null, null, empId);

                return Json(GetStockGroupslist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Open Partial View to Create Stock Groups
        [HttpGet]
        public PartialViewResult CreateStockGroups()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;
                    return PartialView("CreateStockGroups");
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

        // Insert New Stock Groups Detail in DataBase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertStockGroups(StockGroup data)
        {
            try
            {
                int inserted = 0;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidStockGroup(data, out errors))
                    {
                        data.empId = PageControl.getLoggedinId();
                        inserted = BusinessLogicLayer.Accounts.Masters.StockGroup.InsertUpdateStockGroup(data);
                        
                        if (inserted > 0)
                        {
                            return Json(new { isInserted = inserted, message = "Stock Group Added Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (inserted == -1)
                        {
                            return Json(new { isInserted = inserted, message = "Stock Group already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = inserted, message = "Error while Creating Stock Group!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = -2, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return View();
        }

        // Get Data From Databse to Edit Stock Groups Detail By igId
        [HttpGet]
        public PartialViewResult EditStockGroups(int igId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<StockGroup> StockGroup = BusinessLogicLayer.Accounts.Masters.StockGroup.GetStockGroup(igId, null, null, null, empId);
                DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");

                ViewData["BranchList"] = branchlist;
                return PartialView("EditStockGroups", StockGroup.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Update Stock Groups Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStockGroups(StockGroup data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidStockGroup(data, out errors))
                    {
                        data.empId = PageControl.getLoggedinId();
                        isUpdated = BusinessLogicLayer.Accounts.Masters.StockGroup.InsertUpdateStockGroup(data);
                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = true, message = "Stock Group Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Stock Group already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        // Update Stock Groups Status for Inactive or Delete
        [HttpPost]
        public ActionResult UpdateStockGroups_Status(int igId, string ig_status)
        {
            try
            {
                int isStatsuChanged = 0;
                int Action = 0;
                if (ig_status == "Deleted")
                    Action = (int)Actions.Delete;
                else
                    Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isStatsuChanged = BusinessLogicLayer.Accounts.Masters.StockGroup.UpdateStockGroup_Status(igId, ig_status, empId);

                    if (isStatsuChanged > 0)
                    {
                        if (ig_status == "Deleted")
                            return Json(new { isAuthorized = true, success = true, message = "Stock Group Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isStatsuChanged == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Stock Group already exists with same name!" }, JsonRequestBehavior.AllowGet);
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

        // Opening Stock Group's Items View
        [HttpGet]
        public PartialViewResult ViewStockGroupItems(int igId, int ig_branch)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                Items data = new Items();
                data.item_category = igId;
                data.item_branch = ig_branch;
                data.empId = empId;
                List<Items> Itemslist = BusinessLogicLayer.Accounts.Masters.CentralStore.GetAllItems(data);
                return PartialView("ViewStockGroupItems", Itemslist);
            }
            else
            {
                return PartialView("_Unauthorized");
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