using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters.AuditLogs
{
    public class TreatmentLogs
    {
        public int traId { get; set; }
        public int tra_dept { get; set; }
        public int tra_ins { get; set; }
        public string tra_code { get; set; }
        public string tra_name { get; set; }
        public decimal tra_price { get; set; }
        public string tra_type { get; set; }
        public decimal tra_disc { get; set; }
        public string tra_icode { get; set; }
        public string tra_category { get; set; }
        public string tra_lab_dept { get; set; }
        public string tra_lcode { get; set; }
        public int tra_group { get; set; }
        public int tra_branch { get; set; }
        public string tra_class { get; set; }
        public int tra_parent { get; set; }
        public decimal tra_cost { get; set; }
        public int tra_itype { get; set; }
        public string tra_tooth { get; set; }
        public string tra_disc_type { get; set; }
        public DateTime tra_start_date { get; set; }
        public DateTime tra_end_date { get; set; }
        public decimal tra_vat { get; set; }
        public decimal tra_disc_value { get; set; }
        public decimal tra_vat2 { get; set; }
        public string tra_dent_option { get; set; }
        public string tra_dent_option_1 { get; set; }
        public string tra_dent_option_2 { get; set; }
        public string tra_tat { get; set; }
        public string tra_norm_range { get; set; }
        public string tra_methodology { get; set; }
        public string tra_units { get; set; }
        public decimal tra_tat2 { get; set; }
        public string tra_footer { get; set; }
        public string tra_format { get; set; }
        public string tra_status { get; set; }
        public int tra_rdays { get; set; }
        public int tra_madeby { get; set; }
        public int tra_modifyby { get; set; }
        public string tra_operation { get; set; }
        public DateTime tra_date_created { get; set; }
        public DateTime tra_date_modified { get; set; }

        public string emp_name { get; set; }
        public string department { get; set; }
        public string dept_code { get; set; }
        public string ic_name { get; set; }
        public string tg_group { get; set; }
        public string set_company { get; set; }
    }
}
