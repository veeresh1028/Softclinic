using BusinessEntities;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Masters.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        int PageId = (int)Pages.Departments;

        #region Departments Page Load
        [HttpGet]
        public ActionResult Departments()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = "Employee Viewed Departments!"
                });

                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        public JsonResult GetAllDepartments()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.Departments> departmentlist = BusinessLogicLayer.Masters.Departments.GetDepartments(0);

                return Json(departmentlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Departments CRUD Operations
        [HttpGet]
        public PartialViewResult CreateDepartment()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    BusinessEntities.Masters.Departments department = new BusinessEntities.Masters.Departments();
                    return PartialView("CreateDepartment", department);
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
        public ActionResult InsertDepartment(BusinessEntities.Masters.Departments data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();

                    if (SecurityLayer.FormValidations.Departments.isValidDepartments(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Masters.Departments.InsertUpdateDepartment(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Created New Department : {data.department}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Department Created Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Department already exists!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult EditDepartment(int deptId)
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    List<BusinessEntities.Masters.Departments> departmentlist = BusinessLogicLayer.Masters.Departments.GetDepartments(deptId);

                    return PartialView("EditDepartment", departmentlist.FirstOrDefault());
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
        public ActionResult UpdateDepartment(BusinessEntities.Masters.Departments data)
        {
            try
            {
                bool isInserted = false;

                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (SecurityLayer.FormValidations.Departments.isValidDepartments(data, out errors))
                    {
                        isInserted = BusinessLogicLayer.Masters.Departments.InsertUpdateDepartment(data);

                        if (isInserted)
                        {
                            BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                            {
                                log_by = PageControl.getLoggedinId(),
                                log_desc = $"Employee Updated Department to : {data.department} with deptId = {data.deptId}"
                            });

                            return Json(new { isInserted = true, isSuccess = true, message = "Department Updated Successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, isSuccess = true, message = "Department already exists!" }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult UpdateDepartmentStatus(int deptId, string dept_status)
        {
            try
            {
                int Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {

                    int val = BusinessLogicLayer.Masters.Departments.UpdateDepartmentStatus(deptId, dept_status);

                    if (val > 0)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Updated Department Status to : {dept_status} with deptId = {deptId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (val == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "An active Department with the same name already exists!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
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
        public ActionResult DeleteDepartment(int deptId, string dept_status)
        {
            try
            {
                int Action = (int)Actions.Delete;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int val = BusinessLogicLayer.Masters.Departments.UpdateDepartmentStatus(deptId, dept_status);

                    if (val == 1)
                    {
                        BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                        {
                            log_by = PageControl.getLoggedinId(),
                            log_desc = $"Employee Deleted Department with deptId = {deptId}"
                        });

                        return Json(new { isAuthorized = true, success = true, message = "Department Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Delete Department!" }, JsonRequestBehavior.AllowGet);
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
        public PartialViewResult ViewEmpDepartment(int deptId)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                List<BusinessEntities.Masters.EmployeesByDepartment> departmentlist = BusinessLogicLayer.Masters.Departments.GetEmpDepartmentById(deptId);

                BusinessLogicLayer.AuditLogs.AuditLogs.GeneralLogs(new BusinessEntities.AuditLogs.AuditLogs
                {
                    log_by = PageControl.getLoggedinId(),
                    log_desc = $"Employee Viewed Departmentwise Employees with deptId = {deptId}"
                });

                return PartialView("ViewEmpDepartment", departmentlist);
            }
            else
            {
                return PartialView("_Unauthorized");
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