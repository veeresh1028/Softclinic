using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    public class ReimbursementFormsMainPRController : Controller
    {
        int PageId = (int)Pages.PriorRequests;
        // GET: Documentation/ReimbursementFormsMainPR
        public PartialViewResult ReimbursementFormsMainPR(BusinessEntities.EMRForms.ReimbursementFormsMain reimb)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    reimb.SelectedOptionList = BusinessLogicLayer.EMRForms.ReimbursementFormsMain.GetReimbForms();
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed ReimbursementFormsMainPR Page!"
                    });
                    return PartialView("ReimbursementFormsMainPR", reimb);
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