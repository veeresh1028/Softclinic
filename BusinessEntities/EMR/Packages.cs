using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class TodaySession
    { 
        public string inv_no { get; set; }
        public int rpsId { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string rps_noses { get; set; }
        public string ccdt_status { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
    }
    public class OnFlyPackages
    {
        public string inv_no { get; set; }
        public int ccdtId { get; set; }
        public string pt_tr_code { get; set; }
        public string pt_tr_name { get; set; }
        public string rps_noses { get; set; }
        public string ccdt_status { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public int used_ses { get; set; }
        public int bal_ses { get; set; }
        public int ccdt_noSes { get; set; }
    }

    public class PatientPackage
    {
        public int poId { get; set; }
        public int app_ins { get; set; }
        public int po_appId { get; set; }
        public int po_patId { get; set; }
        public int po_patient { get; set; } = 0;
        public int po_branch { get; set; }

        public int po_package { get; set; }
        public string po_services { get; set; }
        public string po_refno { get; set; }
        public DateTime po_date { get; set; }
        public DateTime po_exp_date { get; set; }
        public string po_notes { get; set; }
        public int po_madeby { get; set; }
        public string po_status { get; set; }
        public string po_details { get; set; }
        public string po_Servicesdetails { get; set; }
        public string actionvisible { get; set; }
    }
}
