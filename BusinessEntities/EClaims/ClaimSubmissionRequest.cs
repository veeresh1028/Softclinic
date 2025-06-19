using BusinessEntities.EMR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EClaims
{
    public class ClaimSubmissionRequest
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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
            public string PatientID { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
            public string StartType { get; set; }
            public string EndType { get; set; }
            public string TransferSource { get; set; }
            public string TransferDestination { get; set; }
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
            public string Start { get; set; }
            public string Type { get; set; }
            public string Code { get; set; }
            public string Location { get; set; }
            public string Quantity { get; set; }
            public string Net { get; set; }
            public string Clinician { get; set; }
            public string PatientShare { get; set; }
            public string Duration { get; set; }
            public string PriorAuthorizationID { get; set; }
            public string DispensedActivityID { get; set; }
            public List<Observation> Observation { get; set; }
        }

        public class Claim
        {
            public string ID { get; set; }
            public string IDPayer { get; set; }
            public string Type { get; set; }
            public string MemberId { get; set; }
            public string DispensedID { get; set; }
            public string ProviderID { get; set; }
            public string Weight { get; set; }
            public string NationalIDNumber { get; set; }
            public string Gross { get; set; }
            public string PatientShare { get; set; }
            public string Net { get; set; }
            public string ReferenceNumber { get; set; }
            public string DateOfBirth { get; set; }
            public string Gender { get; set; }
            public Encounter Encounter { get; set; }
            public List<Diagnosis> Diagnosis { get; set; }
            public List<Activity> Activity { get; set; }
        }

        public class Submission
        {
            public Header Header { get; set; }
            public List<Claim> Claim { get; set; }
        }

        public class Submission_Request
        {
            public Submission Submission { get; set; }
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

        public class Submission_response
        {
            public string StatusCode { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
            public string UserMessage { get; set; }
            public string EntityID { get; set; }
            public List<Error> Error { get; set; }
        }


    }
}
