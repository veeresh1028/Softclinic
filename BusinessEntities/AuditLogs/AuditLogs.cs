using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.AuditLogs
{
    public class AuditLogs
    {
        public int log_by { get; set; }
        public string log_desc { get; set; }
    }
}
