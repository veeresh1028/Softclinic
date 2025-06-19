using BusinessEntities.Appointment;
using BusinessEntities.Masters.Rights;
using BusinessEntities.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.Masters
{
    public class Employees
    {
        public int empId { get; set; }
        public string emp_status { get; set; }
        public int emp_madeby { get; set; }
        public int emp_modifyby { get; set; }
        public string set_company { get; set; }
        public string emp_photo { get; set; }
        public string emp_login { get; set; }
        public string emp_color { get; set; }
        public string emp_fax { get; set; }
        public string emp_name { get; set; }
        public string emp_address { get; set; }
        public string emp_license { get; set; }
        public string department { get; set; }
        public string designation { get; set; }
        public string emp_speciality { get; set; }
        public string emp_teeth { get; set; }
        public string emp_mob { get; set; }
        public string sales_acc_namecode { get; set; }
        public string comm_acc_namecode { get; set; }
        public int emp_branch { get; set; }
        public int emp_dept { get; set; }
        public int emp_desig { get; set; }
        public int emp_nat { get; set; }
        public string emp_lname { get; set; }
        public string emp_gender { get; set; }
        public string emp_tel { get; set; }
        public string emp_email { get; set; }
        public string emp_sign { get; set; }
        public string emp_emid { get; set; }
        public string emp_stamp { get; set; }
        public string emp_whatsappId { get; set; }
        public string emp_whatsappToken { get; set; }
        public string emp_dha_speciality { get; set; }
        public string emp_dha_login { get; set; }
        public string emp_dha_pass { get; set; }
        public string emp_pass { get; set; }
        public string emp_confirmpass { get; set; }
        public string emp_work_branch { get; set; }
        public decimal emp_disc_allowed { get; set; }
        public decimal emp_consultation_commi { get; set; }
        public decimal emp_procedure_commi { get; set; }
        public decimal emp_lab_commi { get; set; }
        public decimal emp_rad_commi { get; set; }
        public decimal emp_pha_commi { get; set; }
        public decimal emp_met_commi { get; set; }
        public string hashpass { get; set; }
        public string nationality { get; set; }
        public int emp_scheduler { get; set; }
        public string emp_moh_login { get; set; }
        public string emp_moh_pass { get; set; }
        public string emp_flag { get; set; }
        public string emp_pwd_validity { get; set; }
        public string emp_outside_access { get; set; }
        public string set_city { get; set; }
        public DateTime emp_date_created { get; set; }
        public string actionvisible { get; set; }
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
        [NotMapped]
        public List<Departments> DepartmentList { get; set; }
        [NotMapped]
        public List<CommonDDL> DesignationList { get; set; }
        [NotMapped]
        public List<CommonDDL> NationalityList { get; set; }
    }

    public class EmployeesSearch
    {
        public int empId { get; set; } = 0;
        public int search_type { get; set; } = 0;
        public string branch_ids { get; set; } = string.Empty;
        public string dept_ids { get; set; } = string.Empty;
        public string desig_ids { get; set; } = string.Empty;
        public string nats_ids { get; set; } = string.Empty;
        public string select_gender { get; set; } = string.Empty;
        public string select_status { get; set; } = string.Empty;
    }

    public class EmployeesRights
    {
        public int empId { get; set; }
        public List<Module> modules_list { get; set; }
        public List<Sub_Module> sub_modules_list { get; set; }
        public List<Rights.Pages> pages_list { get; set; }
        public List<string> checked_pages { get; set; }
    }

    public class DoctorDetailInfo
    {
        public int empId { get; set; }
        public string emp_name { get; set; }
        public Employees emp_info { get; set; }
        public DoctorAccountSummary acc_summary { get; set; }
        public DoctorAppStatusSummary app_status_summary { get; set; }
        public DoctorInfo summary { get; set; }
    }

    public class DoctorAccountSummary
    {
        public decimal CashSales { get; set; }
        public decimal InsSales { get; set; }
        public decimal Received { get; set; }
    }

    public class DoctorAppStatusSummary
    {
        public int Booked { get; set; }
        public int Confirmed { get; set; }
        public int Arrived { get; set; }
        public int Completed { get; set; }
        public int Cancelled { get; set; }
        public int Deleted { get; set; }
    }

    public class DoctorInfo
    {
        public List<DoctorAppSummary> app_summary { get; set; }
        public List<DoctorTreatmentSummary> treatment_summary { get; set; }
        public List<DoctorInvoiceSummary> invoices_summary { get; set; }
        public List<DoctorReceiptsSummary> receipts_summary { get; set; }
        public List<DoctorPackageOrderSummary> po_summary { get; set; }
        public List<DoctorRemittances> doctor_remittances { get; set; }
    }

    public class DoctorAppSummary
    {
        public int appId { get; set; }
        public DateTime app_fdate { get; set; }
        public string app_doc_ftime { get; set; }
        public string app_doc_ttime { get; set; }
        public string room { get; set; }
        public string app_doctor { get; set; }
        public string app_patient { get; set; }
        public string app_type { get; set; }
        public string app_status { get; set; }
        public string app_branch_name { get; set; }
        public string app_madeby_name { get; set; }
        public string remarks { get; set; }
    }

    public class DoctorTreatmentSummary
    {
        public int ptId { get; set; }
        public int appId { get; set; }
        public DateTime pt_app_fdate { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public int pt_qty { get; set; }
        public decimal pt_uprice { get; set; }
        public decimal pt_total { get; set; }
        public decimal pt_disc { get; set; }
        public decimal pt_vat { get; set; }
        public string pt_status { get; set; }
        public string ip_name { get; set; }
    }

    public class DoctorInvoiceSummary
    {
        public int invId { get; set; }
        public int inv_appId { get; set; }
        public DateTime app_fdate { get; set; }
        public string inv_type { get; set; }
        public string inv_no { get; set; }
        public DateTime inv_date { get; set; }
        public decimal inv_total { get; set; }
        public decimal inv_disc { get; set; }
        public decimal inv_net { get; set; }
        public decimal inv_vat { get; set; }
        public decimal inv_netvat { get; set; }
        public string inv_status { get; set; }
    }

    public class DoctorReceiptsSummary
    {
        public int recId { get; set; }
        public string rec_code { get; set; }
        public DateTime rec_date { get; set; }
        public string rec_invoice_no { get; set; }
        public string rec_madeby_name { get; set; }
        public string rec_patient { get; set; }
        public decimal rec_cash { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_chq { get; set; }
        public DateTime rec_chq_date { get; set; }
        public decimal rec_bt { get; set; }
        public decimal rec_allocated { get; set; }
        public decimal rec_vamount { get; set; }
        public decimal rec_lamount { get; set; }
        public decimal rec_debit { get; set; }
        public decimal rec_cc_charges { get; set; }
        public decimal rec_total { get; set; }
        public decimal total_refunded { get; set; }
        public decimal total_net { get; set; }

    }

    public class DoctorPackageOrderSummary
    {
        public int psId { get; set; }
        public string po_refno { get; set; }
        public string package_code { get; set; }
        public string ps_packagename { get; set; }
        public string service_code { get; set; }
        public string service_name { get; set; }
        public int ps_qty { get; set; }
        public int used_ses { get; set; }
        public int avail_ses { get; set; }
        public string po_status { get; set; }
    }

    public class DoctorRemittances
    {
        public string xrea_claimId { get; set; }
        public string xrec_TransactionDate { get; set; }
        public string xrea_code { get; set; }
        public decimal xrea_net { get; set; }
        public decimal xrea_PaymentAmount { get; set; }
        public string treatment { get; set; }
        public string denial_desc { get; set; }
    }

    public class EmployeeRoasters
    {
        public int erId { get; set; }
        public int er_employee { get; set; }
        public string er_employee_name { get; set; }
        public int er_branch { get; set; }
        public string er_day { get; set; }
        public int er_ftime { get; set; }
        public int er_ttime { get; set; }
        public string er_status { get; set; }
        public string er_type { get; set; }
        public DateTime er_fdate { get; set; }
        public DateTime er_tdate { get; set; }
        public string er_range { get; set; }
        public string er_round { get; set; }
        public string ftime { get; set; }
        public string ttime { get; set; }
        public string set_company { get; set; }
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
    }

    public class RosterSearch
    {
        public int search_type { get; set; }
        public string er_branch { get; set; }
        public string er_day { get; set; }
        public string er_type { get; set; }
    }

    public class LoginEmployee
    {
        public int empId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string old_password { get; set; }
    }

    public class ChangeEmployeePassword
    {
        public int empId { get; set; }
        public string cemp_login { get; set; }
        public string cemp_loggedin { get; set; }
        public string cpassword { get; set; }
        public string cconfirm_password { get; set; }
    }
    
    public class EmployeeChartofAccount
    {
        public int login_empId { get; set; }
        public int empId { get; set; }
        public int branch { get; set; }
        public string emp_name { get; set; }
        public string year { get; set; }
        public string acc_period { get; set; }
        public string acc_type { get; set; }
    }
    
    public class EmployeeAccounts
    {
        public int empId { get; set; }
        public int branch { get; set; }
        public string branch_name { get; set; }
        public string account_code { get; set; }
        public string account_name { get; set; }
        public string group_name { get; set; }
        public string acc_category { get; set; }
        public string category_name { get; set; }
        public string emp_name { get; set; }
        public string acc_period { get; set; }
        public string acc_type { get; set; }
        public int logId { get; set; }
    }

}