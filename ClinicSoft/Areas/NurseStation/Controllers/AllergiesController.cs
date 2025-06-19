using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.MNR;
using BusinessEntities.NurseStation;
using Google.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class AllergiesController : Controller
    {
        #region Allergies (Page Load)
        // GET: NurseStation/Allergies
        int PageId = (int)Pages.Allergies; 
        public PartialViewResult Allergies()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;
                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = "Employee Viewed Allergies Page!"
                    });
                    return PartialView("Allergies");
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

        public JsonResult GetAllAllergies(int appId, int? allId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Allergies> allergies = BusinessLogicLayer.NurseStation.Allergies.GetAllAllergies(appId, allId);

                return Json(allergies, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/Allergies
        public JsonResult GetAllPreAllergies(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Allergies> allergy = BusinessLogicLayer.NurseStation.Allergies.GetAllPreAllergies(appId, patId);

                return Json(allergy, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion Allergies (Page Load)
        #region Allergies  CRUD Operations
        // Create: Allergies
        public PartialViewResult CreateAllergies(int? allId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    Allergies allergy = new Allergies();
                    if (allId == 0)
                    {
                        allergy = new Allergies();
                    }
                    else
                    {
                        allergy = BusinessLogicLayer.NurseStation.Allergies.GetAllAllergies(0, allId).FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous Patient Allergies with Id = {allId}"
                        });
                    }
                    return PartialView("CreateAllergies", allergy);
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
        public async Task<ActionResult> InsertAllergies(Allergies data)
        {
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.all_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Allergies.isValidAllergies(data, out errors))
                    {
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        MNRAck ack = new MNRAck();
                        isInserted = BusinessLogicLayer.NurseStation.Allergies.InsertUpdateAllergies(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.all_madeby,
                                log_desc = $"Employee Created New Allergies with (Id) : {data.allId}"
                            });
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 3,
                                AJ_AJSCId = 7,
                                AJ_AppId = data.all_appId
                            });
                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_4(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Inserted");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Allergies Inserted Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA60_A(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no);

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA31(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Inserted");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Allergies Inserted Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Allergies Inserted Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Allergies already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Edit: Allergies
        [HttpGet]
        public PartialViewResult EditAllergies(int appId, int allId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<Allergies> allergy = BusinessLogicLayer.NurseStation.Allergies.GetAllAllergies(appId, allId);

                    return PartialView("EditAllergies", allergy.FirstOrDefault());
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
        public async Task<ActionResult> UpdateAllergies(Allergies data)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.all_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Allergies.isValidAllergies(data, out errors))
                    {
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        MNRAck ack = new MNRAck();
                        isUpdated = BusinessLogicLayer.NurseStation.Allergies.InsertUpdateAllergies(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = data.all_madeby,
                                log_desc = $"Employee Updated Allergies with (Id) : {data.allId}"
                            });
                            if (emr.set_sync == "Yes")
                            {

                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_4(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Updated");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Allergies Updated Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ADTA60_U(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no);

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ADTA31(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Updated");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Allergies Updated Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Allergies Updated Successfully" }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Allergies already exists!" }, JsonRequestBehavior.AllowGet);
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

        // Delete: Allergies
        [HttpPost]
        public async Task<ActionResult> DeleteAllergies(int allId)
        {
            try
            {
                int Action = (int)Actions.Delete;
                EMRInfo emr = (EMRInfo)TempData["emr_data"];
                TempData.Keep("emr_data");
                MNRAck ack = new MNRAck();
                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.NurseStation.Allergies.DeleteAllergies(allId, PageControl.getLoggedinId());

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Allergies with (Id) : {allId}"
                        });
                        if (emr.set_sync == "Yes")
                        {

                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA08_4(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Deleted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Allergies Deleted Successfully Without Sharing Data"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ADTA60_D(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no);

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ADTA31(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Deleted");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Allergies Deleted Successfully! Please Update The conectivity for sharing data"
                                };
                            }
                            return Json(new { success = true, isAuthorized = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Allergies Deleted Successfully" }, JsonRequestBehavior.AllowGet);
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

        // GET: Allergies/MALAFFI NABIDH RIYATI CODESETS
        [HttpGet]
        public ActionResult get_MalaffiNabihRiyatiData(string query,string type)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {

                    List<CommonDDL> allerList = BusinessLogicLayer.NurseStation.Allergies.get_MalaffiNabihRiyatiData(query, type);
                    var jsonResult = Json(allerList, JsonRequestBehavior.AllowGet);
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
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}