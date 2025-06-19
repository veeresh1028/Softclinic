using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class SourceCampaigns
    {
        public int eqcId { get; set; }
        public int eqc_slno { get; set; }
        public string eqc_code { get; set; }
        public string eqc_title { get; set; }
        public string eqc_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public string eqc_status { get; set; }
        public int empId { get; set; }
        public int eqc_madeby { get; set; }
        public DateTime eqc_start_date { get; set; }
        public DateTime eqc_end_date { get; set; }
        public DateTime eqc_date_created { get; set; }
        public DateTime eqc_date_modified { get; set; }
    }

    public class SourcewiseCampaigns
    {
        public int eqcId { get; set; }
        public int escId { get; set; }
        public int esc_eqcId { get; set; }
        public string esc_title { get; set; }
        public string esc_desc { get; set; }
        public string esc_madeby_name { get; set; }
        public string actionvisible { get; set; }
        public string esc_status { get; set; }
        public int empId { get; set; }
        public int esc_madeby { get; set; }
        public DateTime esc_start_date { get; set; }
        public DateTime esc_end_date { get; set; }
        public DateTime esc_date_created { get; set; }
        public DateTime esc_date_modified { get; set; }

    }
}