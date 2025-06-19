using BusinessEntities.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class DentalCharting
    {
        public int patId { get; set; }
        public int appId { get; set; }
        public string formname { get; set; }
        public string formlink { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string cdc_note { get; set; }
        public string psb_sign { get; set; }
        public string path { get; set; }
        public int cdcId { get; set; }
        public int cdc_appId { get; set; }
        public int cdc_patId { get; set; }
        public string cdc_chartname { get; set; }
        public string cdc_status { get; set; }
        public int cdc_madeby { get; set; }
        public DateTime cdc_date_created { get; set; }
        public DateTime cdc_date_modified { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class Dental_PerioChart
    {
        public PerioChart dental_perio { get; set; }
        public List<PerioChartDetails> dental_perio_details { get; set; }
    }
    public class PerioChart
    {
        public int perioId { get; set; }
        public int perio_appId { get; set; }
        public string perio_tooths { get; set; }
        
        public string perio_status { get; set; }
        public int perio_madeby { get; set; }
        public DateTime perio_date_created { get; set; }
        public DateTime perio_date_modified { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
    public class PerioChartDetails
    {
        public int pchdId { get; set; }
        public int pchd_appId { get; set; }
        public int pchd_tooth { get; set; }
        public string pchd_plaque { get; set; }
        public string pchd_mobility { get; set; }
        public string pchd_boneloss { get; set; }
        public string pchd_mgd { get; set; }
        public int pchd_calt1 { get; set; }
        public int pchd_calt2 { get; set; }
        public int pchd_calt3 { get; set; }
        public int pchd_gmt1 { get; set; }
        public int pchd_gmt2 { get; set; }
        public int pchd_gmt3 { get; set; }
        public int pchd_pdt1 { get; set; }
        public int pchd_pdt2 { get; set; }
        public int pchd_pdt3 { get; set; }
        public string pchd_t1 { get; set; }
        public string pchd_t2 { get; set; }
        public string pchd_t3 { get; set; }
        public string pchd_t4 { get; set; }
        public string pchd_t5 { get; set; }
        public string pchd_t6 { get; set; }
        public int pchd_pdb1 { get; set; }
        public int pchd_pdb2 { get; set; }
        public int pchd_pdb3 { get; set; }
        public int pchd_gmb1 { get; set; }
        public int pchd_gmb2 { get; set; }
        public int pchd_gmb3 { get; set; }
        public int pchd_calb1 { get; set; }
        public int pchd_calb2 { get; set; }
        public int pchd_calb3 { get; set; }
        public string pchd_status { get; set; }
        public int pchd_madeby { get; set; }
        public DateTime pchd_date_created { get; set; }
        public DateTime pchd_date_modified { get; set; }


    }
}
