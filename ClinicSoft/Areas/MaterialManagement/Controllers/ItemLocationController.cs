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
    public class ItemLocationController : Controller
    {
        int PageId = (int)Pages.ItemLocation;
        // Item Location
        #region Stock Groups 

        // Get Item Location Detail on Page Load
        public ActionResult ItemLocation()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<ItemLocation> ItemLocationlist = BusinessLogicLayer.Accounts.Masters.ItemLocation.GetItemLocation(0, null, null, empId);

                return View(ItemLocationlist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Item Location Detail
        public JsonResult GetItemLocation()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<ItemLocation> GetItemLocationlist = BusinessLogicLayer.Accounts.Masters.ItemLocation.GetItemLocation(0, null, null, empId);

                return Json(GetItemLocationlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Open Partial View to Create Item Location
        [HttpGet]
        public PartialViewResult CreateItemLocation()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateItemLocation");
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

        // Insert New Item Location Detail in DataBase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertItemLocation(ItemLocation data)
        {
            try
            {
                int insert = 0;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidItemLocation(data, out errors))
                    {
                        data.empId = PageControl.getLoggedinId();
                        insert = BusinessLogicLayer.Accounts.Masters.ItemLocation.InsertUpdateItemLocation(data);
                        if (insert > 0)
                        {
                            return Json(new { isInserted = insert, message = "Stock Location Added Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if(insert == -1)
                        {
                            return Json(new { isInserted = insert, message = "Stock Location already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = insert, message = "Error while Creating Stock Location!" }, JsonRequestBehavior.AllowGet);
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

        // Get Data From Databse to Edit Item Location Detail By ilId
        [HttpGet]
        public PartialViewResult EditItemLocation(int ilId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<ItemLocation> ItemLocationList = BusinessLogicLayer.Accounts.Masters.ItemLocation.GetItemLocation(ilId, null, null, empId);

                return PartialView("EditItemLocation", ItemLocationList.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Update Item Location Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateItemLocation(ItemLocation data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    // Checking Valiadtion
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidItemLocation(data, out errors))
                    {
                        data.empId = PageControl.getLoggedinId();
                        isUpdated = BusinessLogicLayer.Accounts.Masters.ItemLocation.InsertUpdateItemLocation(data);
                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = true, message = "Stock Location Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Stock Location already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Update Item Location Status for Inactive or Delete
        [HttpPost]
        public ActionResult UpdateItemLocation_Status(int ilId, string il_status)
        {
            try
            {
                int isStatsuChanged = 0;
                int Action = 0;
                if (il_status == "Deleted")
                    Action = (int)Actions.Delete;
                else
                    Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isStatsuChanged = BusinessLogicLayer.Accounts.Masters.ItemLocation.UpdateItemLocation_Status(ilId, il_status, empId);
                    if (isStatsuChanged > 0)
                    {
                        if (il_status == "Deleted")
                            return Json(new { isAuthorized = true, success = true, message = "Stock Location Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isStatsuChanged == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Stock Location already exists with same name!" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}