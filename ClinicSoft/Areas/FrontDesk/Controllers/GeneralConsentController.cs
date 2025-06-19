using BusinessEntities;
using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.FrontDesk.Controllers
{
    [Authorize]
    public class GeneralConsentController : Controller
    {
        int PageId = (int)Pages.GeneralConsent;
        [HttpGet]
        public PartialViewResult GeneralConsent()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int appId = Convert.ToInt32(TempData["appId"]);

                List<BusinessEntities.FrontDesk.GeneralConsent> patientdetail = BusinessLogicLayer.FrontDesk.GeneralConsent.GetAppointmentPatient(appId);

                return PartialView("GeneralConsent", patientdetail.FirstOrDefault());
            }
            else
            {
                return PartialView("UnAuthorizedAccess");
            }
        }

        [HttpGet]
        public JsonResult GetGeneralConsentAll(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.FrontDesk.GeneralConsent> form = BusinessLogicLayer.FrontDesk.GeneralConsent.GetGeneralConsentAll(appId);

                var jsonResult = Json(form, JsonRequestBehavior.AllowGet);

                jsonResult.MaxJsonLength = int.MaxValue;

                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult InsertGeneralConsent(BusinessEntities.FrontDesk.GeneralConsent data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.gcf_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.FrontDesk.GeneralConsent.InsertUpdateGeneralConsent(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                        {
                            AJ_AJCId = 2,
                            AJ_AJSCId = 4,
                            AJ_AppId = data.appId
                        });

                        PDF _pdf = CreatePDF(data.gcf_appId, "GeneralConsent");

                        return Json(new { isInserted = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = "Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdateGeneralConsent(BusinessEntities.FrontDesk.GeneralConsent data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.gcf_madeby = PageControl.getLoggedinId();

                    isInserted = BusinessLogicLayer.FrontDesk.GeneralConsent.InsertUpdateGeneralConsent(data);

                    if (isInserted)
                    {
                        PDF _pdf = CreatePDF(data.gcf_appId, "GeneralConsent");

                        return Json(new { isInserted = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = "Form already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteGeneralConsent(int gcfId, string gcf_status)
        {
            try
            {
                bool success = false;
                bool isAuthorized = false;
                int Action = (int)Actions.Delete;
                int gcf_madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.FrontDesk.GeneralConsent.DeleteGeneralConsent(gcfId, gcf_status, gcf_madeby);

                    if (val > 0)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult PrintPDFGeneralConsent(int appId, string form)
        {
            try
            {
                int Action = (int)Actions.Print;
                int madeby = PageControl.getLoggedinId();

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();

                    if (pdf != null)
                    {
                        return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        PDF _pdf = CreatePDF(appId, form);

                        return Json(new { success = true, isAuthorized = true, message = _pdf }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public PDF CreatePDF(int appId, string form)
        {
            PDF _pdf = new PDF();

            try
            {
                int madeby = PageControl.getLoggedinId();
                string fileName = appId + "_" + form + ".pdf";
                string file_path = Server.MapPath("~/Documents/ConsentForms");

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
                }

                string path = Path.Combine(file_path, fileName);

                var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
                var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
                int setId = int.Parse(emp_branch);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlGeneralConsent(appId, setId);

                var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();

                var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);

                System.IO.File.WriteAllBytes(path, pdfBytes);

                if (System.IO.File.Exists(path))
                {
                    _pdf.pdfAppId = appId;
                    _pdf.pdfForm = form;
                    _pdf.pdfPath = path;
                    _pdf.pdfFileName = fileName;
                    _pdf.pdfUploadedBy = madeby;

                    bool isInserted = BusinessLogicLayer.Common.PDF.UploadDocument(_pdf);
                }

                return _pdf;
            }
            catch (Exception ex)
            {
                return _pdf;
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