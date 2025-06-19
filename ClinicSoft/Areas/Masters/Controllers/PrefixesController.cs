using BusinessEntities;
using BusinessEntities.Appointment;
using ClinicSoft.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    public class PrefixesController : Controller
    {
        int PageId = (int)Pages.Prefixes;
        // GET: Masters/Prefixes
        [HttpGet]
        public ActionResult Prefixes()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Prefixes!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllPrefixes()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Prefixes> Prefixlist = BusinessLogicLayer.Masters.Prefixes.GetPrefixes(0);

                return Json(Prefixlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreatePrefixes()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Prefixes Prefix = new BusinessEntities.Masters.Prefixes();

                    Prefix.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("CreatePrefixes", Prefix);
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

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsertPrefixes(BusinessEntities.Masters.Prefixes data)
        {
            bool isInserted = false;
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                data.pfx_madeby = PageControl.getLoggedinId();

                isInserted = BusinessLogicLayer.Masters.Prefixes.InsertUpdatePrefix(data);

                if (isInserted)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = data.pfx_madeby,
                        log_desc = $"Employee Created New Prefixes for: {data.pfx_type}"
                    });

                    return Json(new { isInserted = true, isSuccess = true, message = "Prefixes Created Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isInserted = false, isSuccess = true, message = "Prefixes Already Exists!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public PartialViewResult EditPrefixes(int pfxId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Prefixes prefix = BusinessLogicLayer.Masters.Prefixes.GetPrefixes(pfxId).FirstOrDefault();

                    prefix.BranchList = BusinessLogicLayer.Company.GetBranchList();

                    return PartialView("EditPrefixes", prefix);
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
        public ActionResult UpdateVoucher(BusinessEntities.Masters.Prefixes data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();


                data.pfx_madeby = PageControl.getLoggedinId();

                isUpdated = BusinessLogicLayer.Masters.Prefixes.InsertUpdatePrefix(data);

                if (isUpdated)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Voucher with pfxId = {data.pfxId}"
                    });

                    return Json(new { isUpdated = true, isSuccess = true, message = "Voucher Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isUpdated = false, isSuccess = true, message = "Voucher Already Exists!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
    }
}