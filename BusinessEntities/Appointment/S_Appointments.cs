using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Appointment
{
    public class S_Appointments
    {
        public string id { get; set; }
        public string resourceId { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string title { get; set; }
        
        public string backgroundColor { get; set; }
        public string textColor { get; set; }
        public string borderColor { get; set; }
        public S_Appointment_Info extendedProps { get; set; }
    }

    public class S_Appointment_Info
    {
        public string pat_code { get; set; }
        public string pat_mob { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_name { get; set; }
        public string pat_photo { get; set; }
        public string pat_gender { get; set; }
        public string pat_age { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_nationality { get; set; }
        public string app_doctor { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_color { get; set; }
        public string app_fdate { get; set; }
        public string app_inout { get; set; }
        public string app_branch { get; set; }
        public string app_room { get; set; }
        public string app_room_name { get; set; }
        public string app_ftime { get; set; }
        public string app_ttime { get; set; }
        public string app_patient { get; set; }
        public string app_ins { get; set; }
        public string app_type { get; set; }
        public string app_status { get; set; }
        public string app_emergency { get; set; }
        public string app_service { get; set; }
        public string app_eligibility { get; set; }
        public string app_resnforvisit { get; set; }
        public string app_comments { get; set; }
        public string app_po { get; set; }
        public string app_ic_name { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_price { get; set; }
        public string simplybook_status { get; set; }
        public string room_color { get; set; }
        public string app_category { get; set; }
        public string title_arb { get; set; }
    }

    public class Appointment
    {
        public int appId { get; set; } = 0;
        public int app_room { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_tdate { get; set; }
        public DateTime app_ae_date { get; set; }
        public int app_ftime { get; set; }
        public int app_ttime { get; set; }
        public int app_ins { get; set; } = 0;
        public int app_doctor { get; set; }
        public int app_madeby { get; set; } = 0;
        public string app_type { get; set; }
        public string app_status { get; set; }
        public string app_pat_code { get; set; }
        public int app_branch { get; set; }
        public string app_inout { get; set; }
        public int app_duplicate { get; set; } = 0;
        public int app_rappId { get; set; } = 0;
        public string app_emergency { get; set; }
        public int app_source { get; set; } = 0;
        public int app_compaign { get; set; } = 0;
        public string app_status2 { get; set; } = string.Empty;
        public string app_eligibility { get; set; } = string.Empty;
        public string app_reason_for_visit { get; set; }
        public int app_package_order { get; set; }
        public string app_comments { get; set; } = string.Empty;
        public string app_service { get; set; }
        public string app_doc_ftime { get; set; } = string.Empty;
        public string app_doc_ttime { get; set; } = string.Empty;
        public int app_patient { get; set; }

        public string app_category { get; set; }
        // Recurring Appointment
        public string app_rec_pattern { get; set; }
        public int app_rec_days { get; set; }
        public string app_rec_daily { get; set; }
        public int isAvailable { get; set; }
        public int isBooked { get; set; }
        public string app_days_week { get; set; }
        public int app_days_month { get; set; }
        public string app_riayathiConsent { get; set; }
        // Appointment Dropdowns
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
        [NotMapped]
        public List<CommonDDL> RoomsList { get; set; }
        [NotMapped]
        public List<S_Doctor> DoctorsList { get; set; }
        [NotMapped]
        public List<CommonDDL> FromTimeList { get; set; }
        [NotMapped]
        public List<CommonDDL> ToTimeList { get; set; }
        [NotMapped]
        public List<CommonDDL> StatusList { get; set; }
       
    }

    public class ReBookAppointment
    {
        public int appId { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_tdate { get; set; }
        public String app_doc_ftime { get; set; }
        public String app_doc_ttime { get; set; }
        public int app_doctor { get; set; }
        public int app_room { get; set; }
        public int app_branch { get; set; }
        public int app_madeby { get; set; }
    }

    public class DepartmentSearchList
    {
        public string[] Departments { get; set; }
        public string Doctor { get; set; }
    }

    public class AppointmentList
    {
        // Appointments Table
        public int appId { get; set; }
        public string app_pat_code { get; set; }
        public string pt_auth_code { get; set; }
        public string app_status { get; set; }
        public string app_type { get; set; }
        public string app_doc_ftime { get; set; }
        public string app_doc_ttime { get; set; }
        public string app_madeby_name { get; set; }
        public string app_resnforvisit { get; set; }
        public string app_inout { get; set; }
        public string app_ic_name { get; set; }
        public int app_branch { get; set; }
        public int app_doctor { get; set; }
        public int app_ins { get; set; }
        public int app_po { get; set; }
        public string app_service { get; set; }
        public int app_room { get; set; }
        public string app_emergency { get; set; }
        public string app_ftime { get; set; }
        public string app_ttime { get; set; }
        public string app_eligibility { get; set; }
        public string app_comments { get; set; }
        public int app_patient { get; set; }
        public DateTime app_fdate { get; set; }
        public DateTime app_ae_date { get; set; }
        public string app_category { get; set; }
        public string set_emr_lock { get; set; }
        // Patients Table
        public int patId { get; set; }
        public string pat_name { get; set; }
        public string pat_photo { get; set; }
        public string pat_gender { get; set; }
        public string pat_mob { get; set; }
        public string pat_emirateid { get; set; }
        public string pat_class { get; set; }
        public int pat_referal { get; set; }
        public string pat_email { get; set; }
        public DateTime id_card_idate { get; set; }
        public DateTime id_card_edate { get; set; }
        public DateTime pat_dob { get; set; }
        // Employees Table
        public int empId { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_license { get; set; }
        public string emp_color { get; set; }
        public string emp_status { get; set; }
        // Appointments Status Color Table
        public string aps_color { get; set; }
        // Rooms Table
        public string room { get; set; }
        // Nationalities Table
        public string nationality { get; set; }
        // Appointment Remarks Table
        public string remarks { get; set; }
        // Insurance
        public string ins_exp { get; set; }
        // EMR Pendings
        public int pendings { get; set; }        
        public decimal balance { get; set; }        
        public decimal pat_tot_balance { get; set; }        
        public DateTime date_arrived { get; set; }
        public DateTime date_invoiced { get; set; }
    }

    public class AppointmentSearch
    {
        public int search_type { get; set; }
        public string branch_ids { get; set; } = string.Empty;
        public string dept_ids { get; set; } = string.Empty;
        public string doc_ids { get; set; } = string.Empty;
        public string room_ids { get; set; } = string.Empty;
        public string referral_ids { get; set; } = string.Empty;
        public string nats_ids { get; set; } = string.Empty;
        public string types { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public int patient { get; set; } = 0;
        public string ins_tpa { get; set; } = string.Empty;
        public string ins_scheme { get; set; } = string.Empty;
        public string ins_payer { get; set; } = string.Empty;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("2099-01-01");
    }

    public class AppointmentCount
    {
        public int Booked { get; set; }
        public int Confirmed { get; set; }
        public int Arrived { get; set; }
        public int NurseStation { get; set; }
        public int WithDoctor { get; set; }
        public int Invoiced { get; set; }
        public int Cancelled { get; set; }
        public int Total { get; set; }
    }

    public class AppointmentStatusColor
    {
        public string Booked { get; set; }
        public string Confirmed { get; set; }
        public string Arrived { get; set; }
        public string NurseStation { get; set; }
        public string WithDoctor { get; set; }
        public string Invoiced { get; set; }
        public string Cancelled { get; set; }
    }

    public class AppointmentListData
    {
        public List<AppointmentList> AppointmentList { get; set; }
        public AppointmentCount AppointmentCount { get; set; }
        public AppointmentStatusColor AppointmentStatusColor { get; set; }
    }

    public class SearchAppJourney
    {
        public int appId { get; set; }
    }
    public class TokenResult
    {
        public byte[] FileContent { get; set; }
        public string FileName { get; set; }
    }
    public class AppointmentHistory
    {
        public int appId { get; set; }
        public int patId { get; set; }
        public DateTime app_fdate { get; set; }
        public string app_ftime { get; set; }
        public string app_ttime { get; set; }
        public string emp_name { get; set; }
        public int empId { get; set; }
        public int emp_dept { get; set; }
        public string emp_dept_name { get; set; }
        public string app_type { get; set; }
        public string app_status { get; set; }
        public string app_instype { get; set; }
        public string patient { get; set; }
    }
}