using BusinessEntities;
using BusinessEntities.Lists;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class ClinicSettingsController : Controller
    {
        int PageId = (int)Pages.ClinicSettings;

        [HttpGet]
        public ActionResult ClinicSettingIndex()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Clinic Settings!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetClinicSetting()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Company> dataList = BusinessLogicLayer.Company.GetBranchDetails(0);

                return Json(new { isAuthorized = true, message = "Access Denied!", data = dataList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public FileContentResult Download(int id, string type)
        {
            int Action = (int)Actions.Export;

            if (PageControl.haveAccess(PageId, Action))
            {
                byte[] data = null;
                string desc = "";

                DataTable dt = BusinessLogicLayer.Company.GetBranches(id);

                DataRow row = dt.Rows[0];

                if (type == "header")
                {
                    if ((row["set_header_image"].ToString().Trim() != "") &&
                    (row["set_header_image"].ToString().Trim() != null) &&
                    (row["set_header_image"].ToString().Trim() != "NA"))
                    {
                        string fileName = Path.Combine(Server.MapPath("~/images/header_images"), row["set_header_image"].ToString().Trim());
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        data = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();
                        //data = (byte[])row["set_header_binary"];
                        string[] strArr = row["set_header_image"].ToString().Split('.');
                        Response.AppendHeader("Content-type", "." + strArr[1].Trim());
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + row["set_header_image"].ToString().Trim());

                        desc = "Header";
                    }
                }
                else if (type == "footer")
                {
                    if ((row["set_footer_image"].ToString().Trim() != "") &&
                    (row["set_footer_image"].ToString().Trim() != null) &&
                    (row["set_footer_image"].ToString().Trim() != "NA"))
                    {
                        string fileName = Path.Combine(Server.MapPath("~/images/footer_images"), row["set_footer_image"].ToString().Trim());
                        System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);
                        long byteLength = new System.IO.FileInfo(fileName).Length;
                        data = binaryReader.ReadBytes((Int32)byteLength);
                        fs.Close();
                        fs.Dispose();
                        binaryReader.Close();
                        //data = (byte[])row["set_footer_binary"];
                        string[] strArr = row["set_footer_image"].ToString().Split('.');
                        Response.AppendHeader("Content-type", "." + strArr[1].Trim());
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + row["set_footer_image"].ToString().Trim());

                        desc = "Footer";
                    }
                }

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Downloaded Company {desc}!"
                });

                return new FileContentResult(data, "image/jpeg");
            }
            else
            {
                return new FileContentResult(null, "image/jpeg");
            }
        }

        [HttpGet]
        public PartialViewResult EditSettings(int setId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    // Load Branch to Edit
                    List<Company> setting = BusinessLogicLayer.Company.GetBranchDetails(setId);

                    // Load Countries Dropdown
                    DataTable dt1 = BusinessLogicLayer.Lists.Countries.GetCountries(0);
                    SelectList CountriesList = Models.Helper.ToSelectList(dt1, "countryId", "country");
                    ViewData["CountriesList"] = CountriesList;

                    return PartialView("EditSettings", setting.FirstOrDefault());
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
        public ActionResult UpdateSettings(Company data)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                bool isUpdated = false;
                string error = string.Empty;
                data.set_modifyby = PageControl.getLoggedinId();

                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                        string path = "";
                        string filename = Path.GetFileName(file.FileName);
                        string extension = Path.GetExtension(file.FileName);
                        string key = files.AllKeys[i];

                        if (key == "set_header_image")
                        {
                            path = Server.MapPath(ConfigurationManager.AppSettings["ClinicHeader"]);
                        }
                        else if (key == "set_footer_image")
                        {
                            path = Server.MapPath(ConfigurationManager.AppSettings["ClinicFooter"]);
                        }
                        else if (key == "set_thumbnail")
                        {
                            path = Server.MapPath(ConfigurationManager.AppSettings["ClinicHeader"]);
                        }

                        string file_path = Path.Combine(path, filename);

                        if (file.ContentLength <= 5242880)
                        {
                            if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                            {
                                // Check if Internet Explorer
                                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                {
                                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                    filename = testfiles[testfiles.Length - 1];
                                }
                                else
                                {
                                    filename = file.FileName;
                                }

                                // Assign File name to Model
                                if (key == "set_header_image")
                                {
                                    data.set_header_image = filename;
                                }
                                else if (key == "set_footer_image")
                                {
                                    data.set_footer_image = filename;
                                }
                                else if (key == "set_thumbnail")
                                {
                                    data.set_thumbnail = filename;
                                }

                                if (System.IO.File.Exists(file_path))
                                {
                                    System.IO.File.Delete(file_path);
                                }

                                file.SaveAs(file_path);
                            }
                            else
                            {
                                error = "Invalid format! Allowed formats : .png / .jpg/ .jpeg / .gif";
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
                    isUpdated = BusinessLogicLayer.Company.UpdateBranch(data);

                    if (isUpdated)
                    {
                        return Json(new { isUpdated = true, message = "Clinic Settings Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, message = "Failed to Update Clinic Settings!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isUpdated = false, message = error }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetHeaderFooter(int setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Company> data = BusinessLogicLayer.Company.GetHeaderFooter(setId);

                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult GetSettingsLogs(int setId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {

                    List<BusinessEntities.Masters.AuditLogs.ClinicSettingsLogs> loglist = BusinessLogicLayer.Company.GetCompanyLogs(setId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee viewed audit logs of Clinic Settings with setId = {setId}"
                    });

                    return PartialView("SettingsLogs", loglist);
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

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }
}