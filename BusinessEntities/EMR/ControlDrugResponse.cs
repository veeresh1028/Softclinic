using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.EMR
{
    public class ControlDrugResponse
    {
        public string resourceType { get; set; }
        public List<Issue> issue { get; set; }
    }
    public class ResCoding
    {
        public string code { get; set; }
    }

    public class Details
    {
        public List<ResCoding> coding { get; set; }
        public string text { get; set; }
    }

    public class Issue
    {
        public string severity { get; set; }
        public string code { get; set; }
        public Details details { get; set; }
    }

    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string id_token { get; set; }
    }

    // Patient 
    public class Patient_Response
    {
        public string resourceType { get; set; }
        public string type { get; set; }
        public int total { get; set; }
        public List<Link> link { get; set; }
        public List<Entry> entry { get; set; }
    }
    public class Address
    {
        public string use { get; set; }
        public string type { get; set; }
        public string text { get; set; }
    }

    public class Entry
    {
        public Resources resource { get; set; }
        public Request request { get; set; }
    }

    public class Identifier
    {
        public string use { get; set; }
        public string system { get; set; }
        public string value { get; set; }
    }

    public class Link
    {
        public string relation { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public string family { get; set; }
        public List<string> given { get; set; }
    }

    public class Request
    {
        public string method { get; set; }
    }

    public class Resources
    {
        public string resourceType { get; set; }
        public string id { get; set; }
        public List<Identifier> identifier { get; set; }
        public bool active { get; set; }
        public List<Name> name { get; set; }
        public List<Telecom> telecom { get; set; }
        public string gender { get; set; }
        public string birthDate { get; set; }
        public List<Address> address { get; set; }
    }



    public class Telecom
    {
        public string system { get; set; }
        public string value { get; set; }
        public string use { get; set; }
        public int rank { get; set; }
    }

}
