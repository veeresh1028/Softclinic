using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.PriorRequests
{
    public class PriorAuthorizationViewResponse
    {
        public class Header
        {
            public string SenderID { get; set; }
            public string ReceiverID { get; set; }
            public string TransactionDate { get; set; }
            public int RecordCount { get; set; }
            public string DispositionFlag { get; set; }
            public string PayerID { get; set; }
        }

        public class Activity
        {
            public string ID { get; set; }
            public string Type { get; set; }
            public string Code { get; set; }
            public double Quantity { get; set; }
            public double Net { get; set; }
            public double PatientShare { get; set; }
            public double PaymentAmount { get; set; }
            public string DenialCode { get; set; }
        }

        public class Authorization
        {
            public string Result { get; set; }
            public string ID { get; set; }
            public string IDPayer { get; set; }
            public string DenialCode { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
            public string Comments { get; set; }
            public List<Activity> Activity { get; set; }
        }

        public class Entity
        {
            public Header Header { get; set; }
            public Authorization Authorization { get; set; }
        }

        public class PriorAuthorization_ViewResponse
        {
            public Entity Entity { get; set; }
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
            public string UserMessage { get; set; }
            public List<object> Error { get; set; }
        }
    }
}
