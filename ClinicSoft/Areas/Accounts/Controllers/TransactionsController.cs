using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Accounts.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        int PageId = (int)Pages.Transactions;

        [HttpGet]
        public ActionResult Transactions()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetTransactionsDetail(TransactionsSearch data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.empId = PageControl.getLoggedinId();

                    List<BusinessEntities.Accounts.Accounting.Transaction> T_list = BusinessLogicLayer.Accounts.Accounting.Transaction.GetTransactionsDetail(data);

                    return Json(new { isAuthorized = true, message = "", T_list }, JsonRequestBehavior.AllowGet);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }

    }
}