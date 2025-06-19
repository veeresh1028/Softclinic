using System;
using System.IO;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Tab.Controllers
{
    [Authorize]
    public class ConsentFormsController : Controller
    {
        [HttpGet]
        public ActionResult GeneralConsentForms()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ClaimForms()
        {
            BusinessEntities.Tab.ClaimForms cf = new BusinessEntities.Tab.ClaimForms();
            cf.claimOptionList = BusinessLogicLayer.Tab.PatientConsents.GetClaimForms();

            return View(cf);
        }

        [HttpGet]
        public ActionResult LoadClaimFormView(string viewName)
        {
            try
            {
                string view = viewName.Replace("Index", "");

                string viewPath = $"~/Areas/InsuranceForms/Views/{view}/{viewName}.cshtml";

                ViewBag.Tab = "1";

                var viewResult = View(viewPath);
                
                var viewContent = RenderViewToString(this.ControllerContext, viewResult);

                return Content(viewContent, "text/html");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
             
                return Content($"Error loading view: {ex.Message}", "text/html");
            }
        }

        [HttpGet]
        public ActionResult ReiumbursementForms()
        {
            BusinessEntities.EMRForms.ReimbursementFormsMain reimb = new BusinessEntities.EMRForms.ReimbursementFormsMain();

            reimb.SelectedOptionList = BusinessLogicLayer.EMRForms.ReimbursementFormsMain.GetReimbForms();

            return View(reimb);
        }

        [HttpGet]
        public ActionResult TreatmentForms()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoadTreatmentFormView(string viewName)
        {
            try
            {
                string view = viewName.Replace("Index", "");

                string viewPath = $"~/Areas/ConsentForms/Views/{view}/{viewName}.cshtml";

                ViewBag.Tab = "1";

                var viewResult = View(viewPath);

                var viewContent = RenderViewToString(this.ControllerContext, viewResult);

                return Content(viewContent, "text/html");
            }
            catch (Exception ex)
            {
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

            filterContext.Result = RedirectToAction("ErrorTab", "Common", new { area = "Tab" });
        }
    }
}