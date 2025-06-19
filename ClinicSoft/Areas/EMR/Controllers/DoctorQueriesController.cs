using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Common;
using BusinessEntities.Documentation;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    public class DoctorQueriesController : Controller
    {
        int PageId = (int)Pages.DoctorQueries;

        #region Doctor Queries (Page Load)
        [HttpGet]
        public ActionResult DoctorQueries()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Doctor Queries Page!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllDoctorQueries(int? appId, int? qaId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DoctorQueries> docQueries = BusinessLogicLayer.EMR.DoctorQueries.GetAllDoctorQueries(appId, qaId);

                return Json(new { isAuthorized = true, message = docQueries }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Doctor Queries (CRUD Operations)
        [HttpGet]
        public PartialViewResult CreateDoctorQuery()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DoctorQueries query = new DoctorQueries();

                    return PartialView("CreateDoctorQuery", query);
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
        public ActionResult InsertDoctorQuery(DoctorQueries data)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.qa_madeby = PageControl.getLoggedinId();

                    int qaId = BusinessLogicLayer.EMR.DoctorQueries.InsertDoctorQuery(data);

                    if (qaId > 0)
                    {
                        if (Request.Files.Count > 0)
                        {
                            SaveFiles(Request.Files, qaId);
                        }

                        return Json(new { isSuccess = true, message = "Doctor Query Sent Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Doctor Query Already Exists!" }, JsonRequestBehavior.AllowGet);
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
            string uploadPath = Server.MapPath("~/images/doctor_documents/");

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

                    DoctorFileInformation fileInfo = new DoctorFileInformation
                    {
                        FileName = fileName,
                        FilePath = filePath,
                        DoctorQueryId = qaId
                    };

                    int result = BusinessLogicLayer.EMR.DoctorQueries.InsertDocuments(fileInfo, qaId);
                }
            }
        }

        [HttpGet]
        public PartialViewResult EditDoctorQuery(int qaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DoctorQueries query = BusinessLogicLayer.EMR.DoctorQueries.GetAllDoctorQueries(0, qaId).FirstOrDefault();

                    return PartialView("EditDoctorQuery", query);
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
        public ActionResult UpdateDoctorQuery(DoctorQueries data)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.qa_madeby = PageControl.getLoggedinId();

                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    int qaId = BusinessLogicLayer.EMR.DoctorQueries.UpdateDoctorQuery(data);

                    if (qaId > 0)
                    {
                        return Json(new { isSuccess = true, message = "Doctor Query Updated Successfully!" }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        return Json(new { isSuccess = true, message = "Doctor Query already exists!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult PrintDoctorQuery(int qaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DoctorQueries print = BusinessLogicLayer.EMR.DoctorQueries.GetAllDoctorQueries(0, qaId).FirstOrDefault();

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Printed Doctor Query with qaId = {qaId}"
                    });

                    return View("PrintDoctorQuery", print);
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
        public ActionResult DeleteDoctorQuery(int qaId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int qa_madeby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.EMR.DoctorQueries.DeleteDoctorQuery(qaId, qa_madeby);

                    if (val == 1)
                    {
                        return Json(new { success = true, isAuthorized = true, message = "Doctor Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Doctor Query!" }, JsonRequestBehavior.AllowGet);
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
                    List<CommonDDL> emp = BusinessLogicLayer.EMR.DoctorQueries.GetEmployeeDept(empId);

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
                    List<CommonDDL> emp = BusinessLogicLayer.EMR.DoctorQueries.GetMsgType(query, mt_branch, mtId);

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

        [HttpGet]
        public ActionResult GetCoders()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> emp = BusinessLogicLayer.EMR.DoctorQueries.GetCoders();
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
        #endregion
    }
}