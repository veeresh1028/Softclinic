using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    [Authorize]
    public class NarrativeDiagnosisController : Controller
    {
        int PageId = (int)Pages.NarrativeDiagnosis;

        [HttpGet]
        public ActionResult NarrativeDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Narrative Diagnosis Page!"
                    });

                    return View("NarrativeDiagnosis");
                }
                else
                {
                    return View("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }
    }
}