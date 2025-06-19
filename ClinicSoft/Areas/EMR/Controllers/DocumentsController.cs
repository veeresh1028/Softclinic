using BusinessEntities;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class DocumentsController : Controller
    {
        #region Documents (Page Load)
        // GET: EMR/Documents

        int PageId = (int)Pages.Documents;
        public PartialViewResult Documents()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Documents Page!"
                    });
                    return PartialView("Documents");
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
        #endregion Documents (Page Load)

        #region Documents Favourites CRUD Operations
        // Create: Documents
        public PartialViewResult CreateDocument()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    DocReference doc_ref = new DocReference();
                    doc_ref.reftype = "EMR";


                    return PartialView("CreateDocument", doc_ref);
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
        public ActionResult GetPreDocumentsById(int id, string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                List<DocumentUpload> doc_data = new List<DocumentUpload>();
                try
                {
                    string path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString();
                    if (type == "Patient")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetPreviousDocumentsById(id, 1, path);
                    }
                    else if (type == "Employee")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetPreviousDocumentsById(id, 2, path);
                    }
                    else if (type == "Appointment")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetPreviousDocumentsById(id, 3, path);
                    }
                    else if (type == "EMR")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetPreviousDocumentsById(id, 5, path);
                    }
                    else if (type == "Investigation")
                    {
                        doc_data = BusinessLogicLayer.Common.Documents.GetPreviousDocumentsById(id, 6, path);
                    }
                    var jsonResult = Json(new { isAutherized = true, isSuccess = true, message = doc_data }, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    errors.Add("", ex.Message);
                    return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion Documents Favourites CRUD Operations

        #region OPGIOPA Images (Page Load)
        // GET: EMR/Documents

        public PartialViewResult OPGIOPAImages()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed OPGIOPA Images Page!"
                    });
                    return PartialView("OPGIOPAImages");
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
        #endregion OPGIOPA Images (Page Load)

        #region OPGIOPA Images CRUD Operations
        // Create: Documents
        public PartialViewResult CreateOPGIOPA()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    DocReference opg_iopa = new DocReference();
                    opg_iopa.reftype = "Investigation";


                    return PartialView("CreateOPGIOPA", opg_iopa);
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
        #endregion OPGIOPA Images CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}