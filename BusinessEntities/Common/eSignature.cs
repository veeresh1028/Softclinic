using BusinessEntities.Appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public class eSignature
    {
        public int patId { get; set; }
        public string person { get; set; }
        public string form { get; set; }
        public int appId { get; set; }
        public string formname { get; set; }
        public string formlink { get; set; }
        public string eSign { get; set; }
        public string psb_sign { get; set; }
        public string path { get; set; }
        public DateTime psb_date_Created { get; set; }
        public DateTime psb_date_modified { get; set; }
        public string Base64ImageData { get; set; }
        public string txtSignature { get; set; }
        public string txtDisplay { get; set; }
        public string pat_fname { get; set; }
        public string pat_lname { get; set; }
    }
}