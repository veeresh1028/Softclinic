using BusinessEntities;
using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.ConsentForms.Controllers
{
    public class TeethWhiteningArbController : Controller
    {
        int PageId = (int)Pages.DentalConsentForms;
        // GET: ConsentForms/TeethWhiteningArb
        public ActionResult TeethWhiteningArbIndex()
        {
            ViewBag.Tab = "0";

            return View();
        }
        public JsonResult GetTeethWhiteningArbData(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.ConsentForms.TeethWhiteningArb> list = BusinessLogicLayer.ConsentForms.TeethWhiteningArb.GetTeethWhiteningArbData(appId);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult CreateTeethWhiteningArb()
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                return PartialView("CreateTeethWhiteningArb");
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertTeethWhiteningArb(BusinessEntities.ConsentForms.TeethWhiteningArb data)
        {
            int isInserted = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.TeethWhiteningArb.isValidTeethWhiteningArb(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.ConsentForms.TeethWhiteningArb.SaveTeethWhiteningArb(data, madeby);

                        if (isInserted > 0)
                        {
                            PDF _pdf = CreatePDF(data.ctwa_appId, "TeethWhiteningArb");
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Teeth Whitening Arb Consent is already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }
        public PartialViewResult UpdateTeethWhiteningArb(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.ConsentForms.TeethWhiteningArb dental = BusinessLogicLayer.ConsentForms.TeethWhiteningArb.GetTeethWhiteningArbData(appId).FirstOrDefault();
                    return PartialView("UpdateTeethWhiteningArb", dental);
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
        [ValidateAntiForgeryToken]
        public ActionResult EditTeethWhiteningArb(BusinessEntities.ConsentForms.TeethWhiteningArb data)
        {
            bool isEdited = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.TeethWhiteningArb.isValidTeethWhiteningArb(data, out errors))
                    {
                        int val = BusinessLogicLayer.ConsentForms.TeethWhiteningArb.SaveTeethWhiteningArb(data, madeby);

                        if (val > 0)
                        {
                            PDF _pdf = CreatePDF(data.ctwa_appId, "TeethWhiteningArb");
                            return Json(new { isEdited = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isEdited = false, isSuccess = true, message = "Teeth Whitening Arb Consent is already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }
        [HttpPost]
        public ActionResult DeleteTeethWhiteningArb(int appId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.ConsentForms.TeethWhiteningArb.DeleteTeethWhiteningArb(appId, madeby);

                    if (val == 1)
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
        public PartialViewResult TeethWhiteningArbPreviousHistory(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = BusinessLogicLayer.ConsentForms.TeethWhiteningArb.GetTeethWhiteningArbPreviousHistory(appId);
                    return PartialView("TeethWhiteningArbPreviousHistory", list);
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
        public ActionResult PrintPDFConsent(int appId, string form)
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
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }


                string htmlContent = BusinessLogicLayer.ConcentForms.ConcentFormPDF.HtmlTeethWhiteningArb(appId, emr, setId);
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