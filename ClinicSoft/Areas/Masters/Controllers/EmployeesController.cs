using BusinessEntities;
using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using BusinessEntities.Patient;
using Google.Type;
using Newtonsoft.Json;
using RestSharp;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        int PageId = (int)Pages.Employees;
        int PageId_Whatsapp = (int)Pages.EmployeeWhatsApp;
        int PageId_Email = (int)Pages.EmployeeEmail;
        int PageId_SMS = (int)Pages.EmployeeSMS;

        #region Employees Master (Page Load & Search)
        [HttpGet]
        public ActionResult Employees(EmployeesSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<Employees> employeelist = BusinessLogicLayer.Masters.Employees.GetEmployees(data);

                if (employeelist.Count == 0)
                {
                    TempData["InfoMessage"] = "No Employee(s) Currently Exist in ClinicSoft!";
                }

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Employees & Security!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public ActionResult GetSpeciality(string _type, string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    var type = "";
                    string category = "";
                    if (_type == "DHA")
                    {
                        type = "NABIDH";
                        category = "Hospital Service";
                    }
                    else if (_type == "MOH")
                    {
                        type = "RIAYATI";
                        category = "Hospital Service";
                    }
                    else if (_type == "HAAD")
                    {
                        type = "MALAFFI";
                        category = "Specialty";
                    }
                    else if (_type == "Cash")
                    {
                        type = "Cash";
                    }
                    else
                    {
                        type = "";
                    }

                    List<GetByName> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSpeciality(type, query, category);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetSetupinfo(int setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<Company> SpecialityList = BusinessLogicLayer.Masters.Employees.GetSetupinfo(setId);
                    var jsonResult = Json(SpecialityList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetDHASpeciality(string query = "")
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> DHASpecialityList = BusinessLogicLayer.Masters.Employees.GetDHASpeciality(query);
                    var jsonResult = Json(DHASpecialityList, JsonRequestBehavior.AllowGet);
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
        public JsonResult GetEmployees(EmployeesSearch data)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                //if (Action == 3)
                //{
                //    data.empId = 0;
                //}
                List<BusinessEntities.Masters.Employees> employeelist = BusinessLogicLayer.Masters.Employees.GetEmployees(data);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Searched Employees & Security!"
                });

                var jsonResult = Json(employeelist, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Employees Advanced Filters
        [HttpGet]
        public ActionResult GetBranches(int? empId, int? setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> branchList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranchesForEmployees(empId, setId);
                    branchList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(branchList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetDepartments(int? deptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> departmentList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Masters.Employees.GetDepartmentEmployees(deptId);
                    departmentList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(departmentList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(departmentList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetDesignations(int? desigId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<CommonDDL> designationList = new List<CommonDDL>();
                try
                {
                    DataTable dt = BusinessLogicLayer.Masters.Employees.GetDesignationsEmployees(desigId);
                    designationList = SecurityLayer.TableToList.ConvertDataTable<CommonDDL>(dt);

                    var jsonResult = Json(designationList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception ex)
                {
                    var jsonResult = Json(designationList, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetNationalities()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> NationalitiesList = BusinessLogicLayer.Appointment.Appointment.GetNationalities();

                    var jsonResult = Json(NationalitiesList, JsonRequestBehavior.AllowGet);
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

        #region Employees CRUD Operations
        [HttpGet]
        public PartialViewResult CreateEmployee()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Employees emp = new Employees();

                    emp.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    emp.DepartmentList = BusinessLogicLayer.Masters.Departments.GetActiveDepartments();
                    emp.DesignationList = BusinessLogicLayer.Masters.Designations.GetActiveDesignations(0);
                    emp.NationalityList = BusinessLogicLayer.Nationality.GetNationalitiesList();

                    return PartialView("CreateEmployee", emp);
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
        public ActionResult InsertEmployee(Employees data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                bool isInserted = false;

                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                        string path = "";
                        string filename = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);

                        filename = filename + "_" + data.emp_name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                        string key = files.AllKeys[i];

                        if (key == "emp_sign")
                        {
                            path = Server.MapPath("~/images/EMPLOYEE_SIGNS/");
                        }
                        else if (key == "emp_photo")
                        {
                            path = Server.MapPath("~/images/employee_photos/");
                        }
                        else if (key == "emp_emid")
                        {
                            filename = filename + "_" + data.emp_name + "_EMID_FRONT_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            path = Server.MapPath("~/images/EMPLOYEE_EMID/");
                        }
                        else if (key == "emp_stamp")
                        {
                            filename = filename + "_" + data.emp_name + "_EMID_BACK_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            path = Server.MapPath("~/images/EMPLOYEE_EMID/");
                        }

                        string file_path = Path.Combine(path, filename);

                        if (files.AllKeys[i] == "emp_sign")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_sign = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_sign", "Invalid format for Sign! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_sign", "Employee Sign image size should be less than 5 MB!");
                            }
                        }
                        else if (files.AllKeys[i] == "emp_photo")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_photo = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_photo", "Invalid format for Photo! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_photo", "Employee Photo image size should be less than 5 MB!");
                            }
                        }
                        else if (files.AllKeys[i] == "emp_emid")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_emid = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_emid", "Invalid format for EMID Front! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_emid", "Employee EMID Front image size should be less than 5 MB!");
                            }
                        }
                        else if (files.AllKeys[i] == "emp_stamp")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_stamp = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_stamp", "Invalid format for EMID Back! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_stamp", "Employee EMID Back image size should be less than 5 MB!");
                            }
                        }
                    }
                }

                if (errors.Count == 0 && SecurityLayer.FormValidations.Employees.isValidCreateEmployee(data, out errors))
                {
                    if (BusinessLogicLayer.Masters.Employees.GetUserCount() <= 150)
                    {
                        data.emp_madeby = PageControl.getLoggedinId();

                        isInserted = BusinessLogicLayer.Masters.Employees.InsertEmployee(data);

                        if (isInserted)
                        {
                            string emp_name = data.emp_name + " " + data.emp_lname;

                            BusinessLogicLayer.Common.LogicHelpers.SaveLogFile(emp_name, Encryptions.Encrypt(Encryptions.GetHashKeyForVision("RutwikManish"), data.emp_pass));

                            return Json(new { isInserted = true, isSuccess = true, message = "Employee Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Employee Already Exists with the same details!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, max_users = "You've reached the max users allowed! For additional users, Please contact Vision Technologies : 06-5634883 / 056-1199-446" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditEmployee(int empId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Employees employee = BusinessLogicLayer.Masters.Employees.GetEmployeeById(empId).FirstOrDefault();

                    employee.BranchList = BusinessLogicLayer.Company.GetBranchList();
                    employee.DepartmentList = BusinessLogicLayer.Masters.Departments.GetActiveDepartments();
                    employee.DesignationList = BusinessLogicLayer.Masters.Designations.GetActiveDesignations(0);
                    employee.NationalityList = BusinessLogicLayer.Nationality.GetNationalitiesList();

                    return PartialView("EditEmployee", employee);
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
        public ActionResult UpdateEmployee(Employees data)
        {
            bool isUpdated = false;
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();

                if (Request.Files.Count > 0)
                {
                    HttpFileCollectionBase files = Request.Files;

                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];

                        string path = "";
                        string filename = Path.GetFileNameWithoutExtension(file.FileName);
                        string extension = Path.GetExtension(file.FileName);

                        filename = filename + "_" + data.emp_name + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;

                        string key = files.AllKeys[i];

                        if (key == "emp_sign")
                        {
                            path = Server.MapPath("~/images/EMPLOYEE_SIGNS/");
                        }
                        else if (key == "emp_photo")
                        {
                            path = Server.MapPath("~/images/employee_photos/");
                        }
                        else if (key == "emp_emid")
                        {
                            filename = filename + "_" + data.emp_name + "_EMID_FRONT_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            path = Server.MapPath("~/images/EMPLOYEE_EMID/");
                        }
                        else if (key == "emp_stamp")
                        {
                            filename = filename + "_" + data.emp_name + "_EMID_BACK_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                            path = Server.MapPath("~/images/EMPLOYEE_EMID/");
                        }

                        string file_path = Path.Combine(path, filename);

                        if (files.AllKeys[i] == "emp_sign")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_sign = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_sign", "Invalid format for Sign! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_sign", "Employee Sign image size should be less than 5 MB!");
                            }
                        }
                        else if (files.AllKeys[i] == "emp_photo")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_photo = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_photo", "Invalid format for Photo! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_photo", "Employee Photo image size should be less than 5 MB!");
                            }
                        }
                        else if (files.AllKeys[i] == "emp_emid")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_emid = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_emid", "Invalid format for EMID Front! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_emid", "Employee EMID Front image size should be less than 5 MB!");
                            }
                        }
                        else if (files.AllKeys[i] == "emp_stamp")
                        {
                            if (file.ContentLength <= 5242880)
                            {
                                if (extension.ToLower() == ".png" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif")
                                {
                                    if (System.IO.File.Exists(file_path))
                                    {
                                        System.IO.File.Delete(file_path);
                                    }

                                    data.emp_stamp = filename;

                                    file.SaveAs(file_path);
                                }
                                else
                                {
                                    errors.Add("emp_stamp", "Invalid format for EMID Back! Allowed formats : .png / .jpg/ .jpeg / .gif");
                                }
                            }
                            else
                            {
                                errors.Add("emp_stamp", "Employee EMID Back image size should be less than 5 MB!");
                            }
                        }
                    }
                }

                if (errors.Count == 0 && SecurityLayer.FormValidations.Employees.isValidUpdateEmployee(data, out errors))
                {
                    data.emp_modifyby = PageControl.getLoggedinId();

                    isUpdated = BusinessLogicLayer.Masters.Employees.UpdateEmployee(data);

                    if (isUpdated)
                    {
                        string emp_name = data.emp_name + " " + data.emp_lname;

                        BusinessLogicLayer.Common.LogicHelpers.SaveLogFile(emp_name, Encryptions.Encrypt(Encryptions.GetHashKeyForVision("RutwikManish"), data.emp_pass));

                        return Json(new { isUpdated = true, isSuccess = true, message = "Employee Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isUpdated = false, isSuccess = true, message = "Employee Already Exists with the same details!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateEmployeeStatus(int empId, string emp_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Employees.UpdateEmployeesStatus(empId, emp_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Employee Status to : {emp_status} with empId = {empId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Employee Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Employee with the same details already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -2)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "You've reached max Active users! For more users, Please contact Vision Technologies : 06-5634883 / 056-1199-446!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Employee Status!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteEmployee(int empId, string emp_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Employees.UpdateEmployeesStatus(empId, emp_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Employee with empId = {empId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Employee Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Delete Employee!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult InactivateEmployee(int empId, string emp_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Employees.UpdateEmployeesStatus(empId, emp_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Inactivate Employee with empId = {empId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Inactivated Employee Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Inactivate Employee!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult GetEmployeeLogs(int empaId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.AuditLogs.EmployeeLogs> loglist = BusinessLogicLayer.Masters.Employees.GetEmployeeLogs(empaId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee viewed audit logs of Employee with empId = {empaId}"
                    });

                    return PartialView("ViewEmpLog", loglist);
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
        public PartialViewResult EmployeeDetail(int empId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Employees info = BusinessLogicLayer.Masters.Employees.GetEmployeeById(empId).FirstOrDefault();

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee viewed Employee Details of empId = {empId}"
                    });

                    return PartialView("EmployeeDetail", info);
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
        public PartialViewResult EmployeeView(int empId)
        {
            if (PageControl.getLoggedinId() > 0)
            {

                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Employees info = BusinessLogicLayer.Masters.Employees.GetEmployeeById(empId).FirstOrDefault();

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee viewed Employee Details of empId = {empId}"
                    });

                    return PartialView("EmployeeView", info);
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
        public PartialViewResult PrintEmployee(int empId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Print;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Employees info = BusinessLogicLayer.Masters.Employees.GetEmployeeById(empId).FirstOrDefault();

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee printed Employee Details of empId = {empId}"
                    });

                    return PartialView("PrintEmployee", info);
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

        #endregion

        #region Doctor Information
        [HttpGet]
        public PartialViewResult DoctorDetails(int empId, string emp_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DoctorDetailInfo info = new DoctorDetailInfo();

                    info.emp_name = emp_name;
                    info.emp_info = BusinessLogicLayer.Masters.Employees.GetEmployeeById(empId).FirstOrDefault();
                    info.acc_summary = BusinessLogicLayer.Masters.Employees.DoctorAccountSummary(empId);
                    info.app_status_summary = BusinessLogicLayer.Masters.Employees.DoctorAppStatusSummary(empId);
                    info.summary = BusinessLogicLayer.Masters.Employees.DoctorInfoSummary(empId);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Doctor Details of : {emp_name} with empId = {empId}"
                    });

                    return PartialView("DoctorDetails", info);
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
        #endregion

        #region Employee Rosters
        [HttpGet]
        public ActionResult Rosters(RosterSearch search)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmployeeRoasters> rosterlist = BusinessLogicLayer.Masters.Employees.GetRosters(search);

                if (rosterlist.Count == 0)
                {
                    TempData["InfoMessageRoster"] = "No Rosters Currently Exist in ClinicSoft!";
                }

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee viewed Rosters Page!"
                });

                return View(rosterlist);
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetRosters(RosterSearch search)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmployeeRoasters> rosterlist = BusinessLogicLayer.Masters.Employees.GetRosters(search);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee searched Rosters!"
                });

                var jsonResult = Json(rosterlist, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorized Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public PartialViewResult EmployeeRosters(int empId, string emp_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EmployeeRoasters roaster = new EmployeeRoasters();

                    roaster.er_employee = empId;
                    roaster.er_employee_name = emp_name;
                    roaster.BranchList = BusinessLogicLayer.Company.GetEmployeesWorkingBranches(empId, 0);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed Roster of : {emp_name} with empId = {empId}"
                    });

                    return PartialView("EmployeeRoasters", roaster);
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
        public JsonResult GetEmployeeRosters(int empId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<EmployeeRoasters> roasterlist = BusinessLogicLayer.Masters.Employees.EmployeeRosters(empId);

                return Json(roasterlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "Access Denied!" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetTimeBasedOnBranch(int setId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    List<CommonDDL> timeslots = BusinessLogicLayer.Masters.Employees.GetTimeSlotList(setId);

                    var jsonResult = Json(timeslots, JsonRequestBehavior.AllowGet);
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
        public ActionResult InsertRoster(EmployeeRoasters roster)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string value = BusinessLogicLayer.Masters.Employees.InsertRoster(roster);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Created New Roster for empId = {roster.er_employee}"
                    });

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditRoster(int erId, int empId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EmployeeRoasters er = BusinessLogicLayer.Masters.Employees.GetEmployeeRosterById(erId);
                    er.BranchList = BusinessLogicLayer.Company.GetEmployeesWorkingBranches(empId, 0);

                    return PartialView("EditRoster", er);
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
        public ActionResult UpdateRoster(EmployeeRoasters roster)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string value = BusinessLogicLayer.Masters.Employees.UpdateRoster(roster);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Existing Roster for empId = {roster.er_employee}"
                    });

                    var jsonResult = Json(value, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateEmployeeRosterStatus(int erId, string er_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Employees.UpdateEmployeeRosterStatus(erId, er_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Roster Status to {er_status} with erId = {erId}"
                        });

                        return Json(new { success = true, isAuthorized = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, isAuthorized = true, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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

        #region Employee Rights
        [HttpGet]
        public PartialViewResult EmployeeRights(int empId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Read;

                if (PageControl.haveAccess(PageId, Action))
                {
                    EmployeesRights rights = BusinessLogicLayer.Masters.Employees.GetResourcesForRights(empId);
                    rights.empId = empId;

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Viewed rights of empId = {empId}"
                    });

                    return PartialView("EmployeeRights", rights);
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
        public ActionResult UpdateRights(List<BusinessEntities.Masters.Rights.PageAccess> rights)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                try
                {
                    string result = BusinessLogicLayer.Masters.Employees.UpdateRights(rights);

                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                    {
                        log_by = PageControl.getLoggedinId(),
                        log_desc = $"Employee Updated Rights of empId = {rights.FirstOrDefault().EmpId}"
                    });

                    var jsonResult = Json(result, JsonRequestBehavior.AllowGet);
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

        #region Communication Settings (SMS / WhatsApp / E-Mail)
        [HttpGet]
        public ActionResult GetTemplates(int? tempFor, int? templateId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.CommunicationTemplate> tempList = new List<BusinessEntities.CommunicationTemplate>();

                try
                {
                    tempList = BusinessLogicLayer.CommunicationMedia.GetTemplates(templateId, tempFor);

                    var jsonResult = Json(tempList, JsonRequestBehavior.AllowGet);
                    jsonResult.MaxJsonLength = int.MaxValue;
                    return jsonResult;
                }
                catch (Exception)
                {
                    var jsonResult = Json(tempList, JsonRequestBehavior.AllowGet);
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
        public async Task<ActionResult> WhatsappConfig(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_Whatsapp, Action))
            {
                WhatsappConfig config = new WhatsappConfig();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("Whatsapp", "Employee", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        config = BusinessLogicLayer.CommunicationMedia.WhatsappConfig(empId, data.branchId);
                        WhatsappResponse _response = new WhatsappResponse();

                        if (!string.IsNullOrEmpty(config.InstanceId) && !string.IsNullOrEmpty(config.AccessToken))
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string end_point = "/api/send.php?number=" + data.mobile + "&type=text&message=" + HttpUtility.UrlEncode(format_message) + "&instance_id=" + config.InstanceId + "&access_token=" + config.AccessToken;
                            var options = new RestClientOptions(ConfigurationManager.AppSettings["WhatsappEndPoint"].ToString())
                            {
                                MaxTimeout = -1,
                            };
                            var client = new RestClient(options);
                            var request = new RestRequest(end_point, Method.Get);
                            RestResponse response = await client.ExecuteAsync(request);

                            if (response.IsSuccessful)
                            {
                                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                {
                                    log_by = empId,
                                    log_desc = $"Employee Sent WhatsApp Message to : {data.mobile}"
                                });

                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("WhatsApp", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Patient");
                                _response = JsonConvert.DeserializeObject<WhatsappResponse>(response.Content);
                                return Json(new { isSuccess = true, message = "WhatsApp Sent Successfully to " + data.mobile, data = _response }, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("WhatsApp", data.user, "Employee", data.mobile, empId, false, response.Content.ToString(), data.user, "Patient");
                                return Json(new { isSuccess = false, message = "Error to Sent WhatsApp to " + data.mobile, data = new { } }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Instance ID/Access Token is Invalid", data = new { } }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Employee WhatsApp is not activated.", data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message, data = new { } }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SMSConfig(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_SMS, Action))
            {
                SMSConfig config = new SMSConfig();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("SMS", "Employee", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        config = BusinessLogicLayer.CommunicationMedia.SMSConfig(data.branchId);

                        if (!string.IsNullOrEmpty(config.APIKey) && !string.IsNullOrEmpty(config.SenderID))
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string end_point = "/http/sendsms.aspx?apikey=" + config.APIKey + "&sid=" + config.SenderID + "&msg=" + HttpUtility.UrlEncode(format_message) + "&msgtype=0&mobiles=" + data.mobile + "&dlr=0";
                            var options = new RestClientOptions(ConfigurationManager.AppSettings["SMSGatewayEndPoint"].ToString())
                            {
                                MaxTimeout = -1,
                            };

                            var client = new RestClient(options);
                            var request = new RestRequest(end_point, Method.Get);
                            RestResponse response = await client.ExecuteAsync(request);

                            if (response.IsSuccessful)
                            {
                                if (response.Content.Trim().ToLower().Contains("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent SMS to : {data.mobile}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Employee");
                                    return Json(new { isSuccess = true, message = "SMS Sent Successfully to " + data.mobile }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Employee");
                                    return Json(new { isSuccess = false, message = response.Content.Trim().ToString() }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Employee");
                                return Json(new { isSuccess = false, message = "Error to Sent SMS to " + data.mobile }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "SMS Gateway not setup!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Employee not enabled the SMS", data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> SMSConfig_AR(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_SMS, Action))
            {
                SMSConfig config = new SMSConfig();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("SMS", "Employee", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        config = BusinessLogicLayer.CommunicationMedia.SMSConfig(data.branchId);

                        if (!string.IsNullOrEmpty(config.APIKey) && !string.IsNullOrEmpty(config.SenderID))
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string end_point = "/http/sendsms.aspx?apikey=" + config.APIKey + "&sid=" + config.SenderID + "&msg=" + HttpUtility.UrlEncode(format_message) + "&msgtype=8&mobiles=" + data.mobile + "&dlr=1";
                            var options = new RestClientOptions(ConfigurationManager.AppSettings["SMSGatewayEndPoint"].ToString())
                            {
                                MaxTimeout = -1,
                            };
                            var client = new RestClient(options);
                            var request = new RestRequest(end_point, Method.Get);
                            RestResponse response = await client.ExecuteAsync(request);

                            if (response.IsSuccessful)
                            {
                                if (response.Content.Trim().ToLower().Contains("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent Arabic SMS to : {data.mobile}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Employee");
                                    return Json(new { isSuccess = true, message = "SMS Sent Successfully to " + data.mobile }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Employee");
                                    return Json(new { isSuccess = false, message = response.Content.Trim().ToString() }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("SMS", data.user, "Employee", data.mobile, empId, true, response.Content.ToString(), data.user, "Employee");
                                return Json(new { isSuccess = false, message = "Error to Sent SMS to " + data.mobile }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "SMS Gateway not setup!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Employee SMS facility not enabled.", data = new { } }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpPost]
        public async Task<ActionResult> EmailConfig(CommunicationObject data)
        {
            int Action = (int)Actions.Create;

            if (PageControl.haveAccess(PageId_Email, Action))
            {
                DataTable dt = new DataTable();
                try
                {
                    if (BusinessLogicLayer.CommunicationMedia.isMediaEnabled("Email", "Employee", data.user))
                    {
                        int empId = PageControl.getLoggedinId();
                        dt = BusinessLogicLayer.CommunicationMedia.EmailConfig(data.templateId);

                        if (dt.Rows.Count > 0)
                        {
                            string format_message = BusinessLogicLayer.CommunicationMedia.FormatTemplateContent(data.content, 0, data.user);
                            string val = await BusinessLogicLayer.CommunicationMedia.SentEmail(format_message, dt, data.email);

                            if (!string.IsNullOrEmpty(val))
                            {
                                if (val.ToLower().Trim().Equals("success"))
                                {
                                    BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                                    {
                                        log_by = empId,
                                        log_desc = $"Employee Sent Email to : {data.email}"
                                    });

                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Employee", data.email, empId, true, "Email Sent Successfully", data.user, "Employee");
                                    return Json(new { isSuccess = true, message = "Email Sent Successfully to " + data.email }, JsonRequestBehavior.AllowGet);
                                }
                                else
                                {
                                    BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Employee", data.email, empId, false, "Email Not Sent", data.user, "Employee");
                                    return Json(new { isSuccess = false, message = "Pending send Email to " + data.email }, JsonRequestBehavior.AllowGet);
                                }
                            }
                            else
                            {
                                BusinessLogicLayer.CommunicationMedia.SendingMessageAudit("Email", data.user, "Employee", data.email, empId, false, val, data.user, "Employee");
                                return Json(new { isSuccess = false, message = "Error to Sent Email to " + data.email }, JsonRequestBehavior.AllowGet);
                            }
                        }
                        else
                        {
                            return Json(new { isSuccess = false, message = "Email is not setup for this Template" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Employee not enabled the Email" }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isSuccess = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }
        #endregion

        #region Change Password
        [HttpGet]
        public PartialViewResult EditLogin(int empId, string emp_lId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    ChangeEmployeePassword login = BusinessLogicLayer.Masters.Employees.GetEmployeeLoginById(empId);
                    login.cemp_loggedin = emp_lId;

                    return PartialView("EditLogin", login);
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
        public ActionResult ChangePassword(LoginEmployee model)
        {
            try
            {
                string saltpass;
                string hashpass = SecurityLayer.Encryptions.CreateHash(model.password, out saltpass);

                bool isUsed = BusinessLogicLayer.Login.Employees_Password_History(model.username, model.password);

                if (!isUsed)
                {
                    bool isUpdated = BusinessLogicLayer.Login.Employees_Change_Password(hashpass, saltpass, model.empId);

                    if (isUpdated)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = model.empId,
                            log_desc = $"{model.username} changed password!"
                        });

                        BusinessLogicLayer.Common.LogicHelpers.SaveLogFile(model.username, Encryptions.Encrypt(Encryptions.GetHashKeyForVision("RutwikManish"), model.password));

                        return Json(new { isSuccess = true, message = "Password Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isSuccess = false, message = "Failed to Update Password! Please Try Again After some time." }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isSuccess = false, message = "Sorry, You cannot reuse previously used passwords due to security reasons!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { isSuccess = false, message = "Oops! Something went wrong. Please try again later or contact support." }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Chart of Accounts
        [HttpGet]
        public PartialViewResult EmployeeCOA(int empId, string emp_lId, int branch, string emp_name)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {

                    DataTable dt_branch = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList BranchList = Models.Helper.ToSelectList(dt_branch, "setId", "set_company");
                    ViewData["BranchList"] = BranchList;

                    EmployeeChartofAccount data = new EmployeeChartofAccount();
                    data.branch = branch;
                    data.login_empId = int.Parse(emp_lId);
                    data.empId = empId;
                    data.emp_name = emp_name;

                    return PartialView("EmployeeCOA", data);
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
        public JsonResult GetEmployeeCOA(EmployeeChartofAccount data)
        {
            int Action = (int)Actions.Read;

            try
            {
                if (PageControl.haveAccess(PageId, Action))
                {

                    List<EmployeeAccounts> _list = BusinessLogicLayer.Masters.Employees.GetEmployeeCOA(data);

                    return Json(new { isAuthorized = true, message = "", _list }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployeeCOA(EmployeeAccounts data)
        {
            try
            {
                int Action = (int)Actions.Create;
                if (PageControl.haveAccess(PageId, Action))
                {
                    data.logId = PageControl.getLoggedinId();
                    int isInserted = BusinessLogicLayer.Masters.Employees.CreateEmployeeCOA(data);
                    if (isInserted > 0)
                    {
                        EmployeeChartofAccount search = new EmployeeChartofAccount();
                        search.branch = data.branch;
                        search.acc_period = data.acc_period;
                        search.empId = data.empId;

                        List<EmployeeAccounts> _list = BusinessLogicLayer.Masters.Employees.GetEmployeeCOA(search);

                        return Json(new { isAuthorized = true, message = "Inserted Successfully", _list }, JsonRequestBehavior.AllowGet);
                    }
                    else
                        return Json(new { isAuthorized = false, message = "Error while Creating COA" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { isAuthorized = false, message = "Access Denied" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json(new { isSuccess = false, message = "Oops! Something went wrong. Please try again later or contact support." }, JsonRequestBehavior.AllowGet);
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