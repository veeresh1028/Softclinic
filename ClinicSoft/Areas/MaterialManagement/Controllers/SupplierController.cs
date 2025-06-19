using BusinessEntities;
using BusinessEntities.Accounts.Masters;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using SecurityLayer;

namespace ClinicSoft.Areas.MaterialManagement.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        int PageId = (int)Pages.Supplier;

        #region Supplier
        // Get Supplier Detail on Page Load
        public ActionResult Supplier()
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

        // Get Supplier Detail
        public JsonResult GetSupplier()
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<Supplier> Supplierlist = BusinessLogicLayer.Accounts.Masters.Supplier.GetSupplier(0, null, null, null, null, null, 0, 0, 0, empId);

                return Json(Supplierlist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Open Partial View to Create Supplier
        [HttpGet]
        public PartialViewResult CreateSupplier()
        {
            if (PageControl.getLoggedinId() > 0)
            {
                int Action = (int)Actions.Create;

                if (PageControl.haveAccess(PageId, Action))
                {
                    DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                    SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                    ViewData["BranchList"] = branchlist;
                    return PartialView("CreateSupplier");
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

        // Insert New Supplier Detail in DataBase
        [HttpPost]        
        public ActionResult InsertSupplier(Supplier data)
        {
            int Action = (int)Actions.Create;
            int inserted = 0;
            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                try
                {
                    data.sup_mob = (data.sup_mob.Trim() == "+") ? "" : data.sup_mob.Trim().Replace("+", "");
                    data.sup_mob = data.sup_mob.Trim().Replace(" ", "");
                    if (data.sup_mob.Length < 5)
                        data.sup_mob = "";
                    data.sup_tel = (data.sup_tel.Trim() == "+") ? "" : data.sup_tel.Trim().Replace("+", "");
                    data.sup_tel = data.sup_tel.Trim().Replace(" ", "");
                    if (data.sup_tel.Length < 5)
                        data.sup_tel = "";
                    
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidSupplier(data, out errors))
                    {
                        data.sup_madeby = PageControl.getLoggedinId();
                        inserted = BusinessLogicLayer.Accounts.Masters.Supplier.InsertUpdateSupplier(data);

                        if (inserted > 0)
                        {
                            return Json(new { isInserted = inserted, message = "Supplier added successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else if (inserted == -1)
                        {
                            return Json(new { isInserted = inserted, message = "Supplier already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = inserted, message = "Error while creating Supplier!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = -2, message = errors }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    errors.Add("db_error", ex.Message);
                    return Json(new { isInserted = 0, message = errors }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Data From Databse to Edit Supplier Detail By supId
        [HttpGet]
        public PartialViewResult EditSupplier(int supId)
        {
            int Action = (int)Actions.Update;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<Supplier> supplier = BusinessLogicLayer.Accounts.Masters.Supplier.GetSupplierById(supId, null, null, null, null, null, 0, 0, 0, empId);
                DataTable dt = BusinessLogicLayer.Company.GetBranches(0);
                SelectList branchlist = Models.Helper.ToSelectList(dt, "setId", "set_company");
                ViewData["BranchList"] = branchlist;
                return PartialView("EditSupplier", supplier.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Update Supplier Detail in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateSupplier(Supplier data)
        {
            try
            {
                int isUpdated = 0;
                int Action = (int)Actions.Update;
                if (PageControl.haveAccess(PageId, Action))
                {
                    Dictionary<string, string> errors = new Dictionary<string, string>();
                    if (data.sup_mob.Length < 5)
                        data.sup_mob = "";
                    data.sup_mob = (data.sup_mob.Trim() == "+") ? "" : data.sup_mob.Trim().Replace("+", "");
                    data.sup_mob = data.sup_mob.Trim().Replace(" ", "");

                    if (data.sup_tel.Length < 5)
                        data.sup_tel = "";
                    data.sup_tel = (data.sup_tel.Trim() == "+") ? "" : data.sup_tel.Trim().Replace("+", "");
                    data.sup_tel = data.sup_tel.Trim().Replace(" ", "");
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidSupplier(data, out errors))
                    {
                        data.sup_madeby = PageControl.getLoggedinId();
                        isUpdated = BusinessLogicLayer.Accounts.Masters.Supplier.InsertUpdateSupplier(data);
                        if (isUpdated > 0)
                        {
                            return Json(new { isUpdated = true, message = "Supplier Updated successfully!" }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isUpdated = false, message = "Supplier already exists!" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors }, JsonRequestBehavior.AllowGet);
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

        // Update Supplier Status for Inactive or Delete
        [HttpPost]
        public ActionResult UpdateSupplier_Status(int supId, string sup_status)
        {
            try
            {
                int isStatsuChanged = 0;
                int Action = 0;
                if (sup_status == "Deleted")
                    Action = (int)Actions.Delete;
                else
                    Action = (int)Actions.Update;

                if (PageControl.haveAccess(PageId, Action))
                {
                    int empId = PageControl.getLoggedinId();
                    isStatsuChanged = BusinessLogicLayer.Accounts.Masters.Supplier.UpdateSupplier_Status(supId, sup_status, empId);

                    if (isStatsuChanged > 0)
                    {
                        if (sup_status == "Deleted")
                            return Json(new { isAuthorized = true, success = true, message = "Supplier Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                        else
                            return Json(new { isAuthorized = true, success = true, message = "Status Changed Successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else if (isStatsuChanged == -1)
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Supplier already exists with same name!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { isAuthorized = true, success = false, message = "Failed To Change Status!" }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { isAuthorized = false, success = false, message = "Unauthorised!" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get Data From Databse to View Supplier Detail By supId
        [HttpGet]
        public PartialViewResult ViewSupplier(int supId)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<Supplier> supplier = BusinessLogicLayer.Accounts.Masters.Supplier.GetSupplierById(supId, null, null, null, null, null, 0, 0, 0, empId);
                return PartialView("ViewSupplier", supplier.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Data From Databse to Print Supplier Detail By supId
        [HttpGet]
        public PartialViewResult PrintSupplierDetail(int supId)
        {
            int Action = (int)Actions.Export;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<Supplier> supplier = BusinessLogicLayer.Accounts.Masters.Supplier.GetSupplierById(supId, null, null, null, null, null, 0, 0, 0, empId);
                return PartialView("PrintSupplierDetail", supplier.FirstOrDefault());
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Opening Supplier Audit Logs View
        [HttpGet]
        public PartialViewResult SupplierAuditLog(string sup_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                BusinessEntities.Accounts.AuditLogs.SupplierLog SupplierAudtiLogsList = new BusinessEntities.Accounts.AuditLogs.SupplierLog();
                SupplierAudtiLogsList.supa_code = sup_code;
                return PartialView("SupplierAuditLog", SupplierAudtiLogsList);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Supplier Audit Log Detail From Database
        [HttpGet]
        public JsonResult SupplierAuditLog_Detail(string supa_code)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<BusinessEntities.Accounts.AuditLogs.SupplierLog> SupplierAudtiLogsList = BusinessLogicLayer.Accounts.AuditLogs.SupplierLog.GetSupplierAuditLogs(supa_code);

                return Json(SupplierAudtiLogsList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Opening Supplier Account Transactions Detail View
        [HttpGet]
        public PartialViewResult SupplierAccounts(string sup_account, string sup_name, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                SupplierAccounts SupplierList = new SupplierAccounts();
                SupplierList.tr_account = sup_account;
                SupplierList.tr_ref_account = sup_name;
                SupplierList.tr_branch = branch;
                //SupplierList.date_from = DateTime.Parse("01-01-"+ DateTime.Now.Year.ToString()).ToString("dd-MMMM-yyyy");
                //SupplierList.date_to = DateTime.Now.ToString("dd-MMMM-yyyy");
                return PartialView("SupplierAccountTransactions", SupplierList);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Get Supplier Account Transactions Detail From Database
        [HttpGet]
        public JsonResult GetAccountDetailsByCode(string tr_account, string date_from, string date_to, int branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                List<SupplierAccounts> SupplierAccountslist = BusinessLogicLayer.Accounts.Masters.Supplier.GetAccountDetailsByCode(tr_account, date_from, date_to, branch, empId);
                return Json(SupplierAccountslist, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // Opening Supplier Account Transactions Detail View
        [HttpGet]
        public PartialViewResult SupplierOpeningBalace(string sup_account, decimal sup_obal, string sup_obal_type, int sup_branch)
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                Supplier SupplierList = new Supplier();
                SupplierList.sup_account = sup_account;
                SupplierList.sup_obal = sup_obal;
                SupplierList.sup_obal_type = sup_obal_type;
                SupplierList.sup_branch = sup_branch;

                return PartialView("SupplierOpeningBalance", SupplierList);
            }
            else
            {
                return PartialView("_Unauthorized");
            }
        }

        // Insert Supplier Opening Balance
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertSupplierOpeningBalace(Supplier data)
        {
            int Action = (int)Actions.Update;
            int isInserted = 0;
            if (PageControl.haveAccess(PageId, Action))
            {
                Dictionary<string, string> errors = new Dictionary<string, string>();
                try
                {
                    if (SecurityLayer.FormValidations.MaterialManagement.isValidSupplier_OpeningBalce(data, out errors))
                    {
                        data.sup_madeby = PageControl.getLoggedinId();
                        isInserted = BusinessLogicLayer.Accounts.Masters.Supplier.InsertSupplierOpeningBalace(data);
                        if (isInserted > 0)
                        {
                            return Json(new { isInserted = true, message = "Supplier opening balance added successfully!", code = 1 }, JsonRequestBehavior.AllowGet);
                        }
                        else if (isInserted == -1)
                        {
                            return Json(new { isInserted = false, message = "Supplier account is not exists in chart of account!", code = -1 }, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            return Json(new { isInserted = false, message = "Error while adding supplier opening balance!", code = 0 }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { isInserted = false, message = errors, code = -2 }, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    return Json(new { isInserted = false, message = ex.Message, code = -3 }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        // Get Supplier History Detail
        [HttpGet]
        public PartialViewResult SupplierHistory(int supId, int sup_branch)
        {
            int Action = (int)Actions.Read;
            if (PageControl.haveAccess(PageId, Action))
            {
                int empId = PageControl.getLoggedinId();
                DataSet ds = BusinessLogicLayer.Accounts.Masters.Supplier.GetSupplierHistory(supId, sup_branch, empId);

                SupplierHistory supplierHistory = new SupplierHistory();

                SupplierDetail supplierDetail = new SupplierDetail();
                List<SupplierPurchaseOrder> supplierPO = new List<SupplierPurchaseOrder>();
                List<SupplierGRN> supplierGRN = new List<SupplierGRN>();
                List<SupplierInvoice> supplierInvoices = new List<SupplierInvoice>();
                List<SupplierPayment> supplierPayment = new List<SupplierPayment>();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    supplierDetail.supId = Convert.ToInt32(ds.Tables[0].Rows[0]["supId"].ToString());
                    supplierDetail.sup_branch = Convert.ToInt32(ds.Tables[0].Rows[0]["sup_branch"].ToString());
                    supplierDetail.sup_code = ds.Tables[0].Rows[0]["sup_code"].ToString();
                    supplierDetail.sup_name = ds.Tables[0].Rows[0]["sup_name"].ToString();
                    supplierDetail.sup_branch_name = ds.Tables[0].Rows[0]["sup_branch_name"].ToString();
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        supplierPO.Add(new SupplierPurchaseOrder
                        {
                            purId = Convert.ToInt32(dr["purId"].ToString()),
                            pur_supplier = Convert.ToInt32(dr["pur_supplier"].ToString()),
                            pur_odate = DataValidation.isDateValid(dr["pur_odate"].ToString()),
                            pur_ocode = dr["pur_ocode"].ToString(),
                            pur_account = dr["pur_account"].ToString(),
                            pur_total = DataValidation.isDecimalValid(dr["pur_total"].ToString()),
                            pur_disc = DataValidation.isDecimalValid(dr["pur_disc"].ToString()),
                            pur_disc_type = dr["pur_disc_type"].ToString(),
                            pur_net = DataValidation.isDecimalValid(dr["pur_net"].ToString()),
                            pur_vat = DataValidation.isDecimalValid(dr["pur_vat"].ToString()),
                            pur_status = dr["pur_status"].ToString(),
                            madeby_name = dr["madeby_name"].ToString(),
                        });
                    }
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        supplierGRN.Add(new SupplierGRN
                        {
                            pir_dcode = dr["pir_dcode"].ToString(),
                            pir_ddate = DataValidation.isDateValid(dr["pir_ddate"].ToString()),
                            pir_received = DataValidation.isDecimalValid(dr["pir_received"].ToString()),
                            pir_status = dr["pir_status"].ToString(),
                            pir_batchno = dr["pir_batchno"].ToString(),
                            pir_uom = dr["pir_uom"].ToString(),
                            pir_free_qty = DataValidation.isDecimalValid(dr["pir_free_qty"].ToString()),
                            pir_dmadeby = int.Parse(dr["pir_dmadeby"].ToString()),
                            madeby_name = dr["madeby_name"].ToString(),
                        });
                    }
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        supplierInvoices.Add(new SupplierInvoice
                        {
                            pinv_account = dr["pinv_account"].ToString(),
                            pinv_icode = dr["pinv_icode"].ToString(),
                            pinv_invno = dr["pinv_invno"].ToString(),
                            pinv_idate = DataValidation.isDateValid(dr["pinv_idate"].ToString()),
                            pinv_total = DataValidation.isDecimalValid(dr["pinv_total"].ToString()),
                            pinv_disc = DataValidation.isDecimalValid(dr["pinv_disc"].ToString()),
                            pinv_disc_type = dr["pinv_disc_type"].ToString(),
                            pinv_net = DataValidation.isDecimalValid(dr["pinv_net"].ToString()),
                            pinv_vat = DataValidation.isDecimalValid(dr["pinv_vat"].ToString()),
                            pinv_status = dr["pinv_status"].ToString(),
                            pinv_imadeby = int.Parse(dr["pinv_imadeby"].ToString()),
                            madeby_name = dr["madeby_name"].ToString(),
                        });
                    }
                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        supplierPayment.Add(new SupplierPayment
                        {
                            pay_code = dr["pay_code"].ToString(),
                            pay_date = DataValidation.isDateValid(dr["pay_date"].ToString()),
                            pay_type = dr["pay_type"].ToString(),
                            paid = DataValidation.isDecimalValid(dr["paid"].ToString()),
                            pay_status = dr["pay_status"].ToString(),
                            pay_madeby = int.Parse(dr["pay_madeby"].ToString()),
                            madeby_name = dr["madeby_name"].ToString(),
                        });
                    }
                }
                supplierHistory.supplierDetail = supplierDetail;
                supplierHistory.supplierGRN = supplierGRN;
                supplierHistory.supplierPurchaseOrders = supplierPO;
                supplierHistory.supplierInvoice = supplierInvoices;
                supplierHistory.supplierPayment = supplierPayment;

                return PartialView("SupplierHistory", supplierHistory);
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