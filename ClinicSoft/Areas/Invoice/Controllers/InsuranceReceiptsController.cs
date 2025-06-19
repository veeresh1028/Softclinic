using BusinessEntities;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class InsuranceReceiptsController : Controller
    {
        int PageId = (int)Pages.Receipts;

        #region Receipt for Invoices (Page Load & Search)
        [HttpGet]
        public PartialViewResult InsuranceInvoiceReceipt(int invId, int patId, string rec_date)
        {
            int Action = (int)Actions.Read;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    ReceiptInsuranceViewModel dataModel = BusinessLogicLayer.Invoice.Receipts.GetAllInsReceiptsForInvoice(invId, patId, rec_date);

                    return PartialView(dataModel);
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
        public JsonResult GetInsuranceInvoiceReceipt(int invId, int patId, string rec_date)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                ReceiptInsuranceViewModel dataModel = BusinessLogicLayer.Invoice.Receipts.GetAllInsReceiptsForInvoice(invId, patId, rec_date);

                return Json(new { response = dataModel }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { response = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetInsReceiptById(int recId)
        {
            int Action = (int)Actions.Read;

            ReceiptWithInvoiceInfo rni = new ReceiptWithInvoiceInfo();
            Receipts r = new Receipts();

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    rni = BusinessLogicLayer.Invoice.Receipts.GetInsReceiptById(recId);
                    r = rni.receipts;

                    if (r.recId > 0 && r.total > 0)
                    {
                        return Json(new { isAuthorized = true, isSuccess = true, data = r, message = "" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, data = r, message = "No Receipt Found!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isAuthorized = true, isSuccess = false, data = r, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, data = r, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
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