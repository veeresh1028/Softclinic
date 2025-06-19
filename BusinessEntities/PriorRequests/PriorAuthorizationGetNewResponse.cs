using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.PriorRequests
{
    public class PriorAuthorizationGetNewResponse
    {
        public class Entity
        {
            public string ID { get; set; }
            public string SenderID { get; set; }
            public string ReceiverID { get; set; }
            public string RecordCount { get; set; }
            public string TransactionDate { get; set; }
            public string CreationDate { get; set; }
            public string Downloaded { get; set; }
            public string DownloadedDateGeneratedString { get; set; }
        }

        public class PriorAuthorization_GetNew
        {
            public List<Entity> Entities { get; set; }
            public string StatusCode { get; set; }
            public string Message { get; set; }
            public string Success { get; set; }
            public string UserMessage { get; set; }
            public List<object> Error { get; set; }
        }
    }
}
