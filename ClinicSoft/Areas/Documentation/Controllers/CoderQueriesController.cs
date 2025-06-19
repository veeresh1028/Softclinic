using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessEntities.Documentation;
using BusinessEntities.Common;
using System.Net;

using DocData = BusinessEntities.Common.DocData;
using Google.Type;

namespace ClinicSoft.Areas.Documentation.Controllers
{
    [Authorize]
    public class CoderQueriesController : Controller
    {
        int PageId = (int)Pages.CoderQueries;

        #region Coder Queries
        [HttpGet]
        public ActionResult CoderQueries()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Coder Queries Page!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllCoderQueries(int? appId, int? qaId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CoderQueries> pasthis = BusinessLogicLayer.Documentation.CoderQueries.GetAllCoderQueries(appId, qaId);

                return Json(new { isAuthorized = true, message = pasthis }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateCoderQueries()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    CoderQueries query = new CoderQueries();
                    
                    return PartialView("CreateCoderQueries", query);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        public ActionResult InsertCoderQueries(CoderQueries data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    data.qa_madeby = PageControl.getLoggedinId();

                    int qaId = BusinessLogicLayer.Documentation.CoderQueries.InsertUpdateCoderQueries(data);

                    if (qaId > 0)
                    {
                        if (Request.Files.Count > 0)
                        {
                            SaveFiles(Request.Files, qaId);
                        }

                        return Json(new { isSuccess = true, message = "Coder Query Sent Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Coder Query Already Exists!" }, JsonRequestBehavior.AllowGet);
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

        private void SaveFiles(HttpFileCollectionBase files, int qaId)
        {
            string uploadPath = Server.MapPath("~/images/Coder_Documents/");

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];

                if (file != null && file.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string filePath = Path.Combine(uploadPath, fileName);

                    file.SaveAs(filePath);

                    FileInformation fileInfo = new FileInformation
                    {
                        FileName = fileName,
                        FilePath = filePath,
                        CoderQueryId = qaId
                    };

                    int result = BusinessLogicLayer.Documentation.CoderQueries.InsertDocuments(fileInfo, qaId);
                }
            }
        }

        [HttpGet]
        public PartialViewResult EditCoderQueries(int qaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    CoderQueries query = BusinessLogicLayer.Documentation.CoderQueries.GetAllCoderQueries(0, qaId).FirstOrDefault();

                    return PartialView("EditCoderQueries", query);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        public ActionResult UpdateCoderQueries(CoderQueries data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.qa_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    int qaId = BusinessLogicLayer.Documentation.CoderQueries.UpdateCoderQueries(data);

                    if (qaId > 0)
                    {
                        return Json(new { isSuccess = true, message = "Coder Query Updated Successfully!" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { isSuccess = true, message = "Coder Queries already exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult PrintCoderQueries(int qaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    CoderQueries print = BusinessLogicLayer.Documentation.CoderQueries.GetAllCoderQueries(0, qaId).FirstOrDefault();

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Coder Queries with qaId = {qaId}"
                    });

                    return View("PrintCoderQueries", print);
                }
                else
                {
                    return PartialView("UnauthorizedAccess");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
            }
        }

        [HttpPost]
        public ActionResult DeleteCoderQueries(int qaId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                               
                if (PageControl.haveAccess(PageId, Action))
                {
                    int qa_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.Documentation.CoderQueries.DeleteCoderQueries(qaId, qa_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Coder Query Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Coder Query!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult GetEmployeeDept(string empId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> emp = BusinessLogicLayer.Documentation.CoderQueries.GetEmployeeDept(empId);

                    var jsonResult = Json(emp, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetMsgType(string query, int mt_branch, int? mtId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> emp = BusinessLogicLayer.Documentation.CoderQueries.GetMsgType(query, mt_branch, mtId);

                    var jsonResult = Json(emp, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult UploadFiles(DocData data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    bool issuccess = false;
                    DocErrorResponse err = new DocErrorResponse();

                    string file_path = Server.MapPath("~/images/uploaded_documents/");

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
                                    issuccess = true;

                                    string _extension = Path.GetExtension(_file.FileName);
                                    string _file_name = DateTime.Now.ToString("yyyyMMddHHmmss") + _extension;
                                    string _path = Path.Combine(file_path, _file_name);

                                    DocumentUpload doc = new DocumentUpload();
                                    doc.doc_refId = data.id;
                                    doc.doc_reftype = data.type;
                                    doc.doc_label = string.IsNullOrEmpty(data.label) ? string.Empty : data.label;
                                    doc.doc_name = _file_name;
                                    doc.doc_ext = _extension;
                                    doc.doc_path = _path;
                                    doc.doc_uploadedBy = PageControl.getLoggedinId();
                                    doc.doc_category = data.doc_category;

                                    if (doc.doc_refId > 0 && !string.IsNullOrEmpty(doc.doc_reftype))
                                    {
                                        if (BusinessLogicLayer.Common.Documents.UploadDocument(doc))
                                        {

                                            if (System.IO.File.Exists(_path))
                                            {
                                                System.IO.File.Delete(_path);
                                            }
                                            _file.SaveAs(_path);
                                        }
                                    }
                                }
                                else
                                {
                                    err.success = false;
                                    err.errorcode = HttpStatusCode.RequestEntityTooLarge.ToString();
                                    err.error = "Uploaded File should not be exceed to 5MB";
                                }
                            }
                            else
                            {
                                err.success = false;
                                err.errorcode = HttpStatusCode.NotFound.ToString();
                                err.error = "File Not Received";
                            }
                        }
                    }

                    if (issuccess)
                    {
                        DocSuccessResponse success = new DocSuccessResponse();
                        success.success = true;

                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Uploaded Patient Documents"
                        });

                        return Json(success, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
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
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetEmployeeDetailsByID(int empId)
        {
            int Action = (int)Actions.Read;
            
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> emp = BusinessLogicLayer.EMR.PhysicianQuery.GetEmployeeDetailsByID(empId);
                    var jsonResult = Json(emp, JsonRequestBehavior.AllowGet);

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
        #endregion  
    }
}