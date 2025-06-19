using BusinessEntities;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class DiagnosisFavouritesController : Controller
    {
        #region DiagnosisFavourites (Page Load)
        int PageId = (int)Pages.DiagnosisFavourites;
        // GET: EMR/DiagnosisFavourites
        public PartialViewResult DiagnosisFavourites()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Diagnosis Favourites Page!"
                    });
                    return PartialView("DiagnosisFavourites");
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

        public JsonResult GetAllDiagnosisFavourites(int empId, int? pdfId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<DiagnosisFavourites> favrouite = BusinessLogicLayer.EMR.DiagnosisFavourites.GetAllDiagnosisFavourites(empId, pdfId);

                return Json(favrouite, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion DiagnosisFavourites (Page Load)

        #region Diagnosis Favourites CRUD Operations

        //CREATE:DiagnosisFavourites
        public PartialViewResult CreateDiagnosisFavourite()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    DiagnosisFavourites diagnosis = new DiagnosisFavourites();
                    return PartialView("CreateDiagnosisFavourite", diagnosis);
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
        public ActionResult InsertDiagnosisFavourite(DiagnosisFavourites data)
        {
            try
            {
                //  bool isInserted = false;
                data.pdf_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Diagnosis.isValidDiagnosisFavourites(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.DiagnosisFavourites.InsertUpdateDiagnosisFavourites(data);
                        if (val > 0)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pdf_madeby,
                                log_desc = $"Employee Created New Diagnosis Favourites (Id) : {data.pdf_diagnosis}"
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Diagnosis Favourites Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            if (val == -1)
                            {
                                errors.Add("pdf_diagnosis", "Diagnosis Favourites already exists with same Code ! Duplicate Note Allowed");
                            }

                            else
                            {
                                errors.Add("", "Error while Creating Diagnosis Favourites! Please Try Again...");
                            }

                            return Json(new { isSuccess = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        //EDIT :Cheif Patient Diagnosis
        public PartialViewResult EditDiagnosisFavourite(int empId, int pdfId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<DiagnosisFavourites> diagnosis = BusinessLogicLayer.EMR.DiagnosisFavourites.GetAllDiagnosisFavourites(empId, pdfId);
                    return PartialView("EditDiagnosisFavourite", diagnosis.FirstOrDefault());
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
        public ActionResult UpdateDiagnosisFavourites(DiagnosisFavourites data)
        {
            try
            {
               
                data.pdf_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Diagnosis.isValidDiagnosisFavourites(data, out errors))
                    {
                        int val = BusinessLogicLayer.EMR.DiagnosisFavourites.InsertUpdateDiagnosisFavourites(data);
                        if (val > 0 )
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.pdf_madeby,
                                log_desc = $"Employee Updated Patient Diagnosis with Id = {data.pdfId}"
                            });
                            return Json(new { isUpdated = true, isSuccess = true, message = "Patient Diagnosis Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Patient Diagnosis Already Exists with the same details!" }, JsonRequestBehavior.AllowGet);
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

        //DELETE :Diagnosis Favourites

        [HttpPost]
        public ActionResult DeleteDiagnosisFavourites(int pdfId)
        {
            try
            {
                int pdf_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.DiagnosisFavourites.DeleteDiagnosisFavourites(pdfId, pdf_madeby);
                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Diagnosis Favourites with Id = {pdfId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete!" }, JsonRequestBehavior.AllowGet);
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

        #endregion Diagnosis Favourites CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["errorEMR"] = filterContext;
            filterContext.Result = RedirectToAction("ErrorEMR", "Common", new { area = "EMR" });
        }
    }
}