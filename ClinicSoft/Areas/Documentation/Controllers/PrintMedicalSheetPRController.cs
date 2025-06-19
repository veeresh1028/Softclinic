using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    public class PrintMedicalSheetPRController : Controller
    {
        int PageId = (int)Pages.PriorRequests;
        // GET: Documentation/PrintMedicalSheetPR
        public ActionResult PrintMedicalSheetPR()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Print Medical Sheet Page From Prior Requests!"
                });
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }

        }
    }
}