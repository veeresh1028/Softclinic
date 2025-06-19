using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class AdvanceLoyaltyRefundController : Controller
    {
        int PageId = (int)Pages.AdvanceLoyaltyRefund;

        #region Advance / Loyalty / Refund (Page Load & Search)
        public ActionResult AdvanceLoyaltyRefundIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAdvanceLoyaltyRefund(BusinessEntities.Invoice.ReceiptSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.AdvanceLoyaltyRefund> dataList = new List<BusinessEntities.Invoice.AdvanceLoyaltyRefund>();
                try
                {
                    dataList = BusinessLogicLayer.Invoice.AdvanceLoyaltyRefund.GetAdvanceLoyaltyRefund(data);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Advance/Loyalty/Refund Page!"
                    });

                    var jsonResult = Json(dataList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(dataList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Advance / Loyalty / Refund CRUD Operations
        [HttpGet]
        public PartialViewResult NewReceipt()
        {
            int Action = (int)Actions.Create;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();

                    //BusinessEntities.Invoice.Receipts receipts = BusinessLogicLayer.Invoice.Receipts.AutoCreateReceiptCode(int.Parse(emp_branch));
                    BusinessEntities.Invoice.Receipts receipts = BusinessLogicLayer.Invoice.Receipts.AutoCreateReceiptCodes(int.Parse(emp_branch));

                    //receipts.rec_code = receipts.rec_code.Replace("REC-", "");

                    return PartialView("NewReceipt", receipts);
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
        public PartialViewResult EditReceipt(int recId, string mrn, string mobile, string name)
        {
            int Action = (int)Actions.Update;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    ReceiptWithInvoiceInfo rni = new ReceiptWithInvoiceInfo();

                    rni = BusinessLogicLayer.Invoice.Receipts.GetReceiptById(recId);

                    ReceiptPatient patient = new ReceiptPatient
                    {
                        patId = rni.receipts.rec_patient,
                        pat_code = mrn,
                        pat_name = name,
                        pat_mob = mobile
                    };
                    rni.patient = patient;

                    return PartialView("EditReceipt", rni);
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
        public ActionResult SearchPatients(string query, int type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Invoice.AdvanceLoyaltyRefund.SearchPatients(query, type);

                    var jsonResult = Json(dt, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(ex.Message, JsonRequestBehavior.AllowGet);
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
        public ActionResult RefundInvoiceByPatId(int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ReceiptAdvance> list = new List<ReceiptAdvance>();

                try
                {
                    list = BusinessLogicLayer.Invoice.AdvanceLoyaltyRefund.RefundInvoiceByPatId(patId);
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(list, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        [HttpGet]
        public PartialViewResult NewPackageReceipt(int poId, int patId, decimal po_pkg_price, DateTime rec_date)
        {
            int Action = (int)Actions.Update;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    Receipts rni = new Receipts();
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                    var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                    BusinessEntities.Invoice.Receipts receipts = BusinessLogicLayer.Invoice.Receipts.AutoCreateReceiptCode(int.Parse(emp_branch));
                    receipts.rec_code = receipts.rec_code.Replace("REC-", "");
                    rni = BusinessLogicLayer.Invoice.Receipts.GetReceiptPatient(poId, patId, rec_date, po_pkg_price, receipts.rec_code);

                    return PartialView("NewPackageReceipt", rni);
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
        public ActionResult PostToAccountReceipts(ReceiptsBulkStatus data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                int val = BusinessLogicLayer.Invoice.AdvanceLoyaltyRefund.PostToAccountReceipt(data, PageControl.getLoggedinId());

                if (val > 0)
                {
                    return Json(new { isSuccess = true, message = "Selected Receipt(s) Posted to Chart of Account" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Error while posting the Receipt to Chart of Account " }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

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