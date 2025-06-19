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
    public class OrthoEvaluationNewController : Controller
    {
        int PageId = (int)Pages.OphthalmologyConsentForms;
        // GET: ConsentForms/OrthoEvaluationNew
        public ActionResult OrthoEvaluationNewIndex()
        {
            ViewBag.Tab = "0";

            return View();
        }
        public JsonResult GetOrthoEvaluationNewData(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.ConsentForms.OrthoEvaluationNew> list = BusinessLogicLayer.ConsentForms.OrthoEvaluationNew.GetOrthoEvaluationNewData(appId);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult CreateOrthoEvaluationNew()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateOrthoEvaluationNew");
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
        public ActionResult InsertOrthoEvaluationNew(BusinessEntities.ConsentForms.OrthoEvaluationNew data)
        {
            int isInserted = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.OrthoEvaluationNew.isValidOrthoEvaluationNew(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.ConsentForms.OrthoEvaluationNew.SaveOrthoEvaluationNew(data, madeby);

                        if (isInserted > 0)
                        {

                            // PDF _pdf = CreatePDF(data.moe_appId, "OrthoEvaluationNew");
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "OrthoEvaluation New is already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult UpdateOrthoEvaluationNew(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.ConsentForms.OrthoEvaluationNew ortho = BusinessLogicLayer.ConsentForms.OrthoEvaluationNew.GetOrthoEvaluationNewData(appId).FirstOrDefault();

                    return PartialView("UpdateOrthoEvaluationNew", ortho);
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
        public ActionResult EditOrthoEvaluationNew(BusinessEntities.ConsentForms.OrthoEvaluationNew data)
        {
            int isEdited = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.OrthoEvaluationNew.isValidOrthoEvaluationNew(data, out errors))
                    {
                        isEdited = BusinessLogicLayer.ConsentForms.OrthoEvaluationNew.SaveOrthoEvaluationNew(data, madeby);

                        if (isEdited > 0)
                        {
                            //PDF _pdf = CreatePDF(data.moe_appId, "OrthoEvaluationNew");

                            return Json(new { isEdited = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isEdited = false, isSuccess = true, message = "OrthoEvaluation New is already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete 
        [HttpPost]
        public ActionResult DeleteOrthoEvaluationNew(int appId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.ConsentForms.OrthoEvaluationNew.DeleteOrthoEvaluationNew(appId, madeby);

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


        public PartialViewResult OrthoEvaluationNewPreviousHistory(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = BusinessLogicLayer.ConsentForms.OrthoEvaluationNew.GetOrthoEvaluationNewPreviousHistory(appId);
                    return PartialView("OrthoEvaluationNewPreviousHistory", list);
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


                string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlOrthoEvaluationNew(appId, emr, setId);
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