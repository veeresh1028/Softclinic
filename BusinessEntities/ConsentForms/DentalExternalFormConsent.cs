using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BusinessEntities.ConsentForms
{
    public class DentalExternalFormConsent
    {
        

        public int cde_Id { get; set; }
        public int cde_appId { get; set; }
         public string cde_check1 {  get; set; }	
        public string cde_text1 {  get; set; }
        public string cde_text2 {  get; set; }
        public string cde_image { get; set; }
        public string image { get; set; }
        [AllowHtml]
        public string cde_status { get; set; }
        public DateTime cde_date_modified { get; set; }
    }
}
