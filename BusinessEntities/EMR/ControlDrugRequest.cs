using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessEntities.EMR
{
    public class ControlDrugRequest
    {
        public string resourceType { get; set; }
        public string intent { get; set; }
        public string status { get; set; }
        public Subject subject { get; set; }
        public string authoredOn { get; set; }
        public Requester requester { get; set; }
        public List<ReasonCode> reasonCode { get; set; }
        public DispenseRequest dispenseRequest { get; set; }
        public List<DosageInstruction> dosageInstruction { get; set; }
        public MedicationReference medicationReference { get; set; }
        public List<SupportingInformation> supportingInformation { get; set; }
    }


    public class Agent
    {
        public string reference { get; set; }
        public string display { get; set; }
    }

    public class Coding
    {
        public string code { get; set; }
        public string system { get; set; }
    }

    public class DispenseRequest
    {
        public ValidityPeriod validityPeriod { get; set; }
        public ExpectedSupplyDuration expectedSupplyDuration { get; set; }
        public int numberOfRepeatsAllowed { get; set; }
    }

    public class DosageInstruction
    {
        public string patientInstruction { get; set; }
        public Route route { get; set; }
        public DoseQuantity doseQuantity { get; set; }
        public Timing timing { get; set; }
    }

    public class DoseQuantity
    {
        public string unit { get; set; }
        public int value { get; set; }
    }

    public class ExpectedSupplyDuration
    {
        public string unit { get; set; }
        public int value { get; set; }
    }

    public class MedicationReference
    {
        public string reference { get; set; }
    }

    public class OnBehalfOf
    {
        public string reference { get; set; }
        public string display { get; set; }
    }

    public class ReasonCode
    {
        public List<Coding> coding { get; set; }
    }

    public class Repeat
    {
        public int frequency { get; set; }
        public int period { get; set; }
        public string periodUnit { get; set; }
    }

    public class Requester
    {
        public Agent agent { get; set; }
        public OnBehalfOf onBehalfOf { get; set; }
    }


    public class Route
    {
        public string text { get; set; }
    }

    public class Subject
    {
        public string reference { get; set; }
        public string display { get; set; }
    }

    public class SupportingInformation
    {
        public string reference { get; set; }
    }

    public class Timing
    {
        public Repeat repeat { get; set; }
    }

    public class ValidityPeriod
    {
        public string end { get; set; }
        public string start { get; set; }
    }

    // Patient 

    public class Patient_Resquest
    {
        public string resourceType { get; set; }
        public List<Name> name { get; set; }
        public bool active { get; set; }
        public string gender { get; set; }
        public List<Telecom> telecom { get; set; }
        public string birthDate { get; set; }
        public List<Identifier> identifier { get; set; }
    }
}
