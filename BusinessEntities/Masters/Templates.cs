using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class Templates
    {
        public int TemplateId  { get; set; }
        public int TempCreatedBy { get; set; }
        public int TempUpdatedBy { get; set; }
        public string TempStatus  { get; set; }
        public string TempName  { get; set; }
        public string TempFor { get; set; }
        public string TempContent { get; set; }
        public string actionvisible { get; set; }
        public string TParamKey { get; set; }
        public string TParamType { get; set; }
        public string TParamValue { get; set; }
        public DateTime TempCreatedTimeStamp { get; set; }
        public int TempWhatsapp { get; set; }
        public int TempSMS { get; set; }
        public int TempEmail { get; set; }
    }
}
