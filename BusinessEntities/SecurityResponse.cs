using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class SecurityResponse
    {
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public string ProductStatus { get; set; }
        public string ErrorMessage { get; set; }
        public string DisplayMessage { get; set; }
    }
}
