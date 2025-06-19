using BusinessEntities;
using SecurityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CommunicationMedia
    {
        public static List<BusinessEntities.CommunicationTemplate> GetTemplates(int? templateId, int? tempFor)
        {
            List<BusinessEntities.CommunicationTemplate> tempList = new List<BusinessEntities.CommunicationTemplate>();
            DataTable dt = DataAccessLayer.CommunicationMedia.GetTemplates(templateId, tempFor);

            foreach (DataRow dr in dt.Rows)
            {
                BusinessEntities.CommunicationTemplate temp = new BusinessEntities.CommunicationTemplate();
                temp.TemplateId = int.Parse(dr["TemplateId"].ToString());
                temp.TempName = dr["TempName"].ToString();
                temp.TempContent = dr["TempContent"].ToString();
                temp.TempFor = dr["TempFor"].ToString();
                temp.TempStatus = dr["TempStatus"].ToString();
                temp.TempWhatsapp = bool.Parse(dr["TempWhatsapp"].ToString());
                temp.TempSMS = bool.Parse(dr["TempSMS"].ToString());
                temp.TempEmail = bool.Parse(dr["TempEmail"].ToString());
                temp.TempCreatedBy = int.Parse(dr["TempCreatedBy"].ToString());
                temp.TempCreatedTimeStamp = DateTime.Parse(dr["TempCreatedTimeStamp"].ToString());
                temp.TempUpdatedBy = int.Parse(dr["TempUpdatedBy"].ToString());
                temp.TempUpdatedTimeStamp = DateTime.Parse(dr["TempUpdatedTimeStamp"].ToString());
                tempList.Add(temp);
            }

            int _temp = 0; int.TryParse(templateId.ToString(), out _temp);
            if (_temp > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    string TempContent = tempList[0].TempContent;
                    DataTable dt_params = DataAccessLayer.CommunicationMedia.GetTemplateParameters(_temp);

                    foreach (DataRow dr in dt_params.Rows)
                    {
                        if (dr["TParamType"].ToString() == "Custom")
                        {
                            TempContent = TempContent.Replace("{{" + dr["TParamKey"].ToString().Trim() + "}}", dr["TParamValue"].ToString().Trim());
                        }
                    }

                    tempList[0].TempContent = TempContent;
                }
            }

            return tempList;
        }

        public static WhatsappConfig WhatsappConfig(int? empId, int? branchId)
        {
            string wa_instance = string.Empty;
            string wa_token = string.Empty;
            DataAccessLayer.CommunicationMedia.WhatsappConfig(empId, branchId, out wa_instance, out wa_token);
            WhatsappConfig config = new WhatsappConfig();
            config.AccessToken = wa_token;
            config.InstanceId = wa_instance;

            return config;
        }

        public static SMSConfig SMSConfig(int branchId)
        {
            DataTable dt = DataAccessLayer.CommunicationMedia.SMSConfig(branchId);
            SMSConfig config = new SMSConfig();
            config.APIKey = dt.Rows[0]["set_sms_id"].ToString();
            config.Password = dt.Rows[0]["set_sms_pass"].ToString();
            config.SenderID = dt.Rows[0]["set_sms_sender"].ToString();
            return config;
        }

        public static DataTable EmailConfig(int templateId)
        {
            return DataAccessLayer.CommunicationMedia.EmailConfig(templateId);
            //SMSConfig config = new SMSConfig();
            //config.APIKey = dt.Rows[0]["set_sms_id"].ToString();
            //config.Password = dt.Rows[0]["set_sms_pass"].ToString();
            //config.SenderID = dt.Rows[0]["set_sms_sender"].ToString();
            //return config;
        }

        public static void SendingMessageAudit(string type, int receiverId, string receiver, string receiverAccount, int sendBy, bool status, string response, int invId, string refType)
        {
            DataAccessLayer.CommunicationMedia.SendingMessageAudit(type, receiverId, receiver, receiverAccount, sendBy, status, response, invId, refType);
        }

        public static bool isMediaEnabled(string value, string type, int id)
        {
            return DataAccessLayer.CommunicationMedia.isMediaEnabled(value, type, id);
        }

        public static string FormatTemplateContent(string content, int? appId, int? patId)
        {
            string _content = content;
            DataTable dt = DataAccessLayer.CommunicationMedia.TemplateParameters_ByDB(appId, patId);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                _content = _content.Replace("{{PatientID}}", dr["patId"].ToString());
                _content = _content.Replace("{{PatientName}}", dr["pat_name"].ToString());
                _content = _content.Replace("{{MRN}}", dr["pat_code"].ToString());
                _content = _content.Replace("{{DOB}}", DateTime.Parse(dr["pat_dob"].ToString()).ToString("dd/MM/yyyy"));
                _content = _content.Replace("{{Gender}}", dr["pat_gender"].ToString());
                _content = _content.Replace("{{CivilStatus}}", dr["pat_ms"].ToString());
                _content = _content.Replace("{{Mobile}}", dr["pat_mob"].ToString());
                _content = _content.Replace("{{Email}}", dr["pat_email"].ToString());
                _content = _content.Replace("{{Nationality}}", dr["Nationality"].ToString());

                if (int.Parse(dr["appId"].ToString()) > 0)
                {
                    _content = _content.Replace("{{BarcodeNo}}", dr["appId"].ToString());
                    _content = _content.Replace("{{AppointmentDate}}", DateTime.Parse(dr["app_fdate"].ToString()).ToString("dd/MM/yyyy"));
                    _content = _content.Replace("{{StartTime}}", dr["app_doc_ftime"].ToString());
                    _content = _content.Replace("{{EndTime}}", dr["app_doc_ttime"].ToString());
                    _content = _content.Replace("{{AppointmentTime}}", dr["app_time"].ToString());
                    _content = _content.Replace("{{Cash/Insurance}}", dr["app_ic_name"].ToString());
                    _content = _content.Replace("{{Doctor}}", dr["doctor"].ToString());
                    _content = _content.Replace("{{DoctorLicense}}", dr["emp_license"].ToString());
                    _content = _content.Replace("{{DoctorDepartment}}", dr["emp_dept_name"].ToString());
                    _content = _content.Replace("{{DoctorDesignation}}", dr["emp_desig_name"].ToString());
                    _content = _content.Replace("{{AppointmentStatus}}", dr["app_status"].ToString());
                    _content = _content.Replace("{{FollowupType}}", dr["app_type"].ToString());
                    _content = _content.Replace("{{BookingBranch}}", dr["set_company"].ToString());
                    _content = _content.Replace("{{RoomNo}}", dr["room"].ToString());
                    _content = _content.Replace("{{AppointmentCreatedBy}}", dr["madeBy"].ToString());
                }
            }

            return _content;
        }

        public static async Task<string> SentEmail(string content, DataTable dt, string usermail)
        {
            string result = string.Empty;

            string htmlString = EmailTemplate(dt.Rows[0], content);

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(dt.Rows[0]["ES_DisplayMail"].ToString());
                message.To.Add(new MailAddress(usermail.ToString()));
                message.ReplyToList.Add(new MailAddress(dt.Rows[0]["ES_ReplyToMail"].ToString()));
                message.Subject = dt.Rows[0]["ES_Subject"].ToString();
                message.IsBodyHtml = true;
                message.Body = htmlString;
                smtp.Port = int.Parse(dt.Rows[0]["ES_Port"].ToString());
                smtp.Host = dt.Rows[0]["ES_SMTP"].ToString();
                smtp.EnableSsl = bool.Parse(dt.Rows[0]["ES_SSLEnabled"].ToString());
                smtp.UseDefaultCredentials = bool.Parse(dt.Rows[0]["ES_Credentials"].ToString());
                smtp.Credentials = new NetworkCredential(dt.Rows[0]["ES_FromMail"].ToString(), dt.Rows[0]["ES_SMTPPassword"].ToString());
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtp.SendMailAsync(message);

                result = "success";
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

            return await Task.FromResult(result);
        }

        public static string EmailTemplate(DataRow dr, string content)
        {
            string html = "<div style='background-color: #f6f6f6; font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;'>" +
        "<table role='presentation' border='0' cellpadding='0' cellspacing='0' class='body' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;'>" +
            "<tr>" +
                "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>&nbsp;</td>" +
                "<td class='container' style='font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto; max-width: 580px; padding: 10px; width: 580px;'>" +
                    "<div class='content' style='box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;'>" +
                        "<table role='presentation' class='main' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px;'>" +
                            "<tr>" +
                                "<td class='wrapper' style='font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;'>" +
                                    "<table role='presentation' border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'>" +
                                        "<tr>" +
                                            "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>" +
                                                "<a href='" + dr["ES_LogoLink"].ToString() + "'><img src='" + dr["ES_LogoPath"].ToString() + "' style = 'width:40%;margin-left: 28%;'> </a>" +
                                                "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>" +
                                                    content +
                                                "</p> " +

                                                "<p style='font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;'>" +
                                                    dr["ES_RegardsText"].ToString() +
                                                 "</p>" +
                                            "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</td>" +
                        "</tr>" +
                        "</table>" +
                        "<div class='footer' style='clear: both; Margin-top: 10px; text-align: center; width: 100%;'>" +
                            "<table role='presentation' border='0' cellpadding='0' cellspacing='0' style='border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;'>" +
                                "<tr>" +
                                    "<td class='content-block' style='font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;'>" +
                                        "<span class='apple-link' style='color: #999999; font-size: 12px; text-align: center;'> " +
                                            dr["ES_CopyrightText"].ToString() +
                                        "</span>" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</div>" +
                        "<div class='footer1' style='text-align:center;margin:auto;margin-top:-2%;'>" +
                            "<div style='margin-top:2%;'>" +
                                "<a href='" + dr["ES_SocialGmap"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Location </a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialTwitter"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Twitter</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialFb"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Facebook</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialInsta"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Instagram</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialLinkedIn"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>LinkedIn</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialWhatsapp"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Whatsapp</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialTelegram"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Telegram</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialYoutube"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Youtube</a>&nbsp;|&nbsp;" +
                                "<a href='" + dr["ES_SocialSnap"].ToString() + "' target='blank' style='color: #66952c; text-decoration: none;'>Snapchat</a>" +
                            "</div>" +
                            "<div style='margin-top:0%'><p style='font-size:0.7vw; color:gray;'>" + dr["ES_FooterAddress"].ToString() + "<br>" +
                            " <a href='mailto:" + dr["ES_FooterMail"].ToString() + "' style='color: #66952c; text-decoration: none;'>" + dr["ES_FooterMail"].ToString() + "</a> | " +
                            " Call us on : " + dr["ES_FooterPhone"].ToString() + " | <a href='" + dr["ES_FooterWeb"].ToString() + "' style='color: #66952c; text-decoration: none;'>" + dr["ES_FooterWeb"].ToString() + "</a><br></div>" +
                            "<div> <p style='font-size:0.7vw; color:gray;'>Powered by <a href='https://www.visionsoftwares.com/' style='text-decoration: none; color: #66952c;' target='blank'> <b>Vision Technologies</b> </a></p></div>" +
                            "</div>" +
                        "</div>" +
                "</td>" +
                "<td style='font-family: sans-serif; font-size: 14px; vertical-align: top;'>&nbsp;</td>" +
            "</tr>" +
    "</table>";

            return html;
        }
    }
}