using BusinessEntities;
using BusinessEntities.Common;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class ImageComparisionDocumentsController : Controller
    {
        // GET: EMR/ImageComparisionDocuments
        int PageId = (int)Pages.Documents;
        public PartialViewResult ImageComparisionDocuments()
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
                    return PartialView("ImageComparisionDocuments");
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
        public JsonResult GetImageComparisionDocumentsById(int id)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.EMR.ImageComparisionDocuments> list = BusinessLogicLayer.EMR.ImageComparisionDocuments.GetImageComparisionDocumentsById(id);

                if (list.Count > 0)
                {
                    string imgDirPath = "../../images/uploaded_images";

                    foreach (var image in list)
                    {
                        string path = null;

                        if (!string.IsNullOrEmpty(image.imgc_image))
                        {
                            path = Path.Combine(imgDirPath, image.imgc_image).Replace("\\", "/");
                           
                        }
                        image.imgc_image = path;
                       

                    }
                }

                return Json(new { isAuthorized = true, isSuccess = true, message = "Successfully Loaded Image Comparison Documents Data", data = list }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        public PartialViewResult CreateImageComparisionDocuments()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    return PartialView("CreateImageComparisionDocuments");
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
        public ActionResult UploadImages(BusinessEntities.EMR.ImageComparisionDocuments data)
        {
            int Action = (int)Actions.Create;
            int loginId = PageControl.getLoggedinId();
            bool isSuccess = false;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {
                    string file_path = Server.MapPath("~/images/uploaded_images");

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
                            HttpPostedFileBase _file = files[j];

                            if (_file.ContentLength > 0)
                            {
                                if (_file.ContentLength <= 5242880)
                                {
                                    isSuccess = true;

                                    string ext = Path.GetExtension(_file.FileName);

                                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ext;
                                    string path = Path.Combine(file_path, filename);
                                    string db_Path = DateTime.Now.ToString("yyyy") + "\\" + DateTime.Now.ToString("MMMM") + "\\" + DateTime.Now.ToString("dd") + "\\";
                                    db_Path += filename;

                                    data.imgc_image = db_Path;

                                    if(data.imgc_appId > 0 && !string.IsNullOrEmpty(data.imgc_type))
                                    {
                                        bool result = BusinessLogicLayer.EMR.ImageComparisionDocuments.SaveImageComparisionDocuments(data, loginId);

                                        if (result)
                                        {
                                            if (System.IO.File.Exists(path))
                                            {
                                                System.IO.File.Delete(path);
                                            }

                                            _file.SaveAs(path);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    DocErrorResponse err = new DocErrorResponse();
                    err.success = false;
                    err.errorcode = HttpStatusCode.Unauthorized.ToString();
                    err.error = "You are not authorized to Upload Image Comparison Documents";

                    return Json(err, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                DocErrorResponse err = new DocErrorResponse();
                err.success = false;
                err.errorcode = HttpStatusCode.InternalServerError.ToString();
                err.error = ex.Message;

                return Json(err, JsonRequestBehavior.AllowGet);
            }
            if (isSuccess)
            {
                DocSuccessResponse successRes = new DocSuccessResponse()
                {
                    success = true
                };
                return Json(successRes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DocErrorResponse err = new DocErrorResponse();
                err.success = false;
                err.errorcode = HttpStatusCode.InternalServerError.ToString();
                err.error = "Internal Server Error";

                return Json(err, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public ActionResult DeleteImageComparisionDocuments(int imgcId)
        {
            int Action = (int)Actions.Delete;

            if (PageControl.haveAccess(PageId, Action))
            {

                bool val = BusinessLogicLayer.EMR.ImageComparisionDocuments.DeleteImageComparisionDocuments(imgcId, PageControl.getLoggedinId());

                if (imgcId > 0)
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Deleted ImageComparisionDocuments with imgcId = {imgcId}"
                    });

                    return Json(new { isAuthorized = true, success = true, message = "ImageComparisionDocuments Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = true, success = false, message = "Failed To Delete ImageComparisionDocuments!" }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetPrevImageComparisionDocumentsById(int id,int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.EMR.ImageComparisionDocuments> list = BusinessLogicLayer.EMR.ImageComparisionDocuments.GetPrevImageComparisionDocumentsById(id,patId);

                if (list.Count > 0)
                {
                    string imgDirPath = "../../images/uploaded_images";

                    foreach (var image in list)
                    {
                        string path = null;

                        if (!string.IsNullOrEmpty(image.imgc_image))
                        {
                            path = Path.Combine(imgDirPath, image.imgc_image).Replace("\\", "/");

                        }
                        image.imgc_image = path;


                    }
                }

                return Json(new { isAuthorized = true, isSuccess = true, message = "Successfully Loaded Image Comparison Documents Data", data = list }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, isSuccess = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
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