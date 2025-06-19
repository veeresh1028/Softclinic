using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class UOMController : Controller
    {
        int PageId = (int)Pages.UOM;

        // UOM
        #region UOM

        // Get UOM Detail on Page Load

        public ActionResult UOM()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<UOM> uomlist = BusinessLogicLayer.Accounts.Masters.UOM.GetUOM(0, null, null, null, empId);

                return View(uomlist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Supplier Detail
        public JsonResult GetAllUOM()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<UOM> uomlist = BusinessLogicLayer.Accounts.Masters.UOM.GetUOM(0, null, null, null, empId);

                return Json(uomlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Open Partial View to Create UOM
        [HttpGet]
        public PartialViewResult CreateUOM()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateUOM");
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

        // Insert New UOM Detail in DataBase
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUOM(UOM data)
        {
            try
            {
                int inserted = 0;
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidUOM(data, out errors))
                    {
                        data.empId = PageControl.getLoggedinId();
                        inserted = BusinessLogicLayer.Accounts.Masters.UOM.InsertUpdateUOM(data);
                        if (inserted > 0)
                        {
                            return Json(new { isInserted = inserted, message = "UOM Added successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (inserted == -1)
                        {
                            return Json(new { isInserted = inserted, message = "UOM already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = inserted, message = "Error while Creating UOM!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = -2, message = errors }, JsonRequestBehavior.AllowGet);
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

        // Get Data From Databse to Edit UOM Detail By uomId
        [HttpGet]
        public PartialViewResult EditUOM(int uomId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<UOM> uom = BusinessLogicLayer.Accounts.Masters.UOM.GetUOM(uomId, null, null, null, empId);
                return PartialView("EditUOM", uom.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Update UOM Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUOM(UOM data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidUOM(data, out errors))
                    {
                        data.empId = PageControl.getLoggedinId();
                        isUpdated = BusinessLogicLayer.Accounts.Masters.UOM.InsertUpdateUOM(data);
                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = true, message = "UOM Updated successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "UOM already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Update UOM Status for Inactive or Delete
        [HttpPost]
        public ActionResult UpdateUOM_Status(int uomId, string uom_status)
        {
            try
            {
                int isStatsuChanged = 0;
                int Action = 0;
                if (uom_status == "Deleted")
                    Action = (int)Actions.Delete;
                else
                    Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isStatsuChanged = BusinessLogicLayer.Accounts.Masters.UOM.UpdateUOM_Status(uomId, uom_status, empId);

                    if (isStatsuChanged > 0)
                    {
                        if (uom_status == "Deleted")
                            return Json(new { isAuthorized = true, success = true, message = "UOM Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if(isStatsuChanged == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "UOM already exists with same name" }, JsonRequestBehavior.AllowGet);
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