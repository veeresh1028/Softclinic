using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Invoice
{
    public class AdvanceLoyaltyRefund
    {
        public int recId { get; set; }
        public int rec_branch { get; set; }
        public string rec_doctor_name { get; set; }
        public string rec_status2 { get; set; }
        public string rec_code { get; set; }
        public string rec_type { get; set; }
        public string rec_notes { get; set; }
        public decimal rec_loy_value { get; set; }
        public int rec_patient { get; set; }
        public DateTime rec_date { get; set; }
        public decimal rec_cash { get; set; }
        public decimal rec_tabby { get; set; }
        public decimal rec_self { get; set; }
        public decimal rec_spoti { get; set; }
        public decimal rec_group { get; set; }
        public decimal rec_cob { get; set; }
        public decimal rec_stripe { get; set; }
        public decimal rec_tamara { get; set; }
        public decimal rec_extra_pay1 { get; set; }
        public decimal rec_extra_pay2 { get; set; }
        public decimal rec_extra_pay3 { get; set; }
        public decimal rec_cc { get; set; }
        public decimal rec_chq { get; set; }
        public string rec_chq_no { get; set; }
        public string rec_chq_bank { get; set; }
        public DateTime rec_chq_date { get; set; }
        public decimal rec_bt { get; set; }
        public decimal rec_debit { get; set; }
        public decimal rec_total { get; set; }
        public decimal rec_advance { get; set; }
        public string rec_status { get; set; }
        public string rec_branch_name { get; set; }
        public string rec_madeby_name { get; set; }
        public int patId { get; set; }
        public string pat_code { get; set; }
        public string pat_name { get; set; }
        public DateTime pat_dob { get; set; }
        public string pat_class { get; set; }
        public string pat_mob { get; set; }
        public string pat_email { get; set; }
        public string pat_gender { get; set; }
        public string pat_emirateid { get; set; }
        public DateTime id_card_edate { get; set; }
        public decimal rec_cc2 { get; set; }
        public decimal rec_cc_charges2 { get; set; }
        public decimal rec_total_allocated { get; set; }
        public decimal rec_balance { get; set; }
        public string rec_payment_status { get; set; }
        public string rec_refund_ag_adv_code { get; set; }
        public string emp_name { get; set; }
        public string emp_dept_name { get; set; }
        public string emp_color { get; set; }
        public string emp_license { get; set; }

    }
}
