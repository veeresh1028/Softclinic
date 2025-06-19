using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Treatments
    {
        public int trId { get; set; }
        public string set_company { get; set; }
        public string is_title { get; set; }
        public string ic_code { get; set; }
        public string ic_name { get; set; }
        public string ip_code { get; set; }
        public string ip_name { get; set; }
        public string tr_status { get; set; }
        public int tr_itype { get; set; }
        public string tr_lcode { get; set; }
        public string actionvisible { get; set; }
        public string tr_icode { get; set; }
        public string tr_code { get; set; }
        public string tg_group { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public string tr_class { get; set; }
        public string tr_lab_dept { get; set; }
        public string tr_dent_option { get; set; }
        public DateTime tr_start_date { get; set; }
        public DateTime tr_end_date { get; set; }
        //public string tr_category { get; set; }
        public decimal tr_vat { get; set; }
        //public decimal tr_vat2 { get; set; }
        public decimal tr_price { get; set; }
        public decimal tr_cost { get; set; }
        public decimal tr_disc { get; set; }
        public int tr_branch { get; set; }
        public int tr_ins { get; set; }
        public int tr_group { get; set; }
        public string tr_tooth { get; set; }
        public string tr_disc_type { get; set; }
        public int tr_rdays { get; set; }
        public int tr_dept { get; set; }
        public int tr_parent { get; set; }
        public int tr_madeby { get; set; }
        public int tr_modifyby { get; set; }
        public int tr_tat { get; set; }
        public int tr_tat2 { get; set; }
        public int tr_time { get; set; }
        public string tr_footer { get; set; }
        public string tr_units { get; set; }
        public string tr_format { get; set; }
        public string tr_methodology { get; set; }
        public string tr_norm_range { get; set; }
        public string department { get; set; }
        public string tr_notes { get; set; }
        public DateTime tr_date_created { get; set; }
        public DateTime tr_date_modified { get; set; }
        [NotMapped]
        public List<CommonDDL> BranchList { get; set; }
    }

    public class TreatmentsSearch
    {
        public int search_type { get; set; } = 0;
        public string branch_ids { get; set; } = string.Empty;
        public string select_status { get; set; } = string.Empty;
        public string select_tpa { get; set; } = string.Empty;
        public string select_scheme { get; set; } = string.Empty;
        public string select_group { get; set; } = string.Empty;
        public string select_vat { get; set; } = string.Empty;
        public string select_lab { get; set; } = string.Empty;
        public string select_type { get; set; } = string.Empty;
        public string select_activity { get; set; } = string.Empty;
        public Nullable<DateTime> date_from { get; set; } = DateTime.Parse("1900-01-01");
        public Nullable<DateTime> date_to { get; set; } = DateTime.Parse("1900-01-01");
    }
}
