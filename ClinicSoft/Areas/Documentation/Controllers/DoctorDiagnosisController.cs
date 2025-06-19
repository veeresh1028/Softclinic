using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    [Authorize]
    public class DoctorDiagnosisController : Controller
    {
        int PageId = (int)Pages.PatientDiagnosis;

        [HttpGet]
        public ActionResult DoctorDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Patient Diagnosis Page!"
                    });

                    return View("DoctorDiagnosis");
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