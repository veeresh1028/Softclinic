using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.EMR
{
    public class JustificationLetter
    {
        public int jlId { get; set; }
        public int jl_appId { get; set; }
        [AllowHtml]
        public string jl_note { get; set; }
        public DateTime jl_date { get; set; }
        public string jl_status { get; set; }
        public int jl_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }

    public class HealthDeclaration
    {
        public int chd_Id { get; set; }
        public int chd_appId { get; set; }
        
        public string chd_checkbox { get; set; }
        public string chd_Prob1 { get; set; }
        public string chd_Prob2 { get; set; }
        public string chd_Prob3 { get; set; }
        public string chd_Prob4 { get; set; }
        public string chd_Prob5 { get; set; }
        public string chd_status { get; set; }
        public int pa_pain { get; set; }
        public int paId { get; set; }
        public int chd_madeby { get; set; }

        public string doctor_name { get; set; }
        public DateTime app_fdate { get; set; }
        public string set_header_image { get; set; }
        public string set_footer_image { get; set; }
    }
}
