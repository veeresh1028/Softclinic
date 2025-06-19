using BusinessEntities;
using BusinessEntities.Common;
using BusinessEntities.ConsentForms;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.ConsentForms.Controllers
{
    [Authorize]
    public class ImageComparisionController : Controller
    {
        int PageId = (int)Pages.LaserConsentForms;
        // GET: ConsentForms/ImageComparision
        public ActionResult ImageComparisionIndex()
        {
            ViewBag.Tab = "0";

            return View();
        }
        public JsonResult GetImageComparisionData(int appId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.ConsentForms.ImageComparision> list = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionData(appId, 0);

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult CreateImageComparision()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("CreateImageComparision");
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
        public ActionResult InsertImageComparision(BusinessEntities.ConsentForms.ImageComparision data)
        {
            int isInserted = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.ImageComparision.isValidImageComparision(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.ConsentForms.ImageComparision.SaveImageComparision(data, madeby);

                        if (isInserted > 0)
                        {

                            //PDF _pdf = CreatePDF(data.cic_appId, "ImageComparision");
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "ImageComparision is already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult UpdateImageComparision(int cicId, int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.ConsentForms.ImageComparision image = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionData(appId, cicId).FirstOrDefault();

                    return PartialView("UpdateImageComparision", image);
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
        public ActionResult EditImageComparision(BusinessEntities.ConsentForms.ImageComparision data)
        {
            int isEdited = 0;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    int madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.ConsentForms.ImageComparision.isValidImageComparision(data, out errors))
                    {
                        isEdited = BusinessLogicLayer.ConsentForms.ImageComparision.SaveImageComparision(data, madeby);

                        if (isEdited > 0)
                        {
                            //PDF _pdf = CreatePDF(data.cic_appId, "ImageComparision");

                            return Json(new { isEdited = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isEdited = false, isSuccess = true, message = "ImageComparision is already exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteImageComparision(int cicId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                int madeby = PageControl.getLoggedinId();
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.ConsentForms.ImageComparision.DeleteImageComparision(cicId, madeby);

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
        public PartialViewResult ImageComparisionPreviousHistory(int appId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.ConcentForms.ConcentPreviousHistroy> list = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(appId);
                    return PartialView("ImageComparisionPreviousHistory", list);
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
        //[HttpGet]
        //public ActionResult PrintPDFConsent(int appId, string form)
        //{
        //    try
        //    {
        //        int Action = (int)Actions.Print;
        //        int madeby = PageControl.getLoggedinId();

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();

        //            if (pdf != null)
        //            {
        //                return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                PDF _pdf = CreatePDF(appId, form);
        //                return Json(new { success = true, isAuthorized = true, message = _pdf }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public PDF CreatePDF(int appId, string form)
        //{
        //    PDF _pdf = new PDF();

        //    try
        //    {
        //        int madeby = PageControl.getLoggedinId();
        //        string fileName = appId + "_" + form + ".pdf";
        //        string file_path = Server.MapPath("~/Documents/ConsentForms");

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
        //        }

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
        //        }

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
        //        }

        //        string path = Path.Combine(file_path, fileName);

        //        var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
        //        var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
        //        int setId = int.Parse(emp_branch);
        //        EMRInfo emr = (EMRInfo)TempData["emr_data"];
        //        TempData.Keep("emr_data");

        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //        }


        //        string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlTreatmentRecordSheet(appId, emr, setId);
        //        var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
        //        var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);
        //        System.IO.File.WriteAllBytes(path, pdfBytes);



        //        if (System.IO.File.Exists(path))
        //        {
        //            _pdf.pdfAppId = appId;
        //            _pdf.pdfForm = form;
        //            _pdf.pdfPath = path;
        //            _pdf.pdfFileName = fileName;
        //            _pdf.pdfUploadedBy = madeby;

        //            bool isInserted = BusinessLogicLayer.Common.PDF.UploadDocument(_pdf);
        //        }

        //        return _pdf;
        //    }
        //    catch (Exception ex)
        //    {
        //        return _pdf;
        //    }
        //}
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }












        //public PartialViewResult CreateImageComparision()
        //{
        //    if (PageControl.getLoggedinId() > 0)
        //    {
        //        int Action = (int)Actions.Create;

        //        if (PageControl.haveAccess(PageId, Action))
        //        {

        //            imageReference cic_ref = new imageReference();
        //            cic_ref.reftype = "ConsentForms";


        //            return PartialView("CreateImageComparision", cic_ref);
        //        }
        //        else
        //        {
        //            return PartialView("_Unauthorized");
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("_SessionExpired");
        //    }
        //}

        //[HttpGet]
        //public ActionResult GetImageComparisionData(int id, string type)
        //{
        //    int Action = (int)Actions.Read;

        //    if (PageControl.haveAccess(PageId, Action))
        //    {
        //        Dictionary<string, string> errors = new Dictionary<string, string>();

        //        List<ImageComparision> cic_data = new List<ImageComparision>();
        //        try
        //        {
        //            string path = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString();
        //            if (type == "Patient")
        //            {
        //                cic_data = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(id, 1, path);
        //            }
        //            else if (type == "Employee")
        //            {
        //                cic_data = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(id, 2, path);
        //            }
        //            else if (type == "EMR")
        //            {
        //                cic_data = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(id, 3, path);
        //            }
        //            else if (type == "Investigation")
        //            {
        //                cic_data = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(id, 4, path);
        //            }
        //            var jsonResult = Json(new { isAutherized = true, isSuccess = true, message = cic_data }, JsonRequestBehavior.AllowGet);
        //            jsonResult.MaxJsonLength = int.MaxValue;
        //            return jsonResult;
        //        }
        //        catch (Exception ex)
        //        {
        //            errors.Add("", ex.Message);
        //            return Json(new { isAutherized = true, isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
        //    }
        //}
        //[HttpGet]
        //public ActionResult PrintPDFConsent(int appId, string form)
        //{
        //    try
        //    {
        //        int Action = (int)Actions.Print;
        //        int madeby = PageControl.getLoggedinId();

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();

        //            if (pdf != null)
        //            {
        //                return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                PDF _pdf = CreatePDF(appId, form);
        //                return Json(new { success = true, isAuthorized = true, message = _pdf }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public PDF CreatePDF(int appId, string form)
        //{
        //    PDF _pdf = new PDF();

        //    try
        //    {
        //        int madeby = PageControl.getLoggedinId();
        //        string fileName = appId + "_" + form + ".pdf";
        //        string file_path = Server.MapPath("~/Documents/ConsentForms");

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
        //        }

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
        //        }

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
        //        }

        //        string path = Path.Combine(file_path, fileName);

        //        var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
        //        var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
        //        int setId = int.Parse(emp_branch);
        //        EMRInfo emr = (EMRInfo)TempData["emr_data"];
        //        TempData.Keep("emr_data");

        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //        }


        //        string htmlContent = BusinessLogicLayer.ConcentForms.ConsentFormPDF.HtmlTreatmentRecordSheet(appId, emr, setId);
        //        var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
        //        var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);
        //        System.IO.File.WriteAllBytes(path, pdfBytes);



        //        if (System.IO.File.Exists(path))
        //        {
        //            _pdf.pdfAppId = appId;
        //            _pdf.pdfForm = form;
        //            _pdf.pdfPath = path;
        //            _pdf.pdfFileName = fileName;
        //            _pdf.pdfUploadedBy = madeby;

        //            bool isInserted = BusinessLogicLayer.Common.PDF.UploadDocument(_pdf);
        //        }

        //        return _pdf;
        //    }
        //    catch (Exception ex)
        //    {
        //        return _pdf;
        //    }
        //}


































        //public JsonResult GetImageComparisionData(int appId)
        //{
        //    int Action = (int)Actions.Read;

        //    if (PageControl.haveAccess(PageId, Action))
        //    {
        //        List<BusinessEntities.ConsentForms.ImageComparision> list = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionData(appId,0);

        //        return Json(list, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        //public PartialViewResult CreateImageComparision()
        //{
        //    if (PageControl.getLoggedinId() > 0)
        //    {
        //        int Action = (int)Actions.Create;

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            return PartialView("CreateImageComparision");
        //        }
        //        else
        //        {
        //            return PartialView("_Unauthorized");
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("_SessionExpired");
        //    }
        //}
        //[HttpPost]
        //public ActionResult InsertImageComparision(BusinessEntities.ConsentForms.ImageComparision data)
        //{
        //    int isInserted = 0;
        //    try
        //    {
        //        int Action = (int)Actions.Create;

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            int madeby = PageControl.getLoggedinId();

        //            Dictionary<string, string> errors = new Dictionary<string, string>();

        //            if (SecurityLayer.FormValidations.ConsentForms.ImageComparision.isValidImageComparision(data, out errors))
        //            {
        //                string file_path = Server.MapPath("~/images/ImageComparision_img/");
        //                string path = string.Empty;

        //                string file_name_cic_img1 = "img1-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        //                string file_name_cic_img2 = "img2-" + DateTime.Now.ToString("yyyyMMddHHmmss");

        //                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
        //                {
        //                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
        //                    Directory.CreateDirectory(file_path);
        //                }
        //                else
        //                {
        //                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
        //                }
        //                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
        //                {
        //                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
        //                    Directory.CreateDirectory(file_path);
        //                }
        //                else
        //                {
        //                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
        //                }
        //                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
        //                {
        //                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
        //                    Directory.CreateDirectory(file_path);
        //                }
        //                else
        //                {
        //                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
        //                }
        //                if (Request.Files.Count > 0)
        //                {
        //                    HttpFileCollectionBase files = Request.Files;

        //                    for (int j = 0; j < files.Count; j++)
        //                    {
        //                        HttpPostedFileBase file = files[j];

        //                        if (files.AllKeys[j] == "cic_img1")
        //                        {
        //                            if (file.ContentLength > 0)
        //                            {
        //                                if (file.ContentLength <= 5242880)
        //                                {
        //                                    string _extension = Path.GetExtension(file.FileName);
        //                                    file_name_cic_img1 = file_name_cic_img1 + _extension;
        //                                    string _path = Path.Combine(file_path, file_name_cic_img1);
        //                                    if (System.IO.File.Exists(_path))
        //                                    {
        //                                        System.IO.File.Delete(_path);
        //                                    }
        //                                    file.SaveAs(_path);

        //                                    data.cic_img1 = _path.Replace(Server.MapPath("~/images/ImageComparision_img/"), "");
        //                                }
        //                                else
        //                                {
        //                                    errors.Add("cic_img1", "The file has to be less than 5 MB!");
        //                                }
        //                            }
        //                        }
        //                        else if (files.AllKeys[j] == "cic_img2")
        //                        {
        //                            if (file.ContentLength > 0)
        //                            {
        //                                if (file.ContentLength <= 5242880)
        //                                {
        //                                    string _extension = Path.GetExtension(file.FileName);
        //                                    file_name_cic_img2 = file_name_cic_img2 + _extension;
        //                                    string _path = Path.Combine(file_path, file_name_cic_img2);
        //                                    if (System.IO.File.Exists(_path))
        //                                    {
        //                                        System.IO.File.Delete(_path);
        //                                    }
        //                                    file.SaveAs(_path);

        //                                    data.cic_img2 = _path.Replace(Server.MapPath("~/images/ImageComparision_img/"), "");
        //                                }
        //                                else
        //                                {
        //                                    errors.Add("cic_img2", "The file has to be less than 5 MB!");
        //                                }
        //                            }
        //                        }
        //                    }
        //                }

        //                isInserted = BusinessLogicLayer.ConsentForms.ImageComparision.SaveImageComparision(data, madeby);

        //                if (isInserted > 0)
        //                {
        //                    PDF _pdf = CreatePDF(data.cic_appId, "ImageComparision");
        //                    return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
        //                }
        //                else
        //                {
        //                    return Json(new { isInserted = false, isSuccess = true, message = "Image Comparision Form is already exists!" }, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = ex.Message;
        //    }
        //    return View();
        //}
        //public PartialViewResult UpdateImageComparision(int cicId,int appId)
        //{
        //    if (PageControl.getLoggedinId() > 0)
        //    {
        //        int Action = (int)Actions.Create;

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            BusinessEntities.ConsentForms.ImageComparision refraction = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionData(appId, cicId).FirstOrDefault();
        //            return PartialView("UpdateImageComparision", refraction);
        //        }
        //        else
        //        {
        //            return PartialView("_Unauthorized");
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("_SessionExpired");
        //    }
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult EditImageComparision(BusinessEntities.ConsentForms.ImageComparision data)
        //{
        //    int isEdited = 0;
        //    try
        //    {
        //        int Action = (int)Actions.Create;

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            int madeby = PageControl.getLoggedinId();


        //            Dictionary<string, string> errors = new Dictionary<string, string>();

        //            if (SecurityLayer.FormValidations.ConsentForms.ImageComparision.isValidImageComparision(data, out errors))
        //            {
        //                if (SecurityLayer.FormValidations.ConsentForms.ImageComparision.isValidImageComparision(data, out errors))
        //                {
        //                    string file_path = Server.MapPath("~/images/ImageComparision_img/");
        //                    string path = string.Empty;

        //                    string file_name_imagecomparision_img1 = "img1-" + DateTime.Now.ToString("yyyyMMddHHmmss");
        //                    string file_name_imagecomparision_img2 = "img2-" + DateTime.Now.ToString("yyyyMMddHHmmss");

        //                    if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
        //                    {
        //                        file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
        //                        Directory.CreateDirectory(file_path);
        //                    }
        //                    else
        //                    {
        //                        file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
        //                    }
        //                    if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
        //                    {
        //                        file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
        //                        Directory.CreateDirectory(file_path);
        //                    }
        //                    else
        //                    {
        //                        file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
        //                    }
        //                    if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
        //                    {
        //                        file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
        //                        Directory.CreateDirectory(file_path);
        //                    }
        //                    else
        //                    {
        //                        file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
        //                    }
        //                    if (Request.Files.Count > 0)
        //                    {
        //                        HttpFileCollectionBase files = Request.Files;

        //                        for (int j = 0; j < files.Count; j++)
        //                        {
        //                            HttpPostedFileBase file = files[j];

        //                            if (files.AllKeys[j] == "ucic_img1")
        //                            {
        //                                if (file.ContentLength > 0)
        //                                {
        //                                    if (file.ContentLength <= 5242880)
        //                                    {
        //                                        string _extension = Path.GetExtension(file.FileName);
        //                                        file_name_imagecomparision_img1 = file_name_imagecomparision_img1 + _extension;
        //                                        string _path = Path.Combine(file_path, file_name_imagecomparision_img1);
        //                                        if (System.IO.File.Exists(_path))
        //                                        {
        //                                            System.IO.File.Delete(_path);
        //                                        }
        //                                        file.SaveAs(_path);

        //                                        data.cic_img1 = _path.Replace(Server.MapPath("~/images/ImageComparision_img/"), "");
        //                                    }
        //                                    else
        //                                    {
        //                                        errors.Add("ucic_img1", "The file has to be less than 5 MB!");
        //                                    }
        //                                }
        //                            }
        //                            else if (files.AllKeys[j] == "ucic_img2")
        //                            {
        //                                if (file.ContentLength > 0)
        //                                {
        //                                    if (file.ContentLength <= 5242880)
        //                                    {
        //                                        string _extension = Path.GetExtension(file.FileName);
        //                                        file_name_imagecomparision_img2 = file_name_imagecomparision_img2 + _extension;
        //                                        string _path = Path.Combine(file_path, file_name_imagecomparision_img2);
        //                                        if (System.IO.File.Exists(_path))
        //                                        {
        //                                            System.IO.File.Delete(_path);
        //                                        }
        //                                        file.SaveAs(_path);

        //                                        data.cic_img2 = _path.Replace(Server.MapPath("~/images/ImageComparision_img/"), "");
        //                                    }
        //                                    else
        //                                    {
        //                                        errors.Add("ucic_img2", "The file has to be less than 5 MB!");
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }

        //                    isEdited = BusinessLogicLayer.ConsentForms.ImageComparision.SaveImageComparision(data, madeby);

        //                    if (isEdited > 0)
        //                    {
        //                        PDF _pdf = CreatePDF(data.cic_appId, "ImageComparision");
        //                        return Json(new { isEdited = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
        //                    }
        //                    else
        //                    {
        //                        return Json(new { isEdited = false, isSuccess = true, message = "Image Comparision Form is already exists!" }, JsonRequestBehavior.AllowGet);
        //                    }
        //                }
        //                else
        //                {
        //                    return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["ErrorMessage"] = ex.Message;
        //    }
        //    return View();
        //}
        //// Delete 
        //[HttpPost]
        //public ActionResult DeleteImageComparision(int appId)
        //{
        //    try
        //    {
        //        int Action = (int)Actions.Delete;
        //        int madeby = PageControl.getLoggedinId();
        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            int val = BusinessLogicLayer.ConsentForms.ImageComparision.DeleteImageComparision(appId, madeby);

        //            if (val == 1)
        //            {
        //                return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public PartialViewResult ImageComparisionPreviousHistory(int appId)
        //{
        //    if (PageControl.getLoggedinId() > 0)
        //    {
        //        int Action = (int)Actions.Read;

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            List<BusinessEntities.ConcentForms.ConcentPreviousHistory> list = BusinessLogicLayer.ConsentForms.ImageComparision.GetImageComparisionPreviousHistory(appId);
        //            return PartialView("ImageComparisionPreviousHistory", list);
        //        }
        //        else
        //        {
        //            return PartialView("_Unauthorized");
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("_SessionExpired");
        //    }
        //}
        //[HttpGet]
        //public ActionResult PrintPDFConsent(int appId, string form)
        //{
        //    try
        //    {
        //        int Action = (int)Actions.Print;
        //        int madeby = PageControl.getLoggedinId();

        //        if (PageControl.haveAccess(PageId, Action))
        //        {
        //            BusinessEntities.Common.PDF pdf = BusinessLogicLayer.Common.PDF.GetConsentPDFByAppId(appId, form).FirstOrDefault();

        //            if (pdf != null)
        //            {
        //                return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                pdf = CreatePDF(appId, form);
        //                return Json(new { success = true, isAuthorized = true, message = pdf }, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            return Json(new { isAuthorized = false, message = "Unauthorized!" }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public PDF CreatePDF(int appId, string form)
        //{
        //    PDF _pdf = new PDF();

        //    try
        //    {
        //        int madeby = PageControl.getLoggedinId();
        //        string fileName = appId + "_" + form + ".pdf";
        //        string file_path = Server.MapPath("~/Documents/ConsentForms");

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("yyyy"));
        //        }

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("MMMM"));
        //        }

        //        if (!Directory.Exists(Path.Combine(file_path, System.DateTime.Now.ToString("dd"))))
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
        //            Directory.CreateDirectory(file_path);
        //        }
        //        else
        //        {
        //            file_path = Path.Combine(file_path, System.DateTime.Now.ToString("dd"));
        //        }

        //        string path = Path.Combine(file_path, fileName);

        //        var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
        //        var emp_branch = claims.Where(c => c.Type == ClaimTypes.GroupSid).Select(c => c.Value).SingleOrDefault();
        //        int setId = int.Parse(emp_branch);
        //        EMRInfo emr = (EMRInfo)TempData["emr_data"];
        //        TempData.Keep("emr_data");

        //        if (System.IO.File.Exists(path))
        //        {
        //            System.IO.File.Delete(path);
        //        }


        //        string htmlContent = BusinessLogicLayer.ConcentForms.ConcentFormPDF.HtmlImageComparision(appId, emr, setId);
        //        var pdfGenerator = new Rocket.PdfGenerator.HtmlToPdfConverter();
        //        var pdfBytes = pdfGenerator.GeneratePdf(htmlContent);
        //        System.IO.File.WriteAllBytes(path, pdfBytes);


        //        if (System.IO.File.Exists(path))
        //        {
        //            _pdf.pdfAppId = appId;
        //            _pdf.pdfForm = form;
        //            _pdf.pdfPath = path;
        //            _pdf.pdfFileName = fileName;
        //            _pdf.pdfUploadedBy = madeby;

        //            bool isInserted = BusinessLogicLayer.Common.PDF.UploadDocument(_pdf);
        //        }

        //        return _pdf;
        //    }
        //    catch (Exception ex)
        //    {
        //        return _pdf;
        //    }
        //}
        //protected override void OnException(ExceptionContext filterContext)
        //{
        //    filterContext.ExceptionHandled = true;
        //    TempData["error"] = filterContext;
        //    filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        //}
    }
}