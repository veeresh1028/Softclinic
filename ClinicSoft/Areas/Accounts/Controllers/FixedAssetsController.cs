using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Accounts.MaterialManagement;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class FixedAssetsController : Controller
    {
        int PageId = (int)Pages.FixedAssets;
        public ActionResult FixedAssets()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
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
        public JsonResult GetFixedAssets(BusinessEntities.Accounts.Accounting.FixedAssetsFilter data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.FixedAssets> FT_list = BusinessLogicLayer.Accounts.Accounting.FixedAssets.GetFixedAssets(data);

                    return Json(new { isAuthorized = true, message = "", FT_list }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult CreateFixedAsset()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    BusinessEntities.Accounts.Accounting.FixedAssets ftl = new BusinessEntities.Accounts.Accounting.FixedAssets();
                    ftl.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    ftl.fa_branch = Convert.ToInt32(emp_branch);

                    return PartialView("CreateFixedAsset", ftl);
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

        [HttpGet]
        public ActionResult SearchItems(string query, int branch, int groupId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<PurchaseOrderDDL> dt = BusinessLogicLayer.Accounts.Accounting.FixedAssets.SearchItems(query, branch, groupId);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertFixedAsset(BusinessEntities.Accounts.Accounting.FixedAssets data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.fa_created_by = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidFixedAssets(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.FixedAssets.InsertFixedAsset(data);

                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = isInserted, message = "Fixed Asset Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Fixed Asset Already Exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Inserting Fixed Asset!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = 0, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult EditFixedAsset(int faId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Accounts.Accounting.FixedAssetsFilter data = new BusinessEntities.Accounts.Accounting.FixedAssetsFilter();
                    data.faId = faId;
                    data.empId = PageControl.getLoggedinId();
                    List<BusinessEntities.Accounts.Accounting.FixedAssets> FT_list = BusinessLogicLayer.Accounts.Accounting.FixedAssets.GetFixedAssets(data);

                    return PartialView("EditFixedAsset", FT_list.FirstOrDefault());
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
        public ActionResult UpdateFixedAsset(BusinessEntities.Accounts.Accounting.FixedAssets data)
        {
            try
            {
                int isUpdate = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.fa_created_by = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Accounts.isValidFixedAssets(data, out errors))
                    {
                        isUpdate = BusinessLogicLayer.Accounts.Accounting.FixedAssets.InsertFixedAsset(data);

                        if (isUpdate > 0)
                        {
                            return Json(new { isUpdate = isUpdate, message = "Fixed Asset Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isUpdate == -1)
                        {
                            return Json(new { isUpdate = -1, message = "Fixed Asset Already Exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdate = 0, message = "Error While Updating Fixed Asset!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isUpdate = 0, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdate = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult ChangeFixedAssetStatus(int faId, int fa_branch, string status, string action_date, string post_check)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    int ischanged = BusinessLogicLayer.Accounts.Accounting.FixedAssets.ChangeFixedAssetStatus(faId, fa_branch, status, empId, action_date, post_check);

                    if (ischanged > 0)
                    {
                        return Json(new { isUpdated = true, success = true, message = "Fixed Asset Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = true, success = false, message = "Error While Changing Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PartialViewResult GetAssetDepreciations(int faId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    List<AssetsDepreciations> _logsList = BusinessLogicLayer.Accounts.Accounting.FixedAssets.GetAssetDepreciationsDetail(faId, 0, 0, empId);

                    return PartialView("FixedAssetDepreciation", _logsList);
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
        public ActionResult ChangeAssetDepreciationStatus(int adId, string status, int faId)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();

                    int ischanged = BusinessLogicLayer.Accounts.Accounting.FixedAssets.ChangeAssetDepreciationStatus(adId, status, empId);

                    if (ischanged > 0)
                    {
                        List<AssetsDepreciations> ad_list = BusinessLogicLayer.Accounts.Accounting.FixedAssets.GetAssetDepreciationsDetail(faId, 0, 0, empId);

                        return Json(new { isUpdated = true, success = true, message = "Asset Depreciation Status Changed Successfully!", list = ad_list }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = true, success = false, message = "Error While Changing Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, success = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertDepreciationMonths(BusinessEntities.Accounts.Accounting.DepreciationMonth data)
        {
            try
            {
                int isInserted = 0;
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.created_by = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (data.faId > 0 && data.months > 0)
                    {
                        isInserted = BusinessLogicLayer.Accounts.Accounting.FixedAssets.InsertDepreciationMonths(data);

                        if (isInserted > 0)
                        {
                            List<AssetsDepreciations> ad_list = BusinessLogicLayer.Accounts.Accounting.FixedAssets.GetAssetDepreciationsDetail(data.faId, 0, 0, data.created_by);
                            return Json(new { isInserted = isInserted, message = "Depreciation Posted Successfully!", list = ad_list }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = -1, message = "Depreciation Already Exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = 0, message = "Error While Posting Depreciation!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        errors.Add("post_month", "Select month");
                        errors.Add("post_month", "Select Fixed Asset ID");
                        return Json(new { isInserted = 0, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isInserted = 0, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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