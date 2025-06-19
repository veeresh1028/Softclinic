using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class NarrativeDiagnosisController : Controller
    {
        #region Narrative Diagnosis (Page Load)
        // GET: EMR/NarrativeDiagnosis
        int PageId = (int)Pages.NarrativeDiagnosis;
        public PartialViewResult NarrativeDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Narrative Diagnosis Page!"
                    });

                    return PartialView("NarrativeDiagnosis");
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

        public JsonResult GetAllNarrativeDiagnosis(int appId, int? ntdId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NarrativeDiagnosis> narrative = BusinessLogicLayer.EMR.NarrativeDiagnosis.GetAllNarrativeDiagnosis(appId, ntdId);

                return Json(narrative, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/NarrativeDiagnosis

        public JsonResult GetAllPreNarrativeDiagnosis(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<NarrativeDiagnosis> narrative = BusinessLogicLayer.EMR.NarrativeDiagnosis.GetAllPreNarrativeDiagnosis(appId, patId);

                return Json(narrative, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Narrative Diagnosis (Page Load)

        #region Diagnosis Favourites CRUD Operations
        //CREATE:NarrativeDiagnosis

        public PartialViewResult CreateNarrativeDiagnosis()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    NarrativeDiagnosis narrative = new NarrativeDiagnosis();
                    return PartialView("CreateNarrativeDiagnosis", narrative);
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

        //GET:Narrative Diagnosis

        public ActionResult GetNarrative(string query)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<GetByName> Narrative = BusinessLogicLayer.EMR.NarrativeDiagnosis.GetNarrative(query);
                    var jsonResult = Json(Narrative, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertNarrativeDiagnosis(NarrativeDiagnosis data)
        {
            try
            {
                bool isInserted = false;
                data.ntd_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Diagnosis.isValidNarrativeDiagnosis(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.NarrativeDiagnosis.InsertUpdateNarrativeDiagnosis(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.ntd_madeby,
                                log_desc = $"Employee Created New Narrative Diagnosis (Id) : {data.ntdId}"
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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

        //EDIT :Narrative Diagnosis
        public PartialViewResult EditNarrativeDiagnosis(int appId, int ntdId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<NarrativeDiagnosis> Narrative = BusinessLogicLayer.EMR.NarrativeDiagnosis.GetAllNarrativeDiagnosis(appId, ntdId);
                    return PartialView("EditNarrativeDiagnosis", Narrative.FirstOrDefault());
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
        public ActionResult UpdateNarrativeDiagnosis(NarrativeDiagnosis data)
        {
            try
            {
                bool isInserted = false;
                data.ntd_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.Diagnosis.isValidNarrativeDiagnosis(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.NarrativeDiagnosis.InsertUpdateNarrativeDiagnosis(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.ntd_madeby,
                                log_desc = $"Employee Updated Narrative Diagnosis with Id = {data.ntdId}"
                            });
                            return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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

        //DELETE :Narrative Diagnosis

        [HttpPost]
        public ActionResult DeleteNarrativeDiagnosis(int ntdId)
        {
            try
            {
                int ntd_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.EMR.NarrativeDiagnosis.DeleteNarrativeDiagnosis(ntdId, ntd_madeby);
                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Narrative Diagnosis with Id = {ntdId}"
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

        #endregion 
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}