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
using Google.Type;
using Google.Protobuf.WellKnownTypes;
using System.Collections;

namespace ClinicSoft.Areas.Common.Controllers
{
    public class QueriesController : Controller
    {
        int PageId = (int)Pages.MyTickets;
        int PageId_DQueries = (int)Pages.DoctorQueries;

        #region Doctor Queries Page Load
        [HttpGet]
        public ActionResult DoctorQueries()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId_DQueries, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllDoctorQueries(QueriesSearch data)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId_DQueries, Action))
                {
                    //List<DoctorQueries> doctorQueries = BusinessLogicLayer.Common.Queries.GetAllQueries(data);

                    return Json(new { isAuthorized = true, message = "" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Queries Page Load
        [HttpGet]
        public ActionResult Queries()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllQueries(QueriesSearch data)
        {
            try
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<CoderQueries> coderQueries = BusinessLogicLayer.Common.Queries.GetAllQueries(data);

                    return Json(new { isAuthorized = true, message = coderQueries }, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetQuery(int qaId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CoderQueries> Queries = BusinessLogicLayer.Documentation.CoderQueries.GetAllCoderQueries(0, qaId);
                return Json(Queries, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult ReplyQueries(int qaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<CoderQueries> Queries = BusinessLogicLayer.Documentation.CoderQueries.GetAllCoderQueries(0, qaId);

                    return PartialView("ReplyQueries", Queries.FirstOrDefault());
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
        public ActionResult ReplyQuery(int res_query)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<CoderQueries> query = BusinessLogicLayer.Documentation.CoderQueries.GetAllCoderQueries(0, res_query);

                    return PartialView("ReplyQuery", query);
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
        public ActionResult InsertResponses(Queries data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    isInserted = BusinessLogicLayer.Common.Queries.InsertUpdateResponses(data);

                    if (isInserted)
                    {
                        SaveFiles(Request.Files, data.resId);

                        return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Coder Queries already exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        private void SaveFiles(HttpFileCollectionBase files, int qaId)
        {
            string uploadPath = Server.MapPath("~/images/Coder_Documents/"); // Set your upload directory path

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

                    // Save the file to the server
                    file.SaveAs(filePath);

                    // You can do additional processing or store file information in the database
                    FileInformation fileInfo = new FileInformation
                    {
                        FileName = fileName,
                        FilePath = filePath,
                        CoderQueryId = qaId, // Assuming you have a property in CoderQueries model to associate with files
                                             // Add other file information as needed
                    };
                    int result = BusinessLogicLayer.Documentation.CoderQueries.InsertDocuments(fileInfo, qaId);
                }
            }
        }
        #endregion

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}