using BusinessEntities.NurseStation;
using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Org.BouncyCastle.Cms;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
using BusinessEntities.MNR;
using Google.Type;

namespace ClinicSoft.Areas.NurseStation.Controllers
{
    [Authorize]
    public class VitalSignsController : Controller
    {
        #region VitalSigns
        // GET: NurseStation/VitalSigns

        int PageId = (int)Pages.VitalSign;
        public PartialViewResult VitalSigns()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    return PartialView("VitalSigns");
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

        public JsonResult GetAllVitalSigns(int appId, int? signId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<VitalSigns> vital = BusinessLogicLayer.NurseStation.VitalSigns.GetAllVitalSigns(appId, signId);

                return Json(vital, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Previous/VitalSigns

        public JsonResult GetAllPreVitalSigns(int appId, int patId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<VitalSigns> vital = BusinessLogicLayer.NurseStation.VitalSigns.GetAllPreVitalSigns(appId, patId);

                return Json(vital, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }


        // Create: VitalSigns
        public PartialViewResult CreateVitalSigns(int? signId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {

                    VitalSigns vital = new VitalSigns();
                    if (signId == 0)
                    {
                        vital = new VitalSigns();
                    }
                    else
                    {
                        vital = BusinessLogicLayer.NurseStation.VitalSigns.GetAllVitalSigns(0, signId).FirstOrDefault();
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Copied Previous Patient Vital Signs with Id = {signId}"
                        });
                        
                    }
                    return PartialView("CreateVitalSigns", vital);
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
        public async Task<ActionResult> InsertVitalSigns(VitalSigns data)
        {
            int val = 0;
            bool isInserted = false;
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {


                    data.sign_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.VitalSigns.isValidVitalSigns(data, out errors))
                    {
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        MNRAck ack = new MNRAck();
                        val = BusinessLogicLayer.NurseStation.VitalSigns.InsertUpdateVitalSigns(data);

                        if (val>0)
                        {
                            BusinessLogicLayer.Common.AppJourney.InsertAppJourney(new BusinessEntities.Common.AppJourney
                            {
                                AJ_AJCId = 3,
                                AJ_AJSCId = 12,
                                AJ_AppId = int.Parse(emr.appId)
                            });
                            if (emr.set_sync == "Yes")
                            {
                               
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_1(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Inserted");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = -2,
                                            message = "Vital Sign Inserted Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ORUR01(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Inserted");
                                    
                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ORUR01(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Inserted");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Vital Sign Inserted Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);

                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Vital Sign Inserted Successfully" }, JsonRequestBehavior.AllowGet);
                            }

                        }
                        else if (val ==-1)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Vital Sign already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (val == -2)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Please Enter Past History First!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Failed to Insert Vital Signs !" }, JsonRequestBehavior.AllowGet);
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

        // Edit: VitalSigns
        [HttpGet]
        public PartialViewResult EditVitalSigns(int appId, int signId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    List<VitalSigns> vital = BusinessLogicLayer.NurseStation.VitalSigns.GetAllVitalSigns(appId, signId);

                    return PartialView("EditVitalSigns", vital.FirstOrDefault());
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
        public async Task<ActionResult> UpdateVitalSigns(VitalSigns data)
        {
            try
            {
                int val = 0;
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    data.sign_madeby = PageControl.getLoggedinId();
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.VitalSigns.isValidVitalSigns(data, out errors))
                    {
                        val = BusinessLogicLayer.NurseStation.VitalSigns.InsertUpdateVitalSigns(data);
                        EMRInfo emr = (EMRInfo)TempData["emr_data"];
                        TempData.Keep("emr_data");
                        MNRAck ack = new MNRAck();
                        if (val>0)
                        {
                            isInserted = true;
                            if (emr.set_sync == "Yes")
                            {
                                
                                if (emr.set_mnr == "Nabidh")
                                {
                                    if (emr.pat_class != "VIP")
                                    {
                                        ack = await MNR.Nabidh.ADTA08_1(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Updated");
                                    }
                                    else
                                    {
                                        ack = new MNRAck
                                        {
                                            value = 1,
                                            message = "Vital Sign Updated Successfully Without Sharing Data"
                                        };
                                    }
                                }
                                else if (emr.set_mnr == "Riayati")
                                {
                                    ack = await MNR.Riayati.ORUR01(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Updated");

                                }
                                else if (emr.set_mnr == "Malaffi")
                                {
                                    ack = await MNR.Malaffi.ORUR01(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Updated");

                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = -2,
                                        message = "Vital Sign Updated Successfully! Please Update The conectivity for sharing data"
                                    };
                                }
                                return Json(new { isInserted = true, isSuccess = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                                    
                               
                            }
                            else
                            {
                                return Json(new { isInserted = true, isSuccess = true, message = "Vital Sign Updated Successfully" }, JsonRequestBehavior.AllowGet);
                            }

                        }
                        else if (val == -2)
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Please Enter Past History First!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Failed to Insert Vital Signs !" }, JsonRequestBehavior.AllowGet);
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

        // Delete: VitalSigns
        [HttpPost]
        public async Task<ActionResult> DeleteVitalSigns(int signId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.NurseStation.VitalSigns.DeleteVitalSigns(signId, PageControl.getLoggedinId());
                    EMRInfo emr = (EMRInfo)TempData["emr_data"];
                    TempData.Keep("emr_data");
                    MNRAck ack = new MNRAck();

                    if (val == 1)
                    {
                        if (emr.set_sync == "Yes")
                        {
                            
                            if (emr.set_mnr == "Nabidh")
                            {
                                if (emr.pat_class != "VIP")
                                {
                                    ack = await MNR.Nabidh.ADTA08_1(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Deleted");
                                }
                                else
                                {
                                    ack = new MNRAck
                                    {
                                        value = 1,
                                        message = "Vital Sign Deleted Successfully Without Sharing Data"
                                    };
                                }
                            }
                            else if (emr.set_mnr == "Riayati")
                            {
                                ack = await MNR.Riayati.ORUR01(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Deleted");

                            }
                            else if (emr.set_mnr == "Malaffi")
                            {
                                ack = await MNR.Malaffi.ORUR01(int.Parse(emr.appId), int.Parse(emr.pat_code), int.Parse(emr.patId.ToString()), emr.app_fdate_time, emr.set_permit_no, "Deleted");

                            }
                            else
                            {
                                ack = new MNRAck
                                {
                                    value = -2,
                                    message = "Vital Sign Deleted Successfully! Please Update The conectivity for sharing data"
                                };
                            }
                            return Json(new { success = true, isAuthorized = true, message = ack.message }, JsonRequestBehavior.AllowGet);
                            
                        }
                        else
                        {
                            return Json(new { success = true, isAuthorized = true, message = "Vital Sign Deleted Successfully" }, JsonRequestBehavior.AllowGet);
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
        #endregion 
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}