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
    public class RefractionFormController : Controller
    {
        int PageId = (int)Pages.OphthalmologyConsentForms;
        // GET: ConsentForms/RefractionForm
        public ActionResult RefractionFormIndex()
        {
            ViewBag.Tab = "0";

            return View();
        }
        public JsonResult GetRefractionFormData(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.ConsentForms.RefractionForm> list = BusinessLogicLayer.ConsentForms.RefractionForm.GetRefractionFormData(appId);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult CreateRefractionForm()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateRefractionForm");
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
        public ActionResult InsertRefractionForm(BusinessEntities.ConsentForms.RefractionForm data)
        {
            int isInserted = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.RefractionForm.isValidRefractionForm(data, out errors))
                    {
                        string file_path = Server.MapPath("~/images/Refraction_docs/");
                        string path = string.Empty;

                        string file_name_rfc_glass1doc = "Glass1-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_rfc_glass2doc = "Glass2-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_rfc_autodoc = "Refraction-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_rfc_cyclodoc = "Cyclo-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                        string file_name_rfc_drydoc = "DryTest-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                        if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                        {
                            file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                            Directory.CreateDirectory(file_path);
                        }
                        else
                        {
                            file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                        }
                        if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                        {
                            file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                            Directory.CreateDirectory(file_path);
                        }
                        else
                        {
                            file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                        }
                        if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                        {
                            file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                            Directory.CreateDirectory(file_path);
                        }
                        else
                        {
                            file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                        }
                        if (Request.Files.Count > 0)
                        {
                            HttpFileCollectionBase files = Request.Files;

                            for (int j = 0; j < files.Count; j++)
                            {
                                HttpPostedFileBase file = files[j];

                                if (files.AllKeys[j] == "rfc_glass1doc")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_rfc_glass1doc = file_name_rfc_glass1doc + _extension;
                                            string _path = Path.Combine(file_path, file_name_rfc_glass1doc);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.rfc_glass1doc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("rfc_glass1doc", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "rfc_glass2doc")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_rfc_glass2doc = file_name_rfc_glass2doc + _extension;
                                            string _path = Path.Combine(file_path, file_name_rfc_glass2doc);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.rfc_glass2doc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("rfc_glass2doc", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "rfc_autodoc")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_rfc_autodoc = file_name_rfc_autodoc + _extension;
                                            string _path = Path.Combine(file_path, file_name_rfc_autodoc);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.rfc_autodoc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("rfc_autodoc", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                                else if (files.AllKeys[j] == "rfc_cyclodoc")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_rfc_cyclodoc = file_name_rfc_cyclodoc + _extension;
                                            string _path = Path.Combine(file_path, file_name_rfc_cyclodoc);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.rfc_cyclodoc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("rfc_cyclodoc", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }

                                else if (files.AllKeys[j] == "rfc_drydoc")
                                {
                                    if (file.ContentLength > 0)
                                    {
                                        if (file.ContentLength <= 5242880)
                                        {
                                            string _extension = Path.GetExtension(file.FileName);
                                            file_name_rfc_drydoc = file_name_rfc_drydoc + _extension;
                                            string _path = Path.Combine(file_path, file_name_rfc_drydoc);
                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            file.SaveAs(_path);

                                            data.rfc_drydoc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                        }
                                        else
                                        {
                                            errors.Add("rfc_drydoc", "The file has to be less than 5 MB!");
                                        }
                                    }
                                }
                            }
                        }

                        isInserted = BusinessLogicLayer.ConsentForms.RefractionForm.SaveRefractionForm(data, madeby);

                        if (isInserted > 0)
                        {
                             PDF _pdf = CreatePDF(data.rfc_appId, "RefractionForm");
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Refraction Form is already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult UpdateRefractionForm(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.ConsentForms.RefractionForm refraction = BusinessLogicLayer.ConsentForms.RefractionForm.GetRefractionFormData(appId).FirstOrDefault();
                    return PartialView("UpdateRefractionForm", refraction);
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
        public ActionResult EditRefractionForm(BusinessEntities.ConsentForms.RefractionForm data)
        {
            int isEdited = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int madeby = PageControl.getLoggedinId();


                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.RefractionForm.isValidRefractionForm(data, out errors))
                    {
                        if (SecurityLayer.FormValidations.ConsentForms.RefractionForm.isValidRefractionForm(data, out errors))
                        {
                            string file_path = Server.MapPath("~/images/Refraction_docs/");
                            string path = string.Empty;

                            string file_name_rfc_glass1doc = "Glass1-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string file_name_rfc_glass2doc = "Glass2-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string file_name_rfc_autodoc = "Refraction-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string file_name_rfc_cyclodoc = "Cyclo-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                            string file_name_rfc_drydoc = "DryTest-" + DateTime.Now.ToString("yyyyMMddHHmmss");

                            if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                            {
                                file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                            }
                            if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                            {
                                file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                            }
                            if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                            {
                                file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                                Directory.CreateDirectory(file_path);
                            }
                            else
                            {
                                file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                            }
                            if (Request.Files.Count > 0)
                            {
                                HttpFileCollectionBase files = Request.Files;

                                for (int j = 0; j < files.Count; j++)
                                {
                                    HttpPostedFileBase file = files[j];

                                    if (files.AllKeys[j] == "urfc_glass1doc")
                                    {
                                        if (file.ContentLength > 0)
                                        {
                                            if (file.ContentLength <= 5242880)
                                            {
                                                string _extension = Path.GetExtension(file.FileName);
                                                file_name_rfc_glass1doc = file_name_rfc_glass1doc + _extension;
                                                string _path = Path.Combine(file_path, file_name_rfc_glass1doc);
                                                if (System.IO.File.Exists(_path))
                                                {
                                                    System.IO.File.Delete(_path);
                                                }
                                                file.SaveAs(_path);

                                                data.rfc_glass1doc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                            }
                                            else
                                            {
                                                errors.Add("urfc_glass1doc", "The file has to be less than 5 MB!");
                                            }
                                        }
                                    }
                                    else if (files.AllKeys[j] == "urfc_glass2doc")
                                    {
                                        if (file.ContentLength > 0)
                                        {
                                            if (file.ContentLength <= 5242880)
                                            {
                                                string _extension = Path.GetExtension(file.FileName);
                                                file_name_rfc_glass2doc = file_name_rfc_glass2doc + _extension;
                                                string _path = Path.Combine(file_path, file_name_rfc_glass2doc);
                                                if (System.IO.File.Exists(_path))
                                                {
                                                    System.IO.File.Delete(_path);
                                                }
                                                file.SaveAs(_path);

                                                data.rfc_glass2doc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                            }
                                            else
                                            {
                                                errors.Add("urfc_glass2doc", "The file has to be less than 5 MB!");
                                            }
                                        }
                                    }
                                    else if (files.AllKeys[j] == "urfc_autodoc")
                                    {
                                        if (file.ContentLength > 0)
                                        {
                                            if (file.ContentLength <= 5242880)
                                            {
                                                string _extension = Path.GetExtension(file.FileName);
                                                file_name_rfc_autodoc = file_name_rfc_autodoc + _extension;
                                                string _path = Path.Combine(file_path, file_name_rfc_autodoc);
                                                if (System.IO.File.Exists(_path))
                                                {
                                                    System.IO.File.Delete(_path);
                                                }
                                                file.SaveAs(_path);

                                                data.rfc_autodoc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                            }
                                            else
                                            {
                                                errors.Add("urfc_autodoc", "The file has to be less than 5 MB!");
                                            }
                                        }
                                    }
                                    else if (files.AllKeys[j] == "urfc_cyclodoc")
                                    {
                                        if (file.ContentLength > 0)
                                        {
                                            if (file.ContentLength <= 5242880)
                                            {
                                                string _extension = Path.GetExtension(file.FileName);
                                                file_name_rfc_cyclodoc = file_name_rfc_cyclodoc + _extension;
                                                string _path = Path.Combine(file_path, file_name_rfc_cyclodoc);
                                                if (System.IO.File.Exists(_path))
                                                {
                                                    System.IO.File.Delete(_path);
                                                }
                                                file.SaveAs(_path);

                                                data.rfc_cyclodoc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                            }
                                            else
                                            {
                                                errors.Add("urfc_cyclodoc", "The file has to be less than 5 MB!");
                                            }
                                        }
                                    }

                                    else if (files.AllKeys[j] == "urfc_drydoc")
                                    {
                                        if (file.ContentLength > 0)
                                        {
                                            if (file.ContentLength <= 5242880)
                                            {
                                                string _extension = Path.GetExtension(file.FileName);
                                                file_name_rfc_drydoc = file_name_rfc_drydoc + _extension;
                                                string _path = Path.Combine(file_path, file_name_rfc_drydoc);
                                                if (System.IO.File.Exists(_path))
                                                {
                                                    System.IO.File.Delete(_path);
                                                }
                                                file.SaveAs(_path);

                                                data.rfc_drydoc = _path.Replace(Server.MapPath("~/images/Refraction_docs/"), "");
                                            }
                                            else
                                            {
                                                errors.Add("urfc_drydoc", "The file has to be less than 5 MB!");
                                            }
                                        }
                                    }
                                }
                            }

                            isEdited = BusinessLogicLayer.ConsentForms.RefractionForm.SaveRefractionForm(data, madeby);

                            if (isEdited > 0)
                            {
                                 PDF _pdf = CreatePDF(data.rfc_appId, "RefractionForm");
                                return Json(new { isEdited = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                return Json(new { isEdited = false, isSuccess = true, message = "Refraction Form is already exists!" }, JsonRequestBehavior.AllowGet);
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
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }
        // Delete 
        [HttpPost]
        public ActionResult DeleteRefractionForm(int appId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.ConsentForms.RefractionForm.DeleteRefractionForm(appId, madeby);

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
        public PartialViewResult RefractionFormPreviousHistory(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = BusinessLogicLayer.ConsentForms.RefractionForm.GetRefractionFormPreviousHistory(appId);
                    return PartialView("RefractionFormPreviousHistory", list);
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


                string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlRefractionForm(appId, emr, setId);
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