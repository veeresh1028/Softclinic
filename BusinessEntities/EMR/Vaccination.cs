using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class Vaccination
    { 
        public int pvId { get; set; }
        public int pv_appId { get; set; }
        public int pv_vaccination { get; set; }
        public string pv_notes { get; set; }
        public string pv_batchno { get; set; }
        public string pv_manufacturer { get; set; }
        public string pv_status { get; set; }
        public int pv_madeby { get; set; }
        public DateTime pv_exp_date { get; set; }
        public DateTime pv_date { get; set; }
        public string pv_dose { get; set; }
        public string v_code { get; set; }
        public string v_name { get; set; }
        public string pv_reminder_notes { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public string emp_license { get; set; }
    }
    public class VaccinationRecord
    {
        public int vac_recId { get; set; }
        public int vac_rec_patId { get; set; }
        public DateTime vac_rec_date1 { get; set; }
        public DateTime vac_rec_date2 { get; set; }
        public DateTime vac_rec_date3 { get; set; }
        public DateTime vac_rec_date4 { get; set; }
        public DateTime vac_rec_date5 { get; set; }
        public DateTime vac_rec_date6 { get; set; }
        public DateTime vac_rec_date7 { get; set; }
        public DateTime vac_rec_date8 { get; set; }
        public DateTime vac_rec_date9 { get; set; }
        public DateTime vac_rec_date10 { get; set; }
        public DateTime vac_rec_date11 { get; set; }
        public DateTime vac_rec_date12 { get; set; }
        public DateTime vac_rec_date13 { get; set; }
        public DateTime vac_rec_date14 { get; set; }
        public DateTime vac_rec_date15 { get; set; }
        public DateTime vac_rec_date16 { get; set; }
        public DateTime vac_rec_date17 { get; set; }
        public DateTime vac_rec_date18 { get; set; }
        public DateTime vac_rec_date19 { get; set; }
        public DateTime vac_rec_date20 { get; set; }
        public DateTime vac_rec_date21 { get; set; }
        public DateTime vac_rec_date22 { get; set; }
        public DateTime vac_rec_date23 { get; set; }
        public DateTime vac_rec_date24 { get; set; }
        public DateTime vac_rec_date25 { get; set; }
        public DateTime vac_rec_date26 { get; set; }
        public DateTime vac_rec_date27 { get; set; }
        public DateTime vac_rec_date28 { get; set; }
        public DateTime vac_rec_date29 { get; set; }
        public DateTime vac_rec_date30 { get; set; }
        public DateTime vac_rec_date31 { get; set; }
        public DateTime vac_rec_date32 { get; set; }
        public DateTime vac_rec_date33 { get; set; }
        public DateTime vac_rec_date34 { get; set; }
        public DateTime vac_rec_date35 { get; set; }
        public DateTime vac_rec_date36 { get; set; }
        public string vac_rec_status { get; set; }
        public int vac_rec_madeby { get; set; }
        
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public string emp_license { get; set; }

        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class Vaccination2
    {
        public int vac_appId { get; set; }
        public int vacId { get; set; }
        
        public string vac_status { get; set; }
        public string vac_name { get; set; }
        public int vac_madeby { get; set; }

        public DateTime vac_date1 { get; set; }
        public DateTime vac_date2 { get; set; }
        public DateTime vac_date3 { get; set; }
        public DateTime vac_date4 { get; set; }
        public DateTime vac_date5 { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public string emp_license { get; set; }

        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
