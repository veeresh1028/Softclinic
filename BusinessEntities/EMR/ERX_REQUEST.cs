using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
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

    public class Patienterx
    {
        public string MemberID { get; set; }
        public string NationalIDNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ContactNumber { get; set; }
        public string Weight { get; set; }
        public string Email { get; set; }
    }

    public class Encounter
    {
        public string FacilityID { get; set; }
        public string Type { get; set; }
    }

    public class Diagnosis
    {
        public string Type { get; set; }
        public string Code { get; set; }
    }

    public class Frequency
    {
        public string UnitPerFrequency { get; set; }
        public string FrequencyValue { get; set; }
        public string FrequencyType { get; set; }
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
        public string Type { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }
        public string Duration { get; set; }
        public string UnitId { get; set; }
        public string Refills { get; set; }
        public string RoutOfAdmin { get; set; }
        public string Instructions { get; set; }
        public string Start { get; set; }
        public Frequency Frequency { get; set; }
        public List<Observation> Observation { get; set; }
    }

    public class Prescriptionerx
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public int ReferenceNumber { get; set; }
        public string Clinician { get; set; }
        public Patienterx Patient { get; set; }
        public Encounter Encounter { get; set; }
        public List<Diagnosis> Diagnosis { get; set; }
        public List<Activity> Activity { get; set; }
    }

    public class ErxRequest
    {
        public Header Header { get; set; }
        public Prescriptionerx Prescription { get; set; }
    }

    public class ERX_Request
    {
        public ErxRequest ErxRequest { get; set; }
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

    public class ERX_Response
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public string Success { get; set; }
        public string UserMessage { get; set; }
        public string EntityID { get; set; }
        public string ReferenceNumber { get; set; }
        public List<Error> Error { get; set; }
    }

    public class PropertyValue
    {
    }
}
