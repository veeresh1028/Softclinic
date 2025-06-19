using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Invoice.Controllers
{
    [Authorize]
    public class CreditNoteController : Controller
    {
        int PageId = (int)Pages.CreditNote;

        [HttpGet]
        public ActionResult CreditNoteIndex()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCreditNotes(BusinessEntities.Invoice.CreditNoteSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.CreditNote> invoiceList = new List<BusinessEntities.Invoice.CreditNote>();
                try
                {
                    invoiceList = BusinessLogicLayer.Invoice.CreditNote.GetCreditNotes(data);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Searched Credit Notes Page!"
                    });

                    var jsonResult = Json(invoiceList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(invoiceList, JsonRequestBehavior.AllowGet);
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
        public ActionResult SearchPatients(string query)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> dt = BusinessLogicLayer.Invoice.CreditNote.SearchInvoicedPatients(query);

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
        public PartialViewResult NewCreditNote()
        {
            int Action = (int)Actions.Create;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.CreditNote cn = BusinessLogicLayer.Invoice.CreditNote.AutoCreateCreditNoteCode();
                    cn.invc_no = cn.invc_no.Replace("CN-", "");

                    return PartialView("NewCreditNote", cn);
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
        public ActionResult GetPatientInvoiceList(int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Invoice.Invoice> list = new List<BusinessEntities.Invoice.Invoice>();

                try
                {
                    list = BusinessLogicLayer.Invoice.CreditNote.GetInvoiceByPatId(patId);

                    if (list.Count > 0)
                    {
                        return Json(new { isSuccess = true, data = list }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, data = list }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, data = list }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public PartialViewResult InvoicedCreditNotes(int invId)
        {
            int Action = (int)Actions.Create;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    CreditNoteViewModel list = BusinessLogicLayer.Invoice.CreditNote.GetCreditNoteByInvoice(invId);

                    return PartialView(list);
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
        public ActionResult CreateNewCreditNote(CreditNoteInvoiceWithArrayItems data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string cn_no = BusinessLogicLayer.Invoice.CreditNote.CreateNewCreditNote(data, PageControl.getLoggedinId());

                    if (data.items.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(cn_no))
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Created New Credit Note! Ref No. : {cn_no}"
                            });

                            return Json(new { isSuccess = true, message = "You have successfully created the Credit note. Refernce Number is : " + cn_no }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Error in creating the Credit Note" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Please select items to make credit note" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public ActionResult DeleteCreditNote(int invcId)
        {
            int Action = (int)Actions.Delete;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Invoice.CreditNote.DeleteCreditNote(invcId, PageControl.getLoggedinId());

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Credit Note with invcId = {invcId}"
                        });

                        return Json(new { isAuthorized = true, isSuccess = true, message = "Credit Note Deleted Successfully!" }, JsonRequestBehavior.AllowGet); ;
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, isSuccess = false, message = "Failed to Delete Credit Note!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, isSuccess = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isAuthorized = true, isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreditNotAuditLog(int invcId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Invoice.CreditNoteAudit> list = BusinessLogicLayer.Invoice.CreditNote.GetCreditNoteLog(invcId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Credit Note Audit Logs with invcId = {invcId}"
                    });

                    return PartialView(list);
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
        public ActionResult PrintCreditNote(int invcId)
        {
            int Action = (int)Actions.Print;

            if (PageControl.getLoggedinId() > 0)
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Invoice.CreditNotePrint print = BusinessLogicLayer.Invoice.CreditNote.PrintCreditNote(invcId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Credit Note with Credit Note Id = {invcId}"
                    });

                    return View("PrintCreditNote", print);
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
        public ActionResult PostCreditNoteToAccount(string data)
        {
            try
            {
                int isUpdated1 = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isUpdated1 = BusinessLogicLayer.Invoice.CreditNote.PostCreditNoteToAccount(data, empId);
                    if (isUpdated1 > 0)
                    {
                        return Json(new { isUpdated = 1, message = "Posted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isUpdated1 == -1)
                    {
                        return Json(new { isUpdated = -1, message = "Payment Posting Error to Accounts" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = isUpdated1, message = "Error While Posting Payment to Accounts!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = -3, message = "You are not authorized to perform this action!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { isUpdated = -4, message = ex.Message }, JsonRequestBehavior.AllowGet);
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