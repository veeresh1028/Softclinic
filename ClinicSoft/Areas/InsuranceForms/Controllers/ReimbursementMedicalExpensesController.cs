using BusinessEntities.EMR;
using BusinessEntities;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Security.Claims;
using BusinessEntities.Common;

namespace ClinicSoft.Areas.InsuranceForms.Controllers
{
    public class ReimbursementMedicalExpensesController : Controller
    {
        int PageId = (int)Pages.InsuranceForms;
        // GET: InsuranceForms/ReimbursementMedicalExpenses
        public ActionResult ReimbursementMedicalExpensesIndex()
        {
            ViewBag.Tab = "0";

            return View();
        }
        public JsonResult GetReimbursementMedicalExpensesData(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.InsuranceForms.ReimbursementMedicalExpenses> list = BusinessLogicLayer.InsuranceForms.ReimbursementMedicalExpenses.GetReimbursementMedicalExpensesData(appId);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult CreateReimbursementMedicalExpenses()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateReimbursementMedicalExpenses");
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


    }
}