using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class UploadDocumentResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class PropertyValue
        {
        }

        public class Error
        {
            public string AdditionalReference { get; set; }
            public string AdditionalReferenceObjectName { get; set; }
            public string Reference { get; set; }
            public string ReferenceObjectName { get; set; }
            public string PropertyName { get; set; }
            public PropertyValue PropertyValue { get; set; }
            public string RuleCode { get; set; }
            public string ErrorText { get; set; }
            public string ObjectName { get; set; }
            public string Transaction { get; set; }
        }

        public class UploadDocument_Response
        {
            public string StatusCode { get; set; }
            public string Message { get; set; }
            public string Success { get; set; }
            public string UserMessage { get; set; }
            public string EntityID { get; set; }
            public string ReferenceNumber { get; set; }
            public List<Error> Error { get; set; }
        }


    }
}
