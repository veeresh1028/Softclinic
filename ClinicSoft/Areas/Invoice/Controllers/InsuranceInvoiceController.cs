using BusinessEntities;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class InsuranceInvoiceController : Controller
    {
        int PageId = (int)Pages.Invoice;

        [HttpGet]
        public ActionResult EditSubInsuranceBilling(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                int appId = int.Parse(emr.appId);

                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfoByInvId(invId, appId);

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Insurance Treatments Edit Page from Invoice edit!"
                    });

                    TempData["Layout"] = "True";

                    return PartialView("EditInsuranceBilling", invoice_info);
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
        public ActionResult EditSubDentalInsuranceBilling(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);

                //BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfoByInvId(invId, appId);
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Dental Insurance Treatments Edit Page from Invoice Edit!"
                    });

                    TempData["Layout"] = "True";

                    return PartialView("EditDentalInsuranceBilling", invoice_info);
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
        public ActionResult EditDentalInsuranceBilling(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                int appId = int.Parse(emr.appId);

                BusinessEntities.EMR.PatientTreatments invoice_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Dental Insurance Treatments Edit Page from Invoice Edit!"
                    });

                    TempData["Layout"] = "True";

                    return PartialView("EditDentalInsuranceBilling", invoice_info);
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
        public PartialViewResult InsuranceTreatmentsModal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    BusinessEntities.EMR.PatientTreatments pt_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                    pt_info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Insurance");
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Insurance Treatments!"
                    });

                    return PartialView("InsuranceTreatmentsModal", pt_info);
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
        public PartialViewResult DentalInsuranceTreatmentsModal()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];

                    TempData.Keep("emr_data");

                    int appId = int.Parse(emr.appId);

                    BusinessEntities.EMR.PatientTreatments pt_info = BusinessLogicLayer.EMR.PatientTreatments.Get_InvoiceInfo(appId);
                    pt_info.InvNosList = BusinessLogicLayer.EMR.PatientTreatments.GetInvNosList(appId, "Insurance");
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Dental Insurance Treatments!"
                    });

                    return PartialView("DentalInsuranceTreatmentsModal", pt_info);
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
        public PartialViewResult QuickDentalCashBilling(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfo(appId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Viewed Quick Dental Cash Billing!"
                    });

                    if (qc_info.qc_invoice_info.invId > 0 && qc_info.qc_invoice_info.inv_type == "Cash")
                    {
                        BusinessEntities.Invoice.QuickCash edit_qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(qc_info.qc_invoice_info.invId);

                        return PartialView("EditDentalCashBilling", edit_qc_info);
                    }
                    else
                    {
                        return PartialView("QuickDentalCashBilling", qc_info);
                    }
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
        public PartialViewResult QuickDentalCashMultiBilling(int appId, int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                

                if (PageControl.haveAccess(PageId, Action))
                {
                    if (string.IsNullOrEmpty(invId.ToString()))
                    {
                        invId = 0;
                    }
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQCM_InvoiceInfo(appId, invId);
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Viewed Quick Dental Cash Billing!"
                    });

                    if (invId > 0)
                    {
                        BusinessEntities.Invoice.QuickCash edit_qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(invId);

                        return PartialView("QuickDentalCashMultiBilling", edit_qc_info);
                    }
                    else
                    {
                        return PartialView("QuickDentalCashBilling", qc_info);
                    }
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
        public ActionResult EditDentalCashBilling(int invId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.QuickCash qc_info = BusinessLogicLayer.Invoice.QuickCash.GetQC_InvoiceInfoByInvId(invId);

                    return PartialView("EditDentalCashBilling", qc_info);
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