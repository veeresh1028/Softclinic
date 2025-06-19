using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public class AppJourney
    {

        public int AJId { get; set; }
        public int AJ_AJCId { get; set; }
        public int AJ_AJSCId { get; set; }
        public int AJ_AppId { get; set; }
        public int AJ_PatId { get; set; }
        public string AJ_Status { get; set; }
        public int AJ_isCompleted { get; set; }
        public int AJ_Timestamp { get; set; }
    }
}
