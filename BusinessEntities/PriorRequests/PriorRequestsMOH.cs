using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessEntities.PriorRequests
{
    public class PriorRequestsMOH
    {
        public class Header
        {
            public string SenderID { get; set; }

            public string ReceiverID { get; set; }

            public string TransactionDate { get; set; }

            public string RecordCount { get; set; }

            public string DispositionFlag { get; set; }

            public string PayerID { get; set; }
        }

        public class Encounter
        {
            public string FacilityID { get; set; }

            public string Type { get; set; }
        }

        public class DxInfo
        {
            public string Type { get; set; }

            public string Code { get; set; }
        }

        public class Diagnosis
        {
            public string Type { get; set; }

            public string Code { get; set; }

            public List<DxInfo> DxInfo { get; set; }
        }

        public class Observation
        {
            public string Type { get; set; }

            public string Code { get; set; }

            public string Value { get; set; }

            public string ValueType { get; set; }
        }

        public class Activity
        {
            public string ID { get; set; }

            public string ActivityReference { get; set; }

            public string Start { get; set; }

            public string Type { get; set; }

            public string Code { get; set; }

            public string Location { get; set; }

            public string Quantity { get; set; }

            public string Unit { get; set; }

            public string Net { get; set; }

            public string Clinician { get; set; }

            public string Duration { get; set; }

            public List<Observation> Observation { get; set; }
        }

        public class Authorization
        {
            public string Type { get; set; }

            public string ID { get; set; }

            public string RequestType { get; set; }

            public string RequestReferenceNumber { get; set; }

            public string MemberID { get; set; }

            public string Weight { get; set; }

            public string EmiratesIDNumber { get; set; }

            public string DateOrdered { get; set; }

            public string DateOfBirth { get; set; }

            public string Gender { get; set; }

            public Encounter Encounter { get; set; }

            public List<Diagnosis> Diagnosis { get; set; }

            public List<Activity> Activity { get; set; }
        }

        public class PriorRequest
        {
            public Header Header { get; set; }

            public Authorization Authorization { get; set; }
        }

        public class Prior_Request
        {
            public PriorRequest PriorRequest { get; set; }
        }

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
        [XmlRoot(ElementName = "Files")]
        public class Prior_request_response
        {
            public string StatusCode { get; set; }

            public string Message { get; set; }

            public string Success { get; set; }

            public string UserMessage { get; set; }

            public string EntityID { get; set; }

            public string ReferenceNumber { get; set; }

            public List<Error> Error { get; set; }
            [XmlElement("File")]
            public List<File> Files { get; set; }
        }

        public class DownloadFile
        {
            public string FileID { get; set; }

            public string FileName { get; set; }

            public string SenderID { get; set; }

            public string ReceiverID { get; set; }

            public DateTime TransactionDate { get; set; }

            public int RecordCount { get; set; }
            public bool IsDownloaded { get; set; }

            public List<Error> File { get; set; }
        }
       
        public class File
        {
            [XmlAttribute("FileID")]
            public string FileID { get; set; }

            public string FileName { get; set; }

            public string SenderID { get; set; }

            public string ReceiverID { get; set; }

            public DateTime TransactionDate { get; set; }

            public int RecordCount { get; set; }
            public bool IsDownloaded { get; set; }


            // Other properties...
        }
    }
}
