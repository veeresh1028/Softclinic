using BusinessEntities;
using BusinessEntities.Masters;
using Google.Type;
using Microsoft.Ajax.Utilities;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DateTime = System.DateTime;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class InsuranceCompaniesController : Controller
    {
        int PageId = (int)Pages.InsuranceCompanies;

        #region Insurance Companies CRUD Operations
        [HttpGet]
        public ActionResult InsuranceCompanies()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Insurance Companies Page!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetAllInsuranceCompanies()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.InsuranceCompanies> iclist = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceCompanies(0);

                return Json(iclist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateInsuranceCompany()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsuranceCompanies insuranceCompany = new BusinessEntities.Masters.InsuranceCompanies();

                    insuranceCompany.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    insuranceCompany.InsuranceList = BusinessLogicLayer.Masters.InsuranceCompanies.GetActiveInsuranceCompanies(0, 0);
                    insuranceCompany.CountryList = BusinessLogicLayer.Lists.Countries.GetCountryList();

                    return PartialView("CreateInsuranceCompany", insuranceCompany);
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
        public ActionResult InsertInsuranceCompany(BusinessEntities.Masters.InsuranceCompanies data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.InsuranceCompanies.isValidInsuranceCompanyCreate(data, out errors))
                    {
                        data.ic_madeby = PageControl.getLoggedinId();
                        data.ic_modifiedby = data.ic_madeby;

                        isInserted = BusinessLogicLayer.Masters.InsuranceCompanies.InsertInsuranceCompany(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Created New Insurance Company : {data.ic_name}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Insurance Company Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Insurance Company already exists!" }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpGet]
        public PartialViewResult EditInsuranceCompany(int icId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsuranceCompanies insuranceCompany = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceCompanyById(icId).FirstOrDefault();

                    insuranceCompany.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    insuranceCompany.InsuranceList = BusinessLogicLayer.Masters.InsuranceCompanies.GetActiveInsuranceCompanies(0, 0);
                    insuranceCompany.CountryList = BusinessLogicLayer.Lists.Countries.GetCountryList();

                    return PartialView("EditInsuranceCompany", insuranceCompany);
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
        public ActionResult UpdateInsuranceCompany(BusinessEntities.Masters.InsuranceCompanies data)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.InsuranceCompanies.isValidInsuranceCompanyUpdate(data, out errors))
                    {
                        data.ic_modifiedby = PageControl.getLoggedinId();

                        isUpdated = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsuranceCompany(data);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Updated Insurance Company with icId = {data.icId}"
                            });

                            return Json(new { isUpdated = true, isSuccess = true, message = "Insurance Company Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, isSuccess = true, message = "Insurance Company already exists!" }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateInsuranceCompanyStatus(int icId, string ic_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int modifiedby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsuranceCompanyStatus(icId, ic_status, modifiedby);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Insurance Company Status to : {ic_status} with icId = {icId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Insurance Company Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Insurance Company with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Insurance Company Status!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult DeleteInsuranceCompany(int icId, string ic_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int modifiedby = PageControl.getLoggedinId();

                    int val = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsuranceCompanyStatus(icId, ic_status, modifiedby);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Insurance Company with icId = {icId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Insurance Company Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Insurance Company!" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Insurance Companies Notes
        [HttpGet]
        public PartialViewResult InsuranceNotes(int icId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.InsuranceNotes> insuranceNotes = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceNotes(icId);

                    TempData["icId"] = icId;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Insurance Company Notes with icId : {icId}"
                    });

                    return PartialView("InsuranceNotes", insuranceNotes);
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
        public JsonResult GetInsuranceNotes()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TempData.Keep("icId");

                int icId = int.Parse(TempData["icId"].ToString());

                List<BusinessEntities.Masters.InsuranceNotes> inusrance_notes = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceNotes(icId);

                TempData["ICID"] = icId;

                return Json(inusrance_notes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateInsuranceNote(int id = 0)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsuranceNotes ins_notes = new BusinessEntities.Masters.InsuranceNotes();

                    return PartialView("CreateInsuranceNote", ins_notes);
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
        public ActionResult InsertInsuranceNote(BusinessEntities.Masters.InsuranceNotes ins_note)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isInserted = false;
                    string error = string.Empty;

                    TempData.Keep("ICID");
                    ins_note.in_ins = int.Parse(TempData["ICID"].ToString());
                    ins_note.in_madeby = PageControl.getLoggedinId();

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string filename = System.DateTime.Now.ToString("HHmmss") + "_" + Path.GetFileName(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            string path = Server.MapPath("~/images/insurance_documents");
                            string path_year = Path.Combine(path, System.DateTime.Now.ToString("yyyy"));
                            string path_month = Path.Combine(path_year, System.DateTime.Now.ToString("MMMM"));
                            string path_day = Path.Combine(path_month, System.DateTime.Now.ToString("dd"));
                            string file_path = Path.Combine(path_day, filename);

                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".pdf")
                                {
                                    // Check if Internet Explorer
                                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                    {
                                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                        filename = testfiles[testfiles.Length - 1];
                                    }
                                    else
                                    {
                                        ins_note.in_document = filename;
                                    }

                                    ins_note.in_path = path_day;

                                    if (!Directory.Exists(path_year)) { Directory.CreateDirectory(path_year); }

                                    if (!Directory.Exists(path_month)) { Directory.CreateDirectory(path_month); }

                                    if (!Directory.Exists(path_day)) { Directory.CreateDirectory(path_day); }

                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    error = "Incorrect format! Allowed formats : .PDF";
                                }
                            }
                            else
                            {
                                error = "The file has to be less than 5 MB!";
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(error))
                    {
                        isInserted = BusinessLogicLayer.Masters.InsuranceCompanies.InsertInsuranceNote(ins_note);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = ins_note.in_madeby,
                                log_desc = $"Employee Created New Insurance Note with icId = {ins_note.in_ins}"
                            });

                            return Json(new { success = true, message = "Insurance Note Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, message = "Insurance Note already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = error }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpGet]
        public FilePathResult DownloadInsuranceNoteFile(string fileName, string filepath)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Downloaded Insurance Note : {fileName}"
                });

                return new FilePathResult(string.Format(@"" + filepath + "\\{0}", fileName), "application/pdf");
            }
            else
            {
                return new FilePathResult(null, "application/pdf");
            }
        }

        [HttpGet]
        public PartialViewResult EditInsuranceNote(int inId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.InsuranceNotes> inusrance_note = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceNoteById(inId);

                    return PartialView("EditInsuranceNote", inusrance_note.FirstOrDefault());
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
        public ActionResult UpdateInsuranceNote(BusinessEntities.Masters.InsuranceNotes ins_note)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isUpdated = false;
                    string error = string.Empty;

                    TempData.Keep("ICID");
                    ins_note.in_ins = int.Parse(TempData["ICID"].ToString());
                    ins_note.in_madeby = PageControl.getLoggedinId();

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string filename = System.DateTime.Now.ToString("HHmmss") + "_" + Path.GetFileName(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            string path = Server.MapPath("~/images/insurance_documents");
                            string path_year = Path.Combine(path, System.DateTime.Now.ToString("yyyy"));
                            string path_month = Path.Combine(path_year, System.DateTime.Now.ToString("MMMM"));
                            string path_day = Path.Combine(path_month, System.DateTime.Now.ToString("dd"));
                            string file_path = Path.Combine(path_day, filename);

                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".pdf")
                                {
                                    // Check if Internet Explorer
                                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                    {
                                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                        filename = testfiles[testfiles.Length - 1];
                                    }
                                    else
                                    {
                                        ins_note.in_document = filename;
                                    }

                                    ins_note.in_path = path_day;

                                    if (!Directory.Exists(path_year)) { Directory.CreateDirectory(path_year); }

                                    if (!Directory.Exists(path_month)) { Directory.CreateDirectory(path_month); }

                                    if (!Directory.Exists(path_day)) { Directory.CreateDirectory(path_day); }

                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    error = "Incorrect format! Allowed formats : .PDF";
                                }
                            }
                            else
                            {
                                error = "The file has to be less than 5 MB!";
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(error))
                    {
                        isUpdated = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsuranceNote(ins_note);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = ins_note.in_madeby,
                                log_desc = $"Employee Updated Insurance Note with icId = {ins_note.in_ins}"
                            });

                            return Json(new { success = true, message = "Insurance Note Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, message = "Insurance Note already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = error }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { isAuthorized = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteInsuranceNote(int inId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    string result = BusinessLogicLayer.Masters.InsuranceCompanies.DeleteInsuranceNote(inId);

                    if (result.Contains("Deleted"))
                    {
                        return Json(new { isAuthorized = true, success = true, message = "Insurance Note Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed to Delete Insurance Note!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Insurance Payers
        [HttpGet]
        public PartialViewResult InsurancePayers(int icId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.InsurancePayers> insurancePayers = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayers(icId);

                    TempData["icId"] = icId;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Insurance Payers with icId : {icId}"
                    });

                    return PartialView("InsurancePayers", insurancePayers);
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
        public JsonResult GetInsurancePayers()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TempData.Keep("icId");

                int icId = int.Parse(TempData["icId"].ToString());

                List<BusinessEntities.Masters.InsurancePayers> insurancePayers = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayers(icId);

                TempData["ICID"] = icId;

                return Json(insurancePayers, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateInsurancePayer(int id = 0)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsurancePayers insurancePayer = new BusinessEntities.Masters.InsurancePayers();

                    return PartialView("CreateInsurancePayer", insurancePayer);
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
        public ActionResult InsertInsurancePayer(BusinessEntities.Masters.InsurancePayers insurancePayer)
        {
            try
            {
                int Action = (int)Actions.Create;

                bool isInserted = false;

                if (PageControl.haveAccess(PageId, Action))
                {
                    TempData.Keep("ICID");
                    insurancePayer.ip_ins = int.Parse(TempData["ICID"].ToString());

                    isInserted = BusinessLogicLayer.Masters.InsuranceCompanies.InsertInsurancePayer(insurancePayer);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created New Insurance Payer : {insurancePayer.ip_name} for icId = {insurancePayer.ip_ins}"
                        });

                        return Json(new { isInserted = true, message = "Insurance Payer Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = "Insurance Payer already exists!" }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpGet]
        public PartialViewResult EditInsurancePayer(int ipId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsurancePayers insurancePayer = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayerById(ipId).FirstOrDefault();

                    return PartialView("EditInsurancePayer", insurancePayer);
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
        public ActionResult UpdateInsurancePayer(BusinessEntities.Masters.InsurancePayers insurancePayer)
        {
            try
            {
                bool isUpdated = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    isUpdated = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsurancePayer(insurancePayer);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Insurance Payer : {insurancePayer.ipId} for icId = {insurancePayer.ip_ins}"
                        });

                        return Json(new { isUpdated = true, message = "Insurance Payer Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = "Insurance Payer already exists!" }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateInsurancePayerStatus(int ipId, string ip_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsurancePayerStatus(ipId, ip_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Insurance Payer Status to : {ip_status} with ipId = {ipId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Insurance Payer Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Insurance Payer with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Insurance Payer Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult DeleteInsurancePayer(int ipId, string ip_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsurancePayerStatus(ipId, ip_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Insurance Payer with ipId = {ipId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Insurance Payer Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Insurance Payer!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Insurance Payer Notes
        [HttpGet]
        public PartialViewResult InsurancePayerNotes(int ipId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.InsurancePayerNotes> ip_notes = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayerNotes(ipId);

                    TempData["ipId"] = ipId;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Insurance Payer Notes with ipId : {ipId}"
                    });

                    return PartialView("InsurancePayerNotes", ip_notes);
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
        public JsonResult GetInsurancePayerNotes()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TempData.Keep("ipId");
                int ipId = int.Parse(TempData["ipId"].ToString());

                List<BusinessEntities.Masters.InsurancePayerNotes> payerNotes = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayerNotes(ipId);

                TempData["new_ipId"] = ipId;

                return Json(payerNotes, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateInsurancePayerNote(int id = 0)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsurancePayerNotes payerNote = new BusinessEntities.Masters.InsurancePayerNotes();

                    return PartialView("CreateInsurancePayerNote", payerNote);
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
        public ActionResult InsertInsurancePayerNote(BusinessEntities.Masters.InsurancePayerNotes insurancePayerNote)
        {
            try
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isInserted = false;
                    string error = string.Empty;

                    TempData.Keep("new_ipId");
                    insurancePayerNote.ipn_ip_ins = int.Parse(TempData["new_ipId"].ToString());
                    insurancePayerNote.ipn_madeby = PageControl.getLoggedinId();

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string filename = DateTime.Now.ToString("HHmmss") + "_" + Path.GetFileName(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            string path = Server.MapPath("~/images/insurance_documents");
                            string path_year = Path.Combine(path, DateTime.Now.ToString("yyyy"));
                            string path_month = Path.Combine(path_year, DateTime.Now.ToString("MMMM"));
                            string path_day = Path.Combine(path_month, DateTime.Now.ToString("dd"));
                            string file_path = Path.Combine(path_day, filename);

                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".pdf")
                                {
                                    // Check if Internet Explorer
                                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                    {
                                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                        filename = testfiles[testfiles.Length - 1];
                                    }
                                    else
                                    {
                                        insurancePayerNote.ipn_document = filename;
                                    }

                                    insurancePayerNote.ipn_path = path_day;

                                    if (!Directory.Exists(path_year)) { Directory.CreateDirectory(path_year); }

                                    if (!Directory.Exists(path_month)) { Directory.CreateDirectory(path_month); }

                                    if (!Directory.Exists(path_day)) { Directory.CreateDirectory(path_day); }

                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    error = "Incorrect format! Allowed formats : .PDF";
                                }
                            }
                            else
                            {
                                error = "The file has to be less than 5 MB!";
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(error))
                    {
                        isInserted = BusinessLogicLayer.Masters.InsuranceCompanies.InsertInsurancePayerNote(insurancePayerNote);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = insurancePayerNote.ipn_madeby,
                                log_desc = $"Employee Created New Payer Note with icId = {insurancePayerNote.ipn_ip_ins}"
                            });

                            return Json(new { success = true, message = "Insurance Payer Note Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, message = "Insurance Payer Note already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = error }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpGet]
        public FilePathResult DownloadInsurancePayerFile(string fileName, string filepath)
        {
            int Action = (int)Actions.Export;
            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Downloaded Insurance Payer Note : {fileName}"
                });

                return new FilePathResult(string.Format(@"" + filepath + "\\{0}", fileName), "application/pdf");
            }
            else
            {
                return new FilePathResult(null, "application/pdf");
            }
        }

        [HttpGet]
        public PartialViewResult EditInsurancePayerNote(int ipnId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsurancePayerNotes insurancePayerNote = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsurancePayerNoteById(ipnId).FirstOrDefault();

                    return PartialView("EditInsurancePayerNote", insurancePayerNote);
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
        public ActionResult UpdateInsurancePayerNote(BusinessEntities.Masters.InsurancePayerNotes insurancePayerNote)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    bool isUpdated = false;
                    string error = string.Empty;

                    insurancePayerNote.ipn_madeby = PageControl.getLoggedinId();

                    if (Request.Files.Count > 0)
                    {
                        HttpFileCollectionBase files = Request.Files;

                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string filename = DateTime.Now.ToString("HHmmss") + "_" + Path.GetFileName(file.FileName);
                            string extension = Path.GetExtension(file.FileName);
                            string path = Server.MapPath("~/images/insurance_documents");
                            string path_year = Path.Combine(path, DateTime.Now.ToString("yyyy"));
                            string path_month = Path.Combine(path_year, DateTime.Now.ToString("MMMM"));
                            string path_day = Path.Combine(path_month, DateTime.Now.ToString("dd"));
                            string file_path = Path.Combine(path_day, filename);

                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".pdf")
                                {
                                    // Check if Internet Explorer
                                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                    {
                                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                        filename = testfiles[testfiles.Length - 1];
                                    }
                                    else
                                    {
                                        insurancePayerNote.ipn_document = filename;
                                    }

                                    insurancePayerNote.ipn_path = path_day;

                                    if (!Directory.Exists(path_year)) { Directory.CreateDirectory(path_year); }

                                    if (!Directory.Exists(path_month)) { Directory.CreateDirectory(path_month); }

                                    if (!Directory.Exists(path_day)) { Directory.CreateDirectory(path_day); }

                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    error = "Incorrect format! Allowed formats : .PDF";
                                }
                            }
                            else
                            {
                                error = "The file has to be less than 5 MB!";
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(error))
                    {
                        isUpdated = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsurancePayerNote(insurancePayerNote);

                        if (isUpdated)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = insurancePayerNote.ipn_madeby,
                                log_desc = $"Employee Updated Payer Note with icId = {insurancePayerNote.ipn_ip_ins}"
                            });

                            return Json(new { success = true, message = "Insurance Payer Note Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { success = false, message = "Insurance Payer Note already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { success = false, message = error }, JsonRequestBehavior.AllowGet);
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
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteInsurancePayerNote(int ipnId)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    string result = BusinessLogicLayer.Masters.InsuranceCompanies.DeleteInsurancePayerNote(ipnId);

                    if (result.Contains("Deleted"))
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Insurance Payer Note with ipnId = {ipnId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Insurance Payer Note Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed to Delete Insurance Payer Note!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
        #endregion

        #region Insurance Companies Networks
        [HttpGet]
        public PartialViewResult InsuranceNetworks(int icId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.InsuranceNetworkList> insuranceNetworks = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceNetworks(icId);

                    TempData["icId"] = icId;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Insurance Networks with icId : {icId}"
                    });

                    return PartialView("InsuranceNetworks", insuranceNetworks);
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
        public JsonResult GetInsuranceNetworks()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                TempData.Keep("icId");
                int icId = int.Parse(TempData["icId"].ToString());

                List<BusinessEntities.Masters.InsuranceNetworkList> insuranceNetworks = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceNetworks(icId);

                TempData["ICID"] = icId;

                return Json(insuranceNetworks, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult CreateInsuranceNetwork(int id = 0)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsuranceNetworks ins_networks = new BusinessEntities.Masters.InsuranceNetworks();

                    return PartialView("CreateInsuranceNetwork", ins_networks);
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
        public ActionResult InsertInsuranceNetwork(BusinessEntities.Masters.InsuranceNetworks data)
        {
            bool isInserted = false;
            int Action = (int)Actions.Create;

            TempData.Keep("icId");
            data.is_icId = int.Parse(TempData["icId"].ToString());

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.InsuranceCompanies.isValidInsuranceNetworks(data, out errors))
                {
                    isInserted = BusinessLogicLayer.Masters.InsuranceCompanies.InsertInsuranceNetwork(data);

                    if (isInserted)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Created New Insurance Network : {data.is_title} for icId = {data.is_icId}"
                        });

                        return Json(new { isInserted = true, isSuccess = true, message = "Insurance Network Created Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isInserted = false, isSuccess = true, message = "Insurance Network Already Exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public PartialViewResult EditInsuranceNetwork(int isId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.InsuranceNetworks insuranceNetwork = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceNetworkById(isId).FirstOrDefault();

                    return PartialView("EditInsuranceNetwork", insuranceNetwork);
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
        public ActionResult UpdateInsuranceNetwork(BusinessEntities.Masters.InsuranceNetworks data)
        {
            bool isUpdated = false;

            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (SecurityLayer.FormValidations.InsuranceCompanies.isValidInsuranceNetworksUpdate(data, out errors))
                {
                    isUpdated = BusinessLogicLayer.Masters.InsuranceCompanies.InsertInsuranceNetwork(data);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Insurance Network : {data.is_title} for icId = {data.is_icId}"
                        });

                        return Json(new { isUpdated = true, isSuccess = true, message = "Insurance Network Updated Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Insurance Network Already Exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult UpdateInsuranceNetworkStatus(int isId, string is_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsuranceNetworkStatus(isId, is_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Insurance Network Status to : {is_status} with isId = {isId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Insurance Network Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Insurance Network with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Insurance Network Status!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult DeleteInsuranceNetwork(int isId, string is_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.InsuranceCompanies.UpdateInsuranceNetworkStatus(isId, is_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Insurance Network with isId = {isId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Insurance Network Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Insurance Network!" }, JsonRequestBehavior.AllowGet);
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
        #endregion

        #region Insurance Companies Audit Logs
        [HttpGet]
        public PartialViewResult InsuranceCompanyLogs(int icId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.AuditLogs.InsuranceCompanyLogs> loglist = BusinessLogicLayer.Masters.InsuranceCompanies.GetInsuranceCompanyLogs(icId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee viewed Audit Logs of Insurance Company with icId = {icId}"
                    });

                    return PartialView("InsuranceCompanyLogs", loglist);
                }
                else
                {
                    return PartialView("Unauthorized");
                }
            }
            else
            {
                return PartialView("_SessionExpired");
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