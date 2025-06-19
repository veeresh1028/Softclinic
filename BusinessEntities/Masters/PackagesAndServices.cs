using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Masters
{
    public class PackagesAndServices
    {
        public int pkgId { get; set; }
        public int pkg_madeby { get; set; }
        public DateTime pkg_date { get; set; }
        public string pkg_code { get; set; }
        public string pkg_name { get; set; }
        public decimal pkg_price { get; set; }
        public string pkg_status { get; set; }
        public string actionvisible { get; set; }
        public string pkg_madeby_name { get; set; }
        public string pkg_date_created { get; set; }
    }
}
