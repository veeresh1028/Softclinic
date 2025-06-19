using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.EMR;
using BusinessEntities.MNR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.EMR.Controllers
{
    [Authorize]
    public class ProgressNotesController : Controller
    {
        int PageId = (int)Pages.ProgressNotes;
        #region ProgressNotes (Page Load)
        // GET: EMR/ProgressNotes

        public PartialViewResult ProgressNotes()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed ProgressNotes Page!"
                    });
                    return PartialView("ProgressNotes");
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

        public JsonResult GetAllProgressNotes(int appId, int? mnId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ProgressNotes> ProgressNotes = BusinessLogicLayer.EMR.ProgressNotes.GetAllProgressNotes(appId, mnId);

                return Json(ProgressNotes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/ProgressNotes

        public JsonResult GetAllPreProgressNotes(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<ProgressNotes> notes = BusinessLogicLayer.EMR.ProgressNotes.GetAllPreProgressNotes(appId, patId);

                return Json(notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        //GET:Complaints Master

        public ActionResult GetNotes(string query,string nsm_flag)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<GetByName> notes = BusinessLogicLayer.EMR.ProgressNotes.GetNotes(query, nsm_flag);
                    var jsonResult = Json(notes, JsonRequestBehavior.AllowGet);
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

        #endregion ProgressNotes (Page Load)

        #region ProgressNotes  CRUD Operations
        // Create: ProgressNotes
        public PartialViewResult CreateProgressNotes()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    ProgressNotes notes = new ProgressNotes();
                    return PartialView("CreateProgressNotes", notes);
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
        public async Task<ActionResult> InsertProgressNotes(ProgressNotes data)
        {
            try
            {
                bool isInserted = false;
                data.mn_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidProgressNotes(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.EMR.ProgressNotes.InsertUpdateProgressNotes(data);
                        if (isInserted)
                        {
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 4,
                                AJ_AJSCId = 18,
                                AJ_AppId = int.Parse(emr.appId)
                            });
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.mn_madeby,
                                log_desc = $"Employee Created New ProgressNotes (Id) : {data.mnId}"
                            });
                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.MDMT02(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time);

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Progress Notes Inserted Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Progress Notes Inserted Successfully" }, JsonRequestBehavior.AllowGet);
                            }

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

        //EDIT :Cheif ProgressNotes
        public PartialViewResult EditProgressNotes(int appId, int mnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<ProgressNotes> ProgressNotes = BusinessLogicLayer.EMR.ProgressNotes.GetAllProgressNotes(appId, mnId);
                    return PartialView("EditProgressNotes", ProgressNotes.FirstOrDefault());
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
        public async Task<ActionResult> UpdateProgressNotes(ProgressNotes data)
        {
            try
            {
                bool isUpdated = false;
                data.mn_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.EMR.MainNotes.isValidProgressNotes(data, out errors))
                    {
                        isUpdated = BusinessLogicLayer.EMR.ProgressNotes.InsertUpdateProgressNotes(data);
                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.mn_madeby,
                                log_desc = $"Employee Updated New ProgressNotes (Id) : {data.mnId}"
                            });
                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.MDMT08(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time);

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Progress Notes Updated Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isUpdated = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isUpdated = true, isSuccess = true, message = "Progress Notes Updated Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);
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
        //DELETE :ProgressNotes

        [HttpPost]
        public async Task<ActionResult> DeleteProgressNotes(int mnId)
        {
            try
            {
                int mn_madeby = PageControl.getLoggedinId();
                int Action = (int)Actions.Delete;
                if (PageControl.haveAccess(PageId, Action))
                {
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();
                    int val = BusinessLogicLayer.EMR.ProgressNotes.DeleteProgressNotes(mnId, mn_madeby);
                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = mn_madeby,
                            log_desc = $"Employee Deleted ProgressNotes for (Id) : {mnId}"
                        });
                        if (emr.set_sync == "Yes")
                        {

                            if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.MDMT11(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time);

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Progress Notes Deleted Successfully! Please Update The conectivity for sharing data"
                                };
                            }
                            return Json(new { success = true, isAuthorized = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Progress Notes Deleted Successfully" }, JsonRequestBehavior.AllowGet);
                        }
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

        #endregion ProgressNotes  CRUD Operations
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}