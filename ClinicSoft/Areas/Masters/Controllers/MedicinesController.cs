using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using BusinessEntities.Masters;
using Google.Type;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class MedicinesController : Controller
    {
        int PageId = (int)Pages.Medicines;

        #region Medicines Master (Page Load)
        [HttpGet]
        public ActionResult Medicines()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                ViewData["BranchList"] = BranchList;

                DataTable dt_item_group = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemGroups(0);
                SelectList ItemGroupList = Models.Helper.ToSelectList(dt_item_group, "igId", "ig_group");
                ViewData["ItemGroupList"] = ItemGroupList;

                DataTable dt_item_location = BusinessLogicLayer.Accounts.Masters.CentralStore.GetItemLocations(0);
                SelectList ItemLocationList = Models.Helper.ToSelectList(dt_item_location, "ilId", "il_location");
                ViewData["ItemLocationList"] = ItemLocationList;

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Medicines!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetMedicines(MedicinesFilter data)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    data.empId = empId;

                    List<BusinessEntities.Masters.Medicines> medicines = BusinessLogicLayer.Masters.Medicines.SearchMedicines(data);

                    var jsonResult = Json(medicines, JsonRequestBehavior.AllowGet);

                    jsonResult.MaxJsonLength = int.MaxValue;

                    return jsonResult;
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Medicines CRUD Operations
        [HttpGet]
        public PartialViewResult CreateMedicine()
        {
            int Action = (int)Actions.Create;

            if (PageControl.getLoggedinId() > 0)
            {
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

                    return PartialView("CreateMedicine");
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
        public ActionResult InsertMedicine(BusinessEntities.Masters.Medicines data)
        {
            bool isInserted = false;

            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                data.item_madeby = PageControl.getLoggedinId();
                data.item_opening_date = DateTime.Now.ToString("MM/dd/yyy");

                isInserted = BusinessLogicLayer.Masters.Medicines.InsertUpdateMedicine(data);

                if (isInserted)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Created New Medicine : {data.item_code}"
                    });

                    return Json(new { isInserted = true, isAuthorized = true, message = "Medicine Created Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isInserted = false, isAuthorized = true, message = "Medicine Already Exists!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isInserted = false, isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult EditMedicine(int itemId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.getLoggedinId() > 0)
            {
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

                    BusinessEntities.Masters.Medicines Medicine = BusinessLogicLayer.Masters.Medicines.GetMedicine(itemId).FirstOrDefault();



                    return PartialView("EditMedicine", Medicine);
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
        public ActionResult UpdateMedicine(BusinessEntities.Masters.Medicines data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                //if (SecurityLayer.FormValidations.Medicines.isValidMedicines(data, out errors))
                //{
                isUpdated = BusinessLogicLayer.Masters.Medicines.InsertUpdateMedicine(data);

                if (isUpdated)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Medicine with itemId = {data.itemId}"
                    });

                    return Json(new { isUpdated = true, isSuccess = true, message = "Medicine Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isUpdated = false, isSuccess = true, message = "Medicine Already Exists!" }, JsonRequestBehavior.AllowGet);
                }
                //}
                //else
                //{
                //    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                //}
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult UpdateMedicinestatus(int itemId, string item_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Medicines.UpdateMedicinestatus(itemId, item_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Medicine Status to : {item_status} with itemId = {itemId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Medicine Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Medicine with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Medicine Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult DeleteMedicinestatus(int itemId, string item_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Medicines.UpdateMedicinestatus(itemId, item_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Medicine with itemId = {itemId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Medicine Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Medicine!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Medicines Import (DHA / MOH)
        [HttpPost]
        public ActionResult InsertDHA_Prescriptions()
        {
            try
            {
                int Action = (int)Actions.Create;

                int val = 0;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.Medicines> medicines = new List<BusinessEntities.Masters.Medicines>();
                    var client = new RestClient("http://visionsoftwares.dyndns.org:5019/items.asmx");
                    var request = new RestRequest("GET_ITEMS", Method.Get);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        int branchId = 0;
                        var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                        var bid = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                        int.TryParse(bid, out branchId);

                        medicines = JsonConvert.DeserializeObject<List<BusinessEntities.Masters.Medicines>>(response.Content);

                        int madeby = PageControl.getLoggedinId();
                        string ins_plan = "DHA";

                        val = BusinessLogicLayer.Masters.Medicines.InsertDHAMOH_Prescriptions(medicines, ins_plan, madeby, branchId);
                    }

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Impoted DHA Prescriptions"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "DHA Medicines Imported Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Import DHA Medicines!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult InsertMOH_Prescriptions()
        {
            try
            {
                int Action = (int)Actions.Create;
                int val = 0;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.Medicines> Medicines = new List<BusinessEntities.Masters.Medicines>();
                    var client = new RestClient("http://visionsoftwares.dyndns.org:5019/items.asmx");
                    var request = new RestRequest("GET_ITEMS_MOH", Method.Get);
                    var response = client.Execute(request);

                    if (response.IsSuccessful)
                    {
                        int branchId = 0;
                        var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                        var bid = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                        int.TryParse(bid, out branchId);

                        Medicines = JsonConvert.DeserializeObject<List<BusinessEntities.Masters.Medicines>>(response.Content);

                        int madeby = PageControl.getLoggedinId();
                        var type = "MOH";

                        val = BusinessLogicLayer.Masters.Medicines.InsertDHAMOH_Prescriptions(Medicines, type, madeby, branchId);
                    }

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Impoted MOH Prescriptions"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "MOH Medicines Imported Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Import MOH Medicines!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Miscellaneous Functions
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            bool isPartial = filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            TempData["error"] = filterContext;

            string actionName = isPartial ? "ErrorPartialView" : "Error";

            filterContext.Result = RedirectToAction(actionName, "Error", new { area = "Common" });
        }
        #endregion
    }
}