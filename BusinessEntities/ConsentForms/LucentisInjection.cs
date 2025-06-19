using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.ConsentForms
{
    public class LucentisInjection
    {
        public int lipId { get; set; }
        public int lip_appId { get; set; }
        public string lip_1 { get; set; }
        public string lip_2 { get; set; }
        public string lip_status { get; set; }
        public DateTime lip_date_modified { get; set; }
    }
}
