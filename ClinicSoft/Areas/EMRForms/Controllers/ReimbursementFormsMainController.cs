using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMRForms;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMRForms.Controllers
{
    [Authorize]
    public class ReimbursementFormsMainController : Controller
    {
        int PageId = (int)Pages.Forms;

        [HttpGet]
        public PartialViewResult ReimbursementFormsMain(BusinessEntities.EMRForms.ReimbursementFormsMain reimb)
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
                        log_desc = "Employee Viewed ReimbursementFormsMain Page!"
                    });
                    return PartialView("ReimbursementFormsMain", reimb);
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
        
        public ActionResult GetEMRTabMaster_for_Reimb_Forms(string query)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDLFORMS> emr_tabs = BusinessLogicLayer.EMR.Addendum.GetEMRTabMaster_for_Reimb_Forms(query);
                    var jsonResult = Json(emr_tabs, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(0, JsonRequestBehavior.AllowGet);
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
        public ActionResult LoadView(string viewName)
        {
            try
            {
                // Assuming your custom views are located in the "Custom" folder within your custom area
                string viewPath = $"~/Areas/EMRForms/Views/ReimbursementForms/{viewName}.cshtml";

                // Render the view and capture its HTML content
                var viewResult = View(viewPath);
                var viewContent = RenderViewToString(this.ControllerContext, viewResult);

                // Return the HTML content as a JSON response
                return Content(viewContent, "text/html");
            }
            catch (Exception ex)
            {
                // Handle any errors gracefully
                Console.WriteLine(ex.Message);
                return Content($"Error loading view: {ex.Message}", "text/html");
            }
        }

        protected string RenderViewToString(ControllerContext context, ViewResultBase viewResult)
        {
            using (var sw = new StringWriter())
            {
                var viewEngineResult = ViewEngines.Engines.FindView(context, viewResult.ViewName, null);
                var viewContext = new ViewContext(context, viewEngineResult.View, viewResult.ViewData, viewResult.TempData, sw);
                viewEngineResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
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