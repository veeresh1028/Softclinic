using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessEntities
{
    public class CommunicationTemplate
    {
        public int TemplateId { get; set; }
        public string TempName { get; set; }
        public string TempContent { get; set; }
        public string TempFor { get; set; }
        public string TempStatus { get; set; }
        public bool TempWhatsapp { get; set; }
        public bool TempSMS { get; set; }
        public bool TempEmail { get; set; }
        public int TempCreatedBy { get; set; }
        public DateTime TempCreatedTimeStamp { get; set; }
        public int TempUpdatedBy { get; set; }
        public DateTime TempUpdatedTimeStamp { get; set; }
    }

    public class WhatsappConfig
    {
        public string InstanceId { get; set; }
        public string AccessToken { get; set; }
    }

    public class CommunicationObject
    {
        public int branchId { get; set; }
        public int user { get; set; }
        public string mobile { get; set; }
        public string content { get; set; }
        public int templateId { get; set; }
        public string email { get; set; }
    }

    public class WhatsappResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public WA_Data data { get; set; }
    }

    public class WA_Data
    {
        public WA_Key key { get; set; }
        public WA_Message message { get; set; }
        public string messageTimestamp { get; set; }
        public string status { get; set; }
    }

    public class WA_ExtendedTextMessage
    {
        public string text { get; set; }
    }

    public class WA_Key
    {
        public string remoteJid { get; set; }
        public bool fromMe { get; set; }
        public string id { get; set; }
    }

    public class WA_Message
    {
        public WA_ExtendedTextMessage extendedTextMessage { get; set; }
    }


    public class SMSConfig
    {
        public string APIKey { get; set; }
        public string Password { get; set; }
        public string SenderID { get; set; }
    }

    public class BarcodeService
    {
        public int BranchId { get; set; }
        public int ItemId { get; set; }
        public int ibId { get; set; }
        public string BranchName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Expdate { get; set; }
        public string ItemPrice { get; set; }
        public int Qty { get; set; }
    }

    public class SendAttachment
    {
        public int id { get; set; }
        public string ref_no { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public int user { get; set; }
        public string user_name { get; set; }
    }

    public class MediaPost
    {
        public string Data { get; set; }
    }

    public class MediaResponse
    {
        public HttpPostedFile wav;

        public string PublicPath { get; set; }
    }
}