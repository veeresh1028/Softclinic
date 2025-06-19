using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class PainScale
    {
        public int paId { get; set; }
        public int pa_appId { get; set; }
       // public int pa_pain { get; set; }
        public DateTime app_fdate { get; set; }
        public string pa_status { get; set; }
        public int pa_madeby { get; set; }
        public string doctor_name { get; set; }

       
        private int _pa_pain = 0;
        public int pa_pain
        {
            get
            {
                return _pa_pain;
            }
            set
            {
                _pa_pain = value;
            }
        }
    }
}
