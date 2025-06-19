using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class Radiology
    {
        public int lrId { get; set; }
        public int lr_test { get; set; }
        public int ptId { get; set; }
        public int lr_appId { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public string lr_from { get; set; }
        public string lr_lab_name { get; set; }
        public string lr_result { get; set; }
        public string lr_image1 { get; set; }
        public string lr_status { get; set; }
        public int lr_madeby { get; set; }
        public string lr_madeby_name { get; set; }
        public DateTime lr_date_created { get; set; }
        public FileInfo file { get; set; }
    }
    public class ReportResults
    {
        public int radrId { get; set; }
        public int radr_ptId { get; set; }
        public int ptId { get; set; }
        public int radr_appId { get; set; }
        public string tr_code { get; set; }
        public string tr_name { get; set; }
        public string tr_type { get; set; }
        public string radr_type { get; set; }
        public string radr_title { get; set; }
        [AllowHtml]
        public string radr_report { get; set; }
        public string radr_status { get; set; }
        public int radr_madeby { get; set; }
        public string radr_madeby_name { get; set; }
        public DateTime radr_date_created { get; set; }
        public FileInfo file { get; set; }
    }
}
