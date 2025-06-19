using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Common
{
    public class ApplicationError
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorTrace { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string ErrorDetail { get; set; }
    }
}
