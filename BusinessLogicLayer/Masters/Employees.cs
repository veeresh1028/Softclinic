using BusinessEntities;
using BusinessEntities.Accounts.Accounting;
using BusinessEntities.Appointment;
using BusinessEntities.Masters;
using BusinessEntities.Masters.Rights;
using BusinessEntities.Patient;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Masters
{
    public class Employees
    {
        #region Employees Master (Page Load)
        public static List<BusinessEntities.Masters.Employees> GetEmployees(EmployeesSearch filter)
        {
            List<BusinessEntities.Masters.Employees> employeelist = new List<BusinessEntities.Masters.Employees>();
            DataTable dt = DataAccessLayer.Masters.Employees.SearchEmployees(filter);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Masters.Employees emp = new BusinessEntities.Masters.Employees();

                emp.empId = Convert.ToInt32(dr["empId"]);
                emp.emp_branch = Convert.ToInt32(dr["emp_branch"]);
                emp.emp_status = dr["emp_status"].ToString();
                emp.emp_color = dr["emp_color"].ToString();
                emp.emp_name = dr["emp_name"].ToString();
                emp.emp_lname = dr["emp_lname"].ToString();
                emp.emp_address = dr["emp_address"].ToString();
                emp.emp_email = dr["emp_email"].ToString();
                emp.emp_license = string.IsNullOrEmpty(dr["emp_license"].ToString()) ? "" : dr["emp_license"].ToString();
                emp.emp_mob = dr["emp_mob"].ToString();

                emp.sales_acc_namecode = dr["sales_acc_namecode"].ToString();
                emp.comm_acc_namecode = dr["comm_acc_namecode"].ToString();
                emp.set_company = dr["set_company"].ToString();
                emp.department = dr["department"].ToString();
                emp.designation = dr["designation"].ToString();
                emp.nationality = dr["nationality"].ToString();
                emp.actionvisible = dr["actionvisible"].ToString();

                if (!string.IsNullOrEmpty(dr["emp_photo"].ToString()))
                {
                    emp.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/employee_photos/" + dr["emp_photo"].ToString();
                }
                else
                {
                    emp.emp_photo = ConfigurationManager.AppSettings["ClinicSoftEndPoint"].ToString() + "images/no-photo-male.jpg";
                }

                employeelist.Add(emp);
            }
            return employeelist;
        }
        #endregion

        #region Employees Advanced Filters
        public static DataTable GetDepartmentEmployees(int? deptId)
        {
            return DataAccessLayer.Masters.Employees.GetDepartmentEmployees(deptId);
        }

        public static DataTable GetDesignationsEmployees(int? desiId)
        {
            return DataAccessLayer.Masters.Employees.GetDesignationsEmployees(desiId);
        }
        #endregion

        #region Employee CRUD Operations
        public static int GetUserCount()
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetUserCount();

            if (dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["total"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public static List<GetByName> GetSpeciality(string type, string query, string category)
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetSpeciality(type, query, category);
            List<GetByName> data = new List<GetByName>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    GetByName _data = new GetByName();
                    _data.id = dr["id"].ToString();
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;
        }

        public static List<BusinessEntities.Company> GetSetupinfo(int setId)
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetSetupinfo(setId);
            List<BusinessEntities.Company> data = new List<BusinessEntities.Company>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BusinessEntities.Company _data = new BusinessEntities.Company();
                    _data.setId = int.Parse(dr["setId"].ToString());
                    _data.set_city = dr["set_city"].ToString();
                    data.Add(_data);
                }
            }
            return data;
        }
        public static List<CommonDDL> GetDHASpeciality(string query = "")
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetDHASpeciality(query);
            List<CommonDDL> data = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CommonDDL _data = new CommonDDL();
                    _data.id = int.Parse(dr["id"].ToString());
                    _data.text = dr["text"].ToString();
                    data.Add(_data);
                }
            }
            return data;
        }

        public static bool InsertEmployee(BusinessEntities.Masters.Employees data)
        {
            string saltpass;
            data.hashpass = SecurityLayer.Encryptions.CreateHash(data.emp_pass, out saltpass);
            data.emp_mob = (data.emp_mob.Trim() == "+971") ? "" : data.emp_mob.Trim().Replace("+", "");

            if (!string.IsNullOrEmpty(data.emp_tel))
            {
                data.emp_tel = (data.emp_tel.Trim() == "+971") ? "" : data.emp_tel.Trim().Replace("+", "");
            }
            else
            {
                data.emp_tel = string.IsNullOrEmpty(data.emp_tel) ? string.Empty : data.emp_tel;
            }

            data.emp_fax = string.IsNullOrEmpty(data.emp_fax) ? string.Empty : data.emp_fax;
            data.emp_color = string.IsNullOrEmpty(data.emp_color) ? string.Empty : data.emp_color;
            data.emp_gender = string.IsNullOrEmpty(data.emp_gender) ? string.Empty : data.emp_gender;
            data.emp_license = string.IsNullOrEmpty(data.emp_license) ? string.Empty : data.emp_license;
            data.emp_photo = string.IsNullOrEmpty(data.emp_photo) ? string.Empty : data.emp_photo;
            data.emp_sign = string.IsNullOrEmpty(data.emp_sign) ? string.Empty : data.emp_sign;
            data.emp_emid = string.IsNullOrEmpty(data.emp_emid) ? string.Empty : data.emp_emid;
            data.emp_stamp = string.IsNullOrEmpty(data.emp_stamp) ? string.Empty : data.emp_stamp;
            data.emp_dha_login = string.IsNullOrEmpty(data.emp_dha_login) ? string.Empty : data.emp_dha_login;
            data.emp_dha_pass = string.IsNullOrEmpty(data.emp_dha_pass) ? string.Empty : data.emp_dha_pass;
            data.emp_whatsappId = string.IsNullOrEmpty(data.emp_whatsappId) ? string.Empty : data.emp_whatsappId;
            data.emp_whatsappToken = string.IsNullOrEmpty(data.emp_whatsappToken) ? string.Empty : data.emp_whatsappToken;
            data.emp_teeth = string.IsNullOrEmpty(data.emp_teeth) ? string.Empty : data.emp_teeth;
            data.emp_speciality = string.IsNullOrEmpty(data.emp_speciality) ? string.Empty : data.emp_speciality;
            data.emp_dha_speciality = string.IsNullOrEmpty(data.emp_dha_speciality) ? string.Empty : data.emp_dha_speciality;
            data.emp_moh_login = string.IsNullOrEmpty(data.emp_moh_login) ? string.Empty : data.emp_moh_login;
            data.emp_moh_pass = string.IsNullOrEmpty(data.emp_moh_pass) ? string.Empty : data.emp_moh_pass;
            data.emp_pwd_validity = string.IsNullOrEmpty(data.emp_pwd_validity) ? string.Empty : data.emp_pwd_validity;
            data.emp_flag = string.IsNullOrEmpty(data.emp_flag) ? string.Empty : data.emp_flag;

            return DataAccessLayer.Masters.Employees.InsertEmployee(data, saltpass);
        }

        public static List<BusinessEntities.Masters.Employees> GetEmployeeById(int? empId)
        {
            List<BusinessEntities.Masters.Employees> employeelist = new List<BusinessEntities.Masters.Employees>();
            DataTable dt = DataAccessLayer.Masters.Employees.GetEmployee(empId);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.Masters.Employees emp = new BusinessEntities.Masters.Employees();

                emp.empId = Convert.ToInt32(dr["empId"]);
                emp.emp_nat = Convert.ToInt32(dr["emp_nat"]);
                emp.emp_desig = Convert.ToInt32(dr["emp_desig"]);
                emp.emp_dept = Convert.ToInt32(dr["emp_dept"]);
                emp.emp_branch = Convert.ToInt32(dr["emp_branch"]);
                emp.emp_color = dr["emp_color"].ToString();
                emp.emp_name = dr["emp_name"].ToString();
                emp.emp_lname = dr["emp_lname"].ToString();
                emp.emp_email = dr["emp_email"].ToString();
                emp.emp_gender = dr["emp_gender"].ToString();
                emp.emp_address = dr["emp_address"].ToString();
                emp.emp_fax = dr["emp_fax"].ToString();
                emp.emp_license = string.IsNullOrEmpty(dr["emp_license"].ToString()) ? "" : dr["emp_license"].ToString();
                emp.emp_mob = dr["emp_mob"].ToString();
                emp.emp_tel = dr["emp_tel"].ToString();
                emp.emp_teeth = dr["emp_teeth"].ToString();
                emp.emp_whatsappId = dr["emp_whatsappId"].ToString();
                emp.emp_whatsappToken = dr["emp_whatsappToken"].ToString();
                emp.emp_emid = dr["emp_emid"].ToString();
                emp.emp_stamp = dr["emp_stamp"].ToString();
                emp.emp_sign = dr["emp_sign"].ToString();
                emp.emp_photo = dr["emp_photo"].ToString();
                emp.emp_dha_login = dr["emp_dha_login"].ToString();
                emp.emp_dha_pass = dr["emp_dha_pass"].ToString();
                emp.emp_speciality = dr["emp_speciality"].ToString();
                emp.emp_dha_speciality = dr["emp_dha_speciality"].ToString();
                emp.emp_login = dr["emp_login"].ToString();
                emp.emp_work_branch = dr["emp_work_branch"].ToString();
                emp.emp_scheduler = Convert.ToInt32(dr["emp_scheduler"]);
                emp.emp_moh_login = dr["emp_moh_login"].ToString();
                emp.emp_moh_pass = dr["emp_moh_pass"].ToString();
                emp.emp_pwd_validity = dr["emp_pwd_validity"].ToString();
                emp.emp_flag = dr["emp_flag"].ToString();

                emp.emp_disc_allowed = Convert.ToDecimal(dr["emp_disc_allowed"]);
                emp.emp_lab_commi = Convert.ToDecimal(dr["emp_lab_commi"]);
                emp.emp_met_commi = Convert.ToDecimal(dr["emp_met_commi"]);
                emp.emp_pha_commi = Convert.ToDecimal(dr["emp_pha_commi"]);
                emp.emp_procedure_commi = Convert.ToDecimal(dr["emp_procedure_commi"]);
                emp.emp_rad_commi = Convert.ToDecimal(dr["emp_rad_commi"]);
                emp.emp_consultation_commi = Convert.ToDecimal(dr["emp_consultation_commi"]);

                emp.set_company = dr["set_company"].ToString();
                emp.set_city = dr["set_city"].ToString();
                emp.department = dr["department"].ToString();
                emp.designation = dr["designation"].ToString();
                emp.nationality = dr["nationality"].ToString();

                employeelist.Add(emp);
            }
            return employeelist;
        }

        public static bool UpdateEmployee(BusinessEntities.Masters.Employees data)
        {
            data.emp_mob = (data.emp_mob.Trim() == "+971") ? "" : data.emp_mob.Trim().Replace("+", "");

            if (!string.IsNullOrEmpty(data.emp_tel))
            {
                data.emp_tel = (data.emp_tel.Trim() == "+971") ? "" : data.emp_tel.Trim().Replace("+", "");
            }
            else
            {
                data.emp_tel = string.IsNullOrEmpty(data.emp_tel) ? string.Empty : data.emp_tel;

            }
            data.emp_fax = string.IsNullOrEmpty(data.emp_fax) ? string.Empty : data.emp_fax;
            data.emp_color = string.IsNullOrEmpty(data.emp_color) ? string.Empty : data.emp_color;
            data.emp_gender = string.IsNullOrEmpty(data.emp_gender) ? string.Empty : data.emp_gender;
            data.emp_license = string.IsNullOrEmpty(data.emp_license) ? string.Empty : data.emp_license;
            data.emp_photo = string.IsNullOrEmpty(data.emp_photo) ? string.Empty : data.emp_photo;
            data.emp_sign = string.IsNullOrEmpty(data.emp_sign) ? string.Empty : data.emp_sign;
            data.emp_emid = string.IsNullOrEmpty(data.emp_emid) ? string.Empty : data.emp_emid;
            data.emp_stamp = string.IsNullOrEmpty(data.emp_stamp) ? string.Empty : data.emp_stamp;
            data.emp_dha_login = string.IsNullOrEmpty(data.emp_dha_login) ? string.Empty : data.emp_dha_login;
            data.emp_dha_pass = string.IsNullOrEmpty(data.emp_dha_pass) ? string.Empty : data.emp_dha_pass;
            data.emp_whatsappId = string.IsNullOrEmpty(data.emp_whatsappId) ? string.Empty : data.emp_whatsappId;
            data.emp_whatsappToken = string.IsNullOrEmpty(data.emp_whatsappToken) ? string.Empty : data.emp_whatsappToken;
            data.emp_teeth = string.IsNullOrEmpty(data.emp_teeth) ? string.Empty : data.emp_teeth;
            data.emp_speciality = string.IsNullOrEmpty(data.emp_speciality) ? string.Empty : data.emp_speciality;
            data.emp_dha_speciality = string.IsNullOrEmpty(data.emp_dha_speciality) ? string.Empty : data.emp_dha_speciality;
            data.emp_pwd_validity = string.IsNullOrEmpty(data.emp_pwd_validity) ? string.Empty : data.emp_pwd_validity;
            data.emp_flag = string.IsNullOrEmpty(data.emp_flag) ? string.Empty : data.emp_flag;
            return DataAccessLayer.Masters.Employees.UpdateEmployee(data);
        }

        public static int UpdateEmployeesStatus(int empId, string emp_status)
        {
            return DataAccessLayer.Masters.Employees.UpdateEmployeesStatus(empId, emp_status);
        }

        public static List<BusinessEntities.Masters.AuditLogs.EmployeeLogs> GetEmployeeLogs(int empId)
        {
            List<BusinessEntities.Masters.AuditLogs.EmployeeLogs> emploglist = new List<BusinessEntities.Masters.AuditLogs.EmployeeLogs>();

            DataTable dt = DataAccessLayer.Masters.Employees.GetEmployeeLogs(empId);

            foreach (DataRow dr in dt.Rows)
            {
                emploglist.Add(new BusinessEntities.Masters.AuditLogs.EmployeeLogs
                {
                    empaId = Convert.ToInt32(dr["empaId"]),
                    empa_login = dr["empa_login"].ToString(),
                    empa_name = dr["empa_name"].ToString(),
                    empa_lname = dr["empa_lname"].ToString(),
                    empa_license = dr["empa_license"].ToString(),
                    empa_dept_name = dr["empa_dept_name"].ToString(),
                    empa_desig_name = dr["empa_desig_name"].ToString(),
                    empa_mob = dr["empa_mob"].ToString(),
                    empa_status = dr["empa_status"].ToString(),
                    empa_operation = dr["empa_operation"].ToString(),
                    empa_madeby_name = dr["empa_madeby_name"].ToString(),
                    empa_date_created = Convert.ToDateTime(dr["empa_date_created"].ToString()),
                    empa_date_modified = Convert.ToDateTime(dr["empa_date_modified"].ToString()),
                });
            }
            return emploglist;
        }
        #endregion Employees

        #region Doctor Information
        public static DoctorAccountSummary DoctorAccountSummary(int empId)
        {
            DoctorAccountSummary summary = new DoctorAccountSummary();
            DataTable table = DataAccessLayer.Masters.Employees.DoctorAccountSummary(empId);

            if (table.Rows.Count > 0)
            {
                summary.CashSales = decimal.Parse(table.Rows[0]["CashSales"].ToString());
                summary.InsSales = decimal.Parse(table.Rows[0]["InsSales"].ToString());
                summary.Received = decimal.Parse(table.Rows[0]["Received"].ToString());
            }
            else
            {
                summary.CashSales = 0;
                summary.InsSales = 0;
            }

            return summary;
        }

        public static DoctorAppStatusSummary DoctorAppStatusSummary(int empId)
        {
            DoctorAppStatusSummary summary = new DoctorAppStatusSummary();

            DataTable dt = DataAccessLayer.Masters.Employees.DoctorAppStatusSummary(empId);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (r["app_status"].ToString() == "Booked")
                        summary.Booked = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Confirmed")
                        summary.Confirmed = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Arrived")
                        summary.Arrived = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Invoiced")
                        summary.Completed = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Cancelled")
                        summary.Cancelled = int.Parse(r["total"].ToString());
                    else if (r["app_status"].ToString() == "Deleted")
                        summary.Deleted = int.Parse(r["total"].ToString());
                }
            }
            else
            {
                summary.Booked = 0;
                summary.Confirmed = 0;
                summary.Arrived = 0;
                summary.Completed = 0;
                summary.Cancelled = 0;
                summary.Deleted = 0;
            }

            return summary;
        }

        public static DoctorInfo DoctorInfoSummary(int empId)
        {
            DoctorInfo summary = new DoctorInfo();

            List<DoctorAppSummary> app_summary = new List<DoctorAppSummary>();
            List<DoctorTreatmentSummary> treatment_summary = new List<DoctorTreatmentSummary>();
            List<DoctorInvoiceSummary> invoices_summary = new List<DoctorInvoiceSummary>();
            List<DoctorReceiptsSummary> receipts_summary = new List<DoctorReceiptsSummary>();
            List<DoctorPackageOrderSummary> po_summary = new List<DoctorPackageOrderSummary>();
            List<DoctorRemittances> doctor_remittances = new List<DoctorRemittances>();

            DataSet dataset = DataAccessLayer.Masters.Employees.DoctorInfoSummary(empId);

            if (dataset.Tables.Count > 0)
            {
                DataTable dt1 = dataset.Tables[0];

                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow r in dt1.Rows)
                    {
                        DoctorAppSummary s = new DoctorAppSummary();
                        s.appId = int.Parse(r["appId"].ToString());
                        s.app_fdate = DateTime.Parse(r["app_fdate"].ToString());
                        s.app_doc_ftime = r["app_doc_ftime"].ToString();
                        s.app_doc_ttime = r["app_doc_ttime"].ToString();
                        s.room = r["room"].ToString();
                        s.app_doctor = r["app_doctor"].ToString();
                        s.app_patient = r["app_patient"].ToString();
                        s.app_type = r["app_type"].ToString();
                        s.app_status = r["app_status"].ToString();
                        s.app_branch_name = r["app_branch_name"].ToString();
                        s.app_madeby_name = r["app_madeby_name"].ToString();
                        s.remarks = r["remarks"].ToString();

                        app_summary.Add(s);
                    }
                }

                DataTable dt2 = dataset.Tables[1];

                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow r in dt2.Rows)
                    {
                        DoctorTreatmentSummary s = new DoctorTreatmentSummary();
                        s.ptId = Convert.ToInt32(r["ptId"]);
                        s.appId = Convert.ToInt32(r["pt_appId"]);
                        s.pt_app_fdate = DateTime.Parse(r["pt_app_fdate"].ToString());
                        s.pt_tr_code = r["pt_tr_code"].ToString();
                        s.pt_tr_name = r["pt_tr_name"].ToString();
                        s.pt_status = r["pt_status"].ToString();
                        s.ip_name = r["ip_name"].ToString();
                        s.pt_qty = Convert.ToInt32(r["pt_qty"]);
                        s.pt_uprice = DataValidation.isDecimalValid(r["pt_uprice"].ToString());
                        s.pt_total = DataValidation.isDecimalValid(r["pt_total"].ToString());
                        s.pt_disc = DataValidation.isDecimalValid(r["pt_disc"].ToString());
                        s.pt_vat = DataValidation.isDecimalValid(r["pt_vat"].ToString());

                        treatment_summary.Add(s);
                    }
                }

                DataTable dt3 = dataset.Tables[2];

                if (dt3.Rows.Count > 0)
                {
                    foreach (DataRow r in dt3.Rows)
                    {
                        DoctorInvoiceSummary s = new DoctorInvoiceSummary();
                        s.invId = int.Parse(r["invId"].ToString());
                        s.inv_appId = int.Parse(r["inv_appId"].ToString());
                        s.app_fdate = DateTime.Parse(r["app_fdate"].ToString());
                        s.inv_date = DateTime.Parse(r["inv_date"].ToString());
                        s.inv_type = r["inv_type"].ToString();
                        s.inv_no = r["inv_no"].ToString();
                        s.inv_status = r["inv_status"].ToString();
                        s.inv_total = decimal.Parse(r["inv_total"].ToString());
                        s.inv_disc = decimal.Parse(r["inv_disc"].ToString());
                        s.inv_net = decimal.Parse(r["inv_net"].ToString());
                        s.inv_vat = decimal.Parse(r["inv_vat"].ToString());
                        s.inv_netvat = decimal.Parse(r["inv_netvat"].ToString());

                        invoices_summary.Add(s);
                    }
                }

                DataTable dt4 = dataset.Tables[3];

                if (dt4.Rows.Count > 0)
                {
                    foreach (DataRow r in dt4.Rows)
                    {
                        DoctorReceiptsSummary s = new DoctorReceiptsSummary();
                        s.recId = int.Parse(r["recId"].ToString());
                        s.rec_date = DateTime.Parse(r["rec_date"].ToString());
                        s.rec_chq_date = DateTime.Parse(r["rec_chq_date"].ToString());
                        s.rec_code = r["rec_code"].ToString();
                        s.rec_invoice_no = r["rec_invoice_no"].ToString();
                        s.rec_madeby_name = r["rec_madeby_name"].ToString();
                        s.rec_patient = r["pat_name"].ToString();
                        s.rec_cash = decimal.Parse(r["rec_cash"].ToString());
                        s.rec_cc = decimal.Parse(r["rec_cc"].ToString());
                        s.rec_chq = decimal.Parse(r["rec_chq"].ToString());
                        s.rec_bt = decimal.Parse(r["rec_bt"].ToString());
                        s.rec_allocated = decimal.Parse(r["rec_allocated"].ToString());
                        s.rec_vamount = decimal.Parse(r["rec_vamount"].ToString());
                        s.rec_lamount = decimal.Parse(r["rec_lamount"].ToString());
                        s.rec_debit = decimal.Parse(r["rec_debit"].ToString());
                        s.rec_cc_charges = decimal.Parse(r["rec_cc_charges2"].ToString());
                        s.rec_total = decimal.Parse(r["rec_total"].ToString());
                        s.total_refunded = decimal.Parse(r["total_refunded"].ToString());
                        s.total_net = decimal.Parse(r["total_net"].ToString());

                        receipts_summary.Add(s);
                    }
                }

                DataTable dt5 = dataset.Tables[4];

                if (dt5.Rows.Count > 0)
                {
                    foreach (DataRow r in dt5.Rows)
                    {
                        DoctorPackageOrderSummary s = new DoctorPackageOrderSummary();
                        s.psId = int.Parse(r["psId"].ToString());
                        s.po_refno = r["po_refno"].ToString();
                        s.package_code = r["package_code"].ToString();
                        s.ps_packagename = r["ps_packagename"].ToString();
                        s.service_code = r["service_code"].ToString();
                        s.service_name = r["service_name"].ToString();
                        s.ps_qty = int.Parse(r["ps_qty"].ToString());
                        s.used_ses = int.Parse(r["used_ses"].ToString());
                        s.avail_ses = (int.Parse(r["ps_qty"].ToString()) - int.Parse(r["used_ses"].ToString()));
                        s.po_status = r["po_status"].ToString();

                        po_summary.Add(s);
                    }
                }

                DataTable dt6 = dataset.Tables[5];

                if (dt6.Rows.Count > 0)
                {
                    foreach (DataRow r in dt6.Rows)
                    {
                        DoctorRemittances s = new DoctorRemittances();
                        s.xrea_claimId = r["xrea_claimId"].ToString();
                        s.xrea_code = r["xrea_code"].ToString();
                        s.xrec_TransactionDate = r["xrec_TransactionDate"].ToString();
                        s.treatment = r["treatment"].ToString();
                        s.xrea_net = DataValidation.isDecimalValid(r["xrea_net"].ToString());
                        s.xrea_PaymentAmount = DataValidation.isDecimalValid(r["xrea_PaymentAmount"].ToString());
                        s.denial_desc = r["denial_desc"].ToString();

                        doctor_remittances.Add(s);
                    }
                }
            }

            summary.app_summary = app_summary;
            summary.treatment_summary = treatment_summary;
            summary.invoices_summary = invoices_summary;
            summary.receipts_summary = receipts_summary;
            summary.po_summary = po_summary;
            summary.doctor_remittances = doctor_remittances;

            return summary;
        }
        #endregion

        #region Employee Rosters
        public static List<EmployeeRoasters> GetRosters(RosterSearch search)
        {
            List<EmployeeRoasters> rosterlist = new List<EmployeeRoasters>();

            DataTable dt = DataAccessLayer.Masters.Employees.GetRosters(search);

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeRoasters roster = new EmployeeRoasters();
                roster.erId = Convert.ToInt32(dr["erId"]);
                roster.er_day = dr["er_day"].ToString();
                roster.er_type = dr["er_type"].ToString();
                roster.ftime = dr["ftime"].ToString();
                roster.ttime = dr["ttime"].ToString();
                roster.er_fdate = Convert.ToDateTime(dr["er_fdate"]);
                roster.er_tdate = Convert.ToDateTime(dr["er_tdate"]);
                roster.set_company = dr["set_company"].ToString();
                roster.er_employee_name = dr["er_employee_name"].ToString();

                rosterlist.Add(roster);
            }
            return rosterlist;
        }

        public static List<EmployeeRoasters> EmployeeRosters(int empId)
        {
            List<EmployeeRoasters> roasterlist = new List<EmployeeRoasters>();

            DataTable dt = DataAccessLayer.Masters.Employees.EmployeeRosters(empId);

            foreach (DataRow dr in dt.Rows)
            {
                EmployeeRoasters roaster = new EmployeeRoasters();
                roaster.erId = Convert.ToInt32(dr["erId"]);
                roaster.er_employee = Convert.ToInt32(dr["er_employee"]);
                roaster.er_branch = Convert.ToInt32(dr["er_branch"]);
                roaster.er_ftime = Convert.ToInt32(dr["er_ftime"]);
                roaster.er_ttime = Convert.ToInt32(dr["er_ttime"]);
                roaster.er_fdate = Convert.ToDateTime(dr["er_fdate"]);
                roaster.er_tdate = Convert.ToDateTime(dr["er_tdate"]);
                roaster.er_day = dr["er_day"].ToString();
                roaster.er_round = dr["er_round"].ToString();
                roaster.er_type = dr["er_type"].ToString();
                roaster.er_range = dr["er_range"].ToString();
                roaster.ftime = dr["ftime"].ToString();
                roaster.ttime = dr["ttime"].ToString();
                roaster.er_status = dr["er_status"].ToString();
                roaster.set_company = dr["set_company"].ToString();

                roasterlist.Add(roaster);
            }
            return roasterlist;
        }

        public static List<CommonDDL> GetTimeSlotList(int app_branch)
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetTimeSlots(app_branch);

            List<CommonDDL> timeslotlist = new List<CommonDDL>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    timeslotlist.Add(new CommonDDL
                    {
                        id = Convert.ToInt32(dr["id"]),
                        text = dr["text"].ToString()
                    });
                }
            }
            return timeslotlist;
        }

        public static string InsertRoster(EmployeeRoasters roster)
        {
            string days = string.Join(",", roster.er_day.Split(',').Select(x => string.Format("{0}", x)).ToList());
            string[] arr = days.Split(',');

            DataTable dt = new DataTable();
            dt.Columns.Add("er_employee", typeof(int));
            dt.Columns.Add("er_branch", typeof(int));
            dt.Columns.Add("er_day", typeof(string));
            dt.Columns.Add("er_ftime", typeof(int));
            dt.Columns.Add("er_ttime", typeof(int));
            dt.Columns.Add("er_type", typeof(string));
            dt.Columns.Add("er_fdate", typeof(DateTime));
            dt.Columns.Add("er_tdate", typeof(DateTime));
            dt.Columns.Add("er_range", typeof(string));
            dt.Columns.Add("er_round", typeof(string));

            foreach (var day in arr)
            {
                DataRow dr = dt.NewRow();
                dr["er_employee"] = roster.er_employee;
                dr["er_branch"] = roster.er_branch;
                dr["er_day"] = day;
                dr["er_ftime"] = roster.er_ftime;
                dr["er_ttime"] = roster.er_ttime;
                dr["er_type"] = roster.er_type;
                dr["er_fdate"] = roster.er_fdate;
                dr["er_tdate"] = roster.er_tdate;
                dr["er_range"] = roster.er_range;

                if (roster.er_ttime > roster.er_ftime)
                {
                    dr["er_round"] = "No";
                }
                else
                {
                    dr["er_round"] = "Yes";
                }

                dt.Rows.Add(dr);
            }

            return DataAccessLayer.Masters.Employees.InsertRoster(dt);
        }

        public static EmployeeRoasters GetEmployeeRosterById(int erId)
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetEmployeeRosterById(erId);

            EmployeeRoasters roaster = new EmployeeRoasters();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                roaster.erId = Convert.ToInt32(dr["erId"]);
                roaster.er_employee = Convert.ToInt32(dr["er_employee"]);
                roaster.er_branch = Convert.ToInt32(dr["er_branch"]);
                roaster.er_ftime = Convert.ToInt32(dr["er_ftime"]);
                roaster.er_ttime = Convert.ToInt32(dr["er_ttime"]);
                roaster.er_fdate = Convert.ToDateTime(dr["er_fdate"]);
                roaster.er_tdate = Convert.ToDateTime(dr["er_tdate"]);
                roaster.er_day = dr["er_day"].ToString();
                roaster.er_round = dr["er_round"].ToString();
                roaster.er_type = dr["er_type"].ToString();
                roaster.er_range = dr["er_range"].ToString();
                roaster.ftime = dr["ftime"].ToString();
                roaster.ttime = dr["ttime"].ToString();
                roaster.er_status = dr["er_status"].ToString();
                roaster.set_company = dr["set_company"].ToString();
            }

            return roaster;
        }

        public static string UpdateRoster(EmployeeRoasters roster)
        {
            if (roster.er_ttime > roster.er_ftime)
            {
                roster.er_round = "No";
            }
            else
            {
                roster.er_round = "Yes";
            }

            return DataAccessLayer.Masters.Employees.UpdateRoster(roster);
        }

        public static int UpdateEmployeeRosterStatus(int erId, string er_status)
        {
            return DataAccessLayer.Masters.Employees.UpdateEmployeeRosterStatus(erId, er_status);
        }

        #endregion

        #region Employee Rights
        public static EmployeesRights GetResourcesForRights(int empId)
        {
            try
            {
                EmployeesRights rights = new EmployeesRights();

                DataSet ds = DataAccessLayer.Masters.Employees.GetResourcesForRights(empId);

                List<BusinessEntities.Masters.Rights.Module> module_list = new List<BusinessEntities.Masters.Rights.Module>();
                List<BusinessEntities.Masters.Rights.Sub_Module> sub_module_list = new List<BusinessEntities.Masters.Rights.Sub_Module>();
                List<BusinessEntities.Masters.Rights.Pages> page_list = new List<BusinessEntities.Masters.Rights.Pages>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        BusinessEntities.Masters.Rights.Module mod = new BusinessEntities.Masters.Rights.Module();
                        mod.L1Id = Convert.ToInt32(dr["L1Id"]);
                        mod.L1_Value = dr["L1_Value"].ToString();
                        mod.L1_Status = dr["L1_Status"].ToString();

                        module_list.Add(mod);
                    }
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        Sub_Module submod = new Sub_Module();
                        submod.L2Id = Convert.ToInt32(dr["L2Id"]);
                        submod.L1Id = Convert.ToInt32(dr["L1Id"]);
                        submod.L2_Value = dr["L2_Value"].ToString();
                        submod.L2_Status = dr["L2_Status"].ToString();

                        sub_module_list.Add(submod);
                    }
                }

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        BusinessEntities.Masters.Rights.Pages page = new BusinessEntities.Masters.Rights.Pages();
                        page.L3Id = Convert.ToInt32(dr["L3Id"]);
                        page.L1Id = Convert.ToInt32(dr["L1Id"]);
                        page.L2Id = Convert.ToInt32(dr["L2Id"]);
                        page.L3_Value = dr["L3_Value"].ToString();
                        page.L3_Status = dr["L3_Status"].ToString();

                        page_list.Add(page);
                    }
                }

                rights.modules_list = module_list;
                rights.sub_modules_list = sub_module_list;
                rights.pages_list = page_list;

                List<string> checked_pages = new List<string>();

                int l1_cCount = 0;
                int l1_rCount = 0;
                int l1_uCount = 0;
                int l1_dCount = 0;
                int l1_eCount = 0;
                int l1_pCount = 0;
                int l1_aCount = 0;

                foreach (BusinessEntities.Masters.Rights.Module m in module_list)
                {
                    var sub_module = from submod in sub_module_list
                                     where submod.L1Id == m.L1Id
                                     select new { submod.L1Id, submod.L2Id, submod.L2_Value, submod.L2_Status };

                    int subModuleCount = sub_module.Count();

                    int l2_cCount = 0;
                    int l2_rCount = 0;
                    int l2_uCount = 0;
                    int l2_dCount = 0;
                    int l2_eCount = 0;
                    int l2_pCount = 0;
                    int l2_aCount = 0;

                    foreach (var sm in sub_module)
                    {
                        var page = from pg in page_list
                                   where pg.L2Id == sm.L2Id
                                   select new { pg.L1Id, pg.L2Id, pg.L3Id, pg.L3_Value };

                        int pagesCount = page.Count();

                        int cCount = 0;
                        int rCount = 0;
                        int uCount = 0;
                        int dCount = 0;
                        int eCount = 0;
                        int pCount = 0;
                        int aCount = 0;

                        foreach (var pg in page)
                        {
                            DataRow[] dr = ds.Tables[3].Select("L3Id = " + pg.L3Id);

                            if (dr.Length > 0)
                            {
                                bool isCreate = Convert.ToBoolean(dr[0]["isCreate"]);
                                bool isRead = Convert.ToBoolean(dr[0]["isRead"]);
                                bool isUpdate = Convert.ToBoolean(dr[0]["isUpdate"]);
                                bool isDelete = Convert.ToBoolean(dr[0]["isDelete"]);
                                bool isExport = Convert.ToBoolean(dr[0]["isExport"]);
                                bool isPrint = Convert.ToBoolean(dr[0]["isPrint"]);

                                if (isCreate)
                                {
                                    cCount++;
                                    checked_pages.Add("cl3_" + dr[0]["L3Id"]);
                                }

                                if (isRead)
                                {
                                    rCount++;
                                    checked_pages.Add("rl3_" + dr[0]["L3Id"]);
                                }

                                if (isUpdate)
                                {
                                    uCount++;
                                    checked_pages.Add("ul3_" + dr[0]["L3Id"]);
                                }

                                if (isDelete)
                                {
                                    dCount++;
                                    checked_pages.Add("dl3_" + dr[0]["L3Id"]);
                                }

                                if (isExport)
                                {
                                    eCount++;
                                    checked_pages.Add("el3_" + dr[0]["L3Id"]);
                                }

                                if (isPrint)
                                {
                                    pCount++;
                                    checked_pages.Add("pl3_" + dr[0]["L3Id"]);
                                }

                                if (isCreate && isRead && isUpdate && isDelete && isExport && isPrint)
                                {
                                    aCount++;
                                    checked_pages.Add("alll3_" + dr[0]["L3Id"]);
                                }
                            }

                        }


                        if (pagesCount == cCount)
                        {
                            l2_cCount++;
                            checked_pages.Add("cl2_" + sm.L2Id);
                        }

                        if (pagesCount == rCount)
                        {
                            l2_rCount++;
                            checked_pages.Add("rl2_" + sm.L2Id);
                        }

                        if (pagesCount == uCount)
                        {
                            l2_uCount++;
                            checked_pages.Add("ul2_" + sm.L2Id);
                        }

                        if (pagesCount == dCount)
                        {
                            l2_dCount++;
                            checked_pages.Add("dl2_" + sm.L2Id);
                        }

                        if (pagesCount == eCount)
                        {
                            l2_eCount++;
                            checked_pages.Add("el2_" + sm.L2Id);
                        }

                        if (pagesCount == pCount)
                        {
                            l2_pCount++;
                            checked_pages.Add("pl2_" + sm.L2Id);
                        }

                        if ((pagesCount == cCount) && (pagesCount == rCount) && (pagesCount == uCount) &&
                            (pagesCount == dCount) && (pagesCount == eCount) && (pagesCount == pCount))
                        {
                            l2_aCount++;
                            checked_pages.Add("alll2_" + sm.L2Id);
                        }
                    }

                    if (subModuleCount == l2_cCount)
                    {
                        l1_cCount++;
                        checked_pages.Add("cl1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_rCount)
                    {
                        l1_rCount++;
                        checked_pages.Add("rl1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_uCount)
                    {
                        l1_uCount++;
                        checked_pages.Add("ul1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_dCount)
                    {
                        l1_dCount++;
                        checked_pages.Add("dl1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_eCount)
                    {
                        l1_eCount++;
                        checked_pages.Add("el1_" + m.L1Id);
                    }

                    if (subModuleCount == l2_pCount)
                    {
                        l1_pCount++;
                        checked_pages.Add("pl1_" + m.L1Id);
                    }

                    if ((subModuleCount == l2_cCount) && (subModuleCount == l2_rCount) && (subModuleCount == l2_uCount) &&
                        (subModuleCount == l2_dCount) && (subModuleCount == l2_eCount) && (subModuleCount == l2_pCount))
                    {
                        l1_aCount++;
                        checked_pages.Add("alll1_" + m.L1Id);
                    }
                }

                if (module_list.Count() == l1_cCount)
                {
                    checked_pages.Add("all_c");
                }

                if (module_list.Count() == l1_rCount)
                {
                    checked_pages.Add("all_r");
                }

                if (module_list.Count() == l1_uCount)
                {
                    checked_pages.Add("all_u");
                }

                if (module_list.Count() == l1_dCount)
                {
                    checked_pages.Add("all_d");
                }

                if (module_list.Count() == l1_eCount)
                {
                    checked_pages.Add("all_e");
                }

                if (module_list.Count() == l1_pCount)
                {
                    checked_pages.Add("all_p");
                }

                if ((module_list.Count() == l1_cCount) && (module_list.Count() == l1_rCount) && (module_list.Count() == l1_uCount) &&
                    (module_list.Count() == l1_dCount) && (module_list.Count() == l1_eCount) && (module_list.Count() == l1_pCount))
                {
                    checked_pages.Add("all_all");
                }

                rights.checked_pages = checked_pages;

                return rights;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string UpdateRights(List<BusinessEntities.Masters.Rights.PageAccess> rights)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Columns.Add("L3Id", typeof(int));
            dt.Columns.Add("isCreate", typeof(bool));
            dt.Columns.Add("isUpdate", typeof(bool));
            dt.Columns.Add("isRead", typeof(bool));
            dt.Columns.Add("isDelete", typeof(bool));
            dt.Columns.Add("isExport", typeof(bool));
            dt.Columns.Add("isPrint", typeof(bool));

            foreach (var right in rights)
            {
                DataRow dr = dt.NewRow();
                dr["EmpId"] = right.EmpId;
                dr["L3Id"] = right.L3Id;
                dr["isCreate"] = right.isCreate;
                dr["isUpdate"] = right.isUpdate;
                dr["isRead"] = right.isRead;
                dr["isDelete"] = right.isDelete;
                dr["isExport"] = right.isExport;
                dr["isPrint"] = right.isPrint;

                dt.Rows.Add(dr);
            }

            return DataAccessLayer.Masters.Employees.UpdateRights(dt);
        }

        public static BusinessEntities.Masters.ChangeEmployeePassword GetEmployeeLoginById(int? empId)
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetEmployeeLoginById(empId);

            BusinessEntities.Masters.ChangeEmployeePassword emp = new BusinessEntities.Masters.ChangeEmployeePassword();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                emp.empId = Convert.ToInt32(dr["empId"]);
                emp.cemp_login = dr["emp_login"].ToString();
            }

            return emp;
        }
        #endregion

        #region Employee Logged in Time
        public static void EmployeeLoggedInTime(int empId, string type)
        {
            DataAccessLayer.Masters.Employees.EmployeeLoggedInTime(empId, type);
        }
        #endregion

        #region Chart of Account
        public static List<EmployeeAccounts> GetEmployeeCOA(EmployeeChartofAccount search)
        {
            DataTable dt = DataAccessLayer.Masters.Employees.GetEmployeeCOA(search);

            List<EmployeeAccounts> _list = new List<EmployeeAccounts>();
            DefaultAccountsList da = new DefaultAccountsList();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    _list.Add(new EmployeeAccounts
                    {
                        branch_name = dr["branch_name"].ToString(),
                        account_code = dr["acc_code"].ToString(),
                        account_name = dr["acc_name"].ToString(),
                        empId = search.empId,
                        branch = search.branch,
                        acc_period = search.acc_period,
                        acc_type = dr["acc_gtype"].ToString(),
                        group_name = dr["group_name"].ToString(),
                        category_name = dr["category_name"].ToString(),
                        acc_category = dr["acc_category"].ToString()
                    });
                }
            }

            return _list;
        }

        public static int CreateEmployeeCOA(EmployeeAccounts data)
        {
            return DataAccessLayer.Masters.Employees.CreateEmployeeCOA(data);
        }

        #endregion
    }
}