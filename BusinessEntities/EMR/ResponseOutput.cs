using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class ResponseOutput
    {
        public int status { get; set; }
        public string message { get; set; }
        public string error { get; set; }
        public string filename { get; set; }
        public string filepath { get; set; }
        public string speechtext { get; set; }
    }
}
