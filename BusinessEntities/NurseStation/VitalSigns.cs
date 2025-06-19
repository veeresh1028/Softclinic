using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.NurseStation
{
    public class VitalSigns
    {
        public int signId { get; set; }
        public int sign_appId { get; set; }
        public string sign_temp { get; set; }
        public string sign_pulse { get; set; }
        public string sign_bp { get; set; }
        public string sign_notes { get; set; }
        public string sign_height { get; set; }
        public string sign_weight { get; set; }
        public string sign_resp { get; set; }
        public string sign_spo2 { get; set; }
        public string sign_waist { get; set; }
        public string sign_hip { get; set; }
        public string sign_uri { get; set; }
        public string sign_head { get; set; }
        public string sign_bmi { get; set; }
        public string sign_bpd { get; set; }
        public string sign_sugar { get; set; }
        public string sign_status { get; set; }
        public int sign_madeby { get; set; }
        public int sign_modifyby { get; set; }
        public DateTime app_fdate { get; set; }
        public string doctor_name { get; set; }
        public DateTime today { get; set; } = DateTime.Parse(DateTime.Now.ToString());
    }

}
