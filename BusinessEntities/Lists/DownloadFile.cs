using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Lists
{
    public class DownloadFile
    {
        public string file { get; set; }    
        public string type { get; set; }
        public int id { get; set; }
    }

    public class DownloadEMID
    {
        public string id_card_front { get; set; }
        public string id_card_back { get; set; }
        public int id { get; set; }
    }
}